namespace sAccessComponent.WorkItems
{
    partial class FrmAddMember
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
            this.lblinformationchoosemember = new System.Windows.Forms.Label();
            this.cbxSuborg = new CheckComboBoxTest.CheckedComboBox();
            this.lblFilterBySubOrg = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvMemberList = new CommonControls.Custom.CommonDataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCmnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberList)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblinformationchoosemember);
            this.panel1.Controls.Add(this.cbxSuborg);
            this.panel1.Controls.Add(this.lblFilterBySubOrg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 67);
            this.panel1.TabIndex = 0;
            // 
            // lblinformationchoosemember
            // 
            this.lblinformationchoosemember.AutoSize = true;
            this.lblinformationchoosemember.Location = new System.Drawing.Point(12, 48);
            this.lblinformationchoosemember.Name = "lblinformationchoosemember";
            this.lblinformationchoosemember.Size = new System.Drawing.Size(312, 16);
            this.lblinformationchoosemember.TabIndex = 4;
            this.lblinformationchoosemember.Text = "(Kéo chuột hoặc nhấn controll chọn nhiều thành viên)";
            // 
            // cbxSuborg
            // 
            this.cbxSuborg.CheckOnClick = true;
            this.cbxSuborg.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxSuborg.DropDownHeight = 1;
            this.cbxSuborg.FormattingEnabled = true;
            this.cbxSuborg.IntegralHeight = false;
            this.cbxSuborg.Location = new System.Drawing.Point(163, 6);
            this.cbxSuborg.Name = "cbxSuborg";
            this.cbxSuborg.Size = new System.Drawing.Size(233, 23);
            this.cbxSuborg.TabIndex = 3;
            this.cbxSuborg.ValueSeparator = ", ";
            this.cbxSuborg.DropDownClosed += new System.EventHandler(this.cbxSuborg_DropDownClosed);
            // 
            // lblFilterBySubOrg
            // 
            this.lblFilterBySubOrg.AutoSize = true;
            this.lblFilterBySubOrg.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblFilterBySubOrg.Location = new System.Drawing.Point(12, 9);
            this.lblFilterBySubOrg.Name = "lblFilterBySubOrg";
            this.lblFilterBySubOrg.Size = new System.Drawing.Size(126, 16);
            this.lblFilterBySubOrg.TabIndex = 2;
            this.lblFilterBySubOrg.Text = "Lọc theo tổ chức con";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(940, 573);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvMemberList);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(940, 509);
            this.panel5.TabIndex = 86;
            // 
            // dgvMemberList
            // 
            this.dgvMemberList.AllowUserToAddRows = false;
            this.dgvMemberList.AllowUserToDeleteRows = false;
            this.dgvMemberList.AllowUserToOrderColumns = true;
            this.dgvMemberList.AllowUserToResizeRows = false;
            this.dgvMemberList.BackgroundColor = System.Drawing.Color.White;
            this.dgvMemberList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMemberList.ColumnHeadersHeight = 26;
            this.dgvMemberList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colStt,
            this.colSerial,
            this.colName,
            this.colPhone,
            this.colCmnd,
            this.colEmail});
            this.dgvMemberList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMemberList.Location = new System.Drawing.Point(0, 0);
            this.dgvMemberList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMemberList.Name = "dgvMemberList";
            this.dgvMemberList.ReadOnly = true;
            this.dgvMemberList.RowHeadersVisible = false;
            this.dgvMemberList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMemberList.Size = new System.Drawing.Size(940, 509);
            this.dgvMemberList.TabIndex = 82;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Mã Người Dùng";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 150;
            // 
            // colStt
            // 
            this.colStt.DataPropertyName = "Stt";
            this.colStt.HeaderText = "Số thứ tự";
            this.colStt.Name = "colStt";
            this.colStt.ReadOnly = true;
            // 
            // colSerial
            // 
            this.colSerial.DataPropertyName = "SerialNumber";
            this.colSerial.HeaderText = "SerialNumber";
            this.colSerial.Name = "colSerial";
            this.colSerial.ReadOnly = true;
            this.colSerial.Visible = false;
            this.colSerial.Width = 150;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Tên Người Dùng";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 150;
            // 
            // colPhone
            // 
            this.colPhone.DataPropertyName = "phone";
            this.colPhone.HeaderText = "Số Điện Thoại";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            this.colPhone.Width = 150;
            // 
            // colCmnd
            // 
            this.colCmnd.DataPropertyName = "cmnd";
            this.colCmnd.HeaderText = "Số CMND";
            this.colCmnd.MinimumWidth = 15;
            this.colCmnd.Name = "colCmnd";
            this.colCmnd.ReadOnly = true;
            this.colCmnd.Width = 125;
            // 
            // colEmail
            // 
            this.colEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 509);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(940, 64);
            this.panel4.TabIndex = 85;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pagerPanel1);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnConfirm);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(0, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(940, 62);
            this.panel3.TabIndex = 83;
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 0);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(940, 20);
            this.pagerPanel1.TabIndex = 85;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(811, 26);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 29);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(676, 26);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(117, 29);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Xác Nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // FrmAddMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 640);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAddMember";
            this.Text = "Thêm thành viên vào nhóm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberList)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CheckComboBoxTest.CheckedComboBox cbxSuborg;
        private System.Windows.Forms.Label lblFilterBySubOrg;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panel5;
        private CommonControls.Custom.CommonDataGridView dgvMemberList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCmnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.Panel panel4;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private System.Windows.Forms.Label lblinformationchoosemember;
    }
}