using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Dialogs.PickControl;

namespace WMSOffice.Window
{
    public partial class ReprintTareEticWindow : GeneralWindow
    {
        public string PrinterID { get; private set; }

        public string PrinterName { get; private set; }

        private TextBoxScaner tbScanner = null;

        private NumericUpDown nudCopiesCount = null;

        private bool allowCloseWindow = false;

        public ReprintTareEticWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();
        }

        private void Initialize()
        {
            tsMain.Visible = false;
            pnlContent.Visible = false;

            if (!SelectPrinter())
            {
                // закрываем окно
                allowCloseWindow = true;
                Close();

                return;
            }

            if (!CreateDoc())
            {
                // закрываем окно
                allowCloseWindow = true;
                Close();

                return;
            }

            this.DocTitle.Text = string.Format("Повторная печать этикеток на тару ({0}-{1}) [Принтер: {2} ({3})]", this.DocType, this.DocID, this.PrinterID.Trim(), this.PrinterName.Trim());

            tsMain.Visible = true;
            pnlContent.Visible = true;

            #region ИНИЦИАЛИЗАЦИЯ ПОИСКА ПО Ш/К

            tsSearch.Items.Add(new ToolStripLabel("Ш/К : ") { ForeColor = Color.Blue });

            tbScanner = new TextBoxScaner();
            tbScanner.TextChanged += (s, e) =>
            {
                if (!string.IsNullOrEmpty(tbScanner.Text))
                    this.ProcessBarCode();
            };
            tsSearch.Items.Add(new ToolStripControlHost(tbScanner) { Width = 200 });

            #endregion

            //#region ИНИЦИАЛИЗАЦИЯ ВВОДА КОЛИЧЕСТВА КОПИЙ

            //tsSearch.Items.Add(new ToolStripSeparator());
            //tsSearch.Items.Add(new ToolStripLabel("Копий : ") { ForeColor = Color.Blue });

            //nudCopiesCount = new NumericUpDown() { Minimum = 1, Maximum = 100 };
            //tsSearch.Items.Add(new ToolStripControlHost(nudCopiesCount));

            //#endregion

            this.RefreshData();

            //this.InitEticCopiesCount();

            this.SetOperationAccess();

            tbScanner.Focus();
        }

