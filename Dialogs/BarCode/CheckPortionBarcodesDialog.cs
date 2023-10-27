using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.BarCode
{
    public partial class CheckPortionBarcodesDialog : Form
    {
        private readonly long portionID;

        public CheckPortionBarcodesDialog(long portionID)
        {
            InitializeComponent();
            this.portionID = portionID;
        }

        private void CheckPortionBarcodesDialog_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                portionBarCodesTableAdapter.Fill(bC.PortionBarCodes, this.portionID);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException ?? ex;
                MessageBox.Show(msg.Message, "Ошибка получения ш/к", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Text = string.Format("{0} № {1}", this.Text, this.portionID);

            this.Initialize();
        }

        private void Initialize()
        {
            tbsScanBarCode.TextChanged += new EventHandler(tbsScanBarCode_TextChanged);

            UpdateStatistics();

            if (dgvDetails.Rows.Count > 0)
                dgvDetails.Rows[0].Selected = false;

            tbsScanBarCode.Focus();
        }

        private void UpdateStatistics()
        {
            var iTotalBarCodes = 0;
            var iCheckedBarCodes = 0;
            var iDublicateBarCodes = 0;

            iTotalBarCodes = bC.PortionBarCodes.Rows.Count;

            var oCheckedBarCodes = bC.PortionBarCodes.Compute(string.Format("SUM({0})", bC.PortionBarCodes.CheckedCountColumn.Caption), null);
            iCheckedBarCodes = Convert.ToInt32(oCheckedBarCodes == DBNull.Value ? 0 : oCheckedBarCodes);

            var oDublicateBarCodes = bC.PortionBarCodes.Compute(string.Format("SUM({0})", bC.PortionBarCodes.CheckedCountColumn.Caption), string.Format("ISNULL({0}, 1) > 1", bC.PortionBarCodes.CheckedCountColumn.Caption));
            var oDublicateGroupsBarcodes = bC.PortionBarCodes.Compute(string.Format("COUNT({0})", bC.PortionBarCodes.CheckedCountColumn.Caption), string.Format("ISNULL({0}, 1) > 1", bC.PortionBarCodes.CheckedCountColumn.Caption));
            iDublicateBarCodes = Convert.ToInt32(oDublicateBarCodes == DBNull.Value ? 0 : oDublicateBarCodes) - Convert.ToInt32(oDublicateGroupsBarcodes == DBNull.Value ? 0 : oDublicateGroupsBarcodes);

            lblTotalBarCodes.Text = string.Format("{0}", iTotalBarCodes);
            lblCheckedBarCodes.Text = string.Format("{0}", iCheckedBarCodes);
            lblDublicateBarCodes.Text = string.Format("{0}", iDublicateBarCodes);
        }

        void tbsScanBarCode_TextChanged(object sender, EventArgs e)
        {
            var barcode = tbsScanBarCode.Text;
            if (string.IsNullOrEmpty(barcode))
                return;

            try
            {
                var findRow = bC.PortionBarCodes.FindByBarcodeID(barcode);
                if (findRow != null)
                {
                    portionBarCodesTableAdapter.CheckPortionBarCode(portionID, barcode);

                    var checkedCount = findRow.IsCheckedCountNull() ? 0 : findRow.CheckedCount;
                    findRow.CheckedCount = ++checkedCount;

                    foreach (DataGridViewRow row in dgvDetails.Rows)
                    {
                        if ((row.DataBoundItem as DataRowView).Row.Equals(findRow))
                        {
                            row.Selected = true;
                            dgvDetails.FirstDisplayedScrollingRowIndex = row.Index;
                            break;
                        }
                    }

                    UpdateStatistics();

                    dgvDetails.Refresh();
                }
                else
                    throw new Exception("Ш/К в текущей порции не найден.");
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException ?? ex;
                MessageBox.Show(msg.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tbsScanBarCode.Text = string.Empty;
                tbsScanBarCode.Focus();
            }
        }

        private void dgvDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var row = (dgvDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.BC.PortionBarCodesRow;
            var checkedCount = row.IsCheckedCountNull() ? 0 : row.CheckedCount;

            var color = checkedCount == 0
                            ? Color.White
                            : checkedCount == 1
                                ? Color.LightGreen
                                : Color.Salmon;

            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionForeColor = color;
        }


    }
}
