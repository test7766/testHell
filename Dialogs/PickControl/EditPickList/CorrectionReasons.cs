using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// Перечисление причин корректировки
    /// </summary>
    public enum CorrectionReasons
    {
        // 1	Замена серии
        ChangeSeries = 1,
        // 2	Нетоварный вид
        Substandard = 2,
        // 3	Отказ
        ClientRefuse = 3,
        // 4	Ошибка клиента
        ClientMistake = 4,
        // 5	Ошибка ТО
        ManagerMistake = 5,
        // 6	Тех ошибка (не используется)
        TechnicalError = 6,
        // 7	Нет в наличии
        OutOfStock = 7,
        // 8  Корректировка ящичной нормы
        BoxCapacity = 8,
        // 9  Серия заблокирована
        BlockedLotn = 9
    }
}
