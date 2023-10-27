using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.D3
{
    /// <summary>
    /// Форма создания/редактирования карты (последовательности) маршрутов
    /// </summary>
    public partial class RoutePlanEditForm : DialogForm
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public RoutePlanEditForm()
        {
            InitializeComponent();
            cbType.SelectedIndex = 0;
        }

        /// <summary>
        /// Название карты маршрутов
        /// </summary>
        public string RoutePlanName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }

        /// <summary>
        /// Идентификатор филиала
        /// </summary>
        public string WarehouseID { get; set; }

        /// <summary>
        /// Идентификатор плана маршрутов
        /// </summary>
        public int RoutePlanID { get; set; }

        /// <summary>
        /// Тип плана маршрутов
        /// R - размещение
        /// S - сборка 
        /// P - пополнение 
        /// </summary>
        public string RoutePlanType
        {
            get { return cbType.Text.Substring(0, 1); }
            set
            {
                foreach (string item in cbType.Items)
                {
                    if (item.Substring(0, 1) == value)
                    {
                        cbType.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Обработчик события загрузки формы
        /// </summary>
        private void RoutePlanEditForm_Load(object sender, EventArgs e)
        {
            // обновление данных
            routesTableAdapter.Fill(d3.Routes, WarehouseID);
            routesSequenceTableAdapter.Fill(d3.RoutesSequence, RoutePlanID);

            foreach (WMSOffice.Data.D3.RoutesRow route in d3.Routes)
            {
                Data.D3.RoutesSequenceRow seqRow = d3.RoutesSequence.FindByRoute_ID(route.Route_ID);
                if (seqRow == null)
                    lbRoutes.Items.Add(new ListBoxItem(route.Route_ID, route.Route_Name));
            }
            foreach (WMSOffice.Data.D3.RoutesSequenceRow route in d3.RoutesSequence)
            {
                lbSelRoutes.Items.Add(new ListBoxItem(route.Route_ID, route.Route_Name));
            }
        }

        private class ListBoxItem
        {
            public ListBoxItem(int id, string name)
            {
                ID = id;
                Name = name;
            }
            public int ID { get; set; }
            public string Name { get; set; }
            public new string ToString() { return Name; }
        }

        private void RoutePlanEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                // проверяем параметры
                if (String.IsNullOrEmpty(tbName.Text))
                {
                    MessageBox.Show("Название карты маршрутов является обязательным полем!","Ошибка ввода",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

                if (RoutePlanID == 0)
                {
                    // добавление карты маршрутов
                    using (Data.D3TableAdapters.RoutePlansTableAdapter adapter = new WMSOffice.Data.D3TableAdapters.RoutePlansTableAdapter())
                    {
                        Data.D3.RoutePlansDataTable newPlanRows = adapter.Create(RoutePlanName, RoutePlanType, WarehouseID);
                        if (newPlanRows != null && newPlanRows.Count == 1)
                        {
                            RoutePlanID = newPlanRows[0].Route_Plan_ID;
                            for (int i = 0; i < lbSelRoutes.Items.Count; i++)
                            {
                                routesSequenceTableAdapter.AddRoute(RoutePlanID, ((ListBoxItem)lbSelRoutes.Items[i]).ID, i + 1);
                            }
                        }
                        else
                            MessageBox.Show("Не удалось создать новую карту маршрутов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // обновление карты маршрутов
                    using (Data.D3TableAdapters.RoutePlansTableAdapter adapter = new WMSOffice.Data.D3TableAdapters.RoutePlansTableAdapter())
                    {
                        adapter.Update(RoutePlanID, RoutePlanName, RoutePlanType);
                    }
                    foreach (WMSOffice.Data.D3.RoutesSequenceRow route in d3.RoutesSequence)
                    {
                        routesSequenceTableAdapter.Delete(route.Route_Sequence_ID);
                    }
                    for (int i = 0; i < lbSelRoutes.Items.Count; i++)
                    {
                        routesSequenceTableAdapter.AddRoute(RoutePlanID, ((ListBoxItem)lbSelRoutes.Items[i]).ID, i + 1);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lbRoutes.SelectedItem != null)
            {
                ListBoxItem lbi = (ListBoxItem)lbRoutes.SelectedItem;
                lbRoutes.SelectedIndex = -1;
                lbRoutes.Items.Remove(lbi);
                lbSelRoutes.Items.Add(lbi);
                lbSelRoutes.SelectedItem = lbi;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lbSelRoutes.SelectedItem != null)
            {
                ListBoxItem lbi = (ListBoxItem)lbSelRoutes.SelectedItem;
                lbSelRoutes.SelectedIndex = -1;
                lbSelRoutes.Items.Remove(lbi);
                lbRoutes.Items.Add(lbi);
                lbRoutes.SelectedItem = lbi;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lbSelRoutes.SelectedItem != null)
            {
                int ind = lbSelRoutes.SelectedIndex;
                ListBoxItem lbi = (ListBoxItem)lbSelRoutes.SelectedItem;
                lbSelRoutes.Items.Remove(lbi);
                lbSelRoutes.Items.Insert(ind - 1, lbi);
                lbSelRoutes.SelectedItem = lbi;
            }            
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (lbSelRoutes.SelectedItem != null)
            {
                int ind = lbSelRoutes.SelectedIndex;
                ListBoxItem lbi = (ListBoxItem)lbSelRoutes.SelectedItem;
                lbSelRoutes.Items.Remove(lbi);
                lbSelRoutes.Items.Insert(ind + 1, lbi);
                lbSelRoutes.SelectedItem = lbi;
            }
        }

        private void lbRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = (lbRoutes.SelectedItem != null);
        }

        private void lbSelRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDel.Enabled = (lbSelRoutes.SelectedItem != null);
            btnUp.Enabled = btnDel.Enabled && (lbSelRoutes.SelectedIndex > 0);
            btnDown.Enabled = btnDel.Enabled && (lbSelRoutes.SelectedIndex < lbSelRoutes.Items.Count - 1);
        }

        private void lbRoutes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnAdd_Click(sender, e);
        }

        private void lbSelRoutes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnDel_Click(sender, e);
        }
        
    }
}
