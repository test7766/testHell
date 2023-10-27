using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Admin.Database;
using WMSOffice.Data;
using WMSOffice.Data.AdminTableAdapters;

namespace WMSOffice.Dialogs.Admin
{
    public partial class EntityWizardForm : WizardBlankForm
    {
        public EntityWizardForm(List<string> limitationList, string entity_ID, string entity_Name, string entityElements_StoredProcedure)
        {
            InitializeComponent();

            this.CanResize = true;

            EntityID = entity_ID;
            EntityName = entity_Name;            
            tbEntityID.ReadOnly = string.IsNullOrEmpty(EntityID) ? false : true;
            LimitationList = limitationList;

            LoadPossibleLimitations();
            EntityCanBeLimited = LimitationsToIntByBitMask();

            if (string.IsNullOrEmpty(entityElements_StoredProcedure))
                rbElements.Checked = true;
            else
                rbProcedure.Checked = true;

            
            LoadStoredProcedures();
            EntityElementsStoredProcedure = entityElements_StoredProcedure;

            this.Text = (string.IsNullOrEmpty(entityID)) ? "Создание сущности" : "Редактирование сущности";

            // Теперь разрешаем Bind() данных в контроле. Т.к. на этапе инициализации он вызывается несколько раз без надобности.
            AttributesTwoListControl.CanBind = true;
        }

        #region properties

        public List<string> LimitationList { get; private set; }

        private string entityID = string.Empty;
        public string EntityID
        {
            get { return tbEntityID.Text; }
            set { tbEntityID.Text = entityID = value; }
        }

        private string entityName;
        public string EntityName
        {
            get { return tbEntityName.Text; }
            set { tbEntityName.Text = entityName = value; }
        }

        private string entityElementsStoredProcedure;
        public string EntityElementsStoredProcedure
        {
            get { return  (string)cbEntityElementsProc.SelectedItem; }
            set
            {
                if (!string.IsNullOrEmpty(value) && cbEntityElementsProc.Items.IndexOf(value) == -1)
                    cbEntityElementsProc.Items.Add(value);
                cbEntityElementsProc.SelectedItem = entityElementsStoredProcedure = value;
            }
        }
        
        private int entityCanBeLimited;
        public int EntityCanBeLimited
        {
            get { return LimitationsToIntByBitMask(); }
            set { entityCanBeLimited = value; }
        }

        /// <summary>Признак изменения свойст сущности</summary>
        private bool IsEntityPropertiesChanged
        {
            get
            {
                return (tbEntityID.Text != entityID) ||
                       (tbEntityName.Text != entityName) ||
                       (LimitationsToIntByBitMask() != entityCanBeLimited);
            }
        }

        /// <summary>Признак изменения процедуры получения элементов сущности</summary>
        private bool IsEntityElementsProcedureChanged
        {
            get { return (EntityElementsStoredProcedure != entityElementsStoredProcedure); }
        }

        /// <summary>Признак возврата на предыдущую страницу (при ошибке например)</summary>
        private bool MovePageBack { get; set; }

        /// <summary>Таблица возможных ограничений сущностей</summary>
        Data.Admin.EntityPossibleLimitationsDataTable tableEntityLimitations = null;

        /// <summary>Таблица элементов сущности</summary>
        Data.Admin.EntityElementsDataTable tableEntityElements = null;

        #endregion

        #region EventHandlers
        
        private void wizard_Next(object sender, UtilityLibrary.Wizards.WizardForm.EventNextArgs e)
        {
            ApplyChanges(e.CurrentPage.Name);
        }

