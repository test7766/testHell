using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using WMSOffice.Controls;
using WMSOffice.Dialogs.Complaints;
using WMSOffice.Data.WHTableAdapters;
using WMSOffice.Data.WFTableAdapters;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Timers;

namespace WMSOffice.Window.WriteOff
{
    public partial class AccountDisposalForm : Form
    {
        #region Вспомогательные классы

        /// <summary>
        /// Provides static methods to read system icons for both folders and files.
        /// </summary>
        /// <example>
        /// <code>IconReader.GetFileIcon("c:\\general.xls");</code>
        /// </example>
        public class IconReader
        {
            /// <summary>
            /// Options to specify the size of icons to return.
            /// </summary>
            public enum IconSize
            {
                /// <summary>
                /// Specify large icon - 32 pixels by 32 pixels.
                /// </summary>
                Large = 0,
                /// <summary>
                /// Specify small icon - 16 pixels by 16 pixels.
                /// </summary>
                Small = 1
            }

            /// <summary>
            /// Options to specify whether folders should be in the open or closed state.
            /// </summary>
            public enum FolderType
            {
                /// <summary>
                /// Specify open folder.
                /// </summary>
                Open = 0,
                /// <summary>
                /// Specify closed folder.
                /// </summary>
                Closed = 1
            }

