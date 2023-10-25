using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Window
{
    public partial class ReceiptDebtorsReturnedTareWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        private bool allowCloseWindow = false;

        public ReceiptDebtorsReturnedTareWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!CreateDoc())
            {
                // закрываем окно
                allowCloseWindow = true;
                Close();

                return;
            }

            this.InitDocument();
        }

        private bool CreateDoc()
        {
            try
            {
                var docID = (long?)null;
                var warnMessage = (string)null;

                using (var adapter = new Data.DeliveryTableAdapters.JT_RET_Repeated_Doc_DetailsTableAdapter())
                    adapter.CreateDoc(this.UserID, ref docID, ref warnMessage);

                if (!docID.HasValue)
                    throw new Exception("Не удалось создать журнал сдачи клиентской оборотной тары");

                this.DocID = docID.Value;

                if (!string.IsNullOrEmpty(warnMessage))
                    MessageBox.Show(warnMessage, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        private void InitDocument()
        {
            this.DocTitle.Text = string.Format("Журнал сдачи клиентской оборотной тары ({0}-{1})", this.DocType, this.DocID);
            tbsItemBarcode.TextChanged += new EventHandler(tbsItemBarcode_TextChanged);

            this.ReloadData();
        }

        void tbsItemBarcode_TextChanged(object sender, EventArgs e)
        {
            this.CheckBarcode();
        }

        private void CheckBarcode()
        {
            try
            {
                if (string.IsNullOrEmpty(tbsItemBarcode.Text))
                    return;

                using (var adapter = new Data.DeliveryTableAdapters.JT_RET_Repeated_Doc_DetailsTableAdapter())
                    adapter.CheckBarcode(this.UserID, this.DocID, tbsItemBarcode.Text);

                this.ReloadData();
                //this.FindDocDetail(tbsItemBarcode.Text);

                tbsItemBarcode.Text = string.Empty;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                tbsItemBarcode.Focus();
                tbsItemBarcode.SelectAll();
            }
        }

        private Data.Delivery.JT_RET_Repeated_Doc_DetailsRow FindDocDetail(string barcode)
        {
            foreach (DataGridViewRow gridRow in dgvItems.Rows)
            {
                var row = (gridRow.DataBoundItem as DataRowView).Row as Data.Delivery.JT_RET_Repeated_Doc_DetailsRow;
                if (row.BarCode.Equals(barcode, StringComparison.OrdinalIgnoreCase))
                {
                    gridRow.Selected = true;
                    dgvItems.FirstDisplayedScrollingRowIndex = gridRow.Index;
                    return row;
                }
            }

            return null;
        }

        private void btnRefreshDoc_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += (s, e) =>
                {
                    try
                    {
                        e.Result = jT_RET_Repeated_Doc_DetailsTableAdapter.GetData(this.DocID, this.UserID);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                loadWorker.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        jTRETRepeatedDocDetailsBindingSource.DataSource = e.Result;
                        this.FindDocDetail(tbsItemBarcode.Text);
                    }

                    waitProgressForm.CloseForce();
                };

                jTRETRepeatedDocDetailsBindingSource.DataSource = null;
                waitProgressForm.ActionText = "Выполняется загрузка отсканированной тары..";
                loadWorker.RunWorkerAsync();
                waitProgressForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            this.CloseDoc();
        }

        private void btnCancelDoc_Click(object sender, EventArgs e)
        {
            this.CancelDoc();
        }

        private void CloseDoc()
        {
            this.CloseDoc(false);
        }

        private void CancelDoc()
        {
            this.CloseDoc(true);
        }

        private void CloseDoc(bool isCancel)
        {
            try
            {
                using (var adapter = new Data.DeliveryTableAdapters.JT_RET_Repeated_Doc_DetailsTableAdapter())
                    adapter.CloseDoc(this.UserID, this.DocID, isCancel);

                // закрываем окно
                allowCloseWindow = true;
                Close();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void ReceiptDebtorsReturnedTareWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowCloseWindow && (Control.ModifierKeys != Keys.Control))
            {
                MessageBox.Show("Нельзя закрыть окно документа до завершения\n\rпроцедуры сдачи. Пожалуйста, продолжайте работу.\n\r\n\rДля закрытия документа воспользуйтесь командой \"Закрыть документ\".", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void dgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = (dgvItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Delivery.JT_RET_Repeated_Doc_DetailsRow;
            var color = row.IsColorNull() ? Color.White : Color.FromName(row.Color);

            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionForeColor = color;
        }
    }
}
