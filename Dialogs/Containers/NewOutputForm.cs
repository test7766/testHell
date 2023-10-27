using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Containers
{
    public partial class NewOutputForm : DialogForm
    {
        private bool _isOutput;

        public NewOutputForm(bool isOutput)
        {
            InitializeComponent();
            _isOutput = isOutput;
            if (_isOutput)
            {
                this.label1.Text = "Выберите отдел," + Environment.NewLine + "в который будет передаваться тара:";
                this.cbDepartments.DataSource = this.departmentsBindingSource;
                this.cbDepartments.DisplayMember = "Department";
                this.cbDepartments.ValueMember = "Department_ID";
            } else
            {
                this.label1.Text = "Выберите филиал," + Environment.NewLine + "с которого принимается тара:";
                this.cbDepartments.DataSource = this.filialsBindingSource;
                this.cbDepartments.DisplayMember = "Warehouse";
                this.cbDepartments.ValueMember = "Warehouse_ID";
            }
        }

        private void NewOutputForm_Load(object sender, EventArgs e)
        {
            if (_isOutput)
            {
                this.departmentsTableAdapter.Fill(this.containers.Departments, this.UserID);
            }
            else
            {
                this.filialsTableAdapter.Fill(this.containers.Filials, this.UserID);
            }
        }

        public string Department
        {
            get { return (string)cbDepartments.SelectedValue; }
        }

        public string DepartmentName
        {
            get { return (string)cbDepartments.Text; }
        }
    }
}
