using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Windows.Forms;
using WMSOffice.Controls;
using System.Data;
using WMSOffice.Window.QualityLotsWindow.Model;
using WMSOffice.Window.QualityLotsWindow.QualityLotsData;
using System.Xml;
using WMSOffice.Data;
using System.Reflection;
using System.Threading;
using WMSOffice.Dialogs.Quality;

namespace WMSOffice.Window.QualityLotsWindow
{
    public partial class QualityLotsWindow : GeneralWindow
    {
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();
        public QualityLotsWindow()
        {
            InitializeComponent();

        }


        private void SetOperationAccess()
        {
            var isExportEnabled = xdgvQualityLots.HasRows;
            btnExportToExcel.Enabled = isExportEnabled;

            var selectedRows = xdgvQualityLots.DataView.Data == null ? new DataRow[0] : xdgvQualityLots.DataView.Data.Select(string.Format("{0} = '{1}'", "IsChecked", true));
            var isEdiitLotEnabled = selectedRows.Length > 0;
            btnEditLot.Enabled = isEdiitLotEnabled;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();


        }



        private void Initialize()
        {

            //справочник скдад (onleft event)
            stbWarehouse_ID.ValueReferenceQuery = "[dbo].[pr_QL_Get_Warehouses]";
            stbWarehouse_ID.UserID = this.UserID;
            stbWarehouse_ID.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stb_OnVerifyValue);
            //  stbWarehouse_ID.SetFirstValueByDefault();
            stbWarehouse_ID.SetValueByDefault(string.Empty);



            //пошук по назві
            stbItemID.ValueReferenceQuery = "[dbo].[pr_QL_Search_Items]";
            stbItemID.ApplyAdditionalParameter("Item_Name", string.Empty);
            stbItemID.UserID = this.UserID;
            stbItemID.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stb_OnVerifyValue);
            stbItemID.SetValueByDefault(string.Empty);



 

