using System;

using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Classes.SearchParameters
{
    /// <summary>
    /// Параметры получения списка заявок
    /// </summary>
    public class QualityRequestSearchParameters : ItemSearchParameters
    {
        /// <summary>
        /// True если нужно включать архивные заявки, False если нельзя
        /// </summary>
        public bool IncludeArchivedDocs { get; set; }

        /// <summary>
        /// Часть наименования товара
        /// </summary>
        public string ItemNamePart { get; set; }

        /// <summary>
        /// Код документа
        /// </summary>
        public string DocCode { get; set; }

        /// <summary>
        /// Период с
        /// </summary>
        public DateTime? PeriodFrom { get; set; }

        /// <summary>
        /// Период по
        /// </summary>
        public DateTime? PeriodTo { get; set; }

        /// <summary>
        /// Проверка, правильно ли заданы параметры
        /// </summary>
        /// <returns>Сообщение о неточности либо ошибке (если они есть),
        /// Пустая строка если все параметры заданы правильно</returns>
        public string CheckParametersCorrectness()
        {
            if (IncludeArchivedDocs && !DocID.HasValue && !ItemID.HasValue &&
                String.IsNullOrEmpty(ItemNamePart) && String.IsNullOrEmpty(VendorLot) && String.IsNullOrEmpty(BatchID) && !PeriodFrom.HasValue && !PeriodTo.HasValue)
                return "Если в поиск включены архивные заявки, то нужно задать еще один из фильтров, т.к. без фильтров будет слишком много записей!";
            else
                return String.Empty;
        }
    }
}
