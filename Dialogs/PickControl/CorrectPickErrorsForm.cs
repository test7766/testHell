using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Window;
using System.Transactions;
using WMSOffice.Controls.PickControl;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class CorrectPickErrorsForm : DialogForm
    {
        /// <summary>
        /// № сборочного
        /// </summary>
        public int PickSlipNumber { get; set; }

        /// <summary>
        /// № док-та контроля
        /// </summary>
        public long DocID { get; set; }

        /// <summary>
        /// ID версии процесса
        /// </summary>
        public long? ProcessVersionID { get; set; }

        private bool lockAction = false;

        private bool cancelDocAction = false;

        public CorrectPickErrorsForm()
        {
            InitializeComponent();
        }

        private void CorrectPickErrorsForm_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Text = string.Format("{0} по документу № {1}", this.Text, this.DocID);

            this.btnOK.Location = new Point(762, 8);
            this.btnCancel.Location = new Point(988, 8);

            this.btnOK.Visible = !lockAction;
            this.btnCancel.Text = "Закрыть";

            //this.btnOK.Enabled = false;
        }

        private void LoadData()
        {
            try
            {
                var filialFlag = (int?)null;
                var cancelDocFlag = (int?)null;
                docRowsAllVarianceTableAdapter.Fill(pickControl.DocRowsAllVariance, this.DocID, ref filialFlag, ref cancelDocFlag);
                var vendorLotControl = (filialFlag ?? 0) == 1;

                cancelDocAction = (cancelDocFlag ?? 0) == 1;

                //var lstInstructionGroups = new List<int>();
                //foreach (Data.PickControl.DocRowsAllVarianceRow row in pickControl.DocRowsAllVariance.Rows)
                //    if (!lstInstructionGroups.Contains(row.Instruction_ID))
                //        lstInstructionGroups.Add(row.Instruction_ID);

                var lstPickErrorsGroups = new List<PickErrorsGroup>();
                foreach (Data.PickControl.DocRowsAllVarianceRow row in pickControl.DocRowsAllVariance.Rows)
                {
                    var findGroup = false;
                    foreach (var peg in lstPickErrorsGroups)
                    {
                        if (peg.PCDocID == row.control_number && peg.InstructionID == row.Instruction_ID)
                        {
                            findGroup = true;
                            break;
                        }
                    }
                    if (!findGroup)
                        lstPickErrorsGroups.Add(new PickErrorsGroup() { PCDocID = row.control_number, InstructionID = row.Instruction_ID });
                }

                // Если на текущем контроле нет недостач (InstructionID == 2), то перемещать ничего не нужно 
                var shortageExists = false;
                foreach (var peg in lstPickErrorsGroups)
                {
                    if (peg.InstructionID == 2 && peg.PCDocID == this.DocID)
                    {
                        shortageExists = true;
                        break;
                    }
                }
                if (!shortageExists)
                    lockAction = true;

                //if (!lstInstructionGroups.Contains(2))
                //    lockAction = true;

                pnlContent.Controls.Clear();

                lstPickErrorsGroups.Sort();

                //lstPickErrorsGroups.Reverse();
                //lstInstructionGroups.Reverse(); // за счет операции обращения списка группы расхождений будут правильно размещены в контейнере (!)

                //foreach (var groupID in lstInstructionGroups)
                foreach (var peg in lstPickErrorsGroups)
                {
                    var groupErrors = new DataView(pickControl.DocRowsAllVariance, string.Format("{0} = {1} AND {2} = {3}", pickControl.DocRowsAllVariance.control_numberColumn.Caption, peg.PCDocID, pickControl.DocRowsAllVariance.Instruction_IDColumn.Caption, peg.InstructionID), (string)null, DataViewRowState.CurrentRows).ToTable();
                    var groupErrorsSource = new Data.PickControl.DocRowsAllVarianceDataTable();
                    groupErrorsSource.Merge(groupErrors);

                    var groupErrorsControl = new PickErrorsGroupControl(groupErrorsSource, groupErrorsSource[0].Instruction_Name, groupErrorsSource[0].control_number) 
                    { 
                        UserID = this.UserID, 
                        PickSlipNumber = this.PickSlipNumber,
                        InstructionID = groupErrorsSource[0].Instruction_ID,
                        VendorLotControl = vendorLotControl,
                        ActualControl = groupErrorsSource[0].control_number == this.DocID 
                    };

                    pnlContent.Controls.Add(groupErrorsControl);
                    groupErrorsControl.Dock = DockStyle.Top;

                    groupErrorsControl.Initialize();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CorrectPickErrorsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.CorrectPickSlip();
        }

        /// <summary>
        /// Корректировка сборочного листа
        /// </summary>
        /// <returns></returns>
        private bool CorrectPickSlip()
        {
            try
            {
                var needConfirm = (int?)null;
                docRowsAllVarianceTableAdapter.NeedConfirmPickSlipCorrection(this.UserID, this.DocID, ref needConfirm);

                // Подтверждение корректировки руководителем
                if (needConfirm.HasValue && needConfirm.Value == 1)
                {
                    var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте бэйдж руководителя,\r\nкоторый отвечает за корректировку сборочного",
                        Text = "Корректировка сборочного",
                        Image = Properties.Resources.role,
                        //OnlyNumbersInBarcode = true
                        UseScanModeOnly = true
                    };

                    if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                        return false;

                    var bossID = Convert.ToInt32(dlgBossScanner.Barcode);

                    var checkBossResult = (int?)null;
                    using (var adapter = new Data.PickControlTableAdapters.SurplusContainerDocsTableAdapter())
                        adapter.CheckBoss(this.UserID, this.DocID, bossID, ref checkBossResult);

                    if (!checkBossResult.HasValue || checkBossResult.Value != 1)
                        throw new Exception("У Вас отсутствуют полномочия проводить корректировку сборочного.");
                }

                // 0. Режим переконтроля старшим смены
                if (cancelDocAction)
                {
                    this.DialogResult = DialogResult.Retry;
                    return true;
                }

                // 1. Попытка предварительной корректировки
                var message = (string)null;
                docRowsAllVarianceTableAdapter.TryCorrect(this.UserID, this.DocID, ref message);

                bool allowCorrect = false;
                if (!string.IsNullOrEmpty(message))
                {
                    if (MessageBox.Show(string.Format("{0}\r\nВы желаете подтвердить недостачу?", message), "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        allowCorrect = true;
                }
                else
                    allowCorrect = true;

                if (allowCorrect)
                {
                    var tranOptions = new TransactionOptions();
                    tranOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

                    using (var scope = new TransactionScope(TransactionScopeOption.Required, tranOptions))
                    {
                        try
                        {
                            // 2. Корректировка
                            var userLogin = Environment.UserName;
                            docRowsAllVarianceTableAdapter.Correct(this.UserID, this.DocID, userLogin);

                            // 3. Подтверждение корректировки с перемещением
                            using (var adapter = new Data.PickControlTableAdapters.CorrectPSNLinesErrorsTableAdapter())
                            {
                                adapter.SetTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
                                adapter.Fill(pickControl.CorrectPSNLinesErrors, this.DocID);
                            }

                            scope.Complete();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    // Анализ закрытия формы
                    if (pickControl.CorrectPSNLinesErrors == null || pickControl.CorrectPSNLinesErrors.Rows.Count == 0)
                    {
                        return true;
                    }
                    else
                    {
                        #region ОТОБРАЖАЕМ СПИСОК ОШИБОК

                        using (var frmErrors = new RichListForm())
                        {
                            #region column order_id
                            DataGridViewTextBoxColumn colOrderID = new DataGridViewTextBoxColumn();
                            colOrderID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colOrderID.DataPropertyName = "order_id";
                            colOrderID.HeaderText = "№ заказа";
                            colOrderID.Name = "colOrderID";
                            colOrderID.ReadOnly = true;
                            frmErrors.Columns.Add(colOrderID);
                            #endregion
                            #region column order_type
                            DataGridViewTextBoxColumn colOrderType = new DataGridViewTextBoxColumn();
                            colOrderType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colOrderType.DataPropertyName = "order_type";
                            colOrderType.HeaderText = "Тип заказа";
                            colOrderType.Name = "colOrderType";
                            colOrderType.ReadOnly = true;
                            frmErrors.Columns.Add(colOrderType);
                            #endregion
                            #region column line_id
                            DataGridViewTextBoxColumn colLineID = new DataGridViewTextBoxColumn();
                            colLineID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colLineID.DataPropertyName = "line_id";
                            colLineID.HeaderText = "№ п/п";
                            colLineID.Name = "colLineID";
                            colLineID.ReadOnly = true;
                            frmErrors.Columns.Add(colLineID);
                            #endregion
                            #region column item_id
                            DataGridViewTextBoxColumn colItemID = new DataGridViewTextBoxColumn();
                            colItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colItemID.DataPropertyName = "item_id";
                            colItemID.HeaderText = "Код";
                            colItemID.Name = "colItemID";
                            colItemID.ReadOnly = true;
                            frmErrors.Columns.Add(colItemID);
                            #endregion
                            #region column Item_name
                            DataGridViewTextBoxColumn colItemName = new DataGridViewTextBoxColumn();
                            colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colItemName.DataPropertyName = "Item_name";
                            colItemName.HeaderText = "Наименование товара";
                            colItemName.Name = "colItemName";
                            colItemName.ReadOnly = true;
                            frmErrors.Columns.Add(colItemName);
                            #endregion
                            #region column err_message
                            DataGridViewTextBoxColumn colErrorMessage = new DataGridViewTextBoxColumn();
                            colErrorMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colErrorMessage.DataPropertyName = "err_message";
                            colErrorMessage.HeaderText = "Описание ошибки";
                            colErrorMessage.Name = "colErrorMessage";
                            colErrorMessage.ReadOnly = true;
                            frmErrors.Columns.Add(colErrorMessage);
                            #endregion

                            frmErrors.Text = "Ошибки в результате корректировки сборочного";
                            frmErrors.DataSource = pickControl.CorrectPSNLinesErrors;
                            frmErrors.FilterVisible = false;
                            frmErrors.ShowDialog();
                        }

                        #endregion

                        return false;
                    }
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private class PickErrorsGroup : IComparable<PickErrorsGroup>
        {
            public long PCDocID { get; set; }
            public int InstructionID { get; set; }

            #region IComparable<PickErrorsGroup> Members

            public int CompareTo(PickErrorsGroup other)
            {
                if (this.InstructionID == other.InstructionID)
                    return this.PCDocID.CompareTo(other.PCDocID);

                return other.InstructionID.CompareTo(this.InstructionID);
            }

            #endregion

            public override string ToString()
            {
                return string.Format("InstructionID = {0}; PCDocID = {1}", InstructionID, PCDocID);
            }
        }
    }
}
