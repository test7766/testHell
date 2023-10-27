using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class ShipReturnsToVendorAddShipmentMethodForm : DialogForm
    {
        private bool isInitializing = false;

        public int VendorID { get; private set; }
        public DateTime? PeriodFrom { get; private set; }

        public int? ShipmentTypeID { get; private set; }
        public string Param1 { get; private set; }
        public string Param2 { get; private set; }
        public string Param3 { get; private set; }
        public DateTime? PrintDate { get; private set; }

        public ShipReturnsToVendorAddShipmentMethodForm()
        {
            InitializeComponent();
        }

        public ShipReturnsToVendorAddShipmentMethodForm(int vendorID, DateTime? periodFrom)
            : this()
        {
            this.VendorID = vendorID;
            this.PeriodFrom = periodFrom;
        }

        private void ShipReturnsToVendorAddShipmentDoc_Load(object sender, EventArgs e)
        {
           
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.btnOK.Location = new Point(173, 8);
            this.btnCancel.Location = new Point(263, 8);
        }

        private void Initialize()
        {
            isInitializing = true;

            this.LoadShipmentTypes();
            this.InitShipmentDoc();

            isInitializing = false;
        }

        private void LoadShipmentTypes()
        {
            try
            {
                this.sV_VR_Shipment_TypesTableAdapter.Fill(this.complaints.SV_VR_Shipment_Types);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitShipmentDoc()
        {
            try
            {
                var shipmentTypeID = (int?)null;
                var param1 = (string)null;
                var param2 = (string)null;
                var param3 = (string)null;
                var printDate = (DateTime?)null;

                using (var adapter = new Data.ComplaintsTableAdapters.SV_VR_Docs_VendorsTableAdapter())
                    adapter.GetShipmentDoc(this.UserID, this.VendorID, this.PeriodFrom, ref shipmentTypeID, ref param1, ref param2, ref param3, ref printDate);

                this.Param1 = param1;
                this.Param2 = param2;
                this.Param3 = param3;

                if ((this.PrintDate = printDate).HasValue)
                {
                    dtpPrintDate.Value = this.PrintDate.Value; 
                    dtpPrintDate.Checked = true;
                }

                cmbShipmentTypes.SelectedValueChanged += cmbShipmentTypes_SelectedValueChanged;

                cmbShipmentTypes.SelectedItem = null;
                if ((this.ShipmentTypeID = shipmentTypeID) != null)
                    cmbShipmentTypes.SelectedValue = this.ShipmentTypeID.Value;
                else
                    cmbShipmentTypes.SelectedValue = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbShipmentTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbShipmentTypes.SelectedValue != null)
            {
                var shipmentTypeID = Convert.ToInt32(cmbShipmentTypes.SelectedValue);

                foreach (Control child in pnlContent.Controls)
                {
                    if (child is Panel && child.Tag != null)
                    {
                        child.Visible = false;
                        child.Dock = DockStyle.None;

                        if (Convert.ToInt32(child.Tag) == shipmentTypeID)
                        {
                            if (isInitializing)
                            {
                                switch (shipmentTypeID)
                                {
                                    case 1:
                                        tbCarNumberSD.Text = this.Param1 ?? string.Empty;
                                        tbDriverNameSD.Text = this.Param2 ?? string.Empty;
                                        tbAttorneyNumberSD.Text = this.Param3 ?? string.Empty;
                                        break;
                                    case 2:
                                        tbDeclarationNumberNP.Text = this.Param1 ?? string.Empty;
                                        break;
                                    case 3:
                                        tbCarNumberE.Text = this.Param1 ?? string.Empty;
                                        tbDriverNameE.Text = this.Param2 ?? string.Empty;
                                        tbAttorneyNumberE.Text = this.Param3 ?? string.Empty;
                                        break;
                                    default:
                                        break;
                                }
                            }

                            child.Dock = DockStyle.Fill;
                            child.Visible = true;

                            this.SelectNextControl(child, true, true, true, false);
                        }
                    }
                }
            }
        }

        private void tbInfoField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SelectNextControl((sender as Control), true, true, true, false);
        }

        //private void dtpPrintDate_ValueChanged(object sender, EventArgs e)
        //{
        //    this.SelectNextControl((sender as Control), true, true, true, false);
        //}

        private void ShipReturnsToVendorAddShipmentDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                if (cmbShipmentTypes.SelectedValue == null)
                    throw new Exception("Не выбран метод отгрузки.");

                var shipmentTypeID = Convert.ToInt32(cmbShipmentTypes.SelectedValue);

                switch (shipmentTypeID)
                {
                    case 1:
                        if (string.IsNullOrEmpty(tbCarNumberSD.Text))
                            throw new Exception("Не указан № автомобиля.");
                        else
                            this.Param1 = tbCarNumberSD.Text;

                        if (string.IsNullOrEmpty(tbDriverNameSD.Text))
                            throw new Exception("Не указано Ф.И.О. водителя.");
                        else
                            this.Param2 = tbDriverNameSD.Text;

                        if (string.IsNullOrEmpty(tbAttorneyNumberSD.Text))
                             throw new Exception("Не указан № доверенности.");
                        else
                            this.Param3 = tbAttorneyNumberSD.Text;
                        break;
                    case 2:
                        if (string.IsNullOrEmpty(tbDeclarationNumberNP.Text))
                            throw new Exception("Не указан № декларации.");
                        else 
                            Param1 = tbDeclarationNumberNP.Text;
                        break;
                    case 3:
                        if (string.IsNullOrEmpty(tbCarNumberE.Text))
                            throw new Exception("Не указан № автомобиля.");
                        else
                            this.Param1 = tbCarNumberE.Text;

                        if (string.IsNullOrEmpty(tbDriverNameE.Text))
                            throw new Exception("Не указано Ф.И.О. водителя.");
                        else
                            this.Param2 = tbDriverNameE.Text;

                        if (string.IsNullOrEmpty(tbAttorneyNumberE.Text))
                            throw new Exception("Не указан № доверенности.");
                        else
                            this.Param3 = tbAttorneyNumberE.Text;
                        break;
                    default:
                        break;
                }

                this.PrintDate = dtpPrintDate.Checked ? dtpPrintDate.Value : (DateTime?)null;

                using (var adapter = new Data.ComplaintsTableAdapters.SV_VR_Docs_VendorsTableAdapter())
                    adapter.AddShipmentDoc(this.UserID, this.VendorID, this.PeriodFrom, shipmentTypeID, this.Param1, this.Param2, this.Param3, this.PrintDate);

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
