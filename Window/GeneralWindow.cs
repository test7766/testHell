using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Window
{
    public partial class GeneralWindow : Form
    {
        /// <summary>
        /// Шапка окна (тип документа)
        /// </summary>
        protected Label DocTitle { get { return this.lblDocName; } }

        public GeneralWindow()
        {
            InitializeComponent();
        }

        #region general properties

        public long DocID { get; set; }

        public string DocName { get; set; }

        public string DocType { get; set; }

        public DateTime DocDate { get; set; }

        public string StatusID { get; set; }

        public string StatusName { get; set; }

        private int _userID = 0;
        public int UserID
        {
            set
            {
                _userID = value;
            }
            get
            {
                //return ((MainForm)ParentForm).UserID;
                return (_userID != 0) ? _userID : (ParentForm != null) ? ((MainForm)ParentForm).UserID : 0;
            }
        }

        #endregion

        public void InitDocument(string docName, long docID, string docType, DateTime docDate, string statusID, string statusName)
        {
            if (docID == 0) Text = docName + " (" + docType + ")";
            else Text = docName + " (" + docType + "-" + docID + ")";
            lblDocName.Text = Text;
            DocName = docName;
            DocID = docID;
            DocType = docType;
            DocDate = docDate;
            StatusID = statusID;
            StatusName = statusName;
        }
        
        /// <summary>
        /// Скрывает панель заголовка.
        /// </summary>
        public void HideHeaderPanel()
        {
            pnlHeader.Visible = false;
        }

        public void ShowError(string error)
        {
            MessageBox.Show(error.Replace("\n\r", Environment.NewLine), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void ShowError(Exception exception)
        {
            this.ShowError(exception, false);
        }

        public void ShowError(Exception exception, bool obligatoryConfirmation)
        {
            var messageText = (exception is System.Reflection.TargetInvocationException && exception.InnerException != null)
                ? exception.InnerException.Message.Replace("\n\r", Environment.NewLine)
                : exception.Message.Replace("\n\r", Environment.NewLine);

            do
            {
                var result = DialogResult.None;

                if (obligatoryConfirmation)
                    result = MessageBox.Show(messageText, "Ошибка!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                else
                    result = MessageBox.Show(messageText, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                if (obligatoryConfirmation && result != DialogResult.OK)
                    continue;

                break;
            }
            while (true);
        }

        private const int WM_CLOSE = 0x10;
        /// <summary>
        /// To capture the Upper right "X" click
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CLOSE) // Attempting to close Form
            {
                AutoValidate = AutoValidate.Disable; // this stops (all) validations
            }

            base.WndProc(ref m);  //call the base method to handle other messages
        }

        /// <summary>
        /// Метод возвращает ограничения пользователей, входящих в сессию,
        /// по указанной сущности для данного типа интерфейса
        /// </summary>
        /// <param name="entityName">Название сущности</param>
        /// <returns>Строка с ключами сущностей ограничений (разделитель ";")</returns>
        //public string GetLimitations(string entityName)
        //{
        //    string res = "";
        //    using (Data.AccessTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.AccessTableAdapters.QueriesTableAdapter())
        //    {
        //        res = (string)adapter.GetLimitationsByDocType(UserID, DocType, entityName);
        //    }
        //    return res;
        //}

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        /// <summary>
        /// Метод возвращает ограничения пользователей, входящих в сессию,
        /// по указанной сущности для данного типа интерфейса
        /// </summary>
        /// <param name="entityName">Название сущности</param>
        /// <returns>Строка с ключами сущностей ограничений (разделитель ";")</returns>
        public EntityElementsList GetLimitedElements(string entityName)
        {
            EntityElementsList res = new EntityElementsList();
            using (Data.AccessTableAdapters.LimitedEntityElementsTableAdapter adapter = new WMSOffice.Data.AccessTableAdapters.LimitedEntityElementsTableAdapter())
            {
                Data.Access.LimitedEntityElementsDataTable table = adapter.GetData(UserID, DocType, entityName);
                if (table != null && table.Count > 0)
                    for (int i = 0; i < table.Count; i++)
                        res.Add((string)table[i]["Entity_Key"]);
            }
            return res;
        }

        public class EntityElementsList : List<string> { }
    }
}
