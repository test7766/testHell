using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class ComplaintCheckErrorsForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        private readonly Data.Complaints.CheckDocDataTable _checkTable = null;

        public string Comment { get; private set; }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public ComplaintCheckErrorsForm()
        {
            InitializeComponent();
        }

        public ComplaintCheckErrorsForm(Data.Complaints.CheckDocDataTable pCheckTable)
            :this()
        {
            _checkTable = pCheckTable;
        }

        private void CreateComplaintCheckErrorsForm_Load(object sender, EventArgs e)
        {
            dgvExceptions.DataSource = _checkTable;

            if (dgvExceptions.Rows.Count > 0)
                dgvExceptions.Rows[0].Selected = false;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(400, 8);
            this.btnCancel.Location = new Point(510, 8);

            this.btnOK.Text = "Передать в ОМУ";
            this.btnOK.Width = 105;
        }

        #endregion

        private void dgvExceptions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dr = (dgvExceptions.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Complaints.CheckDocRow;

            bool isWarning = dr.IsWarning;
            bool isError = dr.IsError;

            if (isWarning)
            {
                e.CellStyle.BackColor = Color.Khaki;
                e.CellStyle.SelectionForeColor = Color.Khaki;
            }
            else
                if (isError)
                {
                    e.CellStyle.BackColor = Color.Salmon;
                    e.CellStyle.SelectionForeColor = Color.Salmon;
                }
        }

        private void ComplaintCheckErrorsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ApplyIgnore();
        }

        private bool ApplyIgnore()
        {
            try
            {
                var dlgEnterStringValueForm = new EnterStringValueForm("Комментарий", "Введите примечание к исключению проверок", string.Empty) { AllowEmptyValue = false };

                if (dlgEnterStringValueForm.ShowDialog() == DialogResult.OK)
                {
                    this.Comment = dlgEnterStringValueForm.Value;
                    return true;
                }
                else
                    throw new Exception("Не указано примечание!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
