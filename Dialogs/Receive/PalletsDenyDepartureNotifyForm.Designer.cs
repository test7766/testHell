namespace WMSOffice.Dialogs.Receive
{
    partial class PalletsDenyDepartureNotifyForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAction = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.shipmentDeliveryInfoControl = new WMSOffice.Controls.Receive.Pallets.ShipmentDeliveryInfoControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lblAction);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Controls.Add(this.shipmentDeliveryInfoControl);
            this.panel1.Location = new System.Drawing.Point(24, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 286);
            this.panel1.TabIndex = 0;
            // 
            // lblAction
            // 
            this.lblAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAction.Location = new System.Drawing.Point(3, 234);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(495, 42);
            this.lblAction.TabIndex = 2;
            this.lblAction.Text = "ДЕЙСТВИЕ ПОЛЬЗОВАТЕЛЯ НЕОБХОДИМЫЕ ДЛЯ УСТРАНЕНИЯ ОШИБОК";
            this.lblAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMessage.Location = new System.Drawing.Point(3, 162);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(495, 68);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "СООБЩЕНИЕ";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shipmentDeliveryInfoControl1
            // 
            this.shipmentDeliveryInfoControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.shipmentDeliveryInfoControl.BackColor = System.Drawing.Color.Transparent;
            this.shipmentDeliveryInfoControl.Location = new System.Drawing.Point(3, 3);
            this.shipmentDeliveryInfoControl.Name = "shipmentDeliveryInfoControl1";
            this.shipmentDeliveryInfoControl.ReadOnly = true;
            this.shipmentDeliveryInfoControl.Size = new System.Drawing.Size(495, 155);
            this.shipmentDeliveryInfoControl.TabIndex = 0;
            this.shipmentDeliveryInfoControl.UserID = ((long)(0));
            // 
            // PalletsDenyDepartureNotifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(549, 332);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PalletsDenyDepartureNotifyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private WMSOffice.Controls.Receive.Pallets.ShipmentDeliveryInfoControl shipmentDeliveryInfoControl;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblAction;
    }
}