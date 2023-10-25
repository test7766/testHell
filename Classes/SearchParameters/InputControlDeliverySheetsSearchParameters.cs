using System;
using System.Text;

using WMSOffice.Classes;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Classes.SearchParameters
{
    /// <summary>
    /// Параметры получения анкет входного контроля поставки
    /// </summary>
    public class InputControlDeliverySheetsSearchParameters : SessionIDSearchParameters
    {
        /// <summary>
        /// True если нужно загружать только последние версии анкет, False если нет
        /// </summary>
        public bool OnlyActual { get; set; }

        /// <summary>
        /// Фильтр - номер поставки или null, если по номеру поставки фильтровать не нужно
        /// </summary>
        public long? DeliveryNumber { get; set; }

        /// <summary>
        /// Фильтр - номер заказа или null, если по номеру заказа фильтровать не нужно
        /// </summary>
        public long? OrderNumber { get; set; }

        /// <summary>
        /// Фильтр - код поставщика или null, если по коду поставщика фильтровать не нужно
        /// </summary>
        public long? VendorID { get; set; }

        /// <summary>
        /// Название поставщика (в фильтрации не участвует, нужно чтобы отображать его на формах)
        /// </summary>
        public string VendorName { get; set; }

        /// <summary>
        /// Фильтр - дата с или null, если по дате анкеты фильтровать не нужно
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Фильтр - дата по или null, если по дате анкеты фильтровать не нужно
        /// </summary>
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// Код провизора или null, если по провизору фильтровать не нужно
        /// </summary>
        public long? ProvisorID { get; set; }

        /// <summary>
        /// True если нужно загружать анкеты со статусом "Новая"
        /// </summary>
        public bool IncludeNew { get; set; }

        /// <summary>
        /// True если нужно загружать анкеты со статусом "В работе"
        /// </summary>
        public bool IncludeInWork { get; set; }

        /// <summary>
        /// True если нужно загружать анкеты со статусом "Пройдена успешно"
        /// </summary>
        public bool IncludeAccepted { get; set; }

        /// <summary>
        /// True если нужно загружать анкеты со статусом "Сомнительного качества"
        /// </summary>
        public bool IncludeWithSuspectedQuality { get; set; }

        /// <summary>
        /// True если нужно загружать анкеты со статусом "Не пройдена"
        /// </summary>
        public bool IncludeNotAccepted { get; set; }

        /// <summary>
        /// True если нужно загружать только подтвержденные анкеты
        /// </summary>
        public bool IncludeOnlyApproved { get; set; }

        /// <summary>
        /// Список разрешенных статусов через запятую
        /// </summary>
        public string FilterByStatus
        {
            get
            {
                var s = new StringBuilder();
                if (IncludeNew)
                    s.Append(Constants.QK_IC_STATUS_NEW);
                if (IncludeInWork)
                {
                    if (s.Length > 0)
                        s.Append(",");
                    s.Append(Constants.QK_IC_STATUS_IN_WORK);
                }
                if (IncludeAccepted)
                {
                    if (s.Length > 0)
                        s.Append(",");
                    s.Append(Constants.QK_IC_STATUS_ACCEPTED);
                }
                if (IncludeWithSuspectedQuality)
                {
                    if (s.Length > 0)
                        s.Append(",");
                    s.Append(Constants.QK_IC_STATUS_WITH_SUSPECTED_QUALITY);
                }
                if (IncludeNotAccepted)
                {
                    if (s.Length > 0)
                        s.Append(",");
                    s.Append(Constants.QK_IC_STATUS_NOT_ACCEPTED);
                }

                return s.ToString();
            }
        }

        public InputControlDeliverySheetsSearchParameters()
        {
            OnlyActual = IncludeNew = IncludeInWork = true;
            DeliveryNumber = OrderNumber = VendorID = ProvisorID = null;
            DateFrom = DateTo = null;
            IncludeOnlyApproved = false;
        }
    }
}
