using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    public partial class RecognizeBarcodeForm : DialogForm
    {
        public RecognizeBarcodeForm()
        {
            InitializeComponent();
        }

        public string Barcode
        {
            get { return tbBarcode.Text; }
            set { tbBarcode.Text = value; }
        }

        public string ItemUOM
        {
            get { return tbEI.Text; }
            set { tbEI.Text = value; }
        }

        /// <summary>
        /// Код полки
        /// </summary>
        public string LocationID { get; set; }

        public bool EnableItemsInBox
        {
            get { return tbItemsInBox.Enabled; }
            set { tbItemsInBox.Enabled = value; }
        }

        private void RecognizeBarcodeForm_Load(object sender, EventArgs e)
        {
            this.itemsTableAdapter.Fill(this.receive.Items, this.LocationID);
            ButtonOKEnabled = false;
        }

        private void ChooseItem()
        {
            if (receive.Items.Count > 1)
            {
                ListChoiceForm form = new ListChoiceForm(receive.Items, "ItemName", "ItemID");
                form.Text = "Выбор товара";
                if (lblItemName.Tag != null)
                    form.Value = lblItemName.Tag;
                form.ShowDialog();
                if (form.SelectedItem != null)
                {
                    Data.Receive.ItemsRow row = (Data.Receive.ItemsRow)((DataRowView)form.SelectedItem).Row;
                    lblItemName.Tag = row.ItemID;
                    lblItemName.Text = (row.IsItemNameNull()) ? "(пусто)" : row.ItemName;
                    ButtonOKEnabled = true;
                }
            }
            tbItemsInBox.Focus();
        }

        private void lblItemName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChooseItem();
        }

        private void RecognizeBarcodeForm_Shown(object sender, EventArgs e)
        {
            lblItemName.Focus();
            tbItemsInBox.Text = "1";
        }

        private void RecognizeBarcodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                int itemsInBox = 0;
                if (!int.TryParse(tbItemsInBox.Text, out itemsInBox) || itemsInBox < 1)
                    MessageBox.Show("Недопустимое значение поля КОЛИЧЕСТВО ШТУК В ЯЩИКЕ.");
                else
                    // отправляем задание на печать!))
                    if (lblItemName.Tag != null)
                    {
                        try
                        {
                            itemsTableAdapter.RecognizeBarcode((int)lblItemName.Tag, tbBarcode.Text, ItemUOM, itemsInBox, UserID);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
            }
        }


    }
}
