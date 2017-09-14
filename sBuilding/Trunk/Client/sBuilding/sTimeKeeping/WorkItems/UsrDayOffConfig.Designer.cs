namespace sTimeKeeping.WorkItems {
    partial class UsrDayOffConfig {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lblRightAreaTitleDayOffConfig = new CommonControls.Custom.TitleLabel();
            this.tsDayOff = new CommonControls.Custom.CommonToolStrip();
            this.btnAddDayOff = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateDayOffConfig = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteDayOffConfig = new System.Windows.Forms.ToolStripButton();
            this.btnImportDayOffConfig = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshDayOffList = new System.Windows.Forms.ToolStripButton();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.tbxFilterByMemberName = new System.Windows.Forms.TextBox();
            this.lblFilterByMemberName = new System.Windows.Forms.Label();
            this.tbxFilterByMemberCode = new System.Windows.Forms.TextBox();
            this.lblFilterByMemberCode = new System.Windows.Forms.Label();
            this.lblFilterByCondition = new System.Windows.Forms.Label();
            this.dpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.lblDateEnd = new System.Windows.Forms.Label();
            this.dpDateStart = new System.Windows.Forms.DateTimePicker();
            this.lblDateBegin = new System.Windows.Forms.Label();
            this.pnlMainParent2 = new System.Windows.Forms.Panel();
            this.dgvListDayOff = new CommonControls.Custom.CommonDataGridView();
            this.colDayOffId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDayOffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDayOff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMainParent3 = new System.Windows.Forms.Panel();
            this.pnlMainParent = new System.Windows.Forms.Panel();
            this.lblLeftAreaTitleOrg = new CommonControls.Custom.TitleLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pnlOrgParent = new System.Windows.Forms.Panel();
            this.pnlOrgParent2 = new System.Windows.Forms.Panel();
            this.tvOrganizationList = new System.Windows.Forms.TreeView();
            this.tsOrganization = new CommonControls.Custom.CommonToolStrip();
            this.btnRefreshOrg = new System.Windows.Forms.ToolStripButton();
            this.cmsDayOff = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAddDayOff = new System.Windows.Forms.ToolStripMenuItem();
            this.miUpdateDayOff = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteDayOff = new System.Windows.Forms.ToolStripMenuItem();
            this.miRefreshDayOff = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDayOff.SuspendLayout();
            this.pnlFilterBox.SuspendLayout();
            this.pnlMainParent2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDayOff)).BeginInit();
            this.pnlMainParent3.SuspendLayout();
            this.pnlMainParent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlOrgParent.SuspendLayout();
            this.pnlOrgParent2.SuspendLayout();
            this.tsOrganization.SuspendLayout();
            this.cmsDayOff.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRightAreaTitleDayOffConfig
            // 
            this.lblRightAreaTitleDayOffConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitleDayOffConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitleDayOffConfig.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblRightAreaTitleDayOffConfig.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitleDayOffConfig.Location = new System.Drawing.Point(0, 0);
            this.lblRightAreaTitleDayOffConfig.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRightAreaTitleDayOffConfig.Name = "lblRightAreaTitleDayOffConfig";
            this.lblRightAreaTitleDayOffConfig.Size = new System.Drawing.Size(1712, 69);
            this.lblRightAreaTitleDayOffConfig.TabIndex = 0;
            this.lblRightAreaTitleDayOffConfig.Text = "ĐĂNG KÝ NGÀY NGHỈ";
            this.lblRightAreaTitleDayOffConfig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tsDayOff
            // 
            this.tsDayOff.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsDayOff.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddDayOff,
            this.btnUpdateDayOffConfig,
            this.btnDeleteDayOffConfig,
            this.btnImportDayOffConfig,
            this.btnRefreshDayOffList});
            this.tsDayOff.Location = new System.Drawing.Point(0, 0);
            this.tsDayOff.Name = "tsDayOff";
            this.tsDayOff.Padding = new System.Windows.Forms.Padding(0);
            this.tsDayOff.Size = new System.Drawing.Size(1686, 38);
            this.tsDayOff.TabIndex = 0;
            this.tsDayOff.Text = "tlstripListUser";
            // 
            // btnAddDayOff
            // 
            this.btnAddDayOff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddDayOff.Enabled = false;
            this.btnAddDayOff.Image = global::sTimeKeeping.Properties.Resources.btnAdd;
            this.btnAddDayOff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDayOff.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnAddDayOff.Name = "btnAddDayOff";
            this.btnAddDayOff.Size = new System.Drawing.Size(36, 36);
            this.btnAddDayOff.ToolTipText = "Thêm ngày nghỉ mới cho nhân viên";
            // 
            // btnUpdateDayOffConfig
            // 
            this.btnUpdateDayOffConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateDayOffConfig.Enabled = false;
            this.btnUpdateDayOffConfig.Image = global::sTimeKeeping.Properties.Resources.btnUpdate;
            this.btnUpdateDayOffConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateDayOffConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnUpdateDayOffConfig.Name = "btnUpdateDayOffConfig";
            this.btnUpdateDayOffConfig.Size = new System.Drawing.Size(36, 36);
            this.btnUpdateDayOffConfig.ToolTipText = "Sửa/Cập nhật cấu hình ngày nghỉ";
            // 
            // btnDeleteDayOffConfig
            // 
            this.btnDeleteDayOffConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteDayOffConfig.Enabled = false;
            this.btnDeleteDayOffConfig.Image = global::sTimeKeeping.Properties.Resources.btnDelete;
            this.btnDeleteDayOffConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteDayOffConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnDeleteDayOffConfig.Name = "btnDeleteDayOffConfig";
            this.btnDeleteDayOffConfig.Size = new System.Drawing.Size(36, 36);
            this.btnDeleteDayOffConfig.ToolTipText = "Xóa ngày nghỉ";
            // 
            // btnImportDayOffConfig
            // 
            this.btnImportDayOffConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImportDayOffConfig.Enabled = false;
            this.btnImportDayOffConfig.Image = global::sTimeKeeping.Properties.Resources.Wheel_16x16;
            this.btnImportDayOffConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportDayOffConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnImportDayOffConfig.Name = "btnImportDayOffConfig";
            this.btnImportDayOffConfig.Size = new System.Drawing.Size(36, 36);
            this.btnImportDayOffConfig.ToolTipText = "Thích hợp ngày nghỉ";
            // 
            // btnRefreshDayOffList
            // 
            this.btnRefreshDayOffList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshDayOffList.Enabled = false;
            this.btnRefreshDayOffList.Image = global::sTimeKeeping.Properties.Resources.btnRefresh;
            this.btnRefreshDayOffList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshDayOffList.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnRefreshDayOffList.Name = "btnRefreshDayOffList";
            this.btnRefreshDayOffList.Size = new System.Drawing.Size(36, 36);
            this.btnRefreshDayOffList.ToolTipText = "Làm mới cấu hình ngày nghỉ";
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilterBox.Controls.Add(this.tbxFilterByMemberName);
            this.pnlFilterBox.Controls.Add(this.lblFilterByMemberName);
            this.pnlFilterBox.Controls.Add(this.tbxFilterByMemberCode);
            this.pnlFilterBox.Controls.Add(this.lblFilterByMemberCode);
            this.pnlFilterBox.Controls.Add(this.lblFilterByCondition);
            this.pnlFilterBox.Controls.Add(this.dpDateEnd);
            this.pnlFilterBox.Controls.Add(this.lblDateEnd);
            this.pnlFilterBox.Controls.Add(this.dpDateStart);
            this.pnlFilterBox.Controls.Add(this.lblDateBegin);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 38);
            this.pnlFilterBox.Margin = new System.Windows.Forms.Padding(6);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.pnlFilterBox.Size = new System.Drawing.Size(1686, 240);
            this.pnlFilterBox.TabIndex = 0;
            // 
            // tbxFilterByMemberName
            // 
            this.tbxFilterByMemberName.Enabled = false;
            this.tbxFilterByMemberName.Location = new System.Drawing.Point(1236, 156);
            this.tbxFilterByMemberName.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbxFilterByMemberName.Name = "tbxFilterByMemberName";
            this.tbxFilterByMemberName.Size = new System.Drawing.Size(436, 37);
            this.tbxFilterByMemberName.TabIndex = 4;
            // 
            // lblFilterByMemberName
            // 
            this.lblFilterByMemberName.AutoSize = true;
            this.lblFilterByMemberName.BackColor = System.Drawing.Color.Transparent;
            this.lblFilterByMemberName.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblFilterByMemberName.Location = new System.Drawing.Point(872, 159);
            this.lblFilterByMemberName.Margin = new System.Windows.Forms.Padding(16, 4, 16, 4);
            this.lblFilterByMemberName.Name = "lblFilterByMemberName";
            this.lblFilterByMemberName.Size = new System.Drawing.Size(280, 30);
            this.lblFilterByMemberName.TabIndex = 0;
            this.lblFilterByMemberName.Text = "Tìm theo tên nhân viên:";
            this.lblFilterByMemberName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxFilterByMemberCode
            // 
            this.tbxFilterByMemberCode.Enabled = false;
            this.tbxFilterByMemberCode.Location = new System.Drawing.Point(1236, 81);
            this.tbxFilterByMemberCode.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbxFilterByMemberCode.Name = "tbxFilterByMemberCode";
            this.tbxFilterByMemberCode.Size = new System.Drawing.Size(250, 37);
            this.tbxFilterByMemberCode.TabIndex = 3;
            // 
            // lblFilterByMemberCode
            // 
            this.lblFilterByMemberCode.AutoSize = true;
            this.lblFilterByMemberCode.BackColor = System.Drawing.Color.Transparent;
            this.lblFilterByMemberCode.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblFilterByMemberCode.Location = new System.Drawing.Point(872, 84);
            this.lblFilterByMemberCode.Margin = new System.Windows.Forms.Padding(16, 4, 16, 4);
            this.lblFilterByMemberCode.Name = "lblFilterByMemberCode";
            this.lblFilterByMemberCode.Size = new System.Drawing.Size(279, 30);
            this.lblFilterByMemberCode.TabIndex = 0;
            this.lblFilterByMemberCode.Text = "Tìm theo mã nhân viên:";
            this.lblFilterByMemberCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFilterByCondition
            // 
            this.lblFilterByCondition.AutoSize = true;
            this.lblFilterByCondition.BackColor = System.Drawing.Color.Transparent;
            this.lblFilterByCondition.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblFilterByCondition.Location = new System.Drawing.Point(28, 15);
            this.lblFilterByCondition.Margin = new System.Windows.Forms.Padding(16, 4, 16, 4);
            this.lblFilterByCondition.Name = "lblFilterByCondition";
            this.lblFilterByCondition.Size = new System.Drawing.Size(296, 30);
            this.lblFilterByCondition.TabIndex = 0;
            this.lblFilterByCondition.Text = "Lọc theo ngày tháng năm";
            this.lblFilterByCondition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dpDateEnd
            // 
            this.dpDateEnd.CustomFormat = "dd/MM/yyyy";
            this.dpDateEnd.Enabled = false;
            this.dpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDateEnd.Location = new System.Drawing.Point(280, 156);
            this.dpDateEnd.Margin = new System.Windows.Forms.Padding(6);
            this.dpDateEnd.Name = "dpDateEnd";
            this.dpDateEnd.Size = new System.Drawing.Size(268, 37);
            this.dpDateEnd.TabIndex = 2;
            // 
            // lblDateEnd
            // 
            this.lblDateEnd.AutoSize = true;
            this.lblDateEnd.BackColor = System.Drawing.Color.Transparent;
            this.lblDateEnd.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblDateEnd.Location = new System.Drawing.Point(84, 159);
            this.lblDateEnd.Margin = new System.Windows.Forms.Padding(16, 4, 16, 4);
            this.lblDateEnd.Name = "lblDateEnd";
            this.lblDateEnd.Size = new System.Drawing.Size(175, 30);
            this.lblDateEnd.TabIndex = 0;
            this.lblDateEnd.Text = "Ngày kết thúc:";
            this.lblDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dpDateStart
            // 
            this.dpDateStart.CustomFormat = "dd/MM/yyyy";
            this.dpDateStart.Enabled = false;
            this.dpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDateStart.Location = new System.Drawing.Point(280, 81);
            this.dpDateStart.Margin = new System.Windows.Forms.Padding(6);
            this.dpDateStart.Name = "dpDateStart";
            this.dpDateStart.Size = new System.Drawing.Size(268, 37);
            this.dpDateStart.TabIndex = 1;
            // 
            // lblDateBegin
            // 
            this.lblDateBegin.AutoSize = true;
            this.lblDateBegin.BackColor = System.Drawing.Color.Transparent;
            this.lblDateBegin.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblDateBegin.Location = new System.Drawing.Point(84, 84);
            this.lblDateBegin.Margin = new System.Windows.Forms.Padding(16, 4, 16, 4);
            this.lblDateBegin.Name = "lblDateBegin";
            this.lblDateBegin.Size = new System.Drawing.Size(170, 30);
            this.lblDateBegin.TabIndex = 0;
            this.lblDateBegin.Text = "Ngày bắt đầu:";
            this.lblDateBegin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMainParent2
            // 
            this.pnlMainParent2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMainParent2.Controls.Add(this.dgvListDayOff);
            this.pnlMainParent2.Controls.Add(this.pnlFilterBox);
            this.pnlMainParent2.Controls.Add(this.tsDayOff);
            this.pnlMainParent2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainParent2.Location = new System.Drawing.Point(12, 13);
            this.pnlMainParent2.Margin = new System.Windows.Forms.Padding(6);
            this.pnlMainParent2.Name = "pnlMainParent2";
            this.pnlMainParent2.Size = new System.Drawing.Size(1688, 1163);
            this.pnlMainParent2.TabIndex = 0;
            // 
            // dgvListDayOff
            // 
            this.dgvListDayOff.AllowDrop = true;
            this.dgvListDayOff.AllowUserToAddRows = false;
            this.dgvListDayOff.AllowUserToDeleteRows = false;
            this.dgvListDayOff.AllowUserToOrderColumns = true;
            this.dgvListDayOff.AllowUserToResizeRows = false;
            this.dgvListDayOff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListDayOff.BackgroundColor = System.Drawing.Color.White;
            this.dgvListDayOff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListDayOff.ColumnHeadersHeight = 30;
            this.dgvListDayOff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDayOffId,
            this.colDayOffNo,
            this.colMemCode,
            this.colMemberName,
            this.colDayOff,
            this.colStatus});
            this.dgvListDayOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListDayOff.Enabled = false;
            this.dgvListDayOff.Location = new System.Drawing.Point(0, 278);
            this.dgvListDayOff.Margin = new System.Windows.Forms.Padding(6);
            this.dgvListDayOff.Name = "dgvListDayOff";
            this.dgvListDayOff.ReadOnly = true;
            this.dgvListDayOff.RowHeadersVisible = false;
            this.dgvListDayOff.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvListDayOff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListDayOff.Size = new System.Drawing.Size(1686, 883);
            this.dgvListDayOff.TabIndex = 0;
            this.dgvListDayOff.TabStop = false;
            // 
            // colDayOffId
            // 
            this.colDayOffId.DataPropertyName = "colDayOffId";
            this.colDayOffId.FillWeight = 1F;
            this.colDayOffId.HeaderText = "Id";
            this.colDayOffId.Name = "colDayOffId";
            this.colDayOffId.ReadOnly = true;
            this.colDayOffId.Visible = false;
            // 
            // colDayOffNo
            // 
            this.colDayOffNo.DataPropertyName = "colDayOffNo";
            this.colDayOffNo.FillWeight = 5F;
            this.colDayOffNo.HeaderText = "No.";
            this.colDayOffNo.Name = "colDayOffNo";
            this.colDayOffNo.ReadOnly = true;
            // 
            // colMemCode
            // 
            this.colMemCode.DataPropertyName = "colMemCode";
            this.colMemCode.FillWeight = 15F;
            this.colMemCode.HeaderText = "Mã nhân viên";
            this.colMemCode.Name = "colMemCode";
            this.colMemCode.ReadOnly = true;
            this.colMemCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colMemberName
            // 
            this.colMemberName.DataPropertyName = "colMemberName";
            this.colMemberName.FillWeight = 35F;
            this.colMemberName.HeaderText = "Họ Tên";
            this.colMemberName.Name = "colMemberName";
            this.colMemberName.ReadOnly = true;
            this.colMemberName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colDayOff
            // 
            this.colDayOff.DataPropertyName = "colDayOff";
            this.colDayOff.FillWeight = 20F;
            this.colDayOff.HeaderText = "Ngày đăng ký";
            this.colDayOff.Name = "colDayOff";
            this.colDayOff.ReadOnly = true;
            this.colDayOff.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "colStatus";
            this.colStatus.FillWeight = 25F;
            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // pnlMainParent3
            // 
            this.pnlMainParent3.Controls.Add(this.pnlMainParent2);
            this.pnlMainParent3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainParent3.Location = new System.Drawing.Point(0, 0);
            this.pnlMainParent3.Margin = new System.Windows.Forms.Padding(6);
            this.pnlMainParent3.Name = "pnlMainParent3";
            this.pnlMainParent3.Padding = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.pnlMainParent3.Size = new System.Drawing.Size(1712, 1189);
            this.pnlMainParent3.TabIndex = 0;
            // 
            // pnlMainParent
            // 
            this.pnlMainParent.Controls.Add(this.pnlMainParent3);
            this.pnlMainParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainParent.Location = new System.Drawing.Point(0, 69);
            this.pnlMainParent.Margin = new System.Windows.Forms.Padding(6);
            this.pnlMainParent.Name = "pnlMainParent";
            this.pnlMainParent.Size = new System.Drawing.Size(1712, 1189);
            this.pnlMainParent.TabIndex = 0;
            // 
            // lblLeftAreaTitleOrg
            // 
            this.lblLeftAreaTitleOrg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblLeftAreaTitleOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftAreaTitleOrg.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblLeftAreaTitleOrg.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLeftAreaTitleOrg.Location = new System.Drawing.Point(0, 0);
            this.lblLeftAreaTitleOrg.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLeftAreaTitleOrg.Name = "lblLeftAreaTitleOrg";
            this.lblLeftAreaTitleOrg.Size = new System.Drawing.Size(648, 69);
            this.lblLeftAreaTitleOrg.TabIndex = 0;
            this.lblLeftAreaTitleOrg.Text = "DANH SACH TỔ CHỨC";
            this.lblLeftAreaTitleOrg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.splitContainer.Location = new System.Drawing.Point(12, 13);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pnlOrgParent);
            this.splitContainer.Panel1.Controls.Add(this.lblLeftAreaTitleOrg);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pnlMainParent);
            this.splitContainer.Panel2.Controls.Add(this.lblRightAreaTitleDayOffConfig);
            this.splitContainer.Size = new System.Drawing.Size(2376, 1260);
            this.splitContainer.SplitterDistance = 650;
            this.splitContainer.SplitterWidth = 12;
            this.splitContainer.TabIndex = 0;
            this.splitContainer.TabStop = false;
            // 
            // pnlOrgParent
            // 
            this.pnlOrgParent.Controls.Add(this.pnlOrgParent2);
            this.pnlOrgParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrgParent.Location = new System.Drawing.Point(0, 69);
            this.pnlOrgParent.Margin = new System.Windows.Forms.Padding(6);
            this.pnlOrgParent.Name = "pnlOrgParent";
            this.pnlOrgParent.Padding = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.pnlOrgParent.Size = new System.Drawing.Size(648, 1189);
            this.pnlOrgParent.TabIndex = 1;
            // 
            // pnlOrgParent2
            // 
            this.pnlOrgParent2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOrgParent2.Controls.Add(this.tvOrganizationList);
            this.pnlOrgParent2.Controls.Add(this.tsOrganization);
            this.pnlOrgParent2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrgParent2.Location = new System.Drawing.Point(12, 13);
            this.pnlOrgParent2.Margin = new System.Windows.Forms.Padding(6);
            this.pnlOrgParent2.Name = "pnlOrgParent2";
            this.pnlOrgParent2.Size = new System.Drawing.Size(624, 1163);
            this.pnlOrgParent2.TabIndex = 0;
            // 
            // tvOrganizationList
            // 
            this.tvOrganizationList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvOrganizationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOrganizationList.Location = new System.Drawing.Point(0, 38);
            this.tvOrganizationList.Margin = new System.Windows.Forms.Padding(6);
            this.tvOrganizationList.Name = "tvOrganizationList";
            this.tvOrganizationList.Size = new System.Drawing.Size(622, 1123);
            this.tvOrganizationList.TabIndex = 0;
            this.tvOrganizationList.TabStop = false;
            // 
            // tsOrganization
            // 
            this.tsOrganization.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsOrganization.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshOrg});
            this.tsOrganization.Location = new System.Drawing.Point(0, 0);
            this.tsOrganization.Name = "tsOrganization";
            this.tsOrganization.Padding = new System.Windows.Forms.Padding(0);
            this.tsOrganization.Size = new System.Drawing.Size(622, 38);
            this.tsOrganization.TabIndex = 0;
            this.tsOrganization.Text = "tlstripListGroup";
            // 
            // btnRefreshOrg
            // 
            this.btnRefreshOrg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshOrg.Image = global::sTimeKeeping.Properties.Resources.btnRefresh;
            this.btnRefreshOrg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshOrg.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnRefreshOrg.Name = "btnRefreshOrg";
            this.btnRefreshOrg.Size = new System.Drawing.Size(36, 36);
            this.btnRefreshOrg.ToolTipText = "Làm mới danh sách tổ chức";
            // 
            // cmsDayOff
            // 
            this.cmsDayOff.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cmsDayOff.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddDayOff,
            this.miUpdateDayOff,
            this.miDeleteDayOff,
            this.miRefreshDayOff});
            this.cmsDayOff.Name = "cmsDayOff";
            this.cmsDayOff.Size = new System.Drawing.Size(198, 156);
            // 
            // miAddDayOff
            // 
            this.miAddDayOff.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miAddDayOff.Image = global::sTimeKeeping.Properties.Resources.btnAdd;
            this.miAddDayOff.Name = "miAddDayOff";
            this.miAddDayOff.Size = new System.Drawing.Size(197, 38);
            this.miAddDayOff.Text = "Thêm";
            // 
            // miUpdateDayOff
            // 
            this.miUpdateDayOff.Font = new System.Drawing.Font("Tahoma", 9F);
            this.miUpdateDayOff.Image = global::sTimeKeeping.Properties.Resources.btnUpdate;
            this.miUpdateDayOff.Name = "miUpdateDayOff";
            this.miUpdateDayOff.Size = new System.Drawing.Size(197, 38);
            this.miUpdateDayOff.Text = "Cập nhật";
            // 
            // miDeleteDayOff
            // 
            this.miDeleteDayOff.Font = new System.Drawing.Font("Tahoma", 9F);
            this.miDeleteDayOff.Image = global::sTimeKeeping.Properties.Resources.btnDelete;
            this.miDeleteDayOff.Name = "miDeleteDayOff";
            this.miDeleteDayOff.Size = new System.Drawing.Size(197, 38);
            this.miDeleteDayOff.Text = "Xóa";
            // 
            // miRefreshDayOff
            // 
            this.miRefreshDayOff.Font = new System.Drawing.Font("Tahoma", 9F);
            this.miRefreshDayOff.Image = global::sTimeKeeping.Properties.Resources.btnRefresh;
            this.miRefreshDayOff.Name = "miRefreshDayOff";
            this.miRefreshDayOff.Size = new System.Drawing.Size(197, 38);
            this.miRefreshDayOff.Text = "Làm mới";
            // 
            // UsrDayOffConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UsrDayOffConfig";
            this.Padding = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.Size = new System.Drawing.Size(2400, 1286);
            this.tsDayOff.ResumeLayout(false);
            this.tsDayOff.PerformLayout();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.pnlMainParent2.ResumeLayout(false);
            this.pnlMainParent2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDayOff)).EndInit();
            this.pnlMainParent3.ResumeLayout(false);
            this.pnlMainParent.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.pnlOrgParent.ResumeLayout(false);
            this.pnlOrgParent2.ResumeLayout(false);
            this.pnlOrgParent2.PerformLayout();
            this.tsOrganization.ResumeLayout(false);
            this.tsOrganization.PerformLayout();
            this.cmsDayOff.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControls.Custom.TitleLabel lblRightAreaTitleDayOffConfig;
        private System.Windows.Forms.ToolStripButton btnUpdateDayOffConfig;
        private CommonControls.Custom.CommonToolStrip tsDayOff;
        private System.Windows.Forms.ToolStripButton btnRefreshDayOffList;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Panel pnlMainParent2;
        private System.Windows.Forms.Panel pnlMainParent3;
        private System.Windows.Forms.Panel pnlMainParent;
        private CommonControls.Custom.TitleLabel lblLeftAreaTitleOrg;
        private System.Windows.Forms.SplitContainer splitContainer;
        private CommonControls.Custom.CommonDataGridView dgvListDayOff;
        private System.Windows.Forms.Label lblFilterByCondition;
        private System.Windows.Forms.DateTimePicker dpDateEnd;
        private System.Windows.Forms.Label lblDateEnd;
        private System.Windows.Forms.DateTimePicker dpDateStart;
        private System.Windows.Forms.Label lblDateBegin;
        private System.Windows.Forms.ToolStripButton btnAddDayOff;
        private System.Windows.Forms.TextBox tbxFilterByMemberName;
        private System.Windows.Forms.Label lblFilterByMemberName;
        private System.Windows.Forms.TextBox tbxFilterByMemberCode;
        private System.Windows.Forms.Label lblFilterByMemberCode;
        private System.Windows.Forms.ToolStripButton btnDeleteDayOffConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDayOffId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDayOffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDayOff;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.ContextMenuStrip cmsDayOff;
        private System.Windows.Forms.ToolStripMenuItem miAddDayOff;
        private System.Windows.Forms.ToolStripMenuItem miUpdateDayOff;
        private System.Windows.Forms.ToolStripMenuItem miDeleteDayOff;
        private System.Windows.Forms.ToolStripMenuItem miRefreshDayOff;
        private System.Windows.Forms.Panel pnlOrgParent;
        private System.Windows.Forms.Panel pnlOrgParent2;
        private System.Windows.Forms.TreeView tvOrganizationList;
        private CommonControls.Custom.CommonToolStrip tsOrganization;
        private System.Windows.Forms.ToolStripButton btnRefreshOrg;
        private System.Windows.Forms.ToolStripButton btnImportDayOffConfig;
    }
}
