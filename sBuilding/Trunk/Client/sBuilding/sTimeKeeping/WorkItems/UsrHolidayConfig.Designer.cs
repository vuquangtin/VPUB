namespace sTimeKeeping.WorkItems {
    partial class UsrHolidayConfig {
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
            this.lblRightAreaTitleHolidayConfig = new CommonControls.Custom.TitleLabel();
            this.tvOrganizationList = new System.Windows.Forms.TreeView();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pnlOrgParent = new System.Windows.Forms.Panel();
            this.pnlOrgParent2 = new System.Windows.Forms.Panel();
            this.tsOrganization = new CommonControls.Custom.CommonToolStrip();
            this.btnRefreshOrg = new System.Windows.Forms.ToolStripButton();
            this.lblLeftAreaTitleOrg = new CommonControls.Custom.TitleLabel();
            this.pnlMainParent = new System.Windows.Forms.Panel();
            this.pnlMainParent3 = new System.Windows.Forms.Panel();
            this.pnlMainParent2 = new System.Windows.Forms.Panel();
            this.dgvListHoliday = new CommonControls.Custom.CommonDataGridView();
            this.colHolidayId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHolidayNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHolidayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHolidayStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHolidayEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.lblFilterByCondition = new System.Windows.Forms.Label();
            this.dpHolidayEnd = new System.Windows.Forms.DateTimePicker();
            this.lblDateEnd = new System.Windows.Forms.Label();
            this.dpHolidayStart = new System.Windows.Forms.DateTimePicker();
            this.lblDateBegin = new System.Windows.Forms.Label();
            this.tsHoliday = new CommonControls.Custom.CommonToolStrip();
            this.btnAddHolidayConfig = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateHolidayConfig = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteHolidayConfig = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshHolidayConfig = new System.Windows.Forms.ToolStripButton();
            this.cmsHoliday = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAddHoliday = new System.Windows.Forms.ToolStripMenuItem();
            this.miUpdateHoliday = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteHoliday = new System.Windows.Forms.ToolStripMenuItem();
            this.miRefreshHoliday = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlOrgParent.SuspendLayout();
            this.pnlOrgParent2.SuspendLayout();
            this.tsOrganization.SuspendLayout();
            this.pnlMainParent.SuspendLayout();
            this.pnlMainParent3.SuspendLayout();
            this.pnlMainParent2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListHoliday)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.tsHoliday.SuspendLayout();
            this.cmsHoliday.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRightAreaTitleHolidayConfig
            // 
            this.lblRightAreaTitleHolidayConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitleHolidayConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitleHolidayConfig.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblRightAreaTitleHolidayConfig.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitleHolidayConfig.Location = new System.Drawing.Point(0, 0);
            this.lblRightAreaTitleHolidayConfig.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRightAreaTitleHolidayConfig.Name = "lblRightAreaTitleHolidayConfig";
            this.lblRightAreaTitleHolidayConfig.Size = new System.Drawing.Size(1712, 69);
            this.lblRightAreaTitleHolidayConfig.TabIndex = 0;
            this.lblRightAreaTitleHolidayConfig.Text = "CẤU HÌNH NGÀY LỄ";
            this.lblRightAreaTitleHolidayConfig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tvOrganizationList
            // 
            this.tvOrganizationList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvOrganizationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOrganizationList.Location = new System.Drawing.Point(0, 38);
            this.tvOrganizationList.Margin = new System.Windows.Forms.Padding(6);
            this.tvOrganizationList.Name = "tvOrganizationList";
            this.tvOrganizationList.Size = new System.Drawing.Size(622, 1127);
            this.tvOrganizationList.TabIndex = 0;
            this.tvOrganizationList.TabStop = false;
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(12, 12);
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
            this.splitContainer.Panel2.Controls.Add(this.lblRightAreaTitleHolidayConfig);
            this.splitContainer.Size = new System.Drawing.Size(2376, 1262);
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
            this.pnlOrgParent.Padding = new System.Windows.Forms.Padding(12);
            this.pnlOrgParent.Size = new System.Drawing.Size(648, 1191);
            this.pnlOrgParent.TabIndex = 0;
            // 
            // pnlOrgParent2
            // 
            this.pnlOrgParent2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOrgParent2.Controls.Add(this.tvOrganizationList);
            this.pnlOrgParent2.Controls.Add(this.tsOrganization);
            this.pnlOrgParent2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrgParent2.Location = new System.Drawing.Point(12, 12);
            this.pnlOrgParent2.Margin = new System.Windows.Forms.Padding(6);
            this.pnlOrgParent2.Name = "pnlOrgParent2";
            this.pnlOrgParent2.Size = new System.Drawing.Size(624, 1167);
            this.pnlOrgParent2.TabIndex = 0;
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
            // pnlMainParent
            // 
            this.pnlMainParent.Controls.Add(this.pnlMainParent3);
            this.pnlMainParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainParent.Location = new System.Drawing.Point(0, 69);
            this.pnlMainParent.Margin = new System.Windows.Forms.Padding(6);
            this.pnlMainParent.Name = "pnlMainParent";
            this.pnlMainParent.Size = new System.Drawing.Size(1712, 1191);
            this.pnlMainParent.TabIndex = 0;
            // 
            // pnlMainParent3
            // 
            this.pnlMainParent3.Controls.Add(this.pnlMainParent2);
            this.pnlMainParent3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainParent3.Location = new System.Drawing.Point(0, 0);
            this.pnlMainParent3.Margin = new System.Windows.Forms.Padding(6);
            this.pnlMainParent3.Name = "pnlMainParent3";
            this.pnlMainParent3.Padding = new System.Windows.Forms.Padding(12);
            this.pnlMainParent3.Size = new System.Drawing.Size(1712, 1191);
            this.pnlMainParent3.TabIndex = 0;
            // 
            // pnlMainParent2
            // 
            this.pnlMainParent2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMainParent2.Controls.Add(this.dgvListHoliday);
            this.pnlMainParent2.Controls.Add(this.pnlFilterBox);
            this.pnlMainParent2.Controls.Add(this.tsHoliday);
            this.pnlMainParent2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainParent2.Location = new System.Drawing.Point(12, 12);
            this.pnlMainParent2.Margin = new System.Windows.Forms.Padding(6);
            this.pnlMainParent2.Name = "pnlMainParent2";
            this.pnlMainParent2.Size = new System.Drawing.Size(1688, 1167);
            this.pnlMainParent2.TabIndex = 0;
            // 
            // dgvListHoliday
            // 
            this.dgvListHoliday.AllowDrop = true;
            this.dgvListHoliday.AllowUserToAddRows = false;
            this.dgvListHoliday.AllowUserToDeleteRows = false;
            this.dgvListHoliday.AllowUserToOrderColumns = true;
            this.dgvListHoliday.AllowUserToResizeRows = false;
            this.dgvListHoliday.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListHoliday.BackgroundColor = System.Drawing.Color.White;
            this.dgvListHoliday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListHoliday.ColumnHeadersHeight = 30;
            this.dgvListHoliday.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHolidayId,
            this.colHolidayNo,
            this.colHolidayName,
            this.colHolidayStart,
            this.colHolidayEnd,
            this.colDescription});
            this.dgvListHoliday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListHoliday.Enabled = false;
            this.dgvListHoliday.Location = new System.Drawing.Point(0, 278);
            this.dgvListHoliday.Margin = new System.Windows.Forms.Padding(6);
            this.dgvListHoliday.Name = "dgvListHoliday";
            this.dgvListHoliday.ReadOnly = true;
            this.dgvListHoliday.RowHeadersVisible = false;
            this.dgvListHoliday.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvListHoliday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListHoliday.Size = new System.Drawing.Size(1686, 887);
            this.dgvListHoliday.TabIndex = 3;
            // 
            // colHolidayId
            // 
            this.colHolidayId.DataPropertyName = "colHolidayId";
            this.colHolidayId.FillWeight = 1F;
            this.colHolidayId.HeaderText = "Id";
            this.colHolidayId.Name = "colHolidayId";
            this.colHolidayId.ReadOnly = true;
            this.colHolidayId.Visible = false;
            // 
            // colHolidayNo
            // 
            this.colHolidayNo.DataPropertyName = "colHolidayNo";
            this.colHolidayNo.FillWeight = 5F;
            this.colHolidayNo.HeaderText = "No.";
            this.colHolidayNo.Name = "colHolidayNo";
            this.colHolidayNo.ReadOnly = true;
            // 
            // colHolidayName
            // 
            this.colHolidayName.DataPropertyName = "colHolidayName";
            this.colHolidayName.FillWeight = 25F;
            this.colHolidayName.HeaderText = "Tên Ngày lễ";
            this.colHolidayName.Name = "colHolidayName";
            this.colHolidayName.ReadOnly = true;
            // 
            // colHolidayStart
            // 
            this.colHolidayStart.DataPropertyName = "colHolidayStart";
            this.colHolidayStart.FillWeight = 15F;
            this.colHolidayStart.HeaderText = "Ngày bắt đầu";
            this.colHolidayStart.Name = "colHolidayStart";
            this.colHolidayStart.ReadOnly = true;
            // 
            // colHolidayEnd
            // 
            this.colHolidayEnd.DataPropertyName = "colHolidayEnd";
            this.colHolidayEnd.FillWeight = 15F;
            this.colHolidayEnd.HeaderText = "Ngày kết thúc";
            this.colHolidayEnd.Name = "colHolidayEnd";
            this.colHolidayEnd.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "colDescription";
            this.colDescription.FillWeight = 40F;
            this.colDescription.HeaderText = "Mô tả";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilterBox.Controls.Add(this.lblFilterByCondition);
            this.pnlFilterBox.Controls.Add(this.dpHolidayEnd);
            this.pnlFilterBox.Controls.Add(this.lblDateEnd);
            this.pnlFilterBox.Controls.Add(this.dpHolidayStart);
            this.pnlFilterBox.Controls.Add(this.lblDateBegin);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 38);
            this.pnlFilterBox.Margin = new System.Windows.Forms.Padding(6);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(12);
            this.pnlFilterBox.Size = new System.Drawing.Size(1686, 240);
            this.pnlFilterBox.TabIndex = 0;
            // 
            // lblFilterByCondition
            // 
            this.lblFilterByCondition.AutoSize = true;
            this.lblFilterByCondition.BackColor = System.Drawing.Color.Transparent;
            this.lblFilterByCondition.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblFilterByCondition.Location = new System.Drawing.Point(28, 16);
            this.lblFilterByCondition.Margin = new System.Windows.Forms.Padding(16, 4, 16, 4);
            this.lblFilterByCondition.Name = "lblFilterByCondition";
            this.lblFilterByCondition.Size = new System.Drawing.Size(296, 30);
            this.lblFilterByCondition.TabIndex = 0;
            this.lblFilterByCondition.Text = "Lọc theo ngày tháng năm";
            this.lblFilterByCondition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dpHolidayEnd
            // 
            this.dpHolidayEnd.CustomFormat = "dd/MM/yyyy";
            this.dpHolidayEnd.Enabled = false;
            this.dpHolidayEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpHolidayEnd.Location = new System.Drawing.Point(281, 157);
            this.dpHolidayEnd.Margin = new System.Windows.Forms.Padding(6);
            this.dpHolidayEnd.Name = "dpHolidayEnd";
            this.dpHolidayEnd.Size = new System.Drawing.Size(268, 37);
            this.dpHolidayEnd.TabIndex = 2;
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
            // dpHolidayStart
            // 
            this.dpHolidayStart.CustomFormat = "dd/MM/yyyy";
            this.dpHolidayStart.Enabled = false;
            this.dpHolidayStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpHolidayStart.Location = new System.Drawing.Point(281, 82);
            this.dpHolidayStart.Margin = new System.Windows.Forms.Padding(6);
            this.dpHolidayStart.Name = "dpHolidayStart";
            this.dpHolidayStart.Size = new System.Drawing.Size(268, 37);
            this.dpHolidayStart.TabIndex = 1;
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
            // tsHoliday
            // 
            this.tsHoliday.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsHoliday.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddHolidayConfig,
            this.btnUpdateHolidayConfig,
            this.btnDeleteHolidayConfig,
            this.btnRefreshHolidayConfig});
            this.tsHoliday.Location = new System.Drawing.Point(0, 0);
            this.tsHoliday.Name = "tsHoliday";
            this.tsHoliday.Padding = new System.Windows.Forms.Padding(0);
            this.tsHoliday.Size = new System.Drawing.Size(1686, 38);
            this.tsHoliday.TabIndex = 0;
            this.tsHoliday.Text = "tlstripListUser";
            // 
            // btnAddHolidayConfig
            // 
            this.btnAddHolidayConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddHolidayConfig.Enabled = false;
            this.btnAddHolidayConfig.Image = global::sTimeKeeping.Properties.Resources.btnAdd;
            this.btnAddHolidayConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddHolidayConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnAddHolidayConfig.Name = "btnAddHolidayConfig";
            this.btnAddHolidayConfig.Size = new System.Drawing.Size(36, 36);
            this.btnAddHolidayConfig.ToolTipText = "Thêm ngày lễ mới";
            // 
            // btnUpdateHolidayConfig
            // 
            this.btnUpdateHolidayConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateHolidayConfig.Enabled = false;
            this.btnUpdateHolidayConfig.Image = global::sTimeKeeping.Properties.Resources.btnUpdate;
            this.btnUpdateHolidayConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateHolidayConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnUpdateHolidayConfig.Name = "btnUpdateHolidayConfig";
            this.btnUpdateHolidayConfig.Size = new System.Drawing.Size(36, 36);
            this.btnUpdateHolidayConfig.ToolTipText = "Sửa/Cập nhật thông tin ngày lễ";
            // 
            // btnDeleteHolidayConfig
            // 
            this.btnDeleteHolidayConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteHolidayConfig.Enabled = false;
            this.btnDeleteHolidayConfig.Image = global::sTimeKeeping.Properties.Resources.btnDelete;
            this.btnDeleteHolidayConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteHolidayConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnDeleteHolidayConfig.Name = "btnDeleteHolidayConfig";
            this.btnDeleteHolidayConfig.Size = new System.Drawing.Size(36, 36);
            this.btnDeleteHolidayConfig.ToolTipText = "Xóa ngày lễ";
            // 
            // btnRefreshHolidayConfig
            // 
            this.btnRefreshHolidayConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshHolidayConfig.Enabled = false;
            this.btnRefreshHolidayConfig.Image = global::sTimeKeeping.Properties.Resources.btnRefresh;
            this.btnRefreshHolidayConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshHolidayConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnRefreshHolidayConfig.Name = "btnRefreshHolidayConfig";
            this.btnRefreshHolidayConfig.Size = new System.Drawing.Size(36, 36);
            this.btnRefreshHolidayConfig.ToolTipText = "Làm mới danh sách ngày lễ";
            // 
            // cmsHoliday
            // 
            this.cmsHoliday.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cmsHoliday.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddHoliday,
            this.miUpdateHoliday,
            this.miDeleteHoliday,
            this.miRefreshHoliday});
            this.cmsHoliday.Name = "cmsDayOff";
            this.cmsHoliday.Size = new System.Drawing.Size(198, 156);
            // 
            // miAddHoliday
            // 
            this.miAddHoliday.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miAddHoliday.Image = global::sTimeKeeping.Properties.Resources.btnAdd;
            this.miAddHoliday.Name = "miAddHoliday";
            this.miAddHoliday.Size = new System.Drawing.Size(197, 38);
            this.miAddHoliday.Text = "Thêm";
            // 
            // miUpdateHoliday
            // 
            this.miUpdateHoliday.Font = new System.Drawing.Font("Tahoma", 9F);
            this.miUpdateHoliday.Image = global::sTimeKeeping.Properties.Resources.btnUpdate;
            this.miUpdateHoliday.Name = "miUpdateHoliday";
            this.miUpdateHoliday.Size = new System.Drawing.Size(197, 38);
            this.miUpdateHoliday.Text = "Cập nhật";
            // 
            // miDeleteHoliday
            // 
            this.miDeleteHoliday.Font = new System.Drawing.Font("Tahoma", 9F);
            this.miDeleteHoliday.Image = global::sTimeKeeping.Properties.Resources.btnDelete;
            this.miDeleteHoliday.Name = "miDeleteHoliday";
            this.miDeleteHoliday.Size = new System.Drawing.Size(197, 38);
            this.miDeleteHoliday.Text = "Xóa";
            // 
            // miRefreshHoliday
            // 
            this.miRefreshHoliday.Font = new System.Drawing.Font("Tahoma", 9F);
            this.miRefreshHoliday.Image = global::sTimeKeeping.Properties.Resources.btnRefresh;
            this.miRefreshHoliday.Name = "miRefreshHoliday";
            this.miRefreshHoliday.Size = new System.Drawing.Size(197, 38);
            this.miRefreshHoliday.Text = "Làm mới";
            // 
            // UsrHolidayConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UsrHolidayConfig";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Size = new System.Drawing.Size(2400, 1286);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.pnlOrgParent.ResumeLayout(false);
            this.pnlOrgParent2.ResumeLayout(false);
            this.pnlOrgParent2.PerformLayout();
            this.tsOrganization.ResumeLayout(false);
            this.tsOrganization.PerformLayout();
            this.pnlMainParent.ResumeLayout(false);
            this.pnlMainParent3.ResumeLayout(false);
            this.pnlMainParent2.ResumeLayout(false);
            this.pnlMainParent2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListHoliday)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.tsHoliday.ResumeLayout(false);
            this.tsHoliday.PerformLayout();
            this.cmsHoliday.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CommonControls.Custom.TitleLabel lblRightAreaTitleHolidayConfig;
        private System.Windows.Forms.TreeView tvOrganizationList;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel pnlOrgParent;
        private System.Windows.Forms.Panel pnlOrgParent2;
        private CommonControls.Custom.CommonToolStrip tsOrganization;
        private System.Windows.Forms.ToolStripButton btnRefreshOrg;
        private CommonControls.Custom.TitleLabel lblLeftAreaTitleOrg;
        private System.Windows.Forms.Panel pnlMainParent;
        private System.Windows.Forms.Panel pnlMainParent3;
        private System.Windows.Forms.Panel pnlMainParent2;
        private CommonControls.Custom.CommonDataGridView dgvListHoliday;
        private System.Windows.Forms.Panel pnlFilterBox;
        private CommonControls.Custom.CommonToolStrip tsHoliday;
        private System.Windows.Forms.ToolStripButton btnAddHolidayConfig;
        private System.Windows.Forms.ToolStripButton btnUpdateHolidayConfig;
        private System.Windows.Forms.ToolStripButton btnDeleteHolidayConfig;
        private System.Windows.Forms.ToolStripButton btnRefreshHolidayConfig;
        private System.Windows.Forms.DateTimePicker dpHolidayEnd;
        private System.Windows.Forms.Label lblDateEnd;
        private System.Windows.Forms.DateTimePicker dpHolidayStart;
        private System.Windows.Forms.Label lblDateBegin;
        private System.Windows.Forms.Label lblFilterByCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHolidayId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHolidayNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHolidayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHolidayStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHolidayEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.ContextMenuStrip cmsHoliday;
        private System.Windows.Forms.ToolStripMenuItem miAddHoliday;
        private System.Windows.Forms.ToolStripMenuItem miUpdateHoliday;
        private System.Windows.Forms.ToolStripMenuItem miDeleteHoliday;
        private System.Windows.Forms.ToolStripMenuItem miRefreshHoliday;
    }
}
