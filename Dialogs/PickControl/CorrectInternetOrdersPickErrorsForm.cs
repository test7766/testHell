using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.PickControl;
using System.Transactions;
using WMSOffice.Classes.PickControl;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class CorrectInternetOrdersPickErrorsForm : DialogForm
    {
        /// <summary>
        /// № сборочного
        /// </summary>
        public int PickSlipNumber { get; set; }

        /// <summary>
        /// № док-та контроля
        /// </summary>
        public long DocID { get; set; }

        public long? ProcessVersionID { get; set; }
        public bool CommitVersionChanges { get; set; }

        public bool HasOnlySurplus { get; set; }

        private SurplusContainerDoc surplusContainerDoc = null; 

        public CorrectInternetOrdersPickErrorsForm()
        {
            InitializeComponent();
        }

        private void CorrectInternetOrdersPickErrorsForm_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        protected override void OnShown(EventArgs e)
        {
            this.Text = string.Format("{0} по документу № {1}", this.Text, this.DocID);

            this.btnOK.Location = new Point(671, 8); // 762 // 898
            this.btnCancel.Location = new Point(897, 8); // 988

            if (this.HasOnlySurplus)
            {
                btnOK.Visible = false;
                btnCancel.Text = "Закрыть";
            }

            this.btnOK.Size = new System.Drawing.Size(220, 23);
            this.btnOK.Text = "Подтвердить недостачу";
        }

        private void Initialize()
        {
            if (this.HasOnlySurplus)
                this.LoadData(pickControl.PC_IO_Difference);
            else
                this.LoadData();
        }

        private void LoadData()
        {
            var diff = CorrectInternetOrdersPickErrorsForm.GetPickControlDifference(this.DocID);
            this.LoadData(diff);
        }

        private void LoadData(Data.PickControl.PC_IO_DifferenceDataTable diff)
        {
            try
            {
                var diffSource = (Data.PickControl.PC_IO_DifferenceDataTable)diff.Clone();
                diffSource.Merge(diff, true);
                this.InitializeDiffernce(diffSource);
              
                scContent.Panel1Collapsed = true;

                var lstPickErrorsGroups = new List<InternetOrderPickErrorsGroup>();
                foreach (Data.PickControl.PC_IO_DifferenceRow row in pickControl.PC_IO_Difference.Rows)
                {
                    var findGroup = false;
                    foreach (var peg in lstPickErrorsGroups)
                    {
                        if (peg.OrderID == row.Order_id && peg.InstructionID == row.GR_Id)
                        {
                            findGroup = true;
                            break;
                        }
                    }
                    if (!findGroup)
                        lstPickErrorsGroups.Add(new InternetOrderPickErrorsGroup() { OrderID = row.Order_id, InstructionID = row.GR_Id });
                }


                pnlContent.Controls.Clear();

                lstPickErrorsGroups.Sort();

                foreach (var peg in lstPickErrorsGroups)
                {
                    var groupErrors = new DataView(pickControl.PC_IO_Difference, string.Format("{0} = {1} AND {2} = {3}", pickControl.PC_IO_Difference.Order_idColumn.Caption, peg.OrderID, pickControl.PC_IO_Difference.GR_IdColumn.Caption, peg.InstructionID), (string)null, DataViewRowState.CurrentRows).ToTable();
                    var groupErrorsSource = new Data.PickControl.PC_IO_DifferenceDataTable();
                    groupErrorsSource.Merge(groupErrors);

                    var groupErrorsControl = new InternetOrdersPickErrorsGroupControl(groupErrorsSource, groupErrorsSource[0].GR_Id, groupErrorsSource[0].GR_Name, groupErrorsSource[0].Order_id)
                    {
                        UserID = this.UserID,
                        HasSurplus = groupErrorsSource[0].GR_Id.Equals(1),
                        CanReControl = !groupErrorsSource[0].GR_Id.Equals(1)
                    };

                    groupErrorsControl.OnRegisterSurplus += (s, e) => this.RegisterSurplus(e.Row);
                    groupErrorsControl.OnReControl += (s, e) => this.ReControl(e.Row);

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

        public void InitializeDiffernce(Data.PickControl.PC_IO_DifferenceDataTable diff)
        {
            pickControl.PC_IO_Difference.Clear();
            pickControl.PC_IO_Difference.Merge(diff);
        }

        public static Data.PickControl.PC_IO_DifferenceDataTable GetPickControlDifference(long docID)
        {
            try
            {
                var diff = new Data.PickControl.PC_IO_DifferenceDataTable();
                using (var adapter = new Data.PickControlTableAdapters.PC_IO_DifferenceTableAdapter())
                    adapter.Fill(diff, docID);

                return diff;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static bool CheckOnlySurplus(Data.PickControl.PC_IO_DifferenceDataTable diff)
        {
            var surplus = new DataView(diff, string.Format("{0} = 1", diff.GR_IdColumn.Caption), (string)null, DataViewRowState.CurrentRows).ToTable();
            var surplusSource = new Data.PickControl.PC_IO_DifferenceDataTable();
            surplusSource.Merge(surplus);
            return diff.Rows.Count > 0 && surplusSource.Rows.Count == diff.Rows.Count;
        }

        private void RegisterSurplus(Data.PickControl.PC_IO_DifferenceRow row)
        {
            try
            {
                if (surplusContainerDoc == null)
                    surplusContainerDoc = new SurplusContainerDoc(this.UserID, Environment.UserName, this.DocID, this.ProcessVersionID, this.CommitVersionChanges) { IsRepeatControl = false };

                var needShowMessage = true;
                while (needShowMessage)
                {
                    if (MessageBox.Show("Вы желаете зафиксировать излишек?", "Контроль излишка", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        var needShowContainer = true;
                        while (needShowContainer)
                        {
                            try
                            {
                                if (surplusContainerDoc.IsOpened)
                                {
                                    var expectedQuantity = row.Qty_plan;
                                    var expectedSurplusQuantity = row.Qty;

                                    surplusContainerDoc.Init(new SurplusContainerDocInitParameters() { ItemID = row.Item_id, UnitOfMeasure = row.UOM, Quantity = 0, ExpectedQuantity = expectedQuantity, ExpectedVendorLot = row.Vendor_lot, ExpectedSurplusQuantity = expectedSurplusQuantity });
                                    needShowContainer = false;
                                    needShowMessage = false;
                                }
                                else
                                {
                                    if (surplusContainerDoc.Open())
                                        needShowContainer = true;
                                    else
                                        needShowContainer = false;
                                }
                            }
                            catch (Exception exc)
                            {
                                MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReControl(Data.PickControl.PC_IO_DifferenceRow row)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите провести повторный мини-контроль?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;

                var dlgOrderMiniControl = new OrderMiniControlForm(true) { UserID = this.UserID, DocID = this.DocID, OrderID = row.Order_id, ProcessVersionID = this.ProcessVersionID, CommitVersionChanges = this.CommitVersionChanges };
                if (dlgOrderMiniControl.ShowDialog() == DialogResult.OK)
                {
                    var diff = CorrectInternetOrdersPickErrorsForm.GetPickControlDifference(this.DocID);
                    if (diff.Rows.Count == 0)
                    {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                    else
                    {
                        if (this.HasOnlySurplus = CorrectInternetOrdersPickErrorsForm.CheckOnlySurplus(diff))
                        {
                            btnOK.Visible = false;
                            btnCancel.Text = "Закрыть";
                        }

                        this.LoadData(diff);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CorrectInternetOrdersPickErrorsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.CorrectPickSlip();
            else if (this.DialogResult == DialogResult.Cancel)
                e.Cancel = !this.HasOnlySurplus && MessageBox.Show("Вы уверены что хотите закрыть окно корректировки и отменить текущий контроль?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes;
        }

         /// <summary>
        /// Корректировка сборочного листа
        /// </summary>
        /// <returns></returns>
        private bool CorrectPickSlip()
        {
            if (this.HasOnlySurplus)
                return true;

            try
            {

                var needConfirm = (int?)null;
                using (var adapter = new Data.PickControlTableAdapters.DocRowsAllVarianceTableAdapter())
                    adapter.NeedConfirmPickSlipCorrection(this.UserID, this.DocID, ref needConfirm);

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

                // 1. Попытка предварительной корректировки
                var message = (string)null;
                using (var adapter = new Data.PickControlTableAdapters.DocRowsAllVarianceTableAdapter())
                    adapter.TryCorrect(this.UserID, this.DocID, ref message);

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
                            // 1. Регистрация НТВ
                            foreach (Data.PickControl.PC_IO_DifferenceRow row in pickControl.PC_IO_Difference.Rows)
                            {
                                if (row.GR_Id == 2) // НТВ
                                {
                                    using (var adapter = new Data.PickControlTableAdapters.NTVContainerDocsTableAdapter())
                                        adapter.RegisterNTV(this.DocID, row.Item_id, row.Vendor_lot, row.Qty, this.UserID, Environment.UserName, row.Order_id);
                                }
                            }

                            // 2. Корректировка
                            using (var adapter = new Data.PickControlTableAdapters.PC_IO_DifferenceTableAdapter())
                                adapter.Correct(this.UserID, this.DocID, Environment.UserName);

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

        private class InternetOrderPickErrorsGroup : IComparable<InternetOrderPickErrorsGroup>
        {
            public int OrderID { get; set; }
            public int InstructionID { get; set; }

            #region IComparable<InternetOrderPickErrorsGroup> Members

            public int CompareTo(InternetOrderPickErrorsGroup other)
            {
                if (this.OrderID == other.OrderID)
                    return this.InstructionID.CompareTo(this.InstructionID);

                return other.OrderID.CompareTo(this.OrderID);


                //if (this.InstructionID == other.InstructionID)
                //    return this.OrderID.CompareTo(other.OrderID);

                //return other.InstructionID.CompareTo(this.InstructionID);
            }

            #endregion

            public override string ToString()
            {
                return string.Format("InstructionID = {0}; OrderID = {1}", InstructionID, OrderID);
            }
        }
    }
}
