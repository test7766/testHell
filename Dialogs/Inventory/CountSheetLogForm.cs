using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class CountSheetLogForm : Form
    {
        public CountSheetLogForm()
        {
            InitializeComponent();
        }

        public int CS_ID { get; set; }

        private void CountSheetLogForm_Load(object sender, EventArgs e)
        {
            Text += CS_ID.ToString();
            iV_CS_LogTableAdapter.Fill(inventory.IV_CS_Log, CS_ID);
        }
    }
}
