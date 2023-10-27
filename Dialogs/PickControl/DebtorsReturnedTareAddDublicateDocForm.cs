using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class DebtorsReturnedTareAddDublicateDocForm : DialogForm
    {
        private readonly Data.Delivery.ClientTareTypesDataTable clientTateTypesCache = new WMSOffice.Data.Delivery.ClientTareTypesDataTable();

        public long? DocID { get; private set; }

        public DebtorsReturnedTareAddDublicateDocForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(97, 8);
            this.btnCancel.Location = new Point(187, 8);
        }

        private void DebtorsReturnedTareAddDublicateDocForm_Load(object sender, EventArgs e)
        {
            Initialize();
            LoadTareTypes();
            ChangeBarCodeFlag(false);
        }

        private void Initialize()
        {
            stbWarehouse.ValueReferenceQuery = "[dbo].[pr_DBL_RET_Get_Warehouses]";
            stbWarehouse.UserID = this.UserID;
            stbWarehouse.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            Label lblDescription = null;

            if (control == stbWarehouse)
                lblDescription = lblWarehouseName;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                {
                    control.Value = e.Value;

                    if (!string.IsNullOrEmpty(e.Value))
                        this.SelectNextControl(control, true, true, true, false);
                }
                //else
                //    control.Value = string.Empty;
            }
        }

        private void LoadTareTypes()
        {
            try
            {
                this.clientTareTypesTableAdapter.Fill(clientTateTypesCache);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AttachClientTareTypes()
        {
            this.delivery.ClientTareTypes.Clear();

            if (cbWithoutBarCode.Checked)
                this.delivery.ClientTareTypes.Merge(clientTateTypesCache, true);

            cmbTareType.SelectedValue = "N/A";
        }

        private void cbWithoutBarCode_CheckedChanged(object sender, EventArgs e)
        {
            ChangeBarCodeFlag(cbWithoutBarCode.Checked);
        }

        private void ChangeBarCodeFlag(bool isChecked)
        {
            gbWithoutBarCode.Enabled = isChecked;
            tbTareBarCode.Enabled = !isChecked;

            tbTareBarCode.Clear();
            AttachClientTareTypes();

            this.SelectNextControl(cbWithoutBarCode, isChecked, true, true, false);
        }

        private void tbTareBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                stbWarehouse.Focus();
        }

        private void DebtorsReturnedTareAddDublicateDocForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                var tareType = (string)null;
                var noBar = (int?)null;
                var tareBarCode = (string)null;
                var warehouse = (string)null;

                // 0. Валидация
                if (cbWithoutBarCode.Checked)
                {
                    if (cmbTareType.SelectedValue == null)
                        throw new Exception("Выберите тип тары.");

                    tareType = cmbTareType.SelectedValue.ToString();
                    noBar = 1;
                }
                else
                {
                    if (string.IsNullOrEmpty(tbTareBarCode.Text))
                        throw new Exception("Введите ш/к тары.");

                    tareBarCode = tbTareBarCode.Text;
                }
              
                if (string.IsNullOrEmpty(stbWarehouse.Value))
                    throw new Exception("Выберите склад.");

                warehouse = stbWarehouse.Value;

                
                // 1. Создание документа
                var docObject = (object)null;

                using (var adapter = new Data.PickControlTableAdapters.DBL_RET_DocsTableAdapter())
                    docObject = adapter.CreateDoc(tareBarCode, warehouse, this.UserID, noBar, tareType);

                if (docObject == null)
                    throw new Exception("Документ не был создан.");

                this.DocID = Convert.ToInt64(docObject);

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
