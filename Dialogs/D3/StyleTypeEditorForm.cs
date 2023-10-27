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
    /// Форма выбора визуального стиля 2D/3D объекта
    /// </summary>
    public partial class StyleTypeEditorForm : DialogForm
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public StyleTypeEditorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события загрузки формы - обновляем данные.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StyleTypeEditorForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        private void LoadData()
        {
            // обновление данных
            stylesTableAdapter.Fill(d3.Styles, SessionID);

            // отображение стилей в ListView
            lvStyles.Items.Clear();
            ilStylesSmall.Images.Clear();
            #region формирование изображения стиля по умолчанию
            Bitmap emptyBitmap = new Bitmap(32, 32);
            WMSOffice.Controls.D3.D2Cell cell = new WMSOffice.Controls.D3.D2Cell()
            {
                Position = new WMSOffice.Controls.D3.Point3D(0, 0, 0),
                Size = new WMSOffice.Controls.D3.Region3D(30, 50, 10),
                Text = ""
            };
            #endregion

            foreach (Data.D3.StylesRow styleRow in d3.Styles)
            {
                #region формирование изображения стиля
                Bitmap bmp = new Bitmap(cell.Size.Width, cell.Size.Height);
                Graphics g = Graphics.FromImage(bmp);
                cell.Style = Data.D3.GetStyle(styleRow);
                // cell.Style = GetStyle(styleRow);
                cell.Draw(null, g);
                ilStylesSmall.Images.Add(styleRow.Style_ID, bmp);
                ilStylesLarge.Images.Add(styleRow.Style_ID, bmp);
                #endregion

                // добавление стиля в список
                ListViewItem item = new ListViewItem();
                item.Text = styleRow.Style_ID;
                item.ImageKey = styleRow.Style_ID;
                item.Tag = styleRow;
                lvStyles.Items.Add(item);

                // выбор "текущего" стиля
                if (SelectedValue != null && styleRow.Style_ID == SelectedValue.Name)
                    item.Selected = true;
            }
        }

        /// <summary>
        /// Сессия пользователя
        /// </summary>
        public int SessionID { get; set; }

        /// <summary>
        /// Выбранный (текущий) стиль
        /// </summary>
        public WMSOffice.Controls.D3.Style SelectedValue { get; set; }
