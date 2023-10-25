using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data;
using WMSOffice.Data.AdminTableAdapters;
using WMSOffice.Dialogs.Admin;
using Optima.Devices.Configuration;

namespace WMSOffice.Window
{
    public partial class AdminWindow : GeneralWindow
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public AdminWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка формы (AdminWindow)
        /// Выполняется начальная загрузка данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminWindow_Load(object sender, EventArgs e)
        {
            EntityElementsList funcs = GetLimitedElements("res_WA_funcs");

            LimitationList = funcs;

            if (funcs.Contains("settings"))
                this.wMS_SettingTableAdapter.Fill(this.admin.WMS_Setting);
            else
                tabControl.TabPages.Remove(tabPageSettings);

            if (funcs.Contains("access")) 
                RefreshAllAccessData();
            else
                tabControl.TabPages.Remove(tabPageAccess);

            if (funcs.Contains("print"))
                RefreshPCPrinterSettings();
            else
                tabControl.TabPages.Remove(tabPagePCPrinters);

            if (funcs.Contains("user"))
                bUsers.Enabled = true;

            if (funcs.Contains("role"))
                bRoles.Enabled = true;

            if (funcs.Contains("resource"))
                bResources.Enabled = true;

            if (funcs.Contains("entity"))
                bEntities.Enabled = true;

            if (funcs.Contains("quiz"))
                bQuiz.Enabled = true;

            if (funcs.Contains("device"))
                bDeviceConfigurationSettings.Enabled = true;

            if (funcs.Contains("upgrade"))
                bUpgradeControl.Enabled = true;
        }

        #region Access

        /// <summary>
        /// Обновление данных о модулях, типах документов и сотрудниках
        /// </summary>
        private void RefreshAllAccessData()
        {
            // загрузка данных о типах документов
            this.wH_Docs_TypeTableAdapter.Fill(this.admin.WH_Docs_Type);
            // заполнение списка модулей
            lvModules.Items.Clear();
            foreach (Data.Admin.WH_Docs_TypeRow docTypeRow in this.admin.WH_Docs_Type.Rows)
                if (!lvModules.Items.ContainsKey(docTypeRow.Module_id))
                    lvModules.Items.Add(docTypeRow.Module_id, docTypeRow.Module_id, -1);

            // загрузка списка сотрудников
            this.employeesTableAdapter.Fill(this.admin.Employees);

            // загрузка всего списка доступов
            RefreshAccess();
            //_allowRefreshAccess = true;
            //RefreshAccess(FilterType.None, null);
        }

        /// <summary>
        /// Загрузка всего списка доступов
        /// </summary>
        private void RefreshAccess()
        {
            // загрузка всего списка доступов
            this.accessTableAdapter.Fill(this.admin.Access);
        }

        /// <summary>
        /// Фильтрация списка доступов по выбранному типу документа WMS
        /// </summary>
        private void FilterAccess()
        {
            // изменение фильтра в правильном порядке - разрешаем добавление/сохранение
            toolStripAccess.Enabled = true;
            colAccessModule.Visible = colAccessDocTypeID.Visible = colAccessDocTypeName.Visible = false;

            // установка фильтра
            Data.Admin.WH_Docs_TypeRow selectedDocType = 
                (gvDocTypes.SelectedRows.Count == 1)
                ? (Data.Admin.WH_Docs_TypeRow)((DataRowView)gvDocTypes.SelectedRows[0].DataBoundItem).Row 
                : null;
            this.accessBindingSource.Filter = (selectedDocType != null) ? String.Format("Doc_Type = '{0}'", selectedDocType.Doc_Type_ID) : "";
        }

        /// <summary>
        /// Фильтрация списка сотрудников
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSearchEmployee_TextChanged(object sender, EventArgs e)
        {
            employeesBindingSource.Filter = (String.IsNullOrEmpty(tbSearchEmployee.Text))
                                                ? ""
                                                : String.Format("Employee like '%{0}%'", tbSearchEmployee.Text);
            tbSearchEmployee.BackColor = (String.IsNullOrEmpty(tbSearchEmployee.Text))
                                             ? Color.White
                                             : Color.Yellow;
        }

