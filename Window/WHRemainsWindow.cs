using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.WH.PL;

namespace WMSOffice.Window
{
    public partial class WHRemainsWindow : GeneralWindow
    {
        /// <summary>
        /// Таймаут для получения данных
        /// </summary>
        private const Int32 RESPONSE_WAIT_TIMEOUT = 300; // 5 минут

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Возвращает одну (последнюю) выделенную строку из списка остатков.
        /// </summary>
        private Data.WH.PL_RemainsRow SelectedRow
        {
            get
            {
                if (dgvResponse.SelectedRows.Count == 0)
                    return null;
                else
                    return (Data.WH.PL_RemainsRow)((DataRowView)dgvResponse.SelectedRows[0].DataBoundItem).Row;
            }
        }

        [Obsolete]
        private CheckedListBox clbWarehouseSelector = new CheckedListBox();

        [Obsolete]
        private WMSOffice.Controls.PopupWindow popup;

        public WHRemainsWindow()
        {
            InitializeComponent();
            this.Initialize();
        }

        /// <summary>
        /// Инициализация
        /// </summary>
        [Obsolete]
        private void Initialize()
        {
            ////clbWarehouseSelector.Height = 200;
            //clbWarehouseSelector.Width = 250;

            //popup = new WMSOffice.Controls.PopupWindow(clbWarehouseSelector);

            //for (int i = 0; i < 15; i++)
            //    clbWarehouseSelector.Items.Add(string.Format("item № {0} was added successfully", i), true);         
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            miPrintSSCC.Enabled = false;
        }

        private void dgvResponse_SelectionChanged(object sender, EventArgs e)
        {
            miPrintSSCC.Enabled = this.SelectedRow != null && !this.SelectedRow.IsSSCCNull() && !String.IsNullOrEmpty(this.SelectedRow.SSCC);
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        #region Фоновая загрузка данных
        private void RefreshData()
        {
            try
            {
                BackgroundWorker loadWorker = new BackgroundWorker();
                loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
                loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
                waitProcessForm.ActionText = "Получение данных...";
                this.wHRemainsBindingSource.DataSource = null;

                var filter = new RemainsFilter(
                    tbWarehouse.Text,
                    tbItemID.Text,
                    tbLocation.Text,
                    tbVendorLot.Text,
                    tbLotNumber.Text,
                    tbSSCC.Text,
                    tbLots.Text,
                    cbHideZeroQuantity.Checked,
                    cbWithSSCCRemains.Checked);

                loadWorker.RunWorkerAsync(filter);
                waitProcessForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var filter = e.Argument as RemainsFilter;
                e.Result = this.GetRemains(filter);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Получение остатков по фильтру
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        private Data.WH.PL_RemainsDataTable GetRemains(RemainsFilter filter)
        {
            this.pL_RemainsTableAdapter.SetTimeout(RESPONSE_WAIT_TIMEOUT);

            var result = this.pL_RemainsTableAdapter.GetData(
                             this.UserID,
                             filter.WarehouseID,
                             filter.ItemID,
                             filter.LotNumber,
                             filter.VendorLot,
                             filter.Lots,
                             filter.Location,
                             filter.SSCC,
                             filter.WithSSCCRemains,
                             filter.HideZeroQuantity);

            return result;
        }

        void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                this.ShowError(e.Result as Exception);
                this.wH.PL_Remains.Clear();
            }
            else
            {
                this.wHRemainsBindingSource.DataSource = e.Result;
            }

            waitProcessForm.CloseForce();
        }

        /// <summary>
        /// Фильтр остатков
        /// </summary>
        private class RemainsFilter
        {
            #region ПОЛЯ И СВОЙСТВА
            /// <summary>
            /// Код склада
            /// </summary>
            public String WarehouseID { get; private set; }

            /// <summary>
            /// Код товара
            /// </summary>
            public Int32? ItemID { get; private set; }

            /// <summary>
            /// Ячейка
            /// </summary>
            public String Location { get; private set; }

            /// <summary>
            /// Серия
            /// </summary>
            public String VendorLot { get; private set; }

            /// <summary>
            /// Партия
            /// </summary>
            public String LotNumber { get; private set; }

            /// <summary>
            /// Ид-р пак-листа
            /// </summary>
            public String SSCC { get; private set; }

            /// <summary>
            /// Код блокировки
            /// </summary>
            public String Lots { get; private set; }

            /// <summary>
            /// Скрывать нулевые количества
            /// </summary>
            public Boolean HideZeroQuantity { get; private set; }

            /// <summary>
            /// Отображать остаток SSCC
            /// </summary>
            public Boolean WithSSCCRemains { get; private set; }

            #endregion

            #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
            public RemainsFilter(String warehouseID, String itemID, String cell, String vendorLot, String lotNumber, String _SSCC, String lots, Boolean hideZeroQtty, Boolean withSSCCRemains)
            {
                this.WarehouseID = String.IsNullOrEmpty(warehouseID) ? null : warehouseID;

                try
                {
                    this.ItemID = String.IsNullOrEmpty(itemID) ? (Int32?)null : Convert.ToInt32(itemID);
                }
                catch
                {
                    throw new Exception("Код товара должен быть числом!");
                }
                
                this.Location = String.IsNullOrEmpty(cell) ? null : cell;
                this.VendorLot = String.IsNullOrEmpty(vendorLot) ? null : vendorLot;
                this.LotNumber = String.IsNullOrEmpty(lotNumber) ? null : lotNumber;
                this.SSCC = String.IsNullOrEmpty(_SSCC) ? null : _SSCC;
                this.Lots = String.IsNullOrEmpty(lots) ? null : lots[0].ToString();
                this.HideZeroQuantity = hideZeroQtty;
                this.WithSSCCRemains = withSSCCRemains;
            }
            #endregion
        }
        #endregion

        private void tbItemID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // TODO Отключил ввод только цифр для возможности вставки из буфера

            //if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            //    e.Handled = true;
        }

