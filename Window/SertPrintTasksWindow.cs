using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data.AccessTableAdapters;

namespace WMSOffice.Window
{
    /// <summary>
    /// Диалог для автоматической печати сертификатов по заказам с возможностью поиска в архиве.
    /// </summary>
    public partial class SertPrintTasksWindow : GeneralWindow
    {
        bool showOnlyVaccinesTasks = false;
        public bool ShowOnlyVaccinesTasks
        {
            get { return showOnlyVaccinesTasks; }
            set { Dialogs.Sert.SertPrintingThread.SertPrintingThreadWorkerParameter.PrintOnlyVaccinesTasks = showOnlyVaccinesTasks = value; }
        }

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        public SertPrintTasksWindow()
        {
            InitializeComponent();

            HideHeaderPanel();
        }

        /// <summary>
        /// Проверка печати сертификатов для тяможни АР Крым
        /// </summary>
        private void CheckPrintSert()
        {
            using (var adapter = new LimitedEntityElementsTableAdapter())
            {
                var dt = adapter.HasSertPrint(UserID);
                foreach (WMSOffice.Data.Access.LimitedEntityElementsRow item in dt.Rows)
                    if (item.Entity_Key == "canPrint")
                    {
                        btnDistinctPrint.Visible = true;
                        return;
                    }
            }

            btnDistinctPrint.Visible = false;
        }

        /// <summary>
        /// Признак, показывающий, отображаются ли сейчас результаты поиска (т.е. автообновление списка заказов отключено).
        /// </summary>
        private bool SearchResultsShown { get; set; }

        /// <summary>
        /// Ссылка на диалог прогресса длительных операций.
        /// </summary>
        private Dialogs.SplashForm SplashForm { get; set; }

        /// <summary>
        /// Идентификатор последнего задания с статусом "Error" (ошибка), о котором пользователю было показано сообщение.
        /// </summary>
        private long LastErrorTaskID { get; set; }