            //справочник партія Lot_Number
            stbLot_Number.ValueReferenceQuery = "[dbo].[pr_QL_Get_Lot_Numbers]";
            stbLot_Number.ApplyAdditionalParameter("Item_ID", string.Empty);
            stbLot_Number.UserID = this.UserID;
            stbLot_Number.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stb_OnVerifyValue);
            stbLot_Number.SetValueByDefault(string.Empty);





            //справочник серія  Vendor_lot
            stbVendor_Lot.ValueReferenceQuery = "[dbo].[pr_QL_Get_Vendor_Lots]";
            stbVendor_Lot.ApplyAdditionalParameter("Item_ID", string.Empty);
            stbVendor_Lot.UserID = this.UserID;
            stbVendor_Lot.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stb_OnVerifyValue);
            stbVendor_Lot.SetValueByDefault(string.Empty);





            xdgvQualityLots.AllowSummary = false;
            xdgvQualityLots.AllowRangeColumns = true;
            xdgvQualityLots.UseMultiSelectMode = false;

            xdgvQualityLots.Init(new MVQualityLotsView(), true);
            xdgvQualityLots.LoadExtraDataGridViewSettings(string.Format("{0}_{1}", this.Name, xdgvQualityLots.Name));


            xdgvQualityLots.UserID = this.UserID;

            xdgvQualityLots.OnDataError += new DataGridViewDataErrorEventHandler(xdgvQualityLots_OnDataError); //error
            xdgvQualityLots.OnFilterChanged += new EventHandler(xdgvQualityLots_OnFilterChanged);

            xdgvQualityLots.OnCellContentClick += new DataGridViewCellEventHandler(xdgvQualityLots_OnCellContentClick);

            xdgvQualityLots.OnMultiRowsSelectionChanged += new EventHandler<DataGridViewCheckBoxHeaderCellEventArgs>(xdgvQualityLots_OnMultiRowsSelectionChanged);

            xdgvQualityLots.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvQualityLots_OnFormattingCell);


            xdgvQualityLots.OnCustomSummaryCalculation += new EventHandler<СustomSummaryCalculationEventArgs>(xdgvQualityLots_OnСustomSummaryCalculation);



            //pagin
            xdgvQualityLots.CreatePageNavigator();

            SetOperationAccess();
        }


        void stb_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {

            var control = sender as SearchTextBox;
            TextBox tbDescription = null;
            //SearchTextBox s = null;

            if (control == stbItemID)
            {
                tbDescription = tbItemID;

            }
            else if (control == stbLot_Number)
                tbDescription = tbLot_Number;
            else if (control == stbVendor_Lot)
                tbDescription = tbVendor_Lot;
            else if (control == stbWarehouse_ID)
                tbDescription = tbWarehouse_ID;            
            else if (control == stbVendor_Lot)
            {
                tbDescription = tbVendor_Lot; //серий
            }

            else if (control == stbLot_Number) 
            {
                tbDescription = tbLot_Number; //партия
          
            }
                



            ///------------------------------------------------------///


            if (tbDescription != null)
            {
                tbDescription.Text = e.Success ? e.Description : "ЗНАЧЕННЯ НЕ ЗНАЙДЕНО!";
                tbDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                // Зачистка "быстрого" фильтра товара



                if (control == stbItemID)
                {
                    stbLot_Number.ApplyAdditionalParameter("Item_ID", e.Value); //партия
                    stbVendor_Lot.ApplyAdditionalParameter("Item_ID", e.Value);  //серий

                    if (e.Success && string.IsNullOrEmpty(e.Value)) 
                    {
                        tbQFilterItem.Clear();
                    }
                       
                }
                if (e.Success)
                {
                    control.Value = e.Value;
                }
            }
        }


        private void cbAllRemainsLotNumber_CheckedChanged(object sender, EventArgs e)
        {
            stbLot_Number.ApplyAdditionalParameter("cbAllRemainsLotNumber", cbAllRemainsLotNumber.Checked); //нулевие остатки партия
        }


        private void cbAllRemainsVendorLot_CheckedChanged(object sender, EventArgs e)
        {
            stbVendor_Lot.ApplyAdditionalParameter("cbAllRemainsBatch", cbAllRemainsBatch.Checked);  // нулевие остатки серий
        }






        private void tbQFilterItem_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbQFilterItem_Leave(sender, EventArgs.Empty);
        }
        private void tbQFilterItem_Leave(object sender, EventArgs e)
        {
            stbItemID.ApplyAdditionalParameter("Item_Name", tbQFilterItem.Text);
            if (!string.IsNullOrEmpty(tbQFilterItem.Text.Trim()) && tbQFilterItem.Text.Trim().Length >= 3)
                stbItemID.VerifyValue(true, AutoSelectItemSideMode.None);

        }



        void xdgvQualityLots_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvQualityLots_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvQualityLots.RecalculateSummary();
            SetOperationAccess();
        }


        void xdgvQualityLots_OnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (xdgvQualityLots.DataGrid.Columns[e.ColumnIndex].DataPropertyName == "IsChecked")
                {
                    var row = (xdgvQualityLots.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                    var keyValue = row["Row_Number"];

                    var isChecked = Convert.ToBoolean(row["IsChecked"]);

                    if (this.xdgvQualityLots.ChangeRowPropertyValue("Row_Number", keyValue, "IsChecked", !isChecked))
                    {
                        row["IsChecked"] = !isChecked;
                        this.xdgvQualityLots.RecalculateSummary();

                        SetOperationAccess();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnEditLot_Click(object sender, EventArgs e)
        {

            QualityLotsEditorForm _qualityLotsEditorForm = new QualityLotsEditorForm();
            var selectedRows = xdgvQualityLots.DataView.Data.Select(string.Format("{0} = '{1}'", "IsChecked", true));

            var dialogResult = _qualityLotsEditorForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {

                var resultXml = CreateOrderXML(selectedRows);
             //   MVQualityLotsView.UpdateData(this.UserID, resultXml, _qualityLotsEditorForm.ExpDate, _qualityLotsEditorForm.LotNumber.Text);
                ReloadData();

            }  
        }




        private XmlDocument CreateOrderXML(DataRow[] selectedLines)
        {
            XmlDocument xDoc = new XmlDocument();

            XmlElement xRoot = xDoc.CreateElement("Lines");
            foreach (Data.WH.QL_Lot_Number_ListRow line in selectedLines)
            {
                XmlElement xLineElement = xDoc.CreateElement("Line");

                XmlElement xValue = xDoc.CreateElement("Item_ID");
                xValue.InnerText = line.IsNull("Item_ID") ? string.Empty : line["Item_ID"].ToString();
                xLineElement.AppendChild(xValue);

                xValue = xDoc.CreateElement("Vendor_Lot");
                xValue.InnerText = line.IsNull("Vendor_ID") ? string.Empty : line["Vendor_Lot"].ToString();
                xLineElement.AppendChild(xValue);

                xValue = xDoc.CreateElement("Lot_Number");
                xValue.InnerText = line.IsNull("Lot_Number") ? string.Empty : line["Lot_Number"].ToString();
                xLineElement.AppendChild(xValue);

                xValue = xDoc.CreateElement("Expiration_Date");
                xValue.InnerText = line.IsNull("Expiration_Date") ? string.Empty : ((DateTime)line["Expiration_Date"]).ToString("yyyy-MM-dd");
                xLineElement.AppendChild(xValue);

                xValue = xDoc.CreateElement("Warehouse_ID");
                xValue.InnerText = line.IsNull("Warehouse_ID") ? string.Empty : line["Warehouse_ID"].ToString();
                xLineElement.AppendChild(xValue);

                xRoot.AppendChild(xLineElement);
            }

            xDoc.AppendChild(xRoot);

            return xDoc;
        }




        #region несколько_Отмеченних_chekbox
        void xdgvQualityLots_OnMultiRowsSelectionChanged(object sender, DataGridViewCheckBoxHeaderCellEventArgs e)
        {
            var isEnabled = this.xdgvQualityLots != null;
            btnExportToExcel.Enabled = isEnabled;


            try
            {
                if (this.xdgvQualityLots.ChangeMultipleRowsPropertyValue("IsChecked", e.Checked))
                {
                    foreach (DataGridViewRow dgRow in xdgvQualityLots.DataGrid.Rows)
                    {
                        var row = (dgRow.DataBoundItem as DataRowView).Row;
                        row["IsChecked"] = e.Checked;
                    }

                    this.xdgvQualityLots.RecalculateSummary();

                    SetOperationAccess();
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Раскраска_отмеченних_chekbox
        void xdgvQualityLots_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                // Раскраска
                bool isChecked = Convert.ToBoolean(this.xdgvQualityLots.DataGrid.Rows[e.RowIndex].Cells[0].Value);
                this.xdgvQualityLots.DataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                this.xdgvQualityLots.DataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion



        #region Калькуляция_Строк_внизу
        void xdgvQualityLots_OnСustomSummaryCalculation(object sender, СustomSummaryCalculationEventArgs e)
        {
            try
            {
                if (e.PatternСolumn.DataFieldName == "IsChecked")
                {
                    var cntCheckedRows = 0;
                    foreach (DataRow dataRow in e.FilteredFullDataRows)
                    {
                        if (dataRow["IsChecked"].Equals(true))
                            cntCheckedRows++;
                    }

                    e.TargetCell.Value = cntCheckedRows;
                    e.TargetCell.Style.BackColor = e.TargetCell.Style.SelectionBackColor = cntCheckedRows > 0 ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    e.TargetCell.Style.ForeColor = e.TargetCell.Style.SelectionForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {

            }
        }


        #endregion



        private void tbCheckIsDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //// Разрешить ввод только цифр, знака минус и управляющих символов (например, Backspace).
            //if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            //{
            //    e.Handled = true; // Отклонить ввод, если символ не является разрешенным.
            //}

            //// Проверить, что знак минус находится только в начале строки и только один раз.
            //if (e.KeyChar == '-' && ((sender as TextBox).Text.Contains("-") || (sender as TextBox).SelectionStart != 0))
            //{
            //    e.Handled = true; // Отклонить знак минус, если он уже присутствует или не находится в начале строки.
            //}
        }




        private void btnLoadDataQualityLots_Click(object sender, EventArgs e)
        {
            ReloadData();
        }





        private MVQualityLotsParameters CreateQualityLotsCriteria()
        {
            var searchQualityLotsCriteria = new MVQualityLotsParameters() { Session_ID = this.UserID };

            
            if (!string.IsNullOrEmpty(stbItemID.Value))
            {
               
                int stbItemIDDAta = 0;
                if (!int.TryParse(stbItemID.Value, out stbItemIDDAta))
                {
                    throw new Exception("Код товару повина бути числом.");

                }
                else 
                {
                    searchQualityLotsCriteria.ItemID = stbItemIDDAta;
                }
              
            }
     


            if (!string.IsNullOrEmpty(stbLot_Number.Value))
                searchQualityLotsCriteria.Lot_Number = (!string.IsNullOrEmpty(stbLot_Number.Value)) ? stbLot_Number.Value : null;   //проверка партий



            if (!string.IsNullOrEmpty(stbVendor_Lot.Value))
                searchQualityLotsCriteria.Vendor_Lot = (!string.IsNullOrEmpty(stbVendor_Lot.Value)) ? stbVendor_Lot.Value : null; //проверка серий


            if (!string.IsNullOrEmpty(stbWarehouse_ID.Value))
                searchQualityLotsCriteria.Warehouse_ID = stbWarehouse_ID.Value;




            searchQualityLotsCriteria.AllRemains_LotNumber = cbAllRemainsLotNumber.Checked;
            searchQualityLotsCriteria.AllRemainsBatch = cbAllRemainsBatch.Checked;

            return searchQualityLotsCriteria;
        }


        static MVQualityLotsParameters searchCriteria;
        private void ReloadData()
        {

            try
            {
                 searchCriteria = this.CreateQualityLotsCriteria();
                LoadQualityLots(searchCriteria);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }



        private void LoadQualityLots(MVQualityLotsParameters _mVQualityLotsParameters)
        {
            try
            {
                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvQualityLots.DataView.FillData(e.Argument as MVQualityLotsParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        this.xdgvQualityLots.BindData(false);
                        this.xdgvQualityLots.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Виконується отримання списку довідника партій товару...";
                bw.RunWorkerAsync(_mVQualityLotsParameters);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            SetOperationAccess();
        }






        #region EXPORT_EXEL
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportData();
        }
        private void ExportData()
        {
            try
            {
               var grid = xdgvQualityLots.DataView.Data.Select();


               xdgvQualityLots.ExportToExcelIsChecked("Экспорт довідника партій товару в Excel", "Довідник партій товару", true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
        #endregion




        //перетаскивания колонок
        private void QualityLotsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            xdgvQualityLots.SaveExtraDataGridViewSettings(string.Format("{0}_{1}", this.Name, xdgvQualityLots.Name));
        }

        private void stbLot_Number_Leave(object sender, EventArgs e)
        {

        }

      



    }


}
