using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data.PickControlTableAdapters;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    public partial class ChooseSeriesForm : Form
    {
        #region локальные переменные

        private PickListRow _pickListRow = null;
        private int _sessionId;

        #endregion

        public ChooseSeriesForm(PickListRow pickListRow, int sessionId)
        {
            InitializeComponent();
            _pickListRow = pickListRow;
            _sessionId = sessionId;
            tbLocation.Text = _pickListRow.Location;
        }

        /// <summary>
        /// Наименование товара
        /// </summary>
        public string ItemName
        {
            set { this.Text = String.Format("Выбор серии - {0}", value); }
        }

        /// <summary>
        /// Выбранная новая серия
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Признак, является ли выбранная серия заблокированной
        /// </summary>
        public string BlockReason { get; set; }

        private Data.PickControl.CP_SeriesRow SelectedRow
        {
            get { return (gvSeries.SelectedRows.Count > 0) ? ((Data.PickControl.CP_SeriesRow)((DataRowView)gvSeries.SelectedRows[0].DataBoundItem).Row) : null; }
        }

        private void ChooseSeriesForm_Load(object sender, EventArgs e)
        {
            cP_SeriesTableAdapter.Fill(pickControl.CP_Series, _sessionId, _pickListRow.Company,
                                       _pickListRow.DocumentType, _pickListRow.DocumentNumber,
                                       _pickListRow.PickSlipNumber, _pickListRow.LineId);
            if (gvSeries.Rows.Count > 0)
                if (String.IsNullOrEmpty(Series))
                    gvSeries.Rows[0].Selected = true;
                else
                {
                    foreach (DataGridViewRow dgvRow in gvSeries.Rows)
                        if (((Data.PickControl.CP_SeriesRow)((DataRowView)dgvRow.DataBoundItem).Row).lot_number == Series)
                        {
                            dgvRow.Selected = true;
                            break;
                        }
                }
            gvSeries.Focus();
        }

        /// <summary>
        /// Меняет расцветку строк после обновления данных в таблице.
        /// </summary>
        private void gvSeries_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvRow in gvSeries.Rows)
            {
                if (((Data.PickControl.CP_SeriesRow)((DataRowView)dgvRow.DataBoundItem).Row).is_blocked)
                {
                    for (int c = 0; c < dgvRow.Cells.Count; c++)
                    {
                        dgvRow.Cells[c].Style.BackColor = Color.Red;
                        dgvRow.Cells[c].Style.SelectionForeColor = Color.Red;
                    }
                }
                dgvRow.Selected = false;
            }
        }

        /// <summary>
        /// Действие выбора серии в списке серий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvSeries_SelectionChanged(object sender, EventArgs e)
        {
            Series = (SelectedRow != null) ? SelectedRow.lot_number : String.Empty;
            BlockReason = (SelectedRow != null && SelectedRow.is_blocked) ? SelectedRow.lot_status : String.Empty;
        }

        /// <summary>
        /// Нажатие клавиши Enter - выбираем текущую строку в качестве результата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvSeries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Двойной клик мышью - выбор элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvSeries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SelectedRow != null)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
