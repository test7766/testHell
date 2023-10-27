using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using WMSOffice.Data;
using WMSOffice.Data.AccessTableAdapters;

namespace WMSOffice.Dialogs
{
    public partial class ChangeUserForm : DialogForm
    {
        /// <summary>
        /// Признак создания временной сессии
        /// </summary>
        public bool CreateTempSession { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ChangeUserForm()
        {            
            InitializeComponent();

            // автологин
            CanAutoLogin = true;
            ButtonOKEnabled = false;
            UserAuthentication(0, 0, null);
            if (ButtonOKEnabled)
                CreateSession();
        }

        //int _userID;
        //public int UserID
        //{
        //    get { return _userID; }
        //}
        //string _userName;
        //public string UserName
        //{
        //    get { return _userName; }
        //}
        //int _sessionID;
        //public int SessionID
        //{
        //    get { return _sessionID; }
        //}

        public bool CanAutoLogin { get; set; }
        public bool SessionCreated { get { return UserID > 0 ? true : false; } }

        public string UsersLine
        {
            get {
                string line = "";
                foreach (Access.SessionUsersRow row in access.SessionUsers.Rows)
                {
                    if (!String.IsNullOrEmpty(line)) line += ", ";
                    line += row.Employee + " (" + row.Employee_ID.ToString() + ")";
                }
                return line;
            }
        }

        //private Data.Access.SessionUsersDataTable sessionUsers = new Access.SessionUsersDataTable();
        private bool newSession = true;
        private void tbEmployeeCode_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbEmployeeCode.Text))
            {
                //bool toClose = false;
                int id = 0;
                int.TryParse(tbEmployeeCode.Text, out id);
                // проверка сотрудника
                UserAuthentication(id, 0, null);
                tbEmployeeCode.Text = "";
            } else 
                if (ButtonOKEnabled) { DialogResult = DialogResult.OK; Close(); }
        }

        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        /// <param name="userID">Код сотрудника</param>
        /// <param name="cardID">Код карточки сотрудника</param>
        /// <param name="password">Пароль</param>
        private void UserAuthentication(int userID, long cardID, string password)
        {
            // если была открыта сессия, то мы начинаем новую
            if (!newSession)
            {
                newSession = true;
                access.SessionUsers.Clear();
            }

            // проверка сотрудника
            using (UserInformationTableAdapter adapter = new UserInformationTableAdapter())
            {
                try
                {
                    string login = CanAutoLogin ? System.Security.Principal.WindowsIdentity.GetCurrent().Name : null;
                    Access.UserInformationDataTable table = adapter.GetData(System.Environment.MachineName, userID, cardID, login, password);
                    if (table != null && table.Count > 0)
                    {
                        if (access.SessionUsers.FindByEmployee_ID((int)table[0].User_ID) == null)
                        {
                            Access.SessionUsersRow newRow = access.SessionUsers.NewSessionUsersRow();
                            newRow.Employee_ID = (int)table[0].User_ID;
                            newRow.Employee = table[0].User_Name;
                            newRow.Login_Type = table[0].Login_Type;
                            newRow.Warning_Message = table[0].Warning_Message;
                            access.SessionUsers.AddSessionUsersRow(newRow);
                        }
                        //toClose = true;
                        ButtonOKEnabled = true;
                    }
                    else if (!CanAutoLogin) // в случае автовхода сообщение не показывать
                        MessageBox.Show("Пользователь не найден!\nВозможно неверно введены код сотрудника либо пароль.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else CanAutoLogin = false;
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("PASSWORD_REQUIRED"))
                    {
                        PasswordForm inputPasswordForm = new PasswordForm();
                        inputPasswordForm.ShowDialog();
                        if (inputPasswordForm.DialogResult == DialogResult.OK)
                            UserAuthentication(userID, cardID, inputPasswordForm.GetPassword());
                    }
                    else if (!CanAutoLogin)
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else CanAutoLogin = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region Smart Logic device support

        /// <summary>
        /// Метод создания временного фонового потока для считывания кода электро-магнитного удостоверения сотрудника
        /// </summary>
        private void CreateSmartLogicWorker()
        {
            smartLogicDevice = new SmartLogicDeviceHelper.SmartLogicDevice("COM6");
            BackgroundWorker workerSmartLogic = new BackgroundWorker();
            // формирование фонового потока считывания кода электро-магнитной карты
            workerSmartLogic.DoWork += new DoWorkEventHandler(workerSmartLogic_DoWork);
            workerSmartLogic.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerSmartLogic_RunWorkerCompleted);
            // запуск считывания кода карточки в фоновом потоке
            workerSmartLogic.RunWorkerAsync();
        }

        /// <summary>
        /// Объект для работы с устройством SmartLogic
        /// </summary>
        SmartLogicDeviceHelper.SmartLogicDevice smartLogicDevice = null;

        /// <summary>
        /// Обработчик события считывания кода электро-магнитной карты сотрудника в отдельном потоке
        /// </summary>
        void workerSmartLogic_DoWork(object sender, DoWorkEventArgs e)
        {
            long num = smartLogicDevice.ScanCardNumber();
            e.Result = num;
        }

        /// <summary>
        /// Обработчик события завершения считывания кода электро-магнитной карты сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void workerSmartLogic_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            long num = (long)e.Result;
            if (num == 0) return; // код принудительного закрытия порта

            // TODO: Login here
            //MessageBox.Show(num.ToString());

            UserAuthentication(0, num, null);   

            // продолжаем слушать порт устройства SmartLogic
            CreateSmartLogicWorker();
        }

        #endregion

        /// <summary>
        /// Обработчик события: форма загружена
        /// </summary>
        private void ChangeUserForm_Load(object sender, EventArgs e)
        {
            if (UserID != 0)
            {
                sessionUsersTableAdapter.Fill(access.SessionUsers, UserID);
                newSession = false;
            }
            else access.SessionUsers.Clear();

            ButtonOKEnabled = false;

            // добавлена поддержка SmartLogic устройств
            CreateSmartLogicWorker();
        }

        /// <summary>
        /// Обработчик события закрытия формы создания сессии
        /// </summary>
        private void ChangeUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CreateSession();
        }

        /// <summary>
        /// Cоздание сессии
        /// </summary>
        private void CreateSession()
        {
            // создание новой сессии
            if (DialogResult == DialogResult.OK || CanAutoLogin)
            {
                try
                {
                    // создание новой сессии
                    var sessionID = (long?)null;
                    sessionUsersTableAdapter.CreateSession(Environment.MachineName, System.Security.Principal.WindowsIdentity.GetCurrent().Name, this.CreateTempSession, ref sessionID);

                    var id = Convert.ToInt32(sessionID ?? 0);

                    // добавление пользователей в сессию
                    if (id != 0)
                        foreach (Access.SessionUsersRow row in access.SessionUsers.Rows)
                        {
                            sessionUsersTableAdapter.Insert(id, row.Employee_ID, row.Login_Type);
                        }

                    UserID = id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Обработчик события открытия (показа) формы
        /// </summary>
        private void ChangeUserForm_Shown(object sender, EventArgs e)
        {
            tbEmployeeCode.Focus();
        }

        /// <summary>
        /// Обработчик события - форма закрыта.
        /// Освобождаются ресурсы (COM-Port).
        /// </summary>
        private void ChangeUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            smartLogicDevice.Dispose();
        }

        /// <summary>
        /// Отображение сообщения пользовтаелю при нажатии на ячейку
        /// </summary>
        private void gvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvUsers.Columns[e.ColumnIndex].Name == "Warning_Message")
                MessageBox.Show(gvUsers[e.ColumnIndex, e.RowIndex].Value.ToString(), "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
