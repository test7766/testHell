using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class DebtorsReturnedTareIssueForm : DialogForm
    {
        public string SSCC { get; private set; }
        public string LocationID { get; private set; }
        public int DocID { get; private set; }

        public DebtorsReturnedTareIssueForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Enabled = false;

            this.btnOK.Location = new Point(757, 8);
            this.btnCancel.Location = new Point(847, 8);

            if (SelectSSCC() && SelectLocation())
            {
                this.Text = string.Format("{0} [SSCC № {1}; Полка № {2}]", this.Text, this.SSCC, this.LocationID);

                tbsTareBarCode.TextChanged += new EventHandler(tbsTareBarCode_TextChanged);
                tbsTareBarCode.Focus();
            }
            else
            {
                DialogResult = DialogResult.Abort;
                Close();
            }
        }

        private bool SelectSSCC()
        {
            var success = false;
            var lastBarcode = (string)null;

            while (true)
            {
                try
                {
                    var dlgAssignSSCC = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте SSCC,\r\nкоторое необходимо привязать\r\nк заданию выдачи",
                        Text = "Выдача оборотной тары",
                        Image = Properties.Resources.barcode,
                        Barcode = lastBarcode
                    };

                    if (dlgAssignSSCC.ShowDialog() == DialogResult.OK)
                    {
                        var barcode = lastBarcode = dlgAssignSSCC.Barcode;
                        if (this.CreateDoc(barcode))
                        {
                            lastBarcode = (string)null;
                            success = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        success = false;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return success;
        }

        private bool SelectLocation()
        {
            var success = false;
            var lastBarcode = (string)null;

            while (true)
            {
                try
                {
                    var dlgChoiseLocation = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте полку,\r\nс которой необходимо выдать\r\nоборотную тару",
                        Text = "Выдача оборотной тары",
                        Image = Properties.Resources.barcode,
                        Barcode = lastBarcode
                    };

                    if (dlgChoiseLocation.ShowDialog() == DialogResult.OK)
                    {
                        var barcode = lastBarcode = dlgChoiseLocation.Barcode;
                        if (this.ScanLocation(barcode))
                        {
                            lastBarcode = (string)null;
                            success = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        success = false;

                        this.CloseDoc(false);

                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return success;
        }

        void tbsTareBarCode_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbsTareBarCode.Text))
                return;

            try
            {
                var barcode = tbsTareBarCode.Text;

                using (var adapter = new Data.PickControlTableAdapters.CT_DocDetailsTableAdapter())
                    adapter.AddDocDetail(this.UserID, this.DocID, barcode);

                tbsTareBarCode.Text = string.Empty;

                this.btnOK.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.GetDetails();

                tbsTareBarCode.Focus();
                tbsTareBarCode.SelectAll();
            }
        }

        private void GetDetails()
        {
            try
            {
                cT_DocDetailsTableAdapter.Fill(pickControl.CT_DocDetails, this.DocID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CreateDoc(string sscc)
        {
            try
            {
                var docID = (int?)null;

                using (var adapter = new Data.PickControlTableAdapters.CT_DocDetailsTableAdapter())
                    adapter.CreateDoc(this.UserID, sscc, ref docID);

                if (docID.HasValue)
                {
                    this.SSCC = sscc;
                    this.DocID = docID.Value;

                    return true;
                }
                else
                    throw new Exception("Задание выдачи оборотной тары не было создано.");
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return false;
            }
        }

        private bool ScanLocation(string location)
        {
            try
            {
                using (var adapter = new Data.PickControlTableAdapters.CT_DocDetailsTableAdapter())
                    adapter.ScanLocation(location, this.DocID, this.SSCC);

                this.LocationID = location;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void DebtorsReturnedTareIssueForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                e.Cancel = !this.CloseDoc(true);
            }
            else if (DialogResult == DialogResult.Cancel)
            {
                this.CloseDoc(false);
            }
        }

        private bool CloseDoc(bool commitChanges)
        {
            try
            {
                var statusID = commitChanges ? "199" : "198";

                using (var adapter = new Data.PickControlTableAdapters.CT_DocDetailsTableAdapter())
                    adapter.ChangeDocStatus(this.UserID, this.DocID, statusID);

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
