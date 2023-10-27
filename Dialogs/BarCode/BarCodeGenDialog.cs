using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using WMSOffice.Data.BCTableAdapters;

namespace WMSOffice.Dialogs.BarCode
{
    public partial class BarCodeGenDialog : Form
    {
        public const string PrintEmpty = "(Пусто)";

        public BarCodeGenDialog()
        {
            InitializeComponent();
        }
        
        public int PortionCnt { get; set; }

        public string PrinterName { get; set; }

        public int PortionType { get; set; }

        public long SessionID { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PortionCnt = 1000;
            PortionType = 1;

            Binding binding = new Binding("Value", this, "PortionCnt") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            numericUpDown.DataBindings.Add(binding);

            PrinterName = PrintEmpty;
            pCmb.Items.Add(PrinterName);

            using (var ad = new BC_InstalledPrintersTableAdapter())
            {
                var dt = ad.GetData(this.SessionID);
                foreach (WMSOffice.Data.BC.BC_InstalledPrintersRow row in dt.Rows)
                    pCmb.Items.Add(row.PrinterName);
            }

            using (var ad = new BC_PortionTypeTableAdapter())
            {
                var dt = ad.GetData();
                cbType.DataSource = dt;
            }

            binding = new Binding("SelectedItem", this, "PrinterName") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            pCmb.DataBindings.Add(binding);

            binding = new Binding("SelectedValue", this, "PortionType") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            cbType.DataBindings.Add(binding);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);


        }
    }
}
