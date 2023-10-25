using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Containers;
using WMSOffice.Dialogs.PickControl;

namespace WMSOffice.Window
{
    public partial class PickControlCheckWindow : GeneralWindow
    {
        public PickControlCheckWindow()
        {
            InitializeComponent();
            lblDocType.Text = lblDocNumber.Text = lblDocDate.Text = lblNumber.Text = lblDelivery.Text = lblDeliveryDate.Text =
    lblContainer.Text = lblDepartment.Text = lblRegim.Text = tbBarcode.Text = "";
        }

        private void PickControlCheckWindow_Load(object sender, EventArgs e)
        {
            // получаем информацию по номеру документа
            using (Data.PickControlTableAdapters.PickSlipInfoTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.PickSlipInfoTableAdapter())
            {
                try
                {
                    Data.PickControl.PickSlipInfoDataTable table = adapter.GetData(DocID);
                    if (table == null || table.Count != 1)
                        ShowError("Не найдена информация о документе!");
                    else
                    {
                        Data.PickControl.PickSlipInfoRow row = table[0];
                        lblDocType.Text = row.Doc_type;
                        lblDocNumber.Text = row.Doc_number.ToString();
                        lblDocDate.Text = row.Order_Date.ToShortDateString();
                        lblNumber.Text = row.PickSlip.ToString();
                        lblDelivery.Text = row.Delivery;
                        lblDeliveryDate.Text = row.Delivery_Date.ToShortDateString();
                        lblContainer.Text = row.Conteiner_id;
                        lblDepartment.Text = row.OtdelName;
                        lblRegim.Text = row.Delivery_Zone;
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
            docRowsWithDifferenceBindingSource.Filter = "";
            docRowsWithDifferenceBindingSource.Sort = "";
            docRowsWithDifferenceTableAdapter.Fill(pickControl.DocRowsWithDifference, DocID);
            //if (gvLines.Rows.Count > 0)
            //    gvLines.Rows[0].Selected = true;
        }

        private void gvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in gvLines.Rows)
            {
                Data.PickControl.DocRowsWithDifferenceRow diffRow = (Data.PickControl.DocRowsWithDifferenceRow)((DataRowView)row.DataBoundItem).Row;
                //if (diffRow.IsPSN_QtyNull() || diffRow.IsControl_QtyNull() || diffRow.PSN_Qty != diffRow.Control_Qty)
                //Color backColor = (diffRow.Error_Flag == 1) ? Color.Red : (diffRow.Error_Flag == 2) ? Color.Orange : Color.Gray;
                // 1 - излишек, 2 - недостача, 3 - пересортица
                Color backColor = (diffRow.Instruction_ID == 1) ? Color.FromArgb(178, 161, 199) : (diffRow.Instruction_ID == 2) ? Color.Red : (diffRow.Instruction_ID == 3) ? Color.Orange : Color.White;
                //if (diffRow.Error_Flag == 2) backColor = Color.Gray;
                if (diffRow.Error_Flag == 1)// || diffRow.Error_Flag == 2)
                {
                    // строка отличается - подсвечиваем красным
                    for (int c = 0; c < row.Cells.Count; c++)
                    {
                        row.Cells[c].Style.BackColor = backColor;
                        //row.Cells[c].Style.ForeColor = Color.White;
                    }
                }
            }
        }

        private void gvLines_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        private void gvLines_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && btnRepair.Enabled)
            {
                e.Handled = true;
                btnRepair_Click(sender, null);
            }
        }