/*
        /// <summary>
        /// Стиль по умолчанию
        /// </summary>
        private WMSOffice.Controls.D3.Style _defaultStyle = new WMSOffice.Controls.D3.Style()
        {
            BackColor = SystemColors.Info,
            BorderColor = Color.Black,
            BorderStyle = WMSOffice.Controls.D3.BorderStyles.None,
            BorderWidth = 1,
            ForeColor = Color.Black,
            Name = "Default"
        };

        /// <summary>
        /// Метод возвращает нужный стиль из загруженных ранее
        /// </summary>
        /// <param name="styleName"></param>
        /// <returns></returns>
        private WMSOffice.Controls.D3.Style GetStyle(Data.D3.StylesRow rowStyle)
        {
            // создание объекта стиля
            if (rowStyle != null)
                return new WMSOffice.Controls.D3.Style()
                {
                    Name = rowStyle.Style_ID,
                    BackColor = (rowStyle.IsBack_ColorNull()) ? _defaultStyle.BackColor
                        : (rowStyle.Back_Color[0] == '#') ? Color.FromArgb(Convert.ToInt32(rowStyle.Back_Color.Substring(1), 16))
                            : Color.FromName(rowStyle.Back_Color),
                    BorderColor = (rowStyle.IsBorder_ColorNull()) ? _defaultStyle.BorderColor
                        : (rowStyle.Border_Color[0] == '#') ? Color.FromArgb(Convert.ToInt32(rowStyle.Border_Color.Substring(1), 16))
                            : Color.FromName(rowStyle.Border_Color),
                    BorderStyle = (rowStyle.IsBorder_StyleNull()) ? _defaultStyle.BorderStyle
                        : (rowStyle.Border_Style == "solid") ? WMSOffice.Controls.D3.BorderStyles.Solid
                        : (rowStyle.Border_Style == "dash") ? WMSOffice.Controls.D3.BorderStyles.Dash
                        : (rowStyle.Border_Style == "cross") ? WMSOffice.Controls.D3.BorderStyles.Cross : WMSOffice.Controls.D3.BorderStyles.None,
                    BorderWidth = (rowStyle.IsBorder_WidthNull()) ? _defaultStyle.BorderWidth
                        : rowStyle.Border_Width,
                    ForeColor = (rowStyle.IsFore_ColorNull()) ? _defaultStyle.ForeColor
                        : (rowStyle.Fore_Color[0] == '#') ? Color.FromArgb(Convert.ToInt32(rowStyle.Fore_Color.Substring(1), 16))
                            : Color.FromName(rowStyle.Fore_Color)
                };

            // иначе возвращаем стиль по умолчанию
            return _defaultStyle;
        }
*/
        /// <summary>
        /// При закрытии формы присваиваем свойству SelectedValue выбранное значение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StyleTypeEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
                if (SelectedValue == null)
                    e.Cancel = true;
        }

        #region изменение режима просмотра списка стилей

        /// <summary>
        /// Переключение на вид с большими иконками
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewLargeIcon_Click(object sender, EventArgs e)
        {
            SwitchView(System.Windows.Forms.View.LargeIcon, btnViewLargeIcon);
        }

        /// <summary>
        /// Переключение на вид с маленькими иконками
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewSmallIcon_Click(object sender, EventArgs e)
        {
            SwitchView(System.Windows.Forms.View.SmallIcon, btnViewSmallIcon);
        }

        /// <summary>
        /// Переключение на вид списком
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewList_Click(object sender, EventArgs e)
        {
            SwitchView(System.Windows.Forms.View.List, btnViewList);
        }

        /// <summary>
        /// Метод переключения вида отображения списка стилей
        /// </summary>
        /// <param name="view"></param>
        /// <param name="selectedItem"></param>
        private void SwitchView(System.Windows.Forms.View view, ToolStripMenuItem selectedItem)
        {
            lvStyles.View = view;
            btnViewLargeIcon.Checked = btnViewSmallIcon.Checked = btnViewList.Checked = false;
            selectedItem.Checked = true;
        }

        #endregion

        /// <summary>
        /// По двойному щелчку на стиле производим его выбор
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvStyles_DoubleClick(object sender, EventArgs e)
        {
            if (lvStyles.SelectedItems.Count > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "Добавить стиль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddStyle_Click(object sender, EventArgs e)
        {
            StyleEditForm form = new StyleEditForm();
            if (SelectedValue != null)
                form.Style = SelectedValue;
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    WMSOffice.Controls.D3.Style style = form.Style;
                    stylesTableAdapter.Insert(style.Name, 
                        Style.ColorToString(style.BackColor),
                        Style.ColorToString(style.ForeColor), 
                        Style.ColorToString(style.BorderColor), 
                        style.BorderWidth, 
                        style.BorderStyle.ToString().ToLower());
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка добавления!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        /// <summary>
        /// Обработчик нажатия на кнопку "Редактировать стиль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditStyle_Click(object sender, EventArgs e)
        {
            if (SelectedValue == null)
                MessageBox.Show("Не выбран стиль для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                StyleEditForm form = new StyleEditForm();
                form.Style = SelectedValue;
                form.AllowChangeName = false;
                if (form.ShowDialog() == DialogResult.OK)
                    try
                    {
                        WMSOffice.Controls.D3.Style style = form.Style;
                        stylesTableAdapter.Update(style.Name,
                            Style.ColorToString(style.BackColor),
                            Style.ColorToString(style.ForeColor),
                            Style.ColorToString(style.BorderColor),
                            style.BorderWidth,
                            style.BorderStyle.ToString().ToLower());
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка сохранения!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        /// <summary>
        /// Удаление стиля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteStyle_Click(object sender, EventArgs e)
        {
            if (SelectedValue == null)
                MessageBox.Show("Не выбран стиль для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                if (MessageBox.Show(String.Format("Вы уверенны, что хотите удалить стиль \"{0}\"?", SelectedValue.Name), "Удалить?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    try
                    {
                        stylesTableAdapter.Delete(SelectedValue.Name);
                        SelectedValue = null;
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка удаления!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
        }

        /// <summary>
        /// Выбор стиля в списке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStyles.SelectedItems.Count > 0)
                SelectedValue = Data.D3.GetStyle((WMSOffice.Data.D3.StylesRow)lvStyles.SelectedItems[0].Tag);
                // SelectedValue = GetStyle((WMSOffice.Data.D3.StylesRow)lvStyles.SelectedItems[0].Tag);
            else
                SelectedValue = null;
        }


    }
}
