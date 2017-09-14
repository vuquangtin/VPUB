namespace SystemMgtComponent.WorkItems.Users
{
    partial class FrmResetPassword
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblPasswdStrength = new CommonControls.Custom.PasswordMeterLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxNewPasswd2 = new CommonControls.Custom.CommonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxNewPasswd1 = new CommonControls.Custom.CommonTextBox();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.lblCreateNewPass = new System.Windows.Forms.Label();
            this.lblReSetupPassWord = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblMessage);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnConfirm);
            this.panel2.Controls.Add(this.lblPasswdStrength);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbxNewPasswd2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbxNewPasswd1);
            this.panel2.Controls.Add(this.lblInstruction);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel2.Size = new System.Drawing.Size(394, 218);
            this.panel2.TabIndex = 54;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMessage.Location = new System.Drawing.Point(13, 135);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(3);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(368, 39);
            this.lblMessage.TabIndex = 48;
            this.lblMessage.Text = "This is a sample message on control lblMessage";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(281, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRefresh.Location = new System.Drawing.Point(175, 180);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 26);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfirm.Location = new System.Drawing.Point(69, 180);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 26);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Xác Nhận...";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // lblPasswdStrength
            // 
            this.lblPasswdStrength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPasswdStrength.Location = new System.Drawing.Point(138, 107);
            this.lblPasswdStrength.Margin = new System.Windows.Forms.Padding(3);
            this.lblPasswdStrength.Name = "lblPasswdStrength";
            this.lblPasswdStrength.Score = 0;
            this.lblPasswdStrength.Size = new System.Drawing.Size(243, 22);
            this.lblPasswdStrength.TabIndex = 44;
            this.lblPasswdStrength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 50);
            this.label4.TabIndex = 43;
            this.label4.Text = "Nhập lại mật khẩu mới:";
            // 
            // tbxNewPasswd2
            // 
            this.tbxNewPasswd2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxNewPasswd2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbxNewPasswd2.Location = new System.Drawing.Point(138, 79);
            this.tbxNewPasswd2.MaxLength = 255;
            this.tbxNewPasswd2.Name = "tbxNewPasswd2";
            this.tbxNewPasswd2.Size = new System.Drawing.Size(243, 22);
            this.tbxNewPasswd2.TabIndex = 2;
            this.tbxNewPasswd2.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 22);
            this.label2.TabIndex = 41;
            this.label2.Text = "Mật khẩu mới:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxNewPasswd1
            // 
            this.tbxNewPasswd1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxNewPasswd1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbxNewPasswd1.Location = new System.Drawing.Point(138, 51);
            this.tbxNewPasswd1.MaxLength = 255;
            this.tbxNewPasswd1.Name = "tbxNewPasswd1";
            this.tbxNewPasswd1.Size = new System.Drawing.Size(243, 22);
            this.tbxNewPasswd1.TabIndex = 1;
            this.tbxNewPasswd1.UseSystemPasswordChar = true;
            // 
            // lblInstruction
            // 
            this.lblInstruction.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInstruction.Location = new System.Drawing.Point(10, 5);
            this.lblInstruction.Margin = new System.Windows.Forms.Padding(3);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(374, 40);
            this.lblInstruction.TabIndex = 16;
            this.lblInstruction.Text = "Hãy nhập các trường bên dưới để cài lại mật khẩu. Mật khẩu mới phải có độ mạnh tố" +
    "i thiểu ở mức độ trung bình.";
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
            this.line1.TabIndex = 53;
            this.line1.TabStop = false;
            // 
            // lblCreateNewPass
            // 
            this.lblCreateNewPass.AutoSize = true;
            this.lblCreateNewPass.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateNewPass.Location = new System.Drawing.Point(12, 39);
            this.lblCreateNewPass.Margin = new System.Windows.Forms.Padding(3);
            this.lblCreateNewPass.Name = "lblCreateNewPass";
            this.lblCreateNewPass.Size = new System.Drawing.Size(275, 14);
            this.lblCreateNewPass.TabIndex = 1;
            this.lblCreateNewPass.Text = "Tạo một mật khẩu mới cho người dùng đã chọn.";
            // 
            // lblReSetupPassWord
            // 
            this.lblReSetupPassWord.AutoSize = true;
            this.lblReSetupPassWord.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReSetupPassWord.Location = new System.Drawing.Point(12, 22);
            this.lblReSetupPassWord.Name = "lblReSetupPassWord";
            this.lblReSetupPassWord.Size = new System.Drawing.Size(109, 14);
            this.lblReSetupPassWord.TabIndex = 0;
            this.lblReSetupPassWord.Text = "Cài Lại Mật Khẩu";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblCreateNewPass);
            this.panel1.Controls.Add(this.lblReSetupPassWord);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 75);
            this.panel1.TabIndex = 52;
            // 
            // FrmResetPassword
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(394, 295);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmResetPassword";
            this.Text = "Cài Lại Mật Khẩu";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnConfirm;
        private CommonControls.Custom.PasswordMeterLabel lblPasswdStrength;
        private System.Windows.Forms.Label label4;
        private CommonControls.Custom.CommonTextBox tbxNewPasswd2;
        private System.Windows.Forms.Label label2;
        private CommonControls.Custom.CommonTextBox tbxNewPasswd1;
        private System.Windows.Forms.Label lblInstruction;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Label lblCreateNewPass;
        private System.Windows.Forms.Label lblReSetupPassWord;
        private System.Windows.Forms.Panel panel1;
    }
}