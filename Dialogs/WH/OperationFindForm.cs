using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class OperationFindForm : DialogForm
    {
        #region Статические поля
        public static string SubDocType { get; private set; }
        public static DateTime? DateFrom { get; private set; }
        public static DateTime? DateTo { get; private set; }
        public static string StatusID { get; private set; }
        public static string WarehouseID { get; private set; }
        public static double? JDDocID { get; private set; }
        public static string JDDocType { get; private set; }
        public static double? BatchNumber { get; private set; }
        public static long? TSDDocID { get; private set; }
        public static string TSDDocType { get; private set; }
        public static bool? IsVirtual { get; private set; }
        public static int? EmployeeID { get; private set; }
        public static string Description { get; private set; }
        public static bool? CloseOperations {get; private set;}

        public static bool ActivateSubDocType { get; private set; }
        public static bool ActivateDateFrom { get; private set; }
        public static bool ActivateDateTo { get; private set; }
        public static bool ActivateStatusID { get; private set; }
        public static bool ActivateWarehouseID { get; private set; }
        public static bool ActivateJDDocID { get; private set; }
        public static bool ActivateJDDocType { get; private set; }
        public static bool ActivateBatchNumber { get; private set; }
        public static bool ActivateTSDDocID { get; private set; }
        public static bool ActivateTSDDocType { get; private set; }
        public static bool ActivateIsVirtual { get; private set; }
        public static bool ActivateEmployeeID { get; private set; }
        public static bool ActivateDescription { get; private set; }
        public static bool ActivateCloseOperations { get; private set; }
        #endregion

        static OperationFindForm()
        {
            SubDocType = null;
            DateFrom = null;
            DateTo = null;
            StatusID = null;
            WarehouseID = null;
            JDDocID = null;
            JDDocType = null;
            BatchNumber = null;
            TSDDocID = null;
            TSDDocType = null;
            IsVirtual = null;
            EmployeeID = null;
            Description = null; 
            CloseOperations = null;
        }

        public OperationFindForm()
        {
            InitializeComponent();
            this.ApplyOperation(DialogResult.None);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.SetInterfaceSettings();
            this.LoadWarehouses();
            this.LoadOperationTypes();
            this.InitializeValues();
        }

        private void InitializeValues()
        {
            if (SubDocType != null)
                cmbOperationDocType.SelectedValue = SubDocType;
            dtDateFrom.Value = DateFrom.HasValue ? DateFrom.Value : DateTime.Today;
            dtDateTo.Value = DateTo.HasValue ? DateTo.Value : DateTime.Today;
            tbStatusID.Text = StatusID;
            if (WarehouseID != null)
                cmbWarehouses.SelectedValue = WarehouseID;
            tbJDDocID.Text = JDDocID.ToString();
            tbJDDocType.Text = JDDocType;
            tbBatchNumber.Text = BatchNumber.ToString();
            tbTSDDocID.Text = TSDDocID.ToString();
            tbTSDDocType.Text = TSDDocType;
            cbIsVirtual.Checked = IsVirtual.HasValue ? IsVirtual.Value : false;
            tbEmployeeID.Text = EmployeeID.ToString();
            tbDescription.Text = Description;
            cbCloseOperations.Checked = CloseOperations.HasValue ? CloseOperations.Value : false;

            cbActivateSubDocType.Checked = ActivateSubDocType;
            cbActivateDateFrom.Checked = ActivateDateFrom;
            cbActivateDateTo.Checked = ActivateDateTo;
            cbActivateStatusID.Checked = ActivateStatusID;
            cbActivateWarehouseID.Checked = ActivateWarehouseID;
            cbActivateJDDocID.Checked = ActivateJDDocID;
            cbActivateJDDocType.Checked = ActivateJDDocType;
            cbActivateBatchNumber.Checked = ActivateBatchNumber;
            cbActivateTSDDocID.Checked = ActivateTSDDocID;
            cbActivateTSDDocType.Checked = ActivateTSDDocType;
            cbActivateIsVirtual.Checked = ActivateIsVirtual;
            cbActivateEmployeeID.Checked = ActivateEmployeeID;
            cbActivateDescription.Checked = ActivateDescription;
            cbActivateCloseOperations.Checked = ActivateCloseOperations;
        }

        private void SetInterfaceSettings()
        {
            this.btnOK.Location = new Point(369, 8);
            this.btnCancel.Location = new Point(459, 8);
        }

        /// <summary>
        /// Заполнение справочника складов
        /// </summary>
        private void LoadWarehouses()
        {
            try
            {
                this.operationWarehousesTableAdapter.Fill(this.wH.OperationWarehouses, this.UserID);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Ошибка загрузки справочника складов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Загрузка справочника типов операций
        /// </summary>
        private void LoadOperationTypes()
        {
            try
            {
                this.operationsTypesTableAdapter.Fill(this.wH.OperationsTypes, this.UserID);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Ошибка загрузки справочника типов операций", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyOperation(DialogResult agreedResult)
        {
            this.DialogResult = agreedResult;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.Cancel);
        }

        private void OperationFindForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidateOperation();
        }

        private bool ValidateOperation()
        {
            try
            {
                SubDocType =  (ActivateSubDocType = cbActivateSubDocType.Checked) ? cmbOperationDocType.SelectedValue.ToString() : null;
                DateFrom = (ActivateDateFrom = cbActivateDateFrom.Checked) ? dtDateFrom.Value : (DateTime?)null;
                DateTo = (ActivateDateTo = cbActivateDateTo.Checked) ? dtDateTo.Value : (DateTime?)null;
                StatusID = (ActivateStatusID = cbActivateStatusID.Checked) ? tbStatusID.Text.Trim() : null;
                WarehouseID = (ActivateWarehouseID = cbActivateWarehouseID.Checked) ? cmbWarehouses.SelectedValue.ToString() : null;
                try
                {
                    JDDocID = (ActivateJDDocID = cbActivateJDDocID.Checked) ? Convert.ToDouble(tbJDDocID.Text.Trim()) : (double?)null;
                }
                catch
                {
                    throw new Exception("№ документа JD должен быть числом");
                }
                JDDocType = (ActivateJDDocType = cbActivateJDDocType.Checked) ? tbJDDocType.Text.Trim() : null;
                try
                {
                    BatchNumber = (ActivateBatchNumber = cbActivateBatchNumber.Checked) ? Convert.ToDouble(tbBatchNumber.Text.Trim()) : (double?)null;
                }
                catch
                {
                    throw new Exception("№ пакета должен быть числом");
                }
                try
                {
                    TSDDocID = (ActivateTSDDocID = cbActivateTSDDocID.Checked) ? Convert.ToInt64(tbTSDDocID.Text.Trim()) : (long?)null;
                }
                catch
                {
                    throw new Exception("№ задания ТСД должен быть числом");
                }
                TSDDocType= (ActivateTSDDocType = cbActivateTSDDocType.Checked) ? tbTSDDocType.Text.Trim() : null;
                IsVirtual = (ActivateIsVirtual = cbActivateIsVirtual.Checked) ? cbIsVirtual.Checked : (bool?)null;
                try
                {
                    EmployeeID = (ActivateEmployeeID = cbActivateEmployeeID.Checked) ? Convert.ToInt32(tbEmployeeID.Text.Trim()) : (int?)null;
                }
                catch
                {
                    throw new Exception("Код сотрудника должен быть числом");
                }
                Description = (ActivateDescription = cbActivateDescription.Checked) ? tbDescription.Text.Trim() : null;
                CloseOperations = (ActivateCloseOperations = cbActivateCloseOperations.Checked) ? cbCloseOperations.Checked : (bool?)null;

                return true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка задания критериев поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
