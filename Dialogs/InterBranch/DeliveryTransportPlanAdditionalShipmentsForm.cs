using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WMSOffice.Dialogs.InterBranch
{
    public partial class DeliveryTransportPlanAdditionalShipmentsForm : DialogForm
    {
        public new long UserID { get; set; }

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public DateTime ShipmentDate { get; set; }

        public Data.Interbranch.TSP_FilialsRow CurrentFilial { get; set; }

        public bool IsReadOnly { get; private set; }

        public DeliveryTransportPlanAdditionalShipmentsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            if (this.IsReadOnly)
            {
                this.Text = string.Format("{0} (только чтение)", this.Text);
                dgvShipments.ReadOnly = true;
            }

            btnOK.Location = new Point(1157, 8);
            btnCancel.Location = new Point(1247, 8);

            if (this.IsReadOnly)
            {
                this.btnOK.Visible = false;
                this.btnCancel.Text = "Закрыть";
            }
        }

        private void Initialize()
        {
            this.CustomizeGrid();
            this.LoadShipments();
        }

        private void CustomizeGrid()
        {
            this.RefreshDeliveries();

            this.CreateDeliveriesCaptions();

            this.CreateShipmentsTotalCaptions();
        }

        private void RefreshDeliveries()
        {
            try
            {
                using (var adapter = new Data.InterbranchTableAdapters.TSP_DeliveriesTableAdapter())
                    adapter.Fill(interbranch.TSP_Deliveries, (int?)null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateDeliveriesCaptions()
        {
            dgvDeliveries.AutoGenerateColumns = false;

            dgvDeliveries.Columns.Insert(0, new DataGridViewColumn() { HeaderText = "Направление", Width = 245, Frozen = true }); // 230

            foreach (Data.Interbranch.TSP_DeliveriesRow delivery in interbranch.TSP_Deliveries)
            {
                var column = new DataGridViewTextBoxColumn()
                {
                    HeaderText = delivery.Delivery_Name,
                    ToolTipText = delivery.Delivery_Name_Full,
                    Tag = delivery.Delivery_ID,
                    Width = 90, //100, //84, //80 //120 
                    SortMode = DataGridViewColumnSortMode.NotSortable
                };
                dgvDeliveries.Columns.Add(column);
            }
        }

        private void CreateShipmentsTotalCaptions()
        {
            this.dgvShipmentsTotal.Rows.Clear();
            this.dgvShipmentsTotal.Columns.Clear();
            
            foreach (DataGridViewColumn column in this.dgvShipments.Columns)
            {
                DataGridViewColumn newColumn = null;
                // Адаптивное изменение размеров колонок
                if (column.Index > 0)
                {
                    column.Width = 90; // 50 // 42; // 40;
                    column.HeaderText = column.HeaderText.Split(',')[0];
                }

                newColumn = new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = column.DataPropertyName,
                    Width = column.Width,
                    Visible = column.Visible,
                    Frozen = column.Frozen
                };

                //if (column.GetType() == typeof(DataGridViewTextBoxColumn))
                newColumn.DefaultCellStyle = column.DefaultCellStyle;

                this.dgvShipmentsTotal.Columns.Add(newColumn);
            }

            this.dgvShipmentsTotal.Rows.Add(1);
            foreach (DataGridViewColumn column in this.dgvShipmentsTotal.Columns)
            {
                this.dgvShipmentsTotal.Rows[0].Cells[column.Index].Style.Font = new Font(this.dgvShipments.Font, FontStyle.Regular);
                this.dgvShipmentsTotal.Rows[0].Cells[column.Index].Style.ForeColor = Color.Black;
            }
        }


        private void LoadShipments()
        {
            try
            {
                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    try
                    {
                        var _lock = (bool?)null;
                        //this.tSP_Additional_Shipments_On_DateTableAdapter.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                        e.Result = this.tSP_Additional_Shipments_On_DateTableAdapter.GetData(this.UserID, this.ShipmentDate, ref _lock, this.CurrentFilial.FilialID);

                        this.IsReadOnly = _lock ?? false;
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
                    {
                        interbranch.TSP_Additional_Shipments_On_Date.Merge((Data.Interbranch.TSP_Additional_Shipments_On_DateDataTable)e.Result, true);
                        this.tSPAdditionalShipmentsOnDateBindingSource.DataSource = interbranch.TSP_Additional_Shipments_On_Date;

                        if (dgvShipments.Rows.Count > 0)
                            dgvShipments.Rows[0].Cells[0].Selected = false;
                    }

                    splashForm.CloseForce();
                };

                this.tSPAdditionalShipmentsOnDateBindingSource.DataSource = null;
                interbranch.TSP_Additional_Shipments_On_Date.Clear();

                splashForm.ActionText = "Выполняется загрузка данных по дополнительным объемам поставок..";

                loadWorker.RunWorkerAsync();

                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDeliveries_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                try
                {
                    dgvShipments.HorizontalScrollingOffset = e.NewValue;
                }
                catch (Exception ex)
                { }
            }
        }

        private void dgvShipments_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                try
                {
                    dgvDeliveries.HorizontalScrollingOffset = e.NewValue;
                    dgvShipmentsTotal.HorizontalScrollingOffset = e.NewValue;
                }
                catch (Exception ex)
                { }
            }
        }

        private void dgvShipmentsTotal_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                try
                {
                    dgvShipments.HorizontalScrollingOffset = e.NewValue;
                }
                catch (Exception ex)
                { }
            }
        }

        private void dgvShipments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.RecalcTotal();
        }

        private void dgvShipments_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (!this.dgvShipments.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
            //{
            //    this.dgvShipments.CurrentCell = this.dgvShipments.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //    this.dgvShipments.BeginEdit(true);
            //}
        }

        private void dgvShipments_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var shipment = (dgvShipments.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row as Data.Interbranch.TSP_Additional_Shipments_On_DateRow;
            var isEditableShipment = !shipment.IsLockNull() && shipment.Lock == 0;

            if (!isEditableShipment)
                this.dgvShipments.EndEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvShipments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            if (e.Exception != null)
            {
                if (e.Exception is FormatException)
                {
                    MessageBox.Show(string.Format("Значение поля \"{0} {1}\"\nдолжно быть числом.", dgvDeliveries.Columns[e.ColumnIndex].HeaderText, dgvShipments.Columns[e.ColumnIndex].HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void dgvShipments_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            this.RecalcTotal();
        }

        private void RecalcTotal()
        {
            try
            {
                if (dgvShipmentsTotal.Rows.Count == 0)
                    return;

                dgvShipmentsTotal.Rows[0].Cells[0].Value = "Итого";
                dgvShipmentsTotal.Rows[0].Cells[0].Selected = false;

                for (int i = 1; i < dgvShipments.Columns.Count; i++)
                {
                    var total = 0.0;
                    foreach (DataGridViewRow row in dgvShipments.Rows)
                    {
                        var shipment = (row.DataBoundItem as DataRowView).Row as Data.Interbranch.TSP_Additional_Shipments_On_DateRow;
                        var isShipmentInfo = !shipment.IsLockNull() && shipment.Lock == 2;

                        if (!isShipmentInfo)
                            total += (double)row.Cells[i].Value;
                    }

                    dgvShipmentsTotal.Rows[0].Cells[i].Value = total;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void DeliveryTransportPlanAdditionalShipmentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                //if (MessageBox.Show("После создания плана дополнительных объемов поставок\nего изменение будет невозможно. Продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                //    return false;

                var volumeDetails = this.CreateVolumeDetails();

                this.tSP_Additional_Shipments_On_DateTableAdapter.CreateAdditionalShipments(this.UserID, this.ShipmentDate, volumeDetails.InnerXml);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private XmlDocument CreateVolumeDetails()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml("<Volumes></Volumes>");
            XmlElement xRoot = xDoc.DocumentElement;

            foreach (DataGridViewRow row in dgvShipments.Rows)
            {
                var shipment = (row.DataBoundItem as DataRowView).Row as Data.Interbranch.TSP_Additional_Shipments_On_DateRow;

                if (shipment.RowState == DataRowState.Modified)
                {
                    var shipmentTypeID = shipment.Type_ID;

                    foreach (Data.Interbranch.TSP_DeliveriesRow delivery in interbranch.TSP_Deliveries.Rows)
                    {
                        var xElement = xDoc.CreateElement("Volume");

                        var deliveryID = delivery.Delivery_ID;

                        var volumeField = string.Format("{0}_AP", deliveryID);
                        var volume = shipment[volumeField] == DBNull.Value ? (double?)null : (double)shipment[volumeField];

                        var xValue = xElement.Attributes.Append(xDoc.CreateAttribute("type_id"));
                        xValue.Value = shipmentTypeID.ToString();

                        xValue = xElement.Attributes.Append(xDoc.CreateAttribute("delivery_id"));
                        xValue.Value = deliveryID.ToString();

                        if (volume != null)
                        {
                            xValue = xElement.Attributes.Append(xDoc.CreateAttribute("value"));
                            xValue.Value = volume.ToString();
                        }

                        xRoot.AppendChild(xElement);
                    }
                }
            }

            return xDoc;
        }

        private static readonly Color selectionBackColor = ColorTranslator.FromHtml("#fff5d5");
        private void dgvShipments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var shipment = (dgvShipments.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Interbranch.TSP_Additional_Shipments_On_DateRow;
            var lockState = shipment.IsLockNull() ? 0 : shipment.Lock;

            var foreColor = Color.Black;
            switch (lockState)
            {
                case 0:
                    foreColor = Color.Black;
                    break;
                case 1:
                    foreColor = Color.Gray;
                    break;
                case 2:
                    foreColor = Color.Brown;
                    break;
                default:
                    break;
            }

            e.CellStyle.ForeColor = foreColor;
            e.CellStyle.SelectionForeColor = foreColor;
            e.CellStyle.SelectionBackColor = selectionBackColor;

            if (e.Value.Equals(DBNull.Value))
            {
                e.CellStyle.BackColor = Color.LightPink;
                e.CellStyle.SelectionBackColor = Color.LightPink;
            }
        }
    }
}
