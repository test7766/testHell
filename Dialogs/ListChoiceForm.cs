using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs
{
    public partial class ListChoiceForm : Form
    {
        public ListChoiceForm()
        {
            InitializeComponent();
        }

        public ListChoiceForm(object dataSource, string displayMember, string valueMember)
            : this()
        {
            listBox.DataSource = dataSource;
            listBox.DisplayMember = displayMember;
            listBox.ValueMember = valueMember;
        }

        public object Value
        {
            get { return listBox.SelectedValue; }
            set { listBox.SelectedValue = value; }
        }

        public object SelectedItem
        {
            get { return listBox.SelectedItem; }
        }

        public bool RememberChoice
        {
            get { return chbRemember.Checked; }
            set { chbRemember.Checked = value; }
        }

        public bool RememberChoiceVisible
        {
            get { return chbRemember.Visible; }
            set { chbRemember.Visible = value; }
        }

        private void listBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox.SelectedItem != null)
                btnOk_Click(sender, null);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if ((e.KeyData == Keys.Left) || (e.KeyData == Keys.Right) ||
            //    (e.KeyData == Keys.Up) || (e.KeyData == Keys.Down) || 
            //    (e.KeyData == Keys.Tab)) { }
            //else if (e.KeyData == Keys.Enter)
            //    btnOk_Click(sender, null);
            //else { tbSearch.Focus(); }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (listBox.DataSource is DataTable)
                ((DataTable) listBox.DataSource).DefaultView.RowFilter = listBox.DisplayMember + " like '%" + tbSearch.Text.Replace("%","_") + "%'";
        }
    }
}