            /// <summary>
            /// Returns an icon for a given file - indicated by the name parameter.
            /// </summary>
            /// <param name="name">Pathname for file.</param>
            /// <param name="size">Large or small</param>
            /// <param name="linkOverlay">Whether to include the link icon</param>
            /// <returns>System.Drawing.Icon</returns>
            public static System.Drawing.Icon GetFileIcon(string name, IconSize size, bool linkOverlay)
            {
                Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
                uint flags = Shell32.SHGFI_ICON | Shell32.SHGFI_USEFILEATTRIBUTES;

                if (true == linkOverlay) flags += Shell32.SHGFI_LINKOVERLAY;

                /* Check the size specified for return. */
                if (IconSize.Small == size)
                {
                    flags += Shell32.SHGFI_SMALLICON;
                }
                else
                {
                    flags += Shell32.SHGFI_LARGEICON;
                }

                Shell32.SHGetFileInfo(name,
                    Shell32.FILE_ATTRIBUTE_NORMAL,
                    ref shfi,
                    (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                    flags);

                // Copy (clone) the returned icon to a new object, thus allowing us to clean-up properly
                System.Drawing.Icon icon = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(shfi.hIcon).Clone();
                User32.DestroyIcon(shfi.hIcon);		// Cleanup
                return icon;
            }

            /// <summary>
            /// Used to access system folder icons.
            /// </summary>
            /// <param name="size">Specify large or small icons.</param>
            /// <param name="folderType">Specify open or closed FolderType.</param>
            /// <returns>System.Drawing.Icon</returns>
            public static System.Drawing.Icon GetFolderIcon(IconSize size, FolderType folderType)
            {
                // Need to add size check, although errors generated at present!
                uint flags = Shell32.SHGFI_ICON | Shell32.SHGFI_USEFILEATTRIBUTES;

                if (FolderType.Open == folderType)
                {
                    flags += Shell32.SHGFI_OPENICON;
                }

                if (IconSize.Small == size)
                {
                    flags += Shell32.SHGFI_SMALLICON;
                }
                else
                {
                    flags += Shell32.SHGFI_LARGEICON;
                }

                // Get the folder icon
                Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
                Shell32.SHGetFileInfo(null,
                    Shell32.FILE_ATTRIBUTE_DIRECTORY,
                    ref shfi,
                    (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                    flags);

                System.Drawing.Icon.FromHandle(shfi.hIcon);	// Load the icon from an HICON handle

                // Now clone the icon, so that it can be successfully stored in an ImageList
                System.Drawing.Icon icon = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(shfi.hIcon).Clone();

                User32.DestroyIcon(shfi.hIcon);		// Cleanup
                return icon;
            }
        }

        /// <summary>
        /// Wraps necessary Shell32.dll structures and functions required to retrieve Icon Handles using SHGetFileInfo. Code
        /// courtesy of MSDN Cold Rooster Consulting case study.
        /// </summary>
        /// 

        // This code has been left largely untouched from that in the CRC example. The main changes have been moving
        // the icon reading code over to the IconReader type.
        public class Shell32
        {

            public const int MAX_PATH = 256;
            [StructLayout(LayoutKind.Sequential)]
            public struct SHITEMID
            {
                public ushort cb;
                [MarshalAs(UnmanagedType.LPArray)]
                public byte[] abID;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct ITEMIDLIST
            {
                public SHITEMID mkid;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct BROWSEINFO
            {
                public IntPtr hwndOwner;
                public IntPtr pidlRoot;
                public IntPtr pszDisplayName;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string lpszTitle;
                public uint ulFlags;
                public IntPtr lpfn;
                public int lParam;
                public IntPtr iImage;
            }

            // Browsing for directory.
            public const uint BIF_RETURNONLYFSDIRS = 0x0001;
            public const uint BIF_DONTGOBELOWDOMAIN = 0x0002;
            public const uint BIF_STATUSTEXT = 0x0004;
            public const uint BIF_RETURNFSANCESTORS = 0x0008;
            public const uint BIF_EDITBOX = 0x0010;
            public const uint BIF_VALIDATE = 0x0020;
            public const uint BIF_NEWDIALOGSTYLE = 0x0040;
            public const uint BIF_USENEWUI = (BIF_NEWDIALOGSTYLE | BIF_EDITBOX);
            public const uint BIF_BROWSEINCLUDEURLS = 0x0080;
            public const uint BIF_BROWSEFORCOMPUTER = 0x1000;
            public const uint BIF_BROWSEFORPRINTER = 0x2000;
            public const uint BIF_BROWSEINCLUDEFILES = 0x4000;
            public const uint BIF_SHAREABLE = 0x8000;

            [StructLayout(LayoutKind.Sequential)]
            public struct SHFILEINFO
            {
                public const int NAMESIZE = 80;
                public IntPtr hIcon;
                public int iIcon;
                public uint dwAttributes;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
                public string szDisplayName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NAMESIZE)]
                public string szTypeName;
            };

            public const uint SHGFI_ICON = 0x000000100;     // get icon
            public const uint SHGFI_DISPLAYNAME = 0x000000200;     // get display name
            public const uint SHGFI_TYPENAME = 0x000000400;     // get type name
            public const uint SHGFI_ATTRIBUTES = 0x000000800;     // get attributes
            public const uint SHGFI_ICONLOCATION = 0x000001000;     // get icon location
            public const uint SHGFI_EXETYPE = 0x000002000;     // return exe type
            public const uint SHGFI_SYSICONINDEX = 0x000004000;     // get system icon index
            public const uint SHGFI_LINKOVERLAY = 0x000008000;     // put a link overlay on icon
            public const uint SHGFI_SELECTED = 0x000010000;     // show icon in selected state
            public const uint SHGFI_ATTR_SPECIFIED = 0x000020000;     // get only specified attributes
            public const uint SHGFI_LARGEICON = 0x000000000;     // get large icon
            public const uint SHGFI_SMALLICON = 0x000000001;     // get small icon
            public const uint SHGFI_OPENICON = 0x000000002;     // get open icon
            public const uint SHGFI_SHELLICONSIZE = 0x000000004;     // get shell size icon
            public const uint SHGFI_PIDL = 0x000000008;     // pszPath is a pidl
            public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;     // use passed dwFileAttribute
            public const uint SHGFI_ADDOVERLAYS = 0x000000020;     // apply the appropriate overlays
            public const uint SHGFI_OVERLAYINDEX = 0x000000040;     // Get the index of the overlay

            public const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
            public const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;

            [DllImport("Shell32.dll")]
            public static extern IntPtr SHGetFileInfo(
                string pszPath,
                uint dwFileAttributes,
                ref SHFILEINFO psfi,
                uint cbFileInfo,
                uint uFlags
                );
        }

        /// <summary>
        /// Wraps necessary functions imported from User32.dll. Code courtesy of MSDN Cold Rooster Consulting example.
        /// </summary>
        public class User32
        {
            /// <summary>
            /// Provides access to function required to delete handle. This method is used internally
            /// and is not required to be called separately.
            /// </summary>
            /// <param name="hIcon">Pointer to icon handle.</param>
            /// <returns>N/A</returns>
            [DllImport("User32.dll")]
            public static extern int DestroyIcon(IntPtr hIcon);
        }

        #endregion

        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Таймер, который отвечает за то, чтобы фильтрация проихсодила не сразу после изменения
        /// фильтра, а спустя некоторое время
        /// </summary>
        private System.Timers.Timer filterTimer = new System.Timers.Timer(1000);

        DataGridViewHeaderCheckBoxCell cbHeader;
        long sessionId;

        bool allowChecked = true;

        public AccountDisposalForm(long userID)
        {
            InitializeComponent();

            sessionId = userID;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Initialize();

            dataGridView1.AutoGenerateColumns = false;
            cbHeader = new DataGridViewHeaderCheckBoxCell();
            cbHeader.Value = null;
            isCheckedDataGridViewCheckBoxColumn.HeaderCell = cbHeader;
            cbHeader.OnCheckBoxClicked += checkHeaderCell_OnCheckBoxClicked;

            var filterTypeID = (int?)null;
            this.LoadRequests(filterTypeID);

            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);

            //dataGridView1.Sort(clmCheck, ListSortDirection.Ascending);

            var contractorID = (int?)null;
            var contractID = (long?)null;
            using (var adapter = new WF_Get_Destruction_RequestsTableAdapter())
                adapter.ApplyActiveContractor(sessionId, ref contractorID, ref contractID);

            stbPartner.UserID = sessionId;
            stbPartner.ValueReferenceQuery = "[dbo].[pr_WF_GetContractor]";

            if (contractorID.HasValue)
                stbPartner.SetValueByDefault(contractorID.Value.ToString());
            //stbPartner.SetValueByDefault("383765");

            stbContract.UserID = sessionId;
            stbContract.ValueReferenceQuery = "[dbo].[pr_WF_GetContract]";

            if (contractID.HasValue)
                stbContract.SetValueByDefault(contractID.Value.ToString());
            //stbContract.SetValueByDefault("4043071");
        }

