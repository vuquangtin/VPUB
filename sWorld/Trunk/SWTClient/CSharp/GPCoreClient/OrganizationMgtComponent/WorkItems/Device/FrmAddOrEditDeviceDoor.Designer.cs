namespace SystemMgtComponent.WorkItems
{
    partial class FrmAddOrEditDeviceDoor
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
            this.lblNoteAddDeviceIO = new System.Windows.Forms.Label();
            this.lblAddDeviceIO = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.lblInfoAddDeviceIO = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cbxOrgCode = new System.Windows.Forms.ComboBox();
            this.cbxLocked = new System.Windows.Forms.CheckBox();
            this.dtpCloseDoor = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpOpenDoor = new System.Windows.Forms.DateTimePicker();
            this.lblBuilding = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.tbxIP = new CommonControls.Custom.CommonTextBox();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtDeviceDoorName = new CommonControls.Custom.CommonTextBox();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lblNoteAddDeviceIO);
            this.panel9.Controls.Add(this.lblAddDeviceIO);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(609, 80);
            this.panel9.TabIndex = 62;
            // 
            // lblNoteAddDeviceIO
            // 
            this.lblNoteAddDeviceIO.AutoSize = true;
            this.lblNoteAddDeviceIO.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteAddDeviceIO.Location = new System.Drawing.Point(14, 42);
            this.lblNoteAddDeviceIO.Margin = new System.Windows.Forms.Padding(3);
            this.lblNoteAddDeviceIO.Name = "lblNoteAddDeviceIO";
            this.lblNoteAddDeviceIO.Size = new System.Drawing.Size(275, 14);
            this.lblNoteAddDeviceIO.TabIndex = 1;
            this.lblNoteAddDeviceIO.Text = "Thêm một thiết bị vao/ra cửa mới vào hệ thống.";
            // 
            // lblAddDeviceIO
            // 
            this.lblAddDeviceIO.AutoSize = true;
            this.lblAddDeviceIO.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddDeviceIO.Location = new System.Drawing.Point(14, 24);
            this.lblAddDeviceIO.Name = "lblAddDeviceIO";
            this.lblAddDeviceIO.Size = new System.Drawing.Size(194, 14);
            this.lblAddDeviceIO.TabIndex = 0;
            this.lblAddDeviceIO.Text = "Thêm Thiết Bị Vào/Ra Cửa Mới";
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 80);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(609, 1);
            this.line1.TabIndex = 63;
            this.line1.TabStop = false;
            // 
            // lblInfoAddDeviceIO
            // 
            this.lblInfoAddDeviceIO.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfoAddDeviceIO.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblInfoAddDeviceIO.Location = new System.Drawing.Point(0, 81);
            this.lblInfoAddDeviceIO.Name = "lblInfoAddDeviceIO";
            this.lblInfoAddDeviceIO.Size = new System.Drawing.Size(609, 27);
            this.lblInfoAddDeviceIO.TabIndex = 74;
            this.lblInfoAddDeviceIO.Text = "Thông tin thiết bị vao/ra cửa:";
            this.lblInfoAddDeviceIO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 245);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(609, 41);
            this.panel1.TabIndex = 77;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(232, 8);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(117, 28);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Xác Nhận...";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(349, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(7, 28);
            this.panel4.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(356, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 28);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(473, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(7, 28);
            this.panel3.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(480, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 28);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtDescription);
            this.panel2.Controls.Add(this.lblDescription);
            this.panel2.Controls.Add(this.cbxOrgCode);
            this.panel2.Controls.Add(this.cbxLocked);
            this.panel2.Controls.Add(this.dtpCloseDoor);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpOpenDoor);
            this.panel2.Controls.Add(this.lblBuilding);
            this.panel2.Controls.Add(this.lblIP);
            this.panel2.Controls.Add(this.tbxIP);
            this.panel2.Controls.Add(this.lblDeviceName);
            this.panel2.Controls.Add(this.lblMoTa);
            this.panel2.Controls.Add(this.txtDeviceDoorName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 108);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(609, 137);
            this.panel2.TabIndex = 78;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(119, 53);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(367, 71);
            this.txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(14, 59);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(45, 16);
            this.lblDescription.TabIndex = 53;
            this.lblDescription.Text = "Mô tả:";
            // 
            // cbxOrgCode
            // 
            this.cbxOrgCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOrgCode.FormattingEnabled = true;
            this.cbxOrgCode.Location = new System.Drawing.Point(492, 102);
            this.cbxOrgCode.Name = "cbxOrgCode";
            this.cbxOrgCode.Size = new System.Drawing.Size(104, 22);
            this.cbxOrgCode.TabIndex = 52;
            this.cbxOrgCode.Visible = false;
            // 
            // cbxLocked
            // 
            this.cbxLocked.AutoSize = true;
            this.cbxLocked.Location = new System.Drawing.Point(479, 151);
            this.cbxLocked.Name = "cbxLocked";
            this.cbxLocked.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbxLocked.Size = new System.Drawing.Size(55, 20);
            this.cbxLocked.TabIndex = 51;
            this.cbxLocked.Text = "Khóa";
            this.cbxLocked.UseVisualStyleBackColor = true;
            // 
            // dtpCloseDoor
            // 
            this.dtpCloseDoor.Checked = false;
            this.dtpCloseDoor.CustomFormat = "HH:mm:ss";
            this.dtpCloseDoor.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCloseDoor.Location = new System.Drawing.Point(348, 147);
            this.dtpCloseDoor.Name = "dtpCloseDoor";
            this.dtpCloseDoor.ShowCheckBox = true;
            this.dtpCloseDoor.Size = new System.Drawing.Size(111, 22);
            this.dtpCloseDoor.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 49;
            this.label3.Text = "Giờ đóng cửa:";
            // 
            // dtpOpenDoor
            // 
            this.dtpOpenDoor.Checked = false;
            this.dtpOpenDoor.CustomFormat = "HH:mm:ss";
            this.dtpOpenDoor.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOpenDoor.Location = new System.Drawing.Point(119, 145);
            this.dtpOpenDoor.Name = "dtpOpenDoor";
            this.dtpOpenDoor.ShowCheckBox = true;
            this.dtpOpenDoor.Size = new System.Drawing.Size(111, 22);
            this.dtpOpenDoor.TabIndex = 48;
            // 
            // lblBuilding
            // 
            this.lblBuilding.AutoSize = true;
            this.lblBuilding.Location = new System.Drawing.Point(495, 81);
            this.lblBuilding.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblBuilding.Name = "lblBuilding";
            this.lblBuilding.Size = new System.Drawing.Size(60, 16);
            this.lblBuilding.TabIndex = 47;
            this.lblBuilding.Text = "Tòa nhà:";
            this.lblBuilding.Visible = false;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(264, 13);
            this.lblIP.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(24, 16);
            this.lblIP.TabIndex = 45;
            this.lblIP.Text = "IP:";
            // 
            // tbxIP
            // 
            this.tbxIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbxIP.Location = new System.Drawing.Point(300, 10);
            this.tbxIP.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.tbxIP.MaxLength = 255;
            this.tbxIP.Name = "tbxIP";
            this.tbxIP.Size = new System.Drawing.Size(186, 22);
            this.tbxIP.TabIndex = 2;
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Location = new System.Drawing.Point(14, 13);
            this.lblDeviceName.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(78, 16);
            this.lblDeviceName.TabIndex = 43;
            this.lblDeviceName.Text = "Tên thiết bị:";
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(13, 149);
            this.lblMoTa.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(78, 16);
            this.lblMoTa.TabIndex = 39;
            this.lblMoTa.Text = "Giờ mở cửa:";
            // 
            // txtDeviceDoorName
            // 
            this.txtDeviceDoorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDeviceDoorName.Location = new System.Drawing.Point(119, 10);
            this.txtDeviceDoorName.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.txtDeviceDoorName.MaxLength = 255;
            this.txtDeviceDoorName.Name = "txtDeviceDoorName";
            this.txtDeviceDoorName.Size = new System.Drawing.Size(133, 22);
            this.txtDeviceDoorName.TabIndex = 1;
            // 
            // FrmAddOrEditDeviceDoor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 286);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblInfoAddDeviceIO);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.Name = "FrmAddOrEditDeviceDoor";
            this.Text = "Thêm Thiết Bị Vào/Ra Cửa";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblNoteAddDeviceIO;
        private System.Windows.Forms.Label lblAddDeviceIO;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Label lblInfoAddDeviceIO;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.Label lblMoTa;
        private CommonControls.Custom.CommonTextBox txtDeviceDoorName;
        private System.Windows.Forms.CheckBox cbxLocked;
        private System.Windows.Forms.DateTimePicker dtpCloseDoor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpOpenDoor;
        private System.Windows.Forms.Label lblBuilding;
        private System.Windows.Forms.Label lblIP;
        private CommonControls.Custom.CommonTextBox tbxIP;
        private System.Windows.Forms.ComboBox cbxOrgCode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnRefresh;
    }
}