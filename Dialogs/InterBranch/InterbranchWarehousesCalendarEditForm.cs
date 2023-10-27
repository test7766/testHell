using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.InterBranch
{
    public partial class InterbranchWarehousesCalendarEditForm : DialogForm
    {
        public string McuFrom { get; set; }
        public string McuTo { get; set; }
        public string McuToName { get; set; }
        public DateTime PeriodTo { get; set; }

        public int? V { get; set; }
        public DateTime? RD { get; set; }
        public bool? NF { get; set; }
        public bool? NCD { get; set; }

        public InterbranchWarehousesCalendarEditForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(173, 8);
            this.btnCancel.Location = new Point(263, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            tbMcuToName.Text = this.McuToName;
            tbPeriodTo.Text = this.PeriodTo.ToShortDateString();

            if (this.V.HasValue)
            {
                nudV.Value = Convert.ToDecimal(this.V ?? Convert.ToInt32(nudV.Minimum));
                dtpRD.Value = this.RD ?? DateTime.Today;
                cbNF.Checked = this.NF ?? false;
                cbNCD.Checked = this.NCD ?? false;
            }
            else
            { 
                var v = (int?)null;
                var rd = (DateTime?)null;
                var nf = (bool?)null;
                var ncd = (bool?)null;

                using (var adapter = new Data.InterbranchTableAdapters.GW_CalendarTableAdapter())
                    adapter.InitCalendar(this.UserID, this.McuFrom, this.McuTo, this.PeriodTo, ref v, ref rd, ref nf, ref ncd);

                nudV.Value = Convert.ToDecimal(this.V = (v ?? Convert.ToInt32(nudV.Minimum)));
                dtpRD.Value = (this.RD = (rd ?? DateTime.Today)).Value;
                cbNF.Checked = (this.NF = (nf ?? false)).Value;
                cbNCD.Checked = (this.NCD = (ncd ?? false)).Value;

                this.Text = string.Format("* {0}", this.Text);
            }

            nudV.Focus();
        }

        private void InterbranchWarehousesCalendarEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                this.V = Convert.ToInt32(nudV.Value);
                this.RD = dtpRD.Value;
                this.NF = cbNF.Checked;
                this.NCD = cbNCD.Checked;

                using (var adapter = new Data.InterbranchTableAdapters.GW_CalendarTableAdapter())
                    adapter.EditCalendar(this.UserID, this.McuFrom, this.McuTo, this.PeriodTo, this.V, this.RD, this.NF, this.NCD);

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
