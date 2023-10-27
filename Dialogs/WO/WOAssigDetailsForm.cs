using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WO
{
    public partial class WOAssigDetailsForm : Form
    {
        public WOAssigDetailsForm()
        {
            InitializeComponent();
            lblItemCode.Text = lblItemName.Text = lblQuantity.Text = lblFact.Text = "";
        }

        public long Doc_ID { get; set; }
        public int Item_ID { get; set; }

        public string Item_Code_Label { set { lblItemCode.Text = value; } }
        public string Item_Name_Label { set { lblItemName.Text = value; } }
        public string Quantity_Label { set { lblQuantity.Text = value; } }
        public string Fact_Label { set { lblFact.Text = value; } }

        private void WOAssigDetailsForm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void gvDocTypes_SelectionChanged(object sender, EventArgs e)
        {
            btnDeleteAssigResults.Enabled = gvItem.SelectedRows.Count > 0;
            if (gvItem.SelectedRows.Count > 0)
            {
                long assigID = ((Data.WMove.WoAssigDetailsRow)((DataRowView)gvItem.SelectedRows[0].DataBoundItem).Row).Assig_ID;
                woAssigDetailsBindingSource.Filter = String.Format("Assig_ID = {0}", assigID);
            }
        }

        private void RefreshData()
        {
            btnDeleteAssigResults.Enabled = false;
            woAssigDetailsTableAdapter.Fill(wMove.WoAssigDetails, Doc_ID, Item_ID);
            DataView dataView = new DataView(wMove.WoAssigDetails, String.Format("Item_ID = {0}", Item_ID), "", DataViewRowState.CurrentRows);
            gvItem.DataSource = dataView;
        }

        private void btnDeleteAssigResults_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить \n\rрезультаты выбранного назначения?", "Удалить?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                try
                {
                    long assigID = ((Data.WMove.WoAssigDetailsRow) ((DataRowView) gvItem.SelectedRows[0].DataBoundItem).Row).Assig_ID;
                    woAssigDetailsTableAdapter.PurgeWOAssig(Doc_ID, assigID);
                    lblFact.Text = lblFact.Text.Replace(" (?)", "") + " (?)";
                } 
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                RefreshData();
            }
        }

        private void gvAssig_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // разрисовка строк в таблице
            foreach (DataGridViewRow row in gvAssig.Rows)
            {
                Data.WMove.WoAssigDetailsRow diffRow = (Data.WMove.WoAssigDetailsRow)((DataRowView)row.DataBoundItem).Row;

                // простая разрисовка строк
                Color backColor = (diffRow.IsColorNull() || diffRow.Color.ToLower() == "white")
                                      ? Color.White
                                      : Color.FromName(diffRow.Color);
                for (int c = 0; c < row.Cells.Count; c++)
                {
                    row.Cells[c].Style.BackColor = backColor;
                    row.Cells[c].Style.SelectionForeColor = backColor;
                }
            }
        }

    }
}
