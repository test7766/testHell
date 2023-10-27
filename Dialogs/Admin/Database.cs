using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using WMSOffice.Data.AdminTableAdapters;

namespace WMSOffice.Data.AdminTableAdapters
{
    public partial class ActionsTableAdapter
    {
        public IDbCommand[] PublicCommandCollection
        {
            get { return this.CommandCollection; }
        }
    }
}

namespace WMSOffice.Admin.Database
{
    class Database
    {
        #region properties
        private static string connectionString = Properties.Settings.Default.JDE_PROCConnectionString;
        public static string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public static ActionsTableAdapter Actions
        {
            get
            {
                ActionsTableAdapter adapter = new ActionsTableAdapter();
                foreach (SqlCommand command in adapter.PublicCommandCollection)
                    command.Connection.ConnectionString = ConnectionString;
                return adapter;
            }
        }
        #endregion

        #region public members for Data

        /// <summary>
        /// Запрос таблицы из базы данных
        /// </summary>
        public static DataTable GetDataTable(Table table, Parameters parameters)
        {
            // выбор таблицы
            string spName = "";
            switch (table)
            {               
                case Table.Roles: spName = "dbo.pr_Admin_Roles_Select"; break;
                case Table.RoleUsers: spName = "dbo.pr_Admin_Role_Users_Select"; break;
                case Table.Users: spName = "dbo.pr_Admin_Users_Select"; break;
                case Table.UserRoles: spName = "dbo.pr_Admin_User_Roles_Select"; break;
                case Table.Entities: spName = "dbo.pr_Admin_Entity_Select"; break;
                case Table.EntityAttributes: spName = "dbo.pr_Admin_Entity_Attribute_Select"; break;
                //case Table.EntityElements: spName = "dbo.pr_Admin_Entity_Elements_Select"; break;
                case Table.LimitationEntityElements: spName = "dbo.pr_Admin_Limitation_Entity_Elements_Select"; break;
                case Table.SecurityObjectResources: spName = "dbo.pr_Admin_SecurityObject_Resources_Select"; break;
                case Table.Resources: spName = "dbo.pr_Admin_Resource_Select"; break;
                case Table.ResourceAccess: spName = "dbo.pr_Admin_Resource_Access_Select"; break;
                case Table.QkAnalysisFeatures: spName = "[dbo].[pr_QK_Get_Analysis_Features]"; break;
                default: return null;
            }
            // выполнение запроса
            return ExecStoredProcedure(ConnectionString, spName, parameters);
        }

        private static DataTable ExecStoredProcedure(string connectionString, string spName, Parameters parameters)
        {
            DataTable result = new DataTable();
            // выполнение запроса
            using (SqlDataAdapter adapter = new SqlDataAdapter(spName, connectionString))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.CommandTimeout = 300;

                if (parameters != null)
                    foreach (KeyValuePair<string, object> parameter in parameters)
                        adapter.SelectCommand.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));              

                adapter.Fill(result);
            }
            return result;
        }

        #endregion
    }

    public class Parameters : List<KeyValuePair<string, object>>
    {
        public void CopyTo(Parameters parameters)
        {
            foreach (KeyValuePair<string, object> item in this)
                parameters.Add(item);
        }
    }

    public enum Table
    {
        None,
        Entities,
        EntityAttributes,
        Roles,
        RoleUsers,
        //EntityElements,
        LimitationEntityElements,
        Users,
        UserRoles,
        SecurityObjectResources,
        Resources,
        ResourceAccess,

        // Это уже не администрирование
        QkAnalysisFeatures
    }
}
