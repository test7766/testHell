using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Enterprise;
using System.IO;
using WMSOffice.Controls.Custom;
using System.Diagnostics;
using System.Xml;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class PickReturnWarrantyNTVComplaintInfoForm : DialogForm
    {
        public long CO_DocID { get; private set; }

        public PickReturnWarrantyNTVComplaintInfoForm()
        {
            InitializeComponent();
        }

        public PickReturnWarrantyNTVComplaintInfoForm(long co_doc_id)
            : this()
        {
            this.CO_DocID = co_doc_id;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(907, 8);
            this.btnCancel.Location = new Point(997, 8);

            //this.DiscardCanceling = true;

            btnDeclineNTV.Visible = false;
            tssDeclineNTV.Visible = false;

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";

            this.Initialize();

            //this.WindowState = FormWindowState.Maximized;
        }

        private void Initialize()
        {
            this.LoadItems();
            this.LoadAttachments();
        }

        private void LoadItems()
        {
            try
            {
                cO_GR_ItemsTableAdapter.Fill(complaints.CO_GR_Items, this.CO_DocID);

                if (dgvItemsInfo.Rows.Count > 0)
                    dgvItemsInfo.Rows[0].Selected = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvItemsInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var item = (dgvItemsInfo.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Complaints.CO_GR_ItemsRow;
            var qtyResult = item.ResultQuantity;
            var qtyConfirm = item.IsConfirmQuantityNull() ? (double?)null : item.ConfirmQuantity;

            if (dgvItemsInfo.Columns[e.ColumnIndex].DataPropertyName == complaints.CO_GR_Items.ConfirmQuantityColumn.Caption)
            {
                var color = qtyConfirm == (double?)null || qtyConfirm > qtyResult || qtyConfirm < 0.0 ? Color.LightPink : qtyConfirm == 0.0 ? Color.LightGray : qtyConfirm == qtyResult ? Color.LightGreen : Color.Khaki;
                e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = color;
            }
        }

        private void dgvItemsInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            if (dgvItemsInfo.Columns[e.ColumnIndex].DataPropertyName == complaints.CO_GR_Items.ConfirmQuantityColumn.Caption)
            {
                if (e.Exception is FormatException)
                    MessageBox.Show(string.Format("Значение поля \"{0}\" должно быть числом.", dgvItemsInfo.Columns[e.ColumnIndex].HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadAttachments()
        {
            try
            {
                docAttachmentsTableAdapter.Fill(complaints.DocAttachments, this.UserID, this.CO_DocID, (int?)null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAttachments_SelectionChanged(object sender, EventArgs e)
        {
            this.PrepareAttachmentPreview();
            this.SetOperationAccess();
        }

        private void SetOperationAccess()
        {
            var isEnabled = dgvAttachments.SelectedRows.Count > 0;
            btnOpenAttachment.Enabled = isEnabled;
            ivcAttachments.Visible = isEnabled;
        }

        private void PrepareAttachmentPreview()
        {
            try
            {
                ivcAttachments.Items.Clear();

                if (dgvAttachments.SelectedRows.Count == 0)
                    return;

                var attachment = (dgvAttachments.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Complaints.DocAttachmentsRow;
                
                var fileName = attachment.File_Name;
                var fileExtension = fileName.Substring(fileName.LastIndexOf('.'));
                var fileData = attachment.File_Data;

                // Выгружаем бинарный документ во временный файл
                var tmpFileName = Path.GetTempFileName();
                System.IO.File.WriteAllBytes(tmpFileName, fileData);

                ivcAttachments.Items.Add(new ImageProxy(tmpFileName, fileExtension) { Properties = attachment });
                ivcAttachments.Items[ivcAttachments.Items.Count - 1].LoadImage();

                ivcAttachments.CurrentItem = ivcAttachments.Items.Count > 0 ? ivcAttachments.Items[0] : new WMSOffice.Controls.Custom.ImageProxy(Properties.Resources.absentimage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAttachments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.OpenAttachment();
        }

        private void btnOpenAttachment_Click(object sender, EventArgs e)
        {
           this.OpenAttachment();
        }

        private void OpenAttachment()
        {
            try
            {
                var attachment = (dgvAttachments.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Complaints.DocAttachmentsRow;

                var fileName = attachment.File_Name;
                var fileData = attachment.File_Data;

                // Выгружаем бинарный документ во временный файл
                var tmpFileName = Path.GetTempFileName();
                System.IO.File.WriteAllBytes(tmpFileName, fileData);

                var trgFileName = Path.Combine(new FileInfo(tmpFileName).DirectoryName, fileName);

                if (System.IO.File.Exists(trgFileName))
                    System.IO.File.Delete(trgFileName);

                System.IO.File.Move(tmpFileName, trgFileName);

                if (System.IO.File.Exists(tmpFileName))
                    System.IO.File.Delete(tmpFileName);

                Process.Start(trgFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAcceptNTV_Click(object sender, EventArgs e)
        {
            try
            {
                var xDoc = CreateAcceptNTVDocumentXML();

                cO_GR_ItemsTableAdapter.AcceptItemsNTV(this.CO_DocID, this.UserID, xDoc.InnerXml);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private XmlDocument CreateAcceptNTVDocumentXML()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml("<Doc></Doc>");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlAttribute xValue = null;

            var xDetailsElement = xDoc.CreateElement("Details");
            foreach (Data.Complaints.CO_GR_ItemsRow item in complaints.CO_GR_Items)
            {
                var qtyResult = item.ResultQuantity;
                var qtyConfirm = item.IsConfirmQuantityNull() ? (double?)null : item.ConfirmQuantity;

                if (qtyConfirm == (double?)null || qtyConfirm > qtyResult || qtyConfirm < 0.0)
                    throw new Exception("Исправьте подтвер. кол-во НТВ в \"красных\" ячейках.");

                var xDetailElement = xDoc.CreateElement("Detail");

                xValue = xDetailElement.Attributes.Append(xDoc.CreateAttribute("id"));
                xValue.Value = item.Detail_Id.ToString();

                xValue = xDetailElement.Attributes.Append(xDoc.CreateAttribute("qty"));
                xValue.Value = item.IsConfirmQuantityNull() ? string.Empty : item.ConfirmQuantity.ToString("N0");

                xDetailsElement.AppendChild(xDetailElement);
            }

            xRoot.AppendChild(xDetailsElement);

            return xDoc;
        }


        private void btnDeclineNTV_Click(object sender, EventArgs e)
        {
            try
            {
                cO_GR_ItemsTableAdapter.DeclineItemsNTV(this.CO_DocID, this.UserID);

                this.DialogResult = DialogResult.Abort;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PickReturnWarrantyNTVComplaintInfoForm_SizeChanged(object sender, EventArgs e)
        {
            if (ivcAttachments.AutoZoomActivated)
                ivcAttachments.ChangeZoom();
        }

        private void PickReturnWarrantyNTVComplaintInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
                e.Cancel = !this.CancelNTV();
        }

        private bool CancelNTV()
        {
            try
            {
                using (var adapter = new Data.PickControlTableAdapters.DocReturnRowsTableAdapter())
                    adapter.CancelReturnControl(this.UserID, this.CO_DocID);

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
