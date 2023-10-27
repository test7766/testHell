using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WMSOffice.Dialogs.WH
{
    public partial class CardCalculationEditForm : DialogForm
    {
        const string STR_OutFilePath = @"\\dl2\fs\DirRK";

        public long DocID { get; set; }

        public CardCalculationEditForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(244, 8);
            this.btnCancel.Location = new Point(334, 8);

            this.btnOK.Text = "Отправить";
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    ofd.Filter = "Файлы Excel|*.xls;*.xlsx;";
                    ofd.Title = "Выберите файл";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        var filePath = ofd.FileName;
                        lblFilePath.Text = filePath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CardCalculationEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SendData();
        }

        private bool SendData()
        {
            try
            {
                var comment = tbComment.Text;

                var editDiscount = cbDiscount.Checked;
                var editMarkdown = cbMarkdown.Checked;
                var editCalcDate = cbCalcDate.Checked;

                if (string.IsNullOrEmpty(comment) && !editDiscount && !editMarkdown && !editCalcDate)
                    throw new Exception("Необходимо либо указать комментарий \r\nлибо отметить позиции.");

                var filePath = string.Empty;
                if (!string.IsNullOrEmpty(lblFilePath.Text))
                {
                    var srcFilePath = lblFilePath.Text;
                    if (File.Exists(srcFilePath))
                    {
                        var fileName = string.Format("{0}_{1}", this.DocID, new FileInfo(srcFilePath).Name);
                        var dstFilePath = Path.Combine(STR_OutFilePath, fileName);

                        File.Copy(srcFilePath, dstFilePath);
                        filePath = dstFilePath;
                    }
                }

                using (var adapter = new Data.WFTableAdapters.CompensationDetailsTableAdapter())
                    adapter.CorrectDoc(this.DocID, editDiscount, editMarkdown, editCalcDate, comment, this.UserID, filePath);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
