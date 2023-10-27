using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Docs
{
    public partial class FixedLocationsEditForm : DialogForm
    {
        private readonly Data.WH.FL_RowsRow _Item = null;

        private string _LocationID = null;

        private string LocationID
        {
            get
            {
                if (string.IsNullOrEmpty(tbLocation.Text))
                    throw new Exception("Местонахождение должно быть указано.");
                else
                    return tbLocation.Text;
            }
            set
            {
                tbLocation.Text = _LocationID = value;
            }
        }

        private int? QtyInTE
        {
            get 
            {
                if (string.IsNullOrEmpty(tbQtyInTE.Text))
                    return (int?)null;

                int pValue;
                if (int.TryParse(tbQtyInTE.Text, out pValue))
                    return pValue;
                else
                    throw new Exception("Кол-во в ТЕ должно быть числом.");
            }
            set 
            {
                tbQtyInTE.Text = value.ToString();
            }
        }

        private int? CountTE
        {
            get
            {
                if (string.IsNullOrEmpty(tbCountTE.Text))
                    return (int?)null;

                int pValue;
                if (int.TryParse(tbCountTE.Text, out pValue))
                    return pValue;
                else
                    throw new Exception("Кол-во ТЕ в месте должно быть числом.");
            }
            set
            {
                tbCountTE.Text = value.ToString();
            }
        }

        private int? ReplMaxQty
        {
            get
            {
                if (string.IsNullOrEmpty(tbReplMaxQty.Text))
                    return (int?)null;

                int pValue;
                if (int.TryParse(tbReplMaxQty.Text, out pValue))
                    return pValue;
                else
                    throw new Exception("Макс. кол-во пополнения должно быть числом.");
            }
            set
            {
                tbReplMaxQty.Text = value.ToString();
            }
        }

        private int? PointNorm
        {
            get
            {
                if (string.IsNullOrEmpty(tbPointNorm.Text))
                    return (int?)null;

                int pValue;
                if (int.TryParse(tbPointNorm.Text, out pValue))
                    return pValue;
                else
                    throw new Exception("Точка норм. пополнения должна быть числом.");
            }
            set
            {
                tbPointNorm.Text = value.ToString();
            }
        }

        private int? PointMin
        {
            get
            {
                if (string.IsNullOrEmpty(tbPointMin.Text))
                    return (int?)null;

                int pValue;
                if (int.TryParse(tbPointMin.Text, out pValue))
                    return pValue;
                else
                    throw new Exception("Точка мин. пополнения должна быть числом.");
            }
            set
            {
                tbPointMin.Text = value.ToString();
            }
        }

        public FixedLocationsEditForm()
        {
            InitializeComponent();            
        }

        public FixedLocationsEditForm(Data.WH.FL_RowsRow item)
            : this()
        {
            _Item = item;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(417, 8);
            this.btnCancel.Location = new Point(507, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            stbWarehouseID.ValueReferenceQuery = "[dbo].[pr_FL_Get_MCU_List]";
            stbWarehouseID.UserID = this.UserID;
            stbWarehouseID.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);
            stbWarehouseID.SetFirstValueByDefault();

            stbItemID.ValueReferenceQuery = "[dbo].[pr_FL_Get_Item_List]";
            stbItemID.UserID = this.UserID;
            stbItemID.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbUnitOfMeasure.ValueReferenceQuery = "[dbo].[pr_FL_Get_UOM_List]";
            stbUnitOfMeasure.UserID = this.UserID;
            stbUnitOfMeasure.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);
            stbUnitOfMeasure.SetFirstValueByDefault();

            if (_Item != null)
            {
                stbWarehouseID.SetValueByDefault(_Item.Warehouse_ID);
                stbWarehouseID.ReadOnly = true;
                stbWarehouseID.BackColor = SystemColors.Info;
                
                stbItemID.SetValueByDefault(_Item.Item_ID.ToString());
                stbItemID.ReadOnly = true;
                stbItemID.BackColor = SystemColors.Info;
                
                stbUnitOfMeasure.SetValueByDefault(_Item.UOM);
                stbUnitOfMeasure.ReadOnly = true;
                stbUnitOfMeasure.BackColor = SystemColors.Info;

                LocationID = _Item.IsLocationNull() ? (string)null : _Item.Location;

                QtyInTE = _Item.IsQtyInTENull() ? (int?)null : Convert.ToInt32(_Item.QtyInTE);
                CountTE = _Item.IsCountTENull() ? (int?)null : Convert.ToInt32(_Item.CountTE);
                ReplMaxQty = _Item.IsReplMaxQtyNull() ? (int?)null : Convert.ToInt32(_Item.ReplMaxQty);
                PointNorm = _Item.IsPointNormNull() ? (int?)null : Convert.ToInt32(_Item.PointNorm);
                PointMin = _Item.IsPointMinNull() ? (int?)null : Convert.ToInt32(_Item.PointMin);
            }
            else
            {
                this.Text = string.Format("*{0}", this.Text);
            }
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbWarehouseID)
                lblDescription = tbWarehouseName;
            else if (control == stbItemID)
                lblDescription = tbItemName;
            else if (control == stbUnitOfMeasure)
                lblDescription = tbUnitOfMeasure;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;
            }
        }

        private void FixedLocationsEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                var warehouseID = string.Empty;
                var itemID = 0;
                var uom = string.Empty;

                var old_location = _LocationID;
                var new_location = string.Empty;
                var qtyInTE = (int?)null;
                var replMaxQty = (int?)null;
                var pointNorm = (int?)null;
                var pointMin = (int?)null;

                if (!string.IsNullOrEmpty(stbWarehouseID.Value))
                    warehouseID = stbWarehouseID.Value;
                else
                    throw new Exception("Код склада должен быть указан.");

                if (string.IsNullOrEmpty(stbItemID.Value))
                    throw new Exception("Код товара должен быть указан.");
                if (!int.TryParse(stbItemID.Value, out itemID))
                    throw new Exception("Код товара должен быть числом.");

                if (!string.IsNullOrEmpty(stbUnitOfMeasure.Value))
                    uom = stbUnitOfMeasure.Value;
                else
                    throw new Exception("Единица измерения должна быть указана.");

                new_location = LocationID;

                qtyInTE = QtyInTE;
                replMaxQty = ReplMaxQty;
                pointNorm = PointNorm;
                pointMin = PointMin;

                if (string.IsNullOrEmpty(old_location))
                {
                    using (var adapter = new Data.WHTableAdapters.FL_RowsTableAdapter())
                        adapter.Add(this.UserID, warehouseID, itemID, uom, new_location, qtyInTE, replMaxQty, pointNorm, pointMin);
                }
                else
                {
                    using (var adapter = new Data.WHTableAdapters.FL_RowsTableAdapter())
                        adapter.Edit(this.UserID, warehouseID, itemID, uom, old_location, new_location, qtyInTE, replMaxQty, pointNorm, pointMin);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
