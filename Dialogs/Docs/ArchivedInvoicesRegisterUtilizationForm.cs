using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using System.Xml;

namespace WMSOffice.Dialogs.Docs
{
    public partial class ArchivedInvoicesRegisterUtilizationForm : DialogForm
    {
        public ArchivedInvoicesRegisterUtilizationForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(567, 8);
            this.btnCancel.Location = new Point(657, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            nudYearFrom.Minimum = 2010M;
            nudYearTo.Minimum = 2010M;

            var today = DateTime.Today;
            nudYearFrom.Value = Convert.ToDecimal(today.Year);
            nudYearTo.Value = Convert.ToDecimal(today.Year);

            stbDebtor.ValueReferenceQuery = "[dbo].[pr_RG_Get_Debtors_List]";
            stbDebtor.UserID = this.UserID;
            stbDebtor.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbInvoiceType.ValueReferenceQuery = "[dbo].[pr_RG_Get_Doc_Types_List]";
            stbInvoiceType.UserID = this.UserID;
            stbInvoiceType.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbDebtor)
                lblDescription = tbDebtor;
            else if (control == stbInvoiceType)
                lblDescription = tbInvoiceType;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;
            }
        }

        private void btnSearchInvoices_Click(object sender, EventArgs e)
        {
            this.SearchInvoices();
        }

        private void SearchInvoices()
        {
            try
            {
                var yearFrom = Convert.ToInt32(nudYearFrom.Value);
                var yearTo = Convert.ToInt32(nudYearTo.Value);

                if (yearFrom > yearTo)
                    throw new Exception("Початковий рік не повинен перевищувати\nкінцевий.");

                var debtorID = (int?)null;
                if (!string.IsNullOrEmpty(stbDebtor.Value))
                {
                    int parsedDebtorID;
                    if (!int.TryParse(stbDebtor.Value, out parsedDebtorID))
                        throw new Exception("Дебітор повинен бути числом.");
                    else
                        debtorID = parsedDebtorID;
                }

                var invoiceType = (string)null;
                if (!string.IsNullOrEmpty(stbInvoiceType.Value))
                    invoiceType = stbInvoiceType.Value;

                var invoiceNumber = (int?)null;
                if (!string.IsNullOrEmpty(tbInvoiceNumber.Text))
                {
                    int parsedInvoiceNumber;
                    if (!int.TryParse(tbInvoiceNumber.Text, out parsedInvoiceNumber))
                        throw new Exception("№ накладної повинен бути числом.");
                    else
                        invoiceNumber = parsedInvoiceNumber;
                }

                var xDoc = this.CreateXml();

                var splashForm = new SplashForm();

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        using (var adapter = new Data.WHTableAdapters.RG_Register_Docs_For_UtilizationTableAdapter())
                            e.Result = adapter.GetData(this.UserID, yearFrom, yearTo, debtorID, invoiceType, invoiceNumber, xDoc.InnerXml);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    splashForm.CloseForce();

                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        rGRegisterDocsForUtilizationBindingSource.DataSource = e.Result;
                };

                splashForm.ActionText = "Виконується пошук документів..";
                rGRegisterDocsForUtilizationBindingSource.DataSource = null;
                bw.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public XmlDocument CreateXml()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml("<Docs></Docs>");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlAttribute xValue = null;
            foreach (Data.WH.RG_Register_Docs_For_UtilizationRow doc in wH.RG_Register_Docs_For_Utilization.Select(string.Format("{0} = 1", wH.RG_Register_Docs_For_Utilization.IsCheckedColumn.Caption)))
            {
                var xDocElement = xDoc.CreateElement("Doc");

                xValue = xDocElement.Attributes.Append(xDoc.CreateAttribute("doc_number"));
                xValue.Value = doc.IsInvoiceNumberNull() ? string.Empty : doc.InvoiceNumber.ToString();

                xValue = xDocElement.Attributes.Append(xDoc.CreateAttribute("doc_type"));
                xValue.Value = doc.IsInvoiceTypeNull() ? string.Empty : doc.InvoiceType.ToString();

                xRoot.AppendChild(xDocElement);
            }

            return xDoc;
        }

        private void dgvInvoices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvInvoices.Rows.Count > 0)
                dgvInvoices.Rows[0].Selected = false;
        }

        private void dgvInvoices_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvInvoices.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvInvoices.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool isChecked = Convert.ToBoolean(this.dgvInvoices.Rows[this.dgvInvoices.CurrentRow.Index].Cells[this.isCheckedDataGridViewCheckBoxColumn.Index].Value);
                foreach (DataGridViewColumn column in this.dgvInvoices.Columns)
                {
                    this.dgvInvoices.Rows[this.dgvInvoices.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    this.dgvInvoices.Rows[this.dgvInvoices.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
                }
            }
        }

        private void dgvInvoices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            bool isChecked = Convert.ToBoolean(this.dgvInvoices.Rows[e.RowIndex].Cells[this.isCheckedDataGridViewCheckBoxColumn.Index].Value);
            this.dgvInvoices.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            this.dgvInvoices.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
        }

        private void tbInvoiceNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(tbInvoiceNumber.Text))
                this.SearchInvoices();
        }

        private void ArchivedInvoicesRegisterUtilizationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.CreateUtilization();
        }

        private bool CreateUtilization()
        {
            try
            {
                var yearFrom = Convert.ToInt32(nudYearFrom.Value);
                var yearTo = Convert.ToInt32(nudYearTo.Value);

                if (yearFrom > yearTo)
                    throw new Exception("Початковий рік не повинен перевищувати\nкінцевий.");

                var xDoc = this.CreateXml();

                rG_Register_Docs_For_UtilizationTableAdapter.CreateUtilization(this.UserID, yearFrom, yearTo, xDoc.InnerXml);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
