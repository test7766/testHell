using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using System.Xml;

namespace WMSOffice.Dialogs.Receive
{
    public partial class PalletsForReturnByDateDialog : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА КЛАССА
        /// <summary>
        /// Код сессии
        /// </summary>
        public new long UserID { get; set; }

        /// <summary>
        /// Ид-р поставки
        /// </summary>
        public int? ShipmentID { get; private set; }

        /// <summary>
        /// Код филиала
        /// </summary>
        public int BranchID { get; private set; }

        /// <summary>
        /// Признак самовывоза
        /// </summary>
        public bool SelfDelivery { get; private set; }

        /// <summary>
        /// Признак фиксации возврата паллет
        /// </summary>
        public bool PalletsReturnsFlagFixed { get; private set; }
        #endregion
         
        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public PalletsForReturnByDateDialog()
        {
            InitializeComponent();
        }

        public PalletsForReturnByDateDialog(int shipmentID, int branchID, bool selfDelivery)
            : this()
        {
            this.ShipmentID = shipmentID;
            this.BranchID = branchID;
            this.SelfDelivery = selfDelivery;
        }

        /// <summary>
        /// Инициализация
        /// </summary>
        private void Initialize()
        {
            try
            {
                this.PalletsReturnsFlagFixed = true;
                using (var adapter = new Data.ReceiveTableAdapters.FixFlagPalletsForReturnResponseTableAdapter())
                    this.PalletsReturnsFlagFixed = adapter.GetData(this.UserID, this.ShipmentID)[0].FixFlag;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Если признак фиксации возврата паллет был ранее установлен
            if (PalletsReturnsFlagFixed)
            {
                this.btnOK.Visible = false;
                this.btnCancel.Text = "Закрыть";
                this.dgvPalletsForReturn.ReadOnly = true;

                this.tbsLoaders.Enabled = false;
                this.dgvLoaders.ReadOnly = true;
            }
        }
        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tbsLoaders.TextChanged += new EventHandler(tbsLoaders_TextChanged);

            this.btnOK.Location = new Point(240, 8); // 107
            this.btnOK.Width = 80;

            this.btnCancel.Location = new Point(330, 8); // 197
            this.btnCancel.Width = 80;
            //this.btnCancel.Text = "Запроса нет";

            this.Initialize();
            this.ReloadData(false);

            this.FillLoaders();
        }

        private void FillLoaders()
        {
            var loaders = this.GetLoaders((int?)null);

            loadersForPalletsBindingSource.DataSource = null;

            receive.LoadersForPallets.Clear();
            receive.LoadersForPallets.Merge(loaders, true);

            loadersForPalletsBindingSource.DataSource = receive.LoadersForPallets;
            loadersForPalletsBindingSource.Sort = string.Format("{0} DESC", receive.LoadersForPallets.LastDateColumn.Caption);
        }