        /// <summary>Активация/деактивация панели ввода/редактирования/удаления элементов сущности</summary>
        private void rbProcedure_CheckedChanged(object sender, EventArgs e)
        {
            gbProcedure.Enabled = gvElements.ReadOnly = rbProcedure.Checked;

            if (rbProcedure.Checked)
            {
                if (gvElements.Rows.Count > 1)
                {// если есть строки, тогда предупреждаем что можно потерять данные
                    if (MessageBox.Show("Существующие элементы будут удалены!\nВы уверены что хотите изменить на процедуру", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        gvElements.DataSource = null;
                        gvElements.Rows.Clear();
                        gvElements.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight;
                    }
                    else
                    {// отменяем пееход к выбору процедуры
                        rbElements.CheckedChanged -= new System.EventHandler(this.rbElements_CheckedChanged);
                        rbElements.Checked = true;
                        rbElements.CheckedChanged += new System.EventHandler(this.rbElements_CheckedChanged);
                    }
                }
                else
                {// если тсрок нету, тогда просто переходим к процедуре
                    gvElements.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight;
                }
            }
        }

        /// <summary>Активация/деактивация панели ввода/редактирования/удаления элементов сущности</summary>
        private void rbElements_CheckedChanged(object sender, EventArgs e)
        {
            gbProcedure.Enabled = gvElements.ReadOnly = rbProcedure.Checked;

            if (rbElements.Checked)
            {
                cbEntityElementsProc.SelectedItem = null;

                using (EntityElementsTableAdapter adapter = new EntityElementsTableAdapter())
                {
                    tableEntityElements = adapter.GetData(EntityID);
                    gvElements.DataSource = tableEntityElements;
                    gvElements.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
                }
            }
        }

        /// <summary>Изменение хранимой процедуры для элементов сущности</summary>
        private void cbEntityElementsProc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((string)cbEntityElementsProc.SelectedItem))
            {// если процедура указана, то загрузить список элементов сущности из процедуры
                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString);

