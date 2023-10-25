using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;

namespace WMSOffice.Window
{
    public partial class PickSlipContentPreviewWindow : GeneralWindow
    {
        private TextBoxScaner tbScaner = null;

        public PickSlipContentPreviewWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            tsMain.Items.Add(new ToolStripLabel("Отсканируйте ш/к сборочного :"));

            tbScaner = new TextBoxScaner();
            tbScaner.TextChanged += new EventHandler(tbScaner_TextChanged);
            var host = new ToolStripControlHost(tbScaner) { Width = 500 };
            tsMain.Items.Add(host);

            tbScaner.Focus();
        }

        void tbScaner_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbScaner.Text))
                    return;

                pickSlipContentTableAdapter.Fill(pickControl.PickSlipContent, tbScaner.Text);

                tbScaner.Text = string.Empty;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                tbScaner.Focus();
                tbScaner.SelectAll();
            }
        }
    }
}
