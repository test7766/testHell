using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.ColdChain;

namespace WMSOffice.Window
{
    public partial class ColdChainTermoBagPackingWindow : GeneralWindow
    {
        /// <summary>
        /// Класс-менеджер данной формы
        /// </summary>
        private ColdChainPackingManager manager = null;

        public ColdChainTermoBagPackingWindow(ColdChainPackingManager manager)
        {
            InitializeComponent();
            tbScanner.TextChanged += new EventHandler(tbScanner_TextChanged);
            this.manager = manager;
        }

        void tbScanner_TextChanged(object sender, EventArgs e)
        {
            PackingItemToTermoBag();
            tbScanner.Text = string.Empty;
        }

        /// <summary>
        /// Упаковка товара в термосумку
        /// </summary>
        private void PackingItemToTermoBag()
        {
            try
            {
                using (Data.ColdChainTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.QueriesTableAdapter())
                    adapter.PackingItemsToTermoBag(tbScanner.Text, manager.TermoBagBarCode, manager.UserID, manager.RouteListNumber);

                RefreshPickSlipContent(); // Обновляем сборочный лист
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента погрузки товара в термосумку", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tbScanner.Focus();
        }

        private void ColdChainAddGoodsToTermoBag_Load(object sender, EventArgs e)
        {
            RefreshPickSlipContent();
            RefreshInterface();
        }


        /// <summary>
        /// Обновление списка не погруженных товаров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshGoodsList_Click(object sender, EventArgs e)
        {
            RefreshPickSlipContent();
        }

        /// <summary>
        /// Обновление сборочного листа
        /// </summary>
        private void RefreshPickSlipContent()
        {
            try
            {
                // TODO тестовый номер сборочного - 222875
                this.routeListPickSlipTableAdapter.Fill(this.coldChain.RouteListPickSlip, manager.RouteListNumber); 
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления сборочного листа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch 
            {
                // TODO срабатывает исключение, возникшее при взаимодействии с источником данных - разобраться
            }
        }

        /// <summary>
        /// Выбор следующей термосумки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUseNextTermoBag_Click(object sender, EventArgs e)
        {
            if (CompleteTermoBagPacking())
                ExecuteActionsAfterUsingTermoBag();
        }

        /// <summary>
        /// Метод определяет была ли завершена работа с текущей термосумкой
        /// </summary>
        /// <returns></returns>
        private bool TermoBagWasHandled()
        {
            return manager.CompleteUsingTermoBag;
        }

        /// <summary>
        /// Завершить работу с текущей термосумкой
        /// </summary>
        /// <returns></returns>
        private bool CompleteTermoBagPacking()
        {
            if (TermoBagWasHandled())
                return true;

            if (MessageBox.Show(this, "Вы уверены что хотите завершить погрузку товара в термосумку?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    using (Data.ColdChainTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.QueriesTableAdapter())
                        adapter.CloseTermoBag(manager.TermoBagBarCode);

                    manager.CompleteUsingTermoBag = true;
                    RefreshInterface(); // Обновим информацию о текущей термосумке
                    MessageBox.Show(this, "Операция закрытия термосумки выполнена успешно.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (System.Data.SqlClient.SqlException er)
                {
                    MessageBox.Show(er.Message, "Ошибка момента закрытия термосумки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            return false;
        }

        /// <summary>
        /// Выполнение дополнительных действий после окончания работы с текущей термосумкой
        /// </summary>
        private void ExecuteActionsAfterUsingTermoBag()
        {
            RefreshPickSlipContent(); // Обновляем сборочный лист
            manager.UseNextTermoBag(); // Выбираем следующую термосумку
            RefreshInterface(); // Обновим информацию о текущей термосумке
        }

        private void RefreshInterface()
        {
            lblCurrentTermoBag.Text = string.Format("Текущая термосумка: {0}", manager.TermoBagBarCode == null ? "ОТСУТСТВУЕТ" : manager.TermoBagBarCode);
            btnUndoTermoBagPacking.Enabled = !TermoBagWasHandled();
        }

        /// <summary>
        /// Завершить сбор товара с перрона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompleteGoodsPacking_Click(object sender, EventArgs e)
        {
            if (CompleteTermoBagPacking())
                try
                {
                    using (Data.ColdChainTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.QueriesTableAdapter())
                        adapter.CompleteGoodsPacking(manager.RouteListNumber);

                    MessageBox.Show(this, "Операция завершения сбора товара с перрона выполнена успешно.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    manager.CompletePacking = true;
                    this.Close();
                }
                catch (System.Data.SqlClient.SqlException er)
                {
                    MessageBox.Show(er.Message, "Ошибка момента окончания погрузки товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RefreshPickSlipContent(); // Обновляем сборочный лист
                }
        }

        /// <summary>
        /// Отменить погрузку термосумки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUndoTermoBagPacking_Click(object sender, EventArgs e)
        {
            if (TermoBagWasHandled())
                return;

            if (MessageBox.Show(this, "Вы уверены что хотите отменить погрузку товара в термосумку?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    using (Data.ColdChainTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.QueriesTableAdapter())
                        adapter.UndoGoodsPackingInTermoBag(manager.TermoBagBarCode);

                    manager.CompleteUsingTermoBag = true;
                    RefreshInterface(); // Обновим информацию о текущей термосумке
                    MessageBox.Show(this, "Операция отмены выполнена успешно.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ExecuteActionsAfterUsingTermoBag();
                }
                catch (System.Data.SqlClient.SqlException er)
                {
                    MessageBox.Show(er.Message, "Ошибка момента отмены погрузки темосумки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }


        private void dgvPickSlipContent_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // * Взято из класса DeliveryPackingWindow

            // Разрисовка строк в таблице
            foreach (DataGridViewRow row in dgvPickSlipContent.Rows)
            {
                Data.ColdChain.RouteListPickSlipRow itemRow = (Data.ColdChain.RouteListPickSlipRow)((DataRowView)row.DataBoundItem).Row;

                // Простая разрисовка строки
                string colorName = itemRow.IsColorNull() ? "white" : itemRow.Color.ToLower();
                Color backColor = Color.FromName(colorName);

                for (int c = 0; c < row.Cells.Count; c++)
                {
                    row.Cells[c].Style.BackColor = backColor;
                    row.Cells[c].Style.SelectionForeColor = backColor;
                }
            }
        }

        private void ColdChainTermoBagPackingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !CanFinishTotalPacking();
        }

        private bool CanFinishTotalPacking()
        {
            if (!manager.CompletePacking)
                MessageBox.Show(this, "Операция сбора товара с перрона не была завершена.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return manager.CompletePacking;
        }
    }
}
