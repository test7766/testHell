using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class ExpertCenterChoiceFrm : Form
    {

        List<ExpertItem> items = new List<ExpertItem>();

        public int? SelectedValue { get { return (int?)cmbExpertCenter.SelectedValue; } }

        public ExpertCenterChoiceFrm()
        {
            InitializeComponent();
            ContentItems();
        }

        private void ContentItems()
        {
            items.Add(new ExpertItem(0, "- НИИ микробиологии и вирусологии им. Д.К. Заболотного"));
            items.Add(new ExpertItem(1, "- ГП «Государственный экспертный центр МОЗ Украины»"));
            cmbExpertCenter.DataSource = items;
            cmbExpertCenter.SelectedValue = 0;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            StartPosition = Owner == null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent;
        }


        class ExpertItem
        {
            public ExpertItem(int key, string value)
            {
                Key = key;
                Value = value;
            }
            public int Key { get; set; }
            public string Value { get; set; }
        }
    }
}
