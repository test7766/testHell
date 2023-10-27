using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WMSOffice.Dialogs.Receive
{
    public partial class PrintBoxLabelForm : DialogForm
    {
        /// <summary>
        /// Источник данных
        /// </summary>
        public Data.Receive.Lotn_For_PrintRow SourceItem { get; set; }

        public LotnReceiptMode ReceiptMode { get; set; }

        public long? DocID { get; set; }
        
        public PrintBoxLabelForm()
        {
            InitializeComponent();
            tbItemsInBox.Text = tbEticCount.Text = "1";
        }

        public int ItemID { get; set; }
        public string Lotn { get; set; }
        public string Manufacturer { get; set; }

        public int? SupplyQuantity { get; set; }

        public string LocationID { get; set; }

        public string ItemName
        {
            get { return lblItem.Text; }
            set { lblItem.Text = value; }
        }

        public string Seria
        {
            get { return lblSeria.Text; }
            set { lblSeria.Text = value; }
        }

        public double ItemsInBoxCount { get; private set; }
        public int LabelsCount { get; private set; }

        //public int ItemsInBox
        //{
        //    set { tbItemsInBox.Text = value.ToString(); }
        //}

        private void PrintBoxLabelForm_Load(object sender, EventArgs e)
        {
            //this.itemsTableAdapter.Fill(this.receive.Items);
        }
        /*
        private void ChooseItem()
        {
            if (receive.Items.Count > 0)
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
*/
        private void PrintBoxLabelForm_Shown(object sender, EventArgs e)
        {
            //tbItemsInBox.Focus();
            //tbItemsInBox.Text = 
            tbItemBarCode.TextChanged += delegate(object s, EventArgs ea) 
            {
                this.SelectNextControl(s as Control, true, true, true, true);
            }; 

            tbEticCount.Text = "1";
            ButtonOKEnabled = true;// (lblItemName.Tag != null);
            //ChooseItem();

            btnOK.Location = new Point(290, 8);
            btnCancel.Location = new Point(380, 8);

            if (this.ReceiptMode == LotnReceiptMode.AssignSSCC)
            {
                var actionText = "Резервирование ш/к на заводской ящик";
                this.Text = actionText;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Enter))
            {
                this.DialogResult = DialogResult.OK;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void PrintBoxLabelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                int countOfLabels = 0;
                double itemsInBox = 0;
                string itemBarCode = string.Empty;

                var separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                if (!double.TryParse(tbItemsInBox.Text.Replace(".", separator).Replace(",", separator), out itemsInBox) || itemsInBox <= 0)
                {
                    MessageBox.Show("Недопустимое значение поля КОЛИЧЕСТВО ШТУК В ЯЩИКЕ.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbItemsInBox.Focus();
                    e.Cancel = true;
                }
                else if (!int.TryParse(tbEticCount.Text, out countOfLabels) || countOfLabels < 1)
                {
                    MessageBox.Show("Недопустимое значение поля КОЛИЧЕСТВО ЭТИКЕТОК.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbEticCount.Focus();
                    e.Cancel = true;
                }
                else if (string.IsNullOrEmpty(itemBarCode = tbItemBarCode.Text))
                {
                    MessageBox.Show("Необходимо отсканировать Ш/К ТОВАРА.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbItemBarCode.Focus();
                    e.Cancel = true;
                }
                else
                {
                    this.ItemsInBoxCount = itemsInBox;
                    this.LabelsCount = countOfLabels;

                    try
                    {
                        if (ReceiptMode == LotnReceiptMode.AssignSSCC)
                        {
                            // Резервируем SSCC
                            using (var adapter = new Data.ReceiveTableAdapters.DocCurrentParametersTableAdapter())
                                adapter.SetCurrentParameters(UserID, DocID, ItemID, itemBarCode, Lotn, itemsInBox, countOfLabels);
                        }
                        else
                        {
                            // отправляем задание на печать!
                            itemsTableAdapter.NewBoxBarcode(ItemID, Lotn, countOfLabels, itemsInBox, UserID, Environment.MachineName, System.Security.Principal.WindowsIdentity.GetCurrent().Name, null, null, itemBarCode, SupplyQuantity, LocationID);
                        }
                    }
                    catch (Exception ex)
                    {
                        // неизвестная ящичная норма - спрашиваем подтверждение у пользователя
                        if (ex.Message.Contains("CallOBVXForm"))
                        {
                            e.Cancel = !this.SetBoxNormSuitability();
                        }
                        else
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                        }
                    }

                }
            }
        }

        private void textBox_SelectNextControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var control = sender as Control;

                if (control == tbEticCount)
                {
                    //tbItemBarCode.Focus();
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                    this.SelectNextControl(control, true, true, true, true);
            }
        }

        /// <summary>
        /// Установить ящичную норму
        /// </summary>
        private bool SetBoxNormSuitability()
        {
            var dlgBoxNormSuitability = new SetBoxNormSuitabilityForm();
            dlgBoxNormSuitability.SourceItem = this.SourceItem;
            dlgBoxNormSuitability.ShowDialog();

            if (dlgBoxNormSuitability.IsBoxNormChanged.HasValue)
            {
                // ящичная норма изменилась
                if (dlgBoxNormSuitability.IsBoxNormChanged.Value)
                {
                    try
                    {
                        itemsTableAdapter.ApplyBoxNormSuitability(this.UserID, ItemID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                // ящичная норма осталась без изменений
                else
                {
                    try
                    {
                        int countOfLabels = Convert.ToInt32(tbEticCount.Text);
                        double itemsInBox = 0;

                        var separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                        double.TryParse(tbItemsInBox.Text.Replace(".", separator).Replace(",", separator), out itemsInBox);

                        this.ItemsInBoxCount = itemsInBox;
                        this.LabelsCount = countOfLabels;

                        string itemBarCode = tbItemBarCode.Text;

                        if (ReceiptMode == LotnReceiptMode.AssignSSCC)
                        {
                            // Резервируем SSCC
                            using (var adapter = new Data.ReceiveTableAdapters.DocCurrentParametersTableAdapter())
                                adapter.SetCurrentParameters(UserID, DocID, ItemID, itemBarCode, Lotn, itemsInBox, countOfLabels);
                        }
                        else
                        {
                            // отправляем задание на печать!
                            itemsTableAdapter.NewBoxBarcode(ItemID, Lotn, countOfLabels, itemsInBox, UserID, Environment.MachineName, System.Security.Principal.WindowsIdentity.GetCurrent().Name, true, null, itemBarCode, SupplyQuantity, LocationID);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
