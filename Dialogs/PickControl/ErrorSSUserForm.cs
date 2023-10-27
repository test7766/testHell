using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class ErrorSSUserForm : Form
    {
        public ErrorSSUserForm()
        {
            InitializeComponent();
            DialogResult = DialogResult.No;
        }

        private void ErrorSSUserForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F8)
            {
                // повторный контроль
                btnUndoDoc_Click(sender, null);
            } else if (e.KeyData == Keys.F4)
            {
                // исправление ошибки
                btnRepairDoc_Click(sender, null);
            }
        }

        /// <summary>
        /// повторный контроль
        /// </summary>
        private void btnUndoDoc_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            //MessageBox.Show("UNDO");
            Close();
        }

        /// <summary>
        /// исправление ошибки
        /// </summary>
        private void btnRepairDoc_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            //MessageBox.Show("REPAIR");
            Close();
        }


    }
}
