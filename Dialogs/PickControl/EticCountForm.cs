using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class EticCountForm : DialogForm
    {
        public EticCountForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public int Count
        {
            get
            {
                return Convert.ToInt32(nudCount.Value);
            }
            set
            {
                nudCount.Value = Convert.ToDecimal(value);
            }
        }

        public int? LimitCount { get; set; }

        public int? MaximumLimitCount
        {
            get
            {
                return Convert.ToInt32(nudCount.Maximum);
            }
            set
            {
                nudCount.Maximum = Math.Abs(Convert.ToDecimal(value ?? 999));
            }
        }

        public int MinimumCount
        {
            get { return Convert.ToInt32(nudCount.Minimum); }
            set { nudCount.Minimum = Convert.ToDecimal(value); }
        }

        public string Caption
        {
            get { return lblCaption.Text; }
            set { lblCaption.Text = value; }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(127, 0);
            this.btnCancel.Location = new Point(217, 0);

            nudCount.Focus();
            nudCount.Select(0, /*nudCount.Value*/this.Count.ToString().Length);
        }

        private void nudCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void EticCountForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                int cnt = Convert.ToInt32(nudCount.Value);

                if (this.LimitCount.HasValue && cnt > this.LimitCount.Value)
                {
                    while (true)
                    {
                        MessageBoxManager.Yes = "&Да";
                        MessageBoxManager.No = "&Нет";
                        MessageBoxManager.Cancel = "&Повтор";
                        MessageBoxManager.Register();

                        var msgResult = MessageBox.Show(string.Format("Вы действительно хотите создать {0} мест (этикеток)?", cnt), "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3);

                        MessageBoxManager.Unregister();

                        if (msgResult == DialogResult.Cancel)
                            continue;

                        if (msgResult == DialogResult.No)
                        {
                            e.Cancel = true;
                            nudCount.Focus();
                            nudCount.Select(0, /*nudCount.Value*/this.Count.ToString().Length);
                        }

                        break;
                    }
                }
            }
        }

    }
}
