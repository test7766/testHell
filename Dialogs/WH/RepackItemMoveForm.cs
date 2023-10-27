using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class RepackItemMoveForm : Form
    {
        public string Description
        {
            get { return lblDescription.Text; }
            set { lblDescription.Text = value; }
        }

        public string Action
        {
            get { return lblAction.Text; }
            set { lblAction.Text = value; }
        }

        public string Caption
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        public ItemMoveContext Context { get; private set; }

        public RepackItemMoveForm()
        {
            InitializeComponent();
        }

        public RepackItemMoveForm(ItemMoveContext context)
            : this()
        {
            Context = context;
        }

        private void RepackItemMoveForm_Load(object sender, EventArgs e)
        {
            this.Text = Context.Caption;
            lblDescription.Text = Context.Description;
            lblAction.Text = Context.Action;

            tbScanner.TextChanged += new EventHandler(tbScanner_TextChanged);
        }

        void tbScanner_TextChanged(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void RepackItemMoveForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
                e.Cancel = !MoveItem();
        }

        private bool MoveItem()
        {
            try
            {
                Context.ExecuteAction(tbScanner.Text);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                tbScanner.Focus();
                tbScanner.SelectAll();
                return false;
            }
        }
    }

    public class ItemMoveContext
    {
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Action { get; set; }
        public long UserID { get; set; }
        public string WarehouseID { get; set; }
        public string LOCN { get; set; }
        public string StationID { get; set; }
        public string BarcodeYL { get; set; }

        public virtual bool ExecuteAction(object parameter) { return true; }
    }

    /// <summary>
    /// Перемещение излишков
    /// </summary>
    public class ItemMoveSurplusContext : ItemMoveContext
    {
        public string BoxBarCode { get; set; }
        public int PackInBox { get; set; }

        public override bool ExecuteAction(object parameter)
        {
            try
            {
                int? errorCode = null;
                string errorMessage = null;

                string LOCN_TO = parameter.ToString();

                using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                    adapter.RepackItemMoveSurplus(UserID, WarehouseID, StationID, LOCN, BarcodeYL, LOCN_TO, BoxBarCode, PackInBox, ref errorCode, ref errorMessage);

                if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return base.ExecuteAction(parameter);
        }
    }

    /// <summary>
    /// Перемещение недостачи
    /// </summary>
    public class ItemMoveShortageContext : ItemMoveContext
    {
        public int ReasonCode { get; set; }
        public int? ItemID_Fact { get; set; }
        public string VendorLot_Fact { get; set; }
        
        public override bool ExecuteAction(object parameter)
        {
            try
            {
                int? errorCode = null;
                string errorMessage = null;

                string LOCN_TO = parameter.ToString();

                using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                    adapter.RepackItemMoveShortage(UserID, WarehouseID, StationID, LOCN, BarcodeYL, ReasonCode, LOCN_TO, VendorLot_Fact, ItemID_Fact, ref errorCode, ref errorMessage);

                if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return base.ExecuteAction(parameter);
        }       
    }

    /// <summary>
    /// Перемещение остатка
    /// </summary>
    public class ItemMoveRemainsContext : ItemMoveContext
    {
        public int ReasonCode { get; set; }
        public int? ItemID_Fact { get; set; }
        public string VendorLot_Fact { get; set; }

        public override bool ExecuteAction(object parameter)
        {
            try
            {
                int? errorCode = null;
                string errorMessage = null;

                string LOCN_TO = parameter.ToString();

                using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                    adapter.RepackItemMoveShortage(UserID, WarehouseID, StationID, LOCN, BarcodeYL, ReasonCode, LOCN_TO, VendorLot_Fact, ItemID_Fact, ref errorCode, ref errorMessage);

                if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return base.ExecuteAction(parameter);
        }        
    }
}
