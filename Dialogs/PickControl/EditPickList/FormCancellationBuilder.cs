using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WMSOffice.Data.PickControlTableAdapters;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// Строитель формы аннулирования строки заказа
    /// </summary>
    public class FormCancellationBuilder : IFormBuilder
    {
        #region локальные переменные

        private PickListRow _pickListRow = null;
        private int _sessionId;
        private CorrectionReasons _reason;

        #endregion

        #region конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pickListRow">Информация о строке сборочного</param>
        /// <param name="sessionId">Сессия пользователя WMS</param>
        public FormCancellationBuilder(CorrectionReasons reason, PickListRow pickListRow, int sessionId)
        {
            _reason = reason;
            _pickListRow = pickListRow;
            _sessionId = sessionId;
        }

        #endregion

        #region Implementation of IFormBuilder

        /// <summary>
        /// Созданные элементы управления для формы
        /// </summary>
        public List<BaseControl> Controls { get; set; }

        /// <summary>
        /// Метод построения элементов управления
        /// </summary>
        public void LoadControls()
        {
            string location = "NULL";

            // определяем полку, на которую будет перемещаться товар
            using (QueriesTableAdapter adapter = new QueriesTableAdapter())
            {
                var locn = adapter.GetLocation((int) _reason, null, null,
                                    _pickListRow.Company, _pickListRow.DocumentType, _pickListRow.DocumentNumber,
                                    _pickListRow.PickSlipNumber, _pickListRow.LineId, _pickListRow.Quantity);
                if (locn != null)
                    location = ((string)locn).Trim();
            }

            Controls = new List<BaseControl>();
            DescriptionControl description = new DescriptionControl();
            description.Action = String.Format("Вы отменяете: ({0}) {1}", _pickListRow.ItemId, _pickListRow.Item);
            description.Count = _pickListRow.Quantity.ToString(CultureInfo.InvariantCulture);
            description.Description = String.Format("Действие системы: Отмененное количество будет перемещено на полку {0}.", location);
            Controls.Add(description);

            if (DialogResultEnableChanged != null) 
                DialogResultEnableChanged(this, new DialogResultEnableEventArgs() { ButtonOkEnabled = true, ButtonCancelEnabled = true });
        }

        /// <summary>
        /// Метод сохранения данных формы
        /// </summary>
        public void SaveData()
        {
            var changedAmount = 0;
            var confirmEmployeeID = (Container as EditPickListItemForm).CheckPickSlipItemEditSum(changedAmount);

            using (QueriesTableAdapter adapter = new QueriesTableAdapter())
            {
                // база данных, аннулирование строки
                adapter.CP_СancelRow(_sessionId, (int) _reason, _pickListRow.Company, _pickListRow.DocumentType,
                                     _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId, confirmEmployeeID);
            }
        }

        /// <summary>
        /// Контейнер
        /// </summary>
        public object Container { get; set; }

        /// <summary>
        /// Событие, призывающее изменить состояние доступности кнопок закрытия диалога корректировки
        /// </summary>
        public event EventHandler<DialogResultEnableEventArgs> DialogResultEnableChanged;

        #endregion
    }
}
