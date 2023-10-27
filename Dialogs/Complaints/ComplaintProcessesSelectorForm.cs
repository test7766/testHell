using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class ComplaintProcessesSelectorForm : Form
    {
        public string SelectedProcesses { get; private set; }

        public long SessionID { get; set; }

        public string EntityKey { get; set; }

        public ComplaintProcessesSelectorForm()
        {
            InitializeComponent();
            SelectedProcesses = string.Empty;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnVideoControl_Click(object sender, EventArgs e)
        {
            PrepareSelectedProcesses();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PrepareSelectedProcesses()
        {
            var sbProcess = new StringBuilder();
            foreach (Data.Complaints.ComplaintProcessesRow item in ctrlTwoListSelector.SelectedItems)
                sbProcess.AppendFormat("{0},", item.Process_ID);

            SelectedProcesses = sbProcess.Length > 0 ? sbProcess.ToString().Trim(',') : string.Empty;
        }

        private void ComplaintProcessesSelectorForm_Load(object sender, EventArgs e)
        {
            try
            {
                Data.Complaints.ComplaintProcessesDataTable dtProcesses = new WMSOffice.Data.Complaints.ComplaintProcessesDataTable();
                using (var adapter = new Data.ComplaintsTableAdapters.ComplaintProcessesTableAdapter())
                    adapter.Fill(dtProcesses, SessionID, EntityKey);

                var rows = new List<object>();
                foreach (var row in dtProcesses.Rows)
                    rows.Add(row);

                ctrlTwoListSelector.Initialize(rows, dtProcesses.Process_NameColumn.ColumnName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
