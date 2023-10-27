namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// ������� �������� ���������� ��� ����� �������������
    /// </summary>
    public class CancellationFormsFactory : IFormsBuilderFactory
    {
        /// <summary>
        /// ��������� ����� ������� ���������� �� ���� ������� �������������
        /// </summary>
        /// <param name="reason">������� �������������</param>
        /// <param name="pickListRow">���������� � ������ ����������</param>
        /// <param name="sessionId">������ ������������ WMS</param>
        /// <returns>��������� ����� ��� ���������� ������� �������������</returns>
        public IFormBuilder CreateFormBuilder(CorrectionReasons reason, PickListRow pickListRow, int sessionId)
        {
            IFormBuilder builder = null;

            switch (reason)
            {
                    // ������������� �� �������
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