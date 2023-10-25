using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Delivery;
using WMSOffice.Dialogs.PickControl;

namespace WMSOffice.Window
{
    public partial class DeliveryReturnWindow : GeneralWindow
    {
        public DeliveryReturnWindow()
        {
            InitializeComponent();
        }

        private void RefreshHeader()
        {
            routeListInfoTableAdapter.Fill(delivery.RouteListInfo, DocID);
            if (delivery.RouteListInfo.Count > 0)
            {
                Data.Delivery.RouteListInfoRow info = delivery.RouteListInfo[0];
                lblRouteList.Text = info.RL_Num.ToString();
                lblCar.Text = info.Car_Num;
                lblStatus.Text = info.RL_Status;
                lblDriver.Text = info.Driver;
                lblDeliveryDate.Text = info.IsDeliveryDateNull() ? string.Empty : info.DeliveryDate.ToShortDateString();
                lblRegim.Text = info.IsZoneNameNull() ? string.Empty : info.ZoneName;
                lblPerron.Text = info.IsPeron_IDNull() ? string.Empty : info.Peron_ID.ToString();
                tbBarcode.Text = "";
            }
            else
            {
                lblRouteList.Text = lblCar.Text = lblStatus.Text = lblDriver.Text =
                    lblDeliveryDate.Text = lblRegim.Text = lblPerron.Text = lblPerron.Text = tbBarcode.Text = "";
            }
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbBarcode.Text))
                try
                {
                    AddRow(tbBarcode.Text);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            tbBarcode.Text = "";
        }

        private void AddRow(string barcode)
        {
            try
            {
                docRowsTableAdapter.Insert(DocID, barcode);
                RefreshLines(); // обновляем строки
            } catch (Exception ex)
            {
                if (ex.Message.Contains("REDFORM"))
                {
                    FullScreenErrorForm errorForm = new FullScreenErrorForm(
                        String.Format("{0}", ex.Message.Replace("REDFORM", "")),
                        "ПРОДОЛЖИТЬ (Enter)", Color.Red);
                    errorForm.TimeOut = 2000;
                    errorForm.ShowDialog();
                }
                else
                    ShowError(ex);
            }
        }

        private void RefreshLines()
        {
            docRowsTableAdapter.Fill(delivery.DocRows, DocID);
        }

        private void DeliveryPackingWindow_Load(object sender, EventArgs e)
        {
            RefreshHeader();
            RefreshLines();
            btnUndo.Enabled = miUndo.Checked = gvLines.SelectedRows.Count > 0;
            tbBarcode.Focus();
        }

        private void gvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // разрисовка строк в таблице
            foreach (DataGridViewRow row in gvLines.Rows)
            {
                Data.Delivery.DocRowsRow diffRow = (Data.Delivery.DocRowsRow)((DataRowView)row.DataBoundItem).Row;

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

        private void gvLines_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //ShowDifference();
        }

        private void gvLines_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //{
            //    ShowDifference();
            //}
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (gvLines.SelectedRows.Count == 1)
            {
                try
                {
                    Data.Delivery.DocRowsRow row =
                        ((Data.Delivery.DocRowsRow) ((DataRowView) gvLines.SelectedRows[0].DataBoundItem).Row);
                    if (MessageBox.Show(
                        String.Format("Вы уверены, что хотите отменить возврат\n\r выбранного в таблице заказа {0}/{1}?", row.OrderType, row.OrderNumber),
                        "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        docRowsTableAdapter.Delete(DocID, row.OrderType, row.OrderNumber);
                        RefreshLines();
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("REDFORM"))
                    {
                        FullScreenErrorForm errorForm = new FullScreenErrorForm(
                            String.Format("{0}", ex.Message.Replace("REDFORM", "")),
                            "ПРОДОЛЖИТЬ (Enter)", Color.Red);
                        errorForm.TimeOut = 2000;
                        errorForm.ShowDialog();
                    }
                    else
                        ShowError(ex);
                }
            }
        }

        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            // закрыть документ возврата товара
            try
            {
                docRowsTableAdapter.CloseDoc(DocID);

                // закрываем окно
                allowCloseWindow = true;
                Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("REDFORM"))
                {
                    FullScreenErrorForm errorForm = new FullScreenErrorForm(
                        String.Format("{0}", ex.Message.Replace("REDFORM", "")),
                        "ПРОДОЛЖИТЬ (Enter)", Color.Red);
                    errorForm.TimeOut = 2000;
                    errorForm.ShowDialog();
                }
                else
                    ShowError(ex);
            }
        }

        private void gvLines_SelectionChanged(object sender, EventArgs e)
        {
            btnUndo.Enabled = miUndo.Checked = gvLines.SelectedRows.Count > 0;
        }

        private bool allowCloseWindow = false;
        private void DeliveryReturnWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowCloseWindow && (Control.ModifierKeys != Keys.Control))
            {
                MessageBox.Show("Нельзя закрыть окно документа до завершения процедуры возврата. Пожалуйста, продолжайте работу.\n\rДля закрытия документа возврата воспользуйтесь командой \"Завершить возврат товара\".", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

    }
}
