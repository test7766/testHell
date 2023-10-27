using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.D3;

namespace WMSOffice.Dialogs.D3
{
    /// <summary>
    /// Форма создания/изменения визуального стиля, который используется в 2D/3D визуализации
    /// </summary>
    public partial class StyleEditForm : DialogForm
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public StyleEditForm()
        {
            InitializeComponent();

            cbBorderType.Items.Add(BorderStyles.None);
            cbBorderType.Items.Add(BorderStyles.Solid);
            cbBorderType.Items.Add(BorderStyles.Dash);
            cbBorderType.Items.Add(BorderStyles.Cross);
        }

        #region Fields

        // локальная переменная - редактируемый стиль
        private Style _style;

        #endregion

        #region Properties

        /// <summary>
        /// Редактируемый стиль
        /// </summary>
        public Style Style
        {
            get
            {
                return _style;
            }
            set
            {
                _style = value;
                tbName.Text = _style.Name;
                cbBackColor.Color = _style.BackColor;
                cbForeColor.Color = _style.ForeColor;
                cbBorderColor.Color = _style.BorderColor;
                nudBorderWidth.Value = _style.BorderWidth;
                
                foreach (object item in cbBorderType.Items)
                    if ((BorderStyles)item == _style.BorderStyle)
                    {
                        cbBorderType.SelectedItem = item;
                        //cbBorderType.SelectedItem = _style.BorderStyle;
                        break;
                    }
            }
        }

        /// <summary>
        /// Атрибут, разрешающий менять название стиля (при создании True)
        /// </summary>
        public bool AllowChangeName
        {
            get { return tbName.Enabled; }
            set { tbName.Enabled = value; }
        }

        #endregion

        #region Preview Refresh

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            _style.Name = tbName.Text;
        }

        private void cbBackColor_SelectedColorChanged(object sender, EventArgs e)
        {
            _style.BackColor = cbBackColor.Color;
            RefreshPreview();
        }

        private void cbForeColor_SelectedColorChanged(object sender, EventArgs e)
        {
            _style.ForeColor = cbForeColor.Color;
            RefreshPreview();
        }

        private void cbBorderColor_SelectedColorChanged(object sender, EventArgs e)
        {
            _style.BorderColor = cbBorderColor.Color;
            RefreshPreview();
        }

        private void nudBorderWidth_ValueChanged(object sender, EventArgs e)
        {
            _style.BorderWidth = (short)nudBorderWidth.Value;
            RefreshPreview();
        }

        private void cbBorderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _style.BorderStyle = (BorderStyles)cbBorderType.SelectedItem;
            RefreshPreview();
        }

        /// <summary>
        /// Обновление предварительного просмотра
        /// </summary>
        private void RefreshPreview()
        {
            // создается объект "ячейка", которая сама себя отрисовывает
            WMSOffice.Controls.D3.D2Cell cell = new WMSOffice.Controls.D3.D2Cell()
            {
                Position = new WMSOffice.Controls.D3.Point3D(0, 0, 0),
                Size = new WMSOffice.Controls.D3.Region3D(30, 50, 10),
                Style = _style,
                Text = _style.Name
            };

            // формирование изображения
            Bitmap bmp = new Bitmap(cell.Size.Width, cell.Size.Height);
            Graphics g = Graphics.FromImage(bmp);
            cell.Draw(null, g);
            picturePreview.Image = bmp;
        }

        #endregion

        /// <summary>
        /// Обработчик события начальной загрузки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StyleEditForm_Load(object sender, EventArgs e)
        {
            //cbBorderType.Items.Add(BorderStyles.None);
            //cbBorderType.Items.Add(BorderStyles.Solid);
            //cbBorderType.Items.Add(BorderStyles.Dash);
            //cbBorderType.Items.Add(BorderStyles.Cross);

            //if (_style == null)
            //{
            //    _style = new Style();
            //    cbBorderType.SelectedIndex = 0;
            //}
        }

        /// <summary>
        /// Обработчик события зактытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StyleEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // проверка правильности ввода
            if (DialogResult == DialogResult.OK && String.IsNullOrEmpty(_style.Name))
            {
                MessageBox.Show("Название стиля является обязательным полем.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }


    }
}
