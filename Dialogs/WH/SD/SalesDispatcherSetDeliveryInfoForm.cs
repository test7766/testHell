using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH.SD
{
    public partial class SalesDispatcherSetDeliveryInfoForm : DialogForm
    {
        private const int BLANK_ROUTE_POINT_ID = -1;

        /// <summary>
        /// Код сессии
        /// </summary>
        public new long UserID { get; set; }

        /// <summary>
        /// Компания
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Тип документа
        /// </summary>
        public string DocType { get; set; }

        /// <summary>
        /// Номер документа
        /// </summary>
        public long DocNumber { get; set; }

        /// <summary>
        /// Номер сборочного
        /// </summary>
        public long PickSlipNumber { get; set; }

        /// <summary>
        /// Код точки доставки
        /// </summary>
        public int? RoutePointID { get; set; }

        public SalesDispatcherSetDeliveryInfoForm()
        {
            InitializeComponent();
        }

        public SalesDispatcherSetDeliveryInfoForm(long userID, string company, string docType, long docNumber, long psn, int? routePointID)
            : this()
        {
            this.UserID = userID;
            this.Company = company;
            this.DocType = docType;
            this.DocNumber = docNumber;
            this.PickSlipNumber = psn;
            this.RoutePointID = routePointID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.btnOK.Location = new Point(547, 8);
            this.btnCancel.Location = new Point(637, 8);
        }

        private void Initialize()
        {
            this.LoadRoutePoints();
        }

        private void LoadRoutePoints()
        {
            try
            {
                dP_VR_DeliveryInfoTableAdapter.Fill(wH.DP_VR_DeliveryInfo, this.UserID);
                
                wH.DP_VR_DeliveryInfo.Rows.InsertAt(this.CreateBlankRow(), 0);
                cmbRoutePoints.SelectedValue = this.RoutePointID ?? BLANK_ROUTE_POINT_ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Data.WH.DP_VR_DeliveryInfoRow CreateBlankRow()
        {
            var blankRow = wH.DP_VR_DeliveryInfo.NewDP_VR_DeliveryInfoRow();
            blankRow.route_point_id = BLANK_ROUTE_POINT_ID;
            blankRow.route_point_name = "(не выбран)";

            return blankRow;
        }

        private void SalesDispatcherSetDeliverySettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                if (cmbRoutePoints.SelectedValue == null || cmbRoutePoints.SelectedValue.Equals(BLANK_ROUTE_POINT_ID))
                    throw new Exception("Не выбран адрес доставки.");

                this.RoutePointID = (int)cmbRoutePoints.SelectedValue;

                dP_VR_DeliveryInfoTableAdapter.SetDeliveryInfo(this.UserID, this.Company, this.DocType, this.DocNumber, this.PickSlipNumber, this.RoutePointID);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void cmbRoutePoints_DropDown(object sender, EventArgs e)
        {
            try
            {
                var size = cmbRoutePoints.GetMaxDropDownSize();

                cmbRoutePoints.DropDownWidth = size.Width > 0 ? size.Width : cmbRoutePoints.DropDownWidth;
                cmbRoutePoints.DropDownHeight = size.Height > 0 ? size.Height : cmbRoutePoints.DropDownHeight;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
