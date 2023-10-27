namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// Фабрика создания Строителей для формы аннулирования
    /// </summary>
    public class CancellationFormsFactory : IFormsBuilderFactory
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
                    // аннулирование по причине
                case CorrectionReasons.ClientRefuse:
                case CorrectionReasons.ClientMistake:
                case CorrectionReasons.ManagerMistake:
                case CorrectionReasons.OutOfStock:
                case CorrectionReasons.BlockedLotn:
                    builder = new FormCancellationBuilder(reason, pickListRow, sessionId);
                    break;
            }
            return builder;
        }
    }
}