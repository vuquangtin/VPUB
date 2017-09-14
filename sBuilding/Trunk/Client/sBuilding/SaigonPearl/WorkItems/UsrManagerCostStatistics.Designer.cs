namespace sAccessComponent.WorkItems
{
    partial class UsrManagerCostStatistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrManagerCostStatistics));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkAutoCloseNode = new System.Windows.Forms.CheckBox();
            this.trvOrganizations = new System.Windows.Forms.TreeView();
            this.cmsOrgTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniReloadOrgs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOrg = new CommonControls.Custom.CommonToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReloadOrgs = new System.Windows.Forms.ToolStripButton();
            this.lblLeftAreaTitleOrg = new CommonControls.Custom.TitleLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvMembers = new CommonControls.Custom.CommonDataGridView();
            this.colManagerCostId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOldManageOwe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManageFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWaterFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOweDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.line2 = new CommonControls.Custom.Line();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbxManagerCostOld = new CommonControls.Custom.CommonTextBox();
            this.lblOldManageOwe = new System.Windows.Forms.Label();
            this.tbxDateCost = new CommonControls.Custom.CommonTextBox();
            this.lblOweDate = new System.Windows.Forms.Label();
            this.tbxWaterCost = new CommonControls.Custom.CommonTextBox();
            this.lblWaterFee = new System.Windows.Forms.Label();
            this.tbxManagerCost = new CommonControls.Custom.CommonTextBox();
            this.lblManageFee = new System.Windows.Forms.Label();
            this.lblApartmentName = new System.Windows.Forms.Label();
            this.txtCode = new CommonControls.Custom.CommonTextBox();
            this.txtPhone = new CommonControls.Custom.CommonTextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmail = new CommonControls.Custom.CommonTextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtName = new CommonControls.Custom.CommonTextBox();
            this.lblApartmentCode = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.lblInfoApartment = new System.Windows.Forms.Label();
            this.lblNotification2 = new System.Windows.Forms.Label();
            this.lblNotification1 = new System.Windows.Forms.Label();
            this.tbxMemberCode = new System.Windows.Forms.TextBox();
            this.cbxFilterByMemberCode = new System.Windows.Forms.CheckBox();
            this.tbxMemberName = new System.Windows.Forms.TextBox();
            this.cbxFilterByMemberName = new System.Windows.Forms.CheckBox();
            this.tmsMember = new CommonControls.Custom.CommonToolStrip();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReloadMembers = new System.Windows.Forms.ToolStripButton();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.lblLeftAreaTitleUser = new CommonControls.Custom.TitleLabel();
            this.cmsUserTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mniExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mniReloadUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.mniRemoveGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUpdateGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsOrgRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.cmsOrgTree.SuspendLayout();
            this.tsmOrg.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tmsMember.SuspendLayout();
            this.cmsUserTable.SuspendLayout();
            this.cmsOrgRecord.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(5, 5);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panel3);
            this.splitContainer.Panel1.Controls.Add(this.lblLeftAreaTitleOrg);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel1);
            this.splitContainer.Panel2.Controls.Add(this.lblLeftAreaTitleUser);
            this.splitContainer.Size = new System.Drawing.Size(927, 590);
            this.splitContainer.SplitterDistance = 234;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(232, 558);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.chkAutoCloseNode);
            this.panel4.Controls.Add(this.trvOrganizations);
            this.panel4.Controls.Add(this.tsmOrg);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(5, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(222, 548);
            this.panel4.TabIndex = 57;
            // 
            // chkAutoCloseNode
            // 
            this.chkAutoCloseNode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chkAutoCloseNode.Location = new System.Drawing.Point(0, 526);
            this.chkAutoCloseNode.Name = "chkAutoCloseNode";
            this.chkAutoCloseNode.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.chkAutoCloseNode.Size = new System.Drawing.Size(220, 20);
            this.chkAutoCloseNode.TabIndex = 58;
            this.chkAutoCloseNode.Text = "Tự động rút gọn danh sách";
            this.chkAutoCloseNode.UseVisualStyleBackColor = true;
            // 
            // trvOrganizations
            // 
            this.trvOrganizations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvOrganizations.ContextMenuStrip = this.cmsOrgTree;
            this.trvOrganizations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvOrganizations.Location = new System.Drawing.Point(0, 25);
            this.trvOrganizations.Name = "trvOrganizations";
            this.trvOrganizations.Size = new System.Drawing.Size(220, 521);
            this.trvOrganizations.TabIndex = 57;
            // 
            // cmsOrgTree
            // 
            this.cmsOrgTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniReloadOrgs});
            this.cmsOrgTree.Name = "contextMenuStrip1";
            this.cmsOrgTree.Size = new System.Drawing.Size(134, 26);
            // 
            // mniReloadOrgs
            // 
            this.mniReloadOrgs.Image = ((System.Drawing.Image)(resources.GetObject("mniReloadOrgs.Image")));
            this.mniReloadOrgs.Name = "mniReloadOrgs";
            this.mniReloadOrgs.Size = new System.Drawing.Size(133, 22);
            this.mniReloadOrgs.Text = "Tải Dữ Liệu";
            // 
            // tsmOrg
            // 
            this.tsmOrg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnReloadOrgs});
            this.tsmOrg.Location = new System.Drawing.Point(0, 0);
            this.tsmOrg.Name = "tsmOrg";
            this.tsmOrg.Size = new System.Drawing.Size(220, 25);
            this.tsmOrg.TabIndex = 56;
            this.tsmOrg.Text = "tlstripListGroup";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnReloadOrgs
            // 
            this.btnReloadOrgs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadOrgs.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadOrgs.Image")));
            this.btnReloadOrgs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadOrgs.Name = "btnReloadOrgs";
            this.btnReloadOrgs.Size = new System.Drawing.Size(23, 22);
            this.btnReloadOrgs.Text = "Tải Dữ Liệu";
            this.btnReloadOrgs.ToolTipText = "Tải danh sách nhóm";
            // 
            // lblLeftAreaTitleOrg
            // 
            this.lblLeftAreaTitleOrg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblLeftAreaTitleOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftAreaTitleOrg.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblLeftAreaTitleOrg.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLeftAreaTitleOrg.Location = new System.Drawing.Point(0, 0);
            this.lblLeftAreaTitleOrg.Name = "lblLeftAreaTitleOrg";
            this.lblLeftAreaTitleOrg.Size = new System.Drawing.Size(232, 30);
            this.lblLeftAreaTitleOrg.TabIndex = 2;
            this.lblLeftAreaTitleOrg.Text = "DANH SÁCH TỔ CHỨC";
            this.lblLeftAreaTitleOrg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Size = new System.Drawing.Size(686, 558);
            this.panel1.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvMembers);
            this.panel2.Controls.Add(this.pnlFilterBox);
            this.panel2.Controls.Add(this.tmsMember);
            this.panel2.Controls.Add(this.pagerPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(676, 550);
            this.panel2.TabIndex = 38;
            // 
            // dgvMembers
            // 
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.AllowUserToDeleteRows = false;
            this.dgvMembers.AllowUserToOrderColumns = true;
            this.dgvMembers.AllowUserToResizeRows = false;
            this.dgvMembers.BackgroundColor = System.Drawing.Color.White;
            this.dgvMembers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMembers.ColumnHeadersHeight = 26;
            this.dgvMembers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colManagerCostId,
            this.colOldManageOwe,
            this.colManageFee,
            this.colWaterFee,
            this.colOweDate,
            this.colActive,
            this.colBlank});
            this.dgvMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMembers.Location = new System.Drawing.Point(0, 141);
            this.dgvMembers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMembers.MultiSelect = false;
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.RowHeadersVisible = false;
            this.dgvMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.Size = new System.Drawing.Size(674, 387);
            this.dgvMembers.TabIndex = 46;
            // 
            // colManagerCostId
            // 
            this.colManagerCostId.DataPropertyName = "ManagerCostId";
            this.colManagerCostId.HeaderText = "MemberId";
            this.colManagerCostId.Name = "colManagerCostId";
            this.colManagerCostId.ReadOnly = true;
            this.colManagerCostId.Visible = false;
            // 
            // colOldManageOwe
            // 
            this.colOldManageOwe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colOldManageOwe.DataPropertyName = "MangerCostOld";
            this.colOldManageOwe.HeaderText = "Nợ Phí Quản Lý Cũ";
            this.colOldManageOwe.Name = "colOldManageOwe";
            this.colOldManageOwe.ReadOnly = true;
            this.colOldManageOwe.Width = 134;
            // 
            // colManageFee
            // 
            this.colManageFee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colManageFee.DataPropertyName = "ManagerCost";
            this.colManageFee.HeaderText = "Nợ Phí Quản Lý";
            this.colManageFee.Name = "colManageFee";
            this.colManageFee.ReadOnly = true;
            this.colManageFee.Width = 116;
            // 
            // colWaterFee
            // 
            this.colWaterFee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colWaterFee.DataPropertyName = "PayWater";
            this.colWaterFee.HeaderText = "Nợ Tiền Nước";
            this.colWaterFee.Name = "colWaterFee";
            this.colWaterFee.ReadOnly = true;
            this.colWaterFee.Width = 108;
            // 
            // colOweDate
            // 
            this.colOweDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colOweDate.DataPropertyName = "PayDay";
            this.colOweDate.HeaderText = "Ngày Nợ Phí";
            this.colOweDate.Name = "colOweDate";
            this.colOweDate.ReadOnly = true;
            this.colOweDate.Width = 98;
            // 
            // colActive
            // 
            this.colActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colActive.DataPropertyName = "Active";
            this.colActive.HeaderText = "Đang Sử Dụng";
            this.colActive.Name = "colActive";
            this.colActive.ReadOnly = true;
            // 
            // colBlank
            // 
            this.colBlank.HeaderText = "Blank";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            this.colBlank.Width = 5;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.Controls.Add(this.line2);
            this.pnlFilterBox.Controls.Add(this.panel5);
            this.pnlFilterBox.Controls.Add(this.line1);
            this.pnlFilterBox.Controls.Add(this.lblInfoApartment);
            this.pnlFilterBox.Controls.Add(this.lblNotification2);
            this.pnlFilterBox.Controls.Add(this.lblNotification1);
            this.pnlFilterBox.Controls.Add(this.tbxMemberCode);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByMemberCode);
            this.pnlFilterBox.Controls.Add(this.tbxMemberName);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByMemberName);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Size = new System.Drawing.Size(674, 116);
            this.pnlFilterBox.TabIndex = 45;
            // 
            // line2
            // 
            this.line2.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line2.Dock = System.Windows.Forms.DockStyle.Top;
            this.line2.Location = new System.Drawing.Point(0, 113);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(674, 1);
            this.line2.TabIndex = 79;
            this.line2.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tbxManagerCostOld);
            this.panel5.Controls.Add(this.lblOldManageOwe);
            this.panel5.Controls.Add(this.tbxDateCost);
            this.panel5.Controls.Add(this.lblOweDate);
            this.panel5.Controls.Add(this.tbxWaterCost);
            this.panel5.Controls.Add(this.lblWaterFee);
            this.panel5.Controls.Add(this.tbxManagerCost);
            this.panel5.Controls.Add(this.lblManageFee);
            this.panel5.Controls.Add(this.lblApartmentName);
            this.panel5.Controls.Add(this.txtCode);
            this.panel5.Controls.Add(this.txtPhone);
            this.panel5.Controls.Add(this.lblPhone);
            this.panel5.Controls.Add(this.txtEmail);
            this.panel5.Controls.Add(this.lblEmail);
            this.panel5.Controls.Add(this.txtName);
            this.panel5.Controls.Add(this.lblApartmentCode);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 26);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(674, 87);
            this.panel5.TabIndex = 78;
            // 
            // tbxManagerCostOld
            // 
            this.tbxManagerCostOld.BackColor = System.Drawing.Color.White;
            this.tbxManagerCostOld.Location = new System.Drawing.Point(536, 5);
            this.tbxManagerCostOld.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tbxManagerCostOld.MaxLength = 255;
            this.tbxManagerCostOld.Name = "tbxManagerCostOld";
            this.tbxManagerCostOld.ReadOnly = true;
            this.tbxManagerCostOld.Size = new System.Drawing.Size(115, 22);
            this.tbxManagerCostOld.TabIndex = 50;
            // 
            // lblOldManageOwe
            // 
            this.lblOldManageOwe.AutoSize = true;
            this.lblOldManageOwe.Location = new System.Drawing.Point(420, 8);
            this.lblOldManageOwe.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.lblOldManageOwe.Name = "lblOldManageOwe";
            this.lblOldManageOwe.Size = new System.Drawing.Size(106, 14);
            this.lblOldManageOwe.TabIndex = 51;
            this.lblOldManageOwe.Text = "Nợ phí quản lý cũ:";
            // 
            // tbxDateCost
            // 
            this.tbxDateCost.BackColor = System.Drawing.Color.White;
            this.tbxDateCost.Location = new System.Drawing.Point(536, 31);
            this.tbxDateCost.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tbxDateCost.MaxLength = 255;
            this.tbxDateCost.Name = "tbxDateCost";
            this.tbxDateCost.ReadOnly = true;
            this.tbxDateCost.Size = new System.Drawing.Size(115, 22);
            this.tbxDateCost.TabIndex = 48;
            // 
            // lblOweDate
            // 
            this.lblOweDate.AutoSize = true;
            this.lblOweDate.Location = new System.Drawing.Point(420, 34);
            this.lblOweDate.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.lblOweDate.Name = "lblOweDate";
            this.lblOweDate.Size = new System.Drawing.Size(76, 14);
            this.lblOweDate.TabIndex = 49;
            this.lblOweDate.Text = "Ngày nợ phí:";
            // 
            // tbxWaterCost
            // 
            this.tbxWaterCost.BackColor = System.Drawing.Color.White;
            this.tbxWaterCost.Location = new System.Drawing.Point(295, 31);
            this.tbxWaterCost.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tbxWaterCost.MaxLength = 255;
            this.tbxWaterCost.Name = "tbxWaterCost";
            this.tbxWaterCost.ReadOnly = true;
            this.tbxWaterCost.Size = new System.Drawing.Size(115, 22);
            this.tbxWaterCost.TabIndex = 46;
            // 
            // lblWaterFee
            // 
            this.lblWaterFee.AutoSize = true;
            this.lblWaterFee.Location = new System.Drawing.Point(211, 34);
            this.lblWaterFee.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.lblWaterFee.Name = "lblWaterFee";
            this.lblWaterFee.Size = new System.Drawing.Size(67, 14);
            this.lblWaterFee.TabIndex = 47;
            this.lblWaterFee.Text = "Tiền nước:";
            // 
            // tbxManagerCost
            // 
            this.tbxManagerCost.BackColor = System.Drawing.Color.White;
            this.tbxManagerCost.Location = new System.Drawing.Point(82, 31);
            this.tbxManagerCost.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tbxManagerCost.MaxLength = 255;
            this.tbxManagerCost.Name = "tbxManagerCost";
            this.tbxManagerCost.ReadOnly = true;
            this.tbxManagerCost.Size = new System.Drawing.Size(115, 22);
            this.tbxManagerCost.TabIndex = 44;
            // 
            // lblManageFee
            // 
            this.lblManageFee.AutoSize = true;
            this.lblManageFee.Location = new System.Drawing.Point(5, 34);
            this.lblManageFee.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.lblManageFee.Name = "lblManageFee";
            this.lblManageFee.Size = new System.Drawing.Size(70, 14);
            this.lblManageFee.TabIndex = 45;
            this.lblManageFee.Text = "Phí quản lý:";
            // 
            // lblApartmentName
            // 
            this.lblApartmentName.AutoSize = true;
            this.lblApartmentName.Location = new System.Drawing.Point(211, 8);
            this.lblApartmentName.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.lblApartmentName.Name = "lblApartmentName";
            this.lblApartmentName.Size = new System.Drawing.Size(74, 14);
            this.lblApartmentName.TabIndex = 43;
            this.lblApartmentName.Text = "Tên căn hộ:";
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCode.Location = new System.Drawing.Point(82, 2);
            this.txtCode.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtCode.MaxLength = 255;
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(115, 22);
            this.txtCode.TabIndex = 1;
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.Location = new System.Drawing.Point(82, 57);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtPhone.MaxLength = 255;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(115, 22);
            this.txtPhone.TabIndex = 9;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(5, 60);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(66, 14);
            this.lblPhone.TabIndex = 32;
            this.lblPhone.Text = "Điện thoại:";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(295, 57);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtEmail.MaxLength = 255;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(356, 22);
            this.txtEmail.TabIndex = 11;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(211, 60);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 14);
            this.lblEmail.TabIndex = 30;
            this.lblEmail.Text = "Email:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtName.Location = new System.Drawing.Point(295, 5);
            this.txtName.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(115, 22);
            this.txtName.TabIndex = 2;
            // 
            // lblApartmentCode
            // 
            this.lblApartmentCode.AutoSize = true;
            this.lblApartmentCode.Location = new System.Drawing.Point(5, 8);
            this.lblApartmentCode.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.lblApartmentCode.Name = "lblApartmentCode";
            this.lblApartmentCode.Size = new System.Drawing.Size(67, 14);
            this.lblApartmentCode.TabIndex = 7;
            this.lblApartmentCode.Text = "Mã căn hộ:";
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 25);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(674, 1);
            this.line1.TabIndex = 77;
            this.line1.TabStop = false;
            // 
            // lblInfoApartment
            // 
            this.lblInfoApartment.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfoApartment.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblInfoApartment.Location = new System.Drawing.Point(0, 0);
            this.lblInfoApartment.Name = "lblInfoApartment";
            this.lblInfoApartment.Size = new System.Drawing.Size(674, 25);
            this.lblInfoApartment.TabIndex = 76;
            this.lblInfoApartment.Text = "Thông tin căn hộ:";
            this.lblInfoApartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNotification2
            // 
            this.lblNotification2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNotification2.Location = new System.Drawing.Point(370, 146);
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
            this.lblNotification1.Location = new System.Drawing.Point(370, 118);
            this.lblNotification1.Name = "lblNotification1";
            this.lblNotification1.Size = new System.Drawing.Size(150, 22);
            this.lblNotification1.TabIndex = 41;
            this.lblNotification1.Text = "Vui lòng nhập ít nhất 2 ký tự";
            this.lblNotification1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotification1.Visible = false;
            // 
            // tbxMemberCode
            // 
            this.tbxMemberCode.Enabled = false;
            this.tbxMemberCode.Location = new System.Drawing.Point(214, 146);
            this.tbxMemberCode.Name = "tbxMemberCode";
            this.tbxMemberCode.Size = new System.Drawing.Size(150, 22);
            this.tbxMemberCode.TabIndex = 35;
            // 
            // cbxFilterByMemberCode
            // 
            this.cbxFilterByMemberCode.Location = new System.Drawing.Point(8, 146);
            this.cbxFilterByMemberCode.Margin = new System.Windows.Forms.Padding(5);
            this.cbxFilterByMemberCode.Name = "cbxFilterByMemberCode";
            this.cbxFilterByMemberCode.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByMemberCode.TabIndex = 34;
            this.cbxFilterByMemberCode.Text = "Lọc theo mã thành viên:";
            this.cbxFilterByMemberCode.UseVisualStyleBackColor = true;
            this.cbxFilterByMemberCode.CheckedChanged += new System.EventHandler(this.cbxFilterByMemberCode_CheckedChanged);
            // 
            // tbxMemberName
            // 
            this.tbxMemberName.Enabled = false;
            this.tbxMemberName.Location = new System.Drawing.Point(214, 118);
            this.tbxMemberName.Name = "tbxMemberName";
            this.tbxMemberName.Size = new System.Drawing.Size(150, 22);
            this.tbxMemberName.TabIndex = 33;
            // 
            // cbxFilterByMemberName
            // 
            this.cbxFilterByMemberName.Location = new System.Drawing.Point(8, 118);
            this.cbxFilterByMemberName.Margin = new System.Windows.Forms.Padding(5);
            this.cbxFilterByMemberName.Name = "cbxFilterByMemberName";
            this.cbxFilterByMemberName.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByMemberName.TabIndex = 32;
            this.cbxFilterByMemberName.Text = "Lọc theo tên thành viên:";
            this.cbxFilterByMemberName.UseVisualStyleBackColor = true;
            this.cbxFilterByMemberName.CheckedChanged += new System.EventHandler(this.cbxFilterByMemberName_CheckedChanged);
            // 
            // tmsMember
            // 
            this.tmsMember.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowHide,
            this.btnExportToExcel,
            this.toolStripSeparator2,
            this.btnReloadMembers});
            this.tmsMember.Location = new System.Drawing.Point(0, 0);
            this.tmsMember.Name = "tmsMember";
            this.tmsMember.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tmsMember.Size = new System.Drawing.Size(674, 25);
            this.tmsMember.TabIndex = 44;
            this.tmsMember.Text = "toolStrip1";
            // 
            // btnShowHide
            // 
            this.btnShowHide.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnShowHide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowHide.Image = ((System.Drawing.Image)(resources.GetObject("btnShowHide.Image")));
            this.btnShowHide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(23, 22);
            this.btnShowHide.Text = "Ẩn Khung Tìm Kiếm";
            this.btnShowHide.ToolTipText = "Ẩn khung tìm kiếm";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BackgroundImage = global::sAccessComponent.Properties.Resources.Excel_16x16;
            this.btnExportToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExportToExcel.Text = "Xuất Ra Excel...";
            this.btnExportToExcel.ToolTipText = "Xuất dữ liệu đang hiển thị ra tập tin excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnReloadMembers
            // 
            this.btnReloadMembers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadMembers.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadMembers.Image")));
            this.btnReloadMembers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadMembers.Name = "btnReloadMembers";
            this.btnReloadMembers.Size = new System.Drawing.Size(23, 22);
            this.btnReloadMembers.Text = "Tải Dữ Liệu";
            this.btnReloadMembers.ToolTipText = "Tải danh sách thành viên";
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 528);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(674, 20);
            this.pagerPanel1.TabIndex = 40;
            // 
            // lblLeftAreaTitleUser
            // 
            this.lblLeftAreaTitleUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblLeftAreaTitleUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftAreaTitleUser.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblLeftAreaTitleUser.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLeftAreaTitleUser.Location = new System.Drawing.Point(0, 0);
            this.lblLeftAreaTitleUser.Name = "lblLeftAreaTitleUser";
            this.lblLeftAreaTitleUser.Size = new System.Drawing.Size(686, 30);
            this.lblLeftAreaTitleUser.TabIndex = 34;
            this.lblLeftAreaTitleUser.Text = "DANH SÁCH THÀNH VIÊN";
            this.lblLeftAreaTitleUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmsUserTable
            // 
            this.cmsUserTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAddUser,
            this.toolStripSeparator5,
            this.mniExportToExcel,
            this.mniReloadUsers});
            this.cmsUserTable.Name = "contextMenuStrip1";
            this.cmsUserTable.Size = new System.Drawing.Size(195, 76);
            // 
            // mniAddUser
            // 
            this.mniAddUser.Image = ((System.Drawing.Image)(resources.GetObject("mniAddUser.Image")));
            this.mniAddUser.Name = "mniAddUser";
            this.mniAddUser.Size = new System.Drawing.Size(194, 22);
            this.mniAddUser.Text = "Thêm Tài Khoản Mới...";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(191, 6);
            // 
            // mniExportToExcel
            // 
            this.mniExportToExcel.Name = "mniExportToExcel";
            this.mniExportToExcel.Size = new System.Drawing.Size(194, 22);
            this.mniExportToExcel.Text = "Xuất Ra Excel...";
            // 
            // mniReloadUsers
            // 
            this.mniReloadUsers.Image = ((System.Drawing.Image)(resources.GetObject("mniReloadUsers.Image")));
            this.mniReloadUsers.Name = "mniReloadUsers";
            this.mniReloadUsers.Size = new System.Drawing.Size(194, 22);
            this.mniReloadUsers.Text = "Tải Dữ Liệu";
            // 
            // mniRemoveGroups
            // 
            this.mniRemoveGroups.Image = ((System.Drawing.Image)(resources.GetObject("mniRemoveGroups.Image")));
            this.mniRemoveGroups.Name = "mniRemoveGroups";
            this.mniRemoveGroups.Size = new System.Drawing.Size(170, 22);
            this.mniRemoveGroups.Text = "Hủy Nhóm...";
            // 
            // mniUpdateGroup
            // 
            this.mniUpdateGroup.Image = ((System.Drawing.Image)(resources.GetObject("mniUpdateGroup.Image")));
            this.mniUpdateGroup.Name = "mniUpdateGroup";
            this.mniUpdateGroup.Size = new System.Drawing.Size(170, 22);
            this.mniUpdateGroup.Text = "Cập Nhật Nhóm...";
            // 
            // cmsOrgRecord
            // 
            this.cmsOrgRecord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniUpdateGroup,
            this.mniRemoveGroups});
            this.cmsOrgRecord.Name = "cmsGroup";
            this.cmsOrgRecord.Size = new System.Drawing.Size(171, 48);
            // 
            // UsrManagerCostStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrManagerCostStatistics";
            this.Size = new System.Drawing.Size(937, 600);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.cmsOrgTree.ResumeLayout(false);
            this.tsmOrg.ResumeLayout(false);
            this.tsmOrg.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tmsMember.ResumeLayout(false);
            this.tmsMember.PerformLayout();
            this.cmsUserTable.ResumeLayout(false);
            this.cmsOrgRecord.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TreeView trvOrganizations;
        private CommonControls.Custom.CommonToolStrip tsmOrg;
        private System.Windows.Forms.ToolStripButton btnReloadOrgs;
        private CommonControls.Custom.TitleLabel lblLeftAreaTitleOrg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private System.Windows.Forms.ContextMenuStrip cmsUserTable;
        private System.Windows.Forms.ToolStripMenuItem mniAddUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mniExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem mniReloadUsers;
        private CommonControls.Custom.TitleLabel lblLeftAreaTitleUser;
        private System.Windows.Forms.ToolStripMenuItem mniRemoveGroups;
        private System.Windows.Forms.ContextMenuStrip cmsOrgTree;
        private System.Windows.Forms.ToolStripMenuItem mniReloadOrgs;
        private System.Windows.Forms.ToolStripMenuItem mniUpdateGroup;
        private System.Windows.Forms.ContextMenuStrip cmsOrgRecord;
        private CommonControls.Custom.CommonDataGridView dgvMembers;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Label lblNotification2;
        private System.Windows.Forms.Label lblNotification1;
        private System.Windows.Forms.TextBox tbxMemberCode;
        private System.Windows.Forms.CheckBox cbxFilterByMemberCode;
        private System.Windows.Forms.TextBox tbxMemberName;
        private System.Windows.Forms.CheckBox cbxFilterByMemberName;
        private CommonControls.Custom.CommonToolStrip tmsMember;
        private System.Windows.Forms.ToolStripButton btnShowHide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripButton btnReloadMembers;
        private System.Windows.Forms.CheckBox chkAutoCloseNode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lblInfoApartment;
        private CommonControls.Custom.Line line2;
        private System.Windows.Forms.Panel panel5;
        private CommonControls.Custom.CommonTextBox tbxDateCost;
        private System.Windows.Forms.Label lblOweDate;
        private CommonControls.Custom.CommonTextBox tbxWaterCost;
        private System.Windows.Forms.Label lblWaterFee;
        private CommonControls.Custom.CommonTextBox tbxManagerCost;
        private System.Windows.Forms.Label lblManageFee;
        private System.Windows.Forms.Label lblApartmentName;
        private CommonControls.Custom.CommonTextBox txtCode;
        private CommonControls.Custom.CommonTextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private CommonControls.Custom.CommonTextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private CommonControls.Custom.CommonTextBox txtName;
        private System.Windows.Forms.Label lblApartmentCode;
        private CommonControls.Custom.Line line1;
        private CommonControls.Custom.CommonTextBox tbxManagerCostOld;
        private System.Windows.Forms.Label lblOldManageOwe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManagerCostId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldManageOwe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManageFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWaterFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOweDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
    }
}
