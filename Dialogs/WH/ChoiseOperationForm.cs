using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class ChoiseOperationForm : DialogForm
    {
        /// <summary>
        /// Код типа операции
        /// </summary>
        public string OperationTypeCode { get; private set; }

        /// <summary>
        /// Название типа операции
        /// </summary>
        public string OperationTypeName { get; private set; }

        public ChoiseOperationForm()
        {
            InitializeComponent();
            this.ApplyAction(DialogResult.None);
        }

        private void ChoiseOperationForm_Load(object sender, EventArgs e)
        {
            this.LoadOperationTypes();
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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.SetInterfaceSettings();
        }

        private void SetInterfaceSettings()
        {
           this.btnOK.Location = new Point(172, 8);
           this.btnCancel.Location = new Point(262, 8);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.ApplyAction(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ApplyAction(DialogResult.Cancel);
        }

        private void ApplyAction(DialogResult agreedResult)
        {
            this.DialogResult = agreedResult;
        }

        private void ChoiseOperationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidateOperation();
        }

        private bool ValidateOperation()
        {
            try
            {
                // Установим тип выбранной операции
                this.OperationTypeCode = cmbOperationType.SelectedValue.ToString();
                this.OperationTypeName = cmbOperationType.Text;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
