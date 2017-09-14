namespace eCashComponentWorkItems.GroupItem
{
    partial class UsrGroupItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrGroupItem));
            this.mniUpdateGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNotification1 = new System.Windows.Forms.Label();
            this.tbxMemberPrice = new System.Windows.Forms.TextBox();
            this.cbxFilterByPriceCode = new System.Windows.Forms.CheckBox();
            this.tbxItemName = new System.Windows.Forms.TextBox();
            this.cbxFilterByItemName = new System.Windows.Forms.CheckBox();
            this.dgvItem = new CommonControls.Custom.CommonDataGridView();
            this.btnAddItem = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateItem = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveItem = new System.Windows.Forms.ToolStripButton();
            this.tssAfterPersoButton = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.btnReloadItem = new System.Windows.Forms.ToolStripButton();
            this.lblItemList = new CommonControls.Custom.TitleLabel();
            this.cmsUserTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mniExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mniReloadUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.mniRemoveGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNotification2 = new System.Windows.Forms.Label();
            this.cmsOrgRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.dtpApplyTimeTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lbFrom = new System.Windows.Forms.Label();
            this.dtpApplyTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.cbxFilterByApplyTime = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tmsItem = new CommonControls.Custom.CommonToolStrip();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkAutoCloseNode = new System.Windows.Forms.CheckBox();
            this.trvGroup = new System.Windows.Forms.TreeView();
            this.cmsOrgTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniReloadOrgs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGroup = new CommonControls.Custom.CommonToolStrip();
            this.btnAddGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpdateGroup = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReloadGroup = new System.Windows.Forms.ToolStripButton();
            this.lblLeftAreaTitle = new CommonControls.Custom.TitleLabel();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Blank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.cmsUserTable.SuspendLayout();
            this.cmsOrgRecord.SuspendLayout();
            this.pnlFilterBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tmsItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.cmsOrgTree.SuspendLayout();
            this.tsmGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // mniUpdateGroup
            // 
            this.mniUpdateGroup.Image = ((System.Drawing.Image)(resources.GetObject("mniUpdateGroup.Image")));
            this.mniUpdateGroup.Name = "mniUpdateGroup";
            this.mniUpdateGroup.Size = new System.Drawing.Size(170, 22);
            this.mniUpdateGroup.Text = "Cập Nhật Nhóm...";
            // 
            // lblNotification1
            // 
            this.lblNotification1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNotification1.Location = new System.Drawing.Point(370, 8);
            this.lblNotification1.Name = "lblNotification1";
            this.lblNotification1.Size = new System.Drawing.Size(150, 22);
            this.lblNotification1.TabIndex = 41;
            this.lblNotification1.Text = "Vui lòng nhập ít nhất 2 ký tự";
            this.lblNotification1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotification1.Visible = false;
            // 
            // tbxMemberPrice
            // 
            this.tbxMemberPrice.Enabled = false;
            this.tbxMemberPrice.Location = new System.Drawing.Point(214, 36);
            this.tbxMemberPrice.Name = "tbxMemberPrice";
            this.tbxMemberPrice.Size = new System.Drawing.Size(150, 22);
            this.tbxMemberPrice.TabIndex = 35;
            // 
            // cbxFilterByPriceCode
            // 
            this.cbxFilterByPriceCode.Location = new System.Drawing.Point(8, 36);
            this.cbxFilterByPriceCode.Name = "cbxFilterByPriceCode";
            this.cbxFilterByPriceCode.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByPriceCode.TabIndex = 34;
            this.cbxFilterByPriceCode.Text = "Lọc theo giá:";
            this.cbxFilterByPriceCode.UseVisualStyleBackColor = true;
            this.cbxFilterByPriceCode.CheckedChanged += new System.EventHandler(this.cbxFilterByPriceCode_CheckedChanged_1);
            // 
            // tbxItemName
            // 
            this.tbxItemName.Enabled = false;
            this.tbxItemName.Location = new System.Drawing.Point(214, 8);
            this.tbxItemName.Name = "tbxItemName";
            this.tbxItemName.Size = new System.Drawing.Size(150, 22);
            this.tbxItemName.TabIndex = 33;
            // 
            // cbxFilterByItemName
            // 
            this.cbxFilterByItemName.Location = new System.Drawing.Point(8, 8);
            this.cbxFilterByItemName.Name = "cbxFilterByItemName";
            this.cbxFilterByItemName.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByItemName.TabIndex = 32;
            this.cbxFilterByItemName.Text = "Lọc theo tên dịch vụ:";
            this.cbxFilterByItemName.UseVisualStyleBackColor = true;
            this.cbxFilterByItemName.CheckedChanged += new System.EventHandler(this.cbxFilterByItemName_CheckedChanged_1);
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.AllowUserToOrderColumns = true;
            this.dgvItem.AllowUserToResizeRows = false;
            this.dgvItem.BackgroundColor = System.Drawing.Color.White;
            this.dgvItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItem.ColumnHeadersHeight = 26;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colItemName,
            this.colprice,
            this.colStatus,
            this.colStartDate,
            this.colEndDate,
            this.colDescription,
            this.Blank});
            this.dgvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItem.Location = new System.Drawing.Point(0, 123);
            this.dgvItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvItem.MultiSelect = false;
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.RowHeadersVisible = false;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(632, 384);
            this.dgvItem.TabIndex = 46;
            // 
            // btnAddItem
            // 
            this.btnAddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(23, 22);
            this.btnAddItem.Text = "Thêm Mục Mới...";
            this.btnAddItem.ToolTipText = "Thêm mục mới vào hệ thống.";
            // 
            // btnUpdateItem
            // 
            this.btnUpdateItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateItem.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateItem.Image")));
            this.btnUpdateItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateItem.Name = "btnUpdateItem";
            this.btnUpdateItem.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateItem.Text = "Cập Nhật Thông Tin Danh Mục...";
            this.btnUpdateItem.ToolTipText = "Cập nhật thông tin danh mục trong hệ thống.";
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveItem.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveItem.Image")));
            this.btnRemoveItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveItem.Text = "Hủy Danh Mục Khỏi Hệ Thống...";
            this.btnRemoveItem.ToolTipText = "Hủy danh mục khỏi hệ thống";
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
            // btnReloadItem
            // 
            this.btnReloadItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadItem.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadItem.Image")));
            this.btnReloadItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadItem.Name = "btnReloadItem";
            this.btnReloadItem.Size = new System.Drawing.Size(23, 22);
            this.btnReloadItem.Text = "Tải Dữ Liệu";
            this.btnReloadItem.ToolTipText = "Tải danh sách danh mục";
            // 
            // lblItemList
            // 
            this.lblItemList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblItemList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblItemList.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblItemList.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblItemList.Location = new System.Drawing.Point(0, 0);
            this.lblItemList.Name = "lblItemList";
            this.lblItemList.Size = new System.Drawing.Size(644, 30);
            this.lblItemList.TabIndex = 34;
            this.lblItemList.Text = "DANH SÁCH DỊCH VỤ";
            this.lblItemList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // lblNotification2
            // 
            this.lblNotification2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNotification2.Location = new System.Drawing.Point(370, 36);
            this.lblNotification2.Name = "lblNotification2";
            this.lblNotification2.Size = new System.Drawing.Size(150, 22);
            this.lblNotification2.TabIndex = 42;
            this.lblNotification2.Text = "Vui lòng nhập ít nhất 2 ký tự";
            this.lblNotification2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotification2.Visible = false;
            // 
            // cmsOrgRecord
            // 
            this.cmsOrgRecord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniUpdateGroup,
            this.mniRemoveGroups});
            this.cmsOrgRecord.Name = "cmsGroup";
            this.cmsOrgRecord.Size = new System.Drawing.Size(171, 48);
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.Controls.Add(this.dtpApplyTimeTo);
            this.pnlFilterBox.Controls.Add(this.lblTo);
            this.pnlFilterBox.Controls.Add(this.lbFrom);
            this.pnlFilterBox.Controls.Add(this.dtpApplyTimeFrom);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByApplyTime);
            this.pnlFilterBox.Controls.Add(this.lblNotification2);
            this.pnlFilterBox.Controls.Add(this.lblNotification1);
            this.pnlFilterBox.Controls.Add(this.tbxMemberPrice);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByPriceCode);
            this.pnlFilterBox.Controls.Add(this.tbxItemName);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByItemName);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(632, 98);
            this.pnlFilterBox.TabIndex = 45;
            // 
            // dtpApplyTimeTo
            // 
            this.dtpApplyTimeTo.CustomFormat = "dd/MM/yyyy";
            this.dtpApplyTimeTo.Enabled = false;
            this.dtpApplyTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplyTimeTo.Location = new System.Drawing.Point(477, 63);
            this.dtpApplyTimeTo.Name = "dtpApplyTimeTo";
            this.dtpApplyTimeTo.Size = new System.Drawing.Size(137, 22);
            this.dtpApplyTimeTo.TabIndex = 47;
            this.dtpApplyTimeTo.ValueChanged += new System.EventHandler(this.dtpApplyTimeTo_ValueChanged);
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(429, 64);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(42, 24);
            this.lblTo.TabIndex = 46;
            this.lblTo.Text = "Đến:";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFrom
            // 
            this.lbFrom.Location = new System.Drawing.Point(247, 64);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(33, 24);
            this.lbFrom.TabIndex = 45;
            this.lbFrom.Text = "Từ:";
            this.lbFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpApplyTimeFrom
            // 
            this.dtpApplyTimeFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpApplyTimeFrom.Enabled = false;
            this.dtpApplyTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplyTimeFrom.Location = new System.Drawing.Point(286, 64);
            this.dtpApplyTimeFrom.Name = "dtpApplyTimeFrom";
            this.dtpApplyTimeFrom.Size = new System.Drawing.Size(137, 22);
            this.dtpApplyTimeFrom.TabIndex = 44;
            this.dtpApplyTimeFrom.ValueChanged += new System.EventHandler(this.dtpApplyTimeFrom_ValueChanged);
            // 
            // cbxFilterByApplyTime
            // 
            this.cbxFilterByApplyTime.Location = new System.Drawing.Point(8, 64);
            this.cbxFilterByApplyTime.Name = "cbxFilterByApplyTime";
            this.cbxFilterByApplyTime.Size = new System.Drawing.Size(233, 24);
            this.cbxFilterByApplyTime.TabIndex = 43;
            this.cbxFilterByApplyTime.Text = "Lọc theo khoảng thời gian áp dụng:";
            this.cbxFilterByApplyTime.UseVisualStyleBackColor = true;
            this.cbxFilterByApplyTime.CheckedChanged += new System.EventHandler(this.cbxFilterByApplyTime_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Size = new System.Drawing.Size(644, 537);
            this.panel1.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvItem);
            this.panel2.Controls.Add(this.pnlFilterBox);
            this.panel2.Controls.Add(this.tmsItem);
            this.panel2.Controls.Add(this.pagerPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 529);
            this.panel2.TabIndex = 38;
            // 
            // tmsItem
            // 
            this.tmsItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddItem,
            this.btnUpdateItem,
            this.btnRemoveItem,
            this.tssAfterPersoButton,
            this.btnShowHide,
            this.btnReloadItem});
            this.tmsItem.Location = new System.Drawing.Point(0, 0);
            this.tmsItem.Name = "tmsItem";
            this.tmsItem.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tmsItem.Size = new System.Drawing.Size(632, 25);
            this.tmsItem.TabIndex = 44;
            this.tmsItem.Text = "toolStrip1";
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 507);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(632, 20);
            this.pagerPanel1.TabIndex = 40;
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
            this.splitContainer.Panel1.Controls.Add(this.panel3);
            this.splitContainer.Panel1.Controls.Add(this.lblLeftAreaTitle);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel1);
            this.splitContainer.Panel2.Controls.Add(this.lblItemList);
            this.splitContainer.Size = new System.Drawing.Size(904, 569);
            this.splitContainer.SplitterDistance = 253;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(251, 537);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.chkAutoCloseNode);
            this.panel4.Controls.Add(this.trvGroup);
            this.panel4.Controls.Add(this.tsmGroup);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(5, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(241, 527);
            this.panel4.TabIndex = 57;
            // 
            // chkAutoCloseNode
            // 
            this.chkAutoCloseNode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chkAutoCloseNode.Location = new System.Drawing.Point(0, 505);
            this.chkAutoCloseNode.Name = "chkAutoCloseNode";
            this.chkAutoCloseNode.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.chkAutoCloseNode.Size = new System.Drawing.Size(239, 20);
            this.chkAutoCloseNode.TabIndex = 58;
            this.chkAutoCloseNode.Text = "Tự động rút gọn danh sách";
            this.chkAutoCloseNode.UseVisualStyleBackColor = true;
            // 
            // trvGroup
            // 
            this.trvGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvGroup.ContextMenuStrip = this.cmsOrgTree;
            this.trvGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvGroup.Location = new System.Drawing.Point(0, 25);
            this.trvGroup.Name = "trvGroup";
            this.trvGroup.Size = new System.Drawing.Size(239, 500);
            this.trvGroup.TabIndex = 57;
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
            // tsmGroup
            // 
            this.tsmGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddGroup,
            this.toolStripSeparator4,
            this.btnUpdateGroup,
            this.btnRemoveGroup,
            this.toolStripSeparator10,
            this.btnReloadGroup});
            this.tsmGroup.Location = new System.Drawing.Point(0, 0);
            this.tsmGroup.Name = "tsmGroup";
            this.tsmGroup.Size = new System.Drawing.Size(239, 25);
            this.tsmGroup.TabIndex = 56;
            this.tsmGroup.Text = "tlstripListGroup";
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGroup.Image")));
            this.btnAddGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(23, 22);
            this.btnAddGroup.Text = "Thêm Nhóm Mới...";
            this.btnAddGroup.ToolTipText = "Thêm Nhóm mới";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator4.Visible = false;
            // 
            // btnUpdateGroup
            // 
            this.btnUpdateGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateGroup.Image")));
            this.btnUpdateGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateGroup.Name = "btnUpdateGroup";
            this.btnUpdateGroup.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateGroup.Text = "Cập Nhật Nhóm...";
            this.btnUpdateGroup.ToolTipText = "Cập nhật thông tin nhóm";
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveGroup.Image")));
            this.btnRemoveGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveGroup.Text = "Hủy Nhóm...";
            this.btnRemoveGroup.ToolTipText = "Hủy nhóm khỏi hệ thống";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // btnReloadGroup
            // 
            this.btnReloadGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadGroup.Image")));
            this.btnReloadGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadGroup.Name = "btnReloadGroup";
            this.btnReloadGroup.Size = new System.Drawing.Size(23, 22);
            this.btnReloadGroup.Text = "Tải Dữ Liệu";
            this.btnReloadGroup.ToolTipText = "Tải danh sách nhóm";
            // 
            // lblLeftAreaTitle
            // 
            this.lblLeftAreaTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblLeftAreaTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftAreaTitle.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblLeftAreaTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLeftAreaTitle.Location = new System.Drawing.Point(0, 0);
            this.lblLeftAreaTitle.Name = "lblLeftAreaTitle";
            this.lblLeftAreaTitle.Size = new System.Drawing.Size(251, 30);
            this.lblLeftAreaTitle.TabIndex = 2;
            this.lblLeftAreaTitle.Text = "DANH SÁCH NHÓM DỊCH VỤ";
            this.lblLeftAreaTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colItemName
            // 
            this.colItemName.DataPropertyName = "Name";
            this.colItemName.HeaderText = "Tên Dịch Vụ";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            this.colItemName.Width = 125;
            // 
            // colprice
            // 
            this.colprice.DataPropertyName = "Price";
            this.colprice.HeaderText = "Giá";
            this.colprice.Name = "colprice";
            this.colprice.ReadOnly = true;
            this.colprice.Width = 125;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Tình Trạng";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Visible = false;
            this.colStatus.Width = 125;
            // 
            // colStartDate
            // 
            this.colStartDate.DataPropertyName = "StartDate";
            this.colStartDate.HeaderText = "Ngày Bắt Đầu";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.ReadOnly = true;
            this.colStartDate.Width = 150;
            // 
            // colEndDate
            // 
            this.colEndDate.DataPropertyName = "EndDate";
            this.colEndDate.HeaderText = "Ngày Kết Thúc";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.ReadOnly = true;
            this.colEndDate.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "TemporaryAddress";
            this.colDescription.HeaderText = "Ghi Chú";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // Blank
            // 
            this.Blank.HeaderText = "";
            this.Blank.Name = "Blank";
            this.Blank.ReadOnly = true;
            this.Blank.Width = 5;
            // 
            // UsrGroupItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "UsrGroupItem";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Size = new System.Drawing.Size(916, 579);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.cmsUserTable.ResumeLayout(false);
            this.cmsOrgRecord.ResumeLayout(false);
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tmsItem.ResumeLayout(false);
            this.tmsItem.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.cmsOrgTree.ResumeLayout(false);
            this.tsmGroup.ResumeLayout(false);
            this.tsmGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mniUpdateGroup;
        private System.Windows.Forms.Label lblNotification1;
        private System.Windows.Forms.TextBox tbxMemberPrice;
        private System.Windows.Forms.CheckBox cbxFilterByPriceCode;
        private System.Windows.Forms.TextBox tbxItemName;
        private System.Windows.Forms.CheckBox cbxFilterByItemName;
        private CommonControls.Custom.CommonDataGridView dgvItem;
        private System.Windows.Forms.ToolStripButton btnAddItem;
        private System.Windows.Forms.ToolStripButton btnUpdateItem;
        private System.Windows.Forms.ToolStripButton btnRemoveItem;
        private System.Windows.Forms.ToolStripSeparator tssAfterPersoButton;
        private System.Windows.Forms.ToolStripButton btnShowHide;
        private System.Windows.Forms.ToolStripButton btnReloadItem;
        private CommonControls.Custom.TitleLabel lblItemList;
        private System.Windows.Forms.ContextMenuStrip cmsUserTable;
        private System.Windows.Forms.ToolStripMenuItem mniAddUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mniExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem mniReloadUsers;
        private System.Windows.Forms.ToolStripMenuItem mniRemoveGroups;
        private System.Windows.Forms.Label lblNotification2;
        private System.Windows.Forms.ContextMenuStrip cmsOrgRecord;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CommonControls.Custom.CommonToolStrip tmsItem;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chkAutoCloseNode;
        private System.Windows.Forms.TreeView trvGroup;
        private System.Windows.Forms.ContextMenuStrip cmsOrgTree;
        private System.Windows.Forms.ToolStripMenuItem mniReloadOrgs;
        private CommonControls.Custom.CommonToolStrip tsmGroup;
        private System.Windows.Forms.ToolStripButton btnAddGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnUpdateGroup;
        private System.Windows.Forms.ToolStripButton btnRemoveGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnReloadGroup;
        private CommonControls.Custom.TitleLabel lblLeftAreaTitle;
        private System.Windows.Forms.DateTimePicker dtpApplyTimeTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.DateTimePicker dtpApplyTimeFrom;
        private System.Windows.Forms.CheckBox cbxFilterByApplyTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Blank;

    }
}
