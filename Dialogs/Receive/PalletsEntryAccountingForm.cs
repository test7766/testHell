using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using System.Xml;
using WMSOffice.Window;

namespace WMSOffice.Dialogs.Receive
{
    public partial class PalletsEntryAccountingForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Хост
        /// </summary>
        public IHost Host { get; set; }

        /// <summary>
        /// Признак импортной поставки
        /// </summary>
        private bool isImportShipping;

        /// <summary>
        /// Код сессии
        /// </summary>
        public new long UserID { get; set; }

        /// <summary>
        /// Ид-р поставки
        /// </summary>
        public int ShipmentID { get; set; }

        /// <summary>
        /// Код филиала
        /// </summary>
        public int BranchID { get; set; }

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
        /// К-во паллет в режиме "без паллет"
        /// </summary>
        public int? WithoutPalletsQty { get { return string.IsNullOrEmpty(this.tbWithoutPalletsQty.Text) ? (int?)null : Convert.ToInt32(this.tbWithoutPalletsQty.Text); } }

        /// <summary>
        /// Тип операции
        /// </summary>
        public char OperationType { get; set; }

        /// <summary>
        /// Признак работы с блоком грузчиков
        /// </summary>
        public bool CanModifyLoaders 
        {
            get { return canModifyLoaders; }
            private set
            {
                canModifyLoaders = value;
                this.PrepareLoadersLayout();
            }
        }

        private bool canModifyLoaders = true;

        #endregion

        public PalletsEntryAccountingForm()
        {
            InitializeComponent();
        }

        private void PalletsEntryAccountingForm_Load(object sender, EventArgs e)
        {
            CheckIsImportShipping();
            FillLoaders();
        }

        private void PrepareLoadersLayout()
        {
            if (!this.CanModifyLoaders)
            {
                this.tbsLoaders.Enabled = false;
                this.dgvLoaders.ReadOnly = true;

                //gbLoaders.Visible = false;
                //this.Height -= gbLoaders.Height;
            }
        }

