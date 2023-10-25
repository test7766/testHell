using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.Complaints;

namespace WMSOffice.Window
{
    public partial class LabelsReprintWindow : GeneralWindow
    {
        private static readonly Color checkedColor = Color.FromArgb(209, 255, 117);
        private static readonly Color printedColor = Color.FromArgb(255, 255, 153);

        /// <summary>
        /// Окно ожидания, которое отображается при длительных операциях
        /// </summary>
        private SplashForm waitProgressForm = new SplashForm();

        public LabelsReprintWindow()
        {
            InitializeComponent();
        }

        private void LabelsReprintWindow_Load(object sender, EventArgs e)
        {
            this.Initialize();    
        }
       
        private void Initialize()
        {
            this.LoadPrinters();

            dgvLabels.Columns[checkedDataGridViewTextBoxColumn.Index].HeaderCell = new DatagridViewCheckBoxHeaderCell(true);
            ((DatagridViewCheckBoxHeaderCell)dgvLabels.Columns[checkedDataGridViewTextBoxColumn.Index].HeaderCell).CheckBoxClicked += CheckBoxHeaderCell_OnCheckBoxClicked;
        }

        private void LoadPrinters()
        {
            try
            {
                var bsPrinters = new BindingSource();

                bsPrinters.DataMember = "LR_Printers";
                bsPrinters.DataSource = pickControl;

                cmbPrinters.ComboBox.DisplayMember = "PrinterName";
                cmbPrinters.ComboBox.ValueMember = "Printer_ID";
                cmbPrinters.ComboBox.DataSource = bsPrinters;

                using (var adapter = new Data.PickControlTableAdapters.LR_PrintersTableAdapter())
                    adapter.Fill(pickControl.LR_Printers, this.UserID);

                bsPrinters.DataSource = pickControl.LR_Printers;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void CheckBoxHeaderCell_OnCheckBoxClicked(object sender, WMSOffice.Dialogs.Complaints.DataGridViewCheckBoxHeaderCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvLabels.Rows)
                    row.Cells[checkedDataGridViewTextBoxColumn.Index].Value = e.IsChecked;

                dgvLabels.RefreshEdit();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            tbOrder.TextBox.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                RefreshLabels();
                return true;
            }

            if (keyData == (Keys.Control | Keys.P))
            {
                ReprintLabels();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefreshLabels_Click(object sender, EventArgs e)
        {
            this.RefreshLabels();
        }

        private void RefreshLabels()
        {
            try
            {
                var sOrder = tbOrder.Text;
                var iOrder = 0;

                if (string.IsNullOrEmpty(tbOrder.Text))
                    throw new Exception("Не указан номер заказа, сборочного.");
                
                if (!int.TryParse(sOrder, out iOrder))
                    throw new Exception("Номер заказа, сборочного должен быть числом.");

                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += (s, e) =>
                {
                    try
                    {
                       e.Result = lR_LabelsTableAdapter.GetData(this.UserID, sOrder, (string)null);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                loadWorker.RunWorkerCompleted += (s, e) =>
                {
                    waitProgressForm.CloseForce();

                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                        lRLabelsBindingSource.DataSource = e.Result;
                };
                lRLabelsBindingSource.DataSource = null;
                waitProgressForm.ActionText = "Выполняется поиск этикеток..";
                loadWorker.RunWorkerAsync();
                waitProgressForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnReprintLabels_Click(object sender, EventArgs e)
        {
            this.ReprintLabels();
        }

        private void ReprintLabels()
        {
            try
            {
                var checkedLabels = this.GetCheckedLabels();

                if (checkedLabels.Count == 0)
                    throw new Exception("Не выбраны этикетки для повторной печати.");
              
                var printerID = cmbPrinters.ComboBox.SelectedValue.ToString();

                var reprintWorker = new BackgroundWorker();
                reprintWorker.DoWork += (s, e) => 
                {
                    try
                    {
                        var cntTotalLabels = checkedLabels.Count;
                        var cntPrintedLabels = 0;
                        foreach (var label in checkedLabels)
                        {
                            var kcoo = label.Company;
                            var doco = label.OrderNum;
                            var dcto = label.OrderType;
                            var psn = label.AssemblyNum;
                            var eticID = label.EticID;

                            using (var adapter = new Data.PickControlTableAdapters.LR_LabelsTableAdapter())
                                adapter.Reprint(this.UserID, kcoo, doco, dcto, psn, eticID, printerID);

                            label.IsPrinted = 1;

                            ThreadSafeDelegate(() => { waitProgressForm.ActionText = string.Format("Выполняется повторная печать этикеток\nНапечатано {0} из {1}..", ++cntPrintedLabels, cntTotalLabels); });
                        }
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    } 
                };
                reprintWorker.RunWorkerCompleted += (s, e) =>
                {
                    waitProgressForm.CloseForce();

                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                        dgvLabels.RefreshEdit();
                };
                waitProgressForm.ActionText = "Выполняется повторная печать этикеток..";
                reprintWorker.RunWorkerAsync();
                waitProgressForm.ShowDialog();
               
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private List<Data.PickControl.LR_LabelsRow> GetCheckedLabels()
        {
            var checkedLabels = new List<Data.PickControl.LR_LabelsRow>();

            foreach (DataGridViewRow row in dgvLabels.Rows)
            {
                var label = (row.DataBoundItem as DataRowView).Row as Data.PickControl.LR_LabelsRow;
                var isChecked = label.IsCheckedNull() ? false : label.Checked;

                if (isChecked)
                    checkedLabels.Add(label);
            }

            return checkedLabels;
        }


        private void ThreadSafeDelegate(MethodInvoker method)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)method);
            else
                method();
        }

        private void dgvLabels_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLabels.CurrentCell is DataGridViewCheckBoxCell)
            {
                if (dgvLabels.IsCurrentCellDirty)
                {
                    dgvLabels.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    var label = (dgvLabels.CurrentRow.DataBoundItem as DataRowView).Row as Data.PickControl.LR_LabelsRow;

                    // Раскраска
                    var isChecked = label.IsCheckedNull() ? false : label.Checked;
                    var isPrinted = Convert.ToBoolean(label.IsIsPrintedNull() ? 0 : label.IsPrinted);
                    
                    foreach (DataGridViewColumn column in this.dgvLabels.Columns)
                    {
                        dgvLabels.Rows[dgvLabels.CurrentRow.Index].Cells[column.Index].Style.BackColor = isPrinted ? printedColor : isChecked ? checkedColor : SystemColors.Window;
                        dgvLabels.Rows[dgvLabels.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isPrinted ? printedColor : isChecked ? checkedColor : Color.Black;
                    }
                }
            }
        }

        private void dgvLabels_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var label = (dgvLabels.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.PickControl.LR_LabelsRow;

            // Раскраска
            var isChecked = label.IsCheckedNull() ? false : label.Checked;
            var isPrinted = Convert.ToBoolean(label.IsIsPrintedNull() ? 0 : label.IsPrinted);

            dgvLabels.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isPrinted ? printedColor : isChecked ? checkedColor : SystemColors.Window;
            dgvLabels.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isPrinted ? printedColor : isChecked ? checkedColor : Color.Black;
        }

        private void dgvLabels_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
    }
}
