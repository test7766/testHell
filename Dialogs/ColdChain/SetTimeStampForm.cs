using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.ColdChain
{
    public partial class SetTimeStampForm : DialogForm
    {
        public DateTime ActTimeStamp
        {
            get { return dtpTimeStamp.Value; }
        }

        public SetTimeStampForm()
        {
            InitializeComponent();

            dtpTimeStamp.Value = DateTime.Now;
            dtpTimeStamp.Value = dtpTimeStamp.Value.AddSeconds(-dtpTimeStamp.Value.Second);
            this.DialogResult = DialogResult.None;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);      
            dtpTimeStamp.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ApplyOperation(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ApplyOperation(DialogResult.Cancel);
        }
        /// <summary>
        /// Выполнить запрашиваемую операцию согласно ожидаемого результата - статуса диалогового окна
        /// </summary>
        /// <param name="agreedResult"></param>
        private void ApplyOperation(DialogResult agreedResult)
        {
            this.DialogResult = agreedResult;
            this.Close();
        }

        private void dtpTimeStamp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ApplyOperation(DialogResult.OK);
        }      
    }
}
