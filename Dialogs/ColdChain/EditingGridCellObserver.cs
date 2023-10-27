using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.ColdChain
{
    /// <summary>
    /// Класс-наблюдатель изменяемости значения текущей ячейки грида с выполнением последействий
    /// </summary>
    public class EditingGridCellObserver
    {
        #region ПОЛЯ
        /// <summary>
        /// Значение в ячейке данных в момент открытия редактора
        /// </summary>
        public object OldValue { get; set; }

        /// <summary>
        /// Значение в ячейке данных в момент ухода из нее после редактирования
        /// </summary>
        public object NewValue { get; set; }

        /// <summary>
        /// Поле источника данных в текущей редактируемой ячейке 
        /// </summary>
        public string SourceFieldName { get; set; }
        #endregion

        #region АТРИБУТЫ
        public delegate void ActionAfterUpdateHandler();
        /// <summary>
        /// Экземпляр делегата - указатель на метод, который будет вызван после обновления данных
        /// </summary>
        public ActionAfterUpdateHandler ExecuteActionAfterUpdate;

        public delegate void CellChangedEventHandler(object sender, CellChangedEventArgs e);
        public event CellChangedEventHandler OnApplyChanges;
        public class CellChangedEventArgs : EventArgs
        {

            private DataGridView owner = null;

            public DataGridView Owner
            {
                get { return owner; }
            }

            public CellChangedEventArgs(DataGridView owner)
            {
                this.owner = owner;
            }
        }
        #endregion

        #region МЕТОДЫ
        public void CheckChanges(DataGridView sender)
        {
            if (DataWasChangedInEditMode() && OnApplyChanges != null)
                OnApplyChanges(this, new CellChangedEventArgs(sender));
        }

        /// <summary>
        /// Возвращает признак изменяемости данных
        /// </summary>
        /// <returns></returns>
        private bool DataWasChangedInEditMode()
        {
            return this.OldValue.ToString().Trim() != this.NewValue.ToString().Trim();
        }
        #endregion
    }
}
