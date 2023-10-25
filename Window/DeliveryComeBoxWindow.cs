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
    public partial class DeliveryComeBoxWindow : GeneralWindow
    {
        public DeliveryComeBoxWindow()
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
                Data.Delivery.ComeBarProcessingDataTable table = comeBarProcessingTableAdapter.GetData(UserID, barcode);
                delivery.ComeBarProcessing.Clear();
                delivery.ComeBarProcessing.Merge(table);
                if (table.Rows.Count > 0)
                {
                    Data.Delivery.ComeBarProcessingRow row = table[0];
                    UndoEnabled = (row.TotalPlace != row.WorkPlace);
                }
                else UndoEnabled = false;
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

        private bool UndoEnabled
        {
            get { return btnUndo.Enabled; }
            set { btnUndo.Enabled = value; }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (gvLines.SelectedRows.Count >= 1)
            {
                try
                {
                    Data.Delivery.ComeBarProcessingRow row =
                        (Data.Delivery.ComeBarProcessingRow) ((DataRowView) gvLines.SelectedRows[0].DataBoundItem).Row;
                    comeBarProcessingTableAdapter.CancelPickSlip(row.PickSlipNumber);
                    UndoEnabled = false;
                    delivery.ComeBarProcessing.Clear();
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
}
