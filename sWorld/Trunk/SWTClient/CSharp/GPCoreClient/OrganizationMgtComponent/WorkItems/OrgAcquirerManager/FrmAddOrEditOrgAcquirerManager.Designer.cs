namespace SystemMgtComponent.WorkItems.OrgAcquirerManager
{
    partial class FrmAddOrEditOrgAcquirerManager
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
            this.lbNote = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgvPartnerList = new CommonControls.Custom.CommonDataGridView();
            this.lbl1_FrmAddOrEditOrgAcquirerManager = new System.Windows.Forms.Label();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.txtDegreeCode = new System.Windows.Forms.TextBox();
            this.cbxFilterByDegree = new System.Windows.Forms.CheckBox();
            this.lblNotification2 = new System.Windows.Forms.Label();
            this.lblNotification1 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.rbtnNotWorking = new System.Windows.Forms.RadioButton();
            this.rbtnWorkingAbroad = new System.Windows.Forms.RadioButton();
            this.rbtnWorking = new System.Windows.Forms.RadioButton();
            this.cbxFilterByPersoStatusMember = new System.Windows.Forms.CheckBox();
            this.tbxMemberCode = new System.Windows.Forms.TextBox();
            this.cbxFilterBySubOrgCode = new System.Windows.Forms.CheckBox();
            this.tbxMemberName = new System.Windows.Forms.TextBox();
            this.cbxFilterByMemberName = new System.Windows.Forms.CheckBox();
            this.cbxFilterByWorkingStatus = new System.Windows.Forms.CheckBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.rbtnPerso = new System.Windows.Forms.RadioButton();
            this.rbtnNotPerso = new System.Windows.Forms.RadioButton();
            this.lblRightAreaTitle = new CommonControls.Custom.TitleLabel();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartnerList)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lbNote);
            this.panel9.Controls.Add(this.lbTitle);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(794, 81);
            this.panel9.TabIndex = 62;
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNote.Location = new System.Drawing.Point(14, 42);
            this.lbNote.Margin = new System.Windows.Forms.Padding(3);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(219, 14);
            this.lbNote.TabIndex = 1;
            this.lbNote.Text = "Thêm tổ chức liên kết trong hệ thống.";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(14, 24);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(148, 14);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Thêm Tổ Chức Liên Kết";
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 81);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(794, 1);
            this.line1.TabIndex = 63;
            this.line1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 531);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(794, 44);
            this.panel1.TabIndex = 77;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(423, 8);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(117, 28);
            this.btnConfirm.TabIndex = 19;
            this.btnConfirm.Text = "Xác Nhận...";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(540, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(7, 28);
            this.panel4.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(547, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 28);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(664, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(7, 28);
            this.panel3.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(671, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 28);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.lblRightAreaTitle);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 82);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(794, 449);
            this.panel5.TabIndex = 79;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 30);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel7.Size = new System.Drawing.Size(794, 419);
            this.panel7.TabIndex = 37;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.dgvPartnerList);
            this.panel8.Controls.Add(this.lbl1_FrmAddOrEditOrgAcquirerManager);
            this.panel8.Controls.Add(this.pnlFilterBox);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(5, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(784, 411);
            this.panel8.TabIndex = 38;
            // 
            // dgvPartnerList
            // 
            this.dgvPartnerList.AllowUserToAddRows = false;
            this.dgvPartnerList.AllowUserToDeleteRows = false;
            this.dgvPartnerList.AllowUserToOrderColumns = true;
            this.dgvPartnerList.AllowUserToResizeRows = false;
            this.dgvPartnerList.BackgroundColor = System.Drawing.Color.White;
            this.dgvPartnerList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPartnerList.ColumnHeadersHeight = 26;
            this.dgvPartnerList.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvPartnerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPartnerList.Location = new System.Drawing.Point(0, 0);
            this.dgvPartnerList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPartnerList.MultiSelect = false;
            this.dgvPartnerList.Name = "dgvPartnerList";
            this.dgvPartnerList.ReadOnly = true;
            this.dgvPartnerList.RowHeadersVisible = false;
            this.dgvPartnerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartnerList.Size = new System.Drawing.Size(782, 382);
            this.dgvPartnerList.TabIndex = 78;
            // 
            // lbl1_FrmAddOrEditOrgAcquirerManager
            // 
            this.lbl1_FrmAddOrEditOrgAcquirerManager.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl1_FrmAddOrEditOrgAcquirerManager.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lbl1_FrmAddOrEditOrgAcquirerManager.Location = new System.Drawing.Point(0, 382);
            this.lbl1_FrmAddOrEditOrgAcquirerManager.Name = "lbl1_FrmAddOrEditOrgAcquirerManager";
            this.lbl1_FrmAddOrEditOrgAcquirerManager.Size = new System.Drawing.Size(782, 27);
            this.lbl1_FrmAddOrEditOrgAcquirerManager.TabIndex = 77;
            this.lbl1_FrmAddOrEditOrgAcquirerManager.Text = "Có thể chọn một hoặc nhiều tổ chức đồng phát hành thẻ";
            this.lbl1_FrmAddOrEditOrgAcquirerManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.Controls.Add(this.txtDegreeCode);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByDegree);
            this.pnlFilterBox.Controls.Add(this.lblNotification2);
            this.pnlFilterBox.Controls.Add(this.lblNotification1);
            this.pnlFilterBox.Controls.Add(this.panel10);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByPersoStatusMember);
            this.pnlFilterBox.Controls.Add(this.tbxMemberCode);
            this.pnlFilterBox.Controls.Add(this.cbxFilterBySubOrgCode);
            this.pnlFilterBox.Controls.Add(this.tbxMemberName);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByMemberName);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByWorkingStatus);
            this.pnlFilterBox.Controls.Add(this.panel11);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 0);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(782, 0);
            this.pnlFilterBox.TabIndex = 45;
            // 
            // txtDegreeCode
            // 
            this.txtDegreeCode.Enabled = false;
            this.txtDegreeCode.Location = new System.Drawing.Point(214, 120);
            this.txtDegreeCode.Name = "txtDegreeCode";
            this.txtDegreeCode.Size = new System.Drawing.Size(150, 22);
            this.txtDegreeCode.TabIndex = 44;
            // 
            // cbxFilterByDegree
            // 
            this.cbxFilterByDegree.Location = new System.Drawing.Point(8, 120);
            this.cbxFilterByDegree.Name = "cbxFilterByDegree";
            this.cbxFilterByDegree.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByDegree.TabIndex = 43;
            this.cbxFilterByDegree.Text = "Lọc theo trình độ:";
            this.cbxFilterByDegree.UseVisualStyleBackColor = true;
            // 
            // lblNotification2
            // 
            this.lblNotification2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNotification2.Location = new System.Drawing.Point(421, 36);
            this.lblNotification2.Name = "lblNotification2";
            this.lblNotification2.Size = new System.Drawing.Size(150, 22);
            this.lblNotification2.TabIndex = 42;
            this.lblNotification2.Text = "Vui lòng nhập ít nhất 2 ký tự";
            this.lblNotification2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotification2.Visible = false;
            // 
            // lblNotification1
            // 
            this.lblNotification1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNotification1.Location = new System.Drawing.Point(421, 8);
            this.lblNotification1.Name = "lblNotification1";
            this.lblNotification1.Size = new System.Drawing.Size(150, 22);
            this.lblNotification1.TabIndex = 41;
            this.lblNotification1.Text = "Vui lòng nhập ít nhất 2 ký tự";
            this.lblNotification1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotification1.Visible = false;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.rbtnNotWorking);
            this.panel10.Controls.Add(this.rbtnWorkingAbroad);
            this.panel10.Controls.Add(this.rbtnWorking);
            this.panel10.Location = new System.Drawing.Point(214, 92);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(350, 22);
            this.panel10.TabIndex = 39;
            // 
            // rbtnNotWorking
            // 
            this.rbtnNotWorking.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnNotWorking.Enabled = false;
            this.rbtnNotWorking.Location = new System.Drawing.Point(250, 0);
            this.rbtnNotWorking.Name = "rbtnNotWorking";
            this.rbtnNotWorking.Size = new System.Drawing.Size(100, 22);
            this.rbtnNotWorking.TabIndex = 6;
            this.rbtnNotWorking.Text = "Đã Nghỉ";
            this.rbtnNotWorking.UseVisualStyleBackColor = true;
            // 
            // rbtnWorkingAbroad
            // 
            this.rbtnWorkingAbroad.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnWorkingAbroad.Enabled = false;
            this.rbtnWorkingAbroad.Location = new System.Drawing.Point(125, 0);
            this.rbtnWorkingAbroad.Name = "rbtnWorkingAbroad";
            this.rbtnWorkingAbroad.Size = new System.Drawing.Size(125, 22);
            this.rbtnWorkingAbroad.TabIndex = 5;
            this.rbtnWorkingAbroad.Text = "Đi Nước Ngoài";
            this.rbtnWorkingAbroad.UseVisualStyleBackColor = true;
            // 
            // rbtnWorking
            // 
            this.rbtnWorking.Checked = true;
            this.rbtnWorking.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnWorking.Enabled = false;
            this.rbtnWorking.Location = new System.Drawing.Point(0, 0);
            this.rbtnWorking.Name = "rbtnWorking";
            this.rbtnWorking.Size = new System.Drawing.Size(125, 22);
            this.rbtnWorking.TabIndex = 4;
            this.rbtnWorking.TabStop = true;
            this.rbtnWorking.Text = "Đang Công Tác";
            this.rbtnWorking.UseVisualStyleBackColor = true;
            // 
            // cbxFilterByPersoStatusMember
            // 
            this.cbxFilterByPersoStatusMember.Location = new System.Drawing.Point(8, 64);
            this.cbxFilterByPersoStatusMember.Name = "cbxFilterByPersoStatusMember";
            this.cbxFilterByPersoStatusMember.Size = new System.Drawing.Size(250, 22);
            this.cbxFilterByPersoStatusMember.TabIndex = 36;
            this.cbxFilterByPersoStatusMember.Text = "Lọc theo trạng thái được cấp phát thẻ:";
            this.cbxFilterByPersoStatusMember.UseVisualStyleBackColor = true;
            // 
            // tbxMemberCode
            // 
            this.tbxMemberCode.Enabled = false;
            this.tbxMemberCode.Location = new System.Drawing.Point(265, 36);
            this.tbxMemberCode.Name = "tbxMemberCode";
            this.tbxMemberCode.Size = new System.Drawing.Size(150, 22);
            this.tbxMemberCode.TabIndex = 35;
            // 
            // cbxFilterBySubOrgCode
            // 
            this.cbxFilterBySubOrgCode.Location = new System.Drawing.Point(8, 36);
            this.cbxFilterBySubOrgCode.Name = "cbxFilterBySubOrgCode";
            this.cbxFilterBySubOrgCode.Size = new System.Drawing.Size(250, 22);
            this.cbxFilterBySubOrgCode.TabIndex = 34;
            this.cbxFilterBySubOrgCode.Text = "Lọc theo mã tổ chức:";
            this.cbxFilterBySubOrgCode.UseVisualStyleBackColor = true;
            // 
            // tbxMemberName
            // 
            this.tbxMemberName.Enabled = false;
            this.tbxMemberName.Location = new System.Drawing.Point(265, 8);
            this.tbxMemberName.Name = "tbxMemberName";
            this.tbxMemberName.Size = new System.Drawing.Size(150, 22);
            this.tbxMemberName.TabIndex = 33;
            // 
            // cbxFilterByMemberName
            // 
            this.cbxFilterByMemberName.Location = new System.Drawing.Point(8, 8);
            this.cbxFilterByMemberName.Name = "cbxFilterByMemberName";
            this.cbxFilterByMemberName.Size = new System.Drawing.Size(250, 22);
            this.cbxFilterByMemberName.TabIndex = 32;
            this.cbxFilterByMemberName.Text = "Lọc theo tên tổ chức:";
            this.cbxFilterByMemberName.UseVisualStyleBackColor = true;
            // 
            // cbxFilterByWorkingStatus
            // 
            this.cbxFilterByWorkingStatus.Location = new System.Drawing.Point(8, 92);
            this.cbxFilterByWorkingStatus.Name = "cbxFilterByWorkingStatus";
            this.cbxFilterByWorkingStatus.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByWorkingStatus.TabIndex = 38;
            this.cbxFilterByWorkingStatus.Text = "Lọc theo tình trạng công tác:";
            this.cbxFilterByWorkingStatus.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.rbtnPerso);
            this.panel11.Controls.Add(this.rbtnNotPerso);
            this.panel11.Location = new System.Drawing.Point(265, 64);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(250, 22);
            this.panel11.TabIndex = 37;
            // 
            // rbtnPerso
            // 
            this.rbtnPerso.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnPerso.Enabled = false;
            this.rbtnPerso.Location = new System.Drawing.Point(150, 0);
            this.rbtnPerso.Name = "rbtnPerso";
            this.rbtnPerso.Size = new System.Drawing.Size(184, 22);
            this.rbtnPerso.TabIndex = 2;
            this.rbtnPerso.Text = "Không được phát hành thẻ";
            this.rbtnPerso.UseVisualStyleBackColor = true;
            // 
            // rbtnNotPerso
            // 
            this.rbtnNotPerso.Checked = true;
            this.rbtnNotPerso.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnNotPerso.Enabled = false;
            this.rbtnNotPerso.Location = new System.Drawing.Point(0, 0);
            this.rbtnNotPerso.Name = "rbtnNotPerso";
            this.rbtnNotPerso.Size = new System.Drawing.Size(150, 22);
            this.rbtnNotPerso.TabIndex = 1;
            this.rbtnNotPerso.TabStop = true;
            this.rbtnNotPerso.Text = "Được phát hành thẻ";
            this.rbtnNotPerso.UseVisualStyleBackColor = true;
            // 
            // lblRightAreaTitle
            // 
            this.lblRightAreaTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitle.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblRightAreaTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitle.Location = new System.Drawing.Point(0, 0);
            this.lblRightAreaTitle.Name = "lblRightAreaTitle";
            this.lblRightAreaTitle.Size = new System.Drawing.Size(794, 30);
            this.lblRightAreaTitle.TabIndex = 36;
            this.lblRightAreaTitle.Text = "DANH SÁCH TỔ CHỨC ĐỒNG PHÁT HÀNH THẺ";
            this.lblRightAreaTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmAddOrEditOrgAcquirerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.Name = "FrmAddOrEditOrgAcquirerManager";
            this.Text = "Thêm Tổ Chức Liên Kết";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartnerList)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Label lbTitle;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private CommonControls.Custom.CommonDataGridView dgvPartnerList;
        private System.Windows.Forms.Label lbl1_FrmAddOrEditOrgAcquirerManager;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.TextBox txtDegreeCode;
        private System.Windows.Forms.CheckBox cbxFilterByDegree;
        private System.Windows.Forms.Label lblNotification2;
        private System.Windows.Forms.Label lblNotification1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.RadioButton rbtnNotWorking;
        private System.Windows.Forms.RadioButton rbtnWorkingAbroad;
        private System.Windows.Forms.RadioButton rbtnWorking;
        private System.Windows.Forms.CheckBox cbxFilterByPersoStatusMember;
        private System.Windows.Forms.TextBox tbxMemberCode;
        private System.Windows.Forms.CheckBox cbxFilterBySubOrgCode;
        private System.Windows.Forms.TextBox tbxMemberName;
        private System.Windows.Forms.CheckBox cbxFilterByMemberName;
        private System.Windows.Forms.CheckBox cbxFilterByWorkingStatus;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.RadioButton rbtnPerso;
        private System.Windows.Forms.RadioButton rbtnNotPerso;
        private CommonControls.Custom.TitleLabel lblRightAreaTitle;
    }
}