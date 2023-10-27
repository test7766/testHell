using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Reports;
using WMSOffice.Data.ReceiveTableAdapters;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Receive
{
    /// <summary>
    /// Редактор проблемного товара
    /// </summary>
    public partial class ProblemItemEditorForm : DialogForm
    {
        /// <summary>
        /// Источник данных для проблемного товара
        /// </summary>
        public Data.ProxyBusinessObjects.ProblemItemRow SourceItem { get; set; }

        public ProblemItemEditorForm()
        {
            InitializeComponent();
        }

        private void ProblemItemEditorForm_Load(object sender, EventArgs e)
        {
            this.LoadProblemItemCategories();
            this.problemItemBindingSource.DataSource = this.SourceItem;
        }

        private void LoadProblemItemCategories()
        {
            try
            {
                Data.Receive.ProblemItemCategoriesDataTable table = new WMSOffice.Data.Receive.ProblemItemCategoriesDataTable();
                table.LoadDataRow(new object[] { -1, "<Не указана>" }, true);
                table.Merge(this.problemItemCategoriesTableAdapter.GetData(this.UserID));
                this.problemItemCategoriesBindingSource.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(265, 8);
            this.btnCancel.Location = new Point(365, 8);
        }

        private void ProblemItemEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveProblemItem();
        }

        /// <summary>
        /// Сохранение проблемного товара
        /// </summary>
        /// <returns></returns>
        private bool SaveProblemItem()
        {
            if (this.SourceItem.ProblemCategoryID == -1)
            {
                MessageBox.Show("Укажите категорию Проблемного Товара.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                long docID;
                using (Data.ReceiveTableAdapters.ItemsTableAdapter adapter = new WMSOffice.Data.ReceiveTableAdapters.ItemsTableAdapter())
                    docID = Convert.ToInt64(adapter.SaveProblemItemQuantity(this.UserID, this.SourceItem.ItemID, this.SourceItem.LotNumber, (double)this.SourceItem.ProblemQuantity, null, this.SourceItem.Location, this.SourceItem.ProblemCategoryID));
                //docID = 402855; // TODO FOR TEST ONLY

                this.PrintPackList(docID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Печать пак-листа
        /// </summary>
        /// <param name="DocID"></param>
        private void PrintPackList(long docID)
        {
            Data.Receive receiveSource = new WMSOffice.Data.Receive();

            Data.Receive.ProblemItemPackReportDataTable table;
            using (Data.ReceiveTableAdapters.ProblemItemPackReportTableAdapter adapter = new ProblemItemPackReportTableAdapter())
                table = adapter.GetData(this.UserID, docID);

            foreach (Data.Receive.ProblemItemPackReportRow row in table.Rows)
            {
                var line = receiveSource.DocLines.NewDocLinesRow();
                line.BX_Qty = row.IsQtyBXNull() ? 0 : row.QtyBX;
                line.IT_Qty = row.IsQtyITNull() ? 0 : row.QtyIT;
                line.Item_ID = row.IsItem_IDNull() ? 0 : row.Item_ID;
                line.Item_Name = row.IsItem_NameNull() ? "" : row.Item_Name;
                line.ITinBX = row.IsITinBXNull() ? 0 : row.ITinBX;
                line.LocationFrom = row.IsLocn_TONull() ? "" : row.Locn_TO;
                line.Lot_Code = row.IsLot_CodeNull() ? "" : row.Lot_Code;
                line.Lot_Number = row.IsLot_NumberNull() ? "" : row.Lot_Number;
                line.Manufacturer = row.IsManufacturerNull() ? "" : row.Manufacturer;
                line.UnitOfMeasure = row.IsUnitOfMeasure_1Null() ? "" : row.UnitOfMeasure_1;
                line.Qty = row.IsQtyNull() ? 0 : row.Qty;
                receiveSource.DocLines.AddDocLinesRow(line);
            }

            // напечатаем упаковочный лист
            PackingListReport report = new PackingListReport();
            BarcodePrepare(receiveSource, docID, "BR");

            if (receiveSource.Docs.Count > 0 && receiveSource.DocLines.Count > 0)
                receiveSource.Docs[0].Location_To = receiveSource.DocLines[0].LocationFrom;

            report.SetDataSource(receiveSource);
            report.SetParameterValue("DocID", docID);

            ReportForm form = new ReportForm();
            form.ReportDocument = report;
            form.Print();
        }

        /// <summary>
        /// Подготовка ш/к для пак-листа
        /// </summary>
        /// <param name="receive"></param>
        /// <param name="docID"></param>
        /// <param name="docType"></param>
        public static void BarcodePrepare(Data.Receive receive, long docID, string docType)
        {
            using (DocsTableAdapter adapter = new DocsTableAdapter())
            {
                adapter.Fill(receive.Docs, docID, docType);
                if (receive.Docs.Count > 0)
                {
                    // создание штрих-кода
                    BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                    barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                    barCodeCtrl.Size = new Size(274 * 5, 108 * 5);
                    barCodeCtrl.BarCodeHeight = 50 * 5;
                    barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 12 * 5, FontStyle.Bold);
                    barCodeCtrl.HeaderText = "";
                    barCodeCtrl.LeftMargin = 10 * 5;
                    barCodeCtrl.ShowFooter = true;
                    barCodeCtrl.TopMargin = 20 * 5;
                    barCodeCtrl.BarCode = receive.Docs[0].Bar_Code; //"12345678PRWMS";
                    byte[] barCode = null;
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        barCode = ms.ToArray();
                    }
                    receive.Docs[0].Bar_Code_IMG = barCode;
                }
            }
        }

        private void dgvProblemItem_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == dgvProblemItem.Columns[problemQuantityDataGridViewTextBoxColumn.Name].Index)
            {
                if (e.Exception != null)
                {
                    var context = (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit);
                    if (e.Context == context)
                    {
                        MessageBox.Show(string.Format("Неверный формат числа для поля \"{0}\".", problemQuantityDataGridViewTextBoxColumn.HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvProblemItem_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.dgvProblemItem.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
            {
                this.dgvProblemItem.CurrentCell = this.dgvProblemItem.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.dgvProblemItem.BeginEdit(true);
            }
        }
    }
}
