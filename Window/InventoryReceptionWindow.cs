using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.Inventory;

namespace WMSOffice.Window
{
    public partial class InventoryReceptionWindow : GeneralWindow
    {
        public InventoryReceptionWindow()
        {
            InitializeComponent();
        }

        private void InventoryReceptionWindow_Load(object sender, EventArgs e)
        {
            RefreshCalcs();
        }

        private void RefreshCalcs()
        {
            inventoryAutoCalcsTableAdapter.Fill(inventory.InventoryAutoCalcs, UserID);
        }

        private void RefreshCountSheets()
        {
            if (gvCalcs.SelectedRows.Count == 1)
            {
                WMSOffice.Data.Inventory.InventoryAutoCalcsRow ivRow = (WMSOffice.Data.Inventory.InventoryAutoCalcsRow)((DataRowView)gvCalcs.SelectedRows[0].DataBoundItem).Row;
                iV_CountSheetsTableAdapter.FillNonClosed(inventory.IV_CountSheets, ivRow.Doc_ID, ivRow.Calc_ID, UserID);
            }
            else inventory.IV_CountSheets.Clear();
            RefreshProgress();
        }

        private void RefreshProgress()
        {
            try
            {
                if (gvCalcs.SelectedRows.Count == 1)
                {
                    WMSOffice.Data.Inventory.InventoryAutoCalcsRow ivRow = (WMSOffice.Data.Inventory.InventoryAutoCalcsRow)((DataRowView)gvCalcs.SelectedRows[0].DataBoundItem).Row;
                    using (Data.InventoryTableAdapters.CalcProgressTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.CalcProgressTableAdapter())
                    {
                        Data.Inventory.CalcProgressDataTable table = adapter.GetData((int)ivRow.Doc_ID, ivRow.Calc_ID);
                        if (table.Count == 1)
                        {
                            lblTotalJDE.Text = table[0].jde.ToString("# ##0");
                            lblTotalWMS.Text = table[0].wms.ToString("# ##0");
                            lblTotalProgress.Text = table[0].prc.ToString("# ##0.00%");
                        }
                        else lblTotalJDE.Text = lblTotalWMS.Text = lblTotalProgress.Text = "";
                    }
                }
                else lblTotalJDE.Text = lblTotalWMS.Text = lblTotalProgress.Text = "";
            }
            catch (Exception ex)
            {
                lblTotalJDE.Text = lblTotalWMS.Text = lblTotalProgress.Text = "";
                ShowError(ex);
            }
        }

        private void miRefresh_Click(object sender, EventArgs e)
        {
            RefreshCalcs();
        }

        private void gvCalcs_SelectionChanged(object sender, EventArgs e)
        {
            RefreshCountSheets();
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (gvCalcs.SelectedRows.Count == 1)
            try
            {
                WMSOffice.Data.Inventory.InventoryAutoCalcsRow ivRow = (WMSOffice.Data.Inventory.InventoryAutoCalcsRow)((DataRowView)gvCalcs.SelectedRows[0].DataBoundItem).Row;
                try
                {
                    iV_CountSheetsTableAdapter.ScanOnReception(ivRow.Doc_ID, ivRow.Calc_ID, tbBarcode.Text, UserID, null);
                }
                catch (Exception ex)
                {
                    if (ex.Message == "NOEMPLOYEE")
                    {
                        ScanEmployeeForm form = new ScanEmployeeForm();
                        if (form.ShowDialog() == DialogResult.OK)
                            iV_CountSheetsTableAdapter.ScanOnReception(ivRow.Doc_ID, ivRow.Calc_ID, tbBarcode.Text, UserID, form.EmployeeID);                            
                    }
                    else throw;
                }
                RefreshCountSheets();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            tbBarcode.Text = "";
        }

        private void miRefreshCS_Click(object sender, EventArgs e)
        {
            RefreshCountSheets();            
        }

        private void miPrintCS_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvCountSheets.SelectedRows.Count == 1)
                {
                    WMSOffice.Data.Inventory.IV_CountSheetsRow csRow = (WMSOffice.Data.Inventory.IV_CountSheetsRow)((DataRowView)gvCountSheets.SelectedRows[0].DataBoundItem).Row;

                    if (csRow.Status_ID == "160")
                    {
                        #region // печать счетного листа
                        // получение заголовка счетного листа
                        using (Data.InventoryTableAdapters.IV_CS_HeaderTableAdapter hAdapter = new WMSOffice.Data.InventoryTableAdapters.IV_CS_HeaderTableAdapter())
                        {
                            hAdapter.Fill(inventory.IV_CS_Header, csRow.CS_ID, csRow.Bar_Code, UserID);
                        }

                        // подготовка данных для листа размещения
                        InventoryControlWindow.CountSheetReportPrepare(inventory, csRow.CS_ID);

                        if (inventory.IV_CS_Print.Count < 1)
                            throw new Exception("Не удалось получить данные Счетного листа.");

                        // напечатаем заполненный Счетный лист
                        Reports.InventoryIVCountSheetReport report = new Reports.InventoryIVCountSheetReport();
                        InventoryControlWindow.BarcodePrepare(inventory.IV_CS_Header, csRow.CS_ID);

                        report.SetDataSource((DataSet)inventory);
                        //report.ParameterFields["firstPrint"].CurrentValues .Add("firstPrint", CrystalDecisions.Shared.ParameterValueKind.BooleanParameter, CrystalDecisions.Shared.DiscreteOrRangeKind.DiscreteValue);

                        ReportForm form = new ReportForm();
                        form.ReportDocument = report;
                        //form.Print();
                        form.ShowDialog();
                        #endregion
                    }
                    else MessageBox.Show("Счетный лист еще не печатался! Разрешается только повторная печать.", "Запрещенная команда", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else MessageBox.Show("Вы не выбрали счетный лист!", "Печать счетного листа", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            tbSearch.BackColor = (String.IsNullOrEmpty(tbSearch.Text)) ? SystemColors.Window : SystemColors.Info;
            iVCountSheetsBindingSource.Filter = (String.IsNullOrEmpty(tbSearch.Text)) ? "" :
                String.Format("Bar_Code like '%{0}%'", tbSearch.Text);
        }

        private void miViewLog_Click(object sender, EventArgs e)
        {
            // показываем лог перехода Счетного листа по статусам
            if (gvCountSheets.SelectedRows.Count == 1)
            {
                WMSOffice.Data.Inventory.IV_CountSheetsRow csRow = (WMSOffice.Data.Inventory.IV_CountSheetsRow)((DataRowView)gvCountSheets.SelectedRows[0].DataBoundItem).Row;
                Dialogs.Inventory.CountSheetLogForm form = new WMSOffice.Dialogs.Inventory.CountSheetLogForm();
                form.CS_ID = csRow.CS_ID;
                form.ShowDialog();
            }
        }

        private void gvCountSheets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // действие по умолчанию - показать лог перехода по статусам
            miViewLog_Click(sender, null);
        }

    }
}
