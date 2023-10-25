namespace WMSOffice.Classes
{
    /// <summary>
    /// Статический класс, который содержит константы, общие для WMS
    /// </summary>
    public static class Constants
    {
        #region ОСНОВНЫЕ КОНСТАНТЫ

        /// <summary>
        /// Идентификатор компании "Оптима-Фарм" (для использования вместе с dcto и doco)
        /// </summary>
        public const string KCOO = "00001";

        #endregion

        #region ТИПЫ МЕЖСКЛАДСКИХ АКТОВ

        /// <summary>
        /// Тип акта по недостаче ящика
        /// </summary>
        public const string IB_ACT_BOXND = "AD";

        /// <summary>
        /// Тип акта по излишку ящика
        /// </summary>
        public const string IB_ACT_BOXOVERAGE = "AS";

        /// <summary>
        /// Тип акта по недостаче дроби
        /// </summary>
        public const string IB_ACT_ITND = "ID";

        /// <summary>
        /// Тип акта по недостаче в заводском ящике
        /// </summary>
        public const string IB_ACT_MANUFACTURERND = "IF";

        /// <summary>
        /// Тип акта по заводскому браку
        /// </summary>
        public const string IB_ACT_DEFECT = "IM";

        /// <summary>
        /// Тип акта приема-передачи (по перерегистрации и перераспределению)
        /// </summary>
        public const string IB_ACT_REG = "IP";

        /// <summary>
        /// Тип акта по пересортице
        /// </summary>
        public const string IB_ACT_PERESORT = "IR";

        /// <summary>
        /// Тип акта по излишкам дроби
        /// </summary>
        public const string IB_ACT_OVERAGE = "IS";

        /// <summary>
        /// Тип акта по НТВ
        /// </summary>
        public const string IB_ACT_NTV = "IV";

        /// <summary>
        /// Тип акта по Бою
        /// </summary>
        public const string IB_ACT_BOY = "IX";

        #endregion

        #region ТИПЫ ПРЕТЕНЗИЙ

        /// <summary>
        /// Тип документа-претензии "Недостача" (DF)
        /// </summary>
        public const string CO_DT_ND = "DF";

        /// <summary>
        /// Тип документа-претензии "Излишек" (EX)
        /// </summary>
        public const string CO_DT_OVERAGE = "EX";

        /// <summary>
        /// Тип документа-претензии "Пересорт" (RG)
        /// </summary>
        public const string CO_DT_PERESORT = "RG";

        /// <summary>
        /// Тип документа-претензии "Нетоварный вид" (FR)
        /// </summary>
        public const string CO_DT_NTV = "FR";

        /// <summary>
        /// Тип документа-претензии "Бой" (BR)
        /// </summary>
        public const string CO_DT_BOY = "BR";

        /// <summary>
        /// Тип документа-претензии "W-Бой" (BO)
        /// </summary>
        public const string CO_DT_W_BOY = "BO";

        /// <summary>
        /// Тип документа-претензии "W-Недостача" (ND)
        /// </summary>
        public const string CO_DT_W_ND = "ND";

        /// <summary>
        /// Тип документа-претензии "Переподписание РН" (RI).
        /// </summary>
        public const string CO_DT_RESIGN_INVOICE = "RI";

        /// <summary>
        /// Тип документа-претензии "Заводской брак" (FL)
        /// </summary>
        public const string CO_DT_DEFECT = "FL";

        /// <summary>
        /// Тип документа-претензии "Аннулирование" (CN)
        /// </summary>
        public const string CO_DT_CANCELLATION = "CN";

        /// <summary>
        /// Тип документа-претензии "Возврат" (NR)
        /// </summary>
        public const string CO_DT_REFUSE = "NR";

        /// <summary>
        /// Тип документа-претензии "Виртуальный возврат" (VR)
        /// </summary>
        public const string CO_DT_VIRTUAL_REFUSE = "VR";

        /// <summary>
        /// Тип документа-претензии "Предписание" (OR)
        /// </summary>
        public const string CO_DT_QUALITY_ORDER = "OR";

        /// <summary>
        /// Тип документа-претензии "Сезонные продажи" (VS)
        /// </summary>
        public const string CO_DT_SEASON_SALES = "VS";

        /// <summary>
        /// Тип документа-претензии "Филиал - НТВ" (FF)
        /// </summary>
        public const string CO_DTFL_NTV = "FF";

        /// <summary>
        /// Тип документа-претензии "Филиал - Бой" (BF)
        /// </summary>
        public const string CO_DTFL_BOY = "BF";

        /// <summary>
        /// Тип документа-претензии "Филиал - Недостача дроби" (D1)
        /// </summary>
        public const string CO_DTFL_ITND = "D1";

        /// <summary>
        /// Тип документа-претензии "Филиал - Недостача ящика" (D2)
        /// </summary>
        public const string CO_DTFL_BOXND = "D2";

        /// <summary>
        /// Тип документа-претензии "Филиал - Недостача в заводском ящике" (D3)
        /// </summary>
        public const string CO_DTFL_MANUFACTURERND = "D3";

        /// <summary>
        /// Тип документа-претензии "Филиал - Излишек" (E1)
        /// </summary>
        public const string CO_DTFL_OVERAGE = "E1";

        /// <summary>
        /// Тип документа-претензии "Филиал - Пересорт" (R1)
        /// </summary>
        public const string CO_DTFL_PERESORT = "R1";

        /// <summary>
        /// Тип документа-претензии "Филиал - возврат по перерегистрации" (B1)
        /// </summary>
        public const string CO_DTFL_REG = "B1";

        /// <summary>
        /// Тип документа-претензии "Филиал - заводской брак" (F1)
        /// </summary>
        public const string CO_DTFL_DEFECT = "F1";

        /// <summary>
        /// Тип документа-претензии "Филиал - возврат по перераспределению" (N1)
        /// </summary>
        public const string CO_DFTL_DEMAND = "N1";

        /// <summary>
        /// Тип документа-претензии "Филиал - возврат по срокам годности" (N2)
        /// </summary>
        public const string CO_DTFL_EXPIRATION = "N2";

        /// <summary>
        /// Тип документа-претензии "Филиал - виртуальный возврат"
        /// </summary>
        public const string CO_DTFL_VIRTUAL_REFUSE = "V1";

        /// <summary>
        /// Тип документа-претензии "Бой внутренний" (I0)
        /// </summary>
        public const string CO_DTWH_BOY = "I0";

        /// <summary>
        /// Тип документа-претензии "НТВ внутренний" (I1)
        /// </summary>
        public const string CO_DTWH_NTV = "I1";

        /// <summary>
        /// Тип документа-претензии "Заводской брак внутренний" (I2)
        /// </summary>
        public const string CO_DTWH_DEFECT = "I2";

        /// <summary>
        /// Тип документа-претензии "Заводское недовложение внутреннее" (I3)
        /// </summary>
        public const string CO_DTWH_MANUFACTURERND = "I3";

        /// <summary>
        /// Тип документа-претензии "Недостача товара внутренняя" (I4)
        /// </summary>
        public const string CO_DTWH_ITND = "I4";

        /// <summary>
        /// Тип документа-претензии "Ошибка этикетки внутренняя" (I5)
        /// </summary>
        public const string CO_DTWH_LABEL_ERROR = "I5";

        /// <summary>
        /// Тип документа-претензии "Излишек внутренний" (I6)
        /// </summary>
        public const string CO_DTWH_OVERAGE = "I6";

        /// <summary>
        /// Тип документа-претензии "Недостача внутренняя (комплектация маршрутов)" (I7)
        /// </summary>
        public const string CO_DTWH_ROUTE_SHORTAGE = "I7";

        /// <summary>
        /// Тип документа-претензии "НТВ внутренний в КиУП" (I8)
        /// </summary>
        public const string CO_DTWH_NTV_KIUP = "I8";

        /// <summary>
        /// Тип документа-претензии "Перемещение в продажу (LC-LA)" (I9)
        /// </summary>
        public const string CO_DTWH_MOVE_TO_SALE_FROM_QUARANTINE = "I9";

        /// <summary>
        /// Тип документа-претензии "Отмена возврата (внутренний)" (IR)
        /// </summary>
        public const string CO_DTWH_CANCEL_REFUSE = "IR";

        /// <summary>
        /// Тип документа-претензии "W-НТВ" (UG)
        /// </summary>
        public const string CO_WEB_NTV = "UG";

        /// <summary>
        /// Тип документа-претензии "Акт ОТ" (RA)
        /// </summary>
        public const string CO_DTWH_RET_ACT = "RA";

        /// <summary>
        /// Тип документа-претнзии "Бой ОТ" (RB)
        /// </summary>
        public const string CO_DTWH_RET_BOY = "RB";

        /// <summary>
        /// Тип документа-претензии "Паллеты - Недостача" (PF)
        /// </summary>
        public const string CO_DTPL_PF = "PF";

        /// <summary>
        /// Тип документа-претензии "Паллеты - Излишек" (PX)
        /// </summary>
        public const string CO_DTPL_PX = "PX";

        #endregion

        #region СТАТУСЫ ЗАЯВОК ОТДЕЛА КАЧЕСТВА

        /// <summary>
        /// Статус заявки: Заявка сформирована
        /// </summary>
        public const string QK_STATUS_D_100 = "100";

        /// <summary>
        /// Статус заявки: Напечатан пакет документов
        /// </summary>
        public const string QK_STATUS_D_110 = "110";

        /// <summary>
        /// Статус заявки: Выбор экспертого центра
        /// </summary>
        public const string QK_STATUS_D_115 = "115";

        /// <summary>
        /// Статус заявки: Сформировано задание на отбор
        /// </summary>
        public const string QK_STATUS_D_120 = "120";

        /// <summary>
        /// Статус заявки: Документы уехали
        /// </summary>
        public const string QK_STATUS_D_130 = "130";

        /// <summary>
        /// Статус заявки: Заявка в Инспеции
        /// </summary>
        public const string QK_STATUS_D_140 = "140";

        /// <summary>
        /// Статус заявки: Заявка на этапе перемещения межсклада с товаром для осмотра
        /// </summary>
        public const string QK_STATUS_D_180 = "180";

        /// <summary>
        /// Статус заявки: Заявка закрыта
        /// </summary>
        public const string QK_STATUS_D_199 = "199";

        /// <summary>
        /// Вид документа: Иммунобиология
        /// </summary>
        public const string QK_DocCode_IMN = "IMN";

        #endregion

        #region СТАТУСЫ СТРОК ЗАЯВОК ОТДЕЛА КАЧЕСТВА

        /// <summary>
        /// Статус строки заявки: Строка сформирована
        /// </summary>
        public const string QK_STATUS_DD_200 = "200";

        /// <summary>
        /// Статус строки заявки: В инспекции PIC/S
        /// </summary>
        public const string QK_STATUS_DD_205 = "205";

        /// <summary>
        /// Статус строки заявки: В инспекции не PIC/S
        /// </summary>
        public const string QK_STATUS_DD_206 = "206";

        /// <summary>
        /// Статус строки заявки: Внесен информ. лист по критическому замечанию
        /// </summary>
        public const string QK_STATUS_DD_208 = "208";

        /// <summary>
        /// Статус строки заявки: Получено направление
        /// </summary>
        public const string QK_STATUS_DD_210 = "210";

        /// <summary>
        /// Статус строки заявки: Сформировано задание на отбор образцов для направления
        /// </summary>
        public const string QK_STATUS_DD_215 = "215";

        /// <summary>
        /// Статус строки заявки: Передано плановой машиной
        /// </summary>
        public const string QK_STATUS_DD_218 = "218";

        /// <summary>
        /// Статус строки заявки: Образцы доставлены на РАС
        /// </summary>
        public const string QK_STATUS_DD_219 = "219";

        /// <summary>
        /// Статус строки заявки: Образцы переданы в лабораторию
        /// </summary>
        public const string QK_STATUS_DD_220 = "220";

        /// <summary>
        /// Статус строки заявки: Анализ получен
        /// </summary>
        public const string QK_STATUS_DD_230 = "230";

        /// <summary>
        /// Статус строки заявки: Анализ передан
        /// </summary>
        public const string QK_STATUS_DD_235 = "235";

        /// <summary>
        /// Статус строки заявки: Добавлено замечание к сертификату от лаборатории
        /// </summary>
        public const string QK_STATUS_DD_236 = "236";

        /// <summary>
        /// Статус строки заявки: Проблемы по строке заявки
        /// </summary>
        public const string QK_STATUS_DD_297 = "297";

        /// <summary>
        /// Статус строки заявки: Закрыта по причине
        /// </summary>
        public const string QK_STATUS_DD_298 = "298";

        /// <summary>
        /// Статус строки заявки: Заключение получено
        /// </summary>
        public const string QK_STATUS_DD_299 = "299";

        /// <summary>
        /// Статус строки заявки: Направление аннулировано
        /// </summary>
        public const string QK_STATUS_DD_999 = "999";

        #endregion

        #region СТАТУСЫ РАЗРЕШЕНИЯ НА РЕАЛИЗАЦИЮ СЕРИИ ДЛЯ СТРОКИ ЗАЯВКИ ОТДЕЛА КАЧЕСТВА

        /// <summary>
        /// Статус разрешения на реализацю, который обозначает, что форма разрешения была подтверждена провизором отдела качества
        /// </summary>
        public const int QK_STATUS_SP_IS_COMMITED = 1;

        /// <summary>
        /// Статус разрешения на реализацю, который обозначает, что форма разрешения была распечатана
        /// </summary>
        public const int QK_STATUS_SP_IS_PRINTED = 2;

        #endregion

        #region СТАТУСЫ ПРИЧИН ЗАДЕРЖКИ ЗАЯВОК ОТДЕЛА КАЧЕСТВА

        /// <summary>
        /// Статус причины задержки: причина задержки внесена в систему
        /// </summary>
        public const string QK_STATUS_DLRN_IS_CREATED = "400";

        /// <summary>
        /// Статус причины задержки: причина задержки решена
        /// </summary>
        public const string QK_STATUS_DLRN_IS_RESOLVED = "405";

        /// <summary>
        /// Статус причины задержки: причина задержки аннулирована
        /// </summary>
        public const string QK_STATUS_DLRN_IS_CANCELED = "406";

        #endregion

        #region СТАТУСЫ АНКЕТ ВХОДНОГО КОНТРОЛЯ ПОСТАВКИ

        /// <summary>
        /// Статус анкеты входного контроля поставки: Новая
        /// </summary>
        public const int QK_IC_STATUS_NEW = 1;

        /// <summary>
        /// Статус анкеты входного контроля поставки: В работе
        /// </summary>
        public const int QK_IC_STATUS_IN_WORK = 2;

        /// <summary>
        /// Статус анкеты входного контроля поставки: Пройдена успешно
        /// </summary>
        public const int QK_IC_STATUS_ACCEPTED = 3;

        /// <summary>
        /// Статус анкеты входного контроля поставки: Не пройдена
        /// </summary>
        public const int QK_IC_STATUS_NOT_ACCEPTED = 4;

        /// <summary>
        /// Статус анкеты входного контроля поставки: Ввод данных сертификата
        /// </summary>
        public const int QK_IC_STATUS_CERT_DATA_INPUT = 5;

        /// <summary>
        /// Статус анкеты входного контроля поставки: Сомнительного качества
        /// </summary>
        public const int QK_IC_STATUS_WITH_SUSPECTED_QUALITY = 6;

        #endregion

        #region ТИПЫ ВОПРОСОВ АНКЕТ ВХОДНОГО КОНТРОЛЯ

        /// <summary>
        /// Вопросы по визуальному состоянию поставки
        /// </summary>
        public const int QK_IC_TYPEID_DELIVERY_STATE = 1;

        /// <summary>
        /// Вопросы по комплектности документов
        /// </summary>
        public const int QK_IC_TYPEID_DELIVERY_DOCS = 2;

        #endregion

        #region ТИПЫ ИСТОЧНИКОВ ОТВЕТОВ НА ВОПРОСЫ АНКЕТ ВХОДНОГО КОНТРОЛЯ ПАРТИИ

        /// <summary>
        /// Сертификаты качества производителя
        /// </summary>
        public const string QK_IC_SOURCEID_CERT = "1";

        /// <summary>
        /// Визуальный контроль
        /// </summary>
        public const string QK_IC_SOURCEID_VISUAL = "2";

        /// <summary>
        /// Печатная накладная
        /// </summary>
        public const string QK_IC_SOURCEID_PRINTEDINV = "3";

        /// <summary>
        /// Заключение ГЛС
        /// </summary>
        public const string QK_IC_SOURCEID_GLS = "4";

        #endregion

        #region СТАТУСЫ ДОКУМЕНТОВ ФОТООТЧЕТА ОТПРАВКИ НА ФИЛИАЛ

        /// <summary>
        /// Документ создан (100)
        /// </summary>
        public const string IB_IR_PHOTO_DOC_CREATED = "100";

        /// <summary>
        /// Документ подтвержден (110)
        /// </summary>
        public const string IB_IR_PHOTO_DOC_APPROVED = "110";

        /// <summary>
        /// Документ на РАС (120)
        /// </summary>
        public const string IB_IR_PHOTO_DOC_RECEIVED = "120";

        /// <summary>
        /// Документ просмотрен (130)
        /// </summary>
        public const string IB_IR_PHOTO_DOC_PREVIEWED = "130";

        /// <summary>
        /// Документ закрыт (199)
        /// </summary>
        public const string IB_IR_PHOTO_DOC_CLOSED = "199";

        #endregion
    }
}
