using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class RepackItemCheckRegradingUnitSeries : Form
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

        #endregion

        public RepackItemCheckRegradingUnitSeries()
        {
            InitializeComponent();
        }

        public RepackItemCheckRegradingUnitSeries(Data.WH.RepackMainDisplayCurrentTasksRow repackItem)
            : this()
        {
            RepackItem = repackItem;
        }

        private void RepackItemCheckRegradingUnitSeries_Load(object sender, EventArgs e)
        {
            lblUnitSeries.Text = string.Format("{0}", RepackItem.IsIORLOTNull() ? string.Empty : RepackItem.IORLOT);
            lblUnit.Text = string.Format("{0} ({1})", RepackItem.IsnazvaNull() ? string.Empty : RepackItem.nazva, RepackItem.IMITM);
        }

        private void btnConfirmUnitSeries_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnBeginRegradeUnitSeries_Click(object sender, EventArgs e)
        {
            var factItemID = (int?)null;
            var factVendorLot = (string)null;

            #region УСТАНОВКА ФАКТИЧЕСКОЙ СЕРИИ

            var dlgSetFactUnitSeries = new RepackItemSetFactUnitSeries()
            {
                UserID = UserID,
                ItemID = Convert.ToInt32(RepackItem.IMITM),
                WarehouseID = WarehouseID
            };
            if (dlgSetFactUnitSeries.ShowDialog() != DialogResult.OK)
                return;

            factVendorLot = dlgSetFactUnitSeries.VendorLot_Fact;

            #endregion

            Data.WH.RepackItemCancelReasonsDataTable reasons = null;
            using (var adapter = new Data.WHTableAdapters.RepackItemCancelReasonsTableAdapter())
                reasons = adapter.GetData(UserID, "IL");

            if (reasons.Count == 0)
                throw new Exception("Отсутствует причина перемещения");

            var reasonID = reasons[0].ReasonCode;

            var context = new ItemMoveRemainsContext()
            {
                Caption = "Посерийный пересорт",
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
