using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Receive;
using WMSOffice.Dialogs.WO;

namespace WMSOffice.Dialogs
{
    public partial class WOAdminForm : Form
    {
        public WOAdminForm()
        {
            InitializeComponent();
        }

        public int UserID { get; set; }

        private void WOAdminForm_Load(object sender, EventArgs e)
        {
            // справочники, фильтры
            typesTableAdapter.Fill(wo.Types, UserID);
            wo.Statuses.AddStatusesRow("", "(все)");
            wo.Statuses.Merge(statusesTableAdapter.GetData());
            if (cbStatuses.Items.Count > 4) cbStatuses.SelectedIndex = 4;

            // сразу обновляем список документов
            RefreshWO();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region refresh WO
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshWO();
        }

        private void cbTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshWO();
        }

        private void cbStatuses_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshWO();
        }

        private void RefreshWO()
        {
            long selDocID = 0;
            int rowIndex = 0;
            if (gvWO.SelectedRows.Count == 1)
            {
                selDocID = ((Data.WO.WorkOrdersRow)((DataRowView)gvWO.SelectedRows[0].DataBoundItem).Row).Doc_ID;
                rowIndex = gvWO.FirstDisplayedScrollingRowIndex;
            }

            if (wo.Types.Count >0)
            {
                workOrdersTableAdapter.Fill(wo.WorkOrders, UserID, (string)cbTypes.SelectedValue, (string)cbStatuses.SelectedValue);
            }

            if (selDocID != 0)
                foreach (DataGridViewRow row in gvWO.Rows)
                    if (selDocID == ((Data.WO.WorkOrdersRow)((DataRowView)row.DataBoundItem).Row).Doc_ID)
                    {
                        row.Selected = true;
                        if (gvWO.RowCount > rowIndex)
                            gvWO.FirstDisplayedScrollingRowIndex = rowIndex;
                        break;
                    }
        }
        #endregion

        private void btnRepeat_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvWO.SelectedRows.Count == 1)
                {
                    Data.WO.WorkOrdersRow selWO =
                        ((Data.WO.WorkOrdersRow)((DataRowView)gvWO.SelectedRows[0].DataBoundItem).Row);
                    workOrdersTableAdapter.RepeatWO(selWO.Doc_ID, UserID);
                    RefreshWO();
                }
                else
                    btnRepeat.Enabled = btnAddAssingment.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gvWO_SelectionChanged(object sender, EventArgs e)
        {
            RefreshAssignments();
        }

        private void RefreshAssignments()
        {
            try
            {
                if (gvWO.SelectedRows.Count == 1)
                {
                    Data.WO.WorkOrdersRow selWO =
                        ((Data.WO.WorkOrdersRow) ((DataRowView) gvWO.SelectedRows[0].DataBoundItem).Row);
                    btnRepeat.Enabled = selWO.AllowRepeat;
                    btnAddAssingment.Enabled = selWO.AllowAddAssignment;
                    assigmentsTableAdapter.Fill(wo.Assigments, selWO.Doc_ID);
                }
                else
                    btnRepeat.Enabled = btnAddAssingment.Enabled = false;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message); }
        }

        #region assingments
        private void btnAddAssingment_Click(object sender, EventArgs e)
        {
            if (gvWO.SelectedRows.Count == 1)
            {
                Data.WO.WorkOrdersRow selWO =
                    ((Data.WO.WorkOrdersRow) ((DataRowView) gvWO.SelectedRows[0].DataBoundItem).Row);

                try
                {
                    AddAssingmentForm form = new AddAssingmentForm();
                    if (form.ShowDialog() == DialogResult.OK)
                        if (form.SelectedTerminals.Count > 0)
                        {
                            foreach (string term in form.SelectedTerminals)
                            {
                                assigmentsTableAdapter.AddAssigment(selWO.Doc_ID, UserID, term);
                            }
                            RefreshAssignments();
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelAssignment_Click(object sender, EventArgs e)
        {
            if (gvAssingments.SelectedRows.Count == 1)
            {
                try
                {
                    Data.WO.AssigmentsRow selAssign =
                        ((Data.WO.AssigmentsRow) ((DataRowView) gvAssingments.SelectedRows[0].DataBoundItem).Row);
                    assigmentsTableAdapter.DeleteAssigment(selAssign.Assig_ID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gvAssingments_SelectionChanged(object sender, EventArgs e)
        {
            if (gvAssingments.SelectedRows.Count == 1)
            {
                Data.WO.AssigmentsRow selAssign =
                    ((Data.WO.AssigmentsRow)((DataRowView)gvAssingments.SelectedRows[0].DataBoundItem).Row);
                btnDelAssignment.Enabled = selAssign.AllowDelete;
            }
            else
                btnDelAssignment.Enabled = false;
        }
        #endregion


    }
}
