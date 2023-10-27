using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// Абстрактная Фабрика создания Строителей для формы
    /// </summary>
    public interface IFormsBuilderFactory
    {
        /// <summary>
        /// Фабричный метод созданя Строителей по типу причины корректировки
        /// </summary>
        /// <param name="reason">Причина корректировки</param>
        /// <param name="pickListRow">Информация о строке сборочного</param>
        /// <param name="sessionId">Сессия пользователя WMS</param>
        /// <returns>Строитель формы для конкретной причины корректировки</returns>
        IFormBuilder CreateFormBuilder(CorrectionReasons reason, PickListRow pickListRow, int sessionId);
    }
}
