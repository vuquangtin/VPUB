namespace SystemMgtComponent.WorkItems.MoveSubOrganizationForPerson {
    partial class FrmMoveSubOrgForMember {
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
            this.pnlParent = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.btnMoveToLeft = new System.Windows.Forms.Button();
            this.btnMoveToRight = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.dgvRight = new System.Windows.Forms.DataGridView();
            this.lblListMemberRight = new System.Windows.Forms.Label();
            this.cbxRight = new System.Windows.Forms.ComboBox();
            this.lblMoveTo = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.dgvLeft = new System.Windows.Forms.DataGridView();
            this.lblListMemberLeft = new System.Windows.Forms.Label();
            this.cbxLeft = new System.Windows.Forms.ComboBox();
            this.lblMoveFrom = new System.Windows.Forms.Label();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblMSOInformation = new System.Windows.Forms.Label();
            this.lblMoveSubOrg = new System.Windows.Forms.Label();
            this.colNoLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullNameLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoRight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullNameRight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDRight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlParent.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlMid.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRight)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeft)).BeginInit();
            this.pnlAction.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlParent
            // 
            this.pnlParent.Controls.Add(this.pnlMain);
            this.pnlParent.Controls.Add(this.pnlAction);
            this.pnlParent.Controls.Add(this.pnlInfo);
            this.pnlParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParent.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlParent.Location = new System.Drawing.Point(0, 0);
            this.pnlParent.Margin = new System.Windows.Forms.Padding(12);
            this.pnlParent.Name = "pnlParent";
            this.pnlParent.Size = new System.Drawing.Size(704, 601);
            this.pnlParent.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlMid);
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 62);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(704, 483);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.btnMoveToLeft);
            this.pnlMid.Controls.Add(this.btnMoveToRight);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(320, 0);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Size = new System.Drawing.Size(64, 483);
            this.pnlMid.TabIndex = 0;
            // 
            // btnMoveToLeft
            // 
            this.btnMoveToLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveToLeft.Enabled = false;
            this.btnMoveToLeft.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveToLeft.Location = new System.Drawing.Point(12, 293);
            this.btnMoveToLeft.Margin = new System.Windows.Forms.Padding(6);
            this.btnMoveToLeft.Name = "btnMoveToLeft";
            this.btnMoveToLeft.Size = new System.Drawing.Size(40, 32);
            this.btnMoveToLeft.TabIndex = 0;
            this.btnMoveToLeft.TabStop = false;
            this.btnMoveToLeft.Text = "←";
            this.btnMoveToLeft.UseVisualStyleBackColor = true;
            // 
            // btnMoveToRight
            // 
            this.btnMoveToRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveToRight.Enabled = false;
            this.btnMoveToRight.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveToRight.Location = new System.Drawing.Point(12, 249);
            this.btnMoveToRight.Margin = new System.Windows.Forms.Padding(6);
            this.btnMoveToRight.Name = "btnMoveToRight";
            this.btnMoveToRight.Size = new System.Drawing.Size(40, 32);
            this.btnMoveToRight.TabIndex = 0;
            this.btnMoveToRight.TabStop = false;
            this.btnMoveToRight.Text = "→";
            this.btnMoveToRight.UseVisualStyleBackColor = true;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.dgvRight);
            this.pnlRight.Controls.Add(this.lblListMemberRight);
            this.pnlRight.Controls.Add(this.cbxRight);
            this.pnlRight.Controls.Add(this.lblMoveTo);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(384, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(0, 12, 12, 0);
            this.pnlRight.Size = new System.Drawing.Size(320, 483);
            this.pnlRight.TabIndex = 0;
            // 
            // dgvRight
            // 
            this.dgvRight.AllowDrop = true;
            this.dgvRight.AllowUserToAddRows = false;
            this.dgvRight.AllowUserToDeleteRows = false;
            this.dgvRight.AllowUserToResizeRows = false;
            this.dgvRight.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRight.BackgroundColor = System.Drawing.Color.White;
            this.dgvRight.ColumnHeadersHeight = 30;
            this.dgvRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRight.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNoRight,
            this.colFullNameRight,
            this.colIDRight});
            this.dgvRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRight.Location = new System.Drawing.Point(0, 102);
            this.dgvRight.Name = "dgvRight";
            this.dgvRight.RowHeadersVisible = false;
            this.dgvRight.RowHeadersWidth = 40;
            this.dgvRight.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRight.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRight.Size = new System.Drawing.Size(308, 381);
            this.dgvRight.TabIndex = 1;
            this.dgvRight.TabStop = false;
            // 
            // lblListMemberRight
            // 
            this.lblListMemberRight.AutoSize = true;
            this.lblListMemberRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListMemberRight.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListMemberRight.Location = new System.Drawing.Point(0, 62);
            this.lblListMemberRight.Name = "lblListMemberRight";
            this.lblListMemberRight.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.lblListMemberRight.Size = new System.Drawing.Size(135, 40);
            this.lblListMemberRight.TabIndex = 0;
            this.lblListMemberRight.Text = "Danh sách thành viên:";
            // 
            // cbxRight
            // 
            this.cbxRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRight.FormattingEnabled = true;
            this.cbxRight.Location = new System.Drawing.Point(0, 40);
            this.cbxRight.Name = "cbxRight";
            this.cbxRight.Size = new System.Drawing.Size(308, 22);
            this.cbxRight.Sorted = true;
            this.cbxRight.TabIndex = 0;
            this.cbxRight.TabStop = false;
            // 
            // lblMoveTo
            // 
            this.lblMoveTo.AutoSize = true;
            this.lblMoveTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMoveTo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveTo.Location = new System.Drawing.Point(0, 12);
            this.lblMoveTo.Name = "lblMoveTo";
            this.lblMoveTo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.lblMoveTo.Size = new System.Drawing.Size(186, 28);
            this.lblMoveTo.TabIndex = 0;
            this.lblMoveTo.Text = "Chọn phòng muốn chuyển đến:";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.dgvLeft);
            this.pnlLeft.Controls.Add(this.lblListMemberLeft);
            this.pnlLeft.Controls.Add(this.cbxLeft);
            this.pnlLeft.Controls.Add(this.lblMoveFrom);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(12, 12, 0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(320, 483);
            this.pnlLeft.TabIndex = 0;
            // 
            // dgvLeft
            // 
            this.dgvLeft.AllowDrop = true;
            this.dgvLeft.AllowUserToAddRows = false;
            this.dgvLeft.AllowUserToDeleteRows = false;
            this.dgvLeft.AllowUserToResizeRows = false;
            this.dgvLeft.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLeft.BackgroundColor = System.Drawing.Color.White;
            this.dgvLeft.ColumnHeadersHeight = 30;
            this.dgvLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLeft.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNoLeft,
            this.colFullNameLeft,
            this.colIDLeft});
            this.dgvLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLeft.Location = new System.Drawing.Point(12, 102);
            this.dgvLeft.Name = "dgvLeft";
            this.dgvLeft.RowHeadersVisible = false;
            this.dgvLeft.RowHeadersWidth = 40;
            this.dgvLeft.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLeft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLeft.Size = new System.Drawing.Size(308, 381);
            this.dgvLeft.TabIndex = 0;
            this.dgvLeft.TabStop = false;
            // 
            // lblListMemberLeft
            // 
            this.lblListMemberLeft.AutoSize = true;
            this.lblListMemberLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListMemberLeft.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListMemberLeft.Location = new System.Drawing.Point(12, 62);
            this.lblListMemberLeft.Name = "lblListMemberLeft";
            this.lblListMemberLeft.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.lblListMemberLeft.Size = new System.Drawing.Size(135, 40);
            this.lblListMemberLeft.TabIndex = 0;
            this.lblListMemberLeft.Text = "Danh sách thành viên:";
            // 
            // cbxLeft
            // 
            this.cbxLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLeft.FormattingEnabled = true;
            this.cbxLeft.ItemHeight = 14;
            this.cbxLeft.Location = new System.Drawing.Point(12, 40);
            this.cbxLeft.Name = "cbxLeft";
            this.cbxLeft.Size = new System.Drawing.Size(308, 22);
            this.cbxLeft.Sorted = true;
            this.cbxLeft.TabIndex = 0;
            this.cbxLeft.TabStop = false;
            // 
            // lblMoveFrom
            // 
            this.lblMoveFrom.AutoSize = true;
            this.lblMoveFrom.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMoveFrom.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveFrom.Location = new System.Drawing.Point(12, 12);
            this.lblMoveFrom.Name = "lblMoveFrom";
            this.lblMoveFrom.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.lblMoveFrom.Size = new System.Drawing.Size(177, 28);
            this.lblMoveFrom.TabIndex = 0;
            this.lblMoveFrom.Text = "Chọn phòng muốn chuyển từ:";
            // 
            // pnlAction
            // 
            this.pnlAction.BackColor = System.Drawing.Color.Transparent;
            this.pnlAction.Controls.Add(this.btnRefresh);
            this.pnlAction.Controls.Add(this.btnCancel);
            this.pnlAction.Controls.Add(this.btnConfirm);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAction.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlAction.Location = new System.Drawing.Point(0, 545);
            this.pnlAction.Margin = new System.Windows.Forms.Padding(6);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Padding = new System.Windows.Forms.Padding(6);
            this.pnlAction.Size = new System.Drawing.Size(704, 56);
            this.pnlAction.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(473, 12);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(104, 32);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(589, 12);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 32);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(357, 12);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(6);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(104, 32);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.TabStop = false;
            this.btnConfirm.Text = "Xác Nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.lblMSOInformation);
            this.pnlInfo.Controls.Add(this.lblMoveSubOrg);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Margin = new System.Windows.Forms.Padding(6);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Padding = new System.Windows.Forms.Padding(12);
            this.pnlInfo.Size = new System.Drawing.Size(704, 62);
            this.pnlInfo.TabIndex = 0;
            // 
            // lblMSOInformation
            // 
            this.lblMSOInformation.AutoSize = true;
            this.lblMSOInformation.BackColor = System.Drawing.Color.Transparent;
            this.lblMSOInformation.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMSOInformation.Location = new System.Drawing.Point(12, 30);
            this.lblMSOInformation.Margin = new System.Windows.Forms.Padding(0);
            this.lblMSOInformation.Name = "lblMSOInformation";
            this.lblMSOInformation.Size = new System.Drawing.Size(401, 14);
            this.lblMSOInformation.TabIndex = 0;
            this.lblMSOInformation.Text = "Dùng để di chuyển thành viên từ phòng ban này sang phòng ban khác.";
            // 
            // lblMoveSubOrg
            // 
            this.lblMoveSubOrg.AutoSize = true;
            this.lblMoveSubOrg.BackColor = System.Drawing.Color.Transparent;
            this.lblMoveSubOrg.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveSubOrg.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblMoveSubOrg.Location = new System.Drawing.Point(12, 12);
            this.lblMoveSubOrg.Margin = new System.Windows.Forms.Padding(0);
            this.lblMoveSubOrg.Name = "lblMoveSubOrg";
            this.lblMoveSubOrg.Size = new System.Drawing.Size(124, 14);
            this.lblMoveSubOrg.TabIndex = 0;
            this.lblMoveSubOrg.Text = "Chuyển phòng ban";
            // 
            // colNoLeft
            // 
            this.colNoLeft.DataPropertyName = "colNoLeft";
            this.colNoLeft.FillWeight = 32F;
            this.colNoLeft.HeaderText = "Mã số";
            this.colNoLeft.Name = "colNoLeft";
            this.colNoLeft.ReadOnly = true;
            this.colNoLeft.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colFullNameLeft
            // 
            this.colFullNameLeft.DataPropertyName = "colFullNameLeft";
            this.colFullNameLeft.FillWeight = 68F;
            this.colFullNameLeft.HeaderText = "Họ và Tên";
            this.colFullNameLeft.Name = "colFullNameLeft";
            this.colFullNameLeft.ReadOnly = true;
            this.colFullNameLeft.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colIDLeft
            // 
            this.colIDLeft.DataPropertyName = "colIDLeft";
            this.colIDLeft.HeaderText = "ID";
            this.colIDLeft.Name = "colIDLeft";
            this.colIDLeft.ReadOnly = true;
            this.colIDLeft.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colIDLeft.Visible = false;
            // 
            // colNoRight
            // 
            this.colNoRight.DataPropertyName = "colNoRight";
            this.colNoRight.FillWeight = 32F;
            this.colNoRight.HeaderText = "Mã số";
            this.colNoRight.Name = "colNoRight";
            this.colNoRight.ReadOnly = true;
            this.colNoRight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colFullNameRight
            // 
            this.colFullNameRight.DataPropertyName = "colFullNameRight";
            this.colFullNameRight.FillWeight = 68F;
            this.colFullNameRight.HeaderText = "Họ và Tên";
            this.colFullNameRight.Name = "colFullNameRight";
            this.colFullNameRight.ReadOnly = true;
            this.colFullNameRight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colIDRight
            // 
            this.colIDRight.DataPropertyName = "colIDRight";
            this.colIDRight.HeaderText = "ID";
            this.colIDRight.Name = "colIDRight";
            this.colIDRight.ReadOnly = true;
            this.colIDRight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colIDRight.Visible = false;
            // 
            // FrmMoveSubOrgForMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 601);
            this.Controls.Add(this.pnlParent);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMoveSubOrgForMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển phòng ban";
            this.pnlParent.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRight)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeft)).EndInit();
            this.pnlAction.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlParent;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblMSOInformation;
        private System.Windows.Forms.Label lblMoveSubOrg;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMid;
        private System.Windows.Forms.Button btnMoveToRight;
        private System.Windows.Forms.Button btnMoveToLeft;
        private System.Windows.Forms.ComboBox cbxRight;
        private System.Windows.Forms.Label lblMoveTo;
        private System.Windows.Forms.ComboBox cbxLeft;
        private System.Windows.Forms.Label lblMoveFrom;
        private System.Windows.Forms.Label lblListMemberRight;
        private System.Windows.Forms.DataGridView dgvLeft;
        private System.Windows.Forms.Label lblListMemberLeft;
        private System.Windows.Forms.DataGridView dgvRight;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullNameRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullNameLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDLeft;
    }
}