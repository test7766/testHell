using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Window;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class PickControlItemsPrintEticForm : DialogForm
    {
        public long DocID { get; set; }

        public bool CommitVersionChanges { get; set; }

        public PickControlItemsPrintEticForm()
        {
            InitializeComponent();
        }

        public PickControlItemsPrintEticForm(Data.PickControl.MDS_EticDataTable etics)
            : this()
        {
            this.MergeEtics(etics);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(417, 8);
            this.btnCancel.Location = new Point(507, 8);

            this.Text = string.Format("{0} по документу контроля № {1}", this.Text, this.DocID);
        }

        private void LoadItems()
        {
            try
            {
                pickControl.MDS_Etic.Clear();

                Data.PickControl.MDS_EticDataTable etics = null;
                PickControlItemsPrintEticForm.LoadNotPrintedEtics(this.DocID, out etics);

                this.MergeEtics(etics);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MergeEtics(Data.PickControl.MDS_EticDataTable etics)
        {
            if (etics != null)
                pickControl.MDS_Etic.Merge(etics);
        }

        public static void LoadNotPrintedEtics(long docID, out Data.PickControl.MDS_EticDataTable etics)
        {
            try
            {
                using (var adapter = new Data.PickControlTableAdapters.MDS_EticTableAdapter())
                    etics = adapter.GetData(docID);

                if (etics.Count == 0)
                    etics = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                etics = null;
            }
        }

        private void PickControlItemsPrintEticForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.CheckCloseForm();
        }

        private bool CheckCloseForm()
        {
            try
            {
                var items = pickControl.MDS_Etic.Select(string.Format("{0} = 1", pickControl.MDS_Etic.IsSelectedColumn.Caption));
                if (items == null || items.Length == 0)
                    throw new Exception("Необходимо отметить позицию.");

                // Печать БЭ для отмеченной позиции
                var item = items[0] as Data.PickControl.MDS_EticRow;
                var itemID = item.Item_ID;
                var a13message = (string)null;
                mDS_EticTableAdapter.Print(this.DocID, itemID, ref a13message);
                if (!string.IsNullOrEmpty(a13message))
                {
                    var sMessage = a13message.Trim();
                    var errorForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(sMessage, "ПРОДОЛЖИТЬ (Enter)", Color.LightBlue);
                    errorForm.TimeOut = 2000;
                    errorForm.AutoClose = false;
                    errorForm.ShowDialog();

                    var isPlatzkart = false;

                    // Проверка БЭ
                    PickControlWindow.CheckPrintedEtics(this.UserID, this.DocID, this.CommitVersionChanges, isPlatzkart);

                    // Контроль упаковки
                    PickControlWindow.CheckMDSTare(this.DocID, itemID);
                }

                // Проверка автоматического закрытия формы
                var isAutoClosed = this.CheckAutoClose();
                
                return isAutoClosed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CheckAutoClose()
        {
            // Повторная загрузка позиций
            this.LoadItems();

            // Проверка кол-ва позиций для автоматического закрытия
            if (pickControl.MDS_Etic.Rows.Count == 0)
                return true;

            return false;
        }

        private void dgvItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvItems.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                var currentItem = (this.dgvItems.Rows[this.dgvItems.CurrentRow.Index].DataBoundItem as DataRowView).Row as Data.PickControl.MDS_EticRow;
                bool isSelected = currentItem.IsIsSelectedNull() ? false : currentItem.IsSelected;
                if (isSelected) // допускается к выбору только одна строка!
                {
                    foreach (Data.PickControl.MDS_EticRow item in pickControl.MDS_Etic.Rows)
                        if (item.Item_ID != currentItem.Item_ID)
                            item.IsSelected = false;
                }

                foreach (DataGridViewColumn column in this.dgvItems.Columns)
                {
                    this.dgvItems.Rows[this.dgvItems.CurrentRow.Index].Cells[column.Index].Style.BackColor = isSelected ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    this.dgvItems.Rows[this.dgvItems.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isSelected ? Color.FromArgb(209, 255, 117) : Color.Black;
                }
               
            }
        }

        private void dgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            // Раскраска
            bool isSelected = Convert.ToBoolean(this.dgvItems.Rows[e.RowIndex].Cells[this.IsSelected.Index].Value);
            this.dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isSelected ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            this.dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isSelected ? Color.FromArgb(209, 255, 117) : Color.Black;
        }
    }
}
