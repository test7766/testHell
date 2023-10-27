using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using WMSOffice.Data.ComplaintsTableAdapters;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class ComplaintMergeForm : Form
    {
        protected int UserID { get; set; }
        public string FilterWarehouse { get; set; }
        /// <summary>
        /// Пустое изображение
        /// </summary>
        private readonly static Bitmap emptyIcon = new Bitmap(16, 16);


        public ComplaintMergeForm(int userID)
            : this()
        {
            UserID = userID;
        }

        private ComplaintMergeForm()
        {
            InitializeComponent();
        }

        private Data.Complaints.CurrentDocsRow currentRow;
        public Data.Complaints.CurrentDocsRow CurrentRow
        {
            get
            {
                return currentRow;
            }
            set
            {
                if (currentRow == value)
                    return;

                currentRow = value;

                PrepareCurRowBinding();
            }
        }

        /// <summary>
        /// Возвращает текущую выделенную строку из таблицы состав претензии.
        /// </summary>
        internal Data.Complaints.DocRequestDetailsRow CurrentDetail
        {
            get
            {
                if (dgvDocRequestDetails.SelectedRows.Count == 0)
                    return null;
                return (Data.Complaints.DocRequestDetailsRow)((DataRowView)dgvDocRequestDetails.SelectedRows[0].DataBoundItem).Row;
            }
        }

        private void PrepareCurRowBinding()
        {
            docRequestDetailsTableAdapter.Fill(complaints.DocRequestDetails, UserID, currentRow == null ? (long?)null : currentRow.Doc_ID);

            lblCode.Text = currentRow.IsFirst_Doc_IDNull() ? String.Empty : currentRow.First_Doc_ID.ToString();
            lblType.Text = currentRow.IsFirst_Doc_IDNull() ? String.Empty : currentRow.Doc_Type;
            lblTypeName.Text = currentRow.IsDoc_Type_NameNull() ? String.Empty : currentRow.Doc_Type_Name;
            lblStatus.Text = currentRow.Status_ID;
            lblStatusName.Text = currentRow.IsStatus_NameNull() ? String.Empty : currentRow.Status_Name;
            lblClient.Text = currentRow.IsSource_Address_NameNull() ? String.Empty : currentRow.Source_Address_Name;
            lblDate.Text = currentRow.Date_Created.ToString("dd.MM.yyyy HH:mm:ss");
            lblAutor.Text = currentRow.IsUsers_CreatedNull() ? String.Empty : currentRow.Users_Created;
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

                row.Cells[clmStage.Index].Value = emptyIcon;
                row.Cells[clmDelete.Index].Value = emptyIcon;

                if (!dataRow.IsisLinkedNull() && dataRow.isLinked == 1)
                {
                    row.Cells[clmStage.Index].Value = MergeStatusImage;
                    clmStage.Visible = true;
                    row.Cells[clmDelete.Index].Value = DeleteImage;
                    clmDelete.ToolTipText = "Удалить связь";
                }
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

        private static Bitmap DeleteImage
        {
            get
            {
                Bitmap b = new Bitmap(16, 16);
                Graphics g = Graphics.FromImage((Image)b);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(Properties.Resources.Delete, 0, 0, 16, 16);
                g.Dispose();
                return b;
            }
        }

        private void dgvDocRequestDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmDelete.Index)
            {
                if (MessageBox.Show(String.Format("Удалить связку по продукту \"{0}\"?", CurrentDetail.Item_Name), 
                        "Удалить связь", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question) == DialogResult.No) return;
                using (QueriesTableAdapter queriesTableAdapter = new QueriesTableAdapter())
                    queriesTableAdapter.pr_CO_CreateLink_byDocunents(UserID,
                        CurrentRow.Doc_ID,
                        CurrentDetail.Detail_ID,
                        null,
                        null);

                dgvDocRequestDetails.Rows[e.RowIndex].Cells[clmStage.Index].Value = emptyIcon;
                dgvDocRequestDetails.Rows[e.RowIndex].Cells[clmDelete.Index].Value = emptyIcon;
                return;
            }
            if (e.ColumnIndex != clmButton.Index)
                return;
            try
            {
                using (ComplaintMergeExtForm frm = new ComplaintMergeExtForm(UserID) { CurrentRow = CurrentRow, CurrentDetail = CurrentDetail, Owner = this, FilterWarehouse = FilterWarehouse })
                {
                    if (frm.ShowDialog() == DialogResult.Cancel) return;

                    var retRow = frm.SelectedRow;
                    var retDetail = frm.SelectedDocRequestDetail;

                    using (QueriesTableAdapter queriesTableAdapter = new QueriesTableAdapter())
                        queriesTableAdapter.pr_CO_CreateLink_byDocunents(UserID, 
                            CurrentRow.Doc_ID, 
                            CurrentDetail.Detail_ID,
                            retRow.Doc_ID,
                            retDetail.Detail_ID);

                    dgvDocRequestDetails.Rows[e.RowIndex].Cells[clmStage.Index].Value = MergeStatusImage;
                    clmStage.Visible = true;
                    
                    {
                        dgvDocRequestDetails.Rows[e.RowIndex].Cells[clmDelete.Index].Value = DeleteImage;
                        clmDelete.ToolTipText = "Удалить связь";
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException ?? ex;
                Logger.ShowErrorMessageBox(msg.Message, ex);
            }
        }
    }
}
