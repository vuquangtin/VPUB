namespace MainForm
{
    partial class FrmConfigService
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
            this.lblConfigService = new System.Windows.Forms.Label();
            this.lblAdressService = new System.Windows.Forms.Label();
            this.tbxIpAddress = new CommonControls.Custom.CommonTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxPort = new CommonControls.Custom.CommonTextBox();
            this.SuspendLayout();
            // 
            // lblConfigService
            // 
            this.lblConfigService.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConfigService.Location = new System.Drawing.Point(5, 5);
            this.lblConfigService.Name = "lblConfigService";
            this.lblConfigService.Size = new System.Drawing.Size(304, 50);
            this.lblConfigService.TabIndex = 0;
            this.lblConfigService.Text = "Để cấu hình địa chỉ máy chủ sWorld, vui lòng nhập thông số vào khung bên dưới rồi" +
                " nhấn \"Lưu Lại\".";
            // 
            // lblAdressService
            // 
            this.lblAdressService.AutoSize = true;
            this.lblAdressService.Location = new System.Drawing.Point(8, 61);
            this.lblAdressService.Margin = new System.Windows.Forms.Padding(3);
            this.lblAdressService.Name = "lblAdressService";
            this.lblAdressService.Size = new System.Drawing.Size(104, 16);
            this.lblAdressService.TabIndex = 1;
            this.lblAdressService.Text = "Địa chỉ máy chủ:";
            // 
            // tbxIpAddress
            // 
            this.tbxIpAddress.Location = new System.Drawing.Point(118, 58);
            this.tbxIpAddress.Name = "tbxIpAddress";
            this.tbxIpAddress.Size = new System.Drawing.Size(122, 22);
            this.tbxIpAddress.TabIndex = 2;
            this.tbxIpAddress.Text = "127.0.0.1";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(100, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 26);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu Lại";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(206, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbxPort
            // 
            this.tbxPort.Location = new System.Drawing.Point(246, 58);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(60, 22);
            this.tbxPort.TabIndex = 3;
            this.tbxPort.Text = "2142";
            // 
            // FrmConfigService
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(314, 150);
            this.Controls.Add(this.tbxPort);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbxIpAddress);
            this.Controls.Add(this.lblAdressService);
            this.Controls.Add(this.lblConfigService);
            this.Name = "FrmConfigService";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Cấu Hình Địa Chỉ Máy Chủ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConfigService;
        private System.Windows.Forms.Label lblAdressService;
        private CommonControls.Custom.CommonTextBox tbxIpAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private CommonControls.Custom.CommonTextBox tbxPort;

    }
}