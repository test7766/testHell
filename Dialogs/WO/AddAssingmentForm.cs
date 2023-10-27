using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WO
{
    public partial class AddAssingmentForm : DialogForm
    {
        public AddAssingmentForm()
        {
            InitializeComponent();
        }

        public string WOType { get; set; }

        private void AddAssingmentForm_Load(object sender, EventArgs e)
        {
            terminalsBindingSource.Filter = (chbShowOnlyFree.Checked) ? "CountActiveAssig = 0" : "";
            terminalsTableAdapter.Fill(wO.Terminals, WOType);
        }

        private List<string> _selectedTerminals = new List<string>();
        public List<string> SelectedTerminals
        {
            get { return _selectedTerminals; }
        }

        private void AddAssingmentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _selectedTerminals.Clear();
                foreach (DataGridViewRow row in gvTSD.Rows)
                {
                    if ((row.Cells[colChecked.DisplayIndex].Value != null) && ((bool)row.Cells[colChecked.DisplayIndex].Value))
                    {
                        _selectedTerminals.Add(((Data.WO.TerminalsRow)((DataRowView) row.DataBoundItem).Row).Terminal_ID);
                    }
                }
            }
        }

    }
}
