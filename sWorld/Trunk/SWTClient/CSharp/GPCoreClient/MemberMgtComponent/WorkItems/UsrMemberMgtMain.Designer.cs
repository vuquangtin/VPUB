namespace MemberMgtComponent.WorkItems
{
    partial class UsrMemberMgtMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrMemberMgtMain));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trvOrganizations = new System.Windows.Forms.TreeView();
            this.tmsOrganization = new CommonControls.Custom.CommonToolStrip();
            this.btnReloadOrgs = new System.Windows.Forms.ToolStripButton();
            this.plHideShowOrg = new System.Windows.Forms.Panel();
            this.cmbPartnerInfo = new System.Windows.Forms.ComboBox();
            this.lblPartnerKey = new System.Windows.Forms.Label();
            this.chkAutoCloseNode = new System.Windows.Forms.CheckBox();
            this.lblLeftAreaTitleforListPartner = new CommonControls.Custom.TitleLabel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pnlRightMain = new System.Windows.Forms.Panel();
            this.dgvMembers = new CommonControls.Custom.CommonDataGridView();
            this.pagerPanel = new CommonControls.Custom.PagerPanel();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.cmsMemberTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniSyncData = new System.Windows.Forms.ToolStripMenuItem();
            this.tssBelowSyncDataMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.mniExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mniReloadMembers = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDegreeCode = new System.Windows.Forms.TextBox();
            this.cbxFilterByDegree = new System.Windows.Forms.CheckBox();
            this.lblNotification2 = new System.Windows.Forms.Label();
            this.lblNotification1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbtnNotWorking = new System.Windows.Forms.RadioButton();
            this.rbtnWorkingAbroad = new System.Windows.Forms.RadioButton();
            this.rbtnWorking = new System.Windows.Forms.RadioButton();
            this.cbxFilterByPersoStatusMember = new System.Windows.Forms.CheckBox();
            this.tbxMemberCode = new System.Windows.Forms.TextBox();
            this.cbxFilterByMemberCode = new System.Windows.Forms.CheckBox();
            this.tbxMemberName = new System.Windows.Forms.TextBox();
            this.cbxFilterByMemberName = new System.Windows.Forms.CheckBox();
            this.cbxFilterByWorkingStatus = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbtnPerso = new System.Windows.Forms.RadioButton();
            this.rbtnNotPerso = new System.Windows.Forms.RadioButton();
            this.tmsMember = new CommonControls.Custom.CommonToolStrip();
            this.btnPersoCard = new System.Windows.Forms.ToolStripButton();
            this.tssAfterPersoButton = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.btnSyncData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnReloadMembers = new System.Windows.Forms.ToolStripButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblRightAreaTitleforListMember = new CommonControls.Custom.TitleLabel();
            this.cmsOrgTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniReloadOrgs = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMemberRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniPersoCard = new System.Windows.Forms.ToolStripMenuItem();
            this.colMemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDegree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhoneNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPermanentAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTemporaryAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersoStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tmsOrganization.SuspendLayout();
            this.plHideShowOrg.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnlRightMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.cmsMemberTable.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tmsMember.SuspendLayout();
            this.cmsOrgTree.SuspendLayout();
            this.cmsMemberRecord.SuspendLayout();
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
            this.panel1.Controls.Add(this.chkAutoCloseNode);
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
            this.panel2.Controls.Add(this.plHideShowOrg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 528);
            this.panel2.TabIndex = 53;
            // 
            // trvOrganizations
            // 
            this.trvOrganizations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvOrganizations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvOrganizations.Location = new System.Drawing.Point(0, 80);
            this.trvOrganizations.Name = "trvOrganizations";
            this.trvOrganizations.Size = new System.Drawing.Size(200, 446);
            this.trvOrganizations.TabIndex = 60;
            // 
            // tmsOrganization
            // 
            this.tmsOrganization.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReloadOrgs});
            this.tmsOrganization.Location = new System.Drawing.Point(0, 55);
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
            // plHideShowOrg
            // 
            this.plHideShowOrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plHideShowOrg.Controls.Add(this.cmbPartnerInfo);
            this.plHideShowOrg.Controls.Add(this.lblPartnerKey);
            this.plHideShowOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.plHideShowOrg.Location = new System.Drawing.Point(0, 0);
            this.plHideShowOrg.Name = "plHideShowOrg";
            this.plHideShowOrg.Size = new System.Drawing.Size(200, 55);
            this.plHideShowOrg.TabIndex = 58;
            // 
            // cmbPartnerInfo
            // 
            this.cmbPartnerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPartnerInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPartnerInfo.FormattingEnabled = true;
            this.cmbPartnerInfo.Location = new System.Drawing.Point(8, 23);
            this.cmbPartnerInfo.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbPartnerInfo.Name = "cmbPartnerInfo";
            this.cmbPartnerInfo.Size = new System.Drawing.Size(185, 22);
            this.cmbPartnerInfo.TabIndex = 4;
            // 
            // lblPartnerKey
            // 
            this.lblPartnerKey.AutoSize = true;
            this.lblPartnerKey.Location = new System.Drawing.Point(5, 5);
            this.lblPartnerKey.Margin = new System.Windows.Forms.Padding(5);
            this.lblPartnerKey.Name = "lblPartnerKey";
            this.lblPartnerKey.Size = new System.Drawing.Size(120, 16);
            this.lblPartnerKey.TabIndex = 2;
            this.lblPartnerKey.Text = "Tổ chức phát hành:";
            // 
            // chkAutoCloseNode
            // 
            this.chkAutoCloseNode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chkAutoCloseNode.Location = new System.Drawing.Point(5, 533);
            this.chkAutoCloseNode.Name = "chkAutoCloseNode";
            this.chkAutoCloseNode.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.chkAutoCloseNode.Size = new System.Drawing.Size(202, 20);
            this.chkAutoCloseNode.TabIndex = 52;
            this.chkAutoCloseNode.Text = "Tự động rút gọn danh sách";
            this.chkAutoCloseNode.UseVisualStyleBackColor = true;
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
            this.lblLeftAreaTitleforListPartner.Text = "DANH SÁCH TỔ CHỨC";
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
            this.pnlRightMain.Controls.Add(this.dgvMembers);
            this.pnlRightMain.Controls.Add(this.pagerPanel);
            this.pnlRightMain.Controls.Add(this.pnlFilterBox);
            this.pnlRightMain.Controls.Add(this.tmsMember);
            this.pnlRightMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightMain.Location = new System.Drawing.Point(5, 0);
            this.pnlRightMain.Name = "pnlRightMain";
            this.pnlRightMain.Size = new System.Drawing.Size(559, 550);
            this.pnlRightMain.TabIndex = 14;
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
            this.colMemberId,
            this.colMemberCode,
            this.colTitle,
            this.colLastName,
            this.colFirstName,
            this.colBirthDate,
            this.colDegree,
            this.colPosition,
            this.colPhoneNo,
            this.colEmail,
            this.colPermanentAddress,
            this.colTemporaryAddress,
            this.colActive,
            this.colPersoStatus});
            this.dgvMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMembers.Location = new System.Drawing.Point(0, 113);
            this.dgvMembers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.RowHeadersVisible = false;
            this.dgvMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.Size = new System.Drawing.Size(557, 415);
            this.dgvMembers.TabIndex = 32;
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
            this.pnlFilterBox.Controls.Add(this.txtDegreeCode);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByDegree);
            this.pnlFilterBox.Controls.Add(this.lblNotification2);
            this.pnlFilterBox.Controls.Add(this.lblNotification1);
            this.pnlFilterBox.Controls.Add(this.panel3);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByPersoStatusMember);
            this.pnlFilterBox.Controls.Add(this.tbxMemberCode);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByMemberCode);
            this.pnlFilterBox.Controls.Add(this.tbxMemberName);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByMemberName);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByWorkingStatus);
            this.pnlFilterBox.Controls.Add(this.panel4);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(557, 88);
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
            this.mniExportToExcel.Text = "Xuất Ra Excel...";
            this.mniExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // mniReloadMembers
            // 
            this.mniReloadMembers.Image = ((System.Drawing.Image)(resources.GetObject("mniReloadMembers.Image")));
            this.mniReloadMembers.Name = "mniReloadMembers";
            this.mniReloadMembers.Size = new System.Drawing.Size(175, 22);
            this.mniReloadMembers.Text = "Tải Dữ Liệu";
            // 
            // txtDegreeCode
            // 
            this.txtDegreeCode.Enabled = false;
            this.txtDegreeCode.Location = new System.Drawing.Point(214, 120);
            this.txtDegreeCode.Name = "txtDegreeCode";
            this.txtDegreeCode.Size = new System.Drawing.Size(150, 22);
            this.txtDegreeCode.TabIndex = 44;
            // 
            // cbxFilterByDegree
            // 
            this.cbxFilterByDegree.Location = new System.Drawing.Point(8, 120);
            this.cbxFilterByDegree.Name = "cbxFilterByDegree";
            this.cbxFilterByDegree.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByDegree.TabIndex = 43;
            this.cbxFilterByDegree.Text = "Lọc theo trình độ:";
            this.cbxFilterByDegree.UseVisualStyleBackColor = true;
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
            // panel3
            // 
            this.panel3.Controls.Add(this.rbtnNotWorking);
            this.panel3.Controls.Add(this.rbtnWorkingAbroad);
            this.panel3.Controls.Add(this.rbtnWorking);
            this.panel3.Location = new System.Drawing.Point(214, 92);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 22);
            this.panel3.TabIndex = 39;
            // 
            // rbtnNotWorking
            // 
            this.rbtnNotWorking.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnNotWorking.Enabled = false;
            this.rbtnNotWorking.Location = new System.Drawing.Point(250, 0);
            this.rbtnNotWorking.Name = "rbtnNotWorking";
            this.rbtnNotWorking.Size = new System.Drawing.Size(100, 22);
            this.rbtnNotWorking.TabIndex = 6;
            this.rbtnNotWorking.Text = "Đã Nghỉ";
            this.rbtnNotWorking.UseVisualStyleBackColor = true;
            // 
            // rbtnWorkingAbroad
            // 
            this.rbtnWorkingAbroad.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnWorkingAbroad.Enabled = false;
            this.rbtnWorkingAbroad.Location = new System.Drawing.Point(125, 0);
            this.rbtnWorkingAbroad.Name = "rbtnWorkingAbroad";
            this.rbtnWorkingAbroad.Size = new System.Drawing.Size(125, 22);
            this.rbtnWorkingAbroad.TabIndex = 5;
            this.rbtnWorkingAbroad.Text = "Đi Nước Ngoài";
            this.rbtnWorkingAbroad.UseVisualStyleBackColor = true;
            // 
            // rbtnWorking
            // 
            this.rbtnWorking.Checked = true;
            this.rbtnWorking.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnWorking.Enabled = false;
            this.rbtnWorking.Location = new System.Drawing.Point(0, 0);
            this.rbtnWorking.Name = "rbtnWorking";
            this.rbtnWorking.Size = new System.Drawing.Size(125, 22);
            this.rbtnWorking.TabIndex = 4;
            this.rbtnWorking.TabStop = true;
            this.rbtnWorking.Text = "Đang Công Tác";
            this.rbtnWorking.UseVisualStyleBackColor = true;
            // 
            // cbxFilterByPersoStatusMember
            // 
            this.cbxFilterByPersoStatusMember.Location = new System.Drawing.Point(8, 64);
            this.cbxFilterByPersoStatusMember.Name = "cbxFilterByPersoStatusMember";
            this.cbxFilterByPersoStatusMember.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByPersoStatusMember.TabIndex = 36;
            this.cbxFilterByPersoStatusMember.Text = "Lọc theo trạng thái phát hành:";
            this.cbxFilterByPersoStatusMember.UseVisualStyleBackColor = true;
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
            this.cbxFilterByMemberCode.Text = "Lọc theo mã thành viên:";
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
            this.cbxFilterByMemberName.Text = "Lọc theo tên thành viên:";
            this.cbxFilterByMemberName.UseVisualStyleBackColor = true;
            // 
            // cbxFilterByWorkingStatus
            // 
            this.cbxFilterByWorkingStatus.Location = new System.Drawing.Point(8, 92);
            this.cbxFilterByWorkingStatus.Name = "cbxFilterByWorkingStatus";
            this.cbxFilterByWorkingStatus.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByWorkingStatus.TabIndex = 38;
            this.cbxFilterByWorkingStatus.Text = "Lọc theo tình trạng công tác:";
            this.cbxFilterByWorkingStatus.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rbtnPerso);
            this.panel4.Controls.Add(this.rbtnNotPerso);
            this.panel4.Location = new System.Drawing.Point(214, 64);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(250, 22);
            this.panel4.TabIndex = 37;
            // 
            // rbtnPerso
            // 
            this.rbtnPerso.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnPerso.Enabled = false;
            this.rbtnPerso.Location = new System.Drawing.Point(125, 0);
            this.rbtnPerso.Name = "rbtnPerso";
            this.rbtnPerso.Size = new System.Drawing.Size(125, 22);
            this.rbtnPerso.TabIndex = 2;
            this.rbtnPerso.Text = "Đã phát hành";
            this.rbtnPerso.UseVisualStyleBackColor = true;
            // 
            // rbtnNotPerso
            // 
            this.rbtnNotPerso.Checked = true;
            this.rbtnNotPerso.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnNotPerso.Enabled = false;
            this.rbtnNotPerso.Location = new System.Drawing.Point(0, 0);
            this.rbtnNotPerso.Name = "rbtnNotPerso";
            this.rbtnNotPerso.Size = new System.Drawing.Size(125, 22);
            this.rbtnNotPerso.TabIndex = 1;
            this.rbtnNotPerso.TabStop = true;
            this.rbtnNotPerso.Text = "Chưa phát hành";
            this.rbtnNotPerso.UseVisualStyleBackColor = true;
            // 
            // tmsMember
            // 
            this.tmsMember.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPersoCard,
            this.tssAfterPersoButton,
            this.btnShowHide,
            this.btnSyncData,
            this.toolStripSeparator2,
            this.btnExportToExcel,
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
            // btnSyncData
            // 
            this.btnSyncData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSyncData.Image = ((System.Drawing.Image)(resources.GetObject("btnSyncData.Image")));
            this.btnSyncData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSyncData.Name = "btnSyncData";
            this.btnSyncData.Size = new System.Drawing.Size(23, 22);
            this.btnSyncData.Text = "Tích Hợp Dữ Liệu...";
            this.btnSyncData.ToolTipText = "Tích hợp dữ liệu thành viên vào hệ thống";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportToExcel.Image = global::MemberMgtComponent.Properties.Resources.Excel_16x16;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExportToExcel.Text = "Xuất Ra Excel...";
            this.btnExportToExcel.ToolTipText = "Xuất dữ liệu đang hiển thị ra tập tin excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
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
            this.lblRightAreaTitleforListMember.Text = "DANH SÁCH THÀNH VIÊN";
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
            // colMemberId
            // 
            this.colMemberId.DataPropertyName = "MemberId";
            this.colMemberId.HeaderText = "MemberId";
            this.colMemberId.Name = "colMemberId";
            this.colMemberId.ReadOnly = true;
            this.colMemberId.Visible = false;
            // 
            // colMemberCode
            // 
            this.colMemberCode.DataPropertyName = "MemberCode";
            this.colMemberCode.HeaderText = "Mã TV";
            this.colMemberCode.Name = "colMemberCode";
            this.colMemberCode.ReadOnly = true;
            // 
            // colTitle
            // 
            this.colTitle.DataPropertyName = "Title";
            this.colTitle.HeaderText = "Chức Danh";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.Visible = false;
            // 
            // colLastName
            // 
            this.colLastName.DataPropertyName = "LastName";
            this.colLastName.HeaderText = "Họ";
            this.colLastName.Name = "colLastName";
            this.colLastName.ReadOnly = true;
            this.colLastName.Width = 150;
            // 
            // colFirstName
            // 
            this.colFirstName.DataPropertyName = "FirstName";
            this.colFirstName.HeaderText = "Tên";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.ReadOnly = true;
            // 
            // colBirthDate
            // 
            this.colBirthDate.DataPropertyName = "BirthDate";
            this.colBirthDate.HeaderText = "Ngày Sinh";
            this.colBirthDate.Name = "colBirthDate";
            this.colBirthDate.ReadOnly = true;
            // 
            // colDegree
            // 
            this.colDegree.DataPropertyName = "Degree";
            this.colDegree.HeaderText = "Trình Độ";
            this.colDegree.Name = "colDegree";
            this.colDegree.ReadOnly = true;
            // 
            // colPosition
            // 
            this.colPosition.DataPropertyName = "Position";
            this.colPosition.HeaderText = "Chức Vụ";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            // 
            // colPhoneNo
            // 
            this.colPhoneNo.DataPropertyName = "PhoneNo";
            this.colPhoneNo.HeaderText = "Số Điện Thoại";
            this.colPhoneNo.Name = "colPhoneNo";
            this.colPhoneNo.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Width = 150;
            // 
            // colPermanentAddress
            // 
            this.colPermanentAddress.DataPropertyName = "PermanentAddress";
            this.colPermanentAddress.HeaderText = "Địa Chỉ Thường Trú";
            this.colPermanentAddress.Name = "colPermanentAddress";
            this.colPermanentAddress.ReadOnly = true;
            this.colPermanentAddress.Width = 250;
            // 
            // colTemporaryAddress
            // 
            this.colTemporaryAddress.DataPropertyName = "TemporaryAddress";
            this.colTemporaryAddress.HeaderText = "Địa Chỉ Tạm Trú";
            this.colTemporaryAddress.Name = "colTemporaryAddress";
            this.colTemporaryAddress.ReadOnly = true;
            this.colTemporaryAddress.Width = 250;
            // 
            // colActive
            // 
            this.colActive.DataPropertyName = "Active";
            this.colActive.HeaderText = "Đã Nghỉ";
            this.colActive.Name = "colActive";
            this.colActive.ReadOnly = true;
            this.colActive.Width = 125;
            // 
            // colPersoStatus
            // 
            this.colPersoStatus.DataPropertyName = "PersoStatus";
            this.colPersoStatus.HeaderText = "TT Phát Hành";
            this.colPersoStatus.Name = "colPersoStatus";
            this.colPersoStatus.ReadOnly = true;
            this.colPersoStatus.Width = 125;
            // 
            // UsrMemberMgtMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "UsrMemberMgtMain";
            this.Size = new System.Drawing.Size(800, 600);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tmsOrganization.ResumeLayout(false);
            this.tmsOrganization.PerformLayout();
            this.plHideShowOrg.ResumeLayout(false);
            this.plHideShowOrg.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.pnlRightMain.ResumeLayout(false);
            this.pnlRightMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.cmsMemberTable.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tmsMember.ResumeLayout(false);
            this.tmsMember.PerformLayout();
            this.cmsOrgTree.ResumeLayout(false);
            this.cmsMemberRecord.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton btnSyncData;
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
        private System.Windows.Forms.Label lblNotification2;
        private System.Windows.Forms.Label lblNotification1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox cbxFilterByPersoStatusMember;
        private System.Windows.Forms.TextBox tbxMemberCode;
        private System.Windows.Forms.CheckBox cbxFilterByMemberCode;
        private System.Windows.Forms.TextBox tbxMemberName;
        private System.Windows.Forms.CheckBox cbxFilterByMemberName;
        private System.Windows.Forms.CheckBox cbxFilterByWorkingStatus;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbtnPerso;
        private System.Windows.Forms.RadioButton rbtnNotPerso;
        private System.Windows.Forms.RadioButton rbtnNotWorking;
        private System.Windows.Forms.RadioButton rbtnWorkingAbroad;
        private System.Windows.Forms.RadioButton rbtnWorking;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mniExportToExcel;
        private System.Windows.Forms.ToolStripButton btnPersoCard;
        private System.Windows.Forms.TextBox txtDegreeCode;
        private System.Windows.Forms.CheckBox cbxFilterByDegree;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView trvOrganizations;
        private CommonControls.Custom.CommonToolStrip tmsOrganization;
        private System.Windows.Forms.ToolStripButton btnReloadOrgs;
        private System.Windows.Forms.Panel plHideShowOrg;
        private System.Windows.Forms.ComboBox cmbPartnerInfo;
        private System.Windows.Forms.Label lblPartnerKey;
        private System.Windows.Forms.CheckBox chkAutoCloseNode;
        private CommonControls.Custom.CommonDataGridView dgvMembers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDegree;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoneNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPermanentAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTemporaryAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersoStatus;
    }
}
