using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class DocsForBranchesOfPersonalResponsibilityCreateForm : DialogForm
    {
        private static readonly int REASON_MAX_LENGTH = 100;

        public DocsForBranchesOfPersonalResponsibilityCreateForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(367, 8);
            btnCancel.Location = new Point(457, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            stbEmployee.ValueReferenceQuery = "[dbo].[pr_MB_Get_Doc_Employees_List]";
            stbEmployee.ApplyAdditionalParameter("Exclude_Fired", true);
            stbEmployee.UserID = this.UserID;
            stbEmployee.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbFilterItem_OnVerifyValue);

            stbWarehouse.ValueReferenceQuery = "[dbo].[pr_MB_Get_Doc_Warehouses_List]";
            stbWarehouse.ApplyAdditionalParameter("Employee_ID", string.Empty);
            stbWarehouse.UserID = this.UserID;
            stbWarehouse.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbFilterItem_OnVerifyValue);

            stbLocationType.ValueReferenceQuery = "[dbo].[pr_MB_Get_Doc_Location_Types_List]";
            stbLocationType.ApplyAdditionalParameter("Warehouse_ID", string.Empty);
            stbLocationType.UserID = this.UserID;
            stbLocationType.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbFilterItem_OnVerifyValue);

            tbDocReason.MaxLength = REASON_MAX_LENGTH;
        }

        void stbFilterItem_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbEmployee)
                lblDescription = tbEmployee;
            else if (control == stbWarehouse)
                lblDescription = tbWarehouse;
            else if (control == stbLocationType)
                lblDescription = tbLocationType;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (control == stbEmployee)
                {
                    stbWarehouse.ApplyAdditionalParameter("Employee_ID", e.Value);
                    stbWarehouse.SetValueByDefault(string.Empty);

                    lblDescription.Font = new Font(lblDescription.Font, FontStyle.Regular);

                    tbDepartment.Clear();
                    tbEmployeePost.Clear();

                    if (e.Success && !string.IsNullOrEmpty(e.Value))
                    {
                        lblDescription.Font = new Font(lblDescription.Font, FontStyle.Bold);

                        tbDepartment.Text = e.OwnedRow["Department"].ToString();
                        tbEmployeePost.Text = e.OwnedRow["Employee_Post"].ToString();
                    }
                }
                else if (control == stbWarehouse)
                {
                    stbLocationType.ApplyAdditionalParameter("Warehouse_ID", e.Value);
                    stbLocationType.SetValueByDefault(string.Empty);
                }


                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;
            }
        }

        private void DocsForBranchesOfPersonalResponsibilityCreateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.CreateDoc();
        }

        private bool CreateDoc()
        {
            try
            {
                int employeeID;
                if (!string.IsNullOrEmpty(stbEmployee.Value))
                {
                    if (!int.TryParse(stbEmployee.Value, out employeeID))
                        throw new Exception("Код сотрудника должен быть числом.");
                }
                else
                    throw new Exception("Не выбран сотрудник.");


                string warehouseID;
                if (!string.IsNullOrEmpty(stbWarehouse.Value))
                    warehouseID = stbWarehouse.Value;
                else
                    throw new Exception("Не выбран склад.");


                string locationTypeID;
                if (!string.IsNullOrEmpty(stbLocationType.Value))
                    locationTypeID = stbLocationType.Value;
                else
                    throw new Exception("Не выбран тип полки.");


                string reason;
                if (!string.IsNullOrEmpty(tbDocReason.Text.Trim()))
                    reason = tbDocReason.Text.Trim();
                else
                    throw new Exception("Не указана причина.");

                //string reason = tbDocReason.Text.Trim();
                ////reason = reason.Substring(0, Math.Min(reason.Length, REASON_MAX_LENGTH));
                //if (string.IsNullOrEmpty(reason))
                //    throw new Exception("Не указана причина.");
                ////else
                ////    if (reason.Length > REASON_MAX_LENGTH)
                ////        throw new Exception(string.Format("Размер текста в поле Причина не должен превышать {0} символов.", REASON_MAX_LENGTH));

                
                var locationName = (string)null;
                using (var adapter = new Data.PickControlTableAdapters.MB_DocsTableAdapter())
                    adapter.CreateDoc(this.UserID, employeeID, warehouseID, locationTypeID, reason, ref locationName);

                if (!string.IsNullOrEmpty(locationName))
                    MessageBox.Show(string.Format("Добавлена заявка\nна создание полки \"{0}\" на складе \"{1}\"\nдля сотрудника {2}", locationName, warehouseID.Trim(), tbEmployee.Text), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
