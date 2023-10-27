using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Properties;
using System.Drawing.Drawing2D;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class ComplaintMergeExtForm : Form
    {
        /// <summary>
        /// Пустое изображение
        /// </summary>
        private readonly static Bitmap emptyIcon = new Bitmap(16, 16);

        long linkedDocId = int.MinValue;
        long linkedDetailId = int.MinValue;

        /// <summary>
        /// Cтатус "ошибка при обработке претензии"
        /// </summary>
        private const string PROCESSING_ERRORS_STATE = "991";

        protected int UserID { get; set; }

        internal WMSOffice.Data.Complaints.CurrentDocsRow CurrentRow { get; set; }

        internal string FilterWarehouse { get; set; }


        private ComplaintMergeExtForm()
        {
            InitializeComponent();
        }

        public ComplaintMergeExtForm(int userID)
            : this()
        {
            UserID = userID;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            using (Data.ComplaintsTableAdapters.CurrentDocsTableAdapter adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
            {
                WMSOffice.Data.Complaints.CurrentDocsDataTable retData;
                if (CurrentDetail == null)
                    retData = adapter.GetData(UserID, "DF", null, null, false, FilterWarehouse);
                else
                    retData = adapter.SearchDocs(UserID, null, "DF", null, null, null, null, null, null, null, CurrentDetail.Item_ID, null, null);
                
                if (retData.Rows.Count == 0)
                {
                    MessageBox.Show(String.Format("Претензий \"Недостача\" на продукт \"{0}\" нет.", CurrentDetail.Item_Name));
                    Close();
                    return;
                }
                currentDocsBindingSource.DataSource = retData;
            }

            if (CurrentDetail == null || CurrentRow == null)
                return;

            if (!CurrentRow.IsisLinkedNull() && CurrentRow.isLinked == 1)
            {
                var linkedAdapter = new Data.ComplaintsTableAdapters.pr_CO_Get_LinkedRowTableAdapter();

                var retLinked = linkedAdapter.GetData(CurrentRow.Doc_ID, CurrentDetail.Detail_ID);
                if (retLinked != null && retLinked.Rows.Count > 0)
                {
                    var rowLinked = retLinked[0] as Data.Complaints.pr_CO_Get_LinkedRowRow;
                    if (rowLinked != null)
                    {
                        linkedDocId = rowLinked.Linked_Doc_ID;
                        linkedDetailId = rowLinked.Linked_Detail_ID;
                    }
                }

                foreach (DataGridViewRow row in dgvComplaints.Rows)
                {
                    Data.Complaints.CurrentDocsRow dbRow = (Data.Complaints.CurrentDocsRow)((DataRowView)row.DataBoundItem).Row;
                    if (dbRow.Doc_ID == linkedDocId)
                    {
                        row.Selected = true;
                        dgvComplaints.FirstDisplayedScrollingRowIndex = row.Index;
                        row.Cells[clmLinked.Index].Value = MergeStatusImage;
                        clmLinked.Visible = true;
                    }
                    else
                        row.Cells[clmLinked.Index].Value = emptyIcon;
                }
            }

        }

        internal Data.Complaints.DocRequestDetailsRow CurrentDetail { get; set; }
        /// <summary>
        /// Возвращает текущую выделенную строку из таблицы со списком претензий.
        /// </summary>
        internal Data.Complaints.CurrentDocsRow SelectedRow
        {
            get
            {
                if (dgvComplaints.SelectedRows.Count == 0)
                    return null;
                return (Data.Complaints.CurrentDocsRow)((DataRowView)dgvComplaints.SelectedRows[0].DataBoundItem).Row;
            }
        }

        /// <summary>
        /// Возвращает текущую выделенную строку из таблицы состав претензии.
        /// </summary>
        internal Data.Complaints.DocRequestDetailsRow SelectedDocRequestDetail
        {
            get
            {
                if (dgvDocRequestDetails.SelectedRows.Count == 0)
                    return null;
                return (Data.Complaints.DocRequestDetailsRow)((DataRowView)dgvDocRequestDetails.SelectedRows[0].DataBoundItem).Row;
            }
        }

        private static Bitmap MergeStatusImage
        {
            get
            {
                Bitmap b = new Bitmap(16, 16);
                Graphics g = Graphics.FromImage((Image)b);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(Properties.Resources.merging, 0, 0, 16, 16);
                g.Dispose();
                return b;
            }
        }

        private void dgvDocRequestDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDocRequestDetails.Rows)
            {
                var dataRow = (row.DataBoundItem as DataRowView).Row as Data.Complaints.DocRequestDetailsRow;
                if (dataRow.XL == 1)
                {
                    row.Cells["dgvcColdSignImage"].Value = Properties.Resources.snowflakeB;
                    row.Cells["dgvcColdSignImage"].ToolTipText = "Признак холода";
                }
                else
                {
                    row.Cells["dgvcColdSignImage"].Value = emptyIcon;
                }

                if (dataRow.Detail_ID == linkedDetailId)
                {
                    row.Selected = true;
                    dgvDocRequestDetails.FirstDisplayedScrollingRowIndex = row.Index;
                    row.Cells[clmLinkedDetail.Index].Value = MergeStatusImage;
                    clmLinkedDetail.Visible = true;
                }
                else
                    row.Cells[clmLinkedDetail.Index].Value = emptyIcon;
            }
        }


        private void dgvComplaints_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvComplaints.Rows)
            {
                row.Cells[dgvcComplaintProcessingDataError.Name].Value = emptyIcon;
                row.Cells[coldColumn.Name].Value = emptyIcon;
                row.Cells[clmLinked.Index].Value = emptyIcon;

                if (HasProcessingErrors(row.Index))
                    row.Cells["dgvcComplaintProcessingDataError"].Value = Resources.Achtung;

                Data.Complaints.CurrentDocsRow dbRow = (Data.Complaints.CurrentDocsRow)((DataRowView)row.DataBoundItem).Row;
                if (!dbRow.IsColorNull())
                {
                    Color rowBackColor = Color.FromName(dbRow.Color);
                    for (int c = 0; c < dgvComplaints.Columns.Count; ++c)
                    {
                        row.Cells[c].Style.BackColor = rowBackColor;
                    }
                }

                if (!dbRow.IsXLNull() && dbRow.XL == 1)
                    row.Cells["coldColumn"].Value = Resources.snowflakeB;

                switch (dbRow.AttachedFiles)
                {
                    case 0:
                        row.Cells[colAttachedFiles.Index].Value = Properties.Resources.close; break;
                    case 1:
                        row.Cells[colAttachedFiles.Index].Value = Properties.Resources.paperclip1; break;
                    case 2:
                        row.Cells[colAttachedFiles.Index].Value = Properties.Resources.paperclip2; break;
                    case 3:
                        row.Cells[colAttachedFiles.Index].Value = Properties.Resources.paperclip3; break;
                    default:
                        row.Cells[colAttachedFiles.Index].Value = Properties.Resources.paperclipN; break;
                }

                if (dbRow.Doc_ID == linkedDocId)
                {
                    row.Selected = true;
                    dgvComplaints.FirstDisplayedScrollingRowIndex = row.Index;
                    row.Cells[clmLinked.Index].Value = MergeStatusImage;
                    clmLinked.Visible = true;
                }
                else
                    row.Cells[clmLinked.Index].Value = emptyIcon;
            }
        }

        /// <summary>
        /// Обнаружнение ошибок при обработке претензии
        /// </summary>
        /// <param name="pRowIndex"></param>
        /// <returns></returns>
        private bool HasProcessingErrors(int pRowIndex)
        {
            return dgvComplaints.Rows[pRowIndex].Cells["statusIDDataGridViewTextBoxColumn"].Value != DBNull.Value &&
                  dgvComplaints.Rows[pRowIndex].Cells["statusIDDataGridViewTextBoxColumn"].Value.ToString() == PROCESSING_ERRORS_STATE;
        }

        private void dgvComplaints_SelectionChanged(object sender, EventArgs e)
        {
            if (SelectedRow == null)
                return;

            docRequestDetailsTableAdapter.Fill(complaints.DocRequestDetails, UserID, SelectedRow == null ? (long?)null : SelectedRow.Doc_ID);

            foreach (DataGridViewRow row in dgvDocRequestDetails.Rows)
            {
                var dataRow = (row.DataBoundItem as DataRowView).Row as Data.Complaints.DocRequestDetailsRow;
                if (dataRow == null)
                    continue;
                if (dataRow.Item_ID == CurrentDetail.Item_ID)
                {
                    row.Selected = true;
                    dgvDocRequestDetails.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }
    }
}
