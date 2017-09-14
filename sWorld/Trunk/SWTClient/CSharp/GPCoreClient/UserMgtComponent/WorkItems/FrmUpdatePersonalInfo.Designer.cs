namespace UserMgtComponent.WorkItems
{
    partial class FrmUpdatePersonalInfo
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
            this.line1 = new CommonControls.Custom.Line();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUpdateInfoChoosed = new System.Windows.Forms.Label();
            this.lblUpdateInfoUser = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblIsLoading = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Line3DStyle = CommonControls.Custom.Line3DStyle.Inset;
            this.line1.Location = new System.Drawing.Point(0, 75);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(594, 2);
            this.line1.TabIndex = 57;
            this.line1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblUpdateInfoChoosed);
            this.panel2.Controls.Add(this.lblUpdateInfoUser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 75);
            this.panel2.TabIndex = 56;
            // 
            // lblUpdateInfoChoosed
            // 
            this.lblUpdateInfoChoosed.AutoSize = true;
            this.lblUpdateInfoChoosed.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateInfoChoosed.Location = new System.Drawing.Point(12, 39);
            this.lblUpdateInfoChoosed.Margin = new System.Windows.Forms.Padding(3);
            this.lblUpdateInfoChoosed.Name = "lblUpdateInfoChoosed";
            this.lblUpdateInfoChoosed.Size = new System.Drawing.Size(320, 14);
            this.lblUpdateInfoChoosed.TabIndex = 1;
            this.lblUpdateInfoChoosed.Text = "Cập nhật các thông tin cá nhân của tài khoản được chọn";
            // 
            // lblUpdateInfoUser
            // 
            this.lblUpdateInfoUser.AutoSize = true;
            this.lblUpdateInfoUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateInfoUser.Location = new System.Drawing.Point(12, 22);
            this.lblUpdateInfoUser.Name = "lblUpdateInfoUser";
            this.lblUpdateInfoUser.Size = new System.Drawing.Size(182, 14);
            this.lblUpdateInfoUser.TabIndex = 0;
            this.lblUpdateInfoUser.Text = "Cập Nhật Thông Tin Cá Nhân";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblIsLoading);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 378);
            this.panel1.TabIndex = 58;
            // 
            // lblIsLoading
            // 
            this.lblIsLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIsLoading.AutoSize = true;
            this.lblIsLoading.Location = new System.Drawing.Point(204, 181);
            this.lblIsLoading.Name = "lblIsLoading";
            this.lblIsLoading.Size = new System.Drawing.Size(187, 16);
            this.lblIsLoading.TabIndex = 0;
            this.lblIsLoading.Text = "Đang tải dữ liệu, vui lòng chờ...";
            // 
            // FrmUpdatePersonalInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 455);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmUpdatePersonalInfo";
            this.Text = "Cập Nhật Thông Tin Cá Nhân";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblUpdateInfoChoosed;
        private System.Windows.Forms.Label lblUpdateInfoUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblIsLoading;






    }
}