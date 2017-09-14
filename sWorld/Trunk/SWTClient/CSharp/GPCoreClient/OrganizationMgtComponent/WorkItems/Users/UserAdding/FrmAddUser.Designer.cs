namespace SystemMgtComponent.WorkItems.UserAdding
{
    partial class FrmAddUser
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
            this.lbl1_FrmAddUser = new System.Windows.Forms.Label();
            this.lblAddnewuser = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.pnlMainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lbl1_FrmAddUser);
            this.panel2.Controls.Add(this.lblAddnewuser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1066, 75);
            this.panel2.TabIndex = 54;
            // 
            // lbl1_FrmAddUser
            // 
            this.lbl1_FrmAddUser.AutoSize = true;
            this.lbl1_FrmAddUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1_FrmAddUser.Location = new System.Drawing.Point(12, 39);
            this.lbl1_FrmAddUser.Margin = new System.Windows.Forms.Padding(3);
            this.lbl1_FrmAddUser.Name = "lbl1_FrmAddUser";
            this.lbl1_FrmAddUser.Size = new System.Drawing.Size(496, 14);
            this.lbl1_FrmAddUser.TabIndex = 1;
            this.lbl1_FrmAddUser.Text = "Tạo tài khoản mới cho một cá nhân là thành viên hoặc không là thành viên vào hệ t" +
    "hống.";
            // 
            // lblAddnewuser
            // 
            this.lblAddnewuser.AutoSize = true;
            this.lblAddnewuser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddnewuser.Location = new System.Drawing.Point(12, 22);
            this.lblAddnewuser.Name = "lblAddnewuser";
            this.lblAddnewuser.Size = new System.Drawing.Size(119, 14);
            this.lblAddnewuser.TabIndex = 0;
            this.lblAddnewuser.Text = "Tạo Tài Khoản Mới";
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Line3DStyle = CommonControls.Custom.Line3DStyle.Inset;
            this.line1.Location = new System.Drawing.Point(0, 75);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(1066, 2);
            this.line1.TabIndex = 55;
            this.line1.TabStop = false;
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.AutoSize = true;
            this.pnlMainContainer.Controls.Add(this.panel3);
            this.pnlMainContainer.Controls.Add(this.panel1);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 77);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(1066, 553);
            this.pnlMainContainer.TabIndex = 56;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1066, 0);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1066, 297);
            this.panel3.TabIndex = 1;
            // 
            // FrmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1066, 630);
            this.Controls.Add(this.pnlMainContainer);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmAddUser";
            this.Text = "Tạo Tài Khoản Mới";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlMainContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl1_FrmAddUser;
        private System.Windows.Forms.Label lblAddnewuser;
        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
    }
}