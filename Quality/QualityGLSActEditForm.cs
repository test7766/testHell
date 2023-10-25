using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Timers;

namespace WMSOffice.Dialogs.Quality
{
    public partial class QualityGLSActEditForm : DialogForm
    {
        public int? DocID { get; private set; }

        public bool? IsCancelMode { get; set; }

        public int? FirstDocID { get; set; }

        public bool CanEdit { get; set; }


        public bool HasChanges { get; private set; }


        private readonly Data.Quality.GA_DocsRow _doc = null;

        private byte[] attachmentBin = null;
       
        public QualityGLSActEditForm()
        {
            InitializeComponent();
        }

        public QualityGLSActEditForm(Data.Quality.GA_DocsRow doc)
            : this()
        {
            _doc = doc;
            this.DocID = _doc != null ? _doc.DocID : (int?)null;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.btnOK.Location = new Point(1127, 8);
            this.btnCancel.Location = new Point(1217, 8);

            this.WindowState = FormWindowState.Maximized;
        }

        private void Initialize()
        {
            filterTimer.Elapsed += filterTimer_Elapsed;

            this.LoadDocTypes();
            this.LoadWorkTypes();
            this.LoadRecallInitiatorTypes();

            if (_doc != null)
            {
                cmbDocType.SelectedValue = _doc.DocType;
                tbDocNumber.Text = _doc.DocNumber;
                dtpDocDate.Value = _doc.DocDate;
                tbDocAttachment.Text = _doc.IsDocAttachmentNameNull() ? string.Empty : _doc.DocAttachmentName;

                if (!_doc.IsWorkTypeIDNull())
                    cmbWorkType.SelectedValue = _doc.WorkTypeID;
                else
                    cmbWorkType.SelectedItem = null;

                if (!_doc.IsInitiatorTypeIDNull())
                    cmbInitiatorType.SelectedValue = _doc.InitiatorTypeID;
                else
                    cmbInitiatorType.SelectedItem = null;

                tbReason.Text = _doc.IsReasonNull() ? string.Empty : _doc.Reason;
                tbProtocolID.Text = _doc.IsProtocolIDNull() ? string.Empty : _doc.ProtocolID.ToString();
                tblProtocolStatus.Text = _doc.IsProtocolStatusNull() ? string.Empty : _doc.ProtocolStatus;

                this.LockEditors();

                this.LoadDocDetails();

                tbFilter.Focus();
            }
            else
            {
                if (quality.GA_Doc_Types.Count > 1)
                    cmbDocType.SelectedItem = null;

                if (quality.GA_Work_Types.Count > 1)
                    cmbWorkType.SelectedItem = null;

                if (quality.GA_Recall_Initiator_Types.Count > 1)
                    cmbInitiatorType.SelectedItem = null;

                this.Text = string.Format("* Акт розпоряджень");
            }

            tbProtocolID.ReadOnly = true;
            tbProtocolID.BackColor = SystemColors.Window;

            tblProtocolStatus.ReadOnly = true;
            tblProtocolStatus.BackColor = SystemColors.Window;

            this.SetOperationsAccess();
        }

