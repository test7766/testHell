using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class StatementPrintCountForm : DialogForm
    {
        /// <summary>
        /// Признак, который показывает, возможна ли печать полного пакета документов (на всех статусах заявки, кроме 100, 
        /// возможен лишь печать актов и перечней)
        /// </summary>
        public bool IsFullPrintEnabled
        {
            get { return rbPrintFullPackageMode.Enabled; }
            set 
            {
                if (!value)
                    rbPrintGeneralDocsMode.Checked = true;
                rbPrintFullPackageMode.Enabled = value; 
            }
        }

        public StatementPrintCountForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(90, 8);
            this.btnCancel.Location = new Point(180, 8);

            rbPrintGeneralDocsMode.Checked = true;
        }

        public int StatementCount
        {
            get
            {
                int val = 1;
                int.TryParse(tbStatementCount.Value.ToString(), out val);
                return val;
            }
            set { tbStatementCount.Value = value; }
        }

        public int StatementListCount
        {
            get
            {
                int val = 1;
                int.TryParse(tbStatementListCount.Value.ToString(), out val);
                return val;
            }
            set { tbStatementListCount.Value = value; }
        }

        // TODO Кол-во сертификатов регламентируется реестром
        //public int CertificatesCount
        //{
        //    get
        //    {
        //        int val = 1;
        //        int.TryParse(tbCertificatesCount.Value.ToString(), out val);
        //        return val;
        //    }
        //    set { tbCertificatesCount.Value = value; }
        //}

        /// <summary>
        /// Признак установки режима "печать пакета документов"
        /// </summary>
        public bool IsFullPackagePrintModeSelected { get { return rbPrintFullPackageMode.Checked; } }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void PrintMode_Changed(object sender, EventArgs e)
        {
            var rbMode = sender as RadioButton;
            if (!rbMode.Checked)
                return;

            // установленный режим - полный пакет документов
            if (rbMode == rbPrintFullPackageMode)
            {
                if (pnlGeneralDocs.Visible)
                {
                    this.Height -= pnlGeneralDocs.Height;
                    pnlGeneralDocs.Visible = false;
                }
            }

            // установленный режим - печать главных документов
            if (rbMode == rbPrintGeneralDocsMode)
            {
                if (!pnlGeneralDocs.Visible)
                {
                    pnlGeneralDocs.Visible = true;
                    this.Height += pnlGeneralDocs.Height;
                }
            }
        }
    }
}
