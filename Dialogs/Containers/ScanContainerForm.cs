using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Containers
{
    public partial class ScanContainerForm : DialogForm
    {
        public ScanContainerViewMode Mode { get; set; }

        public ScanContainerForm()
        {
            InitializeComponent();

            this.Mode = ScanContainerViewMode.Default;
            ButtonOKEnabled = false;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            switch (this.Mode)
            {
                case ScanContainerViewMode.Extended:
                    this.Width = 550;
                    btnOK.Location = new Point(367, 8);
                    btnCancel.Location = new Point(457, 8);
                    break;
                case ScanContainerViewMode.Default:
                default:
                    this.Width = 394;
                    btnOK.Location = new Point(211, 8);
                    btnCancel.Location = new Point(301, 8);
                    break;
            }
        }

        /// <summary>
        /// Метка-приглашение для ввода
        /// </summary>
        public string Label
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Caption
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        public string Barcode
        {
            get { return tbScanner.Text; }
            set { tbScanner.Text = value; }
        }

        public Image Image
        {
            set { pbImage.Image = value; }
        }

        public PictureBoxSizeMode ImageSizeMode
        {
            set { pbImage.SizeMode = value; }
        }

        public bool UseScanModeOnly
        {
            get { return tbScanner.UseScanModeOnly; }
            set { tbScanner.UseScanModeOnly = value; }
        }

        /// <summary>
        /// Установка ввода ш/к, кот. содержит только последовательность цифр
        /// </summary>
        public bool OnlyNumbersInBarcode
        {
            set
            {
                tbScanner.KeyPress -= AllowOnlyNumber_KeyPress;
                if (value)
                    tbScanner.KeyPress += AllowOnlyNumber_KeyPress;
            }
        }

        private void tbScanner_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbScanner.Text))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Изменить размер и местоположение надписи
        /// </summary>
        /// <param name="y"></param>
        /// <param name="height"></param>
        public void ChangeLabelHeight(int y, int height)
        {
            label1.Location = new Point(label1.Location.X, y);
            label1.Size = new Size(label1.Size.Width, height);
        }

        private void ScanContainerForm_Shown(object sender, EventArgs e)
        {
            btnOK.Location = new Point(216, 8);
            btnCancel.Location = new Point(306, 8);

            tbScanner.SelectAll();
            tbScanner.Focus();
        }

        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }
    }

    public enum ScanContainerViewMode
    { 
        /// <summary>
        /// Режим по умолчанию
        /// </summary>
        Default = 0,

        /// <summary>
        /// Расширенный режим
        /// </summary>
        Extended = 1
    }
}
