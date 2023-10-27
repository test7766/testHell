using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.ColdChain
{
    public partial class SelectBranchForm : DialogForm
    {
        public string BranchID 
        {
            get { return lbBranches.SelectedValue.ToString(); } 
        }

        public SelectBranchForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;  
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            lbBranches.Focus();
        }

        private void SelectBranchForm_Load(object sender, EventArgs e)
        {
            RefreshBranches();
        }

        /// <summary>
        /// Обновление списка филиалов
        /// </summary>
        private void RefreshBranches()
        {
            this.branchesTableAdapter.Fill(this.coldChain.Branches);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ApplyOperation(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ApplyOperation(DialogResult.Cancel);
        }

        /// <summary>
        /// Выполнить запрашиваемую операцию согласно ожидаемого результата - статуса диалогового окна
        /// </summary>
        /// <param name="agreedResult"></param>
        private void ApplyOperation(DialogResult agreedResult)
        {
            this.DialogResult = agreedResult;
            this.Close();
        }

        private void lbBranches_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ApplyOperation(DialogResult.OK);
        }
    }
}
