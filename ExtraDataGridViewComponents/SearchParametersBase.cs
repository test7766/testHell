using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Controls.ExtraDataGridViewComponents
{
    public abstract class SearchParametersBase
    {

    }

    /// <summary>
    /// Класс параметров поиска, в котором задана сессия пользователя
    /// </summary>
    public class SessionIDSearchParameters : SearchParametersBase
    {
        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        public long SessionID { get; set; }
    }

    /// <summary>
    /// Класс параметров поиска, в котором заданы фильтры по товару для какой-нибудь сущности
    /// </summary>
    public class ItemSearchParameters : SessionIDSearchParameters
    {
        /// <summary>
        /// Фильтр - Код товара, либо null если этот фильтр не установлен
        /// </summary>
        public int? ItemID { get; set; }

        /// <summary>
        /// Фильтр - Серия товара, либо null если этот фильтр не установлен
        /// </summary>
        public string VendorLot { get; set; }

        /// <summary>
        /// Фильтр - Партия товара, либо null если этот фильтр не установлен
        /// </summary>
        public string BatchID { get; set; }

        /// <summary>
        /// Фильтр - идентификатор документа-сущности, либо null если этот фильтр не установлен
        /// </summary>
        public int? DocID { get; set; }
    }
}
