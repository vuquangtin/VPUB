namespace sTimeKeeping.WorkItems {
    partial class FrmDayOffConfig {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblMust = new System.Windows.Forms.Label();
            this.lblDayOffConfig = new System.Windows.Forms.Label();
            this.lblStar1 = new System.Windows.Forms.Label();
            this.lblDayOffStatus = new System.Windows.Forms.Label();
            this.lblStar4 = new System.Windows.Forms.Label();
            this.lblDetail = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblNoteDayOff = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tbxFilterByMemberName = new System.Windows.Forms.TextBox();
            this.lblFilterByMemberName = new System.Windows.Forms.Label();
            this.tbxFilterByMemberCode = new System.Windows.Forms.TextBox();
            this.lblFilterByMemberCode = new System.Windows.Forms.Label();
            this.lblStar2 = new System.Windows.Forms.Label();
            this.dpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.lblDateEnd = new System.Windows.Forms.Label();
            this.dpDateStart = new System.Windows.Forms.DateTimePicker();
            this.lblDateBegin = new System.Windows.Forms.Label();
            this.cbxFullDayOff = new System.Windows.Forms.CheckBox();
            this.cbxHalfDayOff = new System.Windows.Forms.CheckBox();
            this.pnlParent = new System.Windows.Forms.Panel();
            this.pnlDataGridView = new System.Windows.Forms.Panel();
            this.dgvMember = new CommonControls.Custom.CommonDataGridView();
            this.colMemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlInfo.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlParent.SuspendLayout();
            this.pnlDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgvMember)).BeginInit();
            this.pnlAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMust
            // 
            this.lblMust.BackColor = System.Drawing.Color.Transparent;
            this.lblMust.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblMust.Location = new System.Drawing.Point(11, 45);
            this.lblMust.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.lblMust.Name = "lblMust";
            this.lblMust.Size = new System.Drawing.Size(663, 17);
            this.lblMust.TabIndex = 0;
            this.lblMust.Text = "Các trường có dấu  *   là trường bắt buộc, các trường không bắt buộc nếu không ch" +
    "ỉnh sửa sẽ tự động chọn mặc định.";
            this.lblMust.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMust.AutoSize = true;
            // 
            // lblDayOffConfig
            // 
            this.lblDayOffConfig.AutoSize = true;
            this.lblDayOffConfig.BackColor = System.Drawing.Color.Transparent;
            this.lblDayOffConfig.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblDayOffConfig.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblDayOffConfig.Location = new System.Drawing.Point(11, 12);
            this.lblDayOffConfig.Name = "lblDayOffConfig";
            this.lblDayOffConfig.Size = new System.Drawing.Size(126, 14);
            this.lblDayOffConfig.TabIndex = 0;
            this.lblDayOffConfig.Text = "Cấu hình ngày nghỉ";
            // 
            // lblStar1
            // 
            this.lblStar1.AutoSize = true;
            this.lblStar1.BackColor = System.Drawing.Color.Transparent;
            this.lblStar1.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblStar1.ForeColor = System.Drawing.Color.Red;
            this.lblStar1.Location = new System.Drawing.Point(109, 11);
            this.lblStar1.Margin = new System.Windows.Forms.Padding(0);
            this.lblStar1.Name = "lblStar1";
            this.lblStar1.Size = new System.Drawing.Size(26, 16);
            this.lblStar1.TabIndex = 0;
            this.lblStar1.Text = "(*)";
            // 
            // lblDayOffStatus
            // 
            this.lblDayOffStatus.AutoSize = true;
            this.lblDayOffStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblDayOffStatus.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblDayOffStatus.Location = new System.Drawing.Point(388, 11);
            this.lblDayOffStatus.Margin = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.lblDayOffStatus.Name = "lblDayOffStatus";
            this.lblDayOffStatus.Size = new System.Drawing.Size(72, 16);
            this.lblDayOffStatus.TabIndex = 0;
            this.lblDayOffStatus.Text = "Trạng thái:";
            this.lblDayOffStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStar4
            // 
            this.lblStar4.AutoSize = true;
            this.lblStar4.BackColor = System.Drawing.Color.Transparent;
            this.lblStar4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblStar4.ForeColor = System.Drawing.Color.Red;
            this.lblStar4.Location = new System.Drawing.Point(118, 46);
            this.lblStar4.Margin = new System.Windows.Forms.Padding(0);
            this.lblStar4.Name = "lblStar4";
            this.lblStar4.Size = new System.Drawing.Size(24, 14);
            this.lblStar4.TabIndex = 0;
            this.lblStar4.Text = "(*)";
            // 
            // lblDetail
            // 
            this.lblDetail.BackColor = System.Drawing.Color.Transparent;
            this.lblDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetail.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblDetail.Location = new System.Drawing.Point(0, 75);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblDetail.Size = new System.Drawing.Size(682, 32);
            this.lblDetail.TabIndex = 0;
            this.lblDetail.Text = "Thông tin chi tiết:";
            this.lblDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.lblNoteDayOff);
            this.pnlInfo.Controls.Add(this.lblStar4);
            this.pnlInfo.Controls.Add(this.lblMust);
            this.pnlInfo.Controls.Add(this.lblDayOffConfig);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(682, 75);
            this.pnlInfo.TabIndex = 0;
            // 
            // lblNoteDayOff
            // 
            this.lblNoteDayOff.BackColor = System.Drawing.Color.Transparent;
            this.lblNoteDayOff.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblNoteDayOff.Location = new System.Drawing.Point(11, 30);
            this.lblNoteDayOff.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.lblNoteDayOff.Name = "lblNoteDayOff";
            this.lblNoteDayOff.Size = new System.Drawing.Size(338, 14);
            this.lblNoteDayOff.TabIndex = 0;
            this.lblNoteDayOff.Text = "Đăng ký ngày nghỉ. Dùng để đăng ký ngày nghỉ cho nhân viên";
            this.lblNoteDayOff.AutoSize = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tbxFilterByMemberName);
            this.pnlMain.Controls.Add(this.lblFilterByMemberName);
            this.pnlMain.Controls.Add(this.tbxFilterByMemberCode);
            this.pnlMain.Controls.Add(this.lblFilterByMemberCode);
            this.pnlMain.Controls.Add(this.lblStar2);
            this.pnlMain.Controls.Add(this.dpDateEnd);
            this.pnlMain.Controls.Add(this.lblDateEnd);
            this.pnlMain.Controls.Add(this.dpDateStart);
            this.pnlMain.Controls.Add(this.lblDateBegin);
            this.pnlMain.Controls.Add(this.cbxFullDayOff);
            this.pnlMain.Controls.Add(this.cbxHalfDayOff);
            this.pnlMain.Controls.Add(this.lblStar1);
            this.pnlMain.Controls.Add(this.lblDayOffStatus);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 107);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(14, 5, 14, 5);
            this.pnlMain.Size = new System.Drawing.Size(682, 171);
            this.pnlMain.TabIndex = 0;
            // 
            // tbxFilterByMemberName
            // 
            this.tbxFilterByMemberName.Location = new System.Drawing.Point(182, 139);
            this.tbxFilterByMemberName.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbxFilterByMemberName.Name = "tbxFilterByMemberName";
            this.tbxFilterByMemberName.Size = new System.Drawing.Size(275, 22);
            this.tbxFilterByMemberName.TabIndex = 6;
            this.tbxFilterByMemberName.TabStop = true;
            // 
            // lblFilterByMemberName
            // 
            this.lblFilterByMemberName.AutoSize = true;
            this.lblFilterByMemberName.BackColor = System.Drawing.Color.Transparent;
            this.lblFilterByMemberName.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblFilterByMemberName.Location = new System.Drawing.Point(11, 140);
            this.lblFilterByMemberName.Margin = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.lblFilterByMemberName.Name = "lblFilterByMemberName";
            this.lblFilterByMemberName.Size = new System.Drawing.Size(145, 16);
            this.lblFilterByMemberName.TabIndex = 0;
            this.lblFilterByMemberName.Text = "Tìm theo tên nhân viên:";
            this.lblFilterByMemberName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxFilterByMemberCode
            // 
            this.tbxFilterByMemberCode.Location = new System.Drawing.Point(182, 111);
            this.tbxFilterByMemberCode.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbxFilterByMemberCode.Name = "tbxFilterByMemberCode";
            this.tbxFilterByMemberCode.Size = new System.Drawing.Size(127, 22);
            this.tbxFilterByMemberCode.TabIndex = 5;
            this.tbxFilterByMemberCode.TabStop = true;
            // 
            // lblFilterByMemberCode
            // 
            this.lblFilterByMemberCode.AutoSize = true;
            this.lblFilterByMemberCode.BackColor = System.Drawing.Color.Transparent;
            this.lblFilterByMemberCode.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblFilterByMemberCode.Location = new System.Drawing.Point(11, 112);
            this.lblFilterByMemberCode.Margin = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.lblFilterByMemberCode.Name = "lblFilterByMemberCode";
            this.lblFilterByMemberCode.Size = new System.Drawing.Size(145, 16);
            this.lblFilterByMemberCode.TabIndex = 0;
            this.lblFilterByMemberCode.Text = "Tìm theo mã nhân viên:";
            this.lblFilterByMemberCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStar2
            // 
            this.lblStar2.AutoSize = true;
            this.lblStar2.BackColor = System.Drawing.Color.Transparent;
            this.lblStar2.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblStar2.ForeColor = System.Drawing.Color.Red;
            this.lblStar2.Location = new System.Drawing.Point(109, 46);
            this.lblStar2.Margin = new System.Windows.Forms.Padding(0);
            this.lblStar2.Name = "lblStar2";
            this.lblStar2.Size = new System.Drawing.Size(26, 16);
            this.lblStar2.TabIndex = 0;
            this.lblStar2.Text = "(*)";
            // 
            // dpDateEnd
            // 
            this.dpDateEnd.CustomFormat = "dd/MM/yyyy";
            this.dpDateEnd.Enabled = false;
            this.dpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDateEnd.Location = new System.Drawing.Point(138, 45);
            this.dpDateEnd.Name = "dpDateEnd";
            this.dpDateEnd.Size = new System.Drawing.Size(136, 22);
            this.dpDateEnd.TabIndex = 2;
            this.dpDateEnd.TabStop = true;
            // 
            // lblDateEnd
            // 
            this.lblDateEnd.AutoSize = true;
            this.lblDateEnd.BackColor = System.Drawing.Color.Transparent;
            this.lblDateEnd.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblDateEnd.Location = new System.Drawing.Point(11, 46);
            this.lblDateEnd.Margin = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.lblDateEnd.Name = "lblDateEnd";
            this.lblDateEnd.Size = new System.Drawing.Size(90, 16);
            this.lblDateEnd.TabIndex = 0;
            this.lblDateEnd.Text = "Ngày kết thúc:";
            this.lblDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dpDateStart
            // 
            this.dpDateStart.CustomFormat = "dd/MM/yyyy";
            this.dpDateStart.Enabled = false;
            this.dpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDateStart.Location = new System.Drawing.Point(138, 10);
            this.dpDateStart.Name = "dpDateStart";
            this.dpDateStart.Size = new System.Drawing.Size(136, 22);
            this.dpDateStart.TabIndex = 1;
            this.dpDateStart.TabStop = true;
            // 
            // lblDateBegin
            // 
            this.lblDateBegin.AutoSize = true;
            this.lblDateBegin.BackColor = System.Drawing.Color.Transparent;
            this.lblDateBegin.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblDateBegin.Location = new System.Drawing.Point(11, 11);
            this.lblDateBegin.Margin = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.lblDateBegin.Name = "lblDateBegin";
            this.lblDateBegin.Size = new System.Drawing.Size(88, 16);
            this.lblDateBegin.TabIndex = 0;
            this.lblDateBegin.Text = "Ngày bắt đầu:";
            this.lblDateBegin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxFullDayOff
            // 
            this.cbxFullDayOff.AutoSize = true;
            this.cbxFullDayOff.BackColor = System.Drawing.Color.Transparent;
            this.cbxFullDayOff.Location = new System.Drawing.Point(484, 32);
            this.cbxFullDayOff.Name = "cbxFullDayOff";
            this.cbxFullDayOff.Size = new System.Drawing.Size(100, 20);
            this.cbxFullDayOff.TabIndex = 4;
            this.cbxFullDayOff.TabStop = true;
            this.cbxFullDayOff.Text = "Nghỉ cả ngày";
            this.cbxFullDayOff.UseVisualStyleBackColor = false;
            // 
            // cbxHalfDayOff
            // 
            this.cbxHalfDayOff.AutoSize = true;
            this.cbxHalfDayOff.BackColor = System.Drawing.Color.Transparent;
            this.cbxHalfDayOff.Location = new System.Drawing.Point(484, 11);
            this.cbxHalfDayOff.Name = "cbxHalfDayOff";
            this.cbxHalfDayOff.Size = new System.Drawing.Size(109, 20);
            this.cbxHalfDayOff.TabIndex = 3;
            this.cbxHalfDayOff.TabStop = true;
            this.cbxHalfDayOff.Text = "Nghỉ nửa ngày";
            this.cbxHalfDayOff.UseVisualStyleBackColor = false;
            // 
            // pnlParent
            // 
            this.pnlParent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlParent.Controls.Add(this.pnlDataGridView);
            this.pnlParent.Controls.Add(this.pnlAction);
            this.pnlParent.Controls.Add(this.pnlMain);
            this.pnlParent.Controls.Add(this.lblDetail);
            this.pnlParent.Controls.Add(this.pnlInfo);
            this.pnlParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParent.Location = new System.Drawing.Point(0, 0);
            this.pnlParent.Name = "pnlParent";
            this.pnlParent.Size = new System.Drawing.Size(684, 511);
            this.pnlParent.TabIndex = 0;
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Controls.Add(this.dgvMember);
            this.pnlDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataGridView.Location = new System.Drawing.Point(0, 278);
            this.pnlDataGridView.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlDataGridView.Name = "pnlDataGridView";
            this.pnlDataGridView.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.pnlDataGridView.Size = new System.Drawing.Size(682, 180);
            this.pnlDataGridView.TabIndex = 0;
            // 
            // dgvMember
            // 
            this.dgvMember.AllowDrop = true;
            this.dgvMember.AllowUserToAddRows = false;
            this.dgvMember.AllowUserToDeleteRows = false;
            this.dgvMember.AllowUserToOrderColumns = true;
            this.dgvMember.AllowUserToResizeRows = false;
            this.dgvMember.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMember.BackgroundColor = System.Drawing.Color.White;
            this.dgvMember.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMember.ColumnHeadersHeight = 30;
            this.dgvMember.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMemberId,
            this.colMemberNo,
            this.colMemCode,
            this.colMemberName});
            this.dgvMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMember.Location = new System.Drawing.Point(12, 0);
            this.dgvMember.Name = "dgvMember";
            this.dgvMember.ReadOnly = true;
            this.dgvMember.RowHeadersVisible = false;
            this.dgvMember.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMember.Size = new System.Drawing.Size(658, 180);
            this.dgvMember.TabIndex = 0;
            this.dgvMember.TabStop = false;
            // 
            // colMemberId
            // 
            this.colMemberId.DataPropertyName = "colMemberId";
            this.colMemberId.FillWeight = 50F;
            this.colMemberId.HeaderText = "Id";
            this.colMemberId.Name = "colMemberId";
            this.colMemberId.ReadOnly = true;
            this.colMemberId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMemberId.Visible = false;
            // 
            // colMemberNo
            // 
            this.colMemberNo.DataPropertyName = "colMemberNo";
            this.colMemberNo.FillWeight = 40F;
            this.colMemberNo.HeaderText = "No.";
            this.colMemberNo.Name = "colMemberNo";
            this.colMemberNo.ReadOnly = true;
            this.colMemberNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMemCode
            // 
            this.colMemCode.DataPropertyName = "colMemCode";
            this.colMemCode.FillWeight = 65F;
            this.colMemCode.HeaderText = "Mã nhân viên";
            this.colMemCode.Name = "colMemCode";
            this.colMemCode.ReadOnly = true;
            this.colMemCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMemberName
            // 
            this.colMemberName.DataPropertyName = "colMemberName";
            this.colMemberName.FillWeight = 185F;
            this.colMemberName.HeaderText = "Họ Tên";
            this.colMemberName.Name = "colMemberName";
            this.colMemberName.ReadOnly = true;
            this.colMemberName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlAction
            // 
            this.pnlAction.BackColor = System.Drawing.Color.Transparent;
            this.pnlAction.Controls.Add(this.btnRefresh);
            this.pnlAction.Controls.Add(this.btnCancel);
            this.pnlAction.Controls.Add(this.btnConfirm);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAction.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.pnlAction.Location = new System.Drawing.Point(0, 458);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(682, 51);
            this.pnlAction.TabIndex = 0;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(328, 10);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(110, 30);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.TabStop = true;
            this.btnConfirm.Text = "Xác Nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(560, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.TabStop = true;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(444, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 30);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.TabStop = true;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // FrmDayOffConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(684, 511);
            this.Controls.Add(this.pnlParent);
            this.Name = "FrmDayOffConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình ngày nghỉ";
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlParent.ResumeLayout(false);
            this.pnlDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.dgvMember)).EndInit();
            this.pnlAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMust;
        private System.Windows.Forms.Label lblDayOffConfig;
        private System.Windows.Forms.Label lblStar1;
        private System.Windows.Forms.Label lblDayOffStatus;
        private System.Windows.Forms.Label lblStar4;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlParent;
        private System.Windows.Forms.CheckBox cbxHalfDayOff;
        private System.Windows.Forms.CheckBox cbxFullDayOff;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel pnlDataGridView;
        private CommonControls.Custom.CommonDataGridView dgvMember;
        private System.Windows.Forms.Label lblStar2;
        private System.Windows.Forms.DateTimePicker dpDateEnd;
        private System.Windows.Forms.Label lblDateEnd;
        private System.Windows.Forms.DateTimePicker dpDateStart;
        private System.Windows.Forms.Label lblDateBegin;
        private System.Windows.Forms.Label lblFilterByMemberCode;
        private System.Windows.Forms.TextBox tbxFilterByMemberName;
        private System.Windows.Forms.Label lblFilterByMemberName;
        private System.Windows.Forms.TextBox tbxFilterByMemberCode;
        private System.Windows.Forms.Label lblNoteDayOff;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberName;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCancel;
    }
}