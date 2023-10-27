using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    /// <summary>
    /// Подтвердить соответствие ящичной нормы
    /// </summary>
    public partial class SetBoxNormSuitabilityForm : Form
    {
        /// <summary>
        /// Источник данных
        /// </summary>
        public Data.Receive.Lotn_For_PrintRow SourceItem { get; set; }

        /// <summary>
        /// Признак соответствия ящичной нормы
        /// </summary>
        public bool? IsBoxNormChanged { get; private set; }

        public SetBoxNormSuitabilityForm()
        {
            InitializeComponent();
            this.IsBoxNormChanged = null;
        }

        private void SetBoxNormSuitabilityForm_Load(object sender, EventArgs e)
        {
            this.lotnForPrintBindingSource.DataSource = this.SourceItem;
        }

        private void SetBoxNormSuitabilityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Yes)
            {
                this.IsBoxNormChanged = true;
                return;
            }

            if (this.DialogResult == DialogResult.No)
            {
                this.IsBoxNormChanged = false;
                return;
            }

            if (this.DialogResult == DialogResult.Cancel)
            {
                this.IsBoxNormChanged = (bool?)null;
                return;
            }
        }
    }
}
