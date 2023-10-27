using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public static class WHCache
    {
        private static long _userID;
        public static long UserID
        {
            set 
            {
                if (_userID != value)
                {
                    _userID = value;
                    isWarehousesLoaded = false;
                }
            }
            get { return _userID; }
        }

        /// <summary>
        /// Признак завершения загрузки справочника филиалов
        /// </summary>
        private static bool isWarehousesLoaded;

        /// <summary>
        /// Признак необходимости загрузить справочник филиалов
        /// </summary>
        public static bool NeedToLoadWarehouses { set { isWarehousesLoaded = !value; } }

        private static Data.WH.OperationWarehousesDataTable _warehouses;
        public static Data.WH.OperationWarehousesDataTable Warehouses
        {
            get
            {
                if (!isWarehousesLoaded)
                    LoadWarehouses();
                return _warehouses;
            }
        }

        static WHCache()
        {
            _warehouses = new WMSOffice.Data.WH.OperationWarehousesDataTable();
        }

        private static void LoadWarehouses()
        {
            try
            {
                using (Data.WHTableAdapters.OperationWarehousesTableAdapter adapter = new WMSOffice.Data.WHTableAdapters.OperationWarehousesTableAdapter())
                    adapter.Fill(_warehouses, UserID);

                isWarehousesLoaded = true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Ошибка загрузки справочника складов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
