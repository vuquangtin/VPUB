namespace sTimeKeeping.WorkItems {
    partial class UsrGeneralConfig {
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
            this.lblRightAreaTitleGeneralConfig = new CommonControls.Custom.TitleLabel();
            this.pnlOrgParent = new System.Windows.Forms.Panel();
            this.pnlOrgParent2 = new System.Windows.Forms.Panel();
            this.tvOrganizationList = new System.Windows.Forms.TreeView();
            this.tsOrganization = new CommonControls.Custom.CommonToolStrip();
            this.btnRefreshOrg = new System.Windows.Forms.ToolStripButton();
            this.lblLeftAreaTitleOrg = new CommonControls.Custom.TitleLabel();
            this.dgvListColorConfig = new CommonControls.Custom.CommonDataGridView();
            this.pnlMainParent = new System.Windows.Forms.Panel();
            this.pnlMainParent3 = new System.Windows.Forms.Panel();
            this.pnlMainParent2 = new System.Windows.Forms.Panel();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.nudLateHalfDay = new System.Windows.Forms.NumericUpDown();
            this.cbbLateHalfDay = new System.Windows.Forms.ComboBox();
            this.lblLateHalfDay = new System.Windows.Forms.Label();
            this.nudLate = new System.Windows.Forms.NumericUpDown();
            this.nudCardTag = new System.Windows.Forms.NumericUpDown();
            this.cbbLate = new System.Windows.Forms.ComboBox();
            this.lblLate = new System.Windows.Forms.Label();
            this.cbbCardTag = new System.Windows.Forms.ComboBox();
            this.lblCardTag = new System.Windows.Forms.Label();
            this.tsGeneral = new CommonControls.Custom.CommonToolStrip();
            this.btnSaveGeneralConfig = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshGeneralConfig = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.colColorConfigId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorConfigNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorConfigName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlOrgParent.SuspendLayout();
            this.pnlOrgParent2.SuspendLayout();
            this.tsOrganization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListColorConfig)).BeginInit();
            this.pnlMainParent.SuspendLayout();
            this.pnlMainParent3.SuspendLayout();
            this.pnlMainParent2.SuspendLayout();
            this.pnlFilterBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLateHalfDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCardTag)).BeginInit();
            this.tsGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRightAreaTitleGeneralConfig
            // 
            this.lblRightAreaTitleGeneralConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitleGeneralConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitleGeneralConfig.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblRightAreaTitleGeneralConfig.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitleGeneralConfig.Location = new System.Drawing.Point(0, 0);
            this.lblRightAreaTitleGeneralConfig.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRightAreaTitleGeneralConfig.Name = "lblRightAreaTitleGeneralConfig";
            this.lblRightAreaTitleGeneralConfig.Size = new System.Drawing.Size(1712, 69);
            this.lblRightAreaTitleGeneralConfig.TabIndex = 0;
            this.lblRightAreaTitleGeneralConfig.Text = "CẤU HÌNH NGÀY LỄ";
            this.lblRightAreaTitleGeneralConfig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // dgvListColorConfig
            // 
            this.dgvListColorConfig.AllowDrop = true;
            this.dgvListColorConfig.AllowUserToAddRows = false;
            this.dgvListColorConfig.AllowUserToDeleteRows = false;
            this.dgvListColorConfig.AllowUserToOrderColumns = true;
            this.dgvListColorConfig.AllowUserToResizeRows = false;
            this.dgvListColorConfig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListColorConfig.BackgroundColor = System.Drawing.Color.White;
            this.dgvListColorConfig.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListColorConfig.ColumnHeadersHeight = 30;
            this.dgvListColorConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colColorConfigId,
            this.colColorId,
            this.colColorConfigNo,
            this.colColorConfigName,
            this.colColorValue});
            this.dgvListColorConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListColorConfig.Enabled = false;
            this.dgvListColorConfig.Location = new System.Drawing.Point(0, 278);
            this.dgvListColorConfig.Margin = new System.Windows.Forms.Padding(6);
            this.dgvListColorConfig.MultiSelect = false;
            this.dgvListColorConfig.Name = "dgvListColorConfig";
            this.dgvListColorConfig.ReadOnly = true;
            this.dgvListColorConfig.RowHeadersVisible = false;
            this.dgvListColorConfig.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvListColorConfig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListColorConfig.Size = new System.Drawing.Size(1686, 887);
            this.dgvListColorConfig.TabIndex = 0;
            this.dgvListColorConfig.TabStop = false;
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
            this.pnlMainParent2.Controls.Add(this.dgvListColorConfig);
            this.pnlMainParent2.Controls.Add(this.pnlFilterBox);
            this.pnlMainParent2.Controls.Add(this.tsGeneral);
            this.pnlMainParent2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainParent2.Location = new System.Drawing.Point(12, 12);
            this.pnlMainParent2.Margin = new System.Windows.Forms.Padding(6);
            this.pnlMainParent2.Name = "pnlMainParent2";
            this.pnlMainParent2.Size = new System.Drawing.Size(1688, 1167);
            this.pnlMainParent2.TabIndex = 0;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilterBox.Controls.Add(this.nudLateHalfDay);
            this.pnlFilterBox.Controls.Add(this.cbbLateHalfDay);
            this.pnlFilterBox.Controls.Add(this.lblLateHalfDay);
            this.pnlFilterBox.Controls.Add(this.nudLate);
            this.pnlFilterBox.Controls.Add(this.nudCardTag);
            this.pnlFilterBox.Controls.Add(this.cbbLate);
            this.pnlFilterBox.Controls.Add(this.lblLate);
            this.pnlFilterBox.Controls.Add(this.cbbCardTag);
            this.pnlFilterBox.Controls.Add(this.lblCardTag);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 38);
            this.pnlFilterBox.Margin = new System.Windows.Forms.Padding(6);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(12);
            this.pnlFilterBox.Size = new System.Drawing.Size(1686, 240);
            this.pnlFilterBox.TabIndex = 0;
            // 
            // nudLateHalfDay
            // 
            this.nudLateHalfDay.Enabled = false;
            this.nudLateHalfDay.Location = new System.Drawing.Point(452, 165);
            this.nudLateHalfDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLateHalfDay.Name = "nudLateHalfDay";
            this.nudLateHalfDay.Size = new System.Drawing.Size(87, 37);
            this.nudLateHalfDay.TabIndex = 5;
            this.nudLateHalfDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbbLateHalfDay
            // 
            this.cbbLateHalfDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLateHalfDay.Enabled = false;
            this.cbbLateHalfDay.FormattingEnabled = true;
            this.cbbLateHalfDay.Location = new System.Drawing.Point(548, 165);
            this.cbbLateHalfDay.Margin = new System.Windows.Forms.Padding(6);
            this.cbbLateHalfDay.MaxDropDownItems = 5;
            this.cbbLateHalfDay.Name = "cbbLateHalfDay";
            this.cbbLateHalfDay.Size = new System.Drawing.Size(120, 38);
            this.cbbLateHalfDay.TabIndex = 6;
            // 
            // lblLateHalfDay
            // 
            this.lblLateHalfDay.AutoSize = true;
            this.lblLateHalfDay.Location = new System.Drawing.Point(40, 166);
            this.lblLateHalfDay.Margin = new System.Windows.Forms.Padding(6);
            this.lblLateHalfDay.Name = "lblLateHalfDay";
            this.lblLateHalfDay.Size = new System.Drawing.Size(381, 30);
            this.lblLateHalfDay.TabIndex = 0;
            this.lblLateHalfDay.Text = "Thời gian trễ tính nghỉ nửa ngày:";
            // 
            // nudLate
            // 
            this.nudLate.Enabled = false;
            this.nudLate.Location = new System.Drawing.Point(452, 101);
            this.nudLate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLate.Name = "nudLate";
            this.nudLate.Size = new System.Drawing.Size(87, 37);
            this.nudLate.TabIndex = 3;
            this.nudLate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudCardTag
            // 
            this.nudCardTag.Enabled = false;
            this.nudCardTag.Location = new System.Drawing.Point(452, 35);
            this.nudCardTag.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCardTag.Name = "nudCardTag";
            this.nudCardTag.Size = new System.Drawing.Size(87, 37);
            this.nudCardTag.TabIndex = 1;
            this.nudCardTag.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbbLate
            // 
            this.cbbLate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLate.Enabled = false;
            this.cbbLate.FormattingEnabled = true;
            this.cbbLate.Location = new System.Drawing.Point(548, 100);
            this.cbbLate.Margin = new System.Windows.Forms.Padding(6);
            this.cbbLate.MaxDropDownItems = 5;
            this.cbbLate.Name = "cbbLate";
            this.cbbLate.Size = new System.Drawing.Size(120, 38);
            this.cbbLate.TabIndex = 4;
            // 
            // lblLate
            // 
            this.lblLate.AutoSize = true;
            this.lblLate.Location = new System.Drawing.Point(40, 102);
            this.lblLate.Margin = new System.Windows.Forms.Padding(6);
            this.lblLate.Name = "lblLate";
            this.lblLate.Size = new System.Drawing.Size(275, 30);
            this.lblLate.TabIndex = 0;
            this.lblLate.Text = "Thời gian trễ cho phép:";
            // 
            // cbbCardTag
            // 
            this.cbbCardTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCardTag.Enabled = false;
            this.cbbCardTag.FormattingEnabled = true;
            this.cbbCardTag.Location = new System.Drawing.Point(548, 34);
            this.cbbCardTag.Margin = new System.Windows.Forms.Padding(6);
            this.cbbCardTag.MaxDropDownItems = 5;
            this.cbbCardTag.Name = "cbbCardTag";
            this.cbbCardTag.Size = new System.Drawing.Size(120, 38);
            this.cbbCardTag.TabIndex = 2;
            // 
            // lblCardTag
            // 
            this.lblCardTag.AutoSize = true;
            this.lblCardTag.Location = new System.Drawing.Point(40, 36);
            this.lblCardTag.Margin = new System.Windows.Forms.Padding(6);
            this.lblCardTag.Name = "lblCardTag";
            this.lblCardTag.Size = new System.Drawing.Size(331, 30);
            this.lblCardTag.TabIndex = 0;
            this.lblCardTag.Text = "Thời gian giữa 2 lần tag thẻ:";
            // 
            // tsGeneral
            // 
            this.tsGeneral.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsGeneral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveGeneralConfig,
            this.btnRefreshGeneralConfig});
            this.tsGeneral.Location = new System.Drawing.Point(0, 0);
            this.tsGeneral.Name = "tsGeneral";
            this.tsGeneral.Padding = new System.Windows.Forms.Padding(0);
            this.tsGeneral.Size = new System.Drawing.Size(1686, 38);
            this.tsGeneral.TabIndex = 0;
            this.tsGeneral.Text = "tlstripListUser";
            // 
            // btnSaveGeneralConfig
            // 
            this.btnSaveGeneralConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveGeneralConfig.Enabled = false;
            this.btnSaveGeneralConfig.Image = global::sTimeKeeping.Properties.Resources.btnSave;
            this.btnSaveGeneralConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveGeneralConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnSaveGeneralConfig.Name = "btnSaveGeneralConfig";
            this.btnSaveGeneralConfig.Size = new System.Drawing.Size(36, 36);
            this.btnSaveGeneralConfig.ToolTipText = "Lưu cấu hình chung";
            // 
            // btnRefreshGeneralConfig
            // 
            this.btnRefreshGeneralConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshGeneralConfig.Enabled = false;
            this.btnRefreshGeneralConfig.Image = global::sTimeKeeping.Properties.Resources.btnRefresh;
            this.btnRefreshGeneralConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshGeneralConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnRefreshGeneralConfig.Name = "btnRefreshGeneralConfig";
            this.btnRefreshGeneralConfig.Size = new System.Drawing.Size(36, 36);
            this.btnRefreshGeneralConfig.ToolTipText = "Làm mới cấu hình chung";
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
            this.splitContainer.Panel2.Controls.Add(this.lblRightAreaTitleGeneralConfig);
            this.splitContainer.Size = new System.Drawing.Size(2376, 1262);
            this.splitContainer.SplitterDistance = 650;
            this.splitContainer.SplitterWidth = 12;
            this.splitContainer.TabIndex = 0;
            this.splitContainer.TabStop = false;
            // 
            // colColorConfigId
            // 
            this.colColorConfigId.DataPropertyName = "colColorConfigId";
            this.colColorConfigId.HeaderText = "ColorConfigId";
            this.colColorConfigId.Name = "colColorConfigId";
            this.colColorConfigId.ReadOnly = true;
            this.colColorConfigId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colColorConfigId.Visible = false;
            // 
            // colColorId
            // 
            this.colColorId.DataPropertyName = "colColorId";
            this.colColorId.FillWeight = 50F;
            this.colColorId.HeaderText = "ColorId";
            this.colColorId.Name = "colColorId";
            this.colColorId.ReadOnly = true;
            this.colColorId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colColorId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colColorId.Visible = false;
            // 
            // colColorConfigNo
            // 
            this.colColorConfigNo.DataPropertyName = "colColorConfigNo";
            this.colColorConfigNo.FillWeight = 10F;
            this.colColorConfigNo.HeaderText = "No.";
            this.colColorConfigNo.Name = "colColorConfigNo";
            this.colColorConfigNo.ReadOnly = true;
            this.colColorConfigNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colColorConfigNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colColorConfigName
            // 
            this.colColorConfigName.DataPropertyName = "colColorConfigName";
            this.colColorConfigName.FillWeight = 75F;
            this.colColorConfigName.HeaderText = "Tên Sự Kiện";
            this.colColorConfigName.Name = "colColorConfigName";
            this.colColorConfigName.ReadOnly = true;
            this.colColorConfigName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colColorConfigName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colColorValue
            // 
            this.colColorValue.DataPropertyName = "colColorValue";
            this.colColorValue.FillWeight = 15F;
            this.colColorValue.HeaderText = "Màu";
            this.colColorValue.Name = "colColorValue";
            this.colColorValue.ReadOnly = true;
            this.colColorValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colColorValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UsrGeneralConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UsrGeneralConfig";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Size = new System.Drawing.Size(2400, 1286);
            this.pnlOrgParent.ResumeLayout(false);
            this.pnlOrgParent2.ResumeLayout(false);
            this.pnlOrgParent2.PerformLayout();
            this.tsOrganization.ResumeLayout(false);
            this.tsOrganization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListColorConfig)).EndInit();
            this.pnlMainParent.ResumeLayout(false);
            this.pnlMainParent3.ResumeLayout(false);
            this.pnlMainParent2.ResumeLayout(false);
            this.pnlMainParent2.PerformLayout();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLateHalfDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCardTag)).EndInit();
            this.tsGeneral.ResumeLayout(false);
            this.tsGeneral.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControls.Custom.TitleLabel lblRightAreaTitleGeneralConfig;
        private System.Windows.Forms.Panel pnlOrgParent;
        private System.Windows.Forms.Panel pnlOrgParent2;
        private System.Windows.Forms.TreeView tvOrganizationList;
        private CommonControls.Custom.CommonToolStrip tsOrganization;
        private System.Windows.Forms.ToolStripButton btnRefreshOrg;
        private CommonControls.Custom.TitleLabel lblLeftAreaTitleOrg;
        private CommonControls.Custom.CommonDataGridView dgvListColorConfig;
        private System.Windows.Forms.Panel pnlMainParent;
        private System.Windows.Forms.Panel pnlMainParent3;
        private System.Windows.Forms.Panel pnlMainParent2;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.ComboBox cbbLate;
        private System.Windows.Forms.Label lblLate;
        private System.Windows.Forms.ComboBox cbbCardTag;
        private System.Windows.Forms.Label lblCardTag;
        private CommonControls.Custom.CommonToolStrip tsGeneral;
        private System.Windows.Forms.ToolStripButton btnSaveGeneralConfig;
        private System.Windows.Forms.ToolStripButton btnRefreshGeneralConfig;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.NumericUpDown nudLate;
        private System.Windows.Forms.NumericUpDown nudCardTag;
        private System.Windows.Forms.NumericUpDown nudLateHalfDay;
        private System.Windows.Forms.ComboBox cbbLateHalfDay;
        private System.Windows.Forms.Label lblLateHalfDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorConfigId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorConfigNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorConfigName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorValue;
    }
}
