using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using System.Data.SqlClient;
using WMSOffice.Dialogs.Complaints;

namespace WMSOffice.Dialogs.WH.TSD
{
    public partial class TSD_CreateTaskForm : DialogForm
    {
        private string defaultHeader;

        public long? TaskID { get; private set; }
        public string Description { get; private set; }
        public int TasksCount { get; private set; }

        public decimal MinQuantity 
        {
            get { return nudQuantity.Minimum; }
            private set 
            { 
                nudQuantity.Minimum = value; 
            } 
        }

        public decimal MaxQuantity 
        {
            get { return nudQuantity.Maximum; }
            private set 
            { 
                nudQuantity.Maximum = value;
                tbAvailableQuantity.Text = value > 0 ? value.ToString() : string.Empty;
            } 
        }

        public string DocType { get; private set; }
        public string WarehouseFromID { get; private set; }
        public string WarehouseToID { get; private set; }
        public string LocnFrom { get; private set; }
        public string LocnTo { get; private set; }
        public int ItemID { get; private set; }
        public string VendorLot { get; private set; }
        
        public string Uom 
        {
            get { return string.IsNullOrEmpty(tbUom.Text) ? (string)null : tbUom.Text; }
            private set 
            {
                tbUom.Text = value ?? string.Empty;
            }
        }

        public int Quantity { get; private set; }

        public bool UseAllAvaliableRemains { get; private set; }

        public bool UseBoxPickMode
        {
            get { return cbBoxPickMode.Checked; }
            set { cbBoxPickMode.Checked = value; }
        }

        public TSD_CreateTaskForm()
        {
            InitializeComponent();
            defaultHeader = this.Text;
        }

        private void TSD_CreateTaskForm_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            stbDocType.ValueReferenceQuery = "[dbo].[pr_so_WM_manage_Create_Task_Get_Doc_Types_ext]";
            stbDocType.UserID = this.UserID;
            stbDocType.OnVerifyValue += new VerifyValueHandler(searchCriteria_OnVerifyValue);

            stbWarehouseFromID.ValueReferenceQuery = "[dbo].[pr_so_WM_manage_Create_Task_Get_WH_From_ext]";
            stbWarehouseFromID.ApplyAdditionalParameter("Doc_Type", string.Empty);
            stbWarehouseFromID.UserID = this.UserID;
            stbWarehouseFromID.OnVerifyValue += new VerifyValueHandler(searchCriteria_OnVerifyValue);

            stbWarehouseToID.ValueReferenceQuery = "[dbo].[pr_so_WM_manage_Create_Task_Get_WH_To_ext]";
            stbWarehouseToID.ApplyAdditionalParameter("Doc_Type", string.Empty);
            stbWarehouseToID.ApplyAdditionalParameter("WH_From", string.Empty);
            stbWarehouseToID.UserID = this.UserID;
            stbWarehouseToID.OnVerifyValue += new VerifyValueHandler(searchCriteria_OnVerifyValue);

            stbLocnFrom.ValueReferenceQuery = "[dbo].[pr_so_WM_manage_Create_Task_Get_Places_From_ext]";
            stbLocnFrom.ApplyAdditionalParameter("Doc_Type", string.Empty);
            stbLocnFrom.ApplyAdditionalParameter("WH_From", string.Empty);
            stbLocnFrom.ApplyAdditionalParameter("WH_To", string.Empty);
            stbLocnFrom.ApplyAdditionalParameter("Like_Key", string.Empty);
            stbLocnFrom.UserID = this.UserID;
            stbLocnFrom.OnVerifyValue += new VerifyValueHandler(searchCriteria_OnVerifyValue);

            stbItemID.ValueReferenceQuery = "[dbo].[pr_so_WM_manage_Create_Task_Get_Items_ext]";
            stbItemID.ApplyAdditionalParameter("Doc_Type", string.Empty);
            stbItemID.ApplyAdditionalParameter("WH_From", string.Empty);
            stbItemID.ApplyAdditionalParameter("WH_To", string.Empty);
            stbItemID.ApplyAdditionalParameter("LOCN_From", string.Empty);
            stbItemID.UserID = this.UserID;
            stbItemID.OnVerifyValue += new VerifyValueHandler(searchCriteria_OnVerifyValue);

