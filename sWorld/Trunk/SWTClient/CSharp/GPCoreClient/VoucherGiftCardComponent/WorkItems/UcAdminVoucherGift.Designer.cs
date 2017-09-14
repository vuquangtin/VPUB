namespace VoucherGiftCardComponent.WorkItems
{
    partial class UcAdminVoucherGift
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcAdminVoucherGift));
            this.mniUpdateGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvSynsVoucherGift = new CommonControls.Custom.CommonDataGridView();
            this.tssAfterPersoButton = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.lblRightAreaTitle = new CommonControls.Custom.TitleLabel();
            this.cmsUserTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mniExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mniReloadUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.mniRemoveGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTrvRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblLeftAreaTitle = new CommonControls.Custom.TitleLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkAutoCloseNode = new System.Windows.Forms.CheckBox();
            this.trvGiftVoucher = new System.Windows.Forms.TreeView();
            this.cmsTrvTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniReloadOrgs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTrv = new CommonControls.Custom.CommonToolStrip();
            this.btnReloadTrv = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescribtion = new System.Windows.Forms.Label();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.txtDateEnd = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDateBegin = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtTypeCard = new System.Windows.Forms.TextBox();
            this.lblDateBegin = new System.Windows.Forms.Label();
            this.lblDateEnd = new System.Windows.Forms.Label();
            this.lblMemberLocation = new System.Windows.Forms.Label();
            this.lblMemberVoucherGift = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmsRule = new CommonControls.Custom.CommonToolStrip();
            this.btnRemoveCard = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSyncData = new System.Windows.Forms.ToolStripButton();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQrCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSynsVoucherGift)).BeginInit();
            this.cmsUserTable.SuspendLayout();
            this.cmsTrvRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.cmsTrvTree.SuspendLayout();
            this.tsmTrv.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlFilterBox.SuspendLayout();
            this.tmsRule.SuspendLayout();
            this.SuspendLayout();
            // 
            // mniUpdateGroup
            // 
            this.mniUpdateGroup.Name = "mniUpdateGroup";
            this.mniUpdateGroup.Size = new System.Drawing.Size(170, 22);
            this.mniUpdateGroup.Text = "Cập Nhật Nhóm...";
            // 
            // dgvSynsVoucherGift
            // 
            this.dgvSynsVoucherGift.AllowUserToAddRows = false;
            this.dgvSynsVoucherGift.AllowUserToDeleteRows = false;
            this.dgvSynsVoucherGift.AllowUserToOrderColumns = true;
            this.dgvSynsVoucherGift.AllowUserToResizeRows = false;
            this.dgvSynsVoucherGift.BackgroundColor = System.Drawing.Color.White;
            this.dgvSynsVoucherGift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSynsVoucherGift.ColumnHeadersHeight = 26;
            this.dgvSynsVoucherGift.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colLastName,
            this.colFirstName,
            this.colTelephone,
            this.colQrCode,
            this.colBarCode,
            this.colSerial,
            this.colBlank});
            this.dgvSynsVoucherGift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSynsVoucherGift.Location = new System.Drawing.Point(0, 143);
            this.dgvSynsVoucherGift.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSynsVoucherGift.MultiSelect = false;
            this.dgvSynsVoucherGift.Name = "dgvSynsVoucherGift";
            this.dgvSynsVoucherGift.ReadOnly = true;
            this.dgvSynsVoucherGift.RowHeadersVisible = false;
            this.dgvSynsVoucherGift.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSynsVoucherGift.Size = new System.Drawing.Size(697, 328);
            this.dgvSynsVoucherGift.TabIndex = 46;
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
            // btnReload
            // 
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(23, 22);
            this.btnReload.Text = "Tải Dữ Liệu";
            this.btnReload.ToolTipText = "Tải danh sách thành viên theo cấu hình phiếu";
            // 
            // lblRightAreaTitle
            // 
            this.lblRightAreaTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitle.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblRightAreaTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitle.Location = new System.Drawing.Point(0, 0);
            this.lblRightAreaTitle.Name = "lblRightAreaTitle";
            this.lblRightAreaTitle.Size = new System.Drawing.Size(711, 32);
            this.lblRightAreaTitle.TabIndex = 34;
            this.lblRightAreaTitle.Text = "DANH SÁCH THÀNH VIÊN LỌC THEO CẤU HÌNH PHIẾU";
            this.lblRightAreaTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.mniReloadUsers.Name = "mniReloadUsers";
            this.mniReloadUsers.Size = new System.Drawing.Size(194, 22);
            this.mniReloadUsers.Text = "Tải Dữ Liệu";
            // 
            // mniRemoveGroups
            // 
            this.mniRemoveGroups.Name = "mniRemoveGroups";
            this.mniRemoveGroups.Size = new System.Drawing.Size(170, 22);
            this.mniRemoveGroups.Text = "Hủy Nhóm...";
            // 
            // cmsTrvRecord
            // 
            this.cmsTrvRecord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniUpdateGroup,
            this.mniRemoveGroups});
            this.cmsTrvRecord.Name = "cmsGroup";
            this.cmsTrvRecord.Size = new System.Drawing.Size(171, 48);
            // 
            // lblLeftAreaTitle
            // 
            this.lblLeftAreaTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblLeftAreaTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftAreaTitle.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblLeftAreaTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLeftAreaTitle.Location = new System.Drawing.Point(0, 0);
            this.lblLeftAreaTitle.Name = "lblLeftAreaTitle";
            this.lblLeftAreaTitle.Size = new System.Drawing.Size(241, 32);
            this.lblLeftAreaTitle.TabIndex = 2;
            this.lblLeftAreaTitle.Text = "DANH SÁCH CẤU HÌNH PHIẾU";
            this.lblLeftAreaTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.splitContainer.Panel2.Controls.Add(this.lblRightAreaTitle);
            this.splitContainer.Size = new System.Drawing.Size(962, 537);
            this.splitContainer.SplitterDistance = 243;
            this.splitContainer.SplitterWidth = 6;
            this.splitContainer.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 32);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel3.Size = new System.Drawing.Size(241, 503);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.chkAutoCloseNode);
            this.panel4.Controls.Add(this.trvGiftVoucher);
            this.panel4.Controls.Add(this.tsmTrv);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(6, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(229, 493);
            this.panel4.TabIndex = 57;
            // 
            // chkAutoCloseNode
            // 
            this.chkAutoCloseNode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chkAutoCloseNode.Location = new System.Drawing.Point(0, 469);
            this.chkAutoCloseNode.Name = "chkAutoCloseNode";
            this.chkAutoCloseNode.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.chkAutoCloseNode.Size = new System.Drawing.Size(227, 22);
            this.chkAutoCloseNode.TabIndex = 58;
            this.chkAutoCloseNode.Text = "Tự động rút gọn danh sách";
            this.chkAutoCloseNode.UseVisualStyleBackColor = true;
            // 
            // trvGiftVoucher
            // 
            this.trvGiftVoucher.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvGiftVoucher.ContextMenuStrip = this.cmsTrvTree;
            this.trvGiftVoucher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvGiftVoucher.Location = new System.Drawing.Point(0, 25);
            this.trvGiftVoucher.Name = "trvGiftVoucher";
            this.trvGiftVoucher.Size = new System.Drawing.Size(227, 466);
            this.trvGiftVoucher.TabIndex = 57;
            // 
            // cmsTrvTree
            // 
            this.cmsTrvTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniReloadOrgs});
            this.cmsTrvTree.Name = "contextMenuStrip1";
            this.cmsTrvTree.Size = new System.Drawing.Size(134, 26);
            // 
            // mniReloadOrgs
            // 
            this.mniReloadOrgs.Name = "mniReloadOrgs";
            this.mniReloadOrgs.Size = new System.Drawing.Size(133, 22);
            this.mniReloadOrgs.Text = "Tải Dữ Liệu";
            // 
            // tsmTrv
            // 
            this.tsmTrv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReloadTrv});
            this.tsmTrv.Location = new System.Drawing.Point(0, 0);
            this.tsmTrv.Name = "tsmTrv";
            this.tsmTrv.Size = new System.Drawing.Size(227, 25);
            this.tsmTrv.TabIndex = 56;
            this.tsmTrv.Text = "tlstripListGroup";
            // 
            // btnReloadTrv
            // 
            this.btnReloadTrv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadTrv.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadTrv.Image")));
            this.btnReloadTrv.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadTrv.Name = "btnReloadTrv";
            this.btnReloadTrv.Size = new System.Drawing.Size(23, 22);
            this.btnReloadTrv.Text = "Tải Dữ Liệu";
            this.btnReloadTrv.ToolTipText = "Tải danh sách phiếu";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.panel1.Size = new System.Drawing.Size(711, 503);
            this.panel1.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvSynsVoucherGift);
            this.panel2.Controls.Add(this.pnlFilterBox);
            this.panel2.Controls.Add(this.tmsRule);
            this.panel2.Controls.Add(this.pagerPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(699, 495);
            this.panel2.TabIndex = 38;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.Controls.Add(this.txtDescription);
            this.pnlFilterBox.Controls.Add(this.lblDescribtion);
            this.pnlFilterBox.Controls.Add(this.txtGender);
            this.pnlFilterBox.Controls.Add(this.txtDateEnd);
            this.pnlFilterBox.Controls.Add(this.txtTitle);
            this.pnlFilterBox.Controls.Add(this.txtDateBegin);
            this.pnlFilterBox.Controls.Add(this.txtLocation);
            this.pnlFilterBox.Controls.Add(this.txtTypeCard);
            this.pnlFilterBox.Controls.Add(this.lblDateBegin);
            this.pnlFilterBox.Controls.Add(this.lblDateEnd);
            this.pnlFilterBox.Controls.Add(this.lblMemberLocation);
            this.pnlFilterBox.Controls.Add(this.lblMemberVoucherGift);
            this.pnlFilterBox.Controls.Add(this.lblGender);
            this.pnlFilterBox.Controls.Add(this.label3);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlFilterBox.Size = new System.Drawing.Size(697, 118);
            this.pnlFilterBox.TabIndex = 45;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(101, 90);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(486, 19);
            this.txtDescription.TabIndex = 187;
            // 
            // lblDescribtion
            // 
            this.lblDescribtion.AutoSize = true;
            this.lblDescribtion.Location = new System.Drawing.Point(10, 93);
            this.lblDescribtion.Name = "lblDescribtion";
            this.lblDescribtion.Size = new System.Drawing.Size(40, 16);
            this.lblDescribtion.TabIndex = 186;
            this.lblDescribtion.Text = "Mô tả";
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(407, 33);
            this.txtGender.Name = "txtGender";
            this.txtGender.ReadOnly = true;
            this.txtGender.Size = new System.Drawing.Size(180, 22);
            this.txtGender.TabIndex = 185;
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.Location = new System.Drawing.Point(407, 62);
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.ReadOnly = true;
            this.txtDateEnd.Size = new System.Drawing.Size(180, 22);
            this.txtDateEnd.TabIndex = 184;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(407, 5);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(180, 22);
            this.txtTitle.TabIndex = 183;
            // 
            // txtDateBegin
            // 
            this.txtDateBegin.Location = new System.Drawing.Point(101, 61);
            this.txtDateBegin.Name = "txtDateBegin";
            this.txtDateBegin.ReadOnly = true;
            this.txtDateBegin.Size = new System.Drawing.Size(180, 22);
            this.txtDateBegin.TabIndex = 182;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(101, 33);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(180, 22);
            this.txtLocation.TabIndex = 181;
            // 
            // txtTypeCard
            // 
            this.txtTypeCard.Location = new System.Drawing.Point(101, 5);
            this.txtTypeCard.Name = "txtTypeCard";
            this.txtTypeCard.ReadOnly = true;
            this.txtTypeCard.Size = new System.Drawing.Size(180, 22);
            this.txtTypeCard.TabIndex = 180;
            // 
            // lblDateBegin
            // 
            this.lblDateBegin.AutoSize = true;
            this.lblDateBegin.Location = new System.Drawing.Point(10, 67);
            this.lblDateBegin.Name = "lblDateBegin";
            this.lblDateBegin.Size = new System.Drawing.Size(83, 16);
            this.lblDateBegin.TabIndex = 174;
            this.lblDateBegin.Text = "Ngày bắt đầu";
            // 
            // lblDateEnd
            // 
            this.lblDateEnd.AutoSize = true;
            this.lblDateEnd.Location = new System.Drawing.Point(316, 67);
            this.lblDateEnd.Name = "lblDateEnd";
            this.lblDateEnd.Size = new System.Drawing.Size(85, 16);
            this.lblDateEnd.TabIndex = 175;
            this.lblDateEnd.Text = "Ngày kết thúc";
            // 
            // lblMemberLocation
            // 
            this.lblMemberLocation.AutoSize = true;
            this.lblMemberLocation.Location = new System.Drawing.Point(10, 39);
            this.lblMemberLocation.Name = "lblMemberLocation";
            this.lblMemberLocation.Size = new System.Drawing.Size(64, 16);
            this.lblMemberLocation.TabIndex = 173;
            this.lblMemberLocation.Text = "Địa điểm:";
            // 
            // lblMemberVoucherGift
            // 
            this.lblMemberVoucherGift.AutoSize = true;
            this.lblMemberVoucherGift.Location = new System.Drawing.Point(10, 11);
            this.lblMemberVoucherGift.Name = "lblMemberVoucherGift";
            this.lblMemberVoucherGift.Size = new System.Drawing.Size(71, 16);
            this.lblMemberVoucherGift.TabIndex = 172;
            this.lblMemberVoucherGift.Text = "Loại phiếu:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(316, 39);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(59, 16);
            this.lblGender.TabIndex = 171;
            this.lblGender.Text = "Giới tính:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 168;
            this.label3.Text = "Tiêu đề:";
            // 
            // tmsRule
            // 
            this.tmsRule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRemoveCard,
            this.toolStripSeparator1,
            this.btnSyncData,
            this.tssAfterPersoButton,
            this.btnShowHide,
            this.btnReload});
            this.tmsRule.Location = new System.Drawing.Point(0, 0);
            this.tmsRule.Name = "tmsRule";
            this.tmsRule.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.tmsRule.Size = new System.Drawing.Size(697, 25);
            this.tmsRule.TabIndex = 44;
            this.tmsRule.Text = "toolStrip1";
            // 
            // btnRemoveCard
            // 
            this.btnRemoveCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveCard.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveCard.Image")));
            this.btnRemoveCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveCard.Name = "btnRemoveCard";
            this.btnRemoveCard.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveCard.Text = "Hủy Những Card Này Khỏi Cấu Hình Phiếu...";
            this.btnRemoveCard.ToolTipText = "Hủy những Card này khỏi cấu hình phiếu";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSyncData
            // 
            this.btnSyncData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSyncData.Image = ((System.Drawing.Image)(resources.GetObject("btnSyncData.Image")));
            this.btnSyncData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSyncData.Name = "btnSyncData";
            this.btnSyncData.Size = new System.Drawing.Size(23, 22);
            this.btnSyncData.Text = "Lưu thông tin thành viên được lọc theo cấu hình phiếu...";
            this.btnSyncData.ToolTipText = "Lưu thông tin thành viên được lọc theo cấu hình phiếu vào hệ thống";
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 471);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(697, 22);
            this.pagerPanel1.TabIndex = 40;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colLastName
            // 
            this.colLastName.DataPropertyName = "LastName";
            this.colLastName.HeaderText = "Họ tên đệm";
            this.colLastName.Name = "colLastName";
            this.colLastName.ReadOnly = true;
            this.colLastName.Width = 250;
            // 
            // colFirstName
            // 
            this.colFirstName.DataPropertyName = "FirstName";
            this.colFirstName.HeaderText = "Tên";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.ReadOnly = true;
            // 
            // colTelephone
            // 
            this.colTelephone.DataPropertyName = "Telephone";
            this.colTelephone.HeaderText = "Số điện thoại";
            this.colTelephone.Name = "colTelephone";
            this.colTelephone.ReadOnly = true;
            // 
            // colQrCode
            // 
            this.colQrCode.DataPropertyName = "QrCode";
            this.colQrCode.HeaderText = "QR Code";
            this.colQrCode.Name = "colQrCode";
            this.colQrCode.ReadOnly = true;
            // 
            // colBarCode
            // 
            this.colBarCode.DataPropertyName = "BarCode";
            this.colBarCode.HeaderText = "Bar Code";
            this.colBarCode.Name = "colBarCode";
            this.colBarCode.ReadOnly = true;
            // 
            // colSerial
            // 
            this.colSerial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSerial.DataPropertyName = "Serial";
            this.colSerial.HeaderText = "Serial";
            this.colSerial.Name = "colSerial";
            this.colSerial.ReadOnly = true;
            // 
            // colBlank
            // 
            this.colBlank.HeaderText = "colBlank";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            this.colBlank.Visible = false;
            this.colBlank.Width = 5;
            // 
            // UcAdminVoucherGift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "UcAdminVoucherGift";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Size = new System.Drawing.Size(974, 547);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSynsVoucherGift)).EndInit();
            this.cmsUserTable.ResumeLayout(false);
            this.cmsTrvRecord.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.cmsTrvTree.ResumeLayout(false);
            this.tsmTrv.ResumeLayout(false);
            this.tsmTrv.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.tmsRule.ResumeLayout(false);
            this.tmsRule.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mniUpdateGroup;
        private CommonControls.Custom.CommonDataGridView dgvSynsVoucherGift;
        private System.Windows.Forms.ToolStripSeparator tssAfterPersoButton;
        private System.Windows.Forms.ToolStripButton btnShowHide;
        private System.Windows.Forms.ToolStripButton btnReload;
        private CommonControls.Custom.TitleLabel lblRightAreaTitle;
        private System.Windows.Forms.ContextMenuStrip cmsUserTable;
        private System.Windows.Forms.ToolStripMenuItem mniAddUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mniExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem mniReloadUsers;
        private System.Windows.Forms.ToolStripMenuItem mniRemoveGroups;
        private System.Windows.Forms.ContextMenuStrip cmsTrvRecord;
        private CommonControls.Custom.TitleLabel lblLeftAreaTitle;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chkAutoCloseNode;
        private System.Windows.Forms.TreeView trvGiftVoucher;
        private System.Windows.Forms.ContextMenuStrip cmsTrvTree;
        private System.Windows.Forms.ToolStripMenuItem mniReloadOrgs;
        private CommonControls.Custom.CommonToolStrip tsmTrv;
        private System.Windows.Forms.ToolStripButton btnReloadTrv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CommonControls.Custom.CommonToolStrip tmsRule;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.ToolStripButton btnSyncData;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.TextBox txtDateEnd;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDateBegin;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtTypeCard;
        private System.Windows.Forms.Label lblDateBegin;
        private System.Windows.Forms.Label lblDateEnd;
        private System.Windows.Forms.Label lblMemberLocation;
        private System.Windows.Forms.Label lblMemberVoucherGift;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescribtion;
        private System.Windows.Forms.ToolStripButton btnRemoveCard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQrCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
    }
}
