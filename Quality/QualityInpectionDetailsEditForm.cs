using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class QualityInpectionDetailsEditForm : DialogForm
    {
        public int? InspectionID { get; private set; }

        public DateTime? PlanReceiptDate { get; private set; }

        public QualityInpectionDetailsEditForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(197, 8);
            this.btnCancel.Location = new Point(287, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            try
            {
                qK_ICD_Place_InspectionsTableAdapter.Fill(quality.QK_ICD_Place_Inspections, this.UserID);

                if (quality.QK_ICD_Place_Inspections.Count > 0)
                    cmbInspectionPlaces.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QualityInpectionDetailsEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                if (cmbInspectionPlaces.SelectedValue == null)
                    throw new Exception("Не обрано місце проведення інспекції.");

                this.InspectionID = Convert.ToInt32(cmbInspectionPlaces.SelectedValue);
                this.PlanReceiptDate = dtpPlanReceiptDate.Value.Date;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
