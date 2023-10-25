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
    public partial class InterbranchComeWindow : GeneralWindow
    {
        public InterbranchComeWindow()
        {
            InitializeComponent();
        }

        private void InterbranchComeWindow_Load(object sender, EventArgs e)
        {
            //RefreshLines();
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

        private void miRefresh_Click(object sender, EventArgs e)
        {
            //RefreshLines();
        }

        /*private void RefreshLines()
        {
            //docRowsBindingSource.Filter = "";
            //docRowsBindingSource.Sort = "";
            //docRowsTableAdapter.Fill(interbranch.DocRows, DocID);
        }*/

        private void AddRow(string barcode)
        {
            //UndoEnabled = false;
            //docRowsTableAdapter.AddRow(DocID, barcode, shipToID);
            //_barcode = barcode;
            //UndoEnabled = true;
            //RefreshHeader();
            try
            {
                getPSSTo561BindingSource.Filter = string.Empty;
                getPSSTo561BindingSource.Sort = string.Empty;
                getPSSTo561TableAdapter.Fill(interbranch.GetPSSTo561, barcode);
            }
            catch (Exception ex)
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
