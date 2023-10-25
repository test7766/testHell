using System;
using System.Collections.Generic;
using System.Text;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Data;
using WMSOffice.Window.QualityLotsWindow.Model;
using System.Xml;

namespace WMSOffice.Window.QualityLotsWindow.QualityLotsData
{
    public class MVQualityLotsView : IDataView
    {
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;
        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();
        public PatternColumnsCollection Columns
        {
            get { return this.dataColumns; }
        }

        private DataTable data;
        public DataTable Data
        {
            get { return this.data; }
        }


        public static void UpdateData(int SessionId, XmlDocument dataXmlDocument, DateTime? newExpiration_Date, string newWarehouse_ID) 
        {
            using (var adapter = new Data.WHTableAdapters.QL_Lot_Number_ListTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                adapter.UpdateData(SessionId, dataXmlDocument.InnerXml.ToString(), newExpiration_Date, newWarehouse_ID.ToString());
            }
        }

        

        //основное заполнение
        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as MVQualityLotsParameters;
            using (var adapter = new Data.WHTableAdapters.QL_Lot_Number_ListTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(searchCriteria.Session_ID,
                                        searchCriteria.ItemID, 
                                        searchCriteria.Lot_Number,
                                        searchCriteria.Vendor_Lot,
                                        searchCriteria.Warehouse_ID,
                                        searchCriteria.AllRemains_LotNumber,
                                        searchCriteria.AllRemainsBatch);
            }
        }

       

        public MVQualityLotsView()
        {
            this.dataColumns.Add(new SelectorPatternColumn(" ", "IsChecked", new FilterBoolCompareExpressionRule("IsChecked"), SummaryCalculationType.Custom) { Width = 35 });
            this.dataColumns.Add(new PatternColumn("Код товару", "Item_ID", new FilterCompareExpressionRule<Int32>("Item_ID"), SummaryCalculationType.Count) { Width = 50});
            this.dataColumns.Add(new PatternColumn("Назва товару", "Item_Name", new FilterPatternExpressionRule("Item_Name")) { Width = 200});
            this.dataColumns.Add(new PatternColumn("Серія постачальника", "Vendor_Lot", new FilterPatternExpressionRule("Vendor_Lot")) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Партія товару", "Lot_Number", new FilterPatternExpressionRule("Lot_Number")) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Термін придатності", "Expiration_Date", new FilterDateCompareExpressionRule("Expiration_Date")) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Блок", "BL_Type", new FilterPatternExpressionRule("BL_Type")) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Код філіалу", "Warehouse_ID", new FilterPatternExpressionRule("Warehouse_ID")) { Width = 50});
            this.dataColumns.Add(new PatternColumn("Кількість наявна", "Quantity", new FilterCompareExpressionRule<Int32>("Quantity")) { Width = 100, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Кількість доступна", "Available_Quantity", new FilterCompareExpressionRule<Int32>("Available_Quantity")) { Width = 100, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Код поставщ.", "Vendor_ID", new FilterCompareExpressionRule<Int32>("Vendor_ID")) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Назва постачальника", "Vendor_Name", new FilterPatternExpressionRule("Vendor_Name")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Код виробника", "Manufacturer_ID", new FilterCompareExpressionRule<Int32>("Manufacturer_ID")) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Виробник", "Manufacturer_Name", new FilterPatternExpressionRule("Manufacturer_Name")) { Width = 508 });
            this.dataColumns.Add(new PatternColumn("Номер замовлення", "Order_ID", new FilterCompareExpressionRule<Int32>("Order_ID"), SummaryCalculationType.Count) { Width = 50});
            this.dataColumns.Add(new PatternColumn("Тип замовлення", "Order_Type", new FilterPatternExpressionRule("Order_Type"), SummaryCalculationType.Count) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Номер накл. ОФ", "Invoice_ID", new FilterCompareExpressionRule<Int32>("Invoice_ID")) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Дата отримання", "Receipt_Date", new FilterDateCompareExpressionRule("Receipt_Date")) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Вхідний контроль", "Entrance_Control", new FilterPatternExpressionRule("Entrance_Control")) { Width = 20 });
            this.dataColumns.Add(new PatternColumn("Ставка ПДВ", "TAX", new FilterPatternExpressionRule("TAX")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Форма зберігання", "DRDL01", new FilterPatternExpressionRule("DRDL01")) { Width = 200 });
        }


     
    }
}
