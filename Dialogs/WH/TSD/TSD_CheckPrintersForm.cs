using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH.TSD
{
    public partial class TSD_CheckPrintersForm : DialogForm
    {
        public TSD_CheckPrintersForm()
        {
            InitializeComponent();
        }

        private void TSD_CheckPrintersForm_Load(object sender, EventArgs e)
        {
            this.LoadItems();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(517, 8);
            this.btnCancel.Location = new Point(607, 8);

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";
        }

        private void LoadItems()
        {
            try
            {
                this.checkedPrintersTableAdapter.Fill(this.tSD.CheckedPrinters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUndoPrinter_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dgvRow in dgvItems.SelectedRows)
                {
                    var checkedPrinter = (dgvRow.DataBoundItem as DataRowView).Row as Data.TSD.CheckedPrintersRow;
                    this.checkedPrintersTableAdapter.UndoPrinter(checkedPrinter.printer_id, checkedPrinter.printer_bar_code, this.UserID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.LoadItems();
            }
        }
    }
}
