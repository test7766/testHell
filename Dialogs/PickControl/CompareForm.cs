using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class CompareForm : Form
    {
        public CompareForm()
        {
            InitializeComponent();
        }

        public long DocID { get; set; }

        private void CompareForm_Load(object sender, EventArgs e)
        {
            try
            {
                differenceTableAdapter.Fill(pickControl.Difference, DocID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ForceClosed = false;

        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                using (Data.PickControlTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.QueriesTableAdapter())
                {
                    adapter.ReCreateDoc(DocID);
                }

                ForceClosed = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CompareForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ForceClosed)
                e.Cancel = true;
        }

        private void gvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in gvLines.Rows)
            {
                Data.PickControl.DifferenceRow diffRow = (Data.PickControl.DifferenceRow)((DataRowView)row.DataBoundItem).Row;
                if (diffRow.IsPSN_QtyNull() || diffRow.IsControl_QtyNull() || diffRow.PSN_Qty != diffRow.Control_Qty)
                {
                    // строка отличается - подсвечиваем красным
                    for (int c = 0; c < row.Cells.Count; c++)
                    {
                        row.Cells[c].Style.BackColor = Color.Red;
                        row.Cells[c].Style.ForeColor = Color.White;
                    }
                }
            }
        }
    }
}
