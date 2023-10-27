using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Диалог выбора товарных позиций для выборочной печати пакета документов
    /// </summary>
    public partial class PrintDocItemsSelector : DialogForm
    {
        /// <summary>
        /// Индикатор длительной операции
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Номер документа
        /// </summary>
        public long DocID { get; set; }

        /// <summary>
        /// Параметр для поиска
        /// </summary>
        public string SearchParameter { get; private set; }


        public PrintDocItemsSelector(long docID)
        {
            InitializeComponent();
            this.DocID = docID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(309, 8);
            this.btnCancel.Location = new Point(399, 8);

            this.LoadData();
        }

        #region ФОНОВАЯ ЗАГРУЗКА ТОВАРНЫХ ПОЗИЦИЙ ЗАЯВКИ
        /// <summary>
        /// Загрузка товарных позиций заявки
        /// </summary>
        private void LoadData()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            waitProcessForm.ActionText = "Выполняется загрузка данных..";
            printedDocItemsBindingSource.DataSource = null;
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();
        }

        void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = this.printedDocItemsTableAdapter.GetData(this.UserID, this.DocID);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.quality.PrintedDocItems.Clear();
            }
            else
                this.printedDocItemsBindingSource.DataSource = e.Result;

            waitProcessForm.CloseForce();
        }
        #endregion

        private void dgvSelector_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvSelector.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvSelector.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool isChecked = Convert.ToBoolean(this.dgvSelector.Rows[this.dgvSelector.CurrentRow.Index].Cells[this.dgvcIsItemSelected.Index].Value);
                foreach (DataGridViewColumn column in this.dgvSelector.Columns)
                {
                    this.dgvSelector.Rows[this.dgvSelector.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    this.dgvSelector.Rows[this.dgvSelector.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
                }
            }
        }

        private void PrintDocItemsSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ApplySelection();
        }

        /// <summary>
        /// Подтверждение выбора 
        /// </summary>
        /// <returns></returns>
        private bool ApplySelection()
        {
            StringBuilder sbParameterFormatter = new StringBuilder();
            foreach (DataGridViewRow  gridRow in this.dgvSelector.Rows)
            {
                var row = (gridRow.DataBoundItem as DataRowView).Row as Data.Quality.PrintedDocItemsRow;
                if (row.Option)
                    sbParameterFormatter.AppendFormat("{0}-{1};", row.Item_ID, row.Lot);
            }

            if (sbParameterFormatter.Length > 0)
            {
                this.SearchParameter = sbParameterFormatter.ToString();
                return true;
            }

            MessageBox.Show("Для успешной печати необходимо выбрать хотя бы один элемент!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.SearchParameter = null;
            return false;
        }

        private void dgvSelector_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            bool isChecked = Convert.ToBoolean(this.dgvSelector.Rows[e.RowIndex].Cells[this.dgvcIsItemSelected.Index].Value);
            this.dgvSelector.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            this.dgvSelector.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
        }
    }
}
