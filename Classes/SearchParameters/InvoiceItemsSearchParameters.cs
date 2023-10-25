using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Classes.SearchParameters
{
    /// <summary>
    /// Параметры поиска для загрузки списка товаров по накладной
    /// </summary>
    public class InvoiceItemsSearchParameters : SessionIDSearchParameters
    {
        /// <summary>
        /// Номер накладной
        /// </summary>
        public int InvoiceNumber { get; set; }

        /// <summary>
        /// Тип накладной
        /// </summary>
        public string InvoiceType { get; set; }

        /// <summary>
        /// Компания, которой принадлежит накладная (всегда по умолчанию '00001')
        /// </summary>
        public string KCOO { get; set; }

        /// <summary>
        /// Тип документа, для которого нужно найти товары
        /// </summary>
        public string DocType { get; set; }

        public InvoiceItemsSearchParameters()
        {
            KCOO = Constants.KCOO;
        }
    }
}
