using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class ScanPickListForm : DialogForm
    {
        /// <summary>
        /// Признак тестовой версии
        /// </summary>
        private static bool IsTestVersion { get { return MainForm.IsTestVersion; } }

        public ScanPickListForm()
        {
            InitializeComponent();
            base.ButtonOKEnabled = false;
        }

        private bool isEmployee = false;
        public bool IsEmployee 
        { 
            get { return isEmployee; } 
            set { 
                
                isEmployee = value;
                Text = "Сотрудник";
                lblDescription.Text = "Отсканируйте штрих-код сотрудника.";
            } 
        }

        public int UserID { get; set; }
        public string PickSlipBarcode { get { return tbScanner.Text; } }
        public string DocType { get; set; }

        private void tbScanner_TextChanged(object sender, EventArgs e)
        {
            if (IsEmployee)
            {
                DialogResult = DialogResult.OK;
                return;
            }

            try
            {
                // проверка правильности кода сборочного, можно ли его брать в работу этому сотруднику?
                using (Data.PickControlTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.QueriesTableAdapter())
                {
                    // проверка. Если есть ошибки, будет сгенерирована исключительная ситуация с описанием
                    if (DocType == "PC")
                        CheckPickSlip();
                    else if (DocType == "ET")
                        adapter.CheckEtic(tbScanner.Text, UserID);
                    else if (DocType == "RE")
                        adapter.CheckReturn(tbScanner.Text, UserID);
                    else
                        adapter.CheckReControlPickSlip(tbScanner.Text, UserID, DocType);
                }

                // если все хорошо, закрываем окно, возвращаем значение ШК сборочного
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper() == "CREATE_PACK_PAL")
                {
                    if (MessageBox.Show("Хотите создать пак-лист на перебор товара?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Закрываем окно, возвращаем ШК пак-листа (выставляем тип документа - пак-лист)
                        this.DocType = "PL";
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Документ не был создан.\nДальнейшая обработка прекращена!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    Close();
                    return;
                }
                // Разблокировка контроля
                else if (ex.Message.ToUpper() == "NEED_UNBLOCK_PICK_CONTROL")
                {
                    // Обеспечим повторные действия на случай возникновения сбоев
                    while (true)
                    {
                        var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                        {
                            Label = "Весовой контроль пройден.\r\nНеобходимо разблокировать сборочный.\r\nОтсканируйте бэйдж руководителя,\r\nкоторый отвечает за мониторинг контроля",
                            Text = "Разблокировка контроля",
                            Image = Properties.Resources.role,
                            //OnlyNumbersInBarcode = true
                            UseScanModeOnly = true
                        };

                        if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                        {
                            tbScanner.Focus();
                            tbScanner.SelectAll();
                            return;
                        }

                        var bossID = Convert.ToInt32(dlgBossScanner.Barcode);

                        var canAccess = (int?)null;
                        using (var adapter = new Data.PickControlTableAdapters.DocRowsTableAdapter())
                            adapter.CanUnblockPickControl(bossID, ref canAccess);

                        if (canAccess.HasValue && canAccess.Value == 0)
                        {
                            MessageBox.Show("Пользователь не имеет права\r\nразблокировки контроля!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            continue;
                        }
                        else
                        {
                            // Разблокировка выполнена
                            DialogResult = DialogResult.OK;
                            Close();
                            return;
                        }
                    }
                }

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbScanner.Focus();
                tbScanner.SelectAll();
                //DialogResult = DialogResult.Cancel;
            }
        }

        /// <summary>
        /// Проверка сборочного
        /// </summary>
        private void CheckPickSlip()
        {
            
            var success = false;

            if (IsTestVersion)
            {
                var result = (int?)null;
                using (Data.PickControlTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.QueriesTableAdapter())
                    adapter.CheckNeedConfirmTermoAct(UserID, tbScanner.Text, ref result);

                // Необходимость сканирования акта
                if (result.HasValue && result.Value == 1)
                {
                    var dlgActScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте термоакт,\r\nкоторый связан со сборочным:",
                        Text = "Сканирование термоакта",
                        Image = Properties.Resources.cold_chain_icon_75
                    };

                    if (dlgActScanner.ShowDialog() == DialogResult.OK)
                    {
                        var termoActBarCode = dlgActScanner.Barcode;

                        result = (int?)null;
                        using (Data.PickControlTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.QueriesTableAdapter())
                            adapter.CheckTermoAct(UserID, tbScanner.Text, termoActBarCode, DocType, ref result);

                        // Акт подтвержден
                        if (result.HasValue && result.Value == 1)
                            success = true;
                    }
                }
                else
                    success = true;
            }
            else
                success = true;

            if (success)
            {
                using (Data.PickControlTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.QueriesTableAdapter())
                    adapter.CheckPickSlip(tbScanner.Text, UserID, DocType);
            }
            else
                throw new Exception("Акт не был подтвержден.\r\nДокумент контроля не был создан.\r\nДальнейшая обработка прекращена!");
        }
    }
}
