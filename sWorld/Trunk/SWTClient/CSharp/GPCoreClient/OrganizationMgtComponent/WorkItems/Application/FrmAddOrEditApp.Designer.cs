namespace SystemMgtComponent.WorkItems.Application
{
    partial class FrmAddOrEditApp
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
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbNoteAddApp = new System.Windows.Forms.Label();
            this.lblThemUngDung = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.lblAppInfor = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTenUngDung = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtDescription = new CommonControls.Custom.CommonTextBox();
            this.txtAppName = new CommonControls.Custom.CommonTextBox();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lbNoteAddApp);
            this.panel9.Controls.Add(this.lblThemUngDung);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(567, 80);
            this.panel9.TabIndex = 62;
            // 
            // lbNoteAddApp
            // 
            this.lbNoteAddApp.AutoSize = true;
            this.lbNoteAddApp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoteAddApp.Location = new System.Drawing.Point(14, 42);
            this.lbNoteAddApp.Margin = new System.Windows.Forms.Padding(3);
            this.lbNoteAddApp.Name = "lbNoteAddApp";
            this.lbNoteAddApp.Size = new System.Drawing.Size(228, 14);
            this.lbNoteAddApp.TabIndex = 1;
            this.lbNoteAddApp.Text = "Thêm một ứng dụng mới vào hệ thống.";
            // 
            // lblThemUngDung
            // 
            this.lblThemUngDung.AutoSize = true;
            this.lblThemUngDung.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThemUngDung.Location = new System.Drawing.Point(14, 24);
            this.lblThemUngDung.Name = "lblThemUngDung";
            this.lblThemUngDung.Size = new System.Drawing.Size(132, 14);
            this.lblThemUngDung.TabIndex = 0;
            this.lblThemUngDung.Text = "Thêm Ứng Dụng Mới";
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 80);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(567, 1);
            this.line1.TabIndex = 63;
            this.line1.TabStop = false;
            // 
            // lblAppInfor
            // 
            this.lblAppInfor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAppInfor.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblAppInfor.Location = new System.Drawing.Point(0, 81);
            this.lblAppInfor.Name = "lblAppInfor";
            this.lblAppInfor.Size = new System.Drawing.Size(567, 27);
            this.lblAppInfor.TabIndex = 74;
            this.lblAppInfor.Text = "Thông tin ứng dụng:";
            this.lblAppInfor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 190);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(567, 44);
            this.panel1.TabIndex = 77;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(191, 8);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(117, 28);
            this.btnConfirm.TabIndex = 19;
            this.btnConfirm.Text = "Xác Nhận...";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(308, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(7, 28);
            this.panel4.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(315, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 28);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(432, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(7, 28);
            this.panel3.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(439, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 28);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTenUngDung);
            this.panel2.Controls.Add(this.lblMoTa);
            this.panel2.Controls.Add(this.txtDescription);
            this.panel2.Controls.Add(this.txtAppName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 108);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(567, 82);
            this.panel2.TabIndex = 78;
            // 
            // lblTenUngDung
            // 
            this.lblTenUngDung.AutoSize = true;
            this.lblTenUngDung.Location = new System.Drawing.Point(14, 13);
            this.lblTenUngDung.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblTenUngDung.Name = "lblTenUngDung";
            this.lblTenUngDung.Size = new System.Drawing.Size(93, 16);
            this.lblTenUngDung.TabIndex = 43;
            this.lblTenUngDung.Text = "Tên ứng dụng:";
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(14, 39);
            this.lblMoTa.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(45, 16);
            this.lblMoTa.TabIndex = 39;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(119, 36);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(434, 22);
            this.txtDescription.TabIndex = 4;
            // 
            // txtAppName
            // 
            this.txtAppName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAppName.Location = new System.Drawing.Point(119, 10);
            this.txtAppName.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.txtAppName.MaxLength = 255;
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(434, 22);
            this.txtAppName.TabIndex = 2;
            // 
            // FrmAddOrEditApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 234);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblAppInfor);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.Name = "FrmAddOrEditApp";
            this.Text = "Thêm Ứng Dụng";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbNoteAddApp;
        private System.Windows.Forms.Label lblThemUngDung;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Label lblAppInfor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTenUngDung;
        private System.Windows.Forms.Label lblMoTa;
        private CommonControls.Custom.CommonTextBox txtDescription;
        private CommonControls.Custom.CommonTextBox txtAppName;
    }
}