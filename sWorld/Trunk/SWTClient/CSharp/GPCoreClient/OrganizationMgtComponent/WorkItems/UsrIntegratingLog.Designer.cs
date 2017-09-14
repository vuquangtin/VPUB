namespace MemberMgtComponent.WorkItems
{
    partial class UsrIntegratingLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrIntegratingLog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvIntegratingLogs = new CommonControls.Custom.CommonDataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTableNameVietnamese = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChangedType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIntegratingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChanges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.dgvChanges = new CommonControls.Custom.CommonDataGridView();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.cmsLogTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReloadData = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbChangedTypes = new System.Windows.Forms.ComboBox();
            this.cbxFilterByChangedType = new System.Windows.Forms.CheckBox();
            this.rbtnLoginFail = new System.Windows.Forms.RadioButton();
            this.rbtnLoginSuccess = new System.Windows.Forms.RadioButton();
            this.cbxFilterByLoginResult = new System.Windows.Forms.CheckBox();
            this.dtpTimeTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.cbxFilterByLoginTime = new System.Windows.Forms.CheckBox();
            this.tsmLog = new CommonControls.Custom.CommonToolStrip();
            this.btnShowHideFilter = new System.Windows.Forms.ToolStripButton();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnReloadData = new System.Windows.Forms.ToolStripButton();
            this.lblTitleIntegratingLog = new CommonControls.Custom.TitleLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntegratingLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChanges)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.cmsLogTable.SuspendLayout();
            this.tsmLog.SuspendLayout();
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
            this.panel2.Controls.Add(this.dgvIntegratingLogs);
            this.panel2.Controls.Add(this.pagerPanel1);
            this.panel2.Controls.Add(this.dgvChanges);
            this.panel2.Controls.Add(this.pnlFilterBox);
            this.panel2.Controls.Add(this.tsmLog);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(778, 550);
            this.panel2.TabIndex = 38;
            // 
            // dgvIntegratingLogs
            // 
            this.dgvIntegratingLogs.AllowUserToAddRows = false;
            this.dgvIntegratingLogs.AllowUserToDeleteRows = false;
            this.dgvIntegratingLogs.AllowUserToOrderColumns = true;
            this.dgvIntegratingLogs.AllowUserToResizeRows = false;
            this.dgvIntegratingLogs.BackgroundColor = System.Drawing.Color.White;
            this.dgvIntegratingLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvIntegratingLogs.ColumnHeadersHeight = 26;
            this.dgvIntegratingLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colUserName,
            this.colTableNameVietnamese,
            this.colChangedType,
            this.colIntegratingTime,
            this.colResult,
            this.colReason,
            this.colTableName,
            this.colChanges,
            this.colBlank});
            this.dgvIntegratingLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIntegratingLogs.Location = new System.Drawing.Point(0, 125);
            this.dgvIntegratingLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvIntegratingLogs.Name = "dgvIntegratingLogs";
            this.dgvIntegratingLogs.ReadOnly = true;
            this.dgvIntegratingLogs.RowHeadersVisible = false;
            this.dgvIntegratingLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIntegratingLogs.Size = new System.Drawing.Size(776, 328);
            this.dgvIntegratingLogs.TabIndex = 48;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Mã Lượt";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colUserName
            // 
            this.colUserName.DataPropertyName = "UserName";
            this.colUserName.HeaderText = "Tài Khoản";
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            this.colUserName.Width = 150;
            // 
            // colTableNameVietnamese
            // 
            this.colTableNameVietnamese.DataPropertyName = "TableNameVietnamese";
            this.colTableNameVietnamese.HeaderText = "Loại Dữ Liệu";
            this.colTableNameVietnamese.Name = "colTableNameVietnamese";
            this.colTableNameVietnamese.ReadOnly = true;
            this.colTableNameVietnamese.Width = 150;
            // 
            // colChangedType
            // 
            this.colChangedType.DataPropertyName = "ChangedType";
            this.colChangedType.HeaderText = "Loại Thay Đổi";
            this.colChangedType.Name = "colChangedType";
            this.colChangedType.ReadOnly = true;
            this.colChangedType.Width = 150;
            // 
            // colIntegratingTime
            // 
            this.colIntegratingTime.DataPropertyName = "IntegratingTime";
            this.colIntegratingTime.HeaderText = "Thời Gian";
            this.colIntegratingTime.Name = "colIntegratingTime";
            this.colIntegratingTime.ReadOnly = true;
            this.colIntegratingTime.Width = 150;
            // 
            // colResult
            // 
            this.colResult.DataPropertyName = "Result";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colResult.DefaultCellStyle = dataGridViewCellStyle1;
            this.colResult.HeaderText = "Thành Công";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            // 
            // colReason
            // 
            this.colReason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colReason.DataPropertyName = "Reason";
            this.colReason.HeaderText = "Ghi Chú";
            this.colReason.MinimumWidth = 200;
            this.colReason.Name = "colReason";
            this.colReason.ReadOnly = true;
            // 
            // colTableName
            // 
            this.colTableName.DataPropertyName = "TableName";
            this.colTableName.HeaderText = "colTableName";
            this.colTableName.Name = "colTableName";
            this.colTableName.ReadOnly = true;
            this.colTableName.Visible = false;
            // 
            // colChanges
            // 
            this.colChanges.DataPropertyName = "Changes";
            this.colChanges.HeaderText = "colChanges";
            this.colChanges.Name = "colChanges";
            this.colChanges.ReadOnly = true;
            this.colChanges.Visible = false;
            // 
            // colBlank
            // 
            this.colBlank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBlank.HeaderText = "";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 453);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(776, 20);
            this.pagerPanel1.TabIndex = 47;
            // 
            // dgvChanges
            // 
            this.dgvChanges.AllowUserToAddRows = false;
            this.dgvChanges.AllowUserToDeleteRows = false;
            this.dgvChanges.AllowUserToOrderColumns = true;
            this.dgvChanges.AllowUserToResizeRows = false;
            this.dgvChanges.BackgroundColor = System.Drawing.Color.White;
            this.dgvChanges.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvChanges.ColumnHeadersHeight = 26;
            this.dgvChanges.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvChanges.Location = new System.Drawing.Point(0, 473);
            this.dgvChanges.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChanges.Name = "dgvChanges";
            this.dgvChanges.ReadOnly = true;
            this.dgvChanges.RowHeadersVisible = false;
            this.dgvChanges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChanges.Size = new System.Drawing.Size(776, 75);
            this.dgvChanges.TabIndex = 46;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.ContextMenuStrip = this.cmsLogTable;
            this.pnlFilterBox.Controls.Add(this.cmbChangedTypes);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByChangedType);
            this.pnlFilterBox.Controls.Add(this.rbtnLoginFail);
            this.pnlFilterBox.Controls.Add(this.rbtnLoginSuccess);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByLoginResult);
            this.pnlFilterBox.Controls.Add(this.dtpTimeTo);
            this.pnlFilterBox.Controls.Add(this.label2);
            this.pnlFilterBox.Controls.Add(this.label1);
            this.pnlFilterBox.Controls.Add(this.dtpTimeFrom);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByLoginTime);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(776, 100);
            this.pnlFilterBox.TabIndex = 39;
            // 
            // cmsLogTable
            // 
            this.cmsLogTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniExportToExcel,
            this.mnuReloadData});
            this.cmsLogTable.Name = "contextMenuStrip1";
            this.cmsLogTable.Size = new System.Drawing.Size(161, 48);
            // 
            // mniExportToExcel
            // 
            this.mniExportToExcel.Name = "mniExportToExcel";
            this.mniExportToExcel.Size = new System.Drawing.Size(160, 22);
            this.mniExportToExcel.Text = "Xuất Ra Excel...";
            this.mniExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // mnuReloadData
            // 
            this.mnuReloadData.Image = ((System.Drawing.Image)(resources.GetObject("mnuReloadData.Image")));
            this.mnuReloadData.Name = "mnuReloadData";
            this.mnuReloadData.Size = new System.Drawing.Size(160, 22);
            this.mnuReloadData.Text = "Tải Dữ Liệu";
            this.mnuReloadData.Click += new System.EventHandler(this.btnSearch_Clicked);
            // 
            // cmbChangedTypes
            // 
            this.cmbChangedTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChangedTypes.Enabled = false;
            this.cmbChangedTypes.FormattingEnabled = true;
            this.cmbChangedTypes.Location = new System.Drawing.Point(214, 8);
            this.cmbChangedTypes.Name = "cmbChangedTypes";
            this.cmbChangedTypes.Size = new System.Drawing.Size(150, 22);
            this.cmbChangedTypes.TabIndex = 24;
            // 
            // cbxFilterByChangedType
            // 
            this.cbxFilterByChangedType.Location = new System.Drawing.Point(8, 8);
            this.cbxFilterByChangedType.Name = "cbxFilterByChangedType";
            this.cbxFilterByChangedType.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByChangedType.TabIndex = 23;
            this.cbxFilterByChangedType.Text = "Lọc theo kiểu thay đổi:";
            this.cbxFilterByChangedType.UseVisualStyleBackColor = true;
            // 
            // rbtnLoginFail
            // 
            this.rbtnLoginFail.Enabled = false;
            this.rbtnLoginFail.Location = new System.Drawing.Point(320, 67);
            this.rbtnLoginFail.Name = "rbtnLoginFail";
            this.rbtnLoginFail.Size = new System.Drawing.Size(100, 20);
            this.rbtnLoginFail.TabIndex = 22;
            this.rbtnLoginFail.Text = "Thất bại";
            this.rbtnLoginFail.UseVisualStyleBackColor = true;
            // 
            // rbtnLoginSuccess
            // 
            this.rbtnLoginSuccess.Checked = true;
            this.rbtnLoginSuccess.Enabled = false;
            this.rbtnLoginSuccess.Location = new System.Drawing.Point(214, 67);
            this.rbtnLoginSuccess.Name = "rbtnLoginSuccess";
            this.rbtnLoginSuccess.Size = new System.Drawing.Size(100, 20);
            this.rbtnLoginSuccess.TabIndex = 21;
            this.rbtnLoginSuccess.TabStop = true;
            this.rbtnLoginSuccess.Text = "Thành công";
            this.rbtnLoginSuccess.UseVisualStyleBackColor = true;
            // 
            // cbxFilterByLoginResult
            // 
            this.cbxFilterByLoginResult.Location = new System.Drawing.Point(8, 67);
            this.cbxFilterByLoginResult.Name = "cbxFilterByLoginResult";
            this.cbxFilterByLoginResult.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByLoginResult.TabIndex = 20;
            this.cbxFilterByLoginResult.Text = "Lọc theo kết quả:";
            this.cbxFilterByLoginResult.UseVisualStyleBackColor = true;
            // 
            // dtpTimeTo
            // 
            this.dtpTimeTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTimeTo.Enabled = false;
            this.dtpTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeTo.Location = new System.Drawing.Point(412, 39);
            this.dtpTimeTo.Name = "dtpTimeTo";
            this.dtpTimeTo.Size = new System.Drawing.Size(118, 22);
            this.dtpTimeTo.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(370, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 22);
            this.label2.TabIndex = 17;
            this.label2.Text = "Đến:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(211, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "Từ:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTimeFrom
            // 
            this.dtpTimeFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpTimeFrom.Enabled = false;
            this.dtpTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeFrom.Location = new System.Drawing.Point(246, 39);
            this.dtpTimeFrom.Name = "dtpTimeFrom";
            this.dtpTimeFrom.Size = new System.Drawing.Size(118, 22);
            this.dtpTimeFrom.TabIndex = 15;
            // 
            // cbxFilterByLoginTime
            // 
            this.cbxFilterByLoginTime.Location = new System.Drawing.Point(8, 39);
            this.cbxFilterByLoginTime.Name = "cbxFilterByLoginTime";
            this.cbxFilterByLoginTime.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByLoginTime.TabIndex = 13;
            this.cbxFilterByLoginTime.Text = "Lọc theo khoảng thời gian:";
            this.cbxFilterByLoginTime.UseVisualStyleBackColor = true;
            // 
            // tsmLog
            // 
            this.tsmLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowHideFilter,
            this.btnExportToExcel,
            this.btnReloadData});
            this.tsmLog.Location = new System.Drawing.Point(0, 0);
            this.tsmLog.Name = "tsmLog";
            this.tsmLog.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsmLog.Size = new System.Drawing.Size(776, 25);
            this.tsmLog.TabIndex = 38;
            this.tsmLog.Text = "tlstripListUser";
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
            this.btnShowHideFilter.Click += new System.EventHandler(this.btnShowHide_Clicked);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToExcel.Image")));
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExportToExcel.Text = "Xuất Ra Excel...";
            this.btnExportToExcel.ToolTipText = "Xuất dữ liệu đang hiển thị ra tập tin excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnReloadData
            // 
            this.btnReloadData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadData.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadData.Image")));
            this.btnReloadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.Size = new System.Drawing.Size(23, 22);
            this.btnReloadData.Text = "Tải Dữ Liệu";
            this.btnReloadData.ToolTipText = "Tải danh sách tài khoản";
            this.btnReloadData.Click += new System.EventHandler(this.btnSearch_Clicked);
            // 
            // lblTitleIntegratingLog
            // 
            this.lblTitleIntegratingLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblTitleIntegratingLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleIntegratingLog.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblTitleIntegratingLog.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleIntegratingLog.Location = new System.Drawing.Point(5, 5);
            this.lblTitleIntegratingLog.Name = "lblTitleIntegratingLog";
            this.lblTitleIntegratingLog.Size = new System.Drawing.Size(790, 30);
            this.lblTitleIntegratingLog.TabIndex = 38;
            this.lblTitleIntegratingLog.Text = "LỊCH SỬ TÍCH HỢP DỮ LIỆU";
            this.lblTitleIntegratingLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsrIntegratingLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitleIntegratingLog);
            this.Name = "UsrIntegratingLog";
            this.Size = new System.Drawing.Size(800, 600);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntegratingLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChanges)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.cmsLogTable.ResumeLayout(false);
            this.tsmLog.ResumeLayout(false);
            this.tsmLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlFilterBox;
        private CommonControls.Custom.CommonToolStrip tsmLog;
        private System.Windows.Forms.ToolStripButton btnShowHideFilter;
        private CommonControls.Custom.TitleLabel lblTitleIntegratingLog;
        private System.Windows.Forms.CheckBox cbxFilterByLoginTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTimeFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTimeTo;
        private System.Windows.Forms.RadioButton rbtnLoginFail;
        private System.Windows.Forms.RadioButton rbtnLoginSuccess;
        private System.Windows.Forms.CheckBox cbxFilterByLoginResult;
        private System.Windows.Forms.ToolStripButton btnReloadData;
        private System.Windows.Forms.ContextMenuStrip cmsLogTable;
        private System.Windows.Forms.ToolStripMenuItem mnuReloadData;
        private System.Windows.Forms.ComboBox cmbChangedTypes;
        private System.Windows.Forms.CheckBox cbxFilterByChangedType;
        private CommonControls.Custom.CommonDataGridView dgvIntegratingLogs;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem mniExportToExcel;
        private CommonControls.Custom.CommonDataGridView dgvChanges;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableNameVietnamese;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChangedType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIntegratingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChanges;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
    }
}
