using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Window;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class RepairScanForm : Form
    {
        public RepairScanForm()
        {
            InitializeComponent();
            CheckBoxVisible = true;
        }

        public string ErrorType
        {
            get { return lblErrorType.Text; }
            set { lblErrorType.Text = value; }
        }

        public string Instruction
        {
            get { return lblInstruction.Text; }
            set { lblInstruction.Text = value; }
        }

        public object DataSource
        {
            get { return gvDelta.DataSource; }
            set { gvDelta.DataSource = value; }
        }

        public string CheckBoxText
        {
            get { return chbNext.Text; }
            set { chbNext.Text = value; }
        }

        public bool CheckBoxVisible
        {
            get { return chbNext.Visible; }
            set { 
                chbNext.Visible = value;
                btnNext.Enabled = !value;
            }
        }

        /// <summary>
        /// Код сессии
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// № сборочного
        /// </summary>
        public int PickSlipNumber { get; set; }

        /// <summary>
        /// Проверка возможности применения изменений
        /// </summary>
        public bool CommitVersionChanges { get; set; }

        private void RepairScanForm_Load(object sender, EventArgs e)
        {
            colCollectors.Visible = true;
        } 

        private void chbNext_CheckedChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = !chbNext.Visible || chbNext.Checked;
        }

        private void gvDelta_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.F2 || e.KeyData == Keys.Enter) && btnNext.Enabled)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (e.KeyData == Keys.Space && chbNext.Visible)
                chbNext.Checked = !chbNext.Checked;
        }

        private void gvDelta_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in gvDelta.Rows)
            {
                if (colCollectors.Visible)
                    ((DataGridViewDisableButtonCell)row.Cells[colCollectors.Name]).ButtonVisible = true;
            }
        }

        private void gvDelta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gvDelta.Columns[e.ColumnIndex].Name == colCollectors.Name)
                {
                    if (((DataGridViewDisableButtonCell)gvDelta[e.ColumnIndex, e.RowIndex]).ButtonVisible)
                    {
                        try
                        {
                            var br = (gvDelta.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.PickControl.DocRowsWithDifferenceRow;

                            pickControl.PickSlipItemCollectors.Clear();
                            using (var adapter = new Data.PickControlTableAdapters.PickSlipItemCollectorsTableAdapter())
                                adapter.Fill(pickControl.PickSlipItemCollectors, this.UserID, this.PickSlipNumber, br.Item_ID);

                            if (pickControl.PickSlipItemCollectors.Rows.Count > 0)
                            {
                                var dlgCollectors = new WMSOffice.Dialogs.RichListForm() { Width = 700 };
                                dlgCollectors.Text = string.Format("Список сборщиков по товару ({0}) {1}", br.Item_ID, br.Item_Name);
                                dlgCollectors.AddColumn("employee", "employee", "Ф.И.О. сотрудника");
                                dlgCollectors.AddColumn("location_id", "location_id", "Место сборки");
                                dlgCollectors.ColumnForFilters = new List<string>(new string[] { "employee", "location_id" });
                                dlgCollectors.FilterChangeLevel = 0;

                                pickControl.PickSlipItemCollectors.DefaultView.RowFilter = string.Empty;
                                dlgCollectors.DataSource = pickControl.PickSlipItemCollectors;
                                dlgCollectors.SetDictionaryViewMode();
                                dlgCollectors.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show(string.Format("Список сборщиков по товару ({0}) {1} не найден.", br.Item_ID, br.Item_Name), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }     
    }
}
