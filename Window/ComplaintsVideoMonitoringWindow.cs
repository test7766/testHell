using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Classes.VideoMonitoring;

namespace WMSOffice.Window
{
    public partial class ComplaintsVideoMonitoringWindow : GeneralWindow
    {
        public ComplaintsVideoMonitoringWindow()
        {
            InitializeComponent();
        }

        private void ComplaintsVideoMonitoringWindow_Load(object sender, EventArgs e)
        {
            var lstContext = new List<IOperationContext>();


            var genComplaints = ComplaintsOperationContextTextGenerator.Generate();

            lstContext.Add(ComplaintsOperationContext.CreateEmptyContext());
            foreach (var complaintContext in genComplaints)
                lstContext.Add(complaintContext);

            //lstContext.Add(new ComplaintsOperationContext() { OperationID = -1, OperationName = "(не выбрано)" });
            //lstContext.Add(new ComplaintsOperationContext() { OperationID = 66231061, OperationName = string.Format("Оп. {0}", 66231061), IP = "192.168.100.191", Port = 2515 });
            //lstContext.Add(new ComplaintsOperationContext() { OperationID = 66230630, OperationName = string.Format("Оп. {0}", 66230630), IP = "192.168.100.191", Port = 2615 });
            //lstContext.Add(new ComplaintsOperationContext() { OperationID = 66229739, OperationName = string.Format("Оп. {0}", 66229739), IP = "192.168.100.191", Port = 2506 });
            //lstContext.Add(new ComplaintsOperationContext() { OperationID = 66202288, OperationName = string.Format("Оп. {0}", 66202288), IP = "192.168.100.191", Port = 2526 });

            cmbComplaints.ComboBox.SelectedValueChanged += new EventHandler(ComboBox_SelectedValueChanged);

            cmbComplaints.ComboBox.ValueMember = "OperationID";
            cmbComplaints.ComboBox.DisplayMember = "OperationName";

            var bs = new BindingSource(lstContext, null);
            cmbComplaints.ComboBox.DataSource = bs; 
        }

        void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbComplaints.ComboBox.SelectedValue != null)
                ctrlVideoMonitoring.Initialize(cmbComplaints.ComboBox.SelectedItem as IOperationContext);
        }
    }
}
