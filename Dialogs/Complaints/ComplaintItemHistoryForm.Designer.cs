namespace WMSOffice.Dialogs.Complaints
{
    partial class ComplaintItemHistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComplaintItemHistoryForm));
            this.spcMainContainer = new System.Windows.Forms.SplitContainer();
            this.tbVendorLotFact = new System.Windows.Forms.TextBox();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.lblExpirationDateHeader = new System.Windows.Forms.Label();
            this.lblVendorLotFactHeader = new System.Windows.Forms.Label();
            this.lblLotNumber = new System.Windows.Forms.Label();
            this.lblLotNumberHeader = new System.Windows.Forms.Label();
            this.lblVendorLot = new System.Windows.Forms.Label();
            this.lblVendorLotHeader = new System.Windows.Forms.Label();
            this.lblManagerVendor = new System.Windows.Forms.Label();
            this.lblManagerVendorHeader = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.lblVendorHeader = new System.Windows.Forms.Label();
            this.lblManufacturerHeader = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemId = new System.Windows.Forms.Label();
            this.lblItemNameHeader = new System.Windows.Forms.Label();
            this.lblItemIdHeader = new System.Windows.Forms.Label();
            this.lsvStages = new System.Windows.Forms.ListView();
            this.clhStageType = new System.Windows.Forms.ColumnHeader();
            this.clhGroupName = new System.Windows.Forms.ColumnHeader();
            this.clhResult = new System.Windows.Forms.ColumnHeader();
            this.clhComment = new System.Windows.Forms.ColumnHeader();
            this.clhExpirationDate = new System.Windows.Forms.ColumnHeader();
            this.clhEmployees = new System.Windows.Forms.ColumnHeader();
            this.clhDateChanged = new System.Windows.Forms.ColumnHeader();
            this.imlStageResultIcons = new System.Windows.Forms.ImageList(this.components);
            this.lblUserOKHeader = new System.Windows.Forms.Label();
            this.lblUserOK = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.spcMainContainer.Panel1.SuspendLayout();
            this.spcMainContainer.Panel2.SuspendLayout();
            this.spcMainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3701, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3791, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 350);
            this.pnlButtons.Size = new System.Drawing.Size(938, 43);
            // 
            // spcMainContainer
            // 
            this.spcMainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcMainContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcMainContainer.IsSplitterFixed = true;
            this.spcMainContainer.Location = new System.Drawing.Point(0, 0);
            this.spcMainContainer.Name = "spcMainContainer";
            this.spcMainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMainContainer.Panel1
            // 
            this.spcMainContainer.Panel1.Controls.Add(this.lblUserOK);
            this.spcMainContainer.Panel1.Controls.Add(this.lblUserOKHeader);
            this.spcMainContainer.Panel1.Controls.Add(this.tbVendorLotFact);
            this.spcMainContainer.Panel1.Controls.Add(this.lblExpirationDate);
            this.spcMainContainer.Panel1.Controls.Add(this.lblExpirationDateHeader);
            this.spcMainContainer.Panel1.Controls.Add(this.lblVendorLotFactHeader);
            this.spcMainContainer.Panel1.Controls.Add(this.lblLotNumber);
            this.spcMainContainer.Panel1.Controls.Add(this.lblLotNumberHeader);
            this.spcMainContainer.Panel1.Controls.Add(this.lblVendorLot);
            this.spcMainContainer.Panel1.Controls.Add(this.lblVendorLotHeader);
            this.spcMainContainer.Panel1.Controls.Add(this.lblManagerVendor);
            this.spcMainContainer.Panel1.Controls.Add(this.lblManagerVendorHeader);
            this.spcMainContainer.Panel1.Controls.Add(this.lblVendor);
            this.spcMainContainer.Panel1.Controls.Add(this.lblManufacturer);
            this.spcMainContainer.Panel1.Controls.Add(this.lblVendorHeader);
            this.spcMainContainer.Panel1.Controls.Add(this.lblManufacturerHeader);
            this.spcMainContainer.Panel1.Controls.Add(this.lblItemName);
            this.spcMainContainer.Panel1.Controls.Add(this.lblItemId);
            this.spcMainContainer.Panel1.Controls.Add(this.lblItemNameHeader);
            this.spcMainContainer.Panel1.Controls.Add(this.lblItemIdHeader);
            // 
            // spcMainContainer.Panel2
            // 
            this.spcMainContainer.Panel2.Controls.Add(this.lsvStages);
            this.spcMainContainer.Size = new System.Drawing.Size(938, 344);
            this.spcMainContainer.SplitterDistance = 141;
            this.spcMainContainer.TabIndex = 0;
            // 
            // tbVendorLotFact
            // 
            this.tbVendorLotFact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbVendorLotFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbVendorLotFact.Location = new System.Drawing.Point(534, 93);
            this.tbVendorLotFact.Name = "tbVendorLotFact";
            this.tbVendorLotFact.Size = new System.Drawing.Size(120, 20);
            this.tbVendorLotFact.TabIndex = 3;
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblExpirationDate.Location = new System.Drawing.Point(134, 120);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(71, 13);
            this.lblExpirationDate.TabIndex = 12;
            this.lblExpirationDate.Text = "31.02.2011";
            // 
            // lblExpirationDateHeader
            // 
            this.lblExpirationDateHeader.AutoSize = true;
            this.lblExpirationDateHeader.Location = new System.Drawing.Point(12, 120);
            this.lblExpirationDateHeader.Name = "lblExpirationDateHeader";
            this.lblExpirationDateHeader.Size = new System.Drawing.Size(117, 13);
            this.lblExpirationDateHeader.TabIndex = 11;
            this.lblExpirationDateHeader.Text = "Срок годности серии:";
            // 
            // lblVendorLotFactHeader
            // 
            this.lblVendorLotFactHeader.AutoSize = true;
            this.lblVendorLotFactHeader.Location = new System.Drawing.Point(419, 93);
            this.lblVendorLotFactHeader.Name = "lblVendorLotFactHeader";
            this.lblVendorLotFactHeader.Size = new System.Drawing.Size(112, 13);
            this.lblVendorLotFactHeader.TabIndex = 2;
            this.lblVendorLotFactHeader.Text = "Фактическая серия:";
            // 
            // lblLotNumber
            // 
            this.lblLotNumber.AutoSize = true;
            this.lblLotNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLotNumber.Location = new System.Drawing.Point(51, 93);
            this.lblLotNumber.Name = "lblLotNumber";
            this.lblLotNumber.Size = new System.Drawing.Size(84, 13);
            this.lblLotNumber.TabIndex = 9;
            this.lblLotNumber.Text = "15258478885";
            // 
            // lblLotNumberHeader
            // 
            this.lblLotNumberHeader.AutoSize = true;
            this.lblLotNumberHeader.Location = new System.Drawing.Point(12, 93);
            this.lblLotNumberHeader.Name = "lblLotNumberHeader";
            this.lblLotNumberHeader.Size = new System.Drawing.Size(47, 13);
            this.lblLotNumberHeader.TabIndex = 8;
            this.lblLotNumberHeader.Text = "Партия:";
            // 
            // lblVendorLot
            // 
            this.lblVendorLot.AutoSize = true;
            this.lblVendorLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVendorLot.Location = new System.Drawing.Point(458, 65);
            this.lblVendorLot.Name = "lblVendorLot";
            this.lblVendorLot.Size = new System.Drawing.Size(84, 13);
            this.lblVendorLot.TabIndex = 0;
            this.lblVendorLot.Text = "15258478885";
            // 
            // lblVendorLotHeader
            // 
            this.lblVendorLotHeader.AutoSize = true;
            this.lblVendorLotHeader.Location = new System.Drawing.Point(419, 65);
            this.lblVendorLotHeader.Name = "lblVendorLotHeader";
            this.lblVendorLotHeader.Size = new System.Drawing.Size(41, 13);
            this.lblVendorLotHeader.TabIndex = 17;
            this.lblVendorLotHeader.Text = "Серия:";
            // 
            // lblManagerVendor
            // 
            this.lblManagerVendor.AutoSize = true;
            this.lblManagerVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblManagerVendor.Location = new System.Drawing.Point(156, 65);
            this.lblManagerVendor.Name = "lblManagerVendor";
            this.lblManagerVendor.Size = new System.Drawing.Size(158, 13);
            this.lblManagerVendor.TabIndex = 6;
            this.lblManagerVendor.Text = "Петрова Петра Петровна";
            // 
            // lblManagerVendorHeader
            // 
            this.lblManagerVendorHeader.AutoSize = true;
            this.lblManagerVendorHeader.Location = new System.Drawing.Point(12, 65);
            this.lblManagerVendorHeader.Name = "lblManagerVendorHeader";
            this.lblManagerVendorHeader.Size = new System.Drawing.Size(145, 13);
            this.lblManagerVendorHeader.TabIndex = 5;
            this.lblManagerVendorHeader.Text = "Менеджер отдела закупок:";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVendor.Location = new System.Drawing.Point(487, 35);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(172, 13);
            this.lblVendor.TabIndex = 16;
            this.lblVendor.Text = "ООО \"ОптимаФармПостач\"";
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblManufacturer.Location = new System.Drawing.Point(100, 35);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(188, 13);
            this.lblManufacturer.TabIndex = 4;
            this.lblManufacturer.Text = "ООО \"ОптимаФармПроизвод\"";
            // 
            // lblVendorHeader
            // 
            this.lblVendorHeader.AutoSize = true;
            this.lblVendorHeader.Location = new System.Drawing.Point(419, 35);
            this.lblVendorHeader.Name = "lblVendorHeader";
            this.lblVendorHeader.Size = new System.Drawing.Size(68, 13);
            this.lblVendorHeader.TabIndex = 15;
            this.lblVendorHeader.Text = "Поставщик:";
            // 
            // lblManufacturerHeader
            // 
            this.lblManufacturerHeader.AutoSize = true;
            this.lblManufacturerHeader.Location = new System.Drawing.Point(12, 35);
            this.lblManufacturerHeader.Name = "lblManufacturerHeader";
            this.lblManufacturerHeader.Size = new System.Drawing.Size(89, 13);
            this.lblManufacturerHeader.TabIndex = 3;
            this.lblManufacturerHeader.Text = "Производитель:";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemName.Location = new System.Drawing.Point(543, 9);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(144, 13);
            this.lblItemName.TabIndex = 14;
            this.lblItemName.Text = "Наименование товара:";
            // 
            // lblItemId
            // 
            this.lblItemId.AutoSize = true;
            this.lblItemId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemId.Location = new System.Drawing.Point(79, 9);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(56, 13);
            this.lblItemId.TabIndex = 2;
            this.lblItemId.Text = "1258785";
            // 
            // lblItemNameHeader
            // 
            this.lblItemNameHeader.AutoSize = true;
            this.lblItemNameHeader.Location = new System.Drawing.Point(419, 9);
            this.lblItemNameHeader.Name = "lblItemNameHeader";
            this.lblItemNameHeader.Size = new System.Drawing.Size(124, 13);
            this.lblItemNameHeader.TabIndex = 13;
            this.lblItemNameHeader.Text = "Наименование товара:";
            // 
            // lblItemIdHeader
            // 
            this.lblItemIdHeader.AutoSize = true;
            this.lblItemIdHeader.Location = new System.Drawing.Point(12, 9);
            this.lblItemIdHeader.Name = "lblItemIdHeader";
            this.lblItemIdHeader.Size = new System.Drawing.Size(67, 13);
            this.lblItemIdHeader.TabIndex = 0;
            this.lblItemIdHeader.Text = "Код товара:";
            // 
            // lsvStages
            // 
            this.lsvStages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhStageType,
            this.clhGroupName,
            this.clhResult,
            this.clhComment,
            this.clhExpirationDate,
            this.clhEmployees,
            this.clhDateChanged});
            this.lsvStages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvStages.FullRowSelect = true;
            this.lsvStages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvStages.Location = new System.Drawing.Point(0, 0);
            this.lsvStages.Name = "lsvStages";
            this.lsvStages.Size = new System.Drawing.Size(938, 199);
            this.lsvStages.SmallImageList = this.imlStageResultIcons;
            this.lsvStages.TabIndex = 3;
            this.lsvStages.UseCompatibleStateImageBehavior = false;
            this.lsvStages.View = System.Windows.Forms.View.Details;
            // 
            // clhStageType
            // 
            this.clhStageType.Text = "Этап";
            this.clhStageType.Width = 40;
            // 
            // clhGroupName
            // 
            this.clhGroupName.Text = "Группа пользователей";
            this.clhGroupName.Width = 170;
            // 
            // clhResult
            // 
            this.clhResult.Text = "Результат";
            this.clhResult.Width = 120;
            // 
            // clhComment
            // 
            this.clhComment.Text = "Комментарий";
            this.clhComment.Width = 222;
            // 
            // clhExpirationDate
            // 
            this.clhExpirationDate.Text = "Дата просрочки";
            this.clhExpirationDate.Width = 120;
            // 
            // clhEmployees
            // 
            this.clhEmployees.Text = "Сотрудники";
            this.clhEmployees.Width = 250;
            // 
            // clhDateChanged
            // 
            this.clhDateChanged.Text = "Дата изм.";
            this.clhDateChanged.Width = 120;
            // 
            // imlStageResultIcons
            // 
            this.imlStageResultIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlStageResultIcons.ImageStream")));
            this.imlStageResultIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlStageResultIcons.Images.SetKeyName(0, "delete2.png");
            this.imlStageResultIcons.Images.SetKeyName(1, "ok.png");
            this.imlStageResultIcons.Images.SetKeyName(2, "unknown.png");
            this.imlStageResultIcons.Images.SetKeyName(3, "yellow_triangle.png");
            // 
            // lblUserOKHeader
            // 
            this.lblUserOKHeader.AutoSize = true;
            this.lblUserOKHeader.Location = new System.Drawing.Point(419, 120);
            this.lblUserOKHeader.Name = "lblUserOKHeader";
            this.lblUserOKHeader.Size = new System.Drawing.Size(97, 13);
            this.lblUserOKHeader.TabIndex = 13;
            this.lblUserOKHeader.Text = "Автор версии ОК:";
            // 
            // lblUserOK
            // 
            this.lblUserOK.AutoSize = true;
            this.lblUserOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUserOK.Location = new System.Drawing.Point(522, 120);
            this.lblUserOK.Name = "lblUserOK";
            this.lblUserOK.Size = new System.Drawing.Size(158, 13);
            this.lblUserOK.TabIndex = 14;
            this.lblUserOK.Text = "Петрова Петра Петровна";
            // 
            // ComplaintItemHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 393);
            this.Controls.Add(this.spcMainContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(690, 422);
            this.Name = "ComplaintItemHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "История визирования по строке претензии";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComplaintItemHistoryForm_FormClosing);
            this.Controls.SetChildIndex(this.spcMainContainer, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.spcMainContainer.Panel1.ResumeLayout(false);
            this.spcMainContainer.Panel1.PerformLayout();
            this.spcMainContainer.Panel2.ResumeLayout(false);
            this.spcMainContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMainContainer;
        private System.Windows.Forms.ListView lsvStages;
        private System.Windows.Forms.ColumnHeader clhGroupName;
        private System.Windows.Forms.ColumnHeader clhResult;
        private System.Windows.Forms.ColumnHeader clhComment;
        private System.Windows.Forms.ColumnHeader clhExpirationDate;
        private System.Windows.Forms.ColumnHeader clhEmployees;
        private System.Windows.Forms.ColumnHeader clhDateChanged;
        private System.Windows.Forms.ColumnHeader clhStageType;
        private System.Windows.Forms.ImageList imlStageResultIcons;
        private System.Windows.Forms.Label lblItemIdHeader;
        private System.Windows.Forms.Label lblItemId;
        private System.Windows.Forms.Label lblItemNameHeader;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.Label lblVendorHeader;
        private System.Windows.Forms.Label lblManufacturerHeader;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Label lblVendorLot;
        private System.Windows.Forms.Label lblVendorLotHeader;
        private System.Windows.Forms.Label lblManagerVendor;
        private System.Windows.Forms.Label lblManagerVendorHeader;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.Label lblExpirationDateHeader;
        private System.Windows.Forms.Label lblVendorLotFactHeader;
        private System.Windows.Forms.Label lblLotNumber;
        private System.Windows.Forms.Label lblLotNumberHeader;
        private System.Windows.Forms.TextBox tbVendorLotFact;
        private System.Windows.Forms.Label lblUserOKHeader;
        private System.Windows.Forms.Label lblUserOK;
    }
}