        /// <summary>
        /// При первом показе окна проверяет, настроена ли печать сертификатов, и, если не настроена, показывает предупреждение.
        /// </summary>
        private void SertPrintTasksWindow_Shown(object sender, EventArgs e)
        {
            CheckPrintSert();

            using (Data.SertTableAdapters.QueriesTableAdapter adapter = new Data.SertTableAdapters.QueriesTableAdapter())
            {
                try
                {
                    object settings = adapter.GetSettings(Environment.MachineName);
                    if (settings != null)
                    {
                        Dialogs.Sert.SertPrintSettings.ParseXML(settings.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Печать сертификатов не настраивалась ранее на текущем компьютере. Откройте диалог настроек и введите нужные параметры.",
                            "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("При загрузке настроек возникла следующая ошибка:" + Environment.NewLine +
                       ex1.Message + Environment.NewLine + Environment.NewLine + "Рекомендуется открыть диалог настроек и изменить их вручную.",
                       "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Dialogs.Sert.SertPrintingThread.UserID = UserID;
            LastErrorTaskID = 0;

            toolStripDoc.Items.Insert(1, new ToolStripSeparator());
            var tip = "Настройка фильтра заданий\r\nпечати сертификатов по вакцинам";
            toolStripDoc.Items.Insert(2, new ToolStripLabel(Properties.Resources.filter) { ToolTipText = tip });
            var chbShowVaccinesTasks = new CheckBox() { Text = "Вакцины", CheckAlign = ContentAlignment.MiddleRight };
            chbShowVaccinesTasks.CheckStateChanged += (s, ea) => 
            {
                ShowOnlyVaccinesTasks = chbShowVaccinesTasks.Checked;
                btnRefresh_Click(btnRefresh, EventArgs.Empty);
            };
            toolStripDoc.Items.Insert(3, new ToolStripControlHost(chbShowVaccinesTasks) { ToolTipText = tip });

            refreshCurrentInfoTimer_Tick(this, EventArgs.Empty);
            refreshCurrentInfoTimer.Enabled = true;

            btnRefresh_Click(this, EventArgs.Empty);
            refreshDataTimer.Enabled = true;
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Обновить список нераспечатанных заказов".
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SearchResultsShown = false;
            btnPrintSelected.Enabled = false;
            tasksTableAdapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
            tasksTableAdapter.Fill(sert.Tasks, UserID, null, (double?)null, null, (double?)null, false, ShowOnlyVaccinesTasks);
        }

        /// <summary>
        /// В момент окончания привязки данных к табличному представлению меняет расцветку строк согласно цветам в легенде.
        /// </summary>
        private void dgvTasks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgvTasks.Rows)
            {
                Data.Sert.TasksRow row = (Data.Sert.TasksRow)((DataRowView)r.DataBoundItem).Row;
                if (row.TaskStateID == 2)
                {
                    if (!row.IsProcessingSessionIDNull() && row.ProcessingSessionID == UserID)
                        r.DefaultCellStyle.BackColor = pnlLegendThisComp.BackColor;
                    else if (!row.IsProcessingSessionIDNull())
                        r.DefaultCellStyle.BackColor = pnlLegendOtherComp.BackColor;
                }
                else if (row.TaskStateID == 4)
                {
                    r.DefaultCellStyle.BackColor = pnlLegendError.BackColor;
                }
                if (r.Selected)
                {
                    r.Selected = false;
                }
            }
            dgvTasks.Refresh();

            if (!SearchResultsShown)
                lblTasksCount.Text = dgvTasks.Rows.Count.ToString();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Запустить / остановить автоматическую печать".
        /// </summary>
        private void btnStartStopAutoPrint_Click(object sender, EventArgs e)
        {
            BackgroundWorker workerStartStopAutoPrint = new BackgroundWorker();
            workerStartStopAutoPrint.DoWork += new DoWorkEventHandler(workerStartStopAutoPrint_DoWork);
            workerStartStopAutoPrint.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerStartStopAutoPrint_RunWorkerCompleted);
            if (btnStartStopAutoPrint.Text.Contains("Запустить"))
            {
                workerStartStopAutoPrint.RunWorkerAsync(true);
            }
            else
            {
                workerStartStopAutoPrint.RunWorkerAsync(false);
            }
            using (SplashForm = new WMSOffice.Dialogs.SplashForm())
            {
                SplashForm.ActionText = btnStartStopAutoPrint.Text.Contains("Запустить") ? "Запуск автоматической печати..." : "Остановка автоматической печати...";
                SplashForm.ShowDialog();
            }
        }

        /// <summary>
        /// Запускает или останавливает автоматическую печать в фоновом потоке.
        /// </summary>
        private void workerStartStopAutoPrint_DoWork(object sender, DoWorkEventArgs e)
        {
            if ((bool)e.Argument)
            {
                Dialogs.Sert.SertPrintingThread.StartAutoPrint();
            }
            else
            {
                Dialogs.Sert.SertPrintingThread.StopAutoPrint();
            }
            System.Threading.Thread.Sleep(500);
        }

        /// <summary>
        /// Обновляет состояние кнопки запуска автоматической печати после выполнения действия в фоновом потоке.
        /// </summary>
        private void workerStartStopAutoPrint_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            refreshCurrentInfoTimer_Tick(this, EventArgs.Empty);
            if (SplashForm != null)
            {
                SplashForm.CloseForce();
                SplashForm = null;
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Поиск заказа в архиве".
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (Dialogs.Sert.SertSearchPrintedOrderForm form = new Dialogs.Sert.SertSearchPrintedOrderForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    SearchResultsShown = true;
                    btnPrintSelected.Enabled = true;
                    tasksTableAdapter.Fill(sert.Tasks, UserID, form.DCTO, form.DOCO, form.DCT, form.DOC, form.OnlyNds, ShowOnlyVaccinesTasks);
                    if (sert.Tasks.Rows.Count == 0 && MessageBox.Show(
                        "Заказ с указанным типом и номером не найден." + Environment.NewLine +
                        "Хотите добавить новое задание по указанному типу и номеру заказа?",
                        "Заказ не найден", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tasksTableAdapter.FillByTryCreateTask(sert.Tasks, UserID, form.DCTO, form.DOCO, form.DCT, form.DOC);
                        if (sert.Tasks.Rows.Count > 0)
                        {
                            MessageBox.Show("Заказ найден, задание создано.",
                                "Создание нового задания", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Заказ не найден.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Напечатать выбранный заказ" (только для заказов, найденных в архиве).
        /// </summary>
        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            if (Dialogs.Sert.SertPrintingThread.AutoPrintStarted)
            {
                MessageBox.Show("Перед печатью архивного заказа рекомендуется остановить автоматическую печать.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dgvTasks.SelectedRows.Count == 1)
            {
                Data.Sert.TasksRow row = (Data.Sert.TasksRow)((DataRowView)dgvTasks.SelectedRows[0].DataBoundItem).Row;
                BackgroundWorker workerPrintSelected = new BackgroundWorker();
                workerPrintSelected.DoWork += new DoWorkEventHandler(workerPrintSelected_DoWork);
                workerPrintSelected.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerPrintSelected_RunWorkerCompleted);
                workerPrintSelected.RunWorkerAsync(row);
                using (SplashForm = new WMSOffice.Dialogs.SplashForm() { ActionText = "Печать выбранного заказа..." })
                {
                    SplashForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Заказ не выбран.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Запускает печать выбранного заказа в фоновом потоке.
        /// </summary>
        private void workerPrintSelected_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Dialogs.Sert.SertPrintingThread thread = new Dialogs.Sert.SertPrintingThread();
                thread.Run((Data.Sert.TasksRow)e.Argument, true);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Обрабатывает завершение печати выбранного заказа в фоновом потоке.
        /// </summary>
        private void workerPrintSelected_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (SplashForm != null)
            {
                SplashForm.CloseForce();
                SplashForm = null;
            }
            if (e.Result is Exception)
            {
                MessageBox.Show("Во время печати архивного задания возникла следующая ошибка:" + Environment.NewLine + Environment.NewLine +
                    (e.Result as Exception).ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Настройки".
        /// </summary>
        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (Dialogs.Sert.SertPrintSettingsForm form = new Dialogs.Sert.SertPrintSettingsForm(UserID))
                form.ShowDialog();
        }

        /// <summary>
        /// Обновляет список заданий при срабатывании таймера.
        /// </summary>
        private void refreshDataTimer_Tick(object sender, EventArgs e)
        {
            if (!SearchResultsShown)
                btnRefresh_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Обновляет текущую информацию о задании автоматической печати при срабатывании таймера.
        /// </summary>
        private void refreshCurrentInfoTimer_Tick(object sender, EventArgs e)
        {
            if (Dialogs.Sert.SertPrintingThread.AutoPrintStarted)
            {
                btnStartStopAutoPrint.Text = btnStartStopAutoPrint.Text.Replace("Запустить", "Остановить");
                btnStartStopAutoPrint.Image = Properties.Resources.stop;
            }
            else
            {
                btnStartStopAutoPrint.Text = btnStartStopAutoPrint.Text.Replace("Остановить", "Запустить");
                btnStartStopAutoPrint.Image = Properties.Resources.start;
            }

            if (Dialogs.Sert.SertPrintingThread.CurrentPrintingThread != null)
            {
                switch (Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.TaskState)
                {
                    case Dialogs.Sert.SertPrintTaskStates.None:
                        lblTaskState.Text = "-";
                        break;
                    case Dialogs.Sert.SertPrintTaskStates.TasksNotFound:
                        lblTaskState.Text = "нет заданий";
                        break;
                    case Dialogs.Sert.SertPrintTaskStates.Processing:
                        lblTaskState.Text = "обработка";
                        break;
                    case Dialogs.Sert.SertPrintTaskStates.Successful:
                        lblTaskState.Text = "обработано";
                        break;
                    case Dialogs.Sert.SertPrintTaskStates.Error:
                        lblTaskState.Text = "ошибка!";
                        if (LastErrorTaskID != Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.TaskID)
                        {
                            System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\log2.txt", "TaskID: " + Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.TaskID.ToString() + Environment.NewLine);
                            System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\log2.txt", "LastErrorTaskID: " + LastErrorTaskID.ToString() + Environment.NewLine);
                            System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\log2.txt", "ErrorMessage: " + Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.ErrorMessage + Environment.NewLine);
                            System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\log2.txt", Environment.NewLine);
                            LastErrorTaskID = Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.TaskID;
                            MessageBox.Show(string.Format("Во время выполнения текущего задания (TaskID - {0}, номер заказа - {1}) возникла следующая ошибка:\r\n{2}\r\n\r\nАвтоматическая обработка заданий остановлена.",
                                Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.TaskID,
                                Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.DocNumber,
                                Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.ErrorMessage),
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        break;
                }
                lblTaskID.Text = Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.TaskID.ToString();
                lblOrderNumber.Text = Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.DocNumber;
                lblCustomerName.Text = Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.CustomerCodeAndName;

                if (Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.TaskState == WMSOffice.Dialogs.Sert.SertPrintTaskStates.Error &&
                    LastErrorTaskID != Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.TaskID)
                {
                    LastErrorTaskID = Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.TaskID;
                    MessageBox.Show(string.Format("Во время выполнения текущего задания (TaskID - {0}, номер заказа - {1}) возникла следующая ошибка:\r\n{2}\r\n\r\nАвтоматическая обработка заданий остановлена.",
                        Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.TaskID,
                        Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.DocNumber,
                        Dialogs.Sert.SertPrintingThread.CurrentPrintingThread.ErrorMessage),
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnDistinctPrint_Click(object sender, EventArgs e)
        {
            var frm = new WMSOffice.Dialogs.Sert.SertPrintDateForm() { Owner = this };
            if (frm.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (var adapter = new WMSOffice.Data.SertTableAdapters.TasksTableAdapter())
                    adapter.CreatePrintTaskFor07(frm.SelectedDate.Date, 1, 0);

                MessageBox.Show("Задача печати сертификатов создана.", "Печать для таможни", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException ?? ex;
                MessageBox.Show(ex.Message, "Ошибка создания задачи печати!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
