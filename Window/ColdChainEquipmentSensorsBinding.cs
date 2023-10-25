using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.ColdChain;

namespace WMSOffice.Window
{
    public partial class ColdChainEquipmentSensorsBinding : GeneralWindow
    {
        private ColdChainEquipmentSensorsBindingManager manager = null;
        
        public ColdChainEquipmentSensorsBinding(ColdChainEquipmentSensorsBindingManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        private void ColdChainEquipmentSensorsBinding_Load(object sender, EventArgs e)
        {
            this.branchesBindingSource.CurrentItemChanged += new EventHandler(branchesBindingSource_CurrentItemChanged);
            this.relatedEquipmentBindingSource.CurrentItemChanged += new EventHandler(relatedEquipmentBindingSource_CurrentItemChanged);
            this.relatedSensorsBindingSource.CurrentItemChanged += new EventHandler(relatedSensorsBindingSource_CurrentItemChanged);

           // RefreshBranches();
            RefreshData();
        }

        private void branchesBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (this.AreBranchesExists())
            {
                manager.CurrentData.BranchID = (((DataRowView)(branchesBindingSource.CurrencyManager.Current)).Row as Data.ColdChain.BranchesRow).Warehouse_ID;
                this.SetFilterByBranch();
            }
        }

        private void relatedEquipmentBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            bool equipmentExists = this.AreEquipmentExists();

            if (equipmentExists)
            {
                manager.CurrentData.EquipmentID = (((DataRowView)(relatedEquipmentBindingSource.CurrencyManager.Current)).Row as Data.ColdChain.RelatedEquipmentRow).Equipment_ID;
                this.RefreshSensors();
            }

            sbModifySensorsToEquipmentBinding.Enabled = equipmentExists;
        }

        private void relatedSensorsBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (this.AreSensorsExists())
            {
                manager.CurrentData.SensorID = (((DataRowView)(relatedSensorsBindingSource.CurrencyManager.Current)).Row as Data.ColdChain.RelatedSensorsRow).Sensor_ID;
                this.RefreshPlatforms();
            }
        }

        /// <summary>
        /// Обновление справочника филиалов и списка оборудования
        /// </summary>
        private void RefreshData()
        {
            RefreshBranches();
            //this.manager.CurrentData.EquipmentID = this.manager.CurrentData.SensorID = -1;
            RefreshEquipment();
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void RefreshBranches()
        {
            try
            {
                this.branchesBindingSource.DataSource = null;
                this.branchesBindingSource.DataSource = this.branchesTableAdapter.GetDataByPermission(manager.UserID);
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления справочника филиалов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновление списка холодильного оборудования
        /// </summary>
        private void RefreshEquipment()
        {
            try
            {
                this.relatedPlatformsBindingSource.DataSource = null;
                this.relatedSensorsBindingSource.DataSource = null;
                this.relatedEquipmentBindingSource.DataSource = null;
                this.relatedEquipmentBindingSource.DataSource = this.relatedEquipmentTableAdapter.GetData(manager.UserID);
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления списка холодильного оборудования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Установка локального фильтра для оборудования по филиалу
        /// </summary>
        private void SetFilterByBranch()
        {
            this.relatedPlatformsBindingSource.DataSource = null;
            this.relatedSensorsBindingSource.DataSource = null;
            this.relatedEquipmentBindingSource.Filter = string.Format("{0} = '{1}'", this.coldChain.RelatedEquipment.BranchColumn.Caption, manager.CurrentData.BranchID);
        }
      
        /// <summary>
        /// Обновление списка датчиков температуры
        /// </summary>
        private void RefreshSensors()
        {
            try
            {
                this.relatedPlatformsBindingSource.DataSource = null;
                this.relatedSensorsBindingSource.DataSource = null;
                this.relatedSensorsBindingSource.DataSource = this.relatedSensorsTableAdapter.GetData(manager.CurrentData.EquipmentID);
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления списка датчиков температур", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновление списка перронов
        /// </summary>
        private void RefreshPlatforms()
        {
            try
            {
                this.relatedPlatformsBindingSource.DataSource = null;
                this.relatedPlatformsBindingSource.DataSource = this.relatedPlatformsTableAdapter.GetData(manager.CurrentData.SensorID);
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления списка перронов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод возвращает признак наличия списка оборудования
        /// </summary>
        /// <returns></returns>
        private bool AreEquipmentExists()
        {
            return this.relatedEquipmentBindingSource.CurrencyManager.Count > 0;
        }

        /// <summary>
        /// Метод возвращает признак наличия списка датчиков температуры
        /// </summary>
        /// <returns></returns>
        private bool AreSensorsExists()
        {
            return this.relatedSensorsBindingSource.CurrencyManager.Count > 0;
        }

        /// <summary>
        /// Метод возвращает признак наличия списка филиалов
        /// </summary>
        /// <returns></returns>
        private bool AreBranchesExists()
        { 
           return this.branchesBindingSource.CurrencyManager.Count > 0;
        }

        private void sbModifySensorsToEquipmentBinding_Click(object sender, EventArgs e)
        {
            this.OpenEquipmentBindingsEditor((this.relatedEquipmentBindingSource.CurrencyManager.Current as DataRowView).Row);
        }

        private void sbCreateSensorsToEquipmentBinding_Click(object sender, EventArgs e)
        {
            this.OpenEquipmentBindingsEditor(null);
        }

        private void OpenEquipmentBindingsEditor(DataRow equipmentSource)
        {
            EquipmentSensorsBindingEditor bindingEditor = new EquipmentSensorsBindingEditor(this.manager, equipmentSource);
            bindingEditor.ShowDialog();

            this.RefreshData();
        }
    }
}