using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Receive
{
    public partial class PalletsWriteOffAccountingForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА КЛАССА

        /// <summary>
        /// По неизвестным причинам событие закрытия формы вызывается повторно после закрытия главной формы (привязка Owner)
        /// </summary>
        private bool lockSave = false;

        /// <summary>
        /// Код сессии
        /// </summary>
        public new long UserID { get; set; }

        /// <summary>
        /// Ид-р поставщика
        /// </summary>
        public int VendorID { get; set; }

        /// <summary>
        /// К-во стандартных паллет
        /// </summary>
        public int? StandartPalletsQty { get { return string.IsNullOrEmpty(this.tbStandartPalletsQty.Text) ? (int?)null : Convert.ToInt32(this.tbStandartPalletsQty.Text); } }

        /// <summary>
        /// К-во евро-паллет
        /// </summary>
        public int? EuroPalletsQty { get { return string.IsNullOrEmpty(this.tbEuroPalletsQty.Text) ? (int?)null : Convert.ToInt32(this.tbEuroPalletsQty.Text); } }

        /// <summary>
        /// К-во пластиковых паллет
        /// </summary>
        public int? PlasticPalletsQty { get { return string.IsNullOrEmpty(this.tbPlasticPalletsQty.Text) ? (int?)null : Convert.ToInt32(this.tbPlasticPalletsQty.Text); } }
        #endregion

        public PalletsWriteOffAccountingForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(110, 8);
            btnCancel.Location = new Point(200, 8);
        }

        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void PalletsEntryAccountingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        /// <summary>
        /// Сохранение данных
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {
            try
            {
                if (lockSave)
                    return true;

                var shipmentID = (int?)null;

                using (var adapter = new Data.ReceiveTableAdapters.PalletsForSecureAccountingTableAdapter())
                    adapter.WriteOffPallet(
                           this.UserID,
                           this.VendorID,
                           this.StandartPalletsQty,
                           this.EuroPalletsQty,
                           this.PlasticPalletsQty,
                           ref shipmentID);

                //TODO -> для теста 
                //shipmentID = 59928;

                // Печать акта приема-передачи
                PrintPalletsReceivingAct(shipmentID);

                lockSave = true;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Формирование и печать акта приема-передачи тары
        /// </summary>
        private void PrintPalletsReceivingAct(int? shipmentID)
        {
            var dataSource = new WMSOffice.Data.Receive();
            using (var adapter = new Data.ReceiveTableAdapters.PalletsReceivingActTableAdapter())
                adapter.FillReturnAct(dataSource.PalletsReceivingAct, this.UserID, shipmentID);

            #region ПОЛУЧЕНИЕ ИЗОБРАЖЕНИЯ Ш/К
            BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
            barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
            barCodeCtrl.Size = new Size(274 * 5, 108 * 5);
            barCodeCtrl.BarCodeHeight = 50 * 5;
            barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 12 * 5, FontStyle.Bold);
            barCodeCtrl.HeaderText = "";
            barCodeCtrl.LeftMargin = 10 * 5;
            barCodeCtrl.ShowFooter = true;
            barCodeCtrl.TopMargin = 20 * 5;
            barCodeCtrl.BarCode = dataSource.PalletsReceivingAct[0].Bar_Code;
            byte[] barCode = null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                barCode = ms.ToArray();
            }
            dataSource.PalletsReceivingAct[0].Bar_Code_Image = barCode;
            #endregion

            var report = new WMSOffice.Reports.PalletsReceivingActReport();
            report.SetDataSource(dataSource);
            report.SetParameterValue(report.Parameter_SelfDelivery.ParameterFieldName, false);
            report.PrintToPrinter(1, true, 1, 0);
        }
    }
}