        private void LoadDocTypes()
        {
            try
            {
                using (var adapter = new Data.QualityTableAdapters.GA_Doc_TypesTableAdapter())
                    adapter.Fill(quality.GA_Doc_Types, this.UserID, this.IsCancelMode, this.FirstDocID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadWorkTypes()
        {
            try
            {
                using (var adapter = new Data.QualityTableAdapters.GA_Work_TypesTableAdapter())
                    adapter.Fill(quality.GA_Work_Types);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecallInitiatorTypes()
        {
            try
            {
                using (var adapter = new Data.QualityTableAdapters.GA_Recall_Initiator_TypesTableAdapter())
                    adapter.Fill(quality.GA_Recall_Initiator_Types);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LockEditors()
        {
            cmbDocType.Enabled = false;

            tbDocNumber.ReadOnly = true;
            tbDocNumber.BackColor = SystemColors.Window;

            dtpDocDate.Enabled = false;

            tbDocAttachment.ReadOnly = true;
            tbDocAttachment.BackColor = SystemColors.Window;

            btnDocAttachment.Enabled = !string.IsNullOrEmpty(tbDocAttachment.Text);
            tbDocAttachment.Enabled = btnDocAttachment.Enabled;

            cmbWorkType.Enabled = false;
            cmbInitiatorType.Enabled = false;

            tbReason.ReadOnly = true;
            tbReason.BackColor = SystemColors.Window;

            //tbFilter.BackColor = SystemColors.Info;

            if (this.CanEdit)
            {
                this.Text = string.Format("Акт розпоряджень № {0}", this.DocID);
            }
            else
            {
                this.Text = string.Format("Акт розпоряджень № {0} (тільки читання)", this.DocID);

                pnlFilter.Visible = false;
                spcTwoGrids.Panel1Collapsed = true;
                spcInternalGrid.Panel1Collapsed = true;

                btnOK.Visible = false;
                btnCancel.Text = "Закрити";

                btnCancel.Focus();
            }

            if (this.FirstDocID.HasValue)
                this.LoadItems();
        }

        private void LoadDocDetails()
        {

            try
            {
                using (var adapter = new Data.QualityTableAdapters.GA_Doc_DetailsTableAdapter())
                    adapter.Fill(quality.GA_Doc_Details, this.DocID);

                if (!this.CanEdit)
                {
                    if (dgvActDetails.Rows.Count > 0)
                        dgvActDetails.Rows[0].Selected = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDocAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                if (_doc == null)
                {
                    using (var dlg = new OpenFileDialog() { Title = "Оберіть шлях розміщення документа" })
                    {
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            var filePath = dlg.FileName;

                            if (File.Exists(filePath))
                            {
                                var bin = File.ReadAllBytes(filePath);

                                attachmentBin = bin;
                                tbDocAttachment.Text = filePath;
                            }
                        }
                    }
                }
                else
                {
                    using (var dlg = new SaveFileDialog() { Title = "Вкажіть шлях збереження документа", FileName = tbDocAttachment.Text })
                    {
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            if (attachmentBin == null)
                            {
                                using (var adapter = new Data.QualityTableAdapters.GA_Doc_AttachmentsTableAdapter())
                                    adapter.Fill(quality.GA_Doc_Attachments, this.DocID, "RA");

                                if (quality.GA_Doc_Attachments.Count > 0)
                                    attachmentBin = quality.GA_Doc_Attachments[0].FileData;
                            }

                            var filePath = dlg.FileName;
                            var bin = attachmentBin;

                            File.WriteAllBytes(filePath, bin);

                            if (File.Exists(filePath))
                            {
                                Process.Start(filePath);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxFilter_Enter(object sender, EventArgs e)
        {
            if (!DocID.HasValue && this.CreateDoc(false))
                this.LockEditors();
        }

        private bool CreateDoc(bool saveForce)
        {
            try
            {
                if (cmbDocType.SelectedValue == null)
                    throw new Exception("Тип предписания не может быть пустым.");

                if (string.IsNullOrEmpty(tbDocNumber.Text))
                    throw new Exception("Номер предписания не может быть пустым.");

                if (string.IsNullOrEmpty(tbDocAttachment.Text))
                    throw new Exception("Вложение не может быть пустым.");

                if (cmbWorkType.SelectedValue == null)
                    throw new Exception("Вид отзыва не может быть пустым.");

                if (cmbInitiatorType.SelectedValue == null)
                    throw new Exception("Инициатор отзыва не может быть пустым.");

                if (string.IsNullOrEmpty(tbReason.Text))
                    throw new Exception("Причина отзыва не может быть пустой.");

                if (!saveForce && MessageBox.Show("Сохранить изменения в новом документе?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return false;

                var docID = (int?)null;

                var docType = (string)cmbDocType.SelectedValue;
                var docNumber = tbDocNumber.Text;
                var docDate = dtpDocDate.Value.Date;

                var workType = (byte)cmbWorkType.SelectedValue;
                var initiatorType = (byte)cmbInitiatorType.SelectedValue;
                var reason = tbReason.Text;

                using (var adapter = new Data.QualityTableAdapters.GA_DocsTableAdapter())
                    adapter.CreateDoc(docType, docNumber, docDate, this.UserID, ref docID, this.FirstDocID, workType, initiatorType, reason);

                this.DocID = docID;
                
                this.AddDocAttachment();
               
                return this.DocID.HasValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void AddDocAttachment()
        {
            try
            {
                var attachmentFileName = new FileInfo(tbDocAttachment.Text).Name;

                using (var adapter = new Data.QualityTableAdapters.GA_DocsTableAdapter())
                    adapter.AddDocAttachment(this.DocID, attachmentFileName, (string)null, attachmentBin, this.UserID, (string)null, (DateTime?)null, "RA");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region ПРИМЕНЕНИЕ ФИЛЬТРА ПО ТОВАРАМ

        /// <summary>
        /// Таймер, который отвечает за то, чтобы фильтрация по остаткам проихсодила не сразу после изменения
        /// фильтра, а спустя некоторое время
        /// </summary>
        private System.Timers.Timer filterTimer = new System.Timers.Timer(1000);
        /// <summary>
        /// Строка фильтра (эта переменная сделана для того, чтобы не обращаться из левых потоков к TextBox)
        /// </summary>
        private string filterItem;

        private bool filterAllLotNumbers;

        /// <summary>
        /// Делегат для асинхронного вызова фильтрации
        /// </summary>
        private delegate void Method();

        private void tbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filterTimer.Stop();
                LoadItems();
            }
        }

        /// <summary>
        /// Если прошло достаточно времени с момента последнего редактирования фильтра, запускается фильтрация
        /// </summary>
        private void filterTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            filterTimer.Stop();
            dgvItems.Invoke(new Method(LoadItems));
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            filterItem = tbFilter.Text;
            filterTimer.Stop();
            filterTimer.Start();
        }

        private void LoadItems()
        {
            try
            {
                if (!this.DocID.HasValue)
                    return;

                if ((filterItem == null && !this.FirstDocID.HasValue) || (filterItem != null && filterItem.Length > 0 && filterItem.Length < 3))
                    return;

                if ((filterItem == null || filterItem.Length == 0) && !this.FirstDocID.HasValue)
                {
                    quality.GA_Items.Clear();
                    return;
                }

                var itemName = filterItem;
                var allLotNumbers = filterAllLotNumbers;

                using (var adapter = new Data.QualityTableAdapters.GA_ItemsTableAdapter())
                {
                    adapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                    adapter.Fill(quality.GA_Items, itemName, this.DocID, this.UserID, allLotNumbers);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnFindItemForAct_Click(object sender, EventArgs e)
        {
            var itemID = (int?)null;
            var lotNumber = (string)null;
            var expireDate = (DateTime?)null;
            var lotVendorID = (int?)null;

            if (this.FindItem(out itemID, out lotNumber, out expireDate) && 
                this.AddItem(itemID.Value, lotNumber, expireDate, lotVendorID))
            {
                this.HasChanges = true;
                this.LoadData();
            }
        }

        private bool FindItem(out int? itemID, out string lotNumber, out DateTime? expireDate)
        {
            itemID = (int?)null;
            lotNumber = (string)null;
            expireDate = (DateTime?)null;

            try
            {
                var frmQualityGLSFindItem = new QualityGLSActFindItemForm() { UserID = this.UserID, DocID = this.DocID };
                if (frmQualityGLSFindItem.ShowDialog() == DialogResult.OK)
                {
                    itemID = frmQualityGLSFindItem.ItemID;
                    lotNumber = frmQualityGLSFindItem.LotNumber;
                    expireDate = frmQualityGLSFindItem.ExpireDate;

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnAddToAct_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selectedRow in dgvItems.SelectedRows)
            {
                var item = (selectedRow.DataBoundItem as DataRowView).Row as Data.Quality.GA_ItemsRow;

                var itemID = item.ItemID;
                var lotNumber = item.LotNumber;
                var expireDate = item.IsExpireDateNull() ? (DateTime?)null : item.ExpireDate;
                var lotVendorID = item.IsLotVendorIDNull() ? (int?)null : item.LotVendorID;

                if (!this.AddItem(itemID, lotNumber, expireDate, lotVendorID))
                    return;

                this.HasChanges = true;
            }

            this.LoadData();
        }

        private bool AddItem(int itemID, string lotNumber, DateTime? expireDate, int? lotVendorID)
        {
            return this.ModifyItem(itemID, lotNumber, expireDate, lotVendorID, "I");
        }

        private void btnRemoveFromAct_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selectedRow in dgvActDetails.SelectedRows)
            {
                var detail = (selectedRow.DataBoundItem as DataRowView).Row as Data.Quality.GA_Doc_DetailsRow;

                var itemID = detail.ItemID;
                var lotNumber = detail.LotNumber;
                var expireDate = detail.IsExpireDateNull() ? (DateTime?)null : detail.ExpireDate;
                var lotVendorID = detail.IsLotVendorIDNull() ? (int?)null : detail.LotVendorID;

                if (!this.RemoveItem(itemID, lotNumber, expireDate, lotVendorID))
                    return;

                this.HasChanges = true;
            }

            this.LoadData();
        }

        private bool RemoveItem(int itemID, string lotNumber, DateTime? expireDate, int? lotVendorID)
        {
            return this.ModifyItem(itemID, lotNumber, expireDate, lotVendorID, "D");
        }

        private bool ModifyItem(int itemID, string lotNumber, DateTime? expireDate, int? lotVendorID, string operationType)
        {
            try
            {
                using (var adapter = new Data.QualityTableAdapters.GA_Doc_DetailsTableAdapter())
                    adapter.AddDocRow(this.DocID, itemID, lotNumber, expireDate, lotVendorID, operationType);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnCreateItemForAct_Click(object sender, EventArgs e)
        {
            var itemID = (int?)null;
            var lotNumber = (string)null;
            var expireDate = (DateTime?)null;
            var lotVendorID = (int?)null;

            if (this.CreateItem(out itemID, out lotNumber, out expireDate) &&
                this.AddItem(itemID.Value, lotNumber, expireDate, lotVendorID))
            {
                this.HasChanges = true;
                this.LoadData();
            }
        }

        private bool CreateItem(out int? itemID, out string lotNumber, out DateTime? expireDate)
        {
            itemID = (int?)null;
            lotNumber = (string)null;
            expireDate = (DateTime?)null;

            try
            {
                var createdItems = new Data.Quality.GA_ItemsDataTable();

                var itemBlank = createdItems.NewGA_ItemsRow();
                itemBlank.ItemID = -1;
                foreach (DataGridViewRow selectedRow in dgvItems.SelectedRows)
                {
                    var item = (selectedRow.DataBoundItem as DataRowView).Row as Data.Quality.GA_ItemsRow;
                    itemBlank.ItemArray = item.ItemArray;

                    break;
                }

                var frmQualityGLSCreateItem = new QualityGLSActCreateItemForm(this.DocID, itemBlank) { UserID = this.UserID };
                if (frmQualityGLSCreateItem.ShowDialog() == DialogResult.OK)
                {
                    using (var adapter = new Data.QualityTableAdapters.GA_ItemsTableAdapter())
                        adapter.FillByCreated(createdItems, frmQualityGLSCreateItem.ItemName, frmQualityGLSCreateItem.LotNumber, frmQualityGLSCreateItem.ManufacturerName, frmQualityGLSCreateItem.VendorName, this.UserID);

                    if (createdItems.Count > 0)
                    {
                        var item = createdItems[0];

                        itemID = item.ItemID;
                        lotNumber = item.IsLotNumberNull() ? (string)null : item.LotNumber;
                        expireDate = item.IsExpireDateNull() ? (DateTime?)null : item.ExpireDate;

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void LoadData()
        {
            this.LoadDocDetails();
            this.LoadItems();
        }

        private void QualityGLSActEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                var success = true;

                if (!this.DocID.HasValue)
                    success = this.CreateDoc(true);

                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationsAccess();
        }

        private void dgvActDetails_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationsAccess();
        }

        private void SetOperationsAccess()
        {
            btnFindItemForAct.Enabled = this.DocID.HasValue && this.CanEdit;
            btnAddToAct.Enabled = dgvItems.SelectedRows.Count > 0 && this.CanEdit;
            btnRemoveFromAct.Enabled = dgvActDetails.SelectedRows.Count > 0 && this.CanEdit;
            btnCreateItemForAct.Enabled = this.DocID.HasValue && this.CanEdit;
        }

        private void chbAllLotNumbers_CheckedChanged(object sender, EventArgs e)
        {
            filterAllLotNumbers = chbAllLotNumbers.Checked;
            filterTimer.Stop();
            filterTimer.Start();
        }

        private void tbLotNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var lotNumberFilter = string.IsNullOrEmpty(tbLotNumber.Text) ? (string)null : string.Format("[{0}] LIKE '%{1}%'", quality.GA_Items.LotNumberColumn.Caption, tbLotNumber.Text);
                gAItemsBindingSource.Filter = lotNumberFilter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxManager.Yes = "&Всі";
                MessageBoxManager.No = "&Серія";
                MessageBoxManager.Cancel = "&Скасувати";

                MessageBoxManager.Register();

                var dlgResult = MessageBox.Show("Скинути фільтри \"Всі\"\nабо тільки фільтр \"Серія\"?", "Увага", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                MessageBoxManager.Unregister();

                switch (dlgResult)
                { 
                    case DialogResult.Yes:
                        tbFilter.Clear();
                        chbAllLotNumbers.Checked = false;
                        tbLotNumber.Clear();
                        break;
                    case DialogResult.No:
                        tbLotNumber.Clear();
                        break;
                    case DialogResult.Cancel:
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvActDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var boundRow = (dgvActDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.GA_Doc_DetailsRow;

            var isCanceled = boundRow.IsIsCanceledNull() ? false : boundRow.IsCanceled;
            var itemExists = boundRow.ItemID > 0;

            if (isCanceled)
                e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = Color.LightGray;

            if (!itemExists)
                e.CellStyle.ForeColor = Color.Brown;

            if (!itemExists && dgvActDetails.Columns[e.ColumnIndex].DataPropertyName == quality.GA_Doc_Details.ItemIDColumn.Caption)
                e.Value = string.Empty;
        }

        private void QualityGLSActEditForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quality.GA_Recall_Initiator_Types' table. You can move, or remove it, as needed.
            this.gA_Recall_Initiator_TypesTableAdapter.Fill(this.quality.GA_Recall_Initiator_Types);

        }
    }
}
