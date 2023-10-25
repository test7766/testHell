using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Complaints;

namespace WMSOffice.Window
{
    public partial class WHStocksRotationsWindow : GeneralWindow
    {
        public string WarehouseID { get; private set; }

        public WHStocksRotationsWindow()
        {
            InitializeComponent();
        }

        private void WHStocksRotationsWindow_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            // Кастомизация выпадающего списка со складами
            var blank = "   ";

            lblWarehouse.Text += blank;

            var idx = tsMain.Items.IndexOf(cmbWarehouses);

            var cmb = new ComboBox();
            cmb.Width = 200;
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.DisplayMember = "WarehouseName";
            cmb.ValueMember = "WarehouseID";
            cmb.DataSource = lFWarehousesBindingSource;
            cmb.SelectedValueChanged += (s, e) =>
            {
                if (cmb.SelectedValue != null)
                    this.WarehouseID = cmb.SelectedValue.ToString();
            };

            tsMain.Items.RemoveAt(idx);
            tsMain.Items.Insert(idx, new ToolStripControlHost(cmb));

            tsMain.Items.Insert(idx + 1, new ToolStripLabel(blank));

            // Загрузка складов
            try
            {
                lF_WarehousesTableAdapter.Fill(wH.LF_Warehouses, this.UserID);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }

            // Кастомизация колонки выбора документов
            dgvDocs.Columns[IsSelected.Index].HeaderCell = new DatagridViewCheckBoxHeaderCell(true);
            ((DatagridViewCheckBoxHeaderCell)dgvDocs.Columns[IsSelected.Index].HeaderCell).CheckBoxClicked += (s, e) =>
            {
                try
                {
                    foreach (DataGridViewRow row in dgvDocs.Rows)
                    {
                        if (e.IsChecked)
                        { 
                            var doc = (row.DataBoundItem as DataRowView).Row as Data.WH.LF_DocsRotationsRow;
                            var isDocValid = this.ValidateDoc(doc);
                            if (!isDocValid)
                                continue;
                        }

                        row.Cells[IsSelected.Index].Value = e.IsChecked;
                    }

                    dgvDocs.RefreshEdit();

                    this.CheckApproveDoc();
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
            };
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.LoadDocs();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.LoadDocs();
                return true;
            }
           
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadDocs();
        }