            stbVendorLot.ValueReferenceQuery = "[dbo].[pr_so_WM_manage_Create_Task_Get_Series_ext]";
            stbVendorLot.ApplyAdditionalParameter("Doc_Type", string.Empty);
            stbVendorLot.ApplyAdditionalParameter("WH_From", string.Empty);
            stbVendorLot.ApplyAdditionalParameter("WH_To", string.Empty);
            stbVendorLot.ApplyAdditionalParameter("LOCN_From", string.Empty);
            stbVendorLot.ApplyAdditionalParameter("ITM", string.Empty);
            stbVendorLot.UserID = this.UserID;
            stbVendorLot.OnVerifyValue += new VerifyValueHandler(searchCriteria_OnVerifyValue);

            stbLocnTo.ValueReferenceQuery = "[dbo].[pr_so_WM_manage_Create_Task_Get_Places_To_ext]";
            stbLocnTo.ApplyAdditionalParameter("Doc_Type", string.Empty);
            stbLocnTo.ApplyAdditionalParameter("WH_From", string.Empty);
            stbLocnTo.ApplyAdditionalParameter("WH_To", string.Empty);
            stbLocnTo.ApplyAdditionalParameter("LOCN_From", string.Empty);
            stbLocnTo.ApplyAdditionalParameter("ITM", string.Empty);
            stbLocnTo.ApplyAdditionalParameter("RLOT", string.Empty);
            stbLocnTo.ApplyAdditionalParameter("WO_Lift", string.Empty);
            stbLocnTo.ApplyAdditionalParameter("Like_Key", string.Empty);
            stbLocnTo.UserID = this.UserID;
            stbLocnTo.OnVerifyValue += new VerifyValueHandler(searchCriteria_OnVerifyValue);

            this.MinQuantity = 0.0M;
            this.MaxQuantity = 0.0M;
        }

        void searchCriteria_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox tbDescription = null;

            if (control == stbDocType)
                tbDescription = tbDocType;
            else if (control == stbWarehouseFromID)
                tbDescription = tbWarehouseFromID;
            else if (control == stbWarehouseToID)
                tbDescription = tbWarehouseToID;
            else if (control == stbLocnFrom)
                tbDescription = tbLocnFrom;
            else if (control == stbItemID)
                tbDescription = tbItemID;
            else if (control == stbVendorLot)
                tbDescription = tbVendorLot;
            else if (control == stbLocnTo)
                tbDescription = tbLocnTo;