        private void LoadRequests(int? filterTypeID)
        {
            try
            {
                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += (s, e) =>
                {
                    try
                    {
                        using (var adapter = new WF_Get_Destruction_RequestsTableAdapter())
                          e.Result = adapter.GetDataWithoutInv(sessionId, filterTypeID ?? 0);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                loadWorker.RunWorkerCompleted += (s, e) => 
                {
                    waitProgressForm.CloseForce();
                    
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        wFGetDestructionRequestsBindingSource.DataSource = e.Result;
                        wH.WF_Get_Destruction_Requests.Merge(e.Result as Data.WH.WF_Get_Destruction_RequestsDataTable);
                    }
                };
                waitProgressForm.ActionText = "Выполняется загрузка заявок..";
                
                wFGetDestructionRequestsBindingSource.DataSource = null;
                wH.WF_Get_Destruction_Requests.Clear();

                loadWorker.RunWorkerAsync();
                waitProgressForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Initialize()
        {
            wF.VatRate.AddVatRateRow(20, 0.2, 1.2, "20%");
            wF.VatRate.AddVatRateRow(7, 0.07, 1.07, "7%");

            cmbVATRate.SelectedValue = wF.VatRate[0].Ratio;

            var tip = new ToolTip();
            tip.SetToolTip(btnClearFilter, "Очистить фильтр по номеру заявки / счета");

            filterTimer.Elapsed += filterTimer_Elapsed;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (DialogResult != DialogResult.OK)
                return;

            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Необходимо указать номер счета!", "Ошибка...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            if (listView.Items.Count == 0)
            {
                MessageBox.Show("Необходимо прикрепить файл счета!", "Ошибка...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            try
            {
                string appCodes = String.Empty;
                List<int> requests = new List<int>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (chk.Value == null)
                        continue;

                    bool _checked = false;
                    if (chk.Value == null || !Boolean.TryParse(chk.Value.ToString(), out _checked) || !_checked)
                        continue;

                    int _id = int.MinValue;

                    if (!int.TryParse(row.Cells[1].Value.ToString(), out _id))
                        continue;

                    appCodes += string.IsNullOrEmpty(appCodes) ? String.Format("{0}", _id) : String.Format("; {0}", _id);
                    requests.Add(_id);
                }

                var reportStream = CreateReport(requests);

                byte[] buffer = null;
                string ext = string.Empty;
                int size = -1;
                string invoiceNum = textBox1.Text;
                DateTime invoiceDate = dateTimePicker1.Value;
                int orgCode = Int32.Parse(stbPartner.Value);
                int contrCode = Int32.Parse(stbContract.Value);

                double sumWithoutVAT = (double)nudSumWithoutVAT.Value;
                double sumWithVAT = (double)nudSumWithVAT.Value;
                var vatRate = Convert.ToDouble(cmbVATRate.SelectedValue);

                using (var adapter = new WFTableAdapter())
                {
                    if (listView.Items.Count > 0)
                    {
                        var item = listView.Items[0];
                        var filePath = item.Name;
                        var fi = new FileInfo(filePath);
                        if (!fi.Exists)
                            throw new FileNotFoundException(String.Format("Файл \"{0}\" не найден.", filePath));

                        using (var fs = new FileStream(filePath, FileMode.Open))
                        {
                            size = (int)fs.Length;
                            ext = fi.Extension.Replace(".", String.Empty).ToUpper();

                            var br = new BinaryReader(fs);
                            buffer = br.ReadBytes(size);
                            fs.Close();
                        }
                    }

                    adapter.AddIncomInvoiceEdoc(buffer, ext, sessionId, size, invoiceNum, invoiceDate, orgCode, contrCode, sumWithVAT, appCodes, reportStream, reportStream == null? (int?)null: (int?)reportStream.Length, vatRate, sumWithoutVAT);

                    foreach (var item in requests)
                        adapter.SetInvoice((int)sessionId, item, invoiceDate, invoiceNum, (decimal)sumWithoutVAT);
                }

                e.Cancel = false;

                MessageBox.Show(String.Format("Счет №{0} сохранен.{1}Создана карточка «Входящие счета на оплату» в СЭД Directum.", invoiceNum, Environment.NewLine), "Сохранение...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException ?? ex;
                MessageBox.Show(msg.Message, "Ошибка...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;

            var _count = dataGridView1.Rows.Count;
            var curRow = dataGridView1.Rows[e.RowIndex] as DataGridViewRow;
            int selected = 0;

            dataGridView1.BeginEdit(false);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];

                if (curRow.Equals(row))
                    row.Cells[0].Value = chk.Value;


                if (chk.Value != null && chk.Value.Equals(bool.TrueString))
                    selected++;
            }

            allowChecked = false;
            cbHeader.Select(selected == _count);
            allowChecked = true;
            dataGridView1.EndEdit();
        }

        void checkHeaderCell_OnCheckBoxClicked(bool pState)
        {
            if (!allowChecked)
                return;

            dataGridView1.BeginEdit(false);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var _row = ((DataRowView)row.DataBoundItem).Row as WMSOffice.Data.WH.WF_Get_Destruction_RequestsRow;
                if (_row == null)
                    continue;

                row.Cells[0].Value = pState.ToString();
                //_row.isChecked = pState;
            }
            dataGridView1.EndEdit();
            dataGridView1.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Multiselect = false };
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;

            listView.Clear();

            var fileName = ofd.FileName;
            {
                imageList.Images.Add(IconReader.GetFileIcon(fileName, IconReader.IconSize.Large, false));

                var imageId = imageList.Images.Count - 1;

                var fi = new FileInfo(fileName);

                var existItem = listView.FindItemWithText(fi.Name);

                if (existItem != null)
                {
                    string msg = String.Format("Файл с именем \"{0}\" уже существует.{1}Заменить существующий файл?", fi.Name, Environment.NewLine);

                    if (MessageBox.Show(msg, "Открыть...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    existItem.Text = fi.Name;
                    existItem.Name = fi.FullName;
                    existItem.Tag = fi;
                }
                else
                {
                    var item = listView.Items.Add(fi.FullName, fi.Name, imageId);
                    item.Tag = fi;
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
                return;

            if (MessageBox.Show("Удалить выбранные эдементы?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var selItems = listView.SelectedItems;

            foreach (ListViewItem item in selItems)
                listView.Items.Remove(item);
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {

        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
                btnDel.Enabled = listView.SelectedItems[0].Tag != null;
        }

        private void stbPartner_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            stbPartner.Value = e.Success ? e.Value : null;
            textBox2.Text = e.Success ? e.Description : String.Empty;

            stbContract.ClearAdditionalParameters();
            stbContract.ApplyAdditionalParameter(e.Success ? e.Value : null);

            stbContract.Value = null;
            textBox3.Text = String.Empty;
        }

        private void stbContract_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            stbContract.Value = e.Success ? e.Value : null;
            textBox3.Text = e.Success ? e.Description : String.Empty;
        }

        private void rbFilterType_CheckedChenged(object sender, EventArgs e)
        {
            var filterTypeID = rbNotProcessed.Checked ? 0 : 1;
            this.LoadRequests(filterTypeID);
        }

        private void chbShowSelected_CheckedChanged(object sender, EventArgs e)
        {
            filterTimer.Stop();
            this.RefreshFilter();
        }

        private byte[] CreateReport(List<int> requests)
        {
            if (requests == null || requests.Count == 0)
                return null;

            MemoryStream stream = new MemoryStream(Properties.Resources.WF_ReportTemp);

            XSSFWorkbook templateWorkbook = new XSSFWorkbook(stream);
            var sheet = templateWorkbook.GetSheet("Лист1");

            requests.Sort();

            int rowNum = 4;

            using (var adapter = new Data.WFTableAdapters.wf_get_report_dest_requestTableAdapter())
                foreach (var item in requests)
                {
                    var retData = adapter.GetData(item);
                    foreach (var itemRow in retData.Rows)
                    {
                        var r = itemRow as Data.WF.wf_get_report_dest_requestRow;
                        if (r == null)
                            continue;
                        IRow row = sheet.CreateRow(rowNum);

                        if (!r.Isrequest_idNull()) // Номер заявки
                            row.CreateCell(0).SetCellValue(r.request_id);

                        if (!r.Isvend_nameNull()) // Поставщик
                            row.CreateCell(1).SetCellValue(r.vend_name);

                        if (!r.Isitm_dscNull()) // Наименование товара
                            row.CreateCell(2).SetCellValue(r.itm_dsc);

                        if (!r.Iswf_type_dscNull()) // Тип списания
                            row.CreateCell(3).SetCellValue(r.wf_type_dsc);

                        if (!r.Iscomp_type_dscNull()) // Компенсация
                            row.CreateCell(4).SetCellValue(r.comp_type_dsc);

                        if (!r.IscurrencyNull()) // Валюта
                            row.CreateCell(5).SetCellValue(r.currency);

                        if (!r.IsquantityNull()) // Количество
                            row.CreateCell(6).SetCellValue((double)r.quantity);

                        if (!r.IsweightNull()) // Вес по строке, кг
                            row.CreateCell(7).SetCellValue((double)r.weight);

                        if (!r.Iscomp_calcNull()) // Сумма компенсации рассчитанная
                            row.CreateCell(8).SetCellValue((double)r.comp_calc);

                        if (!r.Iscomp_receivedNull()) // Сумма компенсации полученная
                            row.CreateCell(9).SetCellValue((double)r.comp_received);

                        if (!r.Iscomp_restNull()) // Сумма компенсации к получению после утилизации
                            row.CreateCell(10).SetCellValue((double)r.comp_rest);

                        rowNum++;
                    }
                }


            MemoryStream file = new MemoryStream();
            templateWorkbook.Write(file);

            var buffer = file.GetBuffer();

            file.Flush();
            file.Close();
            file.Dispose();

            stream.Close();
            stream.Dispose();

            return buffer;
        }

        private void cmbVATRate_SelectedValueChanged(object sender, EventArgs e)
        {
            RecalcSumWithVAT();
        }

        private void nudSumWithoutVAT_ValueChanged(object sender, EventArgs e)
        {
            RecalcSumWithVAT();
        }

        private void RecalcSumWithVAT()
        {
            try
            {
                nudSumWithVAT.Value = nudSumWithoutVAT.Value * Convert.ToDecimal(cmbVATRate.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            tbFilter.Clear();
            filterTimer.Stop();
            this.RefreshFilter();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            filterTimer.Stop();
            filterTimer.Start();
        }

        private void RefreshFilter()
        {
            if (wH.WF_Get_Destruction_Requests == null)
                return;

            var filterNumber = tbFilter.Text.Trim();
            var filterNumberExpression = !string.IsNullOrEmpty(filterNumber) ? string.Format("AND ( CONVERT({0}, 'System.String') LIKE '%{2}%' OR {1} LIKE '%{2}%' )", wH.WF_Get_Destruction_Requests.request_numberColumn.Caption, wH.WF_Get_Destruction_Requests.invoice_numberColumn.Caption, filterNumber) : string.Empty;

            var filterSelectorExpression = chbShowSelected.Checked ? string.Format("AND ( {0} = 'True' )", wH.WF_Get_Destruction_Requests.isCheckedColumn.Caption) : string.Empty;

            wFGetDestructionRequestsBindingSource.Filter = string.Format("1=1 {0} {1}", filterNumberExpression, filterSelectorExpression);

            dataGridView1.Refresh();
        }

        private void timerFilter_Tick(object sender, EventArgs e)
        {
            this.RefreshFilter();
        }

        /// <summary>
        /// Делегат для асинхронного вызова фильтрации
        /// </summary>
        private delegate void Method();

        /// <summary>
        /// Если прошло достаточно времени с момента последнего редактирования фильтра, запускается фильтрация
        /// </summary>
        private void filterTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            filterTimer.Stop();
            dataGridView1.Invoke(new Method(RefreshFilter));
        }
    }
}
