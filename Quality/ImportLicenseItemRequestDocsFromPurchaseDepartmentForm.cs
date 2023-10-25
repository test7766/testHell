using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class ImportLicenseItemRequestDocsFromPurchaseDepartmentForm : DialogForm
    {
        private readonly List<Data.Quality.QK_LI_LicItemsRow> _items = null;

        public ImportLicenseItemRequestDocsFromPurchaseDepartmentForm()
        {
            InitializeComponent();
        }

        public ImportLicenseItemRequestDocsFromPurchaseDepartmentForm(List<Data.Quality.QK_LI_LicItemsRow> items)
            : this()
        {
            _items = items;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            foreach (var item in gbDocs.Controls)
                (item as CheckBox).Checked = false;

            var toolTip = new ToolTip();
            toolTip.SetToolTip(cbRequestRegDoc, "Регистрационное свидетельство на препарат");
            toolTip.SetToolTip(cbRequestGmpDoc, "Заключение о подтверждении сертификата GMP");
            toolTip.SetToolTip(cbRequestRegDocTab, "Вкладыш к регистрационному свидетельству на препарат");

            this.btnOK.Location = new Point(107, 8);
            this.btnCancel.Location = new Point(197, 8);
        }

        private void ImportLicenseItemRequestDocsFromPurchaseDepartmentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.RequestDocs();
        }

        private bool RequestDocs()
        {
            try
            {
                var requestRegDoc = cbRequestRegDoc.Checked;
                var requestGmpDoc = cbRequestGmpDoc.Checked;
                var requestRegDocTab = cbRequestRegDocTab.Checked;

                if (!(requestRegDoc || requestGmpDoc || requestRegDocTab))
                    throw new Exception("Необходимо выбрать тип документа.");

                if (string.IsNullOrEmpty(tbNote.Text))
                    throw new Exception("Необходимо указать примечание.");

                var note = tbNote.Text.Trim();

                var sbItems = new StringBuilder();
                foreach (var item in _items)
                {
                    if (sbItems.Length > 0)
                        sbItems.AppendFormat(",{0}", item.ItemID);
                    else
                        sbItems.AppendFormat("{0}", item.ItemID);
                }

                //using (var adapter = new Data.QualityTableAdapters.QK_LI_LicItemsTableAdapter())
                //    adapter.RequestDocsFromMOZ(this.UserID, sbItems.ToString(), requestRegDoc, requestGmpDoc, note, requestRegDocTab);

                using (var adapter = new Data.QualityTableAdapters.QK_LI_LicItemsTableAdapter())
                    adapter.RequestDocsFromVendor(this.UserID, sbItems.ToString(), requestRegDoc, requestGmpDoc, note, requestRegDocTab);
               
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
