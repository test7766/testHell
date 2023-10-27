using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data.InventoryTableAdapters;
using System.Data.SqlClient;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryCheckDialog : Form
    {
        public InventoryCheckDialog()
        {
            InitializeComponent();
            dgView.AutoGenerateColumns = false;

            Columns = new DataGridViewColumnCollection(dgView);
        }

        private bool _hasChecked = false;
        int TotalCheckBoxes = 0;
        int TotalCheckedCheckBoxes = 0;
        bool IsHeaderCheckBoxClicked = false;
        CheckBox HeaderCheckBox = null;

        public DataGridViewColumnCollection Columns { get; set; }

        private int _docID = int.MinValue;
        public int DocID
        {
            get
            {
                return _docID;
            }
            set
            {
                if (_docID == value)
                    return;
                _docID = value;
                PrepareData();
            }
        }

        public WMSOffice.Data.Inventory.pr_IV_Get_CheckInformationRow SelectedItem
        {
            get
            {
                return (WMSOffice.Data.Inventory.pr_IV_Get_CheckInformationRow)(((DataRowView)dgView.SelectedRows[0].DataBoundItem).Row);
            }
        }

        private readonly Dictionary<int, bool> checkList = new Dictionary<int, bool>();

        private void PrepareData()
        {
            PrepareData(true);

            WMSOffice.Data.Inventory.pr_IV_Get_CheckInformationDataTable ds = (WMSOffice.Data.Inventory.pr_IV_Get_CheckInformationDataTable)dgView.DataSource;
            foreach (DataGridViewRow item in dgView.Rows)
                ((DataGridViewCheckBoxCell)item.Cells[clmCheck.Index]).Value =
                    Convert.ToInt32(ds.Rows[item.Index][ds.Status_IDColumn]) != 2;
        }

        public bool HasChecked
        {
            get
            {
                return _hasChecked;
            }
            set
            {
                if (_hasChecked == value)
                    return;
                _hasChecked = value;
                btnOk.Enabled = _hasChecked;
            }
        }

        private void PrepareData(bool isInit)
        {
            using (pr_IV_Get_CheckInformationTableAdapter dta = new pr_IV_Get_CheckInformationTableAdapter())
            {
                WMSOffice.Data.Inventory.pr_IV_Get_CheckInformationDataTable dtaGetData = dta.GetData(DocID);
                
                dgView.DataSource = dtaGetData;

                TotalCheckBoxes = dgView.RowCount;
                TotalCheckedCheckBoxes = 0;

                if (isInit)
                    AddHeaderCheckBox();

                if (dtaGetData.Rows.Count > 0)
                    lblTimeJob.Text = String.Format("Плановое время завершения: {0:HH:mm:ss}", dtaGetData.Rows[0][dtaGetData.PlanTimeColumn]);
                timerActive.Start();
            }
        }

        private void dgView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                WMSOffice.Data.Inventory.pr_IV_Get_CheckInformationDataTable ds = (WMSOffice.Data.Inventory.pr_IV_Get_CheckInformationDataTable)dgView.DataSource;

                if (ds == null)
                    return;

                if (dgView.Columns[e.ColumnIndex] == clmCheck && checkList.Count > 0)
                    e.Value = checkList[Convert.ToInt32(ds.Rows[e.RowIndex][ds.Check_IDColumn])];

                if (dgView.Columns[e.ColumnIndex] == clmImage)
                {
                    var ret = Convert.ToInt32(ds.Rows[e.RowIndex][ds.Status_IDColumn]);
                    switch (ret)
                    {
                        case 1:
                            e.Value = imageList.Images["status-offline.png"];
                            break;
                        case 2:
                            e.Value = imageList.Images["ok.png"];
                            break;
                        case 3:
                            e.Value = imageList.Images["status-error.png"];
                            break;
                        case 4:
                            e.Value = imageList.Images["status-warn.png"];
                            break;
                        case 5:
                            e.Value = imageList.Images["status-ok.png"];
                            break;
                        default:
                            e.Value = imageList.Images["status-offline.png"];
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!IsHeaderCheckBoxClicked && dgView.RowCount > 0)
                    RowCheckBoxClick((DataGridViewCheckBoxCell)dgView[e.ColumnIndex, e.RowIndex]);

                if (clmCheck.Index == e.ColumnIndex)
                {
                    bool _checked = true;
                    if (!Boolean.TryParse(dgView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out _checked))
                        return;
                    WMSOffice.Data.Inventory.pr_IV_Get_CheckInformationDataTable ds = (WMSOffice.Data.Inventory.pr_IV_Get_CheckInformationDataTable)dgView.DataSource;
                    var ret = Convert.ToInt32(ds.Rows[e.RowIndex][ds.Check_IDColumn]);

                    checkList[ret] = _checked;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmCheck.Index || SelectedItem == null)
                return;
            Cursor cursor = Cursor;

            try
            {
                WMSOffice.Data.Inventory.pr_IV_Get_CheckInformationDataTable dataSource = (WMSOffice.Data.Inventory.pr_IV_Get_CheckInformationDataTable)dgView.DataSource;
                var ret = Convert.ToInt32(dataSource.Rows[e.RowIndex][dataSource.Status_IDColumn]);

                if (ret == 1)
                {
                    MessageBox.Show(this,
                        "Результатов проверки нет.\n\rПроверка не выполнялась.",
                        "Детали",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
                if (ret == 2)
                {
                    MessageBox.Show(this,
                        "Результатов проверки нет.\n\rПроверка не завершена.",
                        "Детали",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                Cursor = Cursors.WaitCursor;

                pr_IV_Get_CheckInformationTableAdapter dta = new pr_IV_Get_CheckInformationTableAdapter();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = dta.Connection,
                    CommandText = "dbo.pr_IV_Get_CheckDetail",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Inv_ID", DocID);
                cmd.Parameters.AddWithValue("@Check_ID", SelectedItem.Check_ID);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
                if (ds.Tables.Count <= 0)
                    return;

                Cursor = cursor;

                using (InventoryCheckDetailDialog dlg = new InventoryCheckDetailDialog()
                {
                    Owner = this,
                    DataSource = ds.Tables[0],
                    Text = String.Format("Детали [{0}]", SelectedItem.Check_Dsc)
                })
                    dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Cursor = cursor;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,
                    "Запустить выполнение выбранных проверок?",
                    "Запуск.",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in checkList)
                    if (item.Value)
                        sb.Append(sb.Length == 0 ? item.Key.ToString() : String.Format(";{0}", item.Key));
                using (pr_IV_Get_CheckInformationTableAdapter dta = new pr_IV_Get_CheckInformationTableAdapter())
                    dta.pr_IV_Add_Check(DocID, sb.ToString());

                PrepareData(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void timerCheck_Tick(object sender, EventArgs e)
        {
            PrepareData(false);
        }

        private void InventoryCheckDialog_Activated(object sender, EventArgs e)
        {
            timerCheck.Stop();
        }

        private void timerActive_Tick(object sender, EventArgs e)
        {
            timerCheck.Start();
        }

        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new CheckBox() { Size = new Size(15, 15) };

            HeaderCheckBox.KeyUp += HeaderCheckBox_KeyUp;
            HeaderCheckBox.MouseClick += HeaderCheckBox_MouseClick;

            dgView.Controls.Add(HeaderCheckBox);
            HeaderCheckBox.Checked = true;
            HeaderCheckBoxClick(HeaderCheckBox);
        }

        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        {
            Rectangle oRectangle = this.dgView.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point()
            {
                X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1,
                Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1
            };

            HeaderCheckBox.Location = oPoint;
        }

        private void dgView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
                ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
        }

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;
            HasChecked = HCheckBox.Checked;
            foreach (DataGridViewRow Row in dgView.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells[clmCheck.Index]).Value = HCheckBox.Checked;

            dgView.RefreshEdit();
            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;
            IsHeaderCheckBoxClicked = false;
        }

        private void RowCheckBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
            if (RCheckBox != null)
            {
                if ((bool)RCheckBox.Value && TotalCheckedCheckBoxes < TotalCheckBoxes)
                    TotalCheckedCheckBoxes++;
                else if (TotalCheckedCheckBoxes > 0)
                    TotalCheckedCheckBoxes--;

                if (TotalCheckedCheckBoxes < TotalCheckBoxes)
                    HeaderCheckBox.Checked = false;
                else if (TotalCheckedCheckBoxes == TotalCheckBoxes)
                    HeaderCheckBox.Checked = true;

                HasChecked = TotalCheckedCheckBoxes > 0;
            }
        }

        private void dgView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgView.CurrentCell is DataGridViewCheckBoxCell)
                dgView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