        private void gvLines_SelectionChanged(object sender, EventArgs e)
        {
            if (gvLines.SelectedCells.Count == 1)
            {
                Data.PickControl.DocRowsWithDifferenceRow row = (Data.PickControl.DocRowsWithDifferenceRow)((DataRowView)gvLines.Rows[gvLines.SelectedCells[0].RowIndex].DataBoundItem).Row;
                btnRepair.Enabled = (row.Instruction_ID != 0); //= (row.Error_Flag == 1);
            }
            else btnRepair.Enabled = false;
        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvLines.SelectedCells.Count == 1)
                {
                    // находим строчку, которую собираемся исправлять
                    Data.PickControl.DocRowsWithDifferenceRow row = (Data.PickControl.DocRowsWithDifferenceRow)((DataRowView)gvLines.Rows[gvLines.SelectedCells[0].RowIndex].DataBoundItem).Row;

                    // показываем форму решения проблемы
                    RepairForm form = new RepairForm();
                    form.DocID = DocID;
                    form.LineID = row.Line_ID;
                    form.Instruction = row.Instruction;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // если удалось закрыть форму с значением OK, то виновные были назначены
                        // сохраняем результат исправления
                        docRowsWithDifferenceTableAdapter.SetErrorToLine(DocID, form.LineID, UserID, form.ControlerFault, form.PickerFault, form.OperatorFault);

                        // обновляем список строк документа
                        RefreshLines();
                    }
                }
            }
            catch (Exception ex) {
                ShowError(ex);
            }
        }

        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            try
            {
                using (Data.PickControlTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.QueriesTableAdapter())
                {
                    // закрываем документ
                    adapter.CloseErrorDoc(DocID);

                    // если все прошло успешно...
                    if ((lblDocType.Text == "40" || lblDocType.Text == "41")
                        && (lblContainer.Text == "A1" || lblContainer.Text == "A2" || lblContainer.Text == "A3"))
                    {
                        // ... и это межсклад, то спрашиваем штрих код пластикового ящика
                        ScanContainerForm form = new ScanContainerForm();
                        bool scanError = true;
                        while (scanError)
                        {
                            try
                            {
                                if (form.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(form.Barcode))
                                {
                                    adapter.InsertContainerToPS(DocID, form.Barcode);
                                    scanError = false;
                                }
                            }
                            catch (Exception exch)
                            {
                                ShowError(exch);
                                scanError = true;
                            }
                        }
                    } else
                    {
                        // ...спрашиваем количество этикеток (мест)
                        EticCountForm form = new EticCountForm();
                        form.Count = 1;
                        bool eticError = true;
                        while (eticError)
                        {
                            try
                            {
                                if (form.ShowDialog() == DialogResult.OK && form.Count >= 0)
                                {
                                    #region ВЫБОР ТИПА ТАРЫ ДЛЯ УПАКОВКИ

                                    int? boxType = 0; // тип тары

                                    Data.PickControl.PickContainerTypesDataTable containerTypes = null;
                                    using (var containerTypeAdapter = new Data.PickControlTableAdapters.PickContainerTypesTableAdapter())
                                        containerTypes = containerTypeAdapter.GetData(this.UserID, DocID);

                                    if (containerTypes != null && containerTypes.Rows.Count > 0)
                                    {
                                        var dlgSelectContainerType = new WMSOffice.Dialogs.RichListForm();
                                        dlgSelectContainerType.Text = "Выберите тип тары для упаковки";
                                        dlgSelectContainerType.AddColumn("Short_Value", "Short_Value", "Тип тары");
                                        dlgSelectContainerType.ColumnForFilters = new List<string>(new string[] { "Short_Value" });
                                        dlgSelectContainerType.FilterChangeLevel = 0;
                                        dlgSelectContainerType.DataSource = containerTypes;
                                        dlgSelectContainerType.DiscardCanceling = true;

                                        if (dlgSelectContainerType.ShowDialog() == DialogResult.OK)
                                            boxType = Convert.ToInt32((dlgSelectContainerType.SelectedRow as Data.PickControl.PickContainerTypesRow).Key);
                                    }

                                    #endregion

                                    adapter.PrintEtic(DocID, UserID, form.Count, System.Security.Principal.WindowsIdentity.GetCurrent().Name, boxType, (string)null, (string)null, (int?)null);
                                    eticError = false;
                                }
                                //else adapter.PrintEtic(DocID, UserID, 0, System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                            }
                            catch (Exception exch)
                            {
                                ShowError(exch);
                                eticError = true;
                            }
                        }
                    }

                    // если нет ошибки, закрываем это окно
                    Close();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }
    }
}
/*
if (gvLines.Rows.Count < 1)
                ShowError("Документ контроля сборки не содержит строк.\n\rТакой документ нельзя закрыть! Продолжайте работу.");
            else
            {
                using (Data.PickControlTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.QueriesTableAdapter())
                {
                    try
                    {
                        // закрываем документ по базе, если есть ошибки -- получим исключение, которое показываем пользователю
                        adapter.CloseDoc(DocID, UserID);

                        // если все прошло успешно, спрашиваем количество этикеток (мест)
                        EticCountForm form = new EticCountForm();
                        form.Count = 1;
                        if (form.ShowDialog() == DialogResult.OK && form.Count > 0)
                            adapter.PrintEtic(DocID, UserID, form.Count, System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                        else adapter.PrintEtic(DocID, UserID, 0, System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                    }
                    catch (Exception ex)
                    {
                        //if (ex.Message.Contains("SHOWDIFF"))
                        //{
                        //    // показываем расхождения в сборочном и контроле
                        //    CompareForm form = new CompareForm();
                        //    form.DocID = this.DocID;
                        //    form.ShowDialog();

                        //    // обновляем документ
                        //    UndoEnabled = false;
                        //    RefreshLines();
                        //} else 
                            ShowError(ex);
                    }

                    // закрываем окно
                    allowCloseWindow = true;
                    Close();
                }
            }*/