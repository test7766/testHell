using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// Интерфейс - "универсальный строитель формы"
    /// </summary>
    public interface IFormBuilder
    {
        /// <summary>
        /// Созданные элементы управления для формы
        /// </summary>
        List<BaseControl> Controls { get; set; }

        /// <summary>
        /// Метод построения элементов управления
        /// </summary>
        void LoadControls();

        /// <summary>
        /// Метод сохранения данных формы
        /// </summary>
        void SaveData();

        /// <summary>
        /// Контейнер для строителя
        /// </summary>
        object Container { get; set; }

        /// <summary>
        /// Событие, призывающее изменить состояние доступности кнопок закрытия диалога корректировки
        /// </summary>
        event EventHandler<DialogResultEnableEventArgs> DialogResultEnableChanged;
    }

    public class DialogResultEnableEventArgs : EventArgs
    {
        public bool ButtonOkEnabled { get; set; }
        public bool ButtonCancelEnabled { get; set; }
    }
}
