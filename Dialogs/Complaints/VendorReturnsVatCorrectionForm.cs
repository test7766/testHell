using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using System.Timers;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class VendorReturnsVatCorrectionForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Таймер, который отвечает за то, чтобы фильтрация проихсодила не сразу после изменения
        /// фильтра, а спустя некоторое время
        /// </summary>
        private System.Timers.Timer filterTimer = new System.Timers.Timer(1000);


        public int? CorrectionDocID { get; private set; }
        public int? VendorID { get; private set; }

        public DateTime CorrectionDate 
        {
            get { return dtpCorrectionDate.Value.Date; }
            set { dtpCorrectionDate.Value = value; }
        }

        public bool IsShowSelectedItemsChecked { get; private set; }
        public string FilterValue { get; private set; }

        public VendorReturnsVatCorrectionForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(767, 8);
            btnCancel.Location = new Point(857, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            stbVendorID.ValueReferenceQuery = "[dbo].[pr_VR_Get_Vendors_List]";
            stbVendorID.UserID = this.UserID;
            stbVendorID.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            //stbVendorID.SetValueByDefault("61325"); // TEST

            #region Только отм. документы
            var cbShowSelectedItems = new CheckBox { Text = "Только отм. документы", CheckAlign = ContentAlignment.MiddleRight };
            cbShowSelectedItems.CheckedChanged += (s, e) =>
            {
                this.IsShowSelectedItemsChecked = cbShowSelectedItems.Checked;

                filterTimer.Stop();
                this.RefreshFilter();
            };
            var hostShowSelectedItems = new ToolStripControlHost(cbShowSelectedItems);
            tsItemsFilter.Items.Add(hostShowSelectedItems);
            #endregion

            #region Накл. / ЗЗ / Товар
            var lblFilterFields = new ToolStripLabel(string.Format("{0}Накл. / ЗЗ / Товар", string.Empty.PadLeft(10, ' ')));
            tsItemsFilter.Items.Add(lblFilterFields);

            var tbFilterFieldsValue = new ToolStripTextBox();
            //tbFilterFieldsValue.BackColor = SystemColors.Info;
            tbFilterFieldsValue.TextBox.TextChanged += (s, e) => 
            {
                this.FilterValue = tbFilterFieldsValue.Text;

                filterTimer.Stop();
                filterTimer.Start();
            };
            tsItemsFilter.Items.Add(tbFilterFieldsValue);
            #endregion

            #region Очистить фильтр
            var btnClearFilter = new ToolStripButton(Properties.Resources.clear);
            btnClearFilter.ToolTipText = "Очистить фильтр";
            btnClearFilter.Click += (s, e) => 
            {
                tbFilterFieldsValue.Clear();
                filterTimer.Stop();
                this.RefreshFilter();
            };
            tsItemsFilter.Items.Add(btnClearFilter);
            #endregion

            RecalcTotalAmount();

            dgvItems.Columns[isCheckedDataGridViewCheckBoxColumn.Index].HeaderCell = new DatagridViewCheckBoxHeaderCell(true);
            ((DatagridViewCheckBoxHeaderCell)dgvItems.Columns[isCheckedDataGridViewCheckBoxColumn.Index].HeaderCell).CheckBoxClicked += new EventHandler<DataGridViewCheckBoxHeaderCellEventArgs>(VendorReturnsVatCorrectionForm_CheckBoxClicked);

            filterTimer.Elapsed += filterTimer_Elapsed;

            this.WindowState = FormWindowState.Maximized;
        }

        void VendorReturnsVatCorrectionForm_CheckBoxClicked(object sender, DataGridViewCheckBoxHeaderCellEventArgs e)
        {
            try
            {
                dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);

                foreach (DataGridViewRow row in dgvItems.Rows)
                    row.Cells[isCheckedDataGridViewCheckBoxColumn.Index].Value = e.IsChecked;

                dgvItems.RefreshEdit();

                RecalcTotalAmount();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Делегат для асинхронного вызова фильтрации
        /// </summary>
        private delegate void Method();

        /// <summary>
        /// Если прошло достаточно времени с момента последнего редактирования фильтра, запускается фильтрация
        /// </summary>
        private void filterTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            filterTimer.Stop();
            dgvItems.Invoke(new Method(RefreshFilter));
        }

        private void RefreshFilter()
        {
            if (complaints.VR_NS_Lines == null)
                return;

            var filterValue = (this.FilterValue ?? string.Empty).Trim();
            var filterValueExpression = !string.IsNullOrEmpty(filterValue) ? string.Format("AND ( {0} LIKE '%{4}%' OR CONVERT({1}, 'System.String') LIKE '%{4}%' OR CONVERT({2}, 'System.String') LIKE '%{4}%' OR {3} LIKE '%{4}%')", complaints.VR_NS_Lines.DocumnetNumberColumn.Caption, complaints.VR_NS_Lines.OrderNumberColumn.Caption, complaints.VR_NS_Lines.ItemIDColumn.Caption, complaints.VR_NS_Lines.ItemNameColumn.Caption, filterValue) : string.Empty;

            var filterSelectorExpression = this.IsShowSelectedItemsChecked ? string.Format("AND ( {0} = 'True' )", complaints.VR_NS_Lines.IsCheckedColumn.Caption) : string.Empty;

            vRNSLinesBindingSource.Filter = string.Format("1=1 {0} {1}", filterValueExpression, filterSelectorExpression);

            dgvItems.Refresh();
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbVendorID)
                lblDescription = tbVendorName;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;

                if (control == stbVendorID)
                {
                    dgvItems.CancelEdit();
                    ClearItems();

                    if (e.Success && !string.IsNullOrEmpty(e.Value))
                    {
                        int vendorID;
                        if (int.TryParse(e.Value, out vendorID))
                        {
                            this.VendorID = vendorID;
                            LoadItems();
                        }
                    }
                }
            }
        }

        private void ClearItems()
        {
            filterTimer.Stop();

            this.VendorID = (int?)null;
            complaints.VR_NS_Lines.Clear();

            RecalcTotalAmount();
        }

        private void LoadItems()
        {
            try
            {
                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += (s, e) => 
                {
                    try
                    {
                        using (var adapter = new Data.ComplaintsTableAdapters.VR_NS_LinesTableAdapter())
                            e.Result = adapter.GetDataByVendor(this.VendorID);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                loadWorker.RunWorkerCompleted += (s, e) => 
                {
                    waitProgressForm.CloseForce();

                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        complaints.VR_NS_Lines.Merge(e.Result as Data.Complaints.VR_NS_LinesDataTable, true);

                        if (complaints.VR_NS_Lines.Count == 0)
                            MessageBox.Show(string.Format("Для поставщика \"{0}\"\r\nотсутствуют приходные документы.", tbVendorName.Text.Trim()), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            if (dgvItems.Rows.Count > 0)
                                dgvItems.Rows[0].Selected = false;
                        }
                    }
                };

                waitProgressForm.ActionText = "Выполняется загрузка приходных документов..";
                loadWorker.RunWorkerAsync();

                waitProgressForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VendorReturnsVatCorrectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidateData();
        }

        private bool ValidateData()
        {
            try
            {
                filterTimer.Stop();
                dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);

                if (!this.VendorID.HasValue)
                    throw new Exception("Не выбран поставщик.");

                if (complaints.VR_NS_Lines.Count == 0)
                    throw new Exception(string.Format("Для поставщика \"{0}\"\r\nотсутствуют приходные документы.", tbVendorName.Text.Trim()));

                var cntSelectedItems = Convert.ToInt32(complaints.VR_NS_Lines.Compute(string.Format("COUNT({0})", complaints.VR_NS_Lines.IsCheckedColumn.Caption), string.Format("{0} = 'True'", complaints.VR_NS_Lines.IsCheckedColumn.Caption)));
                if (cntSelectedItems == 0)
                    throw new Exception("Не отмечены приходные документы\r\nдля акта корректировки НДС.");

                if ((this.CorrectionDocID = CreateDoc()).HasValue)
                {
                    PopulateDoc();
                    CloseDoc();

                    return true;
                }
                else
                {
                    throw new Exception("Не удалось создать акт корректировки НДС.");
                }
            }
            catch (Exception ex)
            {
                try
                {
                    if (this.CorrectionDocID.HasValue)
                        CancelDoc();
                }
                catch
                {

                }

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private int? CreateDoc()
        {
            var docID = (int?)null;

            try
            {
                using (var adapter = new Data.ComplaintsTableAdapters.VR_NS_LinesTableAdapter())
                    docID = Convert.ToInt32(adapter.CreateDoc(this.UserID, this.VendorID, this.CorrectionDate));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return docID;
        }

        private void PopulateDoc()
        {
            try
            {
                foreach (Data.Complaints.VR_NS_LinesRow line in complaints.VR_NS_Lines)
                {
                    if (line.IsChecked)
                    {
                        var itemID = Convert.ToInt32(line.ItemID);
                        var lotNumber = line.LotNumber;

                        var qty = line.IsQtyNull() ? 0.0D : line.Qty;
                        var price = line.IsPriceNull() ? 0.0D : line.Price;
                        var diffAmount = line.IsDiffAmountNull() ? 0.0D : line.DiffAmount;

                        using (var adapter = new Data.ComplaintsTableAdapters.VR_NS_LinesTableAdapter())
                            adapter.AddDocRow(this.CorrectionDocID, this.UserID, itemID, lotNumber, qty, price, diffAmount);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CloseDoc()
        {
            try
            {
                using (var adapter = new Data.ComplaintsTableAdapters.VR_NS_LinesTableAdapter())
                    adapter.CloseDoc(this.CorrectionDocID, this.UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CancelDoc()
        {
            try
            {
                using (var adapter = new Data.ComplaintsTableAdapters.VR_NS_LinesTableAdapter())
                    adapter.CancelDoc(this.CorrectionDocID, this.UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void dgvItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            if (e.Exception != null)
            {
                if (dgvItems.Columns[e.ColumnIndex].DataPropertyName == "Qty" ||
                    dgvItems.Columns[e.ColumnIndex].DataPropertyName == "Price" ||
                    dgvItems.Columns[e.ColumnIndex].DataPropertyName == "DiffAmount")
                {
                    MessageBox.Show(string.Format("Значение поля \"{0}\" должно быть числом.", dgvItems.Columns[e.ColumnIndex].HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Раскраска
            bool isChecked = Convert.ToBoolean(this.dgvItems.Rows[e.RowIndex].Cells[isCheckedDataGridViewCheckBoxColumn.Index].Value);
            this.dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            this.dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;

            if (dgvItems.Columns[e.ColumnIndex].DataPropertyName == "Qty" ||
                dgvItems.Columns[e.ColumnIndex].DataPropertyName == "Price" ||
                dgvItems.Columns[e.ColumnIndex].DataPropertyName == "DiffAmount")
            {
                e.CellStyle.BackColor = Color.Khaki;
                e.CellStyle.SelectionForeColor = Color.Khaki;
            }
        }

        private void dgvItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvItems.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool isChecked = Convert.ToBoolean(this.dgvItems.Rows[this.dgvItems.CurrentRow.Index].Cells[isCheckedDataGridViewCheckBoxColumn.Index].Value);
                foreach (DataGridViewColumn column in this.dgvItems.Columns)
                {
                    this.dgvItems.Rows[this.dgvItems.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    this.dgvItems.Rows[this.dgvItems.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
                }

                RecalcTotalAmount();
            }
        }

        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvItems.Columns[e.ColumnIndex].DataPropertyName == "Qty" ||
                dgvItems.Columns[e.ColumnIndex].DataPropertyName == "Price")
            {
                RecalcRow(e.RowIndex);
            }

            RecalcTotalAmount();
        }

        private void RecalcRow(int rowIndex)
        {
            try
            {
                var line = (dgvItems.Rows[rowIndex].DataBoundItem as DataRowView).Row as Data.Complaints.VR_NS_LinesRow;

                var qty = Convert.ToInt32(line.IsQtyNull() ? 0.0D : line.Qty);
                var price = line.IsPriceNull() ? 0.0D : line.Price;
                var oldTax = Convert.ToInt32(line.IsOldTaxNull() ? 0.0D : line.OldTax);
                var newTax = Convert.ToInt32(line.IsNewTaxNull() ? 0.0D : line.NewTax);

                var amount = (double?)null;
                var oldVatAmount = (double?)null;
                var newVatAmount = (double?)null;
                var diffAmount = (double?)null;

                using (var adapter = new Data.ComplaintsTableAdapters.VR_NS_LinesTableAdapter())
                    adapter.RecalcLineAmount(qty, price, oldTax, newTax, ref amount, ref oldVatAmount, ref newVatAmount, ref diffAmount);

                if (amount.HasValue)
                    line.Amount = amount.Value;
                else
                    line.SetAmountNull();

                if (oldVatAmount.HasValue)
                    line.OldVatAmount = oldVatAmount.Value;
                else
                    line.SetOldVatAmountNull();

                if (newVatAmount.HasValue)
                    line.NewVatAmount = newVatAmount.Value;
                else
                    line.SetNewVatAmountNull();

                if (diffAmount.HasValue)
                    line.DiffAmount = diffAmount.Value;
                else
                    line.SetDiffAmountNull();

                dgvItems.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecalcTotalAmount()
        {
            try
            {
                var totalDiffAmount = 0.0D;

                foreach (Data.Complaints.VR_NS_LinesRow line in complaints.VR_NS_Lines)
                    if (line.IsChecked)
                        totalDiffAmount += (line.IsDiffAmountNull() ? 0.0D : line.DiffAmount);

                lblTotalDiffAmount.Text = string.Format("{0:N2}", totalDiffAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