        private void LoadDocs()
        {
            try
            {
                wH.LF_DocsRotations.Clear();

                var docs = this.GetDocs((long?)null);

                if (docs != null)
                    wH.LF_DocsRotations.Merge(docs);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally 
            {
                this.CheckApproveDoc();

                (dgvDocs.Columns[IsSelected.Index].HeaderCell as DatagridViewCheckBoxHeaderCell).ChangeCheckState(false);
            }
        }

        private Data.WH.LF_DocsRotationsDataTable GetDocs(long? docID)
        { 
            try
            {
                return lF_DocsRotationsTableAdapter.GetData(this.WarehouseID, this.UserID, docID);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return null;
            }
        }

        private void dgvDocs_SelectionChanged(object sender, EventArgs e)
        {
            this.LoadDetails();
        }

        private void LoadDetails()
        {
            try
            {
                var doc = dgvDocs.SelectedRows.Count > 0 ? (dgvDocs.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.WH.LF_DocsRotationsRow : null;
                var docID = doc != null ? doc.Doc_ID : (long?)null;
                var docWarehouseID = doc != null ? doc.Warehouse_id : (string)null;

                wH.EnforceConstraints = false;
                lF_DocDetailsRotationsTableAdapter.Fill(wH.LF_DocDetailsRotations, docID, docWarehouseID, this.UserID);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            this.CreateTasks();
        }

        private void CreateTasks()
        {
            try
            {
                if (!btnCreateTask.Enabled)
                    return;

                var checkedDocs = new List<Data.WH.LF_DocsRotationsRow>();
                foreach (Data.WH.LF_DocsRotationsRow doc in wH.LF_DocsRotations)
                    if (doc.IsSelected)
                        checkedDocs.Add(doc);

                var hasErrors = false;

                var sbErrors = new StringBuilder();

                var splashForm = new WMSOffice.Dialogs.SplashForm();

                var taskWorker = new BackgroundWorker();
                taskWorker.DoWork += (s, e) =>
                {
                    try
                    {
                        foreach (var doc in checkedDocs)
                        {
                            try
                            {
                                lF_DocsRotationsTableAdapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                                lF_DocsRotationsTableAdapter.CreateDelayedTask(doc.Warehouse_id, this.UserID, doc.Doc_ID);
                                //lF_DocsRotationsTableAdapter.CreateTask(doc.Warehouse_id, this.UserID, doc.Doc_ID); // TODO Замена на отложенное выполнение задания

                                doc.IsSelected = false;
                                doc.AcceptChanges();
                            }
                            catch (Exception ex)
                            {
                                hasErrors = true;
                                sbErrors.AppendFormat("\r\nНомер Док {0}: {1}", doc.Doc_ID, ex.Message);
                            }
                        }

                        try
                        {
                            //lF_DocsRotationsTableAdapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                            //lF_DocsRotationsTableAdapter.ConfirmTask(checkedDocs[0].Warehouse_id, this.UserID); // TODO Замена на отложенное выполнение задания
                        }
                        catch (Exception ex)
                        {
                            hasErrors = true;
                            sbErrors.AppendFormat("\r\nОбработка Док: {0}", ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                taskWorker.RunWorkerCompleted += (s, e) =>
                {
                    splashForm.CloseForce();

                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                };

                splashForm.ActionText = "Выполняется создание заданий по выбранным документам..";
                taskWorker.RunWorkerAsync();
                splashForm.ShowDialog();

                if (hasErrors)
                    throw new Exception(string.Format("Во время создания некоторых заданий возникли ошибки:{0}\r\n\r\nПовторите действие.", sbErrors));

                MessageBox.Show("Задание было создано и будет выполнено\r\nв ближайшие 10-15 минут.", "Внимание",  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.LoadDocs();
            }
        }

        private void dgvDocs_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDocs.CurrentCell is DataGridViewCheckBoxCell)
            {
                if (dgvDocs.IsCurrentCellDirty)
                {
                    var doc = (dgvDocs.CurrentRow.DataBoundItem as DataRowView).Row as Data.WH.LF_DocsRotationsRow;

                    var isDocValid = this.ValidateDoc(doc);

                    if (isDocValid)
                        dgvDocs.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    else
                        dgvDocs.CancelEdit();

                    //// Раскраска
                    bool isChecked = Convert.ToBoolean(this.dgvDocs.Rows[this.dgvDocs.CurrentRow.Index].Cells[this.IsSelected.Index].Value);
                    var color = !isDocValid ? Color.LightPink : isChecked ? Color.LightGreen : SystemColors.Window;
                    foreach (DataGridViewColumn column in this.dgvDocs.Columns)
                    {
                        this.dgvDocs.Rows[this.dgvDocs.CurrentRow.Index].Cells[column.Index].Style.BackColor = color;
                        this.dgvDocs.Rows[this.dgvDocs.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = color;
                    }

                    this.CheckApproveDoc();
                }
            }
        }

        private void CheckApproveDoc()
        {
            var hasCheckedDocs = false;
            foreach (Data.WH.LF_DocsRotationsRow doc in wH.LF_DocsRotations)
                if (doc.IsSelected)
                {
                    hasCheckedDocs = true;
                    break;
                }

            btnCreateTask.Enabled = hasCheckedDocs; 
        }

        private bool ValidateDoc(Data.WH.LF_DocsRotationsRow doc)
        {
            try
            {
                return !doc.Isqty_itm_confirmNull() && doc.qty_itm_confirm <= doc.qty_itm_fact && doc.qty_itm_confirm >= 0;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        private void dgvDocs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;

                var doc = (dgvDocs.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.LF_DocsRotationsRow;

                var isDocValid = this.ValidateDoc(doc);

                // Раскраска
                bool isChecked = Convert.ToBoolean(this.dgvDocs.Rows[e.RowIndex].Cells[this.IsSelected.Index].Value);
                var color = !isDocValid ? Color.LightPink : isChecked ? Color.LightGreen : SystemColors.Window;

                this.dgvDocs.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = color;
                this.dgvDocs.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = color;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void dgvDocs_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit) && e.Exception != null)
            {
                if (this.dgvDocs.Columns[e.ColumnIndex].DataPropertyName == this.wH.LF_DocsRotations.qty_itm_confirmColumn.Caption)
                {
                    MessageBox.Show("Количество должно быть целым числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDocs_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.dgvDocs.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
            {
                this.dgvDocs.CurrentCell = this.dgvDocs.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.dgvDocs.BeginEdit(true);
            }
        }

        private void dgvDocs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (this.dgvDocs.Columns[e.ColumnIndex].DataPropertyName != this.wH.LF_DocsRotations.qty_itm_confirmColumn.Caption)
                return;

            try
            {
                var doc = (dgvDocs.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.LF_DocsRotationsRow;

                var confirmedQty = doc.Isqty_itm_confirmNull() ? (int?)null : doc.qty_itm_confirm;
                lF_DocsRotationsTableAdapter.ConfirmQuantity(doc.Warehouse_id, doc.Doc_ID, confirmedQty, this.UserID);

                var docsChanged = this.GetDocs(doc.Doc_ID);
                if (docsChanged != null && docsChanged.Count > 0)
                {
                    if (docsChanged[0].Isqty_itm_confirmNull())
                        doc.Setqty_itm_confirmNull();
                    else
                        doc.qty_itm_confirm = docsChanged[0].qty_itm_confirm;
                }

                var isDocValid = this.ValidateDoc(doc);
                if (!isDocValid)
                    doc.IsSelected = false;

                this.CheckApproveDoc();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.LoadDetails();
            }
        } 
    }
}