                    SqlCommand sqlCommand = new SqlCommand(cbEntityElementsProc.SelectedItem.ToString(), conn);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = sqlCommand;
                    conn.Open();
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds);
                    if (gvElements.Rows.Count > 0)
                    {
                        gvElements.DataSource = null;
                        gvElements.Rows.Clear();
                    }
                    gvElements.DataSource = ds.Tables[0];
                    gvElements.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                }
            }
        }

        /// <summary>
        /// Меняет видимость кнопки "Готово"
        /// </summary>
        private void wizard_PageShown(object sender, UtilityLibrary.Wizards.WizardForm.EventNextArgs e)
        {
            wizard.btnCancel.Visible = (e.CurrentPage.Name != wizardFinalPage.Name);
            if (MovePageBack && wizard.PageIndex > 0)
            {
                wizard.MoveBackStep();
                MovePageBack = false;
            }
        }

        private void wizard_WizardClosed(object sender, EventArgs e)
        {
            Close();
        }

        private bool AttributesTwoListControl_OnAddItem(object sender, ListView.SelectedListViewItemCollection e)
        {
            try
            {
                foreach (ListViewItem item in e)
                    Database.Actions.EntityAttributeInsert(EntityID, item.Name);
            }
            catch (Exception) { return false; }
            return true;
        }

        private bool AttributesTwoListControl_OnDeleteItem(object sender, ListView.SelectedListViewItemCollection e)
        {
            try
            {
                foreach (ListViewItem item in e)
                    Database.Actions.EntityAttributeDelete(EntityID, item.Name);
            }
            catch (Exception) { return false; }
            return true;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Загрузка в таблицу возможных ограничений сущности
        /// </summary>
        private void LoadPossibleLimitations()
        {
            using (EntityPossibleLimitationsTableAdapter adapter = new EntityPossibleLimitationsTableAdapter())
            {
                tableEntityLimitations = adapter.GetData(EntityID);

                if (tableEntityLimitations != null && tableEntityLimitations.Count > 0)
                    foreach (Data.Admin.EntityPossibleLimitationsRow row in tableEntityLimitations.Rows)
                        clbLimitations.Items.Add(row.Limitation_Name, row.Limited);
            }
        }

        /// <summary>
        /// Загрузка в таблицу comboBox списка хранимых процедур для определения элементов сущностей
        /// </summary>
        private void LoadStoredProcedures()
        {
            using (EntityElementsStoredProceduresTableAdapter adapter = new EntityElementsStoredProceduresTableAdapter())
            {
                Data.Admin.EntityElementsStoredProceduresDataTable table = adapter.GetData();
                if (table != null && table.Count > 0)
                    foreach(Data.Admin.EntityElementsStoredProceduresRow row in table.Rows)
                        cbEntityElementsProc.Items.Add(row.StoredProcedure);
            }
        }

        /// <summary>
        /// Формирует целое число на основе битовой маски ограничений
        /// </summary>
        /// <returns>Число</returns>
        private int LimitationsToIntByBitMask()
        {
            int result = 0;

            foreach (string name in clbLimitations.CheckedItems)
            {
                Data.Admin.EntityPossibleLimitationsRow row = (Data.Admin.EntityPossibleLimitationsRow)(tableEntityLimitations.Select(string.Format("{0} = '{1}'", tableEntityLimitations.Limitation_NameColumn.ColumnName, name))[0]);
                result += (int)row.ID;
            }

            return result;
        }

        /// <summary>Применение изменений при переходе на следующую страницу мастера</summary>
        /// <param name="pageName">Название страницы</param>
        private void ApplyChanges(string pageName)
        {
            try
            {
                switch (pageName)
                {
                    case "wizardPageEntityProperties":
                        // создаем/обновляем данные
                        if (string.IsNullOrEmpty(entityID))
                        {
                            if (!string.IsNullOrEmpty(tbEntityID.Text))
                            {
                                // добавляем сущность                        
                                Database.Actions.EntityInsert(EntityID, EntityName, null, LimitationsToIntByBitMask()).ToString();
                                EntityID = tbEntityID.Text;
                                EntityName = tbEntityName.Text;
                            }
                            else
                                throw new Exception("ID сущности не задано!");
                        }
                        else if (IsEntityPropertiesChanged)
                        {
                            // изменяем сущность
                            Database.Actions.EntityUpdate(EntityID, EntityName, EntityElementsStoredProcedure, LimitationsToIntByBitMask(), entityID);
                            EntityID = tbEntityID.Text;
                            EntityName = tbEntityName.Text;
                            EntityCanBeLimited = LimitationsToIntByBitMask();
                        }
                        // отображаем название сущности в заголовке
                        this.Text = String.Format("Сущность - {0}", EntityName);
                        AttributesTwoListControl.SelectedListParamValue = EntityID;
                        break;
                    case "wizardPageEntityElements":
                        Database.Actions.EntityElementsDelete(EntityID);

                        if (rbProcedure.Checked && IsEntityElementsProcedureChanged)
                        {
                            Database.Actions.EntityUpdate(EntityID, EntityName, EntityElementsStoredProcedure, LimitationsToIntByBitMask(), entityID);
                            entityElementsStoredProcedure = (string)cbEntityElementsProc.SelectedItem;
                        }
                        else if (rbElements.Checked)
                        {
                            if (IsEntityElementsProcedureChanged)
                            {
                                Database.Actions.EntityUpdate(EntityID, EntityName, null, LimitationsToIntByBitMask(), entityID);
                                entityElementsStoredProcedure = EntityElementsStoredProcedure;
                            }

                            foreach (Data.Admin.EntityElementsRow row in tableEntityElements.Rows)
                            {
                                Database.Actions.EntityElementsInsert(row.ID, row.Название, EntityID);
                            }
                        }
                        break;
                    case "wizardPageEntityAttributes":
                        using (EntityLimitationsSetTableAdapter adapter = new EntityLimitationsSetTableAdapter())
                        {
                            Data.Admin.EntityLimitationsSetDataTable tableEntityLimitationsSet = adapter.GetData(EntityID);
                            entityLimitationsSetBindingSource.DataSource = tableEntityLimitationsSet;
                        }
                        break;
                    case "wizardPageEntityLimitations":
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MovePageBack = true;
            }
        }

        #endregion


    }
}