        private void sbPrintSSCCBarCode_Click(object sender, EventArgs e)
        {
            this.CreateSSCCBarCodes(null);
        }

        private void miPrintSSCC_Click(object sender, EventArgs e)
        {
            this.CreateSSCCBarCodes(this.SelectedRow.SSCC);
        }

        #region Фоновая печать этикеток на ПЛ
        /// <summary>
        /// SSCC
        /// </summary>
        /// <param name="sscc"></param>
        private void CreateSSCCBarCodes(String sscc)
        {
             var dialog = new SetPLLabelPrintProperties() { UserID = this.UserID, UseNewLabelPrintMode = sscc == null };
             if (dialog.ShowDialog() == DialogResult.OK)
             {
                 var parameters = new SSCC_LabelPrintParameters(dialog.Quantity, dialog.SelectedPrinter, sscc, dialog.SelectedSSCCTypeName, dialog.SelectedSSCCTypeDescription);

                 BackgroundWorker printWorker = new BackgroundWorker();
                 printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                 printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                 waitProcessForm.ActionText = "Печать наклеек на ПЛ...";
                 printWorker.RunWorkerAsync(parameters);
                 waitProcessForm.ShowDialog();
             }
        }

        void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = e.Argument as SSCC_LabelPrintParameters;
                    this.pL_RemainsTableAdapter.CreateSSCCBarCodes(parameters.Quantity, parameters.PrinterID, parameters.SSCC, parameters.SSCCTypeName, parameters.SSCCTypeDescription, this.UserID);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                this.ShowError(e.Result as Exception);
            else
            { }

            this.waitProcessForm.CloseForce();
        }

        /// <summary>
        /// Параметры печати этикеток SSCC
        /// </summary>
        private class SSCC_LabelPrintParameters
        {
            #region ПОЛЯ И СВОЙСТВА КЛАССА
            /// <summary>
            /// Кол-во
            /// </summary>
            public Int32 Quantity { get; private set; }

            /// <summary>
            /// Ид-р принтера
            /// </summary>
            public String PrinterID { get; private set; }

            /// <summary>
            /// SSCC
            /// </summary>
            public String SSCC { get; private set; }

            /// <summary>
            /// Название типа SSCC
            /// </summary>
            public String SSCCTypeName { get; private set; }

            /// <summary>
            /// Описание типа SSCC
            /// </summary>
            public String SSCCTypeDescription { get; private set; }

            #endregion

            #region КОНСТРУКТОР

            public SSCC_LabelPrintParameters(Int32 qtty, String printerID, String sscc, String pSSCCTypeName, String pSSCCTypeDescription)
            {
                this.Quantity = qtty;
                this.PrinterID = printerID;
                this.SSCC = sscc;
                this.SSCCTypeName = pSSCCTypeName;
                this.SSCCTypeDescription = pSSCCTypeDescription;
            }

            #endregion
        }
        #endregion

        #region Пока не используется - селектор складов отсутствует
        private void tbWarehouse_MouseClick(object sender, MouseEventArgs e)
        {
            //this.ShowPopup(tbWarehouse, tbWarehouse.ClientRectangle);
        }

        private void WHRemainsWindow_Load(object sender, EventArgs e)
        {

        }

        //private void ShowPopup(Control owner, Rectangle area)
        //{
        //    Point location = owner.PointToScreen(new Point(area.Left, area.Top + area.Height));
        //    Rectangle screen = Screen.FromControl(owner).WorkingArea;
        //    if (location.X + Size.Width > (screen.Left + screen.Width))
        //    {
        //        location.X = (screen.Left + screen.Width) - Size.Width;
        //    }
        //    if (location.Y + Size.Height > (screen.Top + screen.Height))
        //    {
        //        location.Y -= Size.Height + area.Height;
        //    }
        //    location = owner.PointToClient(location);
        //    popup.Show(owner, location, ToolStripDropDownDirection.BelowRight);

        //    //popup.Show(new Point(100, 100));
        //}
        #endregion
    }
        
}
