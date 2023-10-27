using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class RepackItemAddToBox : DialogForm
    {
        /// <summary>
        /// Режим выполнения
        /// </summary>
        private const string EXECUTION_MODE = "ADD";

        /// <summary>
        /// Код сессии пользователя
        /// </summary>
        public new long UserID { get; set; }

        /// <summary>
        /// Стол перепаковки
        /// </summary>
        public string LOCN { get; set; }

        /// <summary>
        /// Код склада
        /// </summary>
        public string WarehouseID { get; set; }

        /// <summary>
        /// Ш/К ЖЭ
        /// </summary>
        public string BarcodeYL { get; private set; }

        /// <summary>
        /// Текущий товар для допаковки
        /// </summary>
        public Data.WH.RepackMainDisplayCurrentTasksRow RepackItem { get; private set; }

        /// <summary>
        /// Сканер Ш/К
        /// </summary>
        private WMSOffice.Controls.TextBoxScaner tbScan = null;

        public RepackItemAddToBox()
        {
            InitializeComponent();
        }

        public RepackItemAddToBox(string barcodeYL)
            : this()
        {
            this.BarcodeYL = barcodeYL;
        }

        private void RepackItemAddToBox_Load(object sender, EventArgs e)
        {
            tbScan = new WMSOffice.Controls.TextBoxScaner();
            tbScan.TextChanged += new EventHandler(tbScan_TextChanged);
            tsMainToolbar.Items.Add(new ToolStripControlHost(tbScan));
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(617, 8);
            this.btnCancel.Location = new Point(707, 8);

            btnOK.Enabled = false;

            tbScan.Focus();
            RefreshData();
        }

        void tbScan_TextChanged(object sender, EventArgs e)
        {
            SwitchToRepackTask(tbScan.Text);
        }

        private void RefreshData()
        {
            try
            {
                repackMainDisplayCurrentTasksTableAdapter.Fill(wH.RepackMainDisplayCurrentTasks, this.UserID, WarehouseID, LOCN, BarcodeYL, EXECUTION_MODE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tbScan.Text = string.Empty;
        }

        /// <summary>
        /// Переключится на задание перепаковки
        /// </summary>
        private bool SwitchToRepackTask(string barcodeYL)
        {
            try
            {
                int? errorCode = null;
                string errorMessage = null;

                using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                    adapter.CheckRepackItemBarcode(UserID, WarehouseID, LOCN, barcodeYL, EXECUTION_MODE, ref errorCode, ref errorMessage);

                if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);

                if ((RepackItem = this.FindRepackItemInTask(barcodeYL)) != null)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    throw new Exception("Ш/К ЖЭ в заданиях перепаковки не найден!");
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                tbScan.Focus();
                tbScan.SelectAll();
                return false;
            }
        }

        /// <summary>
        /// Нахождение и установка фокуса на позицию из задания перепаковки 
        /// </summary>
        private Data.WH.RepackMainDisplayCurrentTasksRow FindRepackItemInTask(string repackItemBarcode)
        {
            foreach (DataGridViewRow row in dgvCurrentTasks.Rows)
            {
                var boundRow = (row.DataBoundItem as DataRowView).Row as Data.WH.RepackMainDisplayCurrentTasksRow;
                if (boundRow != null && boundRow.barcode_YL.ToUpper().Trim().Equals(repackItemBarcode.ToUpper().Trim()))
                {
                    row.Selected = true;
                    dgvCurrentTasks.FirstDisplayedScrollingRowIndex = row.Index;
                    return boundRow;
                }
            }

            return null;
        }

        private void RepackItemAddToBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK && RepackItem == null)
            {
                MessageBox.Show("ЖЭ в заданиях перепаковки не найдена!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }
    }
}
