using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class SetCountNTVForm : DialogForm
    {
        public SetCountNTVForm()
        {
            InitializeComponent();
            cbNTVExists_CheckedChanged(cbNTVExists, EventArgs.Empty);
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
                RecalcTotalCount();
            }
        }

        public int NTVCount
        {
            get
            {
                if (!cbNTVExists.Checked)
                    return 0;

                int cnt = 0;
                if (int.TryParse(tbNTVCount.Text, out cnt))
                    return cnt;
                
                return 0;
            }
            set
            {
                tbNTVCount.Text = value.ToString();

                if (value > 0)
                    cbNTVExists.Checked = true;

                RecalcTotalCount();
            }
        }

        public bool EditOnlyNTVCount
        {
            get { return !tbCount.Enabled; }
            set { tbCount.Enabled = !value; }
        }

        public bool IsPlatzkart { get; set; }
        public string Box { get; set; }

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
                if (int.TryParse(lblCount.Text, out cnt))
                    return cnt;
                else return 0;
            }
            set
            {
                lblCount.Text = value.ToString();
            }
        }

        public int ItemID { get; set; }
        public string ItemName { set { lblItemName.Text = value; } }
        public string Lotn { set { lblLotn.Text = value; } }
        public int TotalCount { set { lblCount.Text = value.ToString(); } }

        /// <summary>
        /// Минимальный порог количества
        /// </summary>
        public int? MinCount{ get; set; }

        public bool CommitVersionChanges { get; set; }

        public bool NeedConfirmNTV { get; set; }

        public long DocID { get; set; }

        //public bool ListUOMVisible
        //{
        //    get { return listUOMs.Visible; }
        //    set { listUOMs.Visible = value;  }
        //}
        
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

            if (!this.IsPlatzkart)
                lblMaxQty.Visible = lblMaxQtyName.Visible = false;

            this.btnOK.Location = new Point(128, 8);
            this.btnCancel.Location = new Point(218, 8);
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

        private void tbCountValue_TextChanged(object sender, EventArgs e)
        {
            RecalcTotalCount();
        }

        private void RecalcTotalCount()
        {
            var totalValue = Count + NTVCount;
            tbTotalCount.Text = totalValue.ToString();
        }

        private void cbNTVExists_CheckedChanged(object sender, EventArgs e)
        {
            tbNTVCount.Enabled = cbNTVExists.Checked;
            if (!cbNTVExists.Checked)
                NTVCount = 0;
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

                    if (this.IsPlatzkart || this.NeedConfirmNTV)
                    {
                        if (Count < 0 || NTVCount < 0)
                            throw new Exception("Нельзя ввести отрицательное значение в поле Количество/НТВ.");

                        cnt = Count + NTVCount;
                        var limitCount = this.MaxCount - this.FactCount;
                        if (this.CommitVersionChanges && cnt > limitCount && this.MaxCount > 0)
                            throw new Exception(string.Format("Введеное значение должно быть не больше {0}.", limitCount));
                    }

                    if (this.NeedConfirmNTV && NTVCount > 0)
                    {
                        var success = this.ConfirmNTV();
                        if (!success)
                        {
                            e.Cancel = true;
                            cbNTVExists.Checked = false;
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

        private bool ConfirmNTV()
        {
            while (true)
            {
                try
                {
                    var bossID = (int?)null;
                    var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте бэйдж руководителя,\r\nкоторый отвечает за мониторинг контроля",
                        Text = "Фиксация НТВ",
                        Image = Properties.Resources.role,
                        //OnlyNumbersInBarcode = true
                        UseScanModeOnly = true
                    };

                    if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                        return false;

                    bossID = Convert.ToInt32(dlgBossScanner.Barcode);

                    var result = (int?)null;
                    using (var adapter = new Data.PickControlTableAdapters.SurplusContainerDocsTableAdapter())
                        adapter.CheckBoss(this.UserID, this.DocID, bossID, ref result);

                    if (result.HasValue && Convert.ToBoolean(result.Value))
                        return true;
                    else
                        throw new Exception("Пользователь не имеет права\r\nподтверждения фиксации НТВ.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
            }
        }
    }
}
