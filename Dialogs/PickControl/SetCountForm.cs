using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class SetCountForm : DialogForm
    {
        public SetCountForm()
        {
            InitializeComponent();
        }

        public int Count
        {
            get
            {
                int cnt = 0;
                if (int.TryParse(tbCount.Text, out cnt))
                    return cnt;
                else return 0;
            }
            set
            {
                tbCount.Text = value.ToString();
            }
        }


        public bool ShowNote { set { lblNote.Visible = value; } }

        public int ItemID { get; set; }
        public string ItemName { set { lblItemName.Text = value; } }
        public string Lotn { set { lblLotn.Text = value; } }
        public int TotalCount 
        {
            get 
            {
                int cntTotal = 0;
                if (int.TryParse(lblCount.Text, out cntTotal))
                    return cntTotal;
                else return 0;
            }
            set { lblCount.Text = value.ToString(); } 
        }

        /// <summary>
        /// Проверка количества на совпадение
        /// </summary>
        public bool CheckQuantity { get; set; }

        /// <summary>
        /// Минимальный порог количества
        /// </summary>
        public int? MinCount{ get; set; }

        public bool CommitVersionChanges { get; set; }

        private void SetCountForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                try
                {
                    int cnt = 0;
                    if (!int.TryParse(tbCount.Text, out cnt))
                        throw new Exception("Введено неверное значение в поле Количество.");

                    if (this.CommitVersionChanges && this.MinCount.HasValue && cnt < this.MinCount.Value)
                        throw new Exception(string.Format("Введеное значение должно быть не меньше {0}.", this.MinCount));

                    if (this.CheckQuantity && cnt != this.TotalCount && this.TotalCount > 0)
                    {
                        if (MessageBox.Show("Значение отличается от указанного ранее.\r\nВы подтверждаете?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                        {
                            tbCount.Focus();
                            tbCount.SelectAll();
                            e.Cancel = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbCount.Focus();
                    tbCount.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void tbCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            //else if (e.KeyData == Keys.Down)
            //{
            //    listUOMs.Focus();
            //}
        }

        public bool InputCountEnabled
        {
            get { return tbCount.Enabled; }
            set { tbCount.Enabled = value; listUOMs.Enabled = !value; }
        }

        private void SetCountForm_Load(object sender, EventArgs e)
        {
            // получаем список возможных склеек
            uOMStructureTableAdapter.Fill(pickControl.UOMStructure, ItemID);

            // фокус на элементе управления
            if (InputCountEnabled)
                tbCount.Focus();
            else
                listUOMs.Focus();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(127, 8);
            this.btnCancel.Location = new Point(217, 8);
        }

        private void listUOMs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listUOMs.Enabled && listUOMs.SelectedItems.Count == 1)
                Count = (int)((double)listUOMs.SelectedValue);
        }

        private void listUOMs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        //public bool ListUOMVisible
        //{
        //    get { return listUOMs.Visible; }
        //    set { listUOMs.Visible = value;  }
        //}
    }
}
