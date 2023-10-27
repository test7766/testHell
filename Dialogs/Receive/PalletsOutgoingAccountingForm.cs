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
    public partial class PalletsOutgoingAccountingForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА КЛАССА
        /// <summary>
        /// Код сессии
        /// </summary>
        public new long UserID { get; set; }

        /// <summary>
        /// Ид-р поставки
        /// </summary>
        public int ShipmentID { get; set; }

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

        /// <summary>
        /// Тип операции
        /// </summary>
        public char OperationType { get; set; }
        #endregion

        public PalletsOutgoingAccountingForm()
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

        private void PalletsOutgoingAccountingForm_FormClosing(object sender, FormClosingEventArgs e)
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
                using (var adapter = new Data.ReceiveTableAdapters.PalletsForSecureAccountingTableAdapter())
                    adapter.SetFactData(
                                this.UserID,
                                this.ShipmentID,
                                this.StandartPalletsQty,
                                this.EuroPalletsQty,
                                this.PlasticPalletsQty,
                                this.OperationType.ToString(),
                                null,
                                null,
                                null,
                                null,
                                null);

                // Печатаем акт приема-передачи тары
                MessageBox.Show("Запрос принят.\nЗапущена печать акта приема-передачи.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                PrintPalletsReceivingAct();
                return true;
            }
            catch (Exception ex)
            {
                // Проверка соответствия запроса к возврату задолженности не пройдена
                if (ex.Message.Contains("VerifyComplianceReturnDebt"))
                {
                    #region Формирование и печать акта установления расхождений
                    try
                    {
                        // Печатаем акт установления расхождений при возврате
                        MessageBox.Show("Запрос отклонен.\nЗапущена печать акта установления расхождений.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        PrintPalletVarianceFindAct();
                        return true;
                    }
                    catch (Exception iex)
                    {
                        MessageBox.Show(iex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    #endregion
                }

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }        
        }

        /// <summary>
        /// Формирование и печать акта приема-передачи тары
        /// </summary>
        private void PrintPalletsReceivingAct()
        {
            var dataSource = new WMSOffice.Data.Receive();
            using (var adapter = new Data.ReceiveTableAdapters.PalletsReceivingActTableAdapter())
                adapter.Fill(dataSource.PalletsReceivingAct, this.UserID, this.ShipmentID);

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
            report.PrintToPrinter(2, true, 1, 0);
        }

        /// <summary>
        /// Формирование и печать акта установления расхождений при возврате
        /// </summary>
        private void PrintPalletVarianceFindAct()
        {
            var dataSource = new WMSOffice.Data.Receive();
            using (var adapter = new Data.ReceiveTableAdapters.PalletVarianceFindActTableAdapter())
                adapter.Fill(dataSource.PalletVarianceFindAct, this.UserID, this.ShipmentID);

            var report = new WMSOffice.Reports.PalletVarianceFindActReport();
            report.SetDataSource(dataSource);
            report.PrintToPrinter(2, true, 1, 0);
        }

    }
}
