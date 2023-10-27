using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.ColdChain
{
    public partial class SensorBindingItemsSelector : Form
    {
        private static readonly int HORIZONTAL_INDENT = 15;
        private BaseBindingItemsAdapter bindingItemsAdapter;

        #region Вспомогательный класс для генерации события добавления элементов привязки
        public delegate void AddBindingItemEventHandler(object sender, AddBindingItemEventArgs e);
        public event AddBindingItemEventHandler OnAddingBindingItem;
        public class AddBindingItemEventArgs : EventArgs
        {
            public DataRow ItemRow { get; private set; }
            public BindingItemsType BindingItemType { get; private set; }

            public AddBindingItemEventArgs(BindingItemsType bindingItemType, DataRow itemRow)
            {
                this.BindingItemType = bindingItemType;
                this.ItemRow = itemRow;
            }
        }
        #endregion

        /// <summary>
        /// Текущий тип элементов справочника привязки 
        /// </summary>
        public BindingItemsType BindingItemsType { get; private set; }

        public SensorBindingItemsSelector(BindingItemsType bindingItemsType)
        {
            InitializeComponent();
            this.BindingItemsType = bindingItemsType;
            this.bindingItemsAdapter = BaseBindingItemsAdapter.CreateBindingItemsAdapter(this.BindingItemsType);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.bindingItemsAdapter.CurrentData = (this.Owner as EquipmentSensorsBindingEditor).Manager.CurrentData;
            this.Location = new Point(this.Owner.Location.X + this.Owner.Width + HORIZONTAL_INDENT, this.Owner.Location.Y);

            this.bindingItemsAdapter.AdaptSourceToGrid(this.dgvBindingItems);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Text = this.bindingItemsAdapter.Caption;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            this.AddItem();
        }

        private void dgvBindingItems_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
                this.AddItem();
        }

        private void AddItem()
        {
            if (this.OnAddingBindingItem != null && dgvBindingItems.SelectedRows.Count > 0)
            {
                this.OnAddingBindingItem(this, new AddBindingItemEventArgs(this.BindingItemsType, (dgvBindingItems.SelectedRows[0].DataBoundItem as DataRowView).Row));

                // если текущая привязка - оборудование, то закрываем форму после добавления первого элемента!!!!
                if (this.BindingItemsType == BindingItemsType.Equipment)
                    this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
