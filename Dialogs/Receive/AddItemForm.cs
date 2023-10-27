using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    public partial class AddItemForm : DialogForm
    {
        public AddItemForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Признак, показывающий, доступен ли выбор количества товара в форме, или форма вызывается исключительно для выбора самого товара
        /// </summary>
        public bool IsCountEnabled
        {
            get { return tbItemsInBox.Visible; }
            set { lblCount.Visible = tbItemsInBox.Visible = value; }
        }

        public int ItemCode
        {
            get { return (int) lblItemName.Tag; }
        }

        /// <summary>
        /// Код полки
        /// </summary>
        public string LocationID { get; set; }

        public int Count
        {
            get; set;
        }

        private void AddItemForm_Load(object sender, EventArgs e)
        {
            this.itemsTableAdapter.Fill(this.receive.Items, LocationID);
            ButtonOKEnabled = false;
        }

        private void ChooseItem()
        {
            if (receive.Items.Count > 1)
            {
                ListChoiceForm form = new ListChoiceForm(receive.Items, "ItemName", "ItemID");
                form.RememberChoiceVisible = false;
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

        private void AddItemForm_Shown(object sender, EventArgs e)
        {
            lblItemName.Focus();
            tbItemsInBox.Text = "1";
        }

        private void AddItemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                int itemsInBox = 0;
                if (!int.TryParse(tbItemsInBox.Text, out itemsInBox) || itemsInBox < 1)
                    MessageBox.Show("Недопустимое значение поля КОЛИЧЕСТВО.");
                else
                {
                    Count = itemsInBox;
                }
            }
        }

        private void tbItemsInBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

    }
}
