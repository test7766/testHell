namespace WMSOffice.Window
{
    partial class WHDocsActDiscountWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tssAfterRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.cbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.lblPrinter = new System.Windows.Forms.ToolStripLabel();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.btnAddActSelector = new System.Windows.Forms.ToolStripSplitButton();
            this.btnAddAct = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddActPrc = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditAct = new System.Windows.Forms.ToolStripButton();
            this.btnAddManyActs = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteActDiscount = new System.Windows.Forms.ToolStripButton();
            this.tssAfterActEdit = new System.Windows.Forms.ToolStripSeparator();
            this.btnPreviewActDiscount = new System.Windows.Forms.ToolStripButton();
            this.btnPrintActsDiscount = new System.Windows.Forms.ToolStripButton();
            this.btnSendEDoc = new System.Windows.Forms.ToolStripButton();
            this.tssAfterPrint = new System.Windows.Forms.ToolStripSeparator();
            this.btnCloseActDiscount = new System.Windows.Forms.ToolStripButton();
            this.btnChangeActDate = new System.Windows.Forms.ToolStripButton();
            this.dgvActs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.cmsGridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miAddNewAct = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddNewActPrc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteActDiscount = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miPreviewActDiscount = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintActsDiscount = new System.Windows.Forms.ToolStripMenuItem();
            this.miSendEDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miCloseActDiscount = new System.Windows.Forms.ToolStripMenuItem();
            this.miChangeActDate = new System.Windows.Forms.ToolStripMenuItem();
            this.miOriginalReceived = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDoc.SuspendLayout();
            this.cmsGridMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.tssAfterRefresh,
            this.cbPrinters,
            this.lblPrinter,
            this.btnExport,
            this.btnAddActSelector,
            this.btnEditAct,
            this.btnAddManyActs,
            this.btnDeleteActDiscount,
            this.tssAfterActEdit,
            this.btnPreviewActDiscount,
            this.btnPrintActsDiscount,
            this.btnSendEDoc,
            this.tssAfterPrint,
            this.btnCloseActDiscount,
            this.btnChangeActDate});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 40);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(1538, 55);
            this.toolStripDoc.TabIndex = 1;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.ToolTipText = "Обновить таблицу с актами скидок";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tssAfterRefresh
            // 
            this.tssAfterRefresh.Name = "tssAfterRefresh";
            this.tssAfterRefresh.Size = new System.Drawing.Size(6, 55);
            // 
            // cbPrinters
            // 
            this.cbPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrinters.Name = "cbPrinters";
            this.cbPrinters.Size = new System.Drawing.Size(250, 55);
            // 
            // lblPrinter
            // 
            this.lblPrinter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(61, 52);
            this.lblPrinter.Text = "Принтер: ";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(113, 52);
            this.btnExport.Text = "Экспорт в\nExcel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnAddActSelector
            // 
            this.btnAddActSelector.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddAct,
            this.btnAddActPrc});
            this.btnAddActSelector.Image = global::WMSOffice.Properties.Resources.document_new;
            this.btnAddActSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddActSelector.Name = "btnAddActSelector";
            this.btnAddActSelector.Size = new System.Drawing.Size(123, 52);
            this.btnAddActSelector.Text = "Создать...";
            this.btnAddActSelector.ButtonClick += new System.EventHandler(this.btnAddActSelector_ButtonClick);
            // 
            // btnAddAct
            // 
            this.btnAddAct.Image = global::WMSOffice.Properties.Resources.document_new;
            this.btnAddAct.Name = "btnAddAct";
            this.btnAddAct.Size = new System.Drawing.Size(228, 22);
            this.btnAddAct.Text = "новый акт скидки";
            this.btnAddAct.Click += new System.EventHandler(this.btnAddAct_Click);
            // 
            // btnAddActPrc
            // 
            this.btnAddActPrc.Image = global::WMSOffice.Properties.Resources.document_new;
            this.btnAddActPrc.Name = "btnAddActPrc";
            this.btnAddActPrc.Size = new System.Drawing.Size(228, 22);
            this.btnAddActPrc.Text = "новый акт скидки по товару";
            this.btnAddActPrc.Click += new System.EventHandler(this.btnAddActPrc_Click);
            // 
            // btnEditAct
            // 
            this.btnEditAct.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEditAct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditAct.Name = "btnEditAct";
            this.btnEditAct.Size = new System.Drawing.Size(139, 52);
            this.btnEditAct.Text = "Редактировать\nакт скидки";
            this.btnEditAct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditAct.ToolTipText = "Редактировать выбранный в таблице акт скидки";
            this.btnEditAct.Click += new System.EventHandler(this.btnEditAct_Click);
            // 
            // btnAddManyActs
            // 
            this.btnAddManyActs.Image = global::WMSOffice.Properties.Resources.history_review;
            this.btnAddManyActs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddManyActs.Name = "btnAddManyActs";
            this.btnAddManyActs.Size = new System.Drawing.Size(157, 52);
            this.btnAddManyActs.Text = "Массовая вставка\nактов скидок";
            this.btnAddManyActs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddManyActs.Click += new System.EventHandler(this.btnAddManyActs_Click);
            // 
            // btnDeleteActDiscount
            // 
            this.btnDeleteActDiscount.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnDeleteActDiscount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteActDiscount.Name = "btnDeleteActDiscount";
            this.btnDeleteActDiscount.Size = new System.Drawing.Size(117, 52);
            this.btnDeleteActDiscount.Text = "Удалить\nакт скидки";
            this.btnDeleteActDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteActDiscount.Click += new System.EventHandler(this.btnDeleteActDiscount_Click);
            // 
            // tssAfterActEdit
            // 
            this.tssAfterActEdit.Name = "tssAfterActEdit";
            this.tssAfterActEdit.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPreviewActDiscount
            // 
            this.btnPreviewActDiscount.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnPreviewActDiscount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreviewActDiscount.Name = "btnPreviewActDiscount";
            this.btnPreviewActDiscount.Size = new System.Drawing.Size(123, 52);
            this.btnPreviewActDiscount.Text = "Просмотр\nакта скидки";
            this.btnPreviewActDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreviewActDiscount.Click += new System.EventHandler(this.btnPreviewActDiscount_Click);
            // 
            // btnPrintActsDiscount
            // 
            this.btnPrintActsDiscount.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintActsDiscount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintActsDiscount.Name = "btnPrintActsDiscount";
            this.btnPrintActsDiscount.Size = new System.Drawing.Size(131, 52);
            this.btnPrintActsDiscount.Text = "Печать актов\nскидки";
            this.btnPrintActsDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintActsDiscount.Click += new System.EventHandler(this.btnPrintActsDiscount_Click);
            // 
            // btnSendEDoc
            // 
            this.btnSendEDoc.Image = global::WMSOffice.Properties.Resources.upgrade;
            this.btnSendEDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSendEDoc.Name = "btnSendEDoc";
            this.btnSendEDoc.Size = new System.Drawing.Size(117, 52);
            this.btnSendEDoc.Text = "Отправить\nдокумент";
            this.btnSendEDoc.Click += new System.EventHandler(this.btnSendEDoc_Click);
            // 
            // tssAfterPrint
            // 
            this.tssAfterPrint.Name = "tssAfterPrint";
            this.tssAfterPrint.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCloseActDiscount
            // 
            this.btnCloseActDiscount.Image = global::WMSOffice.Properties.Resources.folder_documents;
            this.btnCloseActDiscount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseActDiscount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseActDiscount.Name = "btnCloseActDiscount";
            this.btnCloseActDiscount.Size = new System.Drawing.Size(159, 52);
            this.btnCloseActDiscount.Text = "Журнализировать\nакт скидок";
            this.btnCloseActDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseActDiscount.Click += new System.EventHandler(this.btnCloseActDiscount_Click);
            // 
            // btnChangeActDate
            // 
            this.btnChangeActDate.Image = global::WMSOffice.Properties.Resources.lifetime;
            this.btnChangeActDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChangeActDate.Name = "btnChangeActDate";
            this.btnChangeActDate.Size = new System.Drawing.Size(139, 52);
            this.btnChangeActDate.Text = "Изменить дату\nакта скидки";
            this.btnChangeActDate.Click += new System.EventHandler(this.btnChangeActDate_Click);
            // 
            // dgvActs
            // 
            this.dgvActs.AllowSort = true;
            this.dgvActs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvActs.ContextMenuStrip = this.cmsGridMenu;
            this.dgvActs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActs.LargeAmountOfData = false;
            this.dgvActs.Location = new System.Drawing.Point(0, 95);
            this.dgvActs.Name = "dgvActs";
            this.dgvActs.RowHeadersVisible = false;
            this.dgvActs.Size = new System.Drawing.Size(1538, 250);
            this.dgvActs.TabIndex = 2;
            this.dgvActs.UserID = ((long)(0));
            // 
            // cmsGridMenu
            // 
            this.cmsGridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefresh,
            this.toolStripSeparator1,
            this.miAddNewAct,
            this.miAddNewActPrc,
            this.toolStripSeparator4,
            this.miEdit,
            this.miDeleteActDiscount,
            this.toolStripSeparator2,
            this.miPreviewActDiscount,
            this.miPrintActsDiscount,
            this.miSendEDoc,
            this.toolStripSeparator3,
            this.miCloseActDiscount,
            this.miChangeActDate,
            this.miOriginalReceived});
            this.cmsGridMenu.Name = "cmsGridMenu";
            this.cmsGridMenu.Size = new System.Drawing.Size(329, 292);
            // 
            // miRefresh
            // 
            this.miRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefresh.Size = new System.Drawing.Size(328, 22);
            this.miRefresh.Text = "Обновить";
            this.miRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(325, 6);
            // 
            // miAddNewAct
            // 
            this.miAddNewAct.Image = global::WMSOffice.Properties.Resources.document_new;
            this.miAddNewAct.Name = "miAddNewAct";
            this.miAddNewAct.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.miAddNewAct.Size = new System.Drawing.Size(328, 22);
            this.miAddNewAct.Text = "Создать новый акт скидки";
            this.miAddNewAct.Click += new System.EventHandler(this.btnAddAct_Click);
            // 
            // miAddNewActPrc
            // 
            this.miAddNewActPrc.Image = global::WMSOffice.Properties.Resources.document_new;
            this.miAddNewActPrc.Name = "miAddNewActPrc";
            this.miAddNewActPrc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Insert)));
            this.miAddNewActPrc.Size = new System.Drawing.Size(328, 22);
            this.miAddNewActPrc.Text = "Создать новый акт скидки по товару";
            this.miAddNewActPrc.Click += new System.EventHandler(this.btnAddActPrc_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(325, 6);
            // 
            // miEdit
            // 
            this.miEdit.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.miEdit.Name = "miEdit";
            this.miEdit.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.miEdit.Size = new System.Drawing.Size(328, 22);
            this.miEdit.Text = "Редактировать акт скидки";
            this.miEdit.ToolTipText = "Редактировать выбранный в таблице акт скидки";
            this.miEdit.Click += new System.EventHandler(this.btnEditAct_Click);
            // 
            // miDeleteActDiscount
            // 
            this.miDeleteActDiscount.Image = global::WMSOffice.Properties.Resources.Delete;
            this.miDeleteActDiscount.Name = "miDeleteActDiscount";
            this.miDeleteActDiscount.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.miDeleteActDiscount.Size = new System.Drawing.Size(328, 22);
            this.miDeleteActDiscount.Text = "Удалить акт скидки";
            this.miDeleteActDiscount.Click += new System.EventHandler(this.btnDeleteActDiscount_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(325, 6);
            // 
            // miPreviewActDiscount
            // 
            this.miPreviewActDiscount.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.miPreviewActDiscount.Name = "miPreviewActDiscount";
            this.miPreviewActDiscount.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.miPreviewActDiscount.Size = new System.Drawing.Size(328, 22);
            this.miPreviewActDiscount.Text = "Просмотр акта скдики";
            this.miPreviewActDiscount.Click += new System.EventHandler(this.btnPreviewActDiscount_Click);
            // 
            // miPrintActsDiscount
            // 
            this.miPrintActsDiscount.Image = global::WMSOffice.Properties.Resources.document_print;
            this.miPrintActsDiscount.Name = "miPrintActsDiscount";
            this.miPrintActsDiscount.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.miPrintActsDiscount.Size = new System.Drawing.Size(328, 22);
            this.miPrintActsDiscount.Text = "Печать актов скидки";
            this.miPrintActsDiscount.Click += new System.EventHandler(this.btnPrintActsDiscount_Click);
            // 
            // miSendEDoc
            // 
            this.miSendEDoc.Image = global::WMSOffice.Properties.Resources.upgrade;
            this.miSendEDoc.Name = "miSendEDoc";
            this.miSendEDoc.Size = new System.Drawing.Size(328, 22);
            this.miSendEDoc.Text = "Отправить документ";
            this.miSendEDoc.Click += new System.EventHandler(this.btnSendEDoc_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(325, 6);
            // 
            // miCloseActDiscount
            // 
            this.miCloseActDiscount.Image = global::WMSOffice.Properties.Resources.folder_documents;
            this.miCloseActDiscount.Name = "miCloseActDiscount";
            this.miCloseActDiscount.Size = new System.Drawing.Size(328, 22);
            this.miCloseActDiscount.Text = "Журнализировать акт скидки";
            this.miCloseActDiscount.Click += new System.EventHandler(this.btnCloseActDiscount_Click);
            // 
            // miChangeActDate
            // 
            this.miChangeActDate.Image = global::WMSOffice.Properties.Resources.lifetime;
            this.miChangeActDate.Name = "miChangeActDate";
            this.miChangeActDate.Size = new System.Drawing.Size(328, 22);
            this.miChangeActDate.Text = "Изменить дату акта скидки";
            this.miChangeActDate.Click += new System.EventHandler(this.btnChangeActDate_Click);
            // 
            // miOriginalReceived
            // 
            this.miOriginalReceived.Image = global::WMSOffice.Properties.Resources.accept_16;
            this.miOriginalReceived.Name = "miOriginalReceived";
            this.miOriginalReceived.Size = new System.Drawing.Size(328, 22);
            this.miOriginalReceived.Text = "Оригинал получен";
            this.miOriginalReceived.Click += new System.EventHandler(this.miOriginalReceived_Click);
            // 
            // WHDocsActDiscountWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 345);
            this.Controls.Add(this.dgvActs);
            this.Controls.Add(this.toolStripDoc);
            this.Name = "WHDocsActDiscountWindow";
            this.Text = "WHDocsActDiscountWindow";
            this.Load += new System.EventHandler(this.WHDocsActDiscountWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WHDocsActDiscountWindow_FormClosing);
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.Controls.SetChildIndex(this.dgvActs, 0);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.cmsGridMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripDoc;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvActs;
        private System.Windows.Forms.ContextMenuStrip cmsGridMenu;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator tssAfterRefresh;
        private System.Windows.Forms.ToolStripLabel lblPrinter;
        private System.Windows.Forms.ToolStripComboBox cbPrinters;
        private System.Windows.Forms.ToolStripButton btnEditAct;
        private System.Windows.Forms.ToolStripMenuItem miAddNewAct;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripButton btnAddManyActs;
        private System.Windows.Forms.ToolStripSeparator tssAfterActEdit;
        private System.Windows.Forms.ToolStripButton btnPrintActsDiscount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miPrintActsDiscount;
        private System.Windows.Forms.ToolStripButton btnPreviewActDiscount;
        private System.Windows.Forms.ToolStripMenuItem miPreviewActDiscount;
        private System.Windows.Forms.ToolStripButton btnCloseActDiscount;
        private System.Windows.Forms.ToolStripSeparator tssAfterPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem miCloseActDiscount;
        private System.Windows.Forms.ToolStripButton btnDeleteActDiscount;
        private System.Windows.Forms.ToolStripMenuItem miDeleteActDiscount;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripButton btnChangeActDate;
        private System.Windows.Forms.ToolStripMenuItem miChangeActDate;
        private System.Windows.Forms.ToolStripMenuItem miOriginalReceived;
        private System.Windows.Forms.ToolStripSplitButton btnAddActSelector;
        private System.Windows.Forms.ToolStripMenuItem btnAddAct;
        private System.Windows.Forms.ToolStripMenuItem btnAddActPrc;
        private System.Windows.Forms.ToolStripMenuItem miAddNewActPrc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnSendEDoc;
        private System.Windows.Forms.ToolStripMenuItem miSendEDoc;
    }
}