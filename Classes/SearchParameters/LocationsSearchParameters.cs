using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Classes.SearchParameters
{
    /// <summary>
    /// Параметры загрузки полок
    /// </summary>
    public class LocationsSearchParameters : SessionIDSearchParameters
    {
        /// <summary>
        /// Идентификатор документа, для которого загружаются полки, либо NULL если фильтр не задан
        /// </summary>
        public long? DocID { get; set; }

        /// <summary>
        /// Идентификатор товара, для которого загружаются полки, либо NULL если фильтр не задан
        /// </summary>
        public long? ItemID { get; set; }

        /// <summary>
        /// Фильтр для полок (их очень много, поэтому желательно их фильтровать при загрузке)
        /// </summary>
        public string Filter { get; set; }
    }
}
