using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs
{
    /// <summary>
    /// Диалог для ввода кодов сотрудников, принимающих участие в бизнес-процессе обработки документа на определенном статусе.
    /// </summary>
    public partial class DocStatusEmployeesForm : Form
    {
        /// <summary>
        /// Идентификатор текущей сессии.
        /// </summary>
        private long SessionID { get; set; }

        /// <summary>
        /// Идентификатор модуля.
        /// </summary>
        private string ModuleID { get; set; }

        /// <summary>
        /// Идентификатор документа.
        /// </summary>
        private long DocID { get; set; }

        /// <summary>
        /// Тип документа.
        /// </summary>
        private string DocType { get; set; }

        /// <summary>
        /// Код статуса документа.
        /// </summary>
        private string StatusID { get; set; }

        /// <summary>
        /// Буфер для вводимых пользователем символов.
        /// </summary>
        private StringBuilder keysBuffer = new StringBuilder();
        
        /// <summary>
        /// Инициализирует новый экземпляр диалога, автоматически добавляет пользователей текущей сессии.
        /// </summary>
        /// <param name="sessionID">Идентификатор текущей сессии.</param>
        /// <param name="moduleID">Идентификатор модуля.</param>
        /// <param name="docID">Идентификатор документа.</param>
        /// <param name="docType">Тип документа.</param>
        /// <param name="statusID">Код статуса документа.</param>
        public DocStatusEmployeesForm(long sessionID, string moduleID, long docID, string docType, string statusID)
        {
            InitializeComponent();

            this.SessionID = sessionID;
            this.ModuleID = moduleID;
            this.DocID = docID;
            this.DocType = docType;
            this.StatusID = statusID;

            btnClear_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Таблица со списком введенных кодов сотрудников.
        /// </summary>
        public Data.WH.DocStatusEmployeesDataTable Employees
        {
            get { return wH.DocStatusEmployees; }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Сбросить список сотрудников".
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            docStatusEmployeesTableAdapter.FillByAddOrClear(wH.DocStatusEmployees, SessionID, ModuleID, DocID, DocType, StatusID, null);
        }

        /// <summary>
        /// Выполняет предпросмотр нажимаемых кнопок для ввода штрих-кода сотрудника.
        /// </summary>
        private void DocStatusEmployeesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (char.IsNumber(Convert.ToChar(e.KeyValue)))
            {
                keysBuffer.Append(Convert.ToChar(e.KeyValue));
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int employeeID = 0;
                    if (int.TryParse(keysBuffer.ToString(), out employeeID))
                        docStatusEmployeesTableAdapter.FillByAddOrClear(wH.DocStatusEmployees, SessionID, ModuleID, DocID, DocType, StatusID, employeeID);
                }
                keysBuffer.Length = 0;
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Завершить ввод кодов сотрудников".
        /// </summary>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Отменить ввод кодов сотрудников".
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