        /// <summary>
        /// Выбор модуля, фильтрация типов документов WMS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            wHDocsTypeBindingSource.Filter = lvModules.SelectedItems.Count != 1 
                ? "" 
                : String.Format("Module_id = '{0}'", lvModules.SelectedItems[0].Text);
        }

        /// <summary>
        /// Выбор типа документа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvDocTypes_SelectionChanged(object sender, EventArgs e)
        {
            FilterAccess();
        }

        /// <summary>
        /// Выбор сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            // уже не делаем ничего... только по двойному клику установим фильтр
        }

        /// <summary>
        /// Двойной клик на сотруднике установит фильтр: "доступы для этого сотрудника"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvEmployees_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // фильтруем по пользователю - запрещаем добавление/сохранение
                toolStripAccess.Enabled = false;
                colAccessModule.Visible = colAccessDocTypeID.Visible = colAccessDocTypeName.Visible = true;

                // установка фильтра
                Data.Admin.EmployeesRow selectedEmployee = (Data.Admin.EmployeesRow)((DataRowView)gvEmployees.Rows[e.RowIndex].DataBoundItem).Row;
                this.accessBindingSource.Filter = (selectedEmployee != null) ? String.Format("Employee_ID = '{0}'", selectedEmployee.Employee_ID) : "";
            }
        }

        /// <summary>
        /// Метод добавления доступа выбранного пользователя к выбранному типу ресурса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccessAdd_Click(object sender, EventArgs e)
        {
            if (gvEmployees.SelectedRows.Count == 1 && gvDocTypes.SelectedRows.Count == 1)
            {
                Data.Admin.WH_Docs_TypeRow selectedDocType = (Data.Admin.WH_Docs_TypeRow)((DataRowView)gvDocTypes.SelectedRows[0].DataBoundItem).Row;
                Data.Admin.EmployeesRow selectedEmployee = (Data.Admin.EmployeesRow)((DataRowView)gvEmployees.SelectedRows[0].DataBoundItem).Row;

                // Добавление записи
                if (MessageBox.Show(String.Format("Добавить доступ сотруднику {0} к типу документа {1}?", selectedEmployee.Employee, selectedDocType.Doc_Type_Name), 
                    "Добавить доступ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.admin.Access.AddAccessRow(selectedEmployee.Employee_ID,
                        true, selectedDocType.Module_id, selectedDocType.Doc_Type_ID, null, null,
                        selectedEmployee.Employee, selectedDocType.Module_id, selectedDocType.Doc_Type_Name);
                }
            }
        }

        /// <summary>
        /// Метод сохранения изменений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccessSave_Click(object sender, EventArgs e)
        {
            // сохранение изменений
            this.accessTableAdapter.Update(this.admin.Access);
        }

        /// <summary>
        /// Метод обновления данных о правах доступа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miAccessRefresh_Click(object sender, EventArgs e)
        {
            RefreshAccess();
        }

        #endregion

        #region PC printer settings

        /// <summary>
        /// Обновление данных о настройках принтеров для печати этикеток
        /// </summary>
        private void RefreshPCPrinterSettings()
        {
            this.pC_Printer_SettingTableAdapter.Fill(this.admin.PC_Printer_Setting);
        }

        /// <summary>
        /// Изменение фильтра - поиск логина/идентификатора принтера по части наименования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPCPriterFilter_TextChanged(object sender, EventArgs e)
        {
            tbPCPriterFilter.BackColor = (String.IsNullOrEmpty(tbPCPriterFilter.Text)) ? SystemColors.Window : SystemColors.Info;
            pCPrinterSettingBindingSource.Filter = (String.IsNullOrEmpty(tbPCPriterFilter.Text)) ? "" : String.Format("User_ID like '%{0}%' or Printer_ID like '%{0}%'", tbPCPriterFilter.Text);
        }

        /// <summary>
        /// Сохранение изменений в настройках принтера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPCPrinterSettingsSave_Click(object sender, EventArgs e)
        {
            this.pC_Printer_SettingTableAdapter.Update(this.admin.PC_Printer_Setting);
        }

        #endregion

        #region WMS settings

        /// <summary>
        /// Сохранение изменений в настройках WMS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            // обновление данных
            this.wMS_SettingTableAdapter.Update(this.admin.WMS_Setting);
        }

        #endregion

        #region Administration

        public List<string> LimitationList { get; private set; }

        private void bUsers_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm(LimitationList);
            form.ShowDialog();
        }

        private void bRoles_Click(object sender, EventArgs e)
        {
            RoleForm form = new RoleForm(LimitationList);
            form.ShowDialog();
        }

        private void bResources_Click(object sender, EventArgs e)
        {
            ResourceForm form = new ResourceForm(LimitationList);
            form.ShowDialog();
        }

        private void bEntities_Click(object sender, EventArgs e)
        {
            EntityForm form = new EntityForm(LimitationList);
            form.ShowDialog();
        }

        private void bQuiz_Click(object sender, EventArgs e)
        {
            QuizAdminForm form = new QuizAdminForm();
            form.Owner = this;
            form.ShowDialog();
        }

        private void bUpgradeControl_Click(object sender, EventArgs e)
        {
            UpgradeControlAdminForm form = new UpgradeControlAdminForm();
            form.Owner = this;
            form.ShowDialog();
        }

        private void bDigitalWeigherConfigurationSettings_Click(object sender, EventArgs e)
        {
            ConfigurationForm form = new ConfigurationForm();
            form.Owner = this;
            form.ShowDialog();
        }

        #endregion

    }
}
