using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.Custom;
using WMSOffice.Window;
using System.Diagnostics;

namespace WMSOffice.Dialogs.Receive
{
    public partial class ShipmentsFindForm : DialogForm
    {
        public IHost Host { get; set; }

        //private SplashForm WaitProgressForm = new SplashForm();

        public DateTime ShipmentDate { get; set; }

        //public OperationAccess Access { get; set; }

        public ShipmentsFindForm()
        {
            InitializeComponent();
        }

        private void ShipmentsFindForm_Load(object sender, EventArgs e)
        {
            this.CustomizeGridColumns();
            this.LoadRamps();
            this.dgvcShipmentSignColumn.DefaultCellStyle.NullValue = null;
        }

        /// <summary>
        /// Загрузка справочника рамп
        /// </summary>
        private void LoadRamps()
        {
            this.rampsBindingSource.DataSource = this.rampsTableAdapter.GetData(this.Host.SessionID, (int?)null);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Width = 100; 
            btnOK.Text = "Перейти к дате";
            this.btnOK.Location = new Point(1025, 8);

            btnCancel.Width = 100; 
            this.btnCancel.Location = new Point(1135, 8);

            this.LoadData();
        }

        /// <summary>
        /// Настройка отображения колонок
        /// </summary>
        private void CustomizeGridColumns()
        {
            if (this.DesignMode)
                return;

            // TODO на форме поиска поставок необходимость в скрываемых колонках пропадает

            //List<DataGridViewColumn> targetColumns = new List<DataGridViewColumn>();
            //targetColumns.Add(carNumber);
            //targetColumns.Add(description);
            //targetColumns.Add(FactDate);
            //targetColumns.Add(FactTime);
            //targetColumns.Add(PlanDuration);
            //var headerCell = new DataGridViewReversedVisibilityColumnHeaderCell(targetColumns, ContentVisibility.Hide);
            //headerCell.OnChangeTargetColumnsVisibility += new EventHandler<ChangeColumnsVisibilityArgs>(headerCell_OnChangeTargetColumnsVisibility);
            //headerCell.InvokeReverseColumnsVisibility();
            //headerCell.Value = this.PlanDate.HeaderText;
            //this.PlanDate.HeaderCell = headerCell;
        }

        //void headerCell_OnChangeTargetColumnsVisibility(object sender, ChangeColumnsVisibilityArgs e)
        //{
        //    bool targetColumnsVisible = e.TargetColumnsVisibility == ContentVisibility.Show;
        //    foreach (DataGridViewColumn column in e.TargetColumns)
        //        column.Visible = targetColumnsVisible;
        //}

        /// <summary>
        /// Загрузка поставок
        /// </summary>
        public void LoadData()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    e.Result = this.freeShipmentsOnDateTableAdapter.GetData(this.Host.SessionID, this.ShipmentDate, true, Convert.ToInt16(this.Host.Access), (int?)null);
                    //System.Threading.Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };

            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    this.freeShipmentsOnDateBindingSource.DataSource = e.Result;

                this.Host.WaitProgressForm.CloseForce();
            };

