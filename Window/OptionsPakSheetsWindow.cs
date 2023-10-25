using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WMSOffice.Classes;

namespace WMSOffice.Window
{
    public partial class OptionsPakSheetsWindow : GeneralWindow
    {
        public OptionsPakSheetsWindow()
        {
            InitializeComponent();

            dateTo.Value = DateTime.Today.AddDays(1);
            dateFrom.Value = dateTo.Value.AddDays(-30);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            PrepareData();
        }

        private void PrepareData()
        {
            wf_get_ib_docsTableAdapter.Fill(wF.wf_get_ib_docs, DocId, dateFrom.Value, dateTo.Value, null, ItemId, EmpId, checkBox.Checked ? 1 : 0);
        }

        private int? DocId
        {
            get
            {
                int docId;
                if (int.TryParse(tbDoc.Text, out docId))
                    return docId;
                return null;
            }
        }

        private int? ItemId
        {
            get
            {
                int itemId;
                if (int.TryParse(tbItemCode.Text, out itemId))
                    return itemId;
                return null;
            }
        }

        private int? EmpId
        {
            get
            {
                int empId;
                if (int.TryParse(tbEmployee.Text, out empId))
                    return empId;
                return null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PrepareData();
        }

        private void dgvDocs_SelectionChanged(object sender, EventArgs e)
        {
            wF.wf_get_ib_doc_details.Clear();

            if (dgvDocs.CurrentRow == null)
                return;

            var dataRow = dgvDocs.CurrentRow.DataBoundItem as DataRowView;
            if (dataRow == null)
                return;

            var _row = dataRow.Row as Data.WF.wf_get_ib_docsRow;
            if (_row == null)
                return;
            wf_get_ib_doc_detailsTableAdapter.Fill(wF.wf_get_ib_doc_details, (int?)_row.___пак_листа);
        }

        private void btnExportDoc_Click(object sender, EventArgs e)
        {
            if (dgvDocs.CurrentRow == null || dgvDocLines.Rows.Count == 0)
                return;

            var dataRow = dgvDocs.CurrentRow.DataBoundItem as DataRowView;
            if (dataRow == null)
                return;

            var _row = dataRow.Row as Data.WF.wf_get_ib_docsRow;
            if (_row == null || _row.IsДата_закрытияNull())
                return;

            string fileName = string.Format("{0}_{1:yyyyMMdd}", _row.___пак_листа, _row.Дата_закрытия);
           
            ExportHelper.ExportDataGridViewToExcel(dgvDocLines, "Экспорт", fileName, true);
        }

        
    }
}
