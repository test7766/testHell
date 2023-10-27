namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// ������� �������� ���������� ��� ����� �������������
    /// </summary>
    public class CorrectionFormsFactory : IFormsBuilderFactory
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