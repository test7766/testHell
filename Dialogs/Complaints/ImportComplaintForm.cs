using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class ImportComplaintForm : DialogForm
    {
        public ImportComplaintStages ImportStage { get; private set; }

        public ImportComplaintForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            btnOK.Location = new Point(717, 8);
            btnCancel.Location = new Point(807, 8);

            ImportStage = ImportComplaintStages.ImportCreated;
            btnOK.Text = "Импорт";
            btnOK.Enabled = false;

            btnOK.DialogResult = DialogResult.None;
            btnOK.Click += new EventHandler(btnOK_Click);
        }

        private void Initialize()
        {
            this.LoadDocTypes();
        }

        private void LoadDocTypes()
        {
            try
            {
                availableDocsTypesTableAdapter.FillForImport(complaints.AvailableDocsTypes, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsiPasteFromClipboard_Click(object sender, EventArgs e)
        {
            ParseClipboard();
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            switch (ImportStage)
            { 
                case ImportComplaintStages.ParseClipboard:
                    ParseClipboard();
                    break;
                case ImportComplaintStages.ParseXML:
                    ParseXML();
                    break;
                case ImportComplaintStages.CreateComplaints:
                    CreateComplaints();
                    break;
                default:
                    break;
            }
        }

        private void ParseClipboard()
        {
            try
            {
                string[] lines;
                if (!CheckClipboard(out lines))
                    return;

                complaints.CO_Processed_Imported_Docs.Clear();

                #region parse line cells
                foreach (var line in lines)
                {
                    if (string.IsNullOrEmpty(line.Trim('\t')))
                        continue;

                    var cells = line.Split(new char[] { '\t' }, StringSplitOptions.None);

                    var dataRow = complaints.CO_Processed_Imported_Docs.NewCO_Processed_Imported_DocsRow();

                    var errors = new StringBuilder();

                    if (cells.Length > 0)
                    {
                        if (!string.IsNullOrEmpty(cells[0]))
                        {
                            int invoiceNumber;
                            if (int.TryParse(cells[0], out invoiceNumber))
                                dataRow.InvoiceNumber = invoiceNumber;
                            else
                            {
                                if (errors.Length > 0)
                                    errors.AppendFormat("; Некорректный номер накладной: {0}", cells[0]);
                                else
                                    errors.AppendFormat("Некорректный номер накладной: {0}", cells[0]);
                            }
                        }
                        else
                            errors.AppendFormat("Отсутствует номер накладной");
                    }

                    if (cells.Length > 1)
                    {
                        if (!string.IsNullOrEmpty(cells[1]))
                        {
                            int pickSlipNumber;
                            if (int.TryParse(cells[1], out pickSlipNumber))
                                dataRow.PickSlipNumber = pickSlipNumber;
                            else
                            {
                                if (errors.Length > 0)
                                    errors.AppendFormat("; Некорректный номер сборочного: {0}", cells[1]);
                                else
                                    errors.AppendFormat("Некорректный номер сборочного: {0}", cells[1]);
                            }
                        }
                    }

                    if (errors.Length > 1)
                        dataRow.ErrorType = 1;
                    else
                    {
                        //errors.AppendFormat("ОК");
                        dataRow.ErrorType = -2;
                    }

                    dataRow.Errors = errors.ToString().Trim('\n');

                    complaints.CO_Processed_Imported_Docs.AddCO_Processed_Imported_DocsRow(dataRow);
                }
                #endregion

                DeselectRows();

                if (CheckCorrectLines())
                {
                    ImportStage = ImportComplaintStages.ParseXML;
                    btnOK.Enabled = true;
                    if (MessageBox.Show("Начать импорт для успешно обработанных строк?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        ParseXML();
                    else
                        btnOK.Focus();
                }
                else
                {
                    ImportStage = ImportComplaintStages.ImportCreated;
                    btnOK.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckClipboard(out string[] lines)
        {
            lines = new string[0];

            try
            {
                if (!Clipboard.ContainsText())
                    throw new Exception("Отсутствуют данные для импорта.");

                lines = Clipboard.GetText().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                if (lines.Length == 0)
                    throw new Exception("Отсутствуют данные для импорта.");

                ImportStage = ImportComplaintStages.ParseClipboard;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void DeselectRows()
        {
            if (dgvImportedData.Rows.Count > 0)
                dgvImportedData.Rows[0].Selected = false;
        }

        private bool CheckCorrectLines()
        {
            var cntCorrectLines = GetCorrectLinesCount();
            return cntCorrectLines > 0;
        }

        private int GetCorrectLinesCount()
        {
            var cntCorrectLines = (int)complaints.CO_Processed_Imported_Docs.Compute(string.Format("COUNT({0})", complaints.CO_Processed_Imported_Docs.ErrorTypeColumn.Caption), string.Format("{0} <> 1", complaints.CO_Processed_Imported_Docs.ErrorTypeColumn.Caption));
            return cntCorrectLines;
        }

        private void ParseXML()
        {
            try
            {
                FillImportedDocsByXML();

                DeselectRows();

                if (CheckCorrectLines())
                {
                    ImportStage = ImportComplaintStages.CreateComplaints;
                    btnOK.Text = "Сохранить";
                    if (MessageBox.Show("Продолжить импорт для успешно обработанных строк?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        CreateComplaints();
                    else
                        btnOK.Focus();
                }
                else
                {
                    ImportStage = ImportComplaintStages.ImportCreated;
                    btnOK.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateComplaints()
        {
            try
            {
                FillImportedDocsByXML();

                DeselectRows();

                var cntCorrectLines = GetCorrectLinesCount();
                if (cntCorrectLines > 0)
                {
                    ImportStage = ImportComplaintStages.ImportCompleted;
                    MessageBox.Show(string.Format("Импорт завершен.\nСоздано претензий: {0}", cntCorrectLines), "Результат импорта", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmsiPasteFromClipboard.Enabled = false;
                    btnOK.Visible = false;
                    btnCancel.Text = "Закрыть";
                    btnCancel.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillImportedDocsByXML()
        {
            var xData = this.CreateImportDataXML();

            var createDocs = ImportStage == ImportComplaintStages.CreateComplaints;
            using (var adapter = new Data.ComplaintsTableAdapters.CO_Processed_Imported_DocsTableAdapter())
                adapter.Fill(complaints.CO_Processed_Imported_Docs, this.UserID, (string)cmbComplaintType.SelectedValue, xData.InnerXml, createDocs);
        }

        private XmlDocument CreateImportDataXML()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml("<Data></Data>");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlAttribute xValue = null;

            #region Lines

            var xLinesElement = xDoc.CreateElement("Lines");
            foreach (Data.Complaints.CO_Processed_Imported_DocsRow line in complaints.CO_Processed_Imported_Docs)
            {
                if (line.ErrorType == 1)
                    continue;

                var xLineElement = xDoc.CreateElement("Line");

                xValue = xLineElement.Attributes.Append(xDoc.CreateAttribute("doc"));
                xValue.Value = line.IsInvoiceNumberNull() ? string.Empty : line.InvoiceNumber.ToString();

                xValue = xLineElement.Attributes.Append(xDoc.CreateAttribute("psn"));
                xValue.Value = line.IsPickSlipNumberNull() ? string.Empty : line.PickSlipNumber.ToString();

                xLinesElement.AppendChild(xLineElement);
            }
            xRoot.AppendChild(xLinesElement);
            #endregion

            return xDoc;
        }

        private void dgvImportedData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var dataRow = (dgvImportedData.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Complaints.CO_Processed_Imported_DocsRow;
            var color = dataRow.IsErrorTypeNull() ? Color.White : dataRow.ErrorType == -2 ? Color.White : dataRow.ErrorType == -1 ? Color.Khaki : dataRow.ErrorType == 0 ? Color.LightGreen : dataRow.ErrorType == 1 ? Color.LightPink : Color.White;

            e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = color;
        }


        /// <summary>
        /// Типы этапов импорта претензии
        /// </summary>
        public enum ImportComplaintStages
        {
            /// <summary>
            /// Создание импорта
            /// </summary>
            ImportCreated,

            /// <summary>
            /// Парсинг буфера обмена
            /// </summary>
            ParseClipboard,

            /// <summary>
            /// Парсинг XML
            /// </summary>
            ParseXML,

            /// <summary>
            /// Создание претензий
            /// </summary>
            CreateComplaints,

            /// <summary>
            /// Завершение импорта
            /// </summary>
            ImportCompleted
        }
    }
}