            this.freeShipmentsOnDateBindingSource.DataSource = null;
            this.Host.WaitProgressForm.ActionText = "Выполняется загрузка данных по поставкам на разгрузку..";
            loadWorker.RunWorkerAsync();
            this.Host.WaitProgressForm.ShowDialog();
        }

        private void dgvShipments_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var shipmentRow = (this.dgvShipments.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Receive.FreeShipmentsOnDateRow;
            var dlgShipmentOrders = new OrdersByShipmentForm(this.Host, (int)shipmentRow.ShipmentID);
            dlgShipmentOrders.ShowDialog();
        }

        private void dgvShipments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = sender as DataGridView;

            var boundRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Receive.FreeShipmentsOnDateRow;

            if (grid.Columns[e.ColumnIndex].DataPropertyName == receive.FreeShipmentsOnDate.PlanDateColumn.Caption)
            {
                #region СТИЛЬ ДЛЯ ПОСТАВОК БЕЗ ДАТЫ ПЛАНИРОВАНИЯ
                if (!boundRow.IsWithoutDateNull())
                {
                    if (boundRow.WithoutDate)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                    }
                }
                #endregion
            }

            if (grid.Columns[e.ColumnIndex].DataPropertyName == receive.FreeShipmentsOnDate.StatusNameColumn.Caption)
            {
                #region СТИЛЬ ДЛЯ СТАТУСА ПОСТАВКИ
                if (!boundRow.IsStatus_IDNull())
                {
                    bool isEmptyShipment = !boundRow.IsIsEmptyShipmentNull() && boundRow.IsEmptyShipment;
                    e.CellStyle.ForeColor = isEmptyShipment ? Color.FromArgb(0, 0, 255) : Color.Black;
                    e.CellStyle.SelectionForeColor = isEmptyShipment ? Color.FromArgb(0, 0, 255) : Color.Black;

                    grid.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = string.Format("{0}\nнаходится на статусе \"{1}\"",
                       isEmptyShipment ? "Поставка-\"пустышка\"" : "Поставка с заказами", boundRow.StatusName);

                    switch (boundRow.Status_ID)
                    {
                        case "100": // Записана
                            e.CellStyle.BackColor = Color.FromArgb(236, 236, 236);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(236, 236, 236);
                            break;
                        case "105": // Подтверждена
                            e.CellStyle.BackColor = Color.FromArgb(229, 243, 247);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(229, 243, 247);
                            break;
                        case "110": // Приехала
                            e.CellStyle.BackColor = Color.FromArgb(255, 225, 225);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(255, 225, 225);
                            break;
                        case "115": // Ожидает
                            e.CellStyle.BackColor = Color.FromArgb(255, 210, 67);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 67);
                            break;
                        case "120": // Приглашена
                            e.CellStyle.BackColor = Color.FromArgb(255, 255, 153);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(255, 255, 153);
                            break;
                        case "125": // Выгружена
                            e.CellStyle.BackColor = Color.FromArgb(209, 255, 117);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(209, 255, 117);
                            break;
                        case "130": // Загружена
                            e.CellStyle.BackColor = Color.FromArgb(146, 208, 80);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(146, 208, 80);
                            break;
                        default:
                            break;
                    }
                }
                #endregion
            }
        }

        private void dgvShipments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvShipments.Rows)
            {
                var boundItem = (row.DataBoundItem as DataRowView).Row as Data.Receive.FreeShipmentsOnDateRow;
                if (boundItem.Conflict)
                {
                    row.Cells[dgvcShipmentSignColumn.Index].Value = Properties.Resources.Achtung;
                    row.Cells[dgvcShipmentSignColumn.Index].ToolTipText = "Незаписанная поставка";
                }

                if (boundItem.WithoutDate)
                {
                    row.Cells[dgvcShipmentSignColumn.Index].Value = Properties.Resources.Achtung;
                    row.Cells[dgvcShipmentSignColumn.Index].ToolTipText = "Незаписанная поставка";
                }
            }
        }

        private void ShipmentsFindForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (dgvShipments.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Не выбрана поставка.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                    return;
                }

                this.ShipmentDate = ((this.dgvShipments.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Receive.FreeShipmentsOnDateRow).PlanDate;
            }
        }

        /// <summary>
        /// Экспорт в Excel
        /// </summary>
        private void sbExportToExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlgSelectFile = new SaveFileDialog())
            {
                dlgSelectFile.Title = "Экспорт запланированных поставок";

                DateTime now = DateTime.Now;
                dlgSelectFile.FileName = string.Format("{0}{1}{2}{3}{4}{5}-список поставок",
                    now.Year.ToString(),
                    now.Month.ToString().PadLeft(2, '0'),
                    now.Day.ToString().PadLeft(2, '0'),
                    now.Hour.ToString().PadLeft(2, '0'),
                    now.Minute.ToString().PadLeft(2, '0'),
                    now.Second.ToString().PadLeft(2, '0')
                    );

                dlgSelectFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dlgSelectFile.Filter = "Текстовый файл с разделителями (*.csv)|*.csv";//;*.csv|Все файлы (*.*)|*.*";
                dlgSelectFile.FilterIndex = 0;
                dlgSelectFile.AddExtension = true;
                dlgSelectFile.DefaultExt = "csv";
                if (dlgSelectFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ImportExportHelper.ExportGridToExcel(this.dgvShipments, dlgSelectFile.FileName);
                        Process.Start(dlgSelectFile.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }      
        }

    }
}
