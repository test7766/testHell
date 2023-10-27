using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Complaints;

namespace WMSOffice.Dialogs.Delivery
{
    public partial class NeededPSNForm : Form
    {
        public NeededPSNForm()
        {
            InitializeComponent();
        }

        public int PerronID { get; set; }
        public long PerronPackingDocID { get; set; }
        public bool IsPackingStage { get; set; }
        public long UserID { get; set; }

        private void NeededPSNForm_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            btnWriteOffShortage.Enabled = this.CheckWriteOffShortageAccess();
        }

        private bool CheckWriteOffShortageAccess()
        {
            try
            {
                var access = (int?)null;
                needPSNbyPeronTableAdapter.CheckWriteOffShortageAccess(UserID, ref access);

                return Convert.ToBoolean(access ?? 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.ReloadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                needPSNbyPeronTableAdapter.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);

                if (IsPackingStage)
                {
                    this.Text = "Сборочные для комплектации на перрон: " + PerronID.ToString();
                    needPSNbyPeronTableAdapter.Fill(delivery.NeedPSNbyPeron, PerronID, PerronPackingDocID);
                }
                else
                {
                    this.Text = "Места для погрузки с перрона: " + PerronID.ToString();
                    needPSNbyPeronTableAdapter.FillByWO(delivery.NeedPSNbyPeron, PerronID, PerronPackingDocID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWriteOffShortage_Click(object sender, EventArgs e)
        {
            if (this.WriteOffShortage())
                this.ReloadData();
        }

        private bool WriteOffShortage()
        {
            try
            {
                var frmEnterStringValue = new EnterStringValueForm("Комментарий", "Введите комментарий к списанию недостачи:", string.Empty);
                if (frmEnterStringValue.ShowDialog() == DialogResult.OK)
                {
                    var comment = frmEnterStringValue.Value;
                    var isCold = false;

                    needPSNbyPeronTableAdapter.WriteOffShortage(PerronID, PerronPackingDocID, UserID, comment, isCold);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void gvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // разрисовка строк в таблице
            foreach (DataGridViewRow row in gvLines.Rows)
            {
                Data.Delivery.NeedPSNbyPeronRow diffRow = (Data.Delivery.NeedPSNbyPeronRow)((DataRowView)row.DataBoundItem).Row;

                // простая разрисовка строк
                Color backColor = (diffRow.IsColorNull() || diffRow.Color.ToLower() == "white")
                                      ? Color.White
                                      : Color.FromName(diffRow.Color);
                for (int c = 0; c < row.Cells.Count; c++)
                {
                    row.Cells[c].Style.BackColor = backColor;
                    row.Cells[c].Style.SelectionForeColor = backColor;
                }
            }
        }
    }
}
