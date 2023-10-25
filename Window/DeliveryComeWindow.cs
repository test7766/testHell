using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.PickControl;

namespace WMSOffice.Window
{
    public partial class DeliveryComeWindow : GeneralWindow
    {
        public DeliveryComeWindow()
        {
            InitializeComponent();
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbBarcode.Text))
                try
                {
                    AddRow(tbBarcode.Text);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            tbBarcode.Text = "";
        }

        private void AddRow(string barcode)
        {
            try
            {
                getPSSTo571BindingSource.Filter = string.Empty;
                getPSSTo571BindingSource.Sort = string.Empty;
                getPSSTo571TableAdapter.Fill(delivery.GetPSSTo571, barcode);
            } catch (Exception ex)
            {
                if (ex.Message.Contains("REDFORM"))
                {
                    FullScreenErrorForm errorForm = new FullScreenErrorForm(
                        String.Format("{0}", ex.Message.Replace("REDFORM", "")),
                        "ПРОДОЛЖИТЬ (Enter)", Color.Red);
                    errorForm.TimeOut = 2000;
                    errorForm.ShowDialog();
                }
                else
                    ShowError(ex);
            }
        }

    }
}
