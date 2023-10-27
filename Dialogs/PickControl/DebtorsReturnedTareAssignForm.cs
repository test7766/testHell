using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class DebtorsReturnedTareAssignForm : DialogForm
    {
        public string WarehouseID { get; private set; }
        public string LocationID { get; private set; }
        public int DocID { get; private set; }

        public DebtorsReturnedTareAssignForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Enabled = false;

            this.btnOK.Location = new Point(757, 8);
            this.btnCancel.Location = new Point(847, 8);

            if (CreateDoc() && SelectLocation())
            {
                this.Text = string.Format("{0} [Полка № {1}]", this.Text, this.LocationID);

                tbsTareBarCode.TextChanged += new EventHandler(tbsTareBarCode_TextChanged);
                tbsTareBarCode.Focus();
            }
            else
            {
                DialogResult = DialogResult.Abort;
                Close();
            }
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
                        Label = "Отсканируйте полку,\r\nк которой необходимо привязать\r\nоборотную тару",
                        Text = "Привязка оборотной тары",
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

                using (var adapter = new Data.PickControlTableAdapters.CT_AssignDocDetailsTableAdapter())
                    adapter.AddDocDetail(this.UserID, this.DocID, barcode, this.LocationID, this.WarehouseID);

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
                cT_AssignDocDetailsTableAdapter.Fill(pickControl.CT_AssignDocDetails, this.DocID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CreateDoc()
        {
            try
            {
                var docID = (int?)null;

                using (var adapter = new Data.PickControlTableAdapters.CT_AssignDocDetailsTableAdapter())
                    adapter.CreateDoc(this.UserID, ref docID);

                if (docID.HasValue)
                {
                    this.DocID = docID.Value;

                    return true;
                }
                else
                    throw new Exception("Задание привязки оборотной тары не было создано.");
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
                var locationID = (string)null;
                var warehouseID = (string)null;

                using (var adapter = new Data.PickControlTableAdapters.CT_AssignDocDetailsTableAdapter())
                    adapter.ScanLocation(location, this.DocID, ref locationID, ref warehouseID);

                this.LocationID = locationID;
                this.WarehouseID = warehouseID;

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
                var statusID = commitChanges ? "200" : "198";

                using (var adapter = new Data.PickControlTableAdapters.CT_AssignDocDetailsTableAdapter())
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
