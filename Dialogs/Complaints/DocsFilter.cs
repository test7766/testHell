using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Содержит фильтры для ограничения списка отображаемых претензий.
    /// </summary>
    public partial class DocsFilter : UserControl
    {
        /// <summary>
        /// Возвращает / устанавливает признак, показывающий, нужно ли остановить (временно) порождение событий (например, FilterChanged при инициализации).
        /// </summary>
        private bool SupressEvents { get; set; }
        
        /// <summary>
        /// Инициализирует новый экземпляр элемента управления.
        /// </summary>
        public DocsFilter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Инициализирует содержимое выпадающих списков. После инициализации порождает событие FilterChanged.
        /// </summary>
        /// <param name="sessionID">Идентификатор пользовательской сессии.</param>
        public void Init(long sessionID)
        {
            SupressEvents = true;

            cbDocTypes.DropDownWidth = 250;
            cbStatusesFrom.DropDownWidth = cbStatusesTo.DropDownWidth = 350;
            cbWarehouses.DropDownWidth = 200;

            availableDocsTypesTableAdapter.Fill(complaints.AvailableDocsTypes, sessionID, false, null);
            cbDocTypes.DataSource = complaints.AvailableDocsTypes;
            availableStatusesTableAdapter.Fill(complaints.AvailableStatuses, sessionID);
            cbStatusesFrom.DataSource = complaints.AvailableStatuses;
            cbStatusesTo.DataSource = complaints.AvailableStatuses.Copy();

            var useFullMode = 1;
            availableWarehousesTableAdapter.Fill(complaints.AvailableWarehouses, sessionID, useFullMode);

            SupressEvents = false;

            OnFilterChanged();
        }

        /// <summary>
        /// Возникает при изменении пользователем настроек фильтрации.
        /// </summary>
        public event EventHandler<FilterChangedEventArgs> FilterChanged;


        #region Class FilterChangedEventArgs

        /// <summary>
        /// Содержит данные для события DocsFilter.FilterChanged.
        /// </summary>
        public class FilterChangedEventArgs : EventArgs
        {
            /// <summary>
            /// Инициализирует новый экземпляр класса FilterChangedEventArgs.
            /// </summary>
            /// <param name="limitDocType">Признак, показывающий, нужно ли ограничить тип претензии.</param>
            /// <param name="docType">Идентификатор отображаемого типа претензии.</param>
            /// <param name="limitDocStatus">Признак, показывающий, нужно ли ограничить статус претензии.</param>
            /// <param name="statusFrom">Идентификатор статуса претензии для начала отображаемого диапазона.</param>
            /// <param name="statusTo">Идентификатор статуса претензии для конца отображаемого диапазона.</param>
            /// <param name="onlyRequiringVisa">Признак, показывающий, нужно ли отображать только те претензии, по которым пользователь должен поставить визу.</param>
            /// <param name="limitWarehouse">Признак, показывающий, нужно ли ограничить филиал (склад) претензии.</param>
            /// <param name="warehouse">Идентификатор филиала (склада) отображаемых претензий.</param>
            public FilterChangedEventArgs(bool limitDocType, string docType, bool limitDocStatus, string statusFrom, string statusTo, bool onlyRequiringVisa, bool limitWarehouse, string warehouse)
            {
                this.LimitDocType = limitDocType;
                this.DocType = docType;
                this.LimitDocStatus = limitDocStatus;
                this.StatusFrom = statusFrom;
                this.StatusTo = statusTo;
                this.OnlyRequiringVisa = onlyRequiringVisa;
                this.LimitWarehouse = limitWarehouse;
                this.Warehouse = warehouse;
            }
            
            /// <summary>
            /// Возвращает признак, показывающий, нужно ли ограничить тип претензии.
            /// </summary>
            public bool LimitDocType { get; private set; }
            /// <summary>
            /// Возвращает идентификатор отображаемого типа претензии.
            /// </summary>
            public string DocType { get; private set; }
            /// <summary>
            /// Возвращает признак, показывающий, нужно ли ограничить статус претензии.
            /// </summary>
            public bool LimitDocStatus { get; private set; }
            /// <summary>
            /// Возвращает идентификатор статуса претензии для начала отображаемого диапазона.
            /// </summary>
            public string StatusFrom { get; private set; }
            /// <summary>
            /// Возвращает идентификатор статуса претензии для конца отображаемого диапазона.
            /// </summary>
            public string StatusTo { get; private set; }
            /// <summary>
            /// Возвращает признак, показывающий, нужно ли отображать только те претензии, по которым пользователь должен поставить визу.
            /// </summary>
            public bool OnlyRequiringVisa { get; private set; }
            /// <summary>
            /// Возвращает признак, показывающий, нужно ли ограничить филиал (склад) претензии.
            /// </summary>
            public bool LimitWarehouse { get; private set; }
            /// <summary>
            /// Возвращает идентификатор отображаемого филиала (склада) претензий.
            /// </summary>
            public string Warehouse { get; private set; }
        }

        #endregion


        /// <summary>
        /// Обрабатывает изменение пользователем состояний флажков и выбранных элементов в выпадающих списках.
        /// </summary>
        private void FilterValueChanged(object sender, EventArgs e)
        {
            cbDocTypes.Enabled = chkbDocType.Checked;
            cbStatusesFrom.Enabled = cbStatusesTo.Enabled = chkbStatuses.Checked;
            cbWarehouses.Enabled = chkbWarehouse.Checked;

            OnFilterChanged();
        }

        /// <summary>
        /// Порождает событие FilterChanged.
        /// </summary>
        private void OnFilterChanged()
        {
            if (!SupressEvents && FilterChanged != null)
            {
                FilterChanged(this, new FilterChangedEventArgs(chkbDocType.Checked,
                    complaints.AvailableDocsTypes.Count > 0 ? (string)cbDocTypes.SelectedValue : null,
                    chkbStatuses.Checked,
                    complaints.AvailableStatuses.Count > 0 ? (string)cbStatusesFrom.SelectedValue : null,
                    complaints.AvailableStatuses.Count > 0 ? (string)cbStatusesTo.SelectedValue : null,
                    chkbOnlyRequiringVisa.Checked,
                    chkbWarehouse.Checked,
                    (string)cbWarehouses.SelectedValue
                    ));
            }
        }
    }
}
