using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class NumberGMPSertEditorForm : DialogForm
    {
        /// <summary>
        /// Код товара
        /// </summary>
        public int ItemID { get; private set; }

        /// <summary>
        /// Код документа
        /// </summary>
        public long DocID { get; private set; }

        /// <summary>
        /// Номер позиции перечня
        /// </summary>
        public int LineID { get; private set; }

        /// <summary>
        /// № GMP (список)
        /// </summary>
        public string NumberGMPSert { get; private set; }

        /// <summary>
        /// Идентификатор GMP (список)
        /// </summary>
        public string ID_GMPSert { get; private set; }

        public NumberGMPSertEditorForm()
        {
            InitializeComponent();
        }

        public NumberGMPSertEditorForm(long docID, int lineID, int itemID, string numberGMPSert)
            : this()
        {
            DocID = docID;
            LineID = lineID;
            ItemID = itemID;
            NumberGMPSert = numberGMPSert;
        }

        private void NumberGMPSertEditorForm_Load(object sender, EventArgs e)
        {
            LoadGMP();
            LoadSelectedGMP();

            AdaptSelectedGMP();
        }

        /// <summary>
        /// Получение GMP сертификатов
        /// </summary>
        private void LoadGMP()
        {
            try
            {
                gMP_SertTableAdapter.Fill(quality.GMP_Sert, this.UserID, this.ItemID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения GMP", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Получение выбранных GMP сертификатов
        /// </summary>
        private void LoadSelectedGMP()
        {
            try
            {
                using (var adapter = new Data.QualityTableAdapters.GMP_Selected_SertTableAdapter())
                    adapter.Fill(quality.GMP_Selected_Sert, this.UserID, this.DocID, this.LineID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения выбранных GMP", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Адаптация выбранных сертификатов
        /// </summary>
        private void AdaptSelectedGMP()
        {
            foreach (Data.Quality.GMP_Selected_SertRow selectedGMP in quality.GMP_Selected_Sert.Rows)
            {
                var findGMP = quality.GMP_Sert.FindByGMP_ID(selectedGMP.GMP_ID);
                if (findGMP != null)
                    findGMP.IsChecked = true;
            }

            foreach (var selectedGMP in (NumberGMPSert ?? string.Empty).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var findAllGMP = quality.GMP_Sert.Select(string.Format("{0} = '{1}' AND {2} = 0", quality.GMP_Sert.Conclusion_NameColumn.Caption, selectedGMP.Trim(), quality.GMP_Sert.IsCheckedColumn.Caption));
                if (findAllGMP != null && findAllGMP.Length > 0)
                {
                    var findGMP = findAllGMP[0] as Data.Quality.GMP_SertRow;
                    findGMP.IsChecked = true;
                }
            }

            // Снимаем выделение со строк
            if (dgvGMP.Rows.Count > 0)
                dgvGMP.Rows[0].Selected = false;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(817, 8);
            btnCancel.Location = new Point(907, 8);
        }

        private void dgvGMP_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvGMP.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvGMP.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool isChecked = Convert.ToBoolean(this.dgvGMP.Rows[this.dgvGMP.CurrentRow.Index].Cells[this.colItemChecked.Index].Value);
                foreach (DataGridViewColumn column in this.dgvGMP.Columns)
                {
                    this.dgvGMP.Rows[this.dgvGMP.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    this.dgvGMP.Rows[this.dgvGMP.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
                }
            }
        }

        private void dgvGMP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            bool isChecked = Convert.ToBoolean(this.dgvGMP.Rows[e.RowIndex].Cells[this.colItemChecked.Index].Value);
            this.dgvGMP.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            this.dgvGMP.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
        }

        private void NumberGMPSertEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                var sbID_GMP = new StringBuilder();
                foreach (Data.Quality.GMP_SertRow gmp in quality.GMP_Sert.Rows)
                {
                    if (gmp.IsChecked)
                    {
                        if (sbID_GMP.Length > 0)
                            sbID_GMP.AppendFormat("; {0}", gmp.GMP_ID);
                        else
                            sbID_GMP.AppendFormat("{0}", gmp.GMP_ID);
                    }

                    this.ID_GMPSert = sbID_GMP.ToString();
                }
            }

            //var selectConclusion = false;
            //if (DialogResult == DialogResult.OK)
            //{
            //    foreach (DataGridViewRow dgvr in dgvGMP.Rows)
            //    {
            //        var row = (dgvr.DataBoundItem as DataRowView).Row as Data.Quality.GMP_SertRow;
            //        if (row.IsChecked)
            //        {
            //            NumberGMPSert = row.Conclusion_Name;
            //            selectConclusion = true;
            //            break;
            //        }
            //    }
            //}

            //if (!selectConclusion)
            //    DialogResult = DialogResult.Cancel;

            //if (DialogResult == DialogResult.OK)
            //{
            //    if (dgvGMP.SelectedRows.Count > 0)
            //    {
            //        NumberGMPSert = dgvGMP.SelectedRows[0].Cells[conclusionNameDataGridViewTextBoxColumn.Index].Value.ToString();
            //    }
            //    else
            //    {
            //        DialogResult = DialogResult.Cancel;
            //    }
            //}
        }
    }
}
