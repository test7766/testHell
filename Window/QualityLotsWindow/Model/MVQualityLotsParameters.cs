using System;
using System.Collections.Generic;
using System.Text;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Window.QualityLotsWindow.Model
{

    /// модель Критериев поиска для остатков
    class MVQualityLotsParameters : SessionIDSearchParameters
    {
        public long? Session_ID { get; set; }
        public int? ItemID { get; set; }
        public string Lot_Number { get; set; }
        public string Vendor_Lot { get; set; }
        public string Warehouse_ID { get; set; }
        public bool AllRemains_LotNumber { get; set; } // нулевие остатки для партии
        public bool AllRemainsBatch { get; set; } // нулевие остатки для серии
        public DateTime Expiration_Date { get; set; }
      
    }
}
