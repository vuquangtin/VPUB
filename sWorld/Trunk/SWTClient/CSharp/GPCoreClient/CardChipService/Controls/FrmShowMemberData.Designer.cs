namespace CardChipMgtComponent.WorkItems
{
    partial class FrmShowMemberData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowMemberData));
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbxHideAfterTagRemoved = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Number = new System.Windows.Forms.Label();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.Nativeplace = new System.Windows.Forms.Label();
            this.tbxPhoneNo = new System.Windows.Forms.TextBox();
            this.lblindentifiCard = new System.Windows.Forms.Label();
            this.tbxSubOrgName = new System.Windows.Forms.TextBox();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.tbxPosition = new System.Windows.Forms.TextBox();
            this.lblTenThanhVien = new System.Windows.Forms.Label();
            this.tbxFullName = new System.Windows.Forms.TextBox();
            this.lblMaNhanVien = new System.Windows.Forms.Label();
            this.tbxMemberCode = new System.Windows.Forms.TextBox();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.line1 = new CommonControls.Custom.Line();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGUIMemberData = new System.Windows.Forms.Label();
            this.lblMemberData = new System.Windows.Forms.Label();
            this.txtMember = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMember);
            this.panel2.Controls.Add(this.cbxHideAfterTagRemoved);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lblSerialNumber);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel2.Size = new System.Drawing.Size(394, 275);
            this.panel2.TabIndex = 20;
            // 
            // cbxHideAfterTagRemoved
            // 
            this.cbxHideAfterTagRemoved.AutoSize = true;
            this.cbxHideAfterTagRemoved.Checked = true;
            this.cbxHideAfterTagRemoved.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxHideAfterTagRemoved.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxHideAfterTagRemoved.Location = new System.Drawing.Point(10, 205);
            this.cbxHideAfterTagRemoved.Name = "cbxHideAfterTagRemoved";
            this.cbxHideAfterTagRemoved.Size = new System.Drawing.Size(374, 20);
            this.cbxHideAfterTagRemoved.TabIndex = 25;
            this.cbxHideAfterTagRemoved.Text = "Đóng hộp thoại này sau khi đưa thẻ ra khỏi thiết bị đọc";
            this.cbxHideAfterTagRemoved.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.Number);
            this.panel3.Controls.Add(this.tbxEmail);
            this.panel3.Controls.Add(this.Nativeplace);
            this.panel3.Controls.Add(this.tbxPhoneNo);
            this.panel3.Controls.Add(this.lblindentifiCard);
            this.panel3.Controls.Add(this.tbxSubOrgName);
            this.panel3.Controls.Add(this.lblCreateDate);
            this.panel3.Controls.Add(this.tbxPosition);
            this.panel3.Controls.Add(this.lblTenThanhVien);
            this.panel3.Controls.Add(this.tbxFullName);
            this.panel3.Controls.Add(this.lblMaNhanVien);
            this.panel3.Controls.Add(this.tbxMemberCode);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(374, 175);
            this.panel3.TabIndex = 23;
            // 
            // Number
            // 
            this.Number.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Number.Location = new System.Drawing.Point(6, 143);
            this.Number.Margin = new System.Windows.Forms.Padding(3);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(79, 22);
            this.Number.TabIndex = 12;
            this.Number.Text = "Số lần";
            this.Number.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(106, 143);
            this.tbxEmail.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.ReadOnly = true;
            this.tbxEmail.Size = new System.Drawing.Size(259, 22);
            this.tbxEmail.TabIndex = 11;
            // 
            // Nativeplace
            // 
            this.Nativeplace.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nativeplace.Location = new System.Drawing.Point(6, 115);
            this.Nativeplace.Margin = new System.Windows.Forms.Padding(3);
            this.Nativeplace.Name = "Nativeplace";
            this.Nativeplace.Size = new System.Drawing.Size(79, 22);
            this.Nativeplace.TabIndex = 10;
            this.Nativeplace.Text = "Nơi Cấp";
            this.Nativeplace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxPhoneNo
            // 
            this.tbxPhoneNo.Location = new System.Drawing.Point(106, 115);
            this.tbxPhoneNo.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.tbxPhoneNo.Name = "tbxPhoneNo";
            this.tbxPhoneNo.ReadOnly = true;
            this.tbxPhoneNo.Size = new System.Drawing.Size(259, 22);
            this.tbxPhoneNo.TabIndex = 9;
            // 
            // lblindentifiCard
            // 
            this.lblindentifiCard.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblindentifiCard.Location = new System.Drawing.Point(6, 59);
            this.lblindentifiCard.Margin = new System.Windows.Forms.Padding(3);
            this.lblindentifiCard.Name = "lblindentifiCard";
            this.lblindentifiCard.Size = new System.Drawing.Size(79, 22);
            this.lblindentifiCard.TabIndex = 8;
            this.lblindentifiCard.Text = "CMND";
            this.lblindentifiCard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxSubOrgName
            // 
            this.tbxSubOrgName.Location = new System.Drawing.Point(106, 59);
            this.tbxSubOrgName.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.tbxSubOrgName.Name = "tbxSubOrgName";
            this.tbxSubOrgName.ReadOnly = true;
            this.tbxSubOrgName.Size = new System.Drawing.Size(259, 22);
            this.tbxSubOrgName.TabIndex = 7;
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateDate.Location = new System.Drawing.Point(6, 87);
            this.lblCreateDate.Margin = new System.Windows.Forms.Padding(3);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(79, 22);
            this.lblCreateDate.TabIndex = 6;
            this.lblCreateDate.Text = "Ngày cấp";
            this.lblCreateDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxPosition
            // 
            this.tbxPosition.Location = new System.Drawing.Point(106, 87);
            this.tbxPosition.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.tbxPosition.Name = "tbxPosition";
            this.tbxPosition.ReadOnly = true;
            this.tbxPosition.Size = new System.Drawing.Size(259, 22);
            this.tbxPosition.TabIndex = 5;
            // 
            // lblTenThanhVien
            // 
            this.lblTenThanhVien.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenThanhVien.Location = new System.Drawing.Point(6, 31);
            this.lblTenThanhVien.Margin = new System.Windows.Forms.Padding(3);
            this.lblTenThanhVien.Name = "lblTenThanhVien";
            this.lblTenThanhVien.Size = new System.Drawing.Size(94, 22);
            this.lblTenThanhVien.TabIndex = 4;
            this.lblTenThanhVien.Text = "Tên nhân viên";
            this.lblTenThanhVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxFullName
            // 
            this.tbxFullName.Location = new System.Drawing.Point(106, 31);
            this.tbxFullName.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.tbxFullName.Name = "tbxFullName";
            this.tbxFullName.ReadOnly = true;
            this.tbxFullName.Size = new System.Drawing.Size(259, 22);
            this.tbxFullName.TabIndex = 3;
            // 
            // lblMaNhanVien
            // 
            this.lblMaNhanVien.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNhanVien.Location = new System.Drawing.Point(6, 3);
            this.lblMaNhanVien.Margin = new System.Windows.Forms.Padding(3);
            this.lblMaNhanVien.Name = "lblMaNhanVien";
            this.lblMaNhanVien.Size = new System.Drawing.Size(79, 22);
            this.lblMaNhanVien.TabIndex = 2;
            this.lblMaNhanVien.Text = "Mã nhân viên";
            this.lblMaNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxMemberCode
            // 
            this.tbxMemberCode.Location = new System.Drawing.Point(106, 3);
            this.tbxMemberCode.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.tbxMemberCode.Name = "tbxMemberCode";
            this.tbxMemberCode.ReadOnly = true;
            this.tbxMemberCode.Size = new System.Drawing.Size(259, 22);
            this.tbxMemberCode.TabIndex = 0;
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSerialNumber.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNumber.Location = new System.Drawing.Point(10, 5);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(374, 25);
            this.lblSerialNumber.TabIndex = 19;
            this.lblSerialNumber.Text = "Mã Thẻ:";
            this.lblSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(281, 237);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 26);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
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
            this.line1.TabIndex = 19;
            this.line1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblGUIMemberData);
            this.panel1.Controls.Add(this.lblMemberData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 75);
            this.panel1.TabIndex = 18;
            // 
            // lblGUIMemberData
            // 
            this.lblGUIMemberData.AutoSize = true;
            this.lblGUIMemberData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGUIMemberData.Location = new System.Drawing.Point(12, 39);
            this.lblGUIMemberData.Margin = new System.Windows.Forms.Padding(3);
            this.lblGUIMemberData.Name = "lblGUIMemberData";
            this.lblGUIMemberData.Size = new System.Drawing.Size(256, 14);
            this.lblGUIMemberData.TabIndex = 1;
            this.lblGUIMemberData.Text = "Thông tin của thành viên được lưu trong thẻ";
            // 
            // lblMemberData
            // 
            this.lblMemberData.AutoSize = true;
            this.lblMemberData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberData.Location = new System.Drawing.Point(12, 22);
            this.lblMemberData.Name = "lblMemberData";
            this.lblMemberData.Size = new System.Drawing.Size(140, 14);
            this.lblMemberData.TabIndex = 0;
            this.lblMemberData.Text = "Thông Tin Thành Viên";
            // 
            // txtMember
            // 
            this.txtMember.Location = new System.Drawing.Point(10, 6);
            this.txtMember.Multiline = true;
            this.txtMember.Name = "txtMember";
            this.txtMember.ReadOnly = true;
            this.txtMember.Size = new System.Drawing.Size(374, 194);
            this.txtMember.TabIndex = 26;
            // 
            // FrmShowMemberData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 352);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmShowMemberData";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.Text = "Thông Tin Thành Viên";
            this.Load += new System.EventHandler(this.FrmMemberData_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Button btnClose;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGUIMemberData;
        private System.Windows.Forms.Label lblMemberData;
        private System.Windows.Forms.CheckBox cbxHideAfterTagRemoved;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Number;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.Label Nativeplace;
        private System.Windows.Forms.TextBox tbxPhoneNo;
        private System.Windows.Forms.Label lblindentifiCard;
        private System.Windows.Forms.TextBox tbxSubOrgName;
        private System.Windows.Forms.Label lblCreateDate;
        private System.Windows.Forms.TextBox tbxPosition;
        private System.Windows.Forms.Label lblTenThanhVien;
        private System.Windows.Forms.TextBox tbxFullName;
        private System.Windows.Forms.Label lblMaNhanVien;
        private System.Windows.Forms.TextBox tbxMemberCode;
        private System.Windows.Forms.TextBox txtMember;

    }
}