            if (tbDescription != null)
            {
                try
                {
                    if (!e.Success)
                        throw new Exception("Значение не найдено!");

                    if (control == stbDocType)
                    {
                        stbWarehouseFromID.ApplyAdditionalParameter("Doc_Type", e.Value);
                        stbWarehouseToID.ApplyAdditionalParameter("Doc_Type", e.Value);
                        stbLocnFrom.ApplyAdditionalParameter("Doc_Type", e.Value);
                        stbLocnTo.ApplyAdditionalParameter("Doc_Type", e.Value);
                        stbItemID.ApplyAdditionalParameter("Doc_Type", e.Value);
                        stbVendorLot.ApplyAdditionalParameter("Doc_Type", e.Value);
                    }
                    else if (control == stbWarehouseFromID)
                    {
                        stbWarehouseToID.ApplyAdditionalParameter("WH_From", e.Value);
                        stbLocnFrom.ApplyAdditionalParameter("WH_From", e.Value);
                        stbLocnTo.ApplyAdditionalParameter("WH_From", e.Value);
                        stbItemID.ApplyAdditionalParameter("WH_From", e.Value);
                        stbVendorLot.ApplyAdditionalParameter("WH_From", e.Value);
                    }
                    else if (control == stbWarehouseToID)
                    {
                        stbLocnFrom.ApplyAdditionalParameter("WH_To", e.Value);
                        stbLocnTo.ApplyAdditionalParameter("WH_To", e.Value);
                        stbItemID.ApplyAdditionalParameter("WH_To", e.Value);
                        stbVendorLot.ApplyAdditionalParameter("WH_To", e.Value);
                    }
                    else if (control == stbLocnFrom)
                    {
                        stbItemID.ApplyAdditionalParameter("LOCN_From", e.Value);
                        stbVendorLot.ApplyAdditionalParameter("LOCN_From", e.Value);
                        stbLocnTo.ApplyAdditionalParameter("LOCN_From", e.Value);
                    }
                    else if (control == stbItemID)
                    {
                        stbVendorLot.ApplyAdditionalParameter("ITM", e.Value);
                        stbLocnTo.ApplyAdditionalParameter("ITM", e.Value);
                    }
                    else if (control == stbVendorLot)
                    {
                        stbLocnTo.ApplyAdditionalParameter("RLOT", e.Value);
                    }

                    //// Настройка сброса зависимой сущности при смене независимой (при смене склада сбрасывается полка)
                    //// TODO реализовать автоматически через Binding
                    if (control == stbDocType)
                    {
                        stbWarehouseFromID.SetValueByDefault(string.Empty);
                        stbWarehouseToID.SetValueByDefault(string.Empty);
                        stbLocnFrom.SetValueByDefault(string.Empty);
                        stbItemID.SetValueByDefault(string.Empty);
                        stbVendorLot.SetValueByDefault(string.Empty);
                        stbLocnTo.SetValueByDefault(string.Empty);
                    }
                    else if (control == stbWarehouseFromID)
                    {
                        stbWarehouseToID.SetValueByDefault(string.Empty);
                        stbLocnFrom.SetValueByDefault(string.Empty);
                        stbItemID.SetValueByDefault(string.Empty);
                        stbVendorLot.SetValueByDefault(string.Empty);
                        stbLocnTo.SetValueByDefault(string.Empty);
                    }
                    else if (control == stbWarehouseToID)
                    {
                        stbLocnFrom.SetValueByDefault(string.Empty);
                        stbItemID.SetValueByDefault(string.Empty);
                        stbVendorLot.SetValueByDefault(string.Empty);
                        stbLocnTo.SetValueByDefault(string.Empty);
                    }
                    else if (control == stbLocnFrom)
                    {
                        stbItemID.SetValueByDefault(string.Empty);
                        stbVendorLot.SetValueByDefault(string.Empty);
                        stbLocnTo.SetValueByDefault(string.Empty);
                    }
                    else if (control == stbItemID)
                    {
                        stbVendorLot.SetValueByDefault(string.Empty);
                        stbLocnTo.SetValueByDefault(string.Empty);
                    }
                    else if (control == stbVendorLot)
                    {
                        stbLocnTo.SetValueByDefault(string.Empty);
                    }

                    // Зачистка "быстрого" фильтра мест хранения
                    if (control == stbLocnFrom)
                    {
                        if (e.Success && string.IsNullOrEmpty(e.Value))
                            tbQFilterLocnFrom.Clear();
                    }
                    else if (control == stbLocnTo)
                    {
                        if (e.Success && string.IsNullOrEmpty(e.Value))
                            tbQFilterLocnTo.Clear();
                    }
                    // Получение расширенной информации при смене кода товара или серии
                    else if (control == stbItemID)
                    {
                        this.Uom = e.Success && !string.IsNullOrEmpty(e.Value) ? e.OwnedRow["UOM"].ToString() : (string)null;

                        if (e.Success && !string.IsNullOrEmpty(e.Value))
                            this.stbVendorLot.SetValueByDefault("(все)");
                    }
                    else if (control == stbVendorLot)
                    {
                        this.MinQuantity = e.Success && !string.IsNullOrEmpty(e.Value) ? 1.0M : 0.0M;
                        this.MaxQuantity = e.Success && !string.IsNullOrEmpty(e.Value) ? Convert.ToDecimal(e.OwnedRow["QTY"]) : 0.0M;
                        nudQuantity.Value = this.MaxQuantity;
                    }

                    tbDescription.Text = e.Success ? e.Description : string.Empty;

                    if (e.Success)
                        control.Value = e.Value;
                    //else
                    //    control.Value = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (control == stbLocnFrom)
                        tbQFilterLocnFrom.Text = string.Empty;
                    else if (control == stbLocnTo)
                        tbQFilterLocnTo.Text = string.Empty;

                    control.SetValueByDefault(string.Empty);
                    control.Focus();
                }
            }
        }

        private void cbWithoutLift_CheckedChanged(object sender, EventArgs e)
        {
            stbLocnTo.ApplyAdditionalParameter("WO_Lift", cbWithoutLift.Checked);
            stbLocnTo.SetValueByDefault(string.Empty);
            stbLocnTo.Focus();
        }  

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            var btnAdd = this.AddAction("Добавить", () =>
            {
                this.DialogResult = DialogResult.Retry;
            },
            false, new Point(442, 8), AnchorStyles.Right);

            this.btnOK.Location = new Point(532, 8);
            this.btnCancel.Location = new Point(622, 8);

            this.btnOK.Text = "Создать";

            if (!this.SetDescription())
            {
                this.Close();
                return;
            }

            this.UpdateHeader();
        }

        private bool SetDescription()
        {
            var form = new EnterStringValueForm("Примечание", "Введите примечание к создаваемому заданию ТСД:", string.Empty) { AllowEmptyValue = false };
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.Description = form.Value;
                return true;
            }

            return false;
        }

        private void UpdateHeader()
        {
            var sHeader = defaultHeader;
            var sTask = this.TaskID.HasValue ? string.Format(" № {0}({1})", this.TaskID, this.TasksCount) : string.Empty;
            var sDescription = this.Description;

            this.Text = string.Format("{0}{1} : {2}", sHeader, sTask, sDescription);
        }

        private void cbUseAllAvaliableRemains_CheckedChanged(object sender, EventArgs e)
        {
            nudQuantity.Enabled = !cbUseAllAvaliableRemains.Checked;
            nudQuantity.Focus();
        }

        private void tbQFilterLocnFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbQFilterLocnFrom_Leave(sender, EventArgs.Empty);
        }

        private void tbQFilterLocnFrom_Leave(object sender, EventArgs e)
        {
            stbLocnFrom.ApplyAdditionalParameter("Like_Key", tbQFilterLocnFrom.Text);
            if (!string.IsNullOrEmpty(tbQFilterLocnFrom.Text))
                stbLocnFrom.VerifyValue(true, AutoSelectItemSideMode.None);
        }

        private void tbQFilterLocnTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbQFilterLocnTo_Leave(sender, EventArgs.Empty);
        }

        private void tbQFilterLocnTo_Leave(object sender, EventArgs e)
        {
            stbLocnTo.ApplyAdditionalParameter("Like_Key", tbQFilterLocnTo.Text);
            if (!string.IsNullOrEmpty(tbQFilterLocnTo.Text))
                stbLocnTo.VerifyValue(true, AutoSelectItemSideMode.None);
        }

        private void TSD_CreateTaskForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var needAddTask = this.DialogResult == DialogResult.Retry;
            var needConfirmTask = this.DialogResult == DialogResult.OK;
            var cancelTask = this.DialogResult == DialogResult.Cancel;

            var isDataValid = true;
            if (needAddTask || needConfirmTask)
            {
                isDataValid = this.ValidateData();
                if (!isDataValid)
                {
                    e.Cancel = true;
                    return;
                }

                if (needAddTask)
                {
                    isDataValid = this.AddTask();
                    if (!isDataValid)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        this.UpdateHeader();

                        stbLocnFrom.SetValueByDefault(string.Empty);
                        stbLocnFrom.Focus();

                        e.Cancel = true;
                    }
                }
                else if (needConfirmTask)
                {
                    
                    isDataValid = this.AddTask();
                    isDataValid = isDataValid && this.ConfirmTask();
                    if (!isDataValid)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            else if (cancelTask)
            {
                if (this.TaskID.HasValue)
                {
                    if (MessageBox.Show("По последним параметрам задание ТСД  не будет создано.\r\nВы желаете продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        isDataValid = this.ConfirmTask();
                        if (!isDataValid)
                        {
                            e.Cancel = true;
                            return;
                        }
                        else
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        public bool ValidateData()
        {
            try
            {
                if (string.IsNullOrEmpty(stbDocType.Value))
                    throw new Exception("Тип документа должен быть указан.");

                if (string.IsNullOrEmpty(stbWarehouseFromID.Value))
                    throw new Exception("Склад \"Из\" должен быть указан.");

                if (string.IsNullOrEmpty(stbWarehouseToID.Value))
                    throw new Exception("Склад \"В\" должен быть указан.");

                if (string.IsNullOrEmpty(stbLocnFrom.Value))
                    throw new Exception("Место \"Из\" должно быть указано.");

                if (string.IsNullOrEmpty(stbItemID.Value))
                    throw new Exception("Код товара должен быть указан.");

                int itemID;
                if (!int.TryParse(stbItemID.Value, out itemID))
                    throw new Exception("Код товара должен быть числом.");

                if (string.IsNullOrEmpty(stbVendorLot.Value))
                    throw new Exception("Серия товара должна быть указана.");

                if (!cbUseAllAvaliableRemains.Checked && nudQuantity.Value <= 0.0M)
                    throw new Exception("Количество должно быть больше нуля.");

                if (string.IsNullOrEmpty(stbLocnTo.Value))
                    throw new Exception("Место \"В\" должно быть указано.");

                this.DocType = stbDocType.Value;
                this.WarehouseFromID = stbWarehouseFromID.Value;
                this.WarehouseToID = stbWarehouseToID.Value;
                this.LocnFrom = stbLocnFrom.Value;
                this.ItemID = itemID;
                this.VendorLot = stbVendorLot.Value;
                this.LocnTo = stbLocnTo.Value;
                this.Quantity = Convert.ToInt32(nudQuantity.Value);
                this.UseAllAvaliableRemains = cbUseAllAvaliableRemains.Checked;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool AddTask()
        {
            try
            {
                var doc_type = this.DocType;
                var warehouse_from_id = this.WarehouseFromID;
                var warehouse_to_id = this.WarehouseToID;
                var locn_from = this.LocnFrom;
                var locn_to = this.LocnTo;
                var item_id = this.ItemID;
                var uom = this.Uom;
                var vendor_lot = this.VendorLot;
                var qty = this.UseAllAvaliableRemains ? (int?)null : this.Quantity;
                var boxFr = this.UseBoxPickMode;

                var addTaskID = (long?)null;

                using (Data.TSDTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.TSDTableAdapters.QueriesTableAdapter())
                    adapter.AddTask(this.UserID, doc_type, warehouse_from_id, locn_from, locn_to, item_id, vendor_lot, uom, qty, boxFr, warehouse_to_id, this.Description, this.TaskID, ref addTaskID);

                if (addTaskID.HasValue)
                {
                    this.TaskID = addTaskID.Value;
                    this.TasksCount++;
                }
                else
                    throw new Exception("Не удалось создать задание ТСД.");

                return true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ConfirmTask()
        {
            try
            {
                using (Data.TSDTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.TSDTableAdapters.QueriesTableAdapter())
                    adapter.ConfirmTaskPackage(this.TaskID);

                return true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void cbBoxPickMode_CheckedChanged(object sender, EventArgs e)
        {
            cbFraqPickMode.Checked = !cbBoxPickMode.Checked;
        }

        private void cbFraqPickMode_CheckedChanged(object sender, EventArgs e)
        {
            cbBoxPickMode.Checked = !cbFraqPickMode.Checked;
        }      
    }
}
