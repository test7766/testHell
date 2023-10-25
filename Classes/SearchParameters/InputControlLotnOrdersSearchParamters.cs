using System;
using System.Text;

using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Classes.SearchParameters
{
    /// <summary>
    /// Параметры загрузки списка заказов на закупку (в рамках проведения входного контроля партии)
    /// </summary>
    public class InputControlLotnOrdersSearchParamters : SessionIDSearchParameters
    {
        /// <summary>
        /// True если нужно загружать только последние версии анкет, False если нет
        /// </summary>
        public bool OnlyActual { get; set; }

        /// <summary>
        /// Фильтр - код товара или null, если по коду товара фильтровать не нужно
        /// </summary>
        public long? ItemID { get; set; }

        /// <summary>
        /// Название товара (в фильтрации не участвует, нужно чтобы отображать его на формах)
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Фильтр по партии или null, если по партии фильтровать не нужно
        /// </summary>
        public string LotNumber { get; set; }

        /// <summary>
        /// Фильтр - код поставщика или null, если по коду поставщика фильтровать не нужно
        /// </summary>
        public long? VendorID { get; set; }

        /// <summary>
        /// Название поставщика (в фильтрации не участвует, нужно чтобы отображать его на формах)
        /// </summary>
        public string VendorName { get; set; }

        /// <summary>
        /// Фильтр - код производителя или null, если по коду производителя фильтровать не нужно
        /// </summary>
        public long? ManufacturerID { get; set; }

        /// <summary>
        /// Название производителя (в фильтрации не участвует, нужно чтобы отображать его на формах)
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// True если нужно искать в заказах со статусом "Новый"
        /// </summary>
        public bool OrderIncludeNew { get; set; }

        /// <summary>
        /// True если нужно искать в заказах со статусом "В работе"
        /// </summary>
        public bool OrderIncludeInWork { get; set; }

        /// <summary>
        /// True если нужно искать в заказах со статусом "Обработан успешно"
        /// </summary>
        public bool OrderIncludeAccepted { get; set; }

        /// <summary>
        /// True если нужно искать в заказах со статусом "Обработан неуспешно"
        /// </summary>
        public bool OrderIncludeNotAccepted { get; set; }

        /// <summary>
        /// True если нужно искать в заказах со статусом "Ввод данных сертификата"
        /// </summary>
        public bool OrderIncludeCertDataInput { get; set; }

        /// <summary>
        /// Список разрешенных статусов заказов через запятую
        /// </summary>
        public string FilterByOrderStatus
        {
            get
            {
                var s = new StringBuilder();
                if (IncludeNew)
                    s.Append(Constants.QK_IC_STATUS_NEW);
                if (OrderIncludeInWork)
                {
                    if (s.Length > 0)
                        s.Append(",");
                    s.Append(Constants.QK_IC_STATUS_IN_WORK);
                }
                if (OrderIncludeAccepted)
                {
                    if (s.Length > 0)
                        s.Append(",");
                    s.Append(Constants.QK_IC_STATUS_ACCEPTED);
                }
                if (OrderIncludeNotAccepted)
                {
                    if (s.Length > 0)
                        s.Append(",");
                    s.Append(Constants.QK_IC_STATUS_NOT_ACCEPTED);
                }

                if (OrderIncludeCertDataInput)
                {
                    if (s.Length > 0)
                        s.Append(",");
                    s.Append(Constants.QK_IC_STATUS_CERT_DATA_INPUT);
                }

                return s.ToString();
            }
        }

        /// <summary>
        /// True если нужно загружать заказы со статусом "Новый"
        /// </summary>
        public bool IncludeNew { get; set; }

        /// <summary>
        /// True если нужно загружать заказы со статусом "В работе"
        /// </summary>
        public bool IncludeInWork { get; set; }

        /// <summary>
        /// True если нужно загружать заказы со статусом "Обработан успешно"
        /// </summary>
        public bool IncludeAccepted { get; set; }

        /// <summary>
        /// True если нужно загружать заказы со статусом "Обработан неуспешно"
        /// </summary>
        public bool IncludeNotAccepted { get; set; }

        /// <summary>
        /// True если нужно загружать заказы со статусом "Ввод данных сертификата"
        /// </summary>
        public bool IncludeCertDataInput { get; set; }

        /// <summary>
        /// Список разрешенных статусов анкет через запятую
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
                if (IncludeNotAccepted)
                {
                    if (s.Length > 0)
                        s.Append(",");
                    s.Append(Constants.QK_IC_STATUS_NOT_ACCEPTED);
                }
                if (IncludeCertDataInput)
                {
                    if (s.Length > 0)
                        s.Append(",");
                    s.Append(Constants.QK_IC_STATUS_CERT_DATA_INPUT);
                }

                return s.ToString();
            }
        }

        /// <summary>
        /// Фильтр - дата с или null, если по дате заказа фильтровать не нужно
        /// </summary>
        public DateTime? OrderDateFrom { get; set; }

        /// <summary>
        /// Фильтр - дата по или null, если по дате заказа фильтровать не нужно
        /// </summary>
        public DateTime? OrderDateTo { get; set; }

        /// <summary>
        /// Код провизора или null, если по провизору фильтровать не нужно
        /// </summary>
        public long? ProvisorID { get; set; }

        /// <summary>
        /// Номер заказа, по которому нужно загрузить анкеты или null, если этот фильтр не используется
        /// </summary>
        public long? OrderID { get; set; }

        /// <summary>
        /// Фильтр - дата с или null, если по дате анкеты фильтровать не нужно
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Фильтр - дата по или null, если по дате анкеты фильтровать не нужно
        /// </summary>
        public DateTime? DateTo { get; set; }

        public InputControlLotnOrdersSearchParamters()
        {
            IncludeNew = IncludeInWork = OrderIncludeNew = OrderIncludeInWork = OrderIncludeCertDataInput = true;
            OnlyActual = true;
        }
    }
}
