using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// Класс, представляющий собой строку сборочного листа
    /// </summary>
    public class PickListRow
    {
        // ЗАКАЗ

        /// <summary>
        /// Компания
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Тип заказа
        /// </summary>
        public string DocumentType { get; set; }

        /// <summary>
        /// Номер заказа
        /// </summary>
        public int DocumentNumber { get; set; }
        
        // СБОРОЧНЫЙ ЛИСТ

        /// <summary>
        /// Номер сборочного
        /// </summary>
        public int PickSlipNumber { get; set; }

        // СТРОКА СБОРОЧНОГО

        /// <summary>
        /// Номер строки в заказе
        /// </summary>
        public int LineId { get; set; }

        /// <summary>
        /// Код товара
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// Производитель
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Серия
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Партия
        /// </summary>
        public string Lot { get; set; }

        /// <summary>
        /// Полка, место хранения
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Единица измерения
        /// </summary>
        public string UnitOfMeasure { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public int Quantity { get; set; }
    }
}
