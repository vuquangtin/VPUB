namespace MainForm
{
    partial class FrmChangePassworld
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
            if (disposing)
            {
                if (bgwChangePassword != null && bgwChangePassword.IsBusy)
                {
                    bgwChangePassword.CancelAsync();
                }
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.lblCurrentPass = new System.Windows.Forms.Label();
            this.tbxOldPasswd = new CommonControls.Custom.CommonTextBox();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.tbxNewPasswd1 = new CommonControls.Custom.CommonTextBox();
            this.lblReTypePass = new System.Windows.Forms.Label();
            this.tbxNewPasswd2 = new CommonControls.Custom.CommonTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblPasswdStrength = new CommonControls.Custom.PasswordMeterLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblChangePassUserCurrent = new System.Windows.Forms.Label();
            this.lblChangePassword = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentPass
            // 
            this.lblCurrentPass.Location = new System.Drawing.Point(12, 51);
            this.lblCurrentPass.Margin = new System.Windows.Forms.Padding(3);
            this.lblCurrentPass.Name = "lblCurrentPass";
            this.lblCurrentPass.Size = new System.Drawing.Size(115, 22);
            this.lblCurrentPass.TabIndex = 39;
            this.lblCurrentPass.Text = "Mật khẩu hiện tại:";
            this.lblCurrentPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxOldPasswd
            // 
            this.tbxOldPasswd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxOldPasswd.Location = new System.Drawing.Point(133, 51);
            this.tbxOldPasswd.MaxLength = 255;
            this.tbxOldPasswd.Name = "tbxOldPasswd";
            this.tbxOldPasswd.Size = new System.Drawing.Size(249, 22);
            this.tbxOldPasswd.TabIndex = 0;
            this.tbxOldPasswd.UseSystemPasswordChar = true;
            // 
            // lblNewPass
            // 
            this.lblNewPass.Location = new System.Drawing.Point(12, 79);
            this.lblNewPass.Margin = new System.Windows.Forms.Padding(3);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(115, 22);
            this.lblNewPass.TabIndex = 41;
            this.lblNewPass.Text = "Mật khẩu mới:";
            this.lblNewPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxNewPasswd1
            // 
            this.tbxNewPasswd1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxNewPasswd1.Location = new System.Drawing.Point(133, 79);
            this.tbxNewPasswd1.MaxLength = 255;
            this.tbxNewPasswd1.Name = "tbxNewPasswd1";
            this.tbxNewPasswd1.Size = new System.Drawing.Size(249, 22);
            this.tbxNewPasswd1.TabIndex = 1;
            this.tbxNewPasswd1.UseSystemPasswordChar = true;
            // 
            // lblReTypePass
            // 
            this.lblReTypePass.Location = new System.Drawing.Point(12, 107);
            this.lblReTypePass.Margin = new System.Windows.Forms.Padding(3);
            this.lblReTypePass.Name = "lblReTypePass";
            this.lblReTypePass.Size = new System.Drawing.Size(115, 50);
            this.lblReTypePass.TabIndex = 43;
            this.lblReTypePass.Text = "Nhập lại mật khẩu mới:";
            // 
            // tbxNewPasswd2
            // 
            this.tbxNewPasswd2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxNewPasswd2.Location = new System.Drawing.Point(133, 107);
            this.tbxNewPasswd2.MaxLength = 255;
            this.tbxNewPasswd2.Name = "tbxNewPasswd2";
            this.tbxNewPasswd2.Size = new System.Drawing.Size(249, 22);
            this.tbxNewPasswd2.TabIndex = 2;
            this.tbxNewPasswd2.UseSystemPasswordChar = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(282, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Clicked);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRefresh.Location = new System.Drawing.Point(176, 172);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 26);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Clicked);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfirm.Location = new System.Drawing.Point(70, 172);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 26);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Xác Nhận...";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Clicked);
            // 
            // lblPasswdStrength
            // 
            this.lblPasswdStrength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPasswdStrength.Location = new System.Drawing.Point(133, 135);
            this.lblPasswdStrength.Margin = new System.Windows.Forms.Padding(3);
            this.lblPasswdStrength.Name = "lblPasswdStrength";
            this.lblPasswdStrength.Score = 0;
            this.lblPasswdStrength.Size = new System.Drawing.Size(249, 22);
            this.lblPasswdStrength.TabIndex = 44;
            this.lblPasswdStrength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblChangePassUserCurrent);
            this.panel1.Controls.Add(this.lblChangePassword);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 75);
            this.panel1.TabIndex = 49;
            // 
            // lblChangePassUserCurrent
            // 
            this.lblChangePassUserCurrent.AutoSize = true;
            this.lblChangePassUserCurrent.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangePassUserCurrent.Location = new System.Drawing.Point(12, 39);
            this.lblChangePassUserCurrent.Margin = new System.Windows.Forms.Padding(3);
            this.lblChangePassUserCurrent.Name = "lblChangePassUserCurrent";
            this.lblChangePassUserCurrent.Size = new System.Drawing.Size(247, 14);
            this.lblChangePassUserCurrent.TabIndex = 1;
            this.lblChangePassUserCurrent.Text = "Thay đổi mật khẩu của người dùng hiện tại.";
            // 
            // lblChangePassword
            // 
            this.lblChangePassword.AutoSize = true;
            this.lblChangePassword.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangePassword.Location = new System.Drawing.Point(12, 22);
            this.lblChangePassword.Name = "lblChangePassword";
            this.lblChangePassword.Size = new System.Drawing.Size(90, 14);
            this.lblChangePassword.TabIndex = 0;
            this.lblChangePassword.Text = "Đổi Mật Khẩu";
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Line3DStyle = CommonControls.Custom.Line3DStyle.Inset;
            this.line1.Location = new System.Drawing.Point(0, 75);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(394, 2);
            this.line1.TabIndex = 50;
            this.line1.TabStop = false;
            // 
            // lblInstruction
            // 
            this.lblInstruction.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInstruction.Location = new System.Drawing.Point(5, 5);
            this.lblInstruction.Margin = new System.Windows.Forms.Padding(3);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(384, 40);
            this.lblInstruction.TabIndex = 16;
            this.lblInstruction.Text = "Hãy nhập các trường bên dưới để thay đổi mật khẩu. Mật khẩu mới phải có độ mạnh t" +
    "ối thiểu ở mức độ trung bình.";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnConfirm);
            this.panel2.Controls.Add(this.lblPasswdStrength);
            this.panel2.Controls.Add(this.lblReTypePass);
            this.panel2.Controls.Add(this.tbxNewPasswd2);
            this.panel2.Controls.Add(this.lblNewPass);
            this.panel2.Controls.Add(this.tbxNewPasswd1);
            this.panel2.Controls.Add(this.lblCurrentPass);
            this.panel2.Controls.Add(this.tbxOldPasswd);
            this.panel2.Controls.Add(this.lblInstruction);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(394, 210);
            this.panel2.TabIndex = 51;
            // 
            // FrmChangePassworld
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(394, 287);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmChangePassworld";
            this.Text = "Đổi Mật Khẩu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentPass;
        private CommonControls.Custom.CommonTextBox tbxOldPasswd;
        private System.Windows.Forms.Label lblNewPass;
        private CommonControls.Custom.CommonTextBox tbxNewPasswd1;
        private System.Windows.Forms.Label lblReTypePass;
        private CommonControls.Custom.CommonTextBox tbxNewPasswd2;
        private CommonControls.Custom.PasswordMeterLabel lblPasswdStrength;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblChangePassUserCurrent;
        private System.Windows.Forms.Label lblChangePassword;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Panel panel2;
    }
}