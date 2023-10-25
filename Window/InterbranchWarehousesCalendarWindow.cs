using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Classes;
using System.Globalization;
using WMSOffice.Dialogs.InterBranch;

namespace WMSOffice.Window
{
    public partial class InterbranchWarehousesCalendarWindow : GeneralWindow
    {
        public InterbranchWarehousesCalendarWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Initialize();
        }

        private void Initialize()
        {
            #region ИНИЦИАЛИЗАЦИЯ ФИЛЬТРА СКЛАДА ОТГРУЗКИ

            stbWarehouseID.ValueReferenceQuery = "[dbo].[pr_GW_Get_MCU_From]";
            stbWarehouseID.UserID = this.UserID;
            stbWarehouseID.OnVerifyValue += (s, e) =>
            {
                lblWarehouseDesc.Text = e.Success ? e.Description : "СКЛАД НЕ НАЙДЕН";
                lblWarehouseDesc.ForeColor = e.Success ? Color.Blue : Color.Red;

                if (e.Success)
                {
                    stbWarehouseID.Value = e.Value;

                    if (!string.IsNullOrEmpty(e.Value))
                        this.LoadCalendar();
                }
            };
            stbWarehouseID.SetFirstValueByDefault();

            tsMain.Items.Insert(0, new ToolStripControlHost(pnlWarehouseFilter));

            #endregion

            #region ИНИЦИАЛИЗАЦИЯ ФИЛЬТРА ДАТЫ ОТГРУЗКИ

            dtpShipmentDate.ValueChanged += (s, e) => { this.LoadCalendar(); };
            tsMain.Items.Insert(1, new ToolStripControlHost(pnlShipmentDateFilter));

            #endregion

            this.InitCalendar();

            stbWarehouseID.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.LoadCalendar();
                return true;
            }

