using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Delivery;

namespace WMSOffice.Window
{
    public partial class ReturnsDeliveryWindow : GeneralWindow
    {
        public bool Terminate { get; private set; }

        public ReturnsDeliveryWindow()
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
            if (!this.CreateDocument())
            {
                allowCloseWindow = true;
                this.Terminate = true;
                this.Close();
                return;
            }

            tbsItemBarcode.TextChanged += new EventHandler(tbsItemBarcode_TextChanged);
            this.ReloadDocItems();
        }

        void tbsItemBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbsItemBarcode.Text))
            {
                var itemBarcode = tbsItemBarcode.Text;
                if (this.CheckMemo(itemBarcode))
                {
                    this.ReloadDocItems();
                    this.CheckCloseDoc();
                }
            }
        }

        private bool CheckMemo(string memoBarcode)
        {
            try
            {
                if (this.FindMemo(memoBarcode))
                {
                    var dlgReturnsDeliverySetMemoRejectReasonForm = new ReturnsDeliverySetMemoResultForm() { UserID = this.UserID, MemoBarcode = memoBarcode };
                    if (dlgReturnsDeliverySetMemoRejectReasonForm.ShowDialog() == DialogResult.OK)
                    {
                        var docID = Convert.ToInt32(this.DocID);
                        var reasonID = dlgReturnsDeliverySetMemoRejectReasonForm.ReasonID;
                        var reasonDesc = dlgReturnsDeliverySetMemoRejectReasonForm.ReasonDesc;
                        using (var adapter = new Data.ComplaintsTableAdapters.CO_Memo_DocDetailsTableAdapter())
                            adapter.ScanMemo(docID, memoBarcode, reasonID, reasonDesc);

                        return true;
                    }

                    return false;
                }
                else
                    throw new Exception("Служебная записка не найдена.");
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                tbsItemBarcode.Focus();
                tbsItemBarcode.SelectAll();
                return false;
            }
        }

        private bool FindMemo(string memoBarcode)
        {
            foreach (DataGridViewRow dgrMemo in dgvItems.Rows)
            {
                var memoRow = (dgrMemo.DataBoundItem as DataRowView).Row as Data.Complaints.CO_Memo_DocDetailsRow;
                if (memoRow.OrderNumber.Equals(memoBarcode, StringComparison.OrdinalIgnoreCase))
                {
                    dgrMemo.Selected = true;
                    dgvItems.FirstDisplayedScrollingRowIndex = dgrMemo.Index;
                    return true;
                }
            }

            return false;
        }

        private bool CreateDocument()
        {
            try
            {
                pnlContent.Visible = false;

                var checkRouteListResult = this.CheckRouteList();
                if (!checkRouteListResult)
                    return false;

                pnlContent.Visible = true;

                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        private bool CheckRouteList()
        {
            var routeListBarcode = (string)null;
            while (true)
            {
                try
                {
                    var dlgScanRouteList = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте маршрутный лист\r\nдля фиксации возвратов",
                        Text = "Доставка возвратов",
                        Barcode = routeListBarcode,
                        Image = Properties.Resources.delivery
                    };

                    if (dlgScanRouteList.ShowDialog() == DialogResult.OK)
                    {
                        routeListBarcode = dlgScanRouteList.Barcode;

                        var docID = (int?)null;
                        using (var adapter = new Data.ComplaintsTableAdapters.CO_Memo_DocDetailsTableAdapter())
                            adapter.CreateDoc(routeListBarcode, this.UserID, ref docID);

                        if (!docID.HasValue)
                            throw new Exception("Не удалось создать документ фиксации возвратов.");

                        this.DocID = docID.Value;
                        this.DocTitle.Text = string.Format("{0} ({1}-{2})", this.DocName, this.DocType, this.DocID);

                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
            }
                      
        }

        private void btnRefreshDoc_Click(object sender, EventArgs e)
        {
            this.ReloadDocItems();
        }

        private void ReloadDocItems()
        {
            try
            {
                var docID = Convert.ToInt32(this.DocID);
                using (var adapter = new Data.ComplaintsTableAdapters.CO_Memo_DocDetailsTableAdapter())
                    adapter.Fill(complaints.CO_Memo_DocDetails, docID);

                if (dgvItems.Rows.Count > 0)
                    dgvItems.Rows[0].Selected = false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                tbsItemBarcode.Text = string.Empty;
                tbsItemBarcode.Focus();
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

        private void CheckCloseDoc()
        {
            try
            {
                var resultFlag = (int?)null;
                var docID = Convert.ToInt32(this.DocID);
                using (var adapter = new Data.ComplaintsTableAdapters.CO_Memo_DocDetailsTableAdapter())
                    adapter.CanCloseDoc(docID, ref resultFlag);

                if (Convert.ToBoolean(resultFlag ?? 0))
                    this.CloseDoc();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void CloseDoc()
        {
            try
            {
                var docID = Convert.ToInt32(this.DocID);
                using (var adapter = new Data.ComplaintsTableAdapters.CO_Memo_DocDetailsTableAdapter())
                    adapter.CloseDoc(docID);

                MessageBox.Show("Документ был успешно закрыт.", "Закрытие документа", MessageBoxButtons.OK, MessageBoxIcon.Information);

                allowCloseWindow = true;
                this.Close();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void CancelDoc()
        {
            try
            {
                var docID = Convert.ToInt32(this.DocID);
                using (var adapter = new Data.ComplaintsTableAdapters.CO_Memo_DocDetailsTableAdapter())
                    adapter.CancelDoc(docID);

                allowCloseWindow = true;
                this.Terminate = true;
                this.Close();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private bool allowCloseWindow = false;
        private void ReturnsDeliveryWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowCloseWindow && (Control.ModifierKeys != Keys.Control))
            {
                MessageBox.Show("Нельзя закрыть окно документа до завершения\r\nпроцедуры фиксации возвратов. Пожалуйста, продолжайте работу.\r\nДля закрытия документа фиксации возвратов воспользуйтесь командой \"Закрыть документ\".", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }

            if (Control.ModifierKeys == Keys.Control)
                this.Terminate = true;
        }

        private void dgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var boundRow = (dgvItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Complaints.CO_Memo_DocDetailsRow;
            var color = boundRow.IsColorNull() ? Color.White : Color.FromName(boundRow.Color);
            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionForeColor = color;
        }
    }
}
