using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class RepackItemCheckRegradingUnits : Form
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Текущий товар для перепаковки
        /// </summary>
        public Data.WH.RepackMainDisplayCurrentTasksRow RepackItem { get; private set; }

        /// <summary>
        /// Код сессии пользователя
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Код склада
        /// </summary>
        public string WarehouseID { get; set; }

        /// <summary>
        /// Стол перепаковки
        /// </summary>
        public string LOCN { get; set; }

        /// <summary>
        /// Код станции
        /// </summary>
        public string StationID { get; set; }

        /// <summary>
        /// Сканируемый код товара
        /// </summary>
        public int ScannedUnit { get; private set; }

        #endregion

        public RepackItemCheckRegradingUnits()
        {
            InitializeComponent();
        }

        public RepackItemCheckRegradingUnits(Data.WH.RepackMainDisplayCurrentTasksRow repackItem, int scannedUnit)
            : this()
        {
            RepackItem = repackItem;
            ScannedUnit = scannedUnit;
        }

        private void RepackItemCheckRegradingUnits_Load(object sender, EventArgs e)
        {
            lblScannedUnit.Text = string.Format("{0}", ScannedUnit);
            lblExpectedUnit.Text = string.Format("{0}", RepackItem.IMITM);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnBeginRegradeUnits_Click(object sender, EventArgs e)
        {
            var factItemID = (int?)null;
            var factVendorLot = (string)null;

            #region УСТАНОВКА ФАКТИЧЕСКОЙ НОМЕНКЛАТУРЫ

            var dlgSetFactUnits = new RepackItemSetFactUnits()
            {
                UserID = UserID
            };
            if (dlgSetFactUnits.ShowDialog() != DialogResult.OK)
                return;

            factItemID = dlgSetFactUnits.ItemID_Fact;

            #endregion

            Data.WH.RepackItemCancelReasonsDataTable reasons = null;
            using (var adapter = new Data.WHTableAdapters.RepackItemCancelReasonsTableAdapter())
                reasons = adapter.GetData(UserID, "IG");

            if (reasons.Count == 0)
                throw new Exception("Отсутствует причина перемещения");

            var reasonID = reasons[0].ReasonCode;

            var context = new ItemMoveRemainsContext()
            {
                Caption = "Потоварный пересорт",
                Description = "Переместите остаток ЖЭ\r\nна стеллаж проблемного товара",
                Action = "Отсканируйте место\r\nстеллажа проблемного товара",
                UserID = UserID,
                WarehouseID = WarehouseID,
                LOCN = LOCN,
                BarcodeYL = RepackItem.barcode_YL,
                StationID = StationID,
                ReasonCode = reasonID,
                ItemID_Fact = factItemID,
                VendorLot_Fact = factVendorLot
            };

            var dlgRepackItemMove = new RepackItemMoveForm(context);
            if (dlgRepackItemMove.ShowDialog() != DialogResult.OK)
                return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

       
    }
}