            if (keyData == (Keys.F3))
            {
                this.EditCalendar();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Delete))
            {
                this.DeleteCalendar();
                return true;
            }

            if (keyData == (Keys.Control | Keys.S))
            {
                this.ExportCalendar();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvCalendar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvCalendar.Rows)
            {
                var item = (row.DataBoundItem as DataRowView).Row as Data.Interbranch.GW_CalendarRow;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex > 0)
                    {
                        var day = Convert.ToInt32(cell.OwningColumn.DataPropertyName.Substring(1));

                        var v = item[string.Format("V{0}", day)];
                        var rd = item[string.Format("RD{0}", day)];
                        var nf = item[string.Format("NF{0}", day)];
                        var ncd = item[string.Format("NCD{0}", day)];

                        var sbTip = new StringBuilder();

                        if (!v.Equals(DBNull.Value))
                            sbTip.AppendFormat("\n- Лимит: {0:N0} м³", (int)v);
                        if (!rd.Equals(DBNull.Value))
                            sbTip.AppendFormat("\n- Доступен с {0:dd.MM.yyyy}", (DateTime)rd);
                        if (!nf.Equals(DBNull.Value) && Convert.ToBoolean(nf) == true)
                            sbTip.AppendFormat("\n- Без дроби");
                        if (!ncd.Equals(DBNull.Value) && Convert.ToBoolean(ncd) == true)
                            sbTip.AppendFormat("\n- Без КД с ПО");

                        if (sbTip.Length > 0)
                            cell.ToolTipText = sbTip.ToString().TrimStart('\n');
                    }
                }
            }
        }

        private void dgvCalendar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
                return;

            this.EditCalendar(e);
        }

        private void dgvCalendar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
                return;

            var item = (dgvCalendar.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Interbranch.GW_CalendarRow;
            var day = Convert.ToInt32(dgvCalendar.Columns[e.ColumnIndex].DataPropertyName.Substring(1));

            var nf = item[string.Format("NF{0}", day)];
            var ncd = item[string.Format("NCD{0}", day)];

            if (!nf.Equals(DBNull.Value) && Convert.ToBoolean(nf) == true)
                e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = Color.LightGreen;

            if (!ncd.Equals(DBNull.Value) && Convert.ToBoolean(ncd) == true)
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.LoadCalendar();
        }

        private void LoadCalendar()
        {
            try
            {
                if (string.IsNullOrEmpty(stbWarehouseID.Value))
                    throw new Exception("Склад отгрузки должен быть задан.");

                var mcuFrom = stbWarehouseID.Value;
                var dtFrom = dtpShipmentDate.Value.Date;
                gW_CalendarTableAdapter.Fill(interbranch.GW_Calendar, this.UserID, mcuFrom, dtFrom);

                if (dgvCalendar.Rows.Count > 0)
                    dgvCalendar.Rows[0].Cells[0].Selected = false;

                this.InitCalendar();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void InitCalendar()
        {
            var dtPeriod = dtpShipmentDate.Value.Date;

            var idxDate = 0;
            foreach (var date in DateTimeHelper.GetWeekDays(dtPeriod))
            {
                dgvCalendar.Columns[++idxDate].HeaderText = string.Format("{0} - {1}", date.ToShortDateString(), DateTimeHelper.GetAbbreviatedDayName(date));
                dgvCalendar.Columns[idxDate].Tag = date;
            }
        }

        private void EditCalendar()
        {
            if (dgvCalendar.SelectedCells.Count == 0)
                return;

            if (dgvCalendar.SelectedCells[0].RowIndex < 0)
                return;

            if (dgvCalendar.SelectedCells[0].ColumnIndex == 0)
                return;

            this.EditCalendar(new DataGridViewCellEventArgs(dgvCalendar.SelectedCells[0].ColumnIndex, dgvCalendar.SelectedCells[0].RowIndex));
        }

        private void EditCalendar(DataGridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(stbWarehouseID.Value))
                    throw new Exception("Склад отгрузки должен быть задан.");

                var item = (dgvCalendar.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Interbranch.GW_CalendarRow;
                var day = Convert.ToInt32(dgvCalendar.Columns[e.ColumnIndex].DataPropertyName.Substring(1));

                var v = item[string.Format("V{0}", day)];
                var rd = item[string.Format("RD{0}", day)];
                var nf = item[string.Format("NF{0}", day)];
                var ncd = item[string.Format("NCD{0}", day)];

                var mcuToName = item.MCU_Name;
                var periodTo = (DateTime)dgvCalendar.Columns[dgvCalendar.SelectedCells[0].ColumnIndex].Tag;

                var mcuFrom = stbWarehouseID.Value;
                var mcuTo = item.MCU_To;

                var form = new InterbranchWarehousesCalendarEditForm
                {
                    UserID = this.UserID,
                    McuFrom = mcuFrom,
                    McuTo = mcuTo,
                    McuToName = mcuToName,
                    PeriodTo = periodTo,
                    V = (v == DBNull.Value ? (int?)null : (int)v),
                    RD = (rd == DBNull.Value ? (DateTime?)null : (DateTime)rd),
                    NF = (nf == DBNull.Value ? (bool?)null : Convert.ToBoolean(nf)),
                    NCD = (ncd == DBNull.Value ? (bool?)null : Convert.ToBoolean(ncd))
                };
                if (form.ShowDialog() == DialogResult.OK)
                    this.LoadCalendar();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void DeleteCalendar()
        {
            try
            {
                if (dgvCalendar.SelectedCells.Count == 0)
                    return;

                if (dgvCalendar.SelectedCells[0].RowIndex < 0)
                    return;

                if (dgvCalendar.SelectedCells[0].ColumnIndex == 0)
                    return;

                if (string.IsNullOrEmpty(stbWarehouseID.Value))
                    throw new Exception("Склад отгрузки должен быть задан.");

                var item = (dgvCalendar.Rows[dgvCalendar.SelectedCells[0].RowIndex].DataBoundItem as DataRowView).Row as Data.Interbranch.GW_CalendarRow;
                var day = Convert.ToInt32(dgvCalendar.Columns[dgvCalendar.SelectedCells[0].ColumnIndex].DataPropertyName.Substring(1));

                var v = item[string.Format("V{0}", day)];

                if (v.Equals(DBNull.Value))
                    return;
                
                var mcuToName = item.MCU_Name;
                var periodTo = (DateTime)dgvCalendar.Columns[dgvCalendar.SelectedCells[0].ColumnIndex].Tag;

                if (MessageBox.Show(string.Format("Вы желаете удалить данные\nпо складу доставки \"{0}\"\nза период {1}?", mcuToName.TrimEnd(), periodTo.ToShortDateString()), "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;

                var mcuFrom = stbWarehouseID.Value;
                var mcuTo = item.MCU_To;

                gW_CalendarTableAdapter.EditCalendar(this.UserID, mcuFrom, mcuTo, periodTo, (int?)null, (DateTime?)null, (bool?)null, (bool?)null);

                this.LoadCalendar();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.ExportCalendar();
        }

        private void ExportCalendar()
        {
            try
            {
                if (string.IsNullOrEmpty(stbWarehouseID.Value))
                    throw new Exception("Склад отгрузки должен быть задан.");

                var table = interbranch.GW_Calendar;

                var titles = new List<string>();
                var columns = new List<string>();
                foreach (DataGridViewColumn column in dgvCalendar.Columns)
                {
                    if (column.Visible)
                    {
                        titles.Add(column.HeaderText);
                        columns.Add(column.DataPropertyName);
                    }
                }

                var message = ExportHelper.ExportDataTableToExcel(table, titles.ToArray(), columns.ToArray(),
                   "Экспорт календаря межскладов", String.Format("Экспорт календаря межскладов по складу отгрузки {0} за период с {1} по {2}", lblWarehouseDesc.Text.Trim(), DateTimeHelper.StartOfWeek(dtpShipmentDate.Value.Date, DayOfWeek.Monday).ToShortDateString(), DateTimeHelper.EndOfWeek(dtpShipmentDate.Value.Date, DayOfWeek.Monday).ToShortDateString()), true);

                if (!String.IsNullOrEmpty(message))
                    Logger.ShowErrorMessageBox(String.Format("Во время экспорта в Excel возникла ошибка:\n{0}", message));
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void miAdd_Click(object sender, EventArgs e)
        {
            this.EditCalendar();
        }

        private void miEdit_Click(object sender, EventArgs e)
        {
            this.EditCalendar();
        }

        private void miDelete_Click(object sender, EventArgs e)
        {
            this.DeleteCalendar();
        }

        private void dgvCalendar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvCalendar.HitTest(e.X, e.Y);
                if (hti.Type == DataGridViewHitTestType.Cell)
                    dgvCalendar.Rows[hti.RowIndex].Cells[hti.ColumnIndex].Selected = true;
            }
        }

        private void cmsMain_Opening(object sender, CancelEventArgs e)
        {
            if (dgvCalendar.SelectedCells.Count == 0 ||
                        dgvCalendar.SelectedCells[0].RowIndex < 0 ||
                        dgvCalendar.SelectedCells[0].ColumnIndex == 0)
            {
                e.Cancel = true;
                return;
            }

            this.ChangeOperationsAccess();
        }

        private void ChangeOperationsAccess()
        {
            try
            {
                var item = (dgvCalendar.Rows[dgvCalendar.SelectedCells[0].RowIndex].DataBoundItem as DataRowView).Row as Data.Interbranch.GW_CalendarRow;
                var day = Convert.ToInt32(dgvCalendar.Columns[dgvCalendar.SelectedCells[0].ColumnIndex].DataPropertyName.Substring(1));

                var v = item[string.Format("V{0}", day)];

                var canAdd = v.Equals(DBNull.Value);
                miAdd.Enabled = canAdd;

                var canEdit = !canAdd;
                miEdit.Enabled = canEdit;

                var canDelete = !canAdd;
                miDelete.Enabled = canDelete;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }
}