        /// <summary>
        /// Проверка поставки на импорт
        /// </summary>
        private void CheckIsImportShipping()
        {
            try
            {
                var isImport = (int?)null;

                using (var adapter = new Data.ReceiveTableAdapters.PalletsForSecureAccountingTableAdapter())
                    adapter.CheckIsImportShipping(this.UserID, this.ShipmentID, ref isImport);

                if (isImport.HasValue)
                    isImportShipping = Convert.ToBoolean(isImport.Value);

                // Инициализация типов паллет
                cbWithoutPallets_CheckedChanged(cbWithoutPallets, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tbsLoaders.TextChanged += new EventHandler(tbsLoaders_TextChanged);

            btnOK.Location = new Point(240, 8);
            btnCancel.Location = new Point(330, 8);
        }

        private void FillLoaders()
        {
            var loaders = this.GetLoaders((int?)null);

            loadersForPalletsBindingSource.DataSource = null;

            receive.LoadersForPallets.Clear();
            receive.LoadersForPallets.Merge(loaders, true);

            loadersForPalletsBindingSource.DataSource = receive.LoadersForPallets;
            loadersForPalletsBindingSource.Sort = string.Format("{0} DESC", receive.LoadersForPallets.LastDateColumn.Caption);

            if (loaders.Count > 0)
                this.CanModifyLoaders = Convert.ToBoolean(loaders[0].CanModif);
        }

        private Data.Receive.LoadersForPalletsDataTable GetLoaders(int? loaderID)
        {
            Data.Receive.LoadersForPalletsDataTable loaders = null;

            try
            {
                var returnFlag = 0; // признак возврата
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

        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void Number_TextChanged(object sender, EventArgs e)
        {
            var tbNumber = sender as TextBox;
            var text = tbNumber.Text;
            if (string.IsNullOrEmpty(text))
                tbNumber.Text = "0";

            //int number;
            //if (int.TryParse(text, out number))
            //{
            //    tbNumber.Text = number.ToString();
            //}
        }

        private void PalletsEntryAccountingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                var ignoreDiffs = 0;
                e.Cancel = !this.SaveData(ignoreDiffs);
            }
        }

        /// <summary>
        /// Сохранение данных
        /// </summary>
        /// <returns></returns>
        private bool SaveData(int ignoreDiffs)
        {
            try
            {
                if (this.ValidateData())
                {
                    var loaders = this.GetCheckedLoaders();

                    //Data.Receive.SetPlanPalletsForSecureAccountingResponseRow response = null;
                    using (var adapter = new Data.ReceiveTableAdapters.PalletsForSecureAccountingTableAdapter())
                        adapter.SetFactData(
                               this.UserID,
                               this.ShipmentID,
                               this.StandartPalletsQty,
                               this.EuroPalletsQty,
                               this.PlasticPalletsQty,
                               this.OperationType.ToString(),
                               cbWithoutPallets.Checked,
                               this.WithoutPalletsQty,
                               loaders,
                               this.BranchID, 
                               ignoreDiffs);

                    //// Печать акта приема-передачи при разгрузке
                    //MessageBox.Show("Запущена печать акта приема-передачи тары при разгрузке.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //this.PrintTareReceivingActReport();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                var message = ex.Message;

                // Проверка соответствия кол-ва паллет в приходной накладной не пройдена.
                if (ex.Message.Contains("ErrorPalletsPurchaseOrder"))
                {
                    if (MessageBox.Show("Введеные количество или тип паллет не соответсвуют данным ТТН.\nПодтвердите правильность данных.",
                        "Количество паллет в приходе", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        return false;
                    else
                    {
                        try
                        {
                            //// Печать акта приема-передачи при разгрузке
                            //MessageBox.Show("Запущена печать акта приема-передачи тары при разгрузке.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //this.PrintTareReceivingActReport();
                            return true;
                        }
                        catch (Exception exx)
                        {
                            MessageBox.Show(exx.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    #region Формирование и печать акта несоответствия (не печатается согласно ТЗ-15)
                    //try
                    //{
                    //    // Печатаем акт несоответствия при разгрузке поставки
                    //    MessageBox.Show("Запущена печать акта несоответствия.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    PrintPalletVarianceAct();
                    //    return true;
                    //}
                    //catch (Exception iex)
                    //{
                    //    MessageBox.Show(iex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return false;
                    //}
                    #endregion
                }
                else if (ex.Message.Contains("#DIFFERROR#"))
                {
                    var regex = new System.Text.RegularExpressions.Regex(@"^#DIFFERROR#(?<msg>.+)#", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                    if (regex.IsMatch(ex.Message))
                    {
                        message = regex.Match(ex.Message).Groups["msg"].Value;

                        var dlgOrders = new OrdersByShipmentForm(this.Host, this.ShipmentID, message);
                        if (dlgOrders.ShowDialog() == DialogResult.OK)
                        {
                            ignoreDiffs = 1;
                            var saveResult = this.SaveData(ignoreDiffs);
                            return saveResult;
                        }
                        else
                            return false;
                    }
                }
                

                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ValidateData()
        {
            try
            {
                if (!cbWithoutPallets.Checked && (this.StandartPalletsQty ?? 0) + (this.EuroPalletsQty ?? 0) + (this.PlasticPalletsQty ?? 0) == 0)
                    throw new Exception("Укажите хотя бы одно положительное количество\r\nпо ТИПАМ ПАЛЛЕТ.");

                if (cbWithoutPallets.Checked && (this.WithoutPalletsQty ?? 0) == 0)
                    throw new Exception("Укажите положительное количество\r\nБЕЗ ПАЛЛЕТ.");

                if (this.CanModifyLoaders)
                {
                    var cntLoaders = (int)receive.LoadersForPallets.Compute(
                        string.Format("COUNT({0})", receive.LoadersForPallets.OptionColumn.Caption),
                        string.Format("{0} = 1", receive.LoadersForPallets.OptionColumn.Caption));
                    if (cntLoaders == 0)
                        throw new Exception("Укажите одного или нескольких грузчиков.");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetCheckedLoaders()
        {
            if (!this.CanModifyLoaders)
                return (string)null;

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
        /// Формирование и печать акта несоответствия при разгрузке поставки
        /// </summary>
        private void PrintPalletVarianceAct()
        {
            var dataSource = new WMSOffice.Data.Receive();
            using (var adapter = new Data.ReceiveTableAdapters.PalletVarianceActTableAdapter())
                adapter.Fill(dataSource.PalletVarianceAct, this.UserID, this.ShipmentID);

            var report = new WMSOffice.Reports.PalletVarianceActReport();
            report.SetDataSource(dataSource);
            report.PrintToPrinter(2, true, 1, 0);
        }

        /// <summary>
        /// Печать акта приема-передачи оборотной тары
        /// </summary>
        [Obsolete]
        private void PrintTareReceivingActReport()
        {
            PalletsEntryAccountingForm.PrintTareReceivingActReport(this.UserID, this.ShipmentID);
        }

        /// <summary>
        /// Печать акта приема-передачи оборотной тары при разгрузке
        /// </summary>
        /// <param name="userID">Код сессии</param>
        /// <param name="shipmentID">Ид-р поставки</param>
        public static void PrintTareReceivingActReport(long userID, int shipmentID)
        {
            var dataSource = new WMSOffice.Data.Receive();
            using (var adapter = new Data.ReceiveTableAdapters.PalletsReceivingActTableAdapter())
                adapter.Fill(dataSource.PalletsReceivingAct, userID, shipmentID);

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

            var report = new WMSOffice.Reports.PalletsTareReceivingActReport();
            report.SetDataSource(dataSource);
            report.PrintToPrinter(1, true, 1, 0);
        }

        private void cbWithoutPallets_CheckedChanged(object sender, EventArgs e)
        {
            if (cbWithoutPallets.Checked)
            {
                tbStandartPalletsQty.Text = "0";
                tbEuroPalletsQty.Text = "0";
                tbPlasticPalletsQty.Text = "0";
            }
            else
            {
                tbWithoutPalletsQty.Text = "0";
            }

            tbStandartPalletsQty.ReadOnly = isImportShipping ? true : cbWithoutPallets.Checked;
            tbEuroPalletsQty.ReadOnly = cbWithoutPallets.Checked;
            tbPlasticPalletsQty.ReadOnly = isImportShipping ? true : cbWithoutPallets.Checked;

            tbWithoutPalletsQty.Visible = cbWithoutPallets.Checked;

            if (cbWithoutPallets.Checked)
            {
                tbWithoutPalletsQty.Focus();
                //tbWithoutPalletsQty.SelectionStart = 1;
                //tbWithoutPalletsQty.SelectionLength = 0;
            }
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
