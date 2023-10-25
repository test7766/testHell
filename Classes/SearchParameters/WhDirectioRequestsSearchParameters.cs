using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Classes.SearchParameters
{
    public class WhDirectioRequestsSearchParameters : SessionIDSearchParameters
    {
        /// <summary>
        /// True если надо получить все заявки, False если только нераспечатанные
        /// </summary>
        public bool All { get; set; }

        /// <summary>
        /// Тип фильтра
        /// </summary>
        public int? FilterTypeID { get; set; } 
    }
}
