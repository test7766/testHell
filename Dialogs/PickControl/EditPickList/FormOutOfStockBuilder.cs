using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WMSOffice.Data.PickControlTableAdapters;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// Строитель формы корректировки по причине "Нет в наличии"
    /// </summary>
    public class FormOutOfStockBuilder : IFormBuilder
    {
        #region локальные переменные

        private PickListRow _pickListRow = null;
        private int _sessionId;

        private QuantityChangeControl _quantityChange;
        private DescriptionControl _descriptionControl;
        private int _allRemainsCount;
        private string _location = "NULL";

        #endregion

        #region конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pickListRow">Информация о строке сборочного</param>
        /// <param name="sessionId">Сессия пользователя WMS</param>
        public FormOutOfStockBuilder(PickListRow pickListRow, int sessionId)
        {
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
            // определяем полку, на которую будет перемещаться товар
            using (QueriesTableAdapter adapter = new QueriesTableAdapter())
            {
                var locn = adapter.GetLocation((int)CorrectionReasons.OutOfStock, null, null,
                    _pickListRow.Company, _pickListRow.DocumentType, _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId, _pickListRow.Quantity);
                if (locn != null)
                    _location = ((string) locn).Trim();
            }

            Controls = new List<BaseControl>();

            // информация о текущем состоянии строки заказа
            CurrentRowControl currentRow = new CurrentRowControl()
                                               {
                                                   Location = _pickListRow.Location,
                                                   Item = _pickListRow.Item,
                                                   Quantity = _pickListRow.Quantity.ToString(),
                                                   Series = _pickListRow.Series
                                               };
            Controls.Add(currentRow);

            // форма изменения количества по строке заказа
            _quantityChange = new QuantityChangeControl()
                                                       {
                                                           OriginalQuantity = _pickListRow.Quantity,
                                                           Quantity = 0
                                                       };
            _quantityChange.ValueChanged += ParseFormValues;
            Controls.Add(_quantityChange);

            // описание действия системы
            _descriptionControl = new DescriptionControl();
            _descriptionControl.Action = String.Format("Вы отменяете: ({0}) {1}", _pickListRow.ItemId, _pickListRow.Item);
            _descriptionControl.Count = _pickListRow.Quantity.ToString(CultureInfo.InvariantCulture);
            _descriptionControl.Description = String.Format("Действие системы: Отмененное количество будет перемещено на полку {0}.", _location);
            Controls.Add(_descriptionControl);

            if (DialogResultEnableChanged != null)
                DialogResultEnableChanged(this, new DialogResultEnableEventArgs() { ButtonOkEnabled = true, ButtonCancelEnabled = true });
        }

        /// <summary>
        /// Обработчик события изменения значения на форме корректировки
        /// </summary>
        /// <param name="field">Поле формы</param>
        /// <param name="value">Новое значение</param>
        private void ParseFormValues(string field, object value)
        {
            bool allowOk = true;

            if (field == "Quantity")
                _descriptionControl.Count = _quantityChange.CanceledQuantity.ToString();

            if (field == "MoveAllRemains")
                if ((bool)value)
                {
                    try
                    {
                        // определяем полку, на которую будет перемещаться товар
                        using (QueriesTableAdapter adapter = new QueriesTableAdapter())
                        {
                            int? qty = null;
                            adapter.CP_GetRemainsByLocation(_sessionId, _pickListRow.Company, _pickListRow.DocumentType, _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId, ref qty);
                            _allRemainsCount = (qty.HasValue) ? qty.Value : 0;
                        }
                        if (_allRemainsCount > 0)
                            _descriptionControl.Description = String.Format("Действие системы: Отмененное количество будет перемещено на полку {0}.\nДоступный остаток на полке {1} в количестве {2} будет перемещен на полку {0}.", _location, _pickListRow.Location, _allRemainsCount);
                        else
                            _descriptionControl.Description = String.Format("Действие системы: Отмененное количество будет перемещено на полку {0}.\nДоступный остаток на полке {1} отсутствует.", _location, _pickListRow.Location);
                        
                    } catch (Exception ex)
                    {
                        _descriptionControl.Description = String.Format("Действие системы: Отмененное количество будет перемещено на полку {0}.\nОшибка при получении доступного остатка:\n {1}.", _location, ex.Message);
                    }
                } else
                {
                    _descriptionControl.Description = String.Format("Действие системы: Отмененное количество будет перемещено на полку {0}.", _location);
                    _allRemainsCount = 0;
                }

            if (DialogResultEnableChanged != null)
                DialogResultEnableChanged(this, new DialogResultEnableEventArgs() { ButtonOkEnabled = allowOk, ButtonCancelEnabled = true });
        }

        /// <summary>
        /// Метод сохранения данных формы
        /// </summary>
        public void SaveData()
        {
            var changedAmount = _quantityChange.Quantity;
            var confirmEmployeeID = (Container as EditPickListItemForm).CheckPickSlipItemEditSum(changedAmount);

            using (QueriesTableAdapter adapter = new QueriesTableAdapter())
            {
                // база данных, аннулирование строки
                adapter.CP_Сorrect_Outofstock(_sessionId, (int)CorrectionReasons.OutOfStock, _pickListRow.Company, _pickListRow.DocumentType,
                                     _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId, _quantityChange.Quantity, _quantityChange.MoveAllRemains, confirmEmployeeID);
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