        private Data.Receive.LoadersForPalletsDataTable GetLoaders(int? loaderID)
        {
            Data.Receive.LoadersForPalletsDataTable loaders = null;

            try
            {
                var returnFlag = 1; // признак возврата
                loaders = loadersForPalletsTableAdapter.GetDataExt(this.UserID, this.ShipmentID, this.BranchID, loaderID, returnFlag);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return loaders;
        }

        private void CheckLoader(int loaderID)
        {
            var loaders = this.GetLoaders(loaderID);

            if (loaders.Rows.Count == 0)
                throw new Exception(string.Format("Грузчик с кодом {0} не найден.", loaderID));

            foreach (Data.Receive.LoadersForPalletsRow loader in loaders)
            {
                var checkedLoader = receive.LoadersForPallets.FindByUserID(loaderID);
                if (checkedLoader != null)
                {
                    checkedLoader.Option = true;
                    checkedLoader.LastDate = DateTime.Now;
                }
                else
                {
                    checkedLoader = receive.LoadersForPallets.NewLoadersForPalletsRow();
                    checkedLoader.ItemArray = loader.ItemArray;
                    checkedLoader.Option = true;
                    checkedLoader.LastDate = DateTime.Now;
                    checkedLoader.TotalQty = 0;
                    receive.LoadersForPallets.AddLoadersForPalletsRow(checkedLoader);
                }

                break;
            }

            dgvLoaders.FirstDisplayedScrollingRowIndex = 0;
            dgvLoaders.Rows[0].Selected = false;
        }

        /// <summary>
        /// Загрузка данных по возвратам
        /// </summary>
        /// <param name="analizeReturns">Признак наличия анализа вводимых возвратов по задолженности поставщика</param>
        private void ReloadData(bool analizeReturns)
        {
            try
            {
                int? qSPallet = analizeReturns ? this.receive.PalletsForReturnByDate[0].Qty : (int?)null;
                int? qEPallet = analizeReturns ? this.receive.PalletsForReturnByDate[1].Qty : (int?)null;
                int? qPPallet = analizeReturns ? this.receive.PalletsForReturnByDate[2].Qty : (int?)null;

                this.palletsForReturnByDateTableAdapter.Fill(this.receive.PalletsForReturnByDate, this.UserID, this.ShipmentID, qSPallet, qEPallet, qPPallet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPalletsForReturn_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int totalQty = 0;
            bool allowReturn = !this.PalletsReturnsFlagFixed;

            // Расчет общего кол-ва паллет к возврату и признак возможности возврата
            foreach (DataGridViewRow row in this.dgvPalletsForReturn.Rows)
            {
                var boundRow = (row.DataBoundItem as DataRowView).Row as Data.Receive.PalletsForReturnByDateRow;
                
                totalQty += boundRow.Qty;
                allowReturn &= boundRow.Flag;
            }

            this.tbTotalPalletsForReturn.Text = totalQty.ToString();
            this.btnOK.Enabled = allowReturn;
        }

        private void dgvPalletsForReturn_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var row = (dgvPalletsForReturn.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Receive.PalletsForReturnByDateRow;
            Color color = !row.IsFlagNull() && row.Flag ? Color.FromArgb(209, 255, 117) : Color.Salmon;

            if (dgvPalletsForReturn.Columns[e.ColumnIndex].DataPropertyName == this.receive.PalletsForReturnByDate.QtyColumn.Caption)
            {
                dgvPalletsForReturn.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = color;
                dgvPalletsForReturn.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = color;
            }
        }

        private void dgvPalletsForReturn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit) && e.Exception != null)
            {
                if (this.dgvPalletsForReturn.Columns[e.ColumnIndex].DataPropertyName == this.receive.PalletsForReturnByDate.QtyColumn.Caption)
                {
                    MessageBox.Show("Количество должно быть целым числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPalletsForReturn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            try
            {
                #region ОКОНЧАТЕЛЬНОЕ СОХРАНЕНИЕ ВЫПОЛНЯЕТСЯ ТОЛЬКО ПЕРЕД МОМЕНТОМ ФИКСАЦИИ ВОЗВРАТА
                //// Сохраняем количество паллет указанного типа к возврату
                //var row = (this.dgvPalletsForReturn.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Receive.PalletsForReturnByDateRow; 
                //this.palletsForReturnByDateTableAdapter.SavePalletsQuantity(this.UserID, this.ShipmentID, row.Type_ID, row.Qty);
                #endregion

                // Перечитываем данные
                this.ReloadData(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PalletsForReturnByDateDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.FixPalletsReturns();
        }

        /// <summary>
        /// Фиксация возврата оборотной тары 
        /// </summary>
        /// <returns></returns>
        private bool FixPalletsReturns()
        {
            try
            {
                // Сохранение возвратов
                this.SaveReturnsQuantity();

                // Печать акта приема-передачи при возврате
                MessageBox.Show("Запущена печать акта приема-передачи тары при возврате.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.PrintTareReceivingActReport();
                
                // Фиксируем возврат
                using (var adapter = new Data.ReceiveTableAdapters.FixFlagPalletsForReturnResponseTableAdapter())
                    adapter.SetFixFlag(this.UserID, this.ShipmentID);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Сохранение возвратов
        /// </summary>
        private void SaveReturnsQuantity()
        {
            #region OBSOLETE
            //foreach (Data.Receive.PalletsForReturnByDateRow palletReturnsInfo in this.receive.PalletsForReturnByDate)
            //    this.palletsForReturnByDateTableAdapter.SavePalletsQuantity(this.UserID, this.ShipmentID, palletReturnsInfo.Type_ID, palletReturnsInfo.Qty);
            #endregion

            if (this.ValidateData())
            {
                int? qSPallet = this.receive.PalletsForReturnByDate[0].Qty;
                int? qEPallet = this.receive.PalletsForReturnByDate[1].Qty;
                int? qPPallet = this.receive.PalletsForReturnByDate[2].Qty;

                var loaders = this.GetCheckedLoaders();

                this.palletsForReturnByDateTableAdapter.SaveAllPalletsQuantity(this.UserID, this.ShipmentID, qSPallet, qEPallet, qPPallet, loaders, this.BranchID);
            }
        }

        private bool ValidateData()
        {
            try
            {
                var cntLoaders = (int)receive.LoadersForPallets.Compute(
                    string.Format("COUNT({0})", receive.LoadersForPallets.OptionColumn.Caption),
                    string.Format("{0} = 1", receive.LoadersForPallets.OptionColumn.Caption));
                if (cntLoaders == 0)
                    throw new Exception("Укажите одного или нескольких грузчиков.");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetCheckedLoaders()
        {
            var isLoadersSelected = false;

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml("<Loaders></Loaders>");

            XmlElement xRoot = xDoc.DocumentElement;
            foreach (Data.Receive.LoadersForPalletsRow loader in receive.LoadersForPallets.Rows)
            {
                if (loader.Option)
                {
                    var xElement = xDoc.CreateElement("Loader");

                    var xValue = xElement.Attributes.Append(xDoc.CreateAttribute("ID"));
                    xValue.Value = loader.UserID.ToString();

                    xValue = xElement.Attributes.Append(xDoc.CreateAttribute("TotalQty"));
                    xValue.Value = (loader.IsTotalQtyNull() ? 0 : loader.TotalQty).ToString();

                    xRoot.AppendChild(xElement);

                    isLoadersSelected = true;
                }
            }

            if (!isLoadersSelected)
                return (string)null;

            return xDoc.InnerXml;
        }

        /// <summary>
        /// Печать акта приема-передачи при возврате
        /// </summary>
        private void PrintTareReceivingActReport()
        {
            
            PalletsForReturnByDateDialog.PrintTareReceivingActReport(this.UserID, this.ShipmentID.Value, this.SelfDelivery);
        }

        /// <summary>
        /// Печать акта приема-передачи оборотной тары при возврате
        /// </summary>
        /// <param name="userID">Код сессии</param>
        /// <param name="shipmentID">Ид-р поставки</param>
        public static void PrintTareReceivingActReport(long userID, int shipmentID, bool selfDelivery)
        {
            var dataSource = new WMSOffice.Data.Receive();
            using (var adapter = new Data.ReceiveTableAdapters.PalletsReceivingActTableAdapter())
                adapter.FillReturnAct(dataSource.PalletsReceivingAct, userID, shipmentID);

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
            report.SetParameterValue(report.Parameter_SelfDelivery.ParameterFieldName, selfDelivery);
            report.PrintToPrinter(2, true, 1, 0);
        }

        #region НАСТРОЙКА ВЗАИМОДЕЙСТВИЯ СО СПРАВОЧНИКОМ ГРУЗЧИКОВ

        void tbsLoaders_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbsLoaders.Text))
                this.CheckLoader();
        }

        private void CheckLoader()
        {
            try
            {
                int loaderID;
                if (!int.TryParse(tbsLoaders.Text, out loaderID))
                    throw new Exception("Код грузчика должен быть числом.");

                this.CheckLoader(loaderID);

                tbsLoaders.Text = string.Empty;
                tbsLoaders.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                tbsLoaders.Focus();
                tbsLoaders.SelectAll();
            }
        }

        private void dgvLoaders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            bool isChecked = Convert.ToBoolean(this.dgvLoaders.Rows[e.RowIndex].Cells[this.optionDataGridViewCheckBoxColumn.Index].Value);
            this.dgvLoaders.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            this.dgvLoaders.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
        }

        private void dgvLoaders_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLoaders.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvLoaders.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool isChecked = Convert.ToBoolean(this.dgvLoaders.Rows[this.dgvLoaders.CurrentRow.Index].Cells[this.optionDataGridViewCheckBoxColumn.Index].Value);
                foreach (DataGridViewColumn column in this.dgvLoaders.Columns)
                {
                    this.dgvLoaders.Rows[this.dgvLoaders.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    this.dgvLoaders.Rows[this.dgvLoaders.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
                }

                if (!isChecked)
                    this.dgvLoaders.Rows[this.dgvLoaders.CurrentRow.Index].Cells[TotalQty.Name].Value = 0;
            }
        }

        private void dgvLoaders_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var loaderInfo = (this.dgvLoaders.Rows[this.dgvLoaders.CurrentRow.Index].DataBoundItem as DataRowView).Row as Data.Receive.LoadersForPalletsRow;
            var allowEdit = loaderInfo.Option;

            if (!this.dgvLoaders.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode && allowEdit)
            {
                this.dgvLoaders.CurrentCell = this.dgvLoaders.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.dgvLoaders.BeginEdit(true);
            }
        }

        private void dgvLoaders_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dgvLoaders.Columns[dgvLoaders.CurrentCell.ColumnIndex] == dgvLoaders.Columns[TotalQty.Name])
            {
                var loaderInfo = (this.dgvLoaders.Rows[this.dgvLoaders.CurrentRow.Index].DataBoundItem as DataRowView).Row as Data.Receive.LoadersForPalletsRow;
                var allowEdit = loaderInfo.Option;

                if (!allowEdit)
                    this.dgvLoaders.EndEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvLoaders_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == dgvLoaders.Columns[TotalQty.Name].Index)
            {
                if (e.Exception != null)
                {
                    var context = (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit);
                    if ((e.Context | DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit) == context)
                    {
                        if (e.Exception.GetType() == typeof(FormatException))
                        {
                            MessageBox.Show(string.Format("Σ к-во должно быть числом.", dgvLoaders.Columns[e.ColumnIndex].HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
