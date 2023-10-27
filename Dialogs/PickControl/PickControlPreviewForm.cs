using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Window;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class PickControlPreviewForm : DialogForm
    {
        private readonly int userID;
        private readonly long docID;

        private double numPickSlip = -1; // номер сборочного листа
        private byte isCold = 0; // признак холодильного оборудования (0 - не используется)
        private bool isPlasticBox = false; // признак является ли ящик пластиковым

        public string RecommendedTare { get; set; }

        public bool IsNTVRegistrationModeEnabled { get; set; }

        private PickControlPreviewForm()
        {
            InitializeComponent();
        }

        public PickControlPreviewForm(int pUserID, long pDocID)
            :this()
        {
            userID = pUserID;
            docID = pDocID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(967, 8);
            this.btnCancel.Location = new Point(1057, 8);

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";

            this.Text = string.Format("Список товара по сборочному (документ контроля № {0})", docID);

            this.Initialize();
            this.LoadItems();
        }

        private void Initialize()
        {
            #region ПОЛУЧАЕМ ИНФОРМАЦИЮ ПО НОМЕРУ ДОКУМЕНТА

            using (Data.PickControlTableAdapters.PickSlipInfoTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.PickSlipInfoTableAdapter())
            {
                try
                {
                    Data.PickControl.PickSlipInfoDataTable table = adapter.GetData(docID);
                    if (table == null || table.Count != 1)
                        throw new Exception("Не найдена информация о документе!");
                    else
                    {
                        Data.PickControl.PickSlipInfoRow row = table[0];
                        lblDocType.Text = row.Doc_type;
                        lblDocNumber.Text = row.Doc_number.ToString();
                        lblDocDate.Text = row.Order_Date.ToShortDateString();
                        lblNumber.Text = row.PickSlip.ToString();
                        lblDelivery.Text = row.Delivery;
                        lblDeliveryDate.Text = row.Delivery_Date.ToShortDateString();
                        lblContainer.Text = row.Conteiner_id;
                        lblDepartment.Text = row.OtdelName;
                        lblRegim.Text = row.Delivery_Zone;

                        this.numPickSlip = row.PickSlip;
                        this.isCold = row.IsIsColdNull() ? (byte)0 : row.IsCold;
                        this.isPlasticBox = row.IsPlasticBoxFlagNull() ? false : Convert.ToBoolean(row.PlasticBoxFlag);

                        // Анализ отображения рекомендаций к сборке 
                        if (row.IsPriorityInstructionNull() || string.IsNullOrEmpty(row.PriorityInstruction))
                        {
                            lblPriorityInstructionHeader.Visible = false;
                            lblPriorityInstruction.Visible = false;
                        }
                        else
                        {
                            lblPriorityInstruction.Text = row.PriorityInstruction;
                            lblPriorityInstruction.ForeColor = Color.FromName(row.PriorityInstruction_Color);
                            lblPriorityInstruction.Visible = true;
                            lblPriorityInstructionHeader.Visible = true;
                        }

                        // Выбор рекомендуемой тары
                        lblRecommendedTare.Text = string.Format("{0}", this.RecommendedTare);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            #endregion

            if (!(btnSwitchNTVRegistrationMode.Checked = this.IsNTVRegistrationModeEnabled))
                this.InitializeSelectedMode();
        }

        public static string GetRecommendedTare(long docID)
        {
            var recommendedTare = "(не выбрана)";

            // Выбор рекомендуемой тары
            var recommendedTareType = (string)null;
            var returnedTareFlag = (int?)null;
            var splitFlag = (int?)null;
            var cancelReason = (string)null;
            var itemID = (int?)null;
            var changeTare = (int?)null;

            using (var qAdapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                qAdapter.AdaptRecommendedTareType(docID, (int?)null, ref recommendedTareType, ref returnedTareFlag, ref splitFlag, cancelReason, itemID, changeTare);

            if (!string.IsNullOrEmpty(recommendedTareType))
                recommendedTare = string.Format("{0}", recommendedTareType);

            return recommendedTare;
        }

        private void LoadItems()
        {
            try
            {
                autoControlItemsInfoTableAdapter.Fill(pickControl.AutoControlItemsInfo, docID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CloseDoc(int userID, long docID)
        {
            try
            {
                var modeID = 1; // определение тары после пройденного весового контроля
                var appliedProcessVersion = true;
                var adaptTestVersionChanges = true;
                var isPlatzkart = false;
                var isMDP = false;
                var weightControlCompleted = true;
                PickControlWindow.ExecuteCloseDocAction(userID, Environment.UserName, docID, modeID, appliedProcessVersion, adaptTestVersionChanges, isPlatzkart, isMDP, weightControlCompleted);

                var additionalMessage = (string)null;

                // Переведем статус документа на "закрыт"
                using (var closeDocAdapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                    closeDocAdapter.WeightControlCloseDoc(docID, userID, ref additionalMessage);

                var sbMessage = new StringBuilder("Документ контроля успешно закрыт!");
                if (!string.IsNullOrEmpty(additionalMessage))
                    sbMessage.Append(additionalMessage);

                var sMessage = sbMessage.ToString();
                var errorForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(sMessage, "ПРОДОЛЖИТЬ (Enter)", System.Drawing.Color.LightGreen, true);
                errorForm.TimeOut = 2000;
                errorForm.AutoClose = false;
                errorForm.ShowDialog(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSetManualControl_Click(object sender, EventArgs e)
        {
            SetManualControl();
        }

        private void SetManualControl()
        {
            #region ОЖИДАНИЕ ПОДТВЕРЖДЕНИЯ РУКОВОДИТЕЛЯ СКАНИРОВАНИЕМ

            while (true)
            {
                try
                {
                    var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте бэйдж руководителя,\r\nкоторый отвечает за мониторинг контроля",
                        Text = "Выбор ручного контроля",
                        Image = Properties.Resources.role,
                        //OnlyNumbersInBarcode = true
                        UseScanModeOnly = true
                    };

                    if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                        break;

                    var bossID = Convert.ToInt32(dlgBossScanner.Barcode);

                    var result = (int?)null;
                    using (var checkBossAdapter = new Data.PickControlTableAdapters.SurplusContainerDocsTableAdapter())
                        checkBossAdapter.CheckBoss(userID, docID, bossID, ref result);

                    if (result.HasValue && Convert.ToBoolean(result.Value))
                    {
                        // Подтверждение ручного контроля получено
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не имеет права\r\nподтверждения.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
            }

            #endregion
        }

        private void PickControlPreviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.CancelDoc();
        }

        private bool CancelDoc()
        {
            try
            {
                // Переведем статус документа на "отменен"
                using (var closeDocAdapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                    closeDocAdapter.WeightControlCancelDoc(docID);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private readonly Bitmap emptyBitmap = new Bitmap(16, 16);

        private void dgvItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // разрисовка строк в таблице, если не указана серия
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                Data.PickControl.AutoControlItemsInfoRow boundRow = (Data.PickControl.AutoControlItemsInfoRow)((DataRowView)row.DataBoundItem).Row;

                if (colCollectors.Visible)
                    ((DataGridViewDisableButtonCell)row.Cells[colCollectors.Name]).ButtonVisible = true;

                // отображение иконок термо-режима
                if (boundRow.IsSnowFlakeNull()) row.Cells[colSnowFlake.DisplayIndex].Value = emptyBitmap;
                else row.Cells[colSnowFlake.DisplayIndex].Value = (boundRow.SnowFlake == "R")
                    ? Properties.Resources.snowflakeR
                    : (boundRow.SnowFlake == "B")
                        ? Properties.Resources.snowflakeB
                        : emptyBitmap;
            }
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvItems.Columns[e.ColumnIndex].Name == colCollectors.Name)
                {
                    if (((DataGridViewDisableButtonCell)dgvItems[e.ColumnIndex, e.RowIndex]).ButtonVisible)
                    {
                        try
                        {
                            var boundRow = (dgvItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.PickControl.AutoControlItemsInfoRow;

                            pickControl.PickSlipItemCollectors.Clear();
                            using (var adapter = new Data.PickControlTableAdapters.PickSlipItemCollectorsTableAdapter())
                                adapter.Fill(pickControl.PickSlipItemCollectors, userID, Convert.ToInt32(numPickSlip), Convert.ToInt32(boundRow.Item_ID));

                            if (pickControl.PickSlipItemCollectors.Rows.Count > 0)
                            {
                                var dlgCollectors = new WMSOffice.Dialogs.RichListForm() { Width = 700 };
                                dlgCollectors.Text = string.Format("Список сборщиков по товару ({0}) {1}", boundRow.Item_ID, boundRow.Item_Name);
                                dlgCollectors.AddColumn("employee", "employee", "Ф.И.О. сотрудника");
                                dlgCollectors.AddColumn("location_id", "location_id", "Место сборки");
                                dlgCollectors.ColumnForFilters = new List<string>(new string[] { "employee", "location_id" });
                                dlgCollectors.FilterChangeLevel = 0;

                                pickControl.PickSlipItemCollectors.DefaultView.RowFilter = string.Empty;
                                dlgCollectors.DataSource = pickControl.PickSlipItemCollectors;
                                dlgCollectors.SetDictionaryViewMode();
                                dlgCollectors.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show(string.Format("Список сборщиков по товару ({0}) {1} не найден.", boundRow.Item_ID, boundRow.Item_Name), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void dgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var item = (dgvItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.PickControl.AutoControlItemsInfoRow;
            if (item.Doc_Qty_Ntv > 0)
            {
                e.CellStyle.BackColor = Color.Khaki;
                e.CellStyle.SelectionForeColor = Color.Khaki;
            }
        }

        private void btnSwitchNTVRegistrationMode_CheckedChanged(object sender, EventArgs e)
        {
            this.IsNTVRegistrationModeEnabled = btnSwitchNTVRegistrationMode.Checked;
            this.InitializeSelectedMode();
        }

        private void InitializeSelectedMode()
        {
            if (this.IsNTVRegistrationModeEnabled)
            {
                //btnSetManualControl.Enabled = false;
                tsFilter.Visible = true;

                //tbFilter.Clear();
                tbFilter.Focus();
            }
            else
            {
                //btnSetManualControl.Enabled = true;

                tbFilter.Clear();
                tsFilter.Visible = false;
            }
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbFilter.Text))
                    autoControlItemsInfoBindingSource.Filter = null;
                else
                    autoControlItemsInfoBindingSource.Filter = string.Format("CONVERT({0}, 'System.String') LIKE '%{4}%' OR {1} LIKE '%{4}%' OR {2} LIKE '%{4}%' OR {3} LIKE '%{4}%'", pickControl.AutoControlItemsInfo.Item_IDColumn.Caption, pickControl.AutoControlItemsInfo.Item_NameColumn.Caption, pickControl.AutoControlItemsInfo.Vendor_LotColumn.Caption, pickControl.AutoControlItemsInfo.ManufacturerColumn.Caption, tbFilter.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.IsNTVRegistrationModeEnabled)
                return;

            if (dgvItems.SelectedRows.Count == 0)
                return;

            if (this.RegisterNTV())
            {
                btnSwitchNTVRegistrationMode.Checked = false;

                this.LoadItems();
            }
        }

        private bool RegisterNTV()
        {
            try
            {
                var item = (dgvItems.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.PickControl.AutoControlItemsInfoRow;

                var _itemCode = Convert.ToInt32(item.Item_ID);
                var _itemName = item.Item_Name;
                var _vendorLot = item.Vendor_Lot;

                var form = new SetCountNTVForm();
                form.CommitVersionChanges = true;
                form.ItemID = _itemCode;
                form.ItemName = _itemName;
                form.Lotn = _vendorLot;
                form.TotalCount = Convert.ToInt32(item.Doc_Qty);
                form.Count = Convert.ToInt32(item.Doc_Qty);
                form.InputCountEnabled = true;
                form.NTVCount = 0;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.NTVCount > 0)
                    {
                        #region ФИКСАЦИЯ НТВ

                        #region 1. скан бейджа
                        var needScanBoss = true;
                        var abortScanBoss = false;
                        while (needScanBoss)
                        {
                            try
                            {
                                var bossID = (int?)null;
                                var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                                {
                                    Label = "Отсканируйте бэйдж руководителя,\r\nкоторый отвечает за мониторинг контроля",
                                    Text = "Фиксация НТВ",
                                    Image = Properties.Resources.role,
                                    //OnlyNumbersInBarcode = true
                                    UseScanModeOnly = true
                                };

                                if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                                {
                                    abortScanBoss = true;
                                    break;
                                }

                                bossID = Convert.ToInt32(dlgBossScanner.Barcode);

                                var result = (int?)null;
                                using (var adapter = new Data.PickControlTableAdapters.SurplusContainerDocsTableAdapter())
                                    adapter.CheckBoss(userID, docID, bossID, ref result);

                                if (result.HasValue && Convert.ToBoolean(result.Value))
                                    needScanBoss = false;
                                else
                                    throw new Exception("Пользователь не имеет права\r\nподтверждения фиксации НТВ.");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        if (abortScanBoss)
                            return false;

                        #endregion

                        #region 2. фиксация НТВ
                        try
                        {
                            using (var adapter = new Data.PickControlTableAdapters.NTVContainerDocsTableAdapter())
                                adapter.RegisterNTV(docID, _itemCode, _vendorLot, form.NTVCount, userID, Environment.UserName, (long?)null);

                            return true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

                        #endregion
                    }
                }
                else
                {
                    MessageBox.Show("НТВ не было указано.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
