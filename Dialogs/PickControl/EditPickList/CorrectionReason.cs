namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// Причина корректировки
    /// </summary>
    public class CorrectionReason
    {
        public CorrectionReason(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Идентификатор причины корректировки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название причины корректировки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Преобразование класса и перечисления
        /// </summary>
        /// <param name="reason">Объект класса с фактическим описанием причины корректировки</param>
        /// <returns>Элемент перечисления причин корректировки</returns>
        public static implicit operator CorrectionReasons(CorrectionReason reason)
        {
            return (CorrectionReasons) reason.Id;
        }
    }
}