        private bool SelectPrinter()
        {
            try
            {
                var printers = new Data.PickControl.EB_RET_Reprint_PrintersDataTable();
                using (var adapter = new Data.PickControlTableAdapters.EB_RET_Reprint_PrintersTableAdapter())
                    adapter.Fill(printers, this.UserID);

                if (printers.Rows.Count == 0)
                    throw new Exception("У Вас нет доступа к интерфейсу повторной печати этикеток на тару.");

                if (printers.Rows.Count == 1)
                {
                    this.PrinterID = printers[0].Printer_Alias;
                    this.PrinterName = printers[0].Printer_Name;
                    return true;
                }
                else
                {
                    var dlgSelectPrinter = new WMSOffice.Dialogs.RichListForm();
                    dlgSelectPrinter.Text = "Выберите принтер";
                    dlgSelectPrinter.AddColumn("Printer_Alias", "Printer_Alias", "Код");
                    dlgSelectPrinter.AddColumn("Printer_Name", "Printer_Name", "Местоположение");
                    dlgSelectPrinter.FilterChangeLevel = 0;
                    dlgSelectPrinter.FilterVisible = false;

                    dlgSelectPrinter.DataSource = printers;

                    if (dlgSelectPrinter.ShowDialog() != DialogResult.OK)
                        return false;

                    var printer = dlgSelectPrinter.SelectedRow as Data.PickControl.EB_RET_Reprint_PrintersRow;
                    this.PrinterID = printer.Printer_Alias;
                    this.PrinterName = printer.Printer_Name;
                    return true;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        private bool CreateDoc()
        {
            try
            {
                var docID = (long?)null;

                using (var adapter = new Data.PickControlTableAdapters.EB_RET_Reprint_PrintersTableAdapter())
                    adapter.CreateDoc(this.PrinterID, this.UserID, ref docID);

                if (!docID.HasValue)
                    throw new Exception("Не удалось создать документ повторной печати этикеток на тару");

                this.DocID = docID.Value;

                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        private void InitEticCopiesCount()
        {
            var frmEticCount = new EticCountForm();
            frmEticCount.Count = 1;
            frmEticCount.MinimumCount = Convert.ToInt32(nudCopiesCount.Minimum);
            frmEticCount.LimitCount = Convert.ToInt32(nudCopiesCount.Maximum);
            frmEticCount.MaximumLimitCount = Convert.ToInt32(nudCopiesCount.Maximum);
            frmEticCount.Caption = "Введите количество копий\nэтикеток";

            if (frmEticCount.ShowDialog() == DialogResult.OK)
                nudCopiesCount.Value = Convert.ToDecimal(frmEticCount.Count);
        }

        private void ProcessBarCode()
        {
            var barCode = tbScanner.Text.Trim();

            try
            {
                if (this.ReprintEtic())
                    tbScanner.Text = string.Empty;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.RefreshData(barCode);

                tbScanner.Focus();
                tbScanner.SelectAll();
            }
        }

        private void SetAutoFocusOnDetail(string barCode)
        {
            if (string.IsNullOrEmpty(barCode))
                return;

            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                var detail = (row.DataBoundItem as DataRowView).Row as Data.PickControl.EB_RET_Reprint_Task_DetailsRow;
                if (detail.Bar_Code.Equals(barCode, StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;
                    dgvDetails.FirstDisplayedScrollingRowIndex = row.Index;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.RefreshData();
                return true;
            }

            if (keyData == (Keys.P | Keys.Control))
            {
                this.ReprintEticManual();
                return true;
            }

            if (keyData == (Keys.F4))
            {
                this.CloseDoc();
                return true;
            }

            if (keyData == (Keys.F8))
            {
                this.CancelDoc();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void RefreshData()
        {
            this.RefreshData(dgvDetails.SelectedRows.Count > 0 ? ((dgvDetails.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.PickControl.EB_RET_Reprint_Task_DetailsRow).Bar_Code : string.Empty);
        }

        private void RefreshData(string barCode)
        {
            try
            {
                eB_RET_Reprint_Task_DetailsTableAdapter.Fill(pickControl.EB_RET_Reprint_Task_Details, this.DocID);

                this.SetAutoFocusOnDetail(barCode);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                tbScanner.Focus();
            }
        }

        private void btnReprintEtic_Click(object sender, EventArgs e)
        {
            this.ReprintEticManual();
        }

        private void ReprintEticManual()
        {
            var barCode = ((dgvDetails.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.PickControl.EB_RET_Reprint_Task_DetailsRow).Bar_Code;

            if (this.ReprintEtic(barCode, true))
            {
                this.RefreshData();

                tbScanner.Text = string.Empty;
            }
        }

        private bool ReprintEtic()
        {
            var barCode = tbScanner.Text.Trim();
            return this.ReprintEtic(barCode, false);
        }

        private bool ReprintEtic(string barCode, bool isReprint)
        {
            if (isReprint && !btnReprintEtic.Enabled)
                return false;

            try
            {
                var errorMessage = (string)null;

                var cntCopies = (int?)null; // Convert.ToInt32(nudCopiesCount.Value);
                eB_RET_Reprint_Task_DetailsTableAdapter.AddTaskDetail(this.DocID, cntCopies, barCode, isReprint, ref errorMessage, this.UserID);

                if (!string.IsNullOrEmpty(errorMessage))
                    throw new WarningException(errorMessage);

                return true;
            }
            catch (WarningException ex)
            {
                try
                {
                    var msgForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(ex.Message, "ПРОДОЛЖИТЬ (Enter)", System.Drawing.Color.Yellow);
                    msgForm.TimeOut = 2000;
                    msgForm.AutoClose = false;
                    msgForm.ShowDialog();

                    return true;
                }
                catch (Exception exc)
                {
                    this.ShowError(exc);
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            this.CloseDoc();
        }

        private void CloseDoc()
        {
            try
            {
                using (var adapter = new Data.PickControlTableAdapters.EB_RET_Reprint_PrintersTableAdapter())
                    adapter.CloseDoc(this.UserID, this.DocID, false);

                // закрываем окно
                allowCloseWindow = true;
                Close();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnCancelDoc_Click(object sender, EventArgs e)
        {
            this.CancelDoc();
        }

        private void CancelDoc()
        {
            try
            {
                using (var adapter = new Data.PickControlTableAdapters.EB_RET_Reprint_PrintersTableAdapter())
                    adapter.CloseDoc(this.UserID, this.DocID, true);

                // закрываем окно
                allowCloseWindow = true;
                Close();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void ReprintTareEticWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowCloseWindow && (Control.ModifierKeys != Keys.Control))
            {
                MessageBox.Show("Нельзя закрыть окно документа до завершения процедуры повторной печати.\n\rПожалуйста, продолжайте работу.\n\rДля закрытия документа воспользуйтесь командой \"Закрыть документ\".", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess();
        }

        private void SetOperationAccess()
        {
            btnReprintEtic.Enabled = dgvDetails.SelectedRows.Count > 0;
        }

        private void dgvDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var detail = (dgvDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.PickControl.EB_RET_Reprint_Task_DetailsRow;
            var cntCopies = detail.IscopiesNull() ? 0 : detail.copies;
            var cntPrinted = detail.IsPrintedCopiesNull() ? 0 : detail.PrintedCopies;

            var color = Color.Empty;

            if (cntPrinted == 0) // Ни одна из копий этикетки не была напечатана
                color = Color.White;
            else if (cntCopies == cntPrinted) // Все копии этикетки были напечатаны
                color = Color.LightGreen;
            else
                color = Color.Khaki; // Некоторые из копий этикетки были напечатаны

            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionForeColor = color;
        }

    }
}
