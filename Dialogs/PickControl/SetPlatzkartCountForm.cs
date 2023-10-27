using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class SetPlatzkartCountForm : DialogForm
    {
        public SetPlatzkartCountForm()
        {
            InitializeComponent();
        }

        public bool CommitVersionChanges { get; set; }

        public int Count
        {
            get
            {

                int cnt = Convert.ToInt32(nudCount.Value);
                return cnt;
            }
            set
            {
                nudCount.Value = Convert.ToDecimal(value);
            }
        }

        public int MaxCount
        {
            get
            {
                int cnt = 0;
                if (int.TryParse(lblMaxQty.Text, out cnt))
                    return cnt;
                else return 0;
            }
            set
            {
                lblMaxQty.Text = value.ToString();
                lblMaxQty.Visible = lblMaxQtyName.Visible = value > 0;
            }
        }

        public int FactCount
        {
            get
            {
                int cnt = 0;
                if (int.TryParse(lblFactQty.Text, out cnt))
                    return cnt;
                else return 0;
            }
            set
            {
                lblFactQty.Text = value.ToString();
            }
        }

        public int ItemID { get; set; }
        public string ItemName { set { lblItemName.Text = value; } }
        public string Lotn { set { lblLotn.Text = value; } }
        public string Box { set { lblBox.Text = value; } }

        private void SetCountForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                try
                {
                    int cnt = Convert.ToInt32(nudCount.Value);
                    if (cnt < 1)
                        throw new Exception("Введено неверное значение в поле Количество.");

                    var limitCount = this.MaxCount - this.FactCount;
                    if (this.CommitVersionChanges && cnt > limitCount && this.MaxCount > 0)
                        throw new Exception(string.Format("Введеное значение должно быть не больше {0}.", limitCount));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nudCount.Focus();
                    e.Cancel = true;
                }
            }
        }

        private void nudCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }


        public bool InputCountEnabled
        {
            get { return nudCount.Enabled; }
            set { nudCount.Enabled = value; listUOMs.Enabled = !value; }
        }

        private void SetCountForm_Load(object sender, EventArgs e)
        {
            // получаем список возможных склеек
            uOMStructureTableAdapter.Fill(pickControl.UOMStructure, ItemID);

            // фокус на элементе управления
            if (InputCountEnabled)
                nudCount.Focus();
            else
                listUOMs.Focus();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(202, 8);
            this.btnCancel.Location = new Point(292, 8);

            //this.btnOK.Focus();

            nudCount.Focus();
            nudCount.Select(0, /*nudCount.Value*/this.Count.ToString().Length);
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
    }
}
