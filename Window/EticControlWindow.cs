using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data.EticTableAdapters;
using WMSOffice.Dialogs.PickControl;

namespace WMSOffice.Window
{
    public partial class EticControlWindow : GeneralWindow
    {
        public EticControlWindow()
        {
            InitializeComponent();
            lblDocType.Text = lblDocNumber.Text = lblDocDate.Text = lblNumber.Text = lblDelivery.Text = lblDeliveryDate.Text =
                lblContainer.Text = lblDepartment.Text = lblRegim.Text = tbBarcode.Text = lblMest.Text = lblMestD.Text = "";
        }

        private void EticControlWindow_Load(object sender, EventArgs e)
        {
            // получаем информацию по номеру документа
            using (Data.EticTableAdapters.PickSlipInfoTableAdapter adapter = new WMSOffice.Data.EticTableAdapters.PickSlipInfoTableAdapter())
            {
                try
                {
                    Data.Etic.PickSlipInfoDataTable table = adapter.GetData(DocID);
                    if (table == null || table.Count != 1)
                        ShowError("Не найдена информация о документе!");
                    else
                    {
                        Data.Etic.PickSlipInfoRow row = table[0];
                        lblDocType.Text = row.Doc_type;
                        lblDocNumber.Text = row.Doc_number.ToString();
                        lblDocDate.Text = row.Order_Date.ToShortDateString();
                        lblNumber.Text = row.PickSlip.ToString();
                        lblDelivery.Text = row.Delivery;
                        lblDeliveryDate.Text = row.Delivery_Date.ToShortDateString();
                        lblContainer.Text = row.Conteiner_id;
                        lblDepartment.Text = row.OtdelName;
                        lblRegim.Text = row.Delivery_Zone;
                        lblMest.Text = row.Mest.ToString();
                        lblMestD.Text = row.MestD.ToString();
                        tbBarcode.Focus();
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
            RefreshLines();
        }

        private void RefreshLines()
        {
            docRowsBindingSource.Filter = "";
            docRowsBindingSource.Sort = "";
            docRowsTableAdapter.Fill(etic.DocRows, DocID);
            if (gvLines.Rows.Count > 0)
                gvLines.Rows[0].Selected = true;
        }

        private void RefreshPlaces()
        {
            using (Data.EticTableAdapters.PickSlipInfoTableAdapter adapter = new WMSOffice.Data.EticTableAdapters.PickSlipInfoTableAdapter())
            {
                try
                {
                    Data.Etic.PickSlipInfoDataTable table = adapter.GetData(DocID);
                    if (table == null || table.Count != 1)
                    { // ShowError("Не найдена информация о документе!");
                    }
                    else
                    {
                        Data.Etic.PickSlipInfoRow row = table[0];
                        lblMest.Text = row.Mest.ToString();
                        lblMestD.Text = row.MestD.ToString();
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        private void RefreshData()
        {
            RefreshPlaces();
            RefreshLines();
        }

        private void miRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbBarcode.Text))
            {
                try
                {
                    docRowsTableAdapter.AddRow(DocID, tbBarcode.Text);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("REDFORM"))
                    {
                        FullScreenErrorForm errorForm = new FullScreenErrorForm(
                            String.Format(
                                "{0}",
                                ex.Message.Replace("REDFORM", "")),
                            "ПРОДОЛЖИТЬ (Enter)", Color.Red);
                        errorForm.TimeOut = 2000;
                        errorForm.ShowDialog();
                    }
                    else ShowError(ex);
                }

                tbBarcode.Text = "";
                RefreshData();
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // ...спрашиваем количество этикеток (мест)
            EticCountForm form = new EticCountForm();
            form.Count = 1;
            bool eticError = true;
            while (eticError)
            {
                try
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (form.Count >= 0)
                        {
                            docRowsTableAdapter.PrintEtic(DocID, UserID, form.Count, System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                            eticError = false;
                        }
                    } else eticError = false;
                }
                catch (Exception exch)
                {
                    ShowError(exch);
                    eticError = true;
                }
            }
            RefreshData();
        }

        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            RefreshData();
            bool toClose = false;
            if (lblMest.Text != lblMestD.Text)
            {
                // не совпадает количество мест в ETIC и в документе
                if (MessageBox.Show(
                    String.Format(
                        "Из {0} напечатанных этикеток отсканировано {1}.{2}Неотсканированные этикетки будут удалены из базы!{2}{2}Вы уверены, что хотите закрыть документ?",
                        lblMest.Text, lblMestD.Text, Environment.NewLine),
                    "Закрытие документа", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // переспросили, можно закрывать
                    toClose = true;
                }
            } else
            {
                // все сошлось, закрываем документ
                toClose = true;
            }

            if (toClose)
                // закрываем документ
                try
                {
                    docRowsTableAdapter.CloseDoc(DocID, UserID);

                    // закрываем окно
                    //allowCloseWindow = true;
                    Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("REDFORM"))
                    {
                        FullScreenErrorForm errorForm = new FullScreenErrorForm(
                            String.Format(
                                "{0}",
                                ex.Message.Replace("REDFORM", "")),
                            "ПРОДОЛЖИТЬ (Enter)", Color.Red);
                        errorForm.TimeOut = 2000;
                        errorForm.ShowDialog();
                    }
                    else ShowError(ex);
                }

        }

        private void gvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // разрисовка строк в таблице, если не указана серия
            foreach (DataGridViewRow row in gvLines.Rows)
            {
                Data.Etic.DocRowsRow diffRow = (Data.Etic.DocRowsRow) ((DataRowView) row.DataBoundItem).Row;

                // простая разрисовка строк
                Color backColor = (diffRow.IsColorNull() || diffRow.Color.ToLower() == "white")
                                      ? Color.White
                                      : Color.FromName(diffRow.Color);
                for (int c = 0; c < row.Cells.Count; c++)
                    if (row.Cells[c] is DataGridViewDisableButtonCell)
                    {
                    }
                    else
                    {
                        row.Cells[c].Style.BackColor = backColor;
                        row.Cells[c].Style.SelectionForeColor = backColor;
                    }
            }
        }
    }
}
