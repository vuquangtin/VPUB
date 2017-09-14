namespace sTimeKeeping.WorkItems
{
    partial class UsrDevicestatistic
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
            if (disposing)
            {
                if (loadSubOrgWorker != null && loadSubOrgWorker.IsBusy)
                {
                    loadSubOrgWorker.CancelAsync();
                }
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrDevicestatistic));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trvOrganizations = new System.Windows.Forms.TreeView();
            this.tmsOrganization = new CommonControls.Custom.CommonToolStrip();
            this.btnReloadOrgs = new System.Windows.Forms.ToolStripButton();
            this.lblLeftAreaTitleforListPartner = new CommonControls.Custom.TitleLabel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pnlRightMain = new System.Windows.Forms.Panel();
            this.pagerPanel = new CommonControls.Custom.PagerPanel();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.cmsMemberTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniSyncData = new System.Windows.Forms.ToolStripMenuItem();
            this.tssBelowSyncDataMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.mniExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mniReloadMembers = new System.Windows.Forms.ToolStripMenuItem();
            this.tbxMemberCode = new System.Windows.Forms.TextBox();
            this.cbxFilterByMemberCode = new System.Windows.Forms.CheckBox();
            this.tbxMemberName = new System.Windows.Forms.TextBox();
            this.cbxFilterByMemberName = new System.Windows.Forms.CheckBox();
            this.tmsMember = new CommonControls.Custom.CommonToolStrip();
            this.btnPersoCard = new System.Windows.Forms.ToolStripButton();
            this.tssAfterPersoButton = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.btnReloadMembers = new System.Windows.Forms.ToolStripButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblRightAreaTitleforListMember = new CommonControls.Custom.TitleLabel();
            this.cmsOrgTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniReloadOrgs = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMemberRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniPersoCard = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvShiftList = new CommonControls.Custom.CommonDataGridView();
            this.colDoorOutId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImageIn = new System.Windows.Forms.DataGridViewImageColumn();
            this.colImageOut = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tmsOrganization.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnlRightMain.SuspendLayout();
            this.pnlFilterBox.SuspendLayout();
            this.cmsMemberTable.SuspendLayout();
            this.tmsMember.SuspendLayout();
            this.cmsOrgTree.SuspendLayout();
            this.cmsMemberRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShiftList)).BeginInit();
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
            this.splitContainer.Panel1.Controls.Add(this.panel1);
            this.splitContainer.Panel1.Controls.Add(this.lblLeftAreaTitleforListPartner);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel8);
            this.splitContainer.Panel2.Controls.Add(this.panel7);
            this.splitContainer.Panel2.Controls.Add(this.lblRightAreaTitleforListMember);
            this.splitContainer.Size = new System.Drawing.Size(790, 590);
            this.splitContainer.SplitterDistance = 214;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(212, 558);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.trvOrganizations);
            this.panel2.Controls.Add(this.tmsOrganization);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 548);
            this.panel2.TabIndex = 53;
            // 
            // trvOrganizations
            // 
            this.trvOrganizations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvOrganizations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvOrganizations.Location = new System.Drawing.Point(0, 25);
            this.trvOrganizations.Name = "trvOrganizations";
            this.trvOrganizations.Size = new System.Drawing.Size(200, 521);
            this.trvOrganizations.TabIndex = 61;
            // 
            // tmsOrganization
            // 
            this.tmsOrganization.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReloadOrgs});
            this.tmsOrganization.Location = new System.Drawing.Point(0, 0);
            this.tmsOrganization.Name = "tmsOrganization";
            this.tmsOrganization.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tmsOrganization.Size = new System.Drawing.Size(200, 25);
            this.tmsOrganization.TabIndex = 59;
            this.tmsOrganization.Text = "toolStrip1";
            // 
            // btnReloadOrgs
            // 
            this.btnReloadOrgs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadOrgs.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadOrgs.Image")));
            this.btnReloadOrgs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadOrgs.Name = "btnReloadOrgs";
            this.btnReloadOrgs.Size = new System.Drawing.Size(23, 22);
            this.btnReloadOrgs.Text = "Tải Dữ Liệu";
            this.btnReloadOrgs.ToolTipText = "Tải danh sách đơn vị";
            // 
            // lblLeftAreaTitleforListPartner
            // 
            this.lblLeftAreaTitleforListPartner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblLeftAreaTitleforListPartner.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftAreaTitleforListPartner.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblLeftAreaTitleforListPartner.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLeftAreaTitleforListPartner.Location = new System.Drawing.Point(0, 0);
            this.lblLeftAreaTitleforListPartner.Name = "lblLeftAreaTitleforListPartner";
            this.lblLeftAreaTitleforListPartner.Size = new System.Drawing.Size(212, 30);
            this.lblLeftAreaTitleforListPartner.TabIndex = 2;
            this.lblLeftAreaTitleforListPartner.Text = "DANH SÁCH CỬA";
            this.lblLeftAreaTitleforListPartner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.pnlRightMain);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 34);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5, 0, 5, 4);
            this.panel8.Size = new System.Drawing.Size(569, 554);
            this.panel8.TabIndex = 18;
            // 
            // pnlRightMain
            // 
            this.pnlRightMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRightMain.Controls.Add(this.dgvShiftList);
            this.pnlRightMain.Controls.Add(this.pagerPanel);
            this.pnlRightMain.Controls.Add(this.pnlFilterBox);
            this.pnlRightMain.Controls.Add(this.tmsMember);
            this.pnlRightMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightMain.Location = new System.Drawing.Point(5, 0);
            this.pnlRightMain.Name = "pnlRightMain";
            this.pnlRightMain.Size = new System.Drawing.Size(559, 550);
            this.pnlRightMain.TabIndex = 14;
            // 
            // pagerPanel
            // 
            this.pagerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel.Location = new System.Drawing.Point(0, 528);
            this.pagerPanel.Name = "pagerPanel";
            this.pagerPanel.Size = new System.Drawing.Size(557, 20);
            this.pagerPanel.TabIndex = 25;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.ContextMenuStrip = this.cmsMemberTable;
            this.pnlFilterBox.Controls.Add(this.tbxMemberCode);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByMemberCode);
            this.pnlFilterBox.Controls.Add(this.tbxMemberName);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByMemberName);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(557, 66);
            this.pnlFilterBox.TabIndex = 23;
            // 
            // cmsMemberTable
            // 
            this.cmsMemberTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniSyncData,
            this.tssBelowSyncDataMenuItem,
            this.mniExportToExcel,
            this.mniReloadMembers});
            this.cmsMemberTable.Name = "contextMenuStrip1";
            this.cmsMemberTable.Size = new System.Drawing.Size(176, 76);
            // 
            // mniSyncData
            // 
            this.mniSyncData.Image = ((System.Drawing.Image)(resources.GetObject("mniSyncData.Image")));
            this.mniSyncData.Name = "mniSyncData";
            this.mniSyncData.Size = new System.Drawing.Size(175, 22);
            this.mniSyncData.Text = "Tích Hợp Dữ Liệu...";
            // 
            // tssBelowSyncDataMenuItem
            // 
            this.tssBelowSyncDataMenuItem.Name = "tssBelowSyncDataMenuItem";
            this.tssBelowSyncDataMenuItem.Size = new System.Drawing.Size(172, 6);
            // 
            // mniExportToExcel
            // 
            this.mniExportToExcel.Name = "mniExportToExcel";
            this.mniExportToExcel.Size = new System.Drawing.Size(175, 22);
            // 
            // mniReloadMembers
            // 
            this.mniReloadMembers.Image = ((System.Drawing.Image)(resources.GetObject("mniReloadMembers.Image")));
            this.mniReloadMembers.Name = "mniReloadMembers";
            this.mniReloadMembers.Size = new System.Drawing.Size(175, 22);
            this.mniReloadMembers.Text = "Tải Dữ Liệu";
            // 
            // tbxMemberCode
            // 
            this.tbxMemberCode.Enabled = false;
            this.tbxMemberCode.Location = new System.Drawing.Point(214, 36);
            this.tbxMemberCode.Name = "tbxMemberCode";
            this.tbxMemberCode.Size = new System.Drawing.Size(150, 22);
            this.tbxMemberCode.TabIndex = 35;
            this.tbxMemberCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxMemberName_KeyDown);
            // 
            // cbxFilterByMemberCode
            // 
            this.cbxFilterByMemberCode.Location = new System.Drawing.Point(8, 36);
            this.cbxFilterByMemberCode.Name = "cbxFilterByMemberCode";
            this.cbxFilterByMemberCode.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByMemberCode.TabIndex = 34;
            this.cbxFilterByMemberCode.Text = "Lọc theo tên chủ thẻ:";
            this.cbxFilterByMemberCode.UseVisualStyleBackColor = true;
            // 
            // tbxMemberName
            // 
            this.tbxMemberName.Enabled = false;
            this.tbxMemberName.Location = new System.Drawing.Point(214, 8);
            this.tbxMemberName.Name = "tbxMemberName";
            this.tbxMemberName.Size = new System.Drawing.Size(150, 22);
            this.tbxMemberName.TabIndex = 33;
            this.tbxMemberName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxMemberName_KeyDown);
            // 
            // cbxFilterByMemberName
            // 
            this.cbxFilterByMemberName.Location = new System.Drawing.Point(8, 8);
            this.cbxFilterByMemberName.Name = "cbxFilterByMemberName";
            this.cbxFilterByMemberName.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByMemberName.TabIndex = 32;
            this.cbxFilterByMemberName.Text = "Lọc theo mã thẻ:";
            this.cbxFilterByMemberName.UseVisualStyleBackColor = true;
            // 
            // tmsMember
            // 
            this.tmsMember.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPersoCard,
            this.tssAfterPersoButton,
            this.btnShowHide,
            this.btnReloadMembers});
            this.tmsMember.Location = new System.Drawing.Point(0, 0);
            this.tmsMember.Name = "tmsMember";
            this.tmsMember.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tmsMember.Size = new System.Drawing.Size(557, 25);
            this.tmsMember.TabIndex = 22;
            this.tmsMember.Text = "toolStrip1";
            // 
            // btnPersoCard
            // 
            this.btnPersoCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPersoCard.Image = ((System.Drawing.Image)(resources.GetObject("btnPersoCard.Image")));
            this.btnPersoCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPersoCard.Name = "btnPersoCard";
            this.btnPersoCard.Size = new System.Drawing.Size(23, 22);
            this.btnPersoCard.Text = "Cấp Thẻ...";
            this.btnPersoCard.ToolTipText = "Cấp thẻ cho thành viên";
            // 
            // tssAfterPersoButton
            // 
            this.tssAfterPersoButton.Name = "tssAfterPersoButton";
            this.tssAfterPersoButton.Size = new System.Drawing.Size(6, 25);
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
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 30);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(569, 4);
            this.panel7.TabIndex = 17;
            // 
            // lblRightAreaTitleforListMember
            // 
            this.lblRightAreaTitleforListMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitleforListMember.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitleforListMember.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblRightAreaTitleforListMember.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitleforListMember.Location = new System.Drawing.Point(0, 0);
            this.lblRightAreaTitleforListMember.Name = "lblRightAreaTitleforListMember";
            this.lblRightAreaTitleforListMember.Size = new System.Drawing.Size(569, 30);
            this.lblRightAreaTitleforListMember.TabIndex = 16;
            this.lblRightAreaTitleforListMember.Text = "DANH SÁCH THIẾT BỊ";
            this.lblRightAreaTitleforListMember.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // cmsMemberRecord
            // 
            this.cmsMemberRecord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniPersoCard});
            this.cmsMemberRecord.Name = "contextMenuStrip1";
            this.cmsMemberRecord.Size = new System.Drawing.Size(128, 26);
            // 
            // mniPersoCard
            // 
            this.mniPersoCard.Image = ((System.Drawing.Image)(resources.GetObject("mniPersoCard.Image")));
            this.mniPersoCard.Name = "mniPersoCard";
            this.mniPersoCard.Size = new System.Drawing.Size(127, 22);
            this.mniPersoCard.Text = "Cấp Thẻ...";
            this.mniPersoCard.Click += new System.EventHandler(this.btnPersoCard_Clicked);
            // 
            // dgvShiftList
            // 
            this.dgvShiftList.AllowUserToAddRows = false;
            this.dgvShiftList.AllowUserToDeleteRows = false;
            this.dgvShiftList.AllowUserToOrderColumns = true;
            this.dgvShiftList.AllowUserToResizeRows = false;
            this.dgvShiftList.BackgroundColor = System.Drawing.Color.White;
            this.dgvShiftList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvShiftList.ColumnHeadersHeight = 26;
            this.dgvShiftList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDoorOutId,
            this.colMemberId,
            this.colSerialNumber,
            this.colPosition,
            this.colMemberCode,
            this.colMemberFullName,
            this.colDateIn,
            this.colDateOut,
            this.colImageIn,
            this.colImageOut,
            this.colDevice});
            this.dgvShiftList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShiftList.Location = new System.Drawing.Point(0, 91);
            this.dgvShiftList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvShiftList.MultiSelect = false;
            this.dgvShiftList.Name = "dgvShiftList";
            this.dgvShiftList.ReadOnly = true;
            this.dgvShiftList.RowHeadersVisible = false;
            this.dgvShiftList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShiftList.Size = new System.Drawing.Size(557, 437);
            this.dgvShiftList.TabIndex = 93;
            // 
            // colDoorOutId
            // 
            this.colDoorOutId.DataPropertyName = "DoorOutId";
            this.colDoorOutId.HeaderText = "DoorOutId";
            this.colDoorOutId.Name = "colDoorOutId";
            this.colDoorOutId.ReadOnly = true;
            this.colDoorOutId.Visible = false;
            // 
            // colMemberId
            // 
            this.colMemberId.DataPropertyName = "MemberId";
            this.colMemberId.HeaderText = "MemberId";
            this.colMemberId.Name = "colMemberId";
            this.colMemberId.ReadOnly = true;
            this.colMemberId.Visible = false;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.DataPropertyName = "SerialNumber";
            this.colSerialNumber.HeaderText = "Mã Thẻ";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            // 
            // colPosition
            // 
            this.colPosition.HeaderText = "Chức vụ";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            // 
            // colMemberCode
            // 
            this.colMemberCode.DataPropertyName = "MemberCode";
            this.colMemberCode.HeaderText = "Mã Thành viên";
            this.colMemberCode.Name = "colMemberCode";
            this.colMemberCode.ReadOnly = true;
            // 
            // colMemberFullName
            // 
            this.colMemberFullName.DataPropertyName = "MemberFullName";
            this.colMemberFullName.HeaderText = "Họ Và Tên";
            this.colMemberFullName.Name = "colMemberFullName";
            this.colMemberFullName.ReadOnly = true;
            this.colMemberFullName.Width = 150;
            // 
            // colDateIn
            // 
            this.colDateIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDateIn.DataPropertyName = "DateIn";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDateIn.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDateIn.HeaderText = "Ngày giờ vào";
            this.colDateIn.Name = "colDateIn";
            this.colDateIn.ReadOnly = true;
            this.colDateIn.Width = 106;
            // 
            // colDateOut
            // 
            this.colDateOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDateOut.DataPropertyName = "DateOut";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDateOut.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDateOut.HeaderText = "Ngày Giờ Ra";
            this.colDateOut.Name = "colDateOut";
            this.colDateOut.ReadOnly = true;
            this.colDateOut.Width = 102;
            // 
            // colImageIn
            // 
            this.colImageIn.DataPropertyName = "colImageIn";
            this.colImageIn.HeaderText = "Ảnh Vào";
            this.colImageIn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colImageIn.Name = "colImageIn";
            this.colImageIn.ReadOnly = true;
            this.colImageIn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colImageOut
            // 
            this.colImageOut.DataPropertyName = "colImageOut";
            this.colImageOut.HeaderText = "Ảnh Ra";
            this.colImageOut.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colImageOut.Name = "colImageOut";
            this.colImageOut.ReadOnly = true;
            this.colImageOut.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colDevice
            // 
            this.colDevice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDevice.DataPropertyName = "Device";
            this.colDevice.HeaderText = "Thiết bị";
            this.colDevice.Name = "colDevice";
            this.colDevice.ReadOnly = true;
            // 
            // UsrDevicestatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "UsrDevicestatistic";
            this.Size = new System.Drawing.Size(800, 600);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tmsOrganization.ResumeLayout(false);
            this.tmsOrganization.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.pnlRightMain.ResumeLayout(false);
            this.pnlRightMain.PerformLayout();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.cmsMemberTable.ResumeLayout(false);
            this.tmsMember.ResumeLayout(false);
            this.tmsMember.PerformLayout();
            this.cmsOrgTree.ResumeLayout(false);
            this.cmsMemberRecord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShiftList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private CommonControls.Custom.TitleLabel lblLeftAreaTitleforListPartner;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private CommonControls.Custom.TitleLabel lblRightAreaTitleforListMember;
        private System.Windows.Forms.Panel pnlRightMain;
        private System.Windows.Forms.Panel pnlFilterBox;
        private CommonControls.Custom.CommonToolStrip tmsMember;
        private System.Windows.Forms.ToolStripSeparator tssAfterPersoButton;
        private System.Windows.Forms.ToolStripButton btnShowHide;
        private CommonControls.Custom.PagerPanel pagerPanel;
        private System.Windows.Forms.ToolStripButton btnReloadMembers;
        private System.Windows.Forms.ContextMenuStrip cmsOrgTree;
        private System.Windows.Forms.ToolStripMenuItem mniReloadOrgs;
        private System.Windows.Forms.ContextMenuStrip cmsMemberTable;
        private System.Windows.Forms.ToolStripMenuItem mniSyncData;
        private System.Windows.Forms.ToolStripSeparator tssBelowSyncDataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniReloadMembers;
        private System.Windows.Forms.ContextMenuStrip cmsMemberRecord;
        private System.Windows.Forms.ToolStripMenuItem mniPersoCard;
        private System.Windows.Forms.ToolStripMenuItem mniExportToExcel;
        private System.Windows.Forms.ToolStripButton btnPersoCard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CommonControls.Custom.CommonToolStrip tmsOrganization;
        private System.Windows.Forms.ToolStripButton btnReloadOrgs;
        private System.Windows.Forms.TreeView trvOrganizations;
        private System.Windows.Forms.TextBox tbxMemberName;
        private System.Windows.Forms.CheckBox cbxFilterByMemberName;
        private System.Windows.Forms.TextBox tbxMemberCode;
        private System.Windows.Forms.CheckBox cbxFilterByMemberCode;
        private CommonControls.Custom.CommonDataGridView dgvShiftList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoorOutId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateOut;
        private System.Windows.Forms.DataGridViewImageColumn colImageIn;
        private System.Windows.Forms.DataGridViewImageColumn colImageOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevice;
    }
}
