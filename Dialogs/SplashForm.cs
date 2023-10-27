using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs
{
    public partial class SplashForm : Form
    {
        private bool ForceClosed = false;

        /// <summary>
        /// Инициализирует новый экземпляр диалога
        /// </summary>
        public SplashForm()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Описание текущего действия
        /// </summary>
        public string ActionText
        {
            get { return lblAction.Text; }
            set { lblAction.Text = value; }
        }

        /// <summary>
        /// Предотвращает попытку закрытия окна пользователем
        /// </summary>
        private void SimpleLoadingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ForceClosed)
                e.Cancel = true;
        }

        /// <summary>
        /// Закрывает окно
        /// </summary>
        public void CloseForce()
        {
            //SetProgressState(wyDay.Controls.ThumbnailProgressState.NoProgress);
            ForceClosed = true;
            this.Close();
        }
    }
}
