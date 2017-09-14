namespace sTimeKeeping.WorkItems
{
    partial class UsrDateStatistic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrDateStatistic));
            this.cmsMemberRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniPersoCard = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMemberTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniSyncData = new System.Windows.Forms.ToolStripMenuItem();
            this.tssBelowSyncDataMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.mniExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mniReloadMembers = new System.Windows.Forms.ToolStripMenuItem();
            this.mniReloadOrgs = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsOrgTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblRightDateStatisticDetail = new CommonControls.Custom.TitleLabel();
            this.btnReloadMembers = new System.Windows.Forms.ToolStripButton();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.tssAfterPersoButton = new System.Windows.Forms.ToolStripSeparator();
            this.tmsMember = new CommonControls.Custom.CommonToolStrip();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvExportData = new ClientModel.Controls.Commons.CommonDataGridView();
            this.chkAutoCloseNode = new System.Windows.Forms.CheckBox();
            this.trvOrganizations = new System.Windows.Forms.TreeView();
            this.tsmOrg = new CommonControls.Custom.CommonToolStrip();
            this.btnRefreshOrg = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.treeOrg = new System.Windows.Forms.TreeView();
            this.lblLeftAreaTitleOrg = new CommonControls.Custom.TitleLabel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBarLoading = new System.Windows.Forms.ProgressBar();
            this.pagerPanel = new CommonControls.Custom.PagerPanel();
            this.pnlRightMain = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblT = new System.Windows.Forms.Label();
            this.txtT = new System.Windows.Forms.TextBox();
            this.lblK = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.txtK = new System.Windows.Forms.TextBox();
            this.txtP = new System.Windows.Forms.TextBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.lblFilterStatistic = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lbLDate = new System.Windows.Forms.Label();
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.miniToolStrip = new CommonControls.Custom.CommonToolStrip();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsMemberRecord.SuspendLayout();
            this.cmsMemberTable.SuspendLayout();
            this.cmsOrgTree.SuspendLayout();
            this.tmsMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportData)).BeginInit();
            this.tsmOrg.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlRightMain.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlFilterBox.SuspendLayout();
            this.panelTotal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel15.SuspendLayout();
            this.SuspendLayout();
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
            // mniReloadOrgs
            // 
            this.mniReloadOrgs.Image = ((System.Drawing.Image)(resources.GetObject("mniReloadOrgs.Image")));
            this.mniReloadOrgs.Name = "mniReloadOrgs";
            this.mniReloadOrgs.Size = new System.Drawing.Size(133, 22);
            this.mniReloadOrgs.Text = "Tải Dữ Liệu";
            // 
            // cmsOrgTree
            // 
            this.cmsOrgTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniReloadOrgs});
            this.cmsOrgTree.Name = "contextMenuStrip1";
            this.cmsOrgTree.Size = new System.Drawing.Size(134, 26);
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 32);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1053, 4);
            this.panel7.TabIndex = 17;
            // 
            // lblRightDateStatisticDetail
            // 
            this.lblRightDateStatisticDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightDateStatisticDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightDateStatisticDetail.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblRightDateStatisticDetail.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightDateStatisticDetail.Location = new System.Drawing.Point(0, 0);
            this.lblRightDateStatisticDetail.Name = "lblRightDateStatisticDetail";
            this.lblRightDateStatisticDetail.Size = new System.Drawing.Size(1053, 32);
            this.lblRightDateStatisticDetail.TabIndex = 16;
            this.lblRightDateStatisticDetail.Text = "THỐNG KÊ CHI TIẾT";
            this.lblRightDateStatisticDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReloadMembers
            // 
            this.btnReloadMembers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadMembers.Enabled = false;
            this.btnReloadMembers.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadMembers.Image")));
            this.btnReloadMembers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadMembers.Name = "btnReloadMembers";
            this.btnReloadMembers.Size = new System.Drawing.Size(23, 22);
            this.btnReloadMembers.Text = "Tải Dữ Liệu";
            this.btnReloadMembers.ToolTipText = "Tải dữ liệu thống kê";
            this.btnReloadMembers.Click += new System.EventHandler(this.btnReloadMembers_Click);
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
            // tssAfterPersoButton
            // 
            this.tssAfterPersoButton.Name = "tssAfterPersoButton";
            this.tssAfterPersoButton.Size = new System.Drawing.Size(6, 25);
            // 
            // tmsMember
            // 
            this.tmsMember.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssAfterPersoButton,
            this.btnShowHide,
            this.btnExportToExcel,
            this.btnReloadMembers});
            this.tmsMember.Location = new System.Drawing.Point(0, 0);
            this.tmsMember.Name = "tmsMember";
            this.tmsMember.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.tmsMember.Size = new System.Drawing.Size(1039, 25);
            this.tmsMember.TabIndex = 22;
            this.tmsMember.Text = "toolStrip1";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportToExcel.Enabled = false;
            this.btnExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToExcel.Image")));
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExportToExcel.Text = "Xuất Ra Excel...";
            this.btnExportToExcel.ToolTipText = "Xuất dữ liệu đang hiển thị ra tập tin excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(6, 5);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panel1);
            this.splitContainer.Panel1.Controls.Add(this.treeOrg);
            this.splitContainer.Panel1.Controls.Add(this.lblLeftAreaTitleOrg);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel8);
            this.splitContainer.Panel2.Controls.Add(this.panel7);
            this.splitContainer.Panel2.Controls.Add(this.lblRightDateStatisticDetail);
            this.splitContainer.Size = new System.Drawing.Size(1319, 730);
            this.splitContainer.SplitterDistance = 258;
            this.splitContainer.SplitterWidth = 6;
            this.splitContainer.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(256, 696);
            this.panel1.TabIndex = 97;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvExportData);
            this.panel2.Controls.Add(this.chkAutoCloseNode);
            this.panel2.Controls.Add(this.trvOrganizations);
            this.panel2.Controls.Add(this.tsmOrg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 686);
            this.panel2.TabIndex = 57;
            // 
            // dgvExportData
            // 
            this.dgvExportData.AllowUserToAddRows = false;
            this.dgvExportData.AllowUserToDeleteRows = false;
            this.dgvExportData.AllowUserToOrderColumns = true;
            this.dgvExportData.AllowUserToResizeRows = false;
            this.dgvExportData.BackgroundColor = System.Drawing.Color.White;
            this.dgvExportData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvExportData.ColumnHeadersHeight = 26;
            this.dgvExportData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCode,
            this.colName,
            this.colDate,
            this.colDateIn,
            this.colDateOut,
            this.colStatus});
            this.dgvExportData.Location = new System.Drawing.Point(14, 470);
            this.dgvExportData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvExportData.MultiSelect = false;
            this.dgvExportData.Name = "dgvExportData";
            this.dgvExportData.ReadOnly = true;
            this.dgvExportData.RowHeadersVisible = false;
            this.dgvExportData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExportData.Size = new System.Drawing.Size(214, 189);
            this.dgvExportData.TabIndex = 95;
            this.dgvExportData.Visible = false;
            // 
            // chkAutoCloseNode
            // 
            this.chkAutoCloseNode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chkAutoCloseNode.Location = new System.Drawing.Point(0, 664);
            this.chkAutoCloseNode.Name = "chkAutoCloseNode";
            this.chkAutoCloseNode.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.chkAutoCloseNode.Size = new System.Drawing.Size(244, 20);
            this.chkAutoCloseNode.TabIndex = 58;
            this.chkAutoCloseNode.Text = "Tự động rút gọn danh sách";
            this.chkAutoCloseNode.UseVisualStyleBackColor = true;
            // 
            // trvOrganizations
            // 
            this.trvOrganizations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvOrganizations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvOrganizations.Location = new System.Drawing.Point(0, 25);
            this.trvOrganizations.Name = "trvOrganizations";
            this.trvOrganizations.Size = new System.Drawing.Size(244, 659);
            this.trvOrganizations.TabIndex = 57;
            // 
            // tsmOrg
            // 
            this.tsmOrg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshOrg,
            this.toolStripSeparator4});
            this.tsmOrg.Location = new System.Drawing.Point(0, 0);
            this.tsmOrg.Name = "tsmOrg";
            this.tsmOrg.Size = new System.Drawing.Size(244, 25);
            this.tsmOrg.TabIndex = 56;
            this.tsmOrg.Text = "tlstripListGroup";
            // 
            // btnRefreshOrg
            // 
            this.btnRefreshOrg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshOrg.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshOrg.Image")));
            this.btnRefreshOrg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshOrg.Name = "btnRefreshOrg";
            this.btnRefreshOrg.Size = new System.Drawing.Size(23, 22);
            this.btnRefreshOrg.Text = "Tải Dữ Liệu";
            this.btnRefreshOrg.ToolTipText = "Tải danh sách nhóm";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator4.Visible = false;
            // 
            // treeOrg
            // 
            this.treeOrg.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.treeOrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeOrg.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.treeOrg.Location = new System.Drawing.Point(0, 32);
            this.treeOrg.Name = "treeOrg";
            this.treeOrg.Size = new System.Drawing.Size(256, 696);
            this.treeOrg.TabIndex = 3;
            // 
            // lblLeftAreaTitleOrg
            // 
            this.lblLeftAreaTitleOrg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblLeftAreaTitleOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftAreaTitleOrg.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblLeftAreaTitleOrg.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLeftAreaTitleOrg.Location = new System.Drawing.Point(0, 0);
            this.lblLeftAreaTitleOrg.Name = "lblLeftAreaTitleOrg";
            this.lblLeftAreaTitleOrg.Size = new System.Drawing.Size(256, 32);
            this.lblLeftAreaTitleOrg.TabIndex = 2;
            this.lblLeftAreaTitleOrg.Text = "TỔ CHỨC";
            this.lblLeftAreaTitleOrg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.AutoScroll = true;
            this.panel8.Controls.Add(this.pnlBottom);
            this.panel8.Controls.Add(this.pnlRightMain);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 36);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(6, 0, 6, 4);
            this.panel8.Size = new System.Drawing.Size(1053, 692);
            this.panel8.TabIndex = 18;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblProgress);
            this.pnlBottom.Controls.Add(this.progressBarLoading);
            this.pnlBottom.Controls.Add(this.pagerPanel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(6, 670);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1041, 18);
            this.pnlBottom.TabIndex = 101;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblProgress.Location = new System.Drawing.Point(100, 0);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblProgress.Size = new System.Drawing.Size(20, 20);
            this.lblProgress.TabIndex = 104;
            this.lblProgress.Text = "...";
            // 
            // progressBarLoading
            // 
            this.progressBarLoading.BackColor = System.Drawing.SystemColors.Control;
            this.progressBarLoading.Dock = System.Windows.Forms.DockStyle.Left;
            this.progressBarLoading.Location = new System.Drawing.Point(0, 0);
            this.progressBarLoading.Name = "progressBarLoading";
            this.progressBarLoading.Size = new System.Drawing.Size(100, 18);
            this.progressBarLoading.TabIndex = 102;
            // 
            // pagerPanel
            // 
            this.pagerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagerPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel.Location = new System.Drawing.Point(0, 0);
            this.pagerPanel.Name = "pagerPanel";
            this.pagerPanel.Size = new System.Drawing.Size(1041, 18);
            this.pagerPanel.TabIndex = 101;
            // 
            // pnlRightMain
            // 
            this.pnlRightMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRightMain.Controls.Add(this.panel3);
            this.pnlRightMain.Controls.Add(this.pnlFilterBox);
            this.pnlRightMain.Controls.Add(this.tmsMember);
            this.pnlRightMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightMain.Location = new System.Drawing.Point(6, 0);
            this.pnlRightMain.Name = "pnlRightMain";
            this.pnlRightMain.Size = new System.Drawing.Size(1041, 688);
            this.pnlRightMain.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panel14);
            this.panel3.Controls.Add(this.panel13);
            this.panel3.Controls.Add(this.panel12);
            this.panel3.Controls.Add(this.panel11);
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 105);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1039, 581);
            this.panel3.TabIndex = 94;
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 491);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(1039, 71);
            this.panel14.TabIndex = 8;
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 423);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1039, 68);
            this.panel13.TabIndex = 7;
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 354);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1039, 69);
            this.panel12.TabIndex = 6;
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 285);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1039, 69);
            this.panel11.TabIndex = 5;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 219);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1039, 66);
            this.panel10.TabIndex = 4;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 149);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1039, 70);
            this.panel9.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 83);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1039, 66);
            this.panel6.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 16);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1039, 67);
            this.panel5.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1039, 16);
            this.panel4.TabIndex = 0;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.ContextMenuStrip = this.cmsMemberTable;
            this.pnlFilterBox.Controls.Add(this.panelTotal);
            this.pnlFilterBox.Controls.Add(this.panel15);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlFilterBox.Size = new System.Drawing.Size(1039, 80);
            this.pnlFilterBox.TabIndex = 23;
            // 
            // panelTotal
            // 
            this.panelTotal.Controls.Add(this.groupBox1);
            this.panelTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTotal.Location = new System.Drawing.Point(387, 5);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Size = new System.Drawing.Size(646, 70);
            this.panelTotal.TabIndex = 118;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblT);
            this.groupBox1.Controls.Add(this.txtT);
            this.groupBox1.Controls.Add(this.lblK);
            this.groupBox1.Controls.Add(this.lblP);
            this.groupBox1.Controls.Add(this.txtK);
            this.groupBox1.Controls.Add(this.txtP);
            this.groupBox1.Location = new System.Drawing.Point(9, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 64);
            this.groupBox1.TabIndex = 98;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng kết";
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Location = new System.Drawing.Point(59, 30);
            this.lblT.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(33, 16);
            this.lblT.TabIndex = 103;
            this.lblT.Text = "Trễ:";
            // 
            // txtT
            // 
            this.txtT.Enabled = false;
            this.txtT.Location = new System.Drawing.Point(104, 27);
            this.txtT.Name = "txtT";
            this.txtT.Size = new System.Drawing.Size(41, 22);
            this.txtT.TabIndex = 102;
            // 
            // lblK
            // 
            this.lblK.AutoSize = true;
            this.lblK.Location = new System.Drawing.Point(380, 30);
            this.lblK.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblK.Name = "lblK";
            this.lblK.Size = new System.Drawing.Size(157, 16);
            this.lblK.TabIndex = 101;
            this.lblK.Text = "Số ngày nghỉ không phép:";
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Location = new System.Drawing.Point(174, 30);
            this.lblP.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(119, 16);
            this.lblP.TabIndex = 100;
            this.lblP.Text = "Số ngày nghỉ phép:";
            // 
            // txtK
            // 
            this.txtK.Enabled = false;
            this.txtK.Location = new System.Drawing.Point(549, 27);
            this.txtK.Name = "txtK";
            this.txtK.Size = new System.Drawing.Size(41, 22);
            this.txtK.TabIndex = 99;
            // 
            // txtP
            // 
            this.txtP.Enabled = false;
            this.txtP.Location = new System.Drawing.Point(309, 27);
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(41, 22);
            this.txtP.TabIndex = 98;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.lblFilterStatistic);
            this.panel15.Controls.Add(this.dtpDate);
            this.panel15.Controls.Add(this.lbLDate);
            this.panel15.Controls.Add(this.tbxCode);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(6, 5);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(381, 70);
            this.panel15.TabIndex = 117;
            // 
            // lblFilterStatistic
            // 
            this.lblFilterStatistic.AutoSize = true;
            this.lblFilterStatistic.Location = new System.Drawing.Point(28, 40);
            this.lblFilterStatistic.Name = "lblFilterStatistic";
            this.lblFilterStatistic.Size = new System.Drawing.Size(117, 16);
            this.lblFilterStatistic.TabIndex = 119;
            this.lblFilterStatistic.Text = "Nhâp điều kiện lọc:";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(185, 8);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(164, 22);
            this.dtpDate.TabIndex = 118;
            // 
            // lbLDate
            // 
            this.lbLDate.AutoSize = true;
            this.lbLDate.Location = new System.Drawing.Point(28, 13);
            this.lbLDate.Margin = new System.Windows.Forms.Padding(7, 2, 7, 2);
            this.lbLDate.Name = "lbLDate";
            this.lbLDate.Size = new System.Drawing.Size(41, 16);
            this.lbLDate.TabIndex = 117;
            this.lbLDate.Text = "Ngày:";
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(185, 36);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(164, 22);
            this.tbxCode.TabIndex = 116;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(32, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.miniToolStrip.Size = new System.Drawing.Size(213, 25);
            this.miniToolStrip.TabIndex = 59;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "colCode";
            this.colCode.HeaderText = "Mã TV";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCode.Width = 30;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "colName";
            this.colName.HeaderText = "Tên TV";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colName.Width = 40;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "colDate";
            this.colDate.HeaderText = "Ngày";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 35;
            // 
            // colDateIn
            // 
            this.colDateIn.DataPropertyName = "colDateIn";
            this.colDateIn.HeaderText = "Giờ vào";
            this.colDateIn.Name = "colDateIn";
            this.colDateIn.ReadOnly = true;
            this.colDateIn.Width = 35;
            // 
            // colDateOut
            // 
            this.colDateOut.DataPropertyName = "colDateOut";
            this.colDateOut.HeaderText = "Giờ ra";
            this.colDateOut.Name = "colDateOut";
            this.colDateOut.ReadOnly = true;
            this.colDateOut.Width = 35;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "colStatus";
            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Visible = false;
            this.colStatus.Width = 38;
            // 
            // UsrDateStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "UsrDateStatistic";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Size = new System.Drawing.Size(1331, 740);
            this.cmsMemberRecord.ResumeLayout(false);
            this.cmsMemberTable.ResumeLayout(false);
            this.cmsOrgTree.ResumeLayout(false);
            this.tmsMember.ResumeLayout(false);
            this.tmsMember.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportData)).EndInit();
            this.tsmOrg.ResumeLayout(false);
            this.tsmOrg.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlRightMain.ResumeLayout(false);
            this.pnlRightMain.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pnlFilterBox.ResumeLayout(false);
            this.panelTotal.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsMemberRecord;
        private System.Windows.Forms.ToolStripMenuItem mniPersoCard;
        private System.Windows.Forms.ContextMenuStrip cmsMemberTable;
        private System.Windows.Forms.ToolStripMenuItem mniSyncData;
        private System.Windows.Forms.ToolStripSeparator tssBelowSyncDataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem mniReloadMembers;
        private System.Windows.Forms.ToolStripMenuItem mniReloadOrgs;
        private System.Windows.Forms.ContextMenuStrip cmsOrgTree;
        private System.Windows.Forms.Panel panel7;
        private CommonControls.Custom.TitleLabel lblRightDateStatisticDetail;
        private System.Windows.Forms.ToolStripButton btnReloadMembers;
        private System.Windows.Forms.ToolStripButton btnShowHide;
        private System.Windows.Forms.ToolStripSeparator tssAfterPersoButton;
        private CommonControls.Custom.CommonToolStrip tmsMember;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel pnlRightMain;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label lblFilterStatistic;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lbLDate;
        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private CommonControls.Custom.TitleLabel lblLeftAreaTitleOrg;
        private CommonControls.Custom.CommonToolStrip miniToolStrip;
        private System.Windows.Forms.TreeView treeOrg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.TextBox txtT;
        private System.Windows.Forms.Label lblK;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.TextBox txtK;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkAutoCloseNode;
        private System.Windows.Forms.TreeView trvOrganizations;
        private CommonControls.Custom.CommonToolStrip tsmOrg;
        private System.Windows.Forms.ToolStripButton btnRefreshOrg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private ClientModel.Controls.Commons.CommonDataGridView dgvExportData;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar progressBarLoading;
        private CommonControls.Custom.PagerPanel pagerPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}
