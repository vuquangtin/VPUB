namespace SystemMgtComponent.WorkItems.Users
{
    partial class UsrLoginHistory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrLoginHistory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvLoginHistories = new CommonControls.Custom.CommonDataGridView();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.cmsHistoryTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mniReloadData = new System.Windows.Forms.ToolStripMenuItem();
            this.rbtnLoginFailed = new System.Windows.Forms.RadioButton();
            this.rbtnLoginSuccess = new System.Windows.Forms.RadioButton();
            this.cbxFilterByLoginResult = new System.Windows.Forms.CheckBox();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.dtpLoginTimeTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpLoginTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.cbxFilterByLoginTime = new System.Windows.Forms.CheckBox();
            this.cbxFilterByUserName = new System.Windows.Forms.CheckBox();
            this.tsmCard = new CommonControls.Custom.CommonToolStrip();
            this.btnShowHideFilter = new System.Windows.Forms.ToolStripButton();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReloadData = new System.Windows.Forms.ToolStripButton();
            this.lblRightAreaTitle = new CommonControls.Custom.TitleLabel();
            this.colLuotId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFailedReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginHistories)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.cmsHistoryTable.SuspendLayout();
            this.tsmCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 35);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Size = new System.Drawing.Size(790, 560);
            this.panel1.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvLoginHistories);
            this.panel2.Controls.Add(this.pagerPanel1);
            this.panel2.Controls.Add(this.pnlFilterBox);
            this.panel2.Controls.Add(this.tsmCard);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(778, 550);
            this.panel2.TabIndex = 38;
            // 
            // dgvLoginHistories
            // 
            this.dgvLoginHistories.AllowUserToAddRows = false;
            this.dgvLoginHistories.AllowUserToDeleteRows = false;
            this.dgvLoginHistories.AllowUserToOrderColumns = true;
            this.dgvLoginHistories.AllowUserToResizeRows = false;
            this.dgvLoginHistories.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoginHistories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLoginHistories.ColumnHeadersHeight = 26;
            this.dgvLoginHistories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLuotId,
            this.colUserName,
            this.colResult,
            this.colLoginTime,
            this.colFailedReason});
            this.dgvLoginHistories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoginHistories.Location = new System.Drawing.Point(0, 125);
            this.dgvLoginHistories.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvLoginHistories.Name = "dgvLoginHistories";
            this.dgvLoginHistories.ReadOnly = true;
            this.dgvLoginHistories.RowHeadersVisible = false;
            this.dgvLoginHistories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoginHistories.Size = new System.Drawing.Size(776, 403);
            this.dgvLoginHistories.TabIndex = 43;
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 528);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(776, 20);
            this.pagerPanel1.TabIndex = 40;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.ContextMenuStrip = this.cmsHistoryTable;
            this.pnlFilterBox.Controls.Add(this.rbtnLoginFailed);
            this.pnlFilterBox.Controls.Add(this.rbtnLoginSuccess);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByLoginResult);
            this.pnlFilterBox.Controls.Add(this.cmbUsers);
            this.pnlFilterBox.Controls.Add(this.dtpLoginTimeTo);
            this.pnlFilterBox.Controls.Add(this.lblTo);
            this.pnlFilterBox.Controls.Add(this.lblFrom);
            this.pnlFilterBox.Controls.Add(this.dtpLoginTimeFrom);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByLoginTime);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByUserName);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(776, 100);
            this.pnlFilterBox.TabIndex = 39;
            // 
            // cmsHistoryTable
            // 
            this.cmsHistoryTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniExportToExcel,
            this.toolStripSeparator2,
            this.mniReloadData});
            this.cmsHistoryTable.Name = "contextMenuStrip1";
            this.cmsHistoryTable.Size = new System.Drawing.Size(153, 54);
            // 
            // mniExportToExcel
            // 
            this.mniExportToExcel.Image = global::SystemMgtComponent.Properties.Resources.Excel_16x16;
            this.mniExportToExcel.Name = "mniExportToExcel";
            this.mniExportToExcel.Size = new System.Drawing.Size(152, 22);
            this.mniExportToExcel.Text = "Xuất Ra Excel...";
            this.mniExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // mniReloadData
            // 
            this.mniReloadData.Image = ((System.Drawing.Image)(resources.GetObject("mniReloadData.Image")));
            this.mniReloadData.Name = "mniReloadData";
            this.mniReloadData.Size = new System.Drawing.Size(152, 22);
            this.mniReloadData.Text = "Tải Dữ Liệu";
            this.mniReloadData.Click += new System.EventHandler(this.OnButtonSearchClicked);
            // 
            // rbtnLoginFailed
            // 
            this.rbtnLoginFailed.AutoSize = true;
            this.rbtnLoginFailed.Enabled = false;
            this.rbtnLoginFailed.Location = new System.Drawing.Point(313, 64);
            this.rbtnLoginFailed.Name = "rbtnLoginFailed";
            this.rbtnLoginFailed.Size = new System.Drawing.Size(73, 20);
            this.rbtnLoginFailed.TabIndex = 22;
            this.rbtnLoginFailed.Text = "Thất bại";
            this.rbtnLoginFailed.UseVisualStyleBackColor = true;
            // 
            // rbtnLoginSuccess
            // 
            this.rbtnLoginSuccess.AutoSize = true;
            this.rbtnLoginSuccess.Checked = true;
            this.rbtnLoginSuccess.Enabled = false;
            this.rbtnLoginSuccess.Location = new System.Drawing.Point(214, 64);
            this.rbtnLoginSuccess.Name = "rbtnLoginSuccess";
            this.rbtnLoginSuccess.Size = new System.Drawing.Size(93, 20);
            this.rbtnLoginSuccess.TabIndex = 21;
            this.rbtnLoginSuccess.TabStop = true;
            this.rbtnLoginSuccess.Text = "Thành công";
            this.rbtnLoginSuccess.UseVisualStyleBackColor = true;
            // 
            // cbxFilterByLoginResult
            // 
            this.cbxFilterByLoginResult.Location = new System.Drawing.Point(8, 64);
            this.cbxFilterByLoginResult.Name = "cbxFilterByLoginResult";
            this.cbxFilterByLoginResult.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByLoginResult.TabIndex = 20;
            this.cbxFilterByLoginResult.Text = "Lọc theo kết quả:";
            this.cbxFilterByLoginResult.UseVisualStyleBackColor = true;
            // 
            // cmbUsers
            // 
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.Enabled = false;
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(220, 8);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(150, 22);
            this.cmbUsers.TabIndex = 19;
            // 
            // dtpLoginTimeTo
            // 
            this.dtpLoginTimeTo.CustomFormat = "dd/MM/yyyy";
            this.dtpLoginTimeTo.Enabled = false;
            this.dtpLoginTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLoginTimeTo.Location = new System.Drawing.Point(431, 36);
            this.dtpLoginTimeTo.Name = "dtpLoginTimeTo";
            this.dtpLoginTimeTo.Size = new System.Drawing.Size(118, 22);
            this.dtpLoginTimeTo.TabIndex = 18;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(386, 36);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(36, 22);
            this.lblTo.TabIndex = 17;
            this.lblTo.Text = "Đến:";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(211, 36);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(29, 22);
            this.lblFrom.TabIndex = 16;
            this.lblFrom.Text = "Từ:";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpLoginTimeFrom
            // 
            this.dtpLoginTimeFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpLoginTimeFrom.Enabled = false;
            this.dtpLoginTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLoginTimeFrom.Location = new System.Drawing.Point(252, 36);
            this.dtpLoginTimeFrom.Name = "dtpLoginTimeFrom";
            this.dtpLoginTimeFrom.Size = new System.Drawing.Size(118, 22);
            this.dtpLoginTimeFrom.TabIndex = 15;
            // 
            // cbxFilterByLoginTime
            // 
            this.cbxFilterByLoginTime.Location = new System.Drawing.Point(8, 36);
            this.cbxFilterByLoginTime.Name = "cbxFilterByLoginTime";
            this.cbxFilterByLoginTime.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByLoginTime.TabIndex = 13;
            this.cbxFilterByLoginTime.Text = "Lọc theo khoảng thời gian:";
            this.cbxFilterByLoginTime.UseVisualStyleBackColor = true;
            // 
            // cbxFilterByUserName
            // 
            this.cbxFilterByUserName.Location = new System.Drawing.Point(8, 8);
            this.cbxFilterByUserName.Name = "cbxFilterByUserName";
            this.cbxFilterByUserName.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByUserName.TabIndex = 10;
            this.cbxFilterByUserName.Text = "Lọc theo tài khoản:";
            this.cbxFilterByUserName.UseVisualStyleBackColor = true;
            // 
            // tsmCard
            // 
            this.tsmCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowHideFilter,
            this.btnExportToExcel,
            this.toolStripSeparator1,
            this.btnReloadData});
            this.tsmCard.Location = new System.Drawing.Point(0, 0);
            this.tsmCard.Name = "tsmCard";
            this.tsmCard.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsmCard.Size = new System.Drawing.Size(776, 25);
            this.tsmCard.TabIndex = 38;
            this.tsmCard.Text = "tlstripListUser";
            // 
            // btnShowHideFilter
            // 
            this.btnShowHideFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnShowHideFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowHideFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnShowHideFilter.Image")));
            this.btnShowHideFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHideFilter.Name = "btnShowHideFilter";
            this.btnShowHideFilter.Size = new System.Drawing.Size(23, 22);
            this.btnShowHideFilter.Text = "Ẩn Khung Tìm Kiếm";
            this.btnShowHideFilter.ToolTipText = "Ẩn khung tìm kiếm";
            this.btnShowHideFilter.Click += new System.EventHandler(this.OnButtonShowHideClicked);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportToExcel.Image = global::SystemMgtComponent.Properties.Resources.Excel_16x16;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExportToExcel.Text = "Xuất Ra Excel...";
            this.btnExportToExcel.ToolTipText = "Xuất dữ liệu đang hiển thị ra tập tin excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnReloadData
            // 
            this.btnReloadData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadData.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadData.Image")));
            this.btnReloadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.Size = new System.Drawing.Size(23, 22);
            this.btnReloadData.Text = "Tải Dữ Liệu";
            this.btnReloadData.ToolTipText = "Tải lịch sử đăng nhập";
            this.btnReloadData.Click += new System.EventHandler(this.OnButtonSearchClicked);
            // 
            // lblRightAreaTitle
            // 
            this.lblRightAreaTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitle.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblRightAreaTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitle.Location = new System.Drawing.Point(5, 5);
            this.lblRightAreaTitle.Name = "lblRightAreaTitle";
            this.lblRightAreaTitle.Size = new System.Drawing.Size(790, 30);
            this.lblRightAreaTitle.TabIndex = 38;
            this.lblRightAreaTitle.Text = "LỊCH SỬ ĐĂNG NHẬP";
            this.lblRightAreaTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colLuotId
            // 
            this.colLuotId.DataPropertyName = "Id";
            this.colLuotId.HeaderText = "Mã Lượt";
            this.colLuotId.Name = "colLuotId";
            this.colLuotId.ReadOnly = true;
            this.colLuotId.Width = 125;
            // 
            // colUserName
            // 
            this.colUserName.DataPropertyName = "UserName";
            this.colUserName.HeaderText = "Tên Đăng Nhập";
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            this.colUserName.Width = 150;
            // 
            // colResult
            // 
            this.colResult.DataPropertyName = "Result";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colResult.DefaultCellStyle = dataGridViewCellStyle1;
            this.colResult.HeaderText = "Đăng Nhập Thành Công";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            this.colResult.Width = 200;
            // 
            // colLoginTime
            // 
            this.colLoginTime.DataPropertyName = "LoginTime";
            this.colLoginTime.HeaderText = "Thời Gian Đăng Nhập";
            this.colLoginTime.Name = "colLoginTime";
            this.colLoginTime.ReadOnly = true;
            this.colLoginTime.Width = 200;
            // 
            // colFailedReason
            // 
            this.colFailedReason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFailedReason.DataPropertyName = "FailedReason";
            this.colFailedReason.HeaderText = "Nguyên Nhân Thất Bại";
            this.colFailedReason.MinimumWidth = 200;
            this.colFailedReason.Name = "colFailedReason";
            this.colFailedReason.ReadOnly = true;
            // 
            // UsrLoginHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblRightAreaTitle);
            this.Name = "UsrLoginHistory";
            this.Size = new System.Drawing.Size(800, 600);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginHistories)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.cmsHistoryTable.ResumeLayout(false);
            this.tsmCard.ResumeLayout(false);
            this.tsmCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.CheckBox cbxFilterByUserName;
        private CommonControls.Custom.CommonToolStrip tsmCard;
        private System.Windows.Forms.ToolStripButton btnShowHideFilter;
        private CommonControls.Custom.TitleLabel lblRightAreaTitle;
        private System.Windows.Forms.CheckBox cbxFilterByLoginTime;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpLoginTimeFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpLoginTimeTo;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.RadioButton rbtnLoginFailed;
        private System.Windows.Forms.RadioButton rbtnLoginSuccess;
        private System.Windows.Forms.CheckBox cbxFilterByLoginResult;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private CommonControls.Custom.CommonDataGridView dgvLoginHistories;
        private System.Windows.Forms.ToolStripButton btnReloadData;
        private System.Windows.Forms.ContextMenuStrip cmsHistoryTable;
        private System.Windows.Forms.ToolStripMenuItem mniReloadData;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mniExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLuotId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFailedReason;
    }
}
