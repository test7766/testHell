using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Admin
{
    public partial class SetEntityItemsFilterForm : DialogForm
    {
        /// <summary>
        /// Шаблон для поиска
        /// </summary>
        public string FilterSearchPattern { get; set; }

        public SetEntityItemsFilterForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            tbFilter.Text = this.FilterSearchPattern;
            tbFilter.Focus();
            tbFilter.SelectionStart = 0;
            tbFilter.SelectionLength = tbFilter.Text.Length;
        }

        private void SetEntityItemsFilterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(this.FilterSearchPattern = tbFilter.Text))
                this.FilterSearchPattern = null;
        }

        private void tbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.DialogResult = DialogResult.OK;
        }
    }
}
