namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// ������� �������������
    /// </summary>
    public class CorrectionReason
    {
        public CorrectionReason(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// ������������� ������� �������������
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// �������� ������� �������������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// �������������� ������ � ������������
        /// </summary>
        /// <param name="reason">������ ������ � ����������� ��������� ������� �������������</param>
        /// <returns>������� ������������ ������ �������������</returns>
        public static implicit operator CorrectionReasons(CorrectionReason reason)
        {
            return (CorrectionReasons) reason.Id;
        }
    }
}