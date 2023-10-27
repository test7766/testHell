using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using WMSOffice.Data;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class ComplaintActSplitForm : DialogForm
    {
        public int ActID { get; private set; }

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        public ComplaintActSplitForm()
        {
            InitializeComponent();
        }

        public ComplaintActSplitForm(int actID)
            : this()
        {
            this.ActID = actID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(807, 8);
            this.btnCancel.Location = new Point(897, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            dgvcColdType.DefaultCellStyle.NullValue = null;

            this.LoadData();

            this.CheckSelectedItems();
        }

        private void LoadData()
        {
            try
            {
                using (var adapter = new Data.ComplaintsTableAdapters.CO_Vendor_Act_DetailsTableAdapter())
                    adapter.Fill(complaints.CO_Vendor_Act_Details, this.ActID, this.UserID);

                if (dgvDocDetails.Rows.Count > 0)
                    dgvDocDetails.Rows[0].Selected = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDocDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDocDetails.Rows)
            {
                var dataRow = (row.DataBoundItem as DataRowView).Row as Data.Complaints.CO_Vendor_Act_DetailsRow;

                if (dataRow.IsColdTypeNull() || string.IsNullOrEmpty(dataRow.ColdType))
                {
                    row.Cells[dgvcColdType.Index].Value = emptyIcon;
                }
                else
                {
                    if (dataRow.ColdType == "R")
                    {
                        row.Cells[dgvcColdType.Index].Value = Properties.Resources.snowflakeR;
                        row.Cells[dgvcColdType.Index].ToolTipText = "Признак холода 2-8";
                    }
                    else if (dataRow.ColdType == "B")
                    {
                        row.Cells[dgvcColdType.Index].Value = Properties.Resources.snowflakeB;
                        row.Cells[dgvcColdType.Index].ToolTipText = "Признак холода 8-15";
                    }
                }
            }
        }

        private void dgvDocDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDocDetails.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvDocDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool isChecked = Convert.ToBoolean(this.dgvDocDetails.Rows[this.dgvDocDetails.CurrentRow.Index].Cells[this.IsChecked.Index].Value);
                foreach (DataGridViewColumn column in this.dgvDocDetails.Columns)
                {
                    this.dgvDocDetails.Rows[this.dgvDocDetails.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    this.dgvDocDetails.Rows[this.dgvDocDetails.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
                }

                this.CheckSelectedItems();
            }
        }

        private void CheckSelectedItems()
        {
            var cntSelectedItems = 0;
            foreach (DataGridViewRow row in dgvDocDetails.Rows)
            {
                var dataRow = (row.DataBoundItem as DataRowView).Row as Data.Complaints.CO_Vendor_Act_DetailsRow;

                if (dataRow.IsChecked)
                    cntSelectedItems++;
            }

            btnOK.Enabled = cntSelectedItems > 0 && cntSelectedItems != complaints.CO_Vendor_Act_Details.Count;
        }

        private void dgvDocDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            bool isChecked = Convert.ToBoolean(this.dgvDocDetails.Rows[e.RowIndex].Cells[this.IsChecked.Index].Value);
            this.dgvDocDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            this.dgvDocDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
        }

        private void ComplaintActSplitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {

                var xData = this.CreateSplitDataXML();

                using (var adapter = new Data.ComplaintsTableAdapters.CO_Vendor_Act_HeaderTableAdapter())
                    adapter.SplitAct(this.ActID, this.UserID, xData.InnerXml);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private XmlDocument CreateSplitDataXML()
        {

            XmlDocument xData = new XmlDocument();
            xData.LoadXml("<Data></Data>");
            XmlElement xRoot = xData.DocumentElement;

            XmlAttribute xValue = null;

            foreach (Data.Complaints.CO_Vendor_Act_DetailsRow line in complaints.CO_Vendor_Act_Details)
            {
                if (line.IsChecked)
                {
                    var xLineElement = xData.CreateElement("Line");

                    xValue = xLineElement.Attributes.Append(xData.CreateAttribute("Detail_ID"));
                    xValue.Value = line.Detail_ID.ToString();

                    xRoot.AppendChild(xLineElement);
                }
            }

            return xData;
        }
    }
}
