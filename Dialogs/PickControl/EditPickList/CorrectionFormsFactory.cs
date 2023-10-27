namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// Фабрика создания Строителей для формы корректировок
    /// </summary>
    public class CorrectionFormsFactory : IFormsBuilderFactory
    {
        /// <summary>
        /// Фабричный метод созданя Строителей по типу причины корректировки
        /// </summary>
        /// <param name="reason">Причина корректировки</param>
        /// <param name="pickListRow">Информация о строке сборочного</param>
        /// <param name="sessionId">Сессия пользователя WMS</param>
        /// <returns>Строитель формы для конкретной причины корректировки</returns>
        public IFormBuilder CreateFormBuilder(CorrectionReasons reason, PickListRow pickListRow, int sessionId)
        {
            IFormBuilder builder = null;

            switch (reason)
            {
                    // корректировка по причине
                case CorrectionReasons.OutOfStock:
                    builder = new FormOutOfStockBuilder(pickListRow, sessionId);
                    break;
                case CorrectionReasons.ChangeSeries:
                    builder = new FormChangeSeriesBuilder(pickListRow, sessionId);
                    break;
                case CorrectionReasons.Substandard:
                    builder = new FormSubstandardBuilder(pickListRow, sessionId);
                    break;
                case CorrectionReasons.BoxCapacity:
                    builder = new FormBoxCapacityBuilder(pickListRow, sessionId);
                    break;
            }
            return builder;
        }

    }
}