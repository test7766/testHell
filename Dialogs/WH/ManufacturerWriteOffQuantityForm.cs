using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class ManufacturerWriteOffQuantityForm : Form
    {
        public ManufacturerWriteOffQuantityForm()
        {
            InitializeComponent();
            MaxQuantity = double.MaxValue;
        }

        public double MaxQuantity { get; set; }
        public double Quantity { get; set; }

        public WMSOffice.Data.WH.WF_GetItem_RemainsRow Item { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Item == null)
                return;

            tbQuantity.Maximum = (decimal)MaxQuantity;

            tbId.DataBindings.Add(new Binding("Text", Item, "Item_ID"));
            tbItem.DataBindings.Add(new Binding("Text", Item, "Item"));
            tbManuf.DataBindings.Add(new Binding("Text", Item, "Manufacturer"));
            tbLot.DataBindings.Add(new Binding("Text", Item, "LotNumber"));
            tbBatch.DataBindings.Add(new Binding("Text", Item, "Batch_ID"));

            Binding binding = new Binding("Value", this, "Quantity") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            tbQuantity.DataBindings.Add(binding);

        }

    }
}
