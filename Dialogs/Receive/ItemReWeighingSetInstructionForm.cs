using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    public partial class ItemReWeighingSetInstructionForm : DialogForm
    {
        public bool HasInstruction { get; set; }

        public ItemReWeighingSetInstructionForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(77, 8);
            this.btnCancel.Location = new Point(167, 8);

            cbHasInstruction.Checked = this.HasInstruction;
            cbHasInstruction.CheckedChanged += (s, ea) => { this.btnOK.Focus(); };

            cbHasInstruction.Focus();
        }

        private void ItemReWeighingSetInstructionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
                e.Cancel = !this.SetInstruction();
        }

        private bool SetInstruction()
        {
            if (cbHasInstruction.Checked != this.HasInstruction)
            {
                if (MessageBox.Show(string.Format("Вы подтверждаете {0} инструкции?", cbHasInstruction.Checked ? "наличие" : "отсутствие"), "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    cbHasInstruction.Focus();
                    return false;
                }
            }

            this.HasInstruction = cbHasInstruction.Checked;
            return true;
        }
    }
}
