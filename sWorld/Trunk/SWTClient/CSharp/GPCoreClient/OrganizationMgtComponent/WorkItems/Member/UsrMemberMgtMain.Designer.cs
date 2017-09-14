namespace SystemMgtComponent.WorkItems
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrMemberMgtMain));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeOrg = new SystemMgtComponent.WorkItems.TreeOrg();
            this.lblLeftAreaTitleforListOrg = new CommonControls.Custom.TitleLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvMembers = new CommonControls.Custom.CommonDataGridView();
            this.colMemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersoStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentityCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentityCardDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentityCardIssue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhoneNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPermanentAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTemporaryAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.line2 = new CommonControls.Custom.Line();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl2_FrmAddOrEditOrg_Name = new System.Windows.Forms.Label();
            this.txtCode = new CommonControls.Custom.CommonTextBox();
            this.txtPhone = new CommonControls.Custom.CommonTextBox();
            this.Phone = new System.Windows.Forms.Label();
            this.txtEmail = new CommonControls.Custom.CommonTextBox();
            this.lbl11_UsrOrganizationMgtMain = new System.Windows.Forms.Label();
            this.txtName = new CommonControls.Custom.CommonTextBox();
            this.lbl1_FrmAddOrEditOrg_Code = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.lbInfo_FrmAddOrEditOrg = new System.Windows.Forms.Label();
            this.lblNotification22 = new System.Windows.Forms.Label();
            this.lblentermorthan2letter = new System.Windows.Forms.Label();
            this.tbxMemberCode = new System.Windows.Forms.TextBox();
            this.cbxFilterByMemberCode = new System.Windows.Forms.CheckBox();
            this.tbxMemberName = new System.Windows.Forms.TextBox();
            this.cbxFilterByMemberName = new System.Windows.Forms.CheckBox();
            this.tmsMember = new CommonControls.Custom.CommonToolStrip();
            this.btnAddMember = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateMember = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveMember = new System.Windows.Forms.ToolStripButton();
            this.tssAfterPersoButton = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.btnSyncData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnReloadMembers = new System.Windows.Forms.ToolStripButton();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.lstMember = new CommonControls.Custom.TitleLabel();
            this.cmsOrgTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniReloadOrgs = new System.Windows.Forms.ToolStripMenuItem();
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
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tmsMember.SuspendLayout();
            this.cmsOrgTree.SuspendLayout();
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
            this.splitContainer.Panel1.Controls.Add(this.treeOrg);
            this.splitContainer.Panel1.Controls.Add(this.lblLeftAreaTitleforListOrg);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel1);
            this.splitContainer.Panel2.Controls.Add(this.lstMember);
            this.splitContainer.Size = new System.Drawing.Size(927, 590);
            this.splitContainer.SplitterDistance = 234;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 4;
            // 
            // treeOrg
            // 
            this.treeOrg.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.treeOrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeOrg.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.treeOrg.Location = new System.Drawing.Point(0, 30);
            this.treeOrg.Name = "treeOrg";
            this.treeOrg.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.treeOrg.Size = new System.Drawing.Size(232, 558);
            this.treeOrg.TabIndex = 3;
            // 
            // lblLeftAreaTitleforListOrg
            // 
            this.lblLeftAreaTitleforListOrg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblLeftAreaTitleforListOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftAreaTitleforListOrg.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblLeftAreaTitleforListOrg.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLeftAreaTitleforListOrg.Location = new System.Drawing.Point(0, 0);
            this.lblLeftAreaTitleforListOrg.Name = "lblLeftAreaTitleforListOrg";
            this.lblLeftAreaTitleforListOrg.Size = new System.Drawing.Size(232, 30);
            this.lblLeftAreaTitleforListOrg.TabIndex = 2;
            this.lblLeftAreaTitleforListOrg.Text = "DANH SÁCH TỔ CHỨC";
            this.lblLeftAreaTitleforListOrg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.colMemberId,
            this.colMemberCode,
            this.colTitle,
            this.colFullName,
            this.colActive,
            this.colPersoStatus,
            this.colIdentityCard,
            this.colIdentityCardDate,
            this.colIdentityCardIssue,
            this.colPhoneNo,
            this.colEmail,
            this.colPermanentAddress,
            this.colTemporaryAddress});
            this.dgvMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMembers.Location = new System.Drawing.Point(0, 199);
            this.dgvMembers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMembers.MultiSelect = false;
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.RowHeadersVisible = false;
            this.dgvMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.Size = new System.Drawing.Size(674, 329);
            this.dgvMembers.TabIndex = 46;
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
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            this.colFullName.HeaderText = "Họ Và Tên";
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            this.colFullName.Width = 150;
            // 
            // colActive
            // 
            this.colActive.DataPropertyName = "Active";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colActive.DefaultCellStyle = dataGridViewCellStyle1;
            this.colActive.HeaderText = "Đã Hủy";
            this.colActive.Name = "colActive";
            this.colActive.ReadOnly = true;
            this.colActive.Width = 125;
            // 
            // colPersoStatus
            // 
            this.colPersoStatus.DataPropertyName = "PersoStatus";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPersoStatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPersoStatus.HeaderText = "TT Phát Hành";
            this.colPersoStatus.Name = "colPersoStatus";
            this.colPersoStatus.ReadOnly = true;
            this.colPersoStatus.Width = 125;
            // 
            // colIdentityCard
            // 
            this.colIdentityCard.DataPropertyName = "IdentityCard";
            this.colIdentityCard.HeaderText = "CMND";
            this.colIdentityCard.Name = "colIdentityCard";
            this.colIdentityCard.ReadOnly = true;
            // 
            // colIdentityCardDate
            // 
            this.colIdentityCardDate.DataPropertyName = "IdentityCardDate";
            this.colIdentityCardDate.HeaderText = "Ngày Cấp";
            this.colIdentityCardDate.Name = "colIdentityCardDate";
            this.colIdentityCardDate.ReadOnly = true;
            // 
            // colIdentityCardIssue
            // 
            this.colIdentityCardIssue.DataPropertyName = "IdentityCardIssue";
            this.colIdentityCardIssue.HeaderText = "Nơi Cấp";
            this.colIdentityCardIssue.Name = "colIdentityCardIssue";
            this.colIdentityCardIssue.ReadOnly = true;
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
            // pnlFilterBox
            // 
            this.pnlFilterBox.Controls.Add(this.line2);
            this.pnlFilterBox.Controls.Add(this.panel5);
            this.pnlFilterBox.Controls.Add(this.line1);
            this.pnlFilterBox.Controls.Add(this.lbInfo_FrmAddOrEditOrg);
            this.pnlFilterBox.Controls.Add(this.lblNotification22);
            this.pnlFilterBox.Controls.Add(this.lblentermorthan2letter);
            this.pnlFilterBox.Controls.Add(this.tbxMemberCode);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByMemberCode);
            this.pnlFilterBox.Controls.Add(this.tbxMemberName);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByMemberName);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Size = new System.Drawing.Size(674, 174);
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
            this.panel5.Controls.Add(this.lbl2_FrmAddOrEditOrg_Name);
            this.panel5.Controls.Add(this.txtCode);
            this.panel5.Controls.Add(this.txtPhone);
            this.panel5.Controls.Add(this.Phone);
            this.panel5.Controls.Add(this.txtEmail);
            this.panel5.Controls.Add(this.lbl11_UsrOrganizationMgtMain);
            this.panel5.Controls.Add(this.txtName);
            this.panel5.Controls.Add(this.lbl1_FrmAddOrEditOrg_Code);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 26);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(674, 87);
            this.panel5.TabIndex = 78;
            // 
            // lbl2_FrmAddOrEditOrg_Name
            // 
            this.lbl2_FrmAddOrEditOrg_Name.AutoSize = true;
            this.lbl2_FrmAddOrEditOrg_Name.Location = new System.Drawing.Point(269, 11);
            this.lbl2_FrmAddOrEditOrg_Name.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.lbl2_FrmAddOrEditOrg_Name.Name = "lbl2_FrmAddOrEditOrg_Name";
            this.lbl2_FrmAddOrEditOrg_Name.Size = new System.Drawing.Size(80, 14);
            this.lbl2_FrmAddOrEditOrg_Name.TabIndex = 43;
            this.lbl2_FrmAddOrEditOrg_Name.Text = "Tên tổ chức:";
            // 
            // txtCode
            // 
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(93, 5);
            this.txtCode.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtCode.MaxLength = 20;
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(156, 22);
            this.txtCode.TabIndex = 1;
            // 
            // txtPhone
            // 
            this.txtPhone.Enabled = false;
            this.txtPhone.Location = new System.Drawing.Point(93, 35);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtPhone.MaxLength = 15;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(156, 22);
            this.txtPhone.TabIndex = 9;
            // 
            // Phone
            // 
            this.Phone.AutoSize = true;
            this.Phone.Location = new System.Drawing.Point(5, 38);
            this.Phone.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(66, 14);
            this.Phone.TabIndex = 32;
            this.Phone.Text = "Điện thoại:";
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(382, 34);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(232, 22);
            this.txtEmail.TabIndex = 11;
            // 
            // lbl11_UsrOrganizationMgtMain
            // 
            this.lbl11_UsrOrganizationMgtMain.AutoSize = true;
            this.lbl11_UsrOrganizationMgtMain.Location = new System.Drawing.Point(269, 38);
            this.lbl11_UsrOrganizationMgtMain.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.lbl11_UsrOrganizationMgtMain.Name = "lbl11_UsrOrganizationMgtMain";
            this.lbl11_UsrOrganizationMgtMain.Size = new System.Drawing.Size(38, 14);
            this.lbl11_UsrOrganizationMgtMain.TabIndex = 30;
            this.lbl11_UsrOrganizationMgtMain.Text = "Email:";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(382, 8);
            this.txtName.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(232, 22);
            this.txtName.TabIndex = 2;
            // 
            // lbl1_FrmAddOrEditOrg_Code
            // 
            this.lbl1_FrmAddOrEditOrg_Code.AutoSize = true;
            this.lbl1_FrmAddOrEditOrg_Code.Location = new System.Drawing.Point(5, 8);
            this.lbl1_FrmAddOrEditOrg_Code.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.lbl1_FrmAddOrEditOrg_Code.Name = "lbl1_FrmAddOrEditOrg_Code";
            this.lbl1_FrmAddOrEditOrg_Code.Size = new System.Drawing.Size(73, 14);
            this.lbl1_FrmAddOrEditOrg_Code.TabIndex = 7;
            this.lbl1_FrmAddOrEditOrg_Code.Text = "Mã tổ chức:";
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
            // lbInfo_FrmAddOrEditOrg
            // 
            this.lbInfo_FrmAddOrEditOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbInfo_FrmAddOrEditOrg.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.lbInfo_FrmAddOrEditOrg.Location = new System.Drawing.Point(0, 0);
            this.lbInfo_FrmAddOrEditOrg.Name = "lbInfo_FrmAddOrEditOrg";
            this.lbInfo_FrmAddOrEditOrg.Size = new System.Drawing.Size(674, 25);
            this.lbInfo_FrmAddOrEditOrg.TabIndex = 76;
            this.lbInfo_FrmAddOrEditOrg.Text = "Thông tin tổ chức:";
            this.lbInfo_FrmAddOrEditOrg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNotification22
            // 
            this.lblNotification22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNotification22.Location = new System.Drawing.Point(370, 146);
            this.lblNotification22.Name = "lblNotification22";
            this.lblNotification22.Size = new System.Drawing.Size(150, 22);
            this.lblNotification22.TabIndex = 42;
            this.lblNotification22.Text = "Vui lòng nhập ít nhất 2 ký tự";
            this.lblNotification22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotification22.Visible = false;
            // 
            // lblentermorthan2letter
            // 
            this.lblentermorthan2letter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblentermorthan2letter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblentermorthan2letter.Location = new System.Drawing.Point(370, 118);
            this.lblentermorthan2letter.Name = "lblentermorthan2letter";
            this.lblentermorthan2letter.Size = new System.Drawing.Size(150, 22);
            this.lblentermorthan2letter.TabIndex = 41;
            this.lblentermorthan2letter.Text = "Vui lòng nhập ít nhất 2 ký tự";
            this.lblentermorthan2letter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblentermorthan2letter.Visible = false;
            // 
            // tbxMemberCode
            // 
            this.tbxMemberCode.Enabled = false;
            this.tbxMemberCode.Location = new System.Drawing.Point(214, 146);
            this.tbxMemberCode.MaxLength = 100;
            this.tbxMemberCode.Name = "tbxMemberCode";
            this.tbxMemberCode.Size = new System.Drawing.Size(150, 22);
            this.tbxMemberCode.TabIndex = 35;
            this.tbxMemberCode.TextChanged += new System.EventHandler(this.tbxMemberCode_TextChanged);
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
            this.tbxMemberName.MaxLength = 100;
            this.tbxMemberName.Name = "tbxMemberName";
            this.tbxMemberName.Size = new System.Drawing.Size(150, 22);
            this.tbxMemberName.TabIndex = 33;
            this.tbxMemberName.TextChanged += new System.EventHandler(this.tbxMemberName_TextChanged);
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
            this.btnAddMember,
            this.btnUpdateMember,
            this.btnRemoveMember,
            this.tssAfterPersoButton,
            this.btnShowHide,
            this.btnSyncData,
            this.toolStripSeparator2,
            this.btnExportToExcel,
            this.btnReloadMembers});
            this.tmsMember.Location = new System.Drawing.Point(0, 0);
            this.tmsMember.Name = "tmsMember";
            this.tmsMember.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tmsMember.Size = new System.Drawing.Size(674, 25);
            this.tmsMember.TabIndex = 44;
            this.tmsMember.Text = "toolStrip1";
            // 
            // btnAddMember
            // 
            this.btnAddMember.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddMember.Enabled = false;
            this.btnAddMember.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMember.Image")));
            this.btnAddMember.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(23, 22);
            this.btnAddMember.Text = "Thêm Thành Viên Mới...";
            this.btnAddMember.ToolTipText = "Thêm thành viên mới vào hệ thống.";
            // 
            // btnUpdateMember
            // 
            this.btnUpdateMember.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateMember.Enabled = false;
            this.btnUpdateMember.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateMember.Image")));
            this.btnUpdateMember.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateMember.Name = "btnUpdateMember";
            this.btnUpdateMember.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateMember.Text = "Cập Nhật Thông Tin Thành Viên...";
            this.btnUpdateMember.ToolTipText = "Cập nhật thông tin thành viên trong hệ thống.";
            // 
            // btnRemoveMember
            // 
            this.btnRemoveMember.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveMember.Enabled = false;
            this.btnRemoveMember.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveMember.Image")));
            this.btnRemoveMember.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveMember.Name = "btnRemoveMember";
            this.btnRemoveMember.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveMember.Text = "Hủy Thành Viên Khỏi Hệ Thống...";
            this.btnRemoveMember.ToolTipText = "Hủy thành viên khỏi hệ thống";
            // 
            // tssAfterPersoButton
            // 
            this.tssAfterPersoButton.Name = "tssAfterPersoButton";
            this.tssAfterPersoButton.Size = new System.Drawing.Size(6, 25);
            this.tssAfterPersoButton.Visible = false;
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
            this.btnExportToExcel.Enabled = false;
            this.btnExportToExcel.Image = global::SystemMgtComponent.Properties.Resources.Excel_16x16;
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
            this.btnReloadMembers.Enabled = false;
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
            // lstMember
            // 
            this.lstMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lstMember.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstMember.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lstMember.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lstMember.Location = new System.Drawing.Point(0, 0);
            this.lstMember.Name = "lstMember";
            this.lstMember.Size = new System.Drawing.Size(686, 30);
            this.lstMember.TabIndex = 34;
            this.lstMember.Text = "DANH SÁCH THÀNH VIÊN";
            this.lstMember.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // cmsUserTable
            // 
            this.cmsUserTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAddUser,
            this.toolStripSeparator5,
            this.mniExportToExcel,
            this.mniReloadUsers});
            this.cmsUserTable.Name = "contextMenuStrip1";
            this.cmsUserTable.Size = new System.Drawing.Size(194, 76);
            // 
            // mniAddUser
            // 
            this.mniAddUser.Image = ((System.Drawing.Image)(resources.GetObject("mniAddUser.Image")));
            this.mniAddUser.Name = "mniAddUser";
            this.mniAddUser.Size = new System.Drawing.Size(193, 22);
            this.mniAddUser.Text = "Thêm Tài Khoản Mới...";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(190, 6);
            // 
            // mniExportToExcel
            // 
            this.mniExportToExcel.Name = "mniExportToExcel";
            this.mniExportToExcel.Size = new System.Drawing.Size(193, 22);
            this.mniExportToExcel.Text = "Xuất Ra Excel...";
            // 
            // mniReloadUsers
            // 
            this.mniReloadUsers.Image = ((System.Drawing.Image)(resources.GetObject("mniReloadUsers.Image")));
            this.mniReloadUsers.Name = "mniReloadUsers";
            this.mniReloadUsers.Size = new System.Drawing.Size(193, 22);
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
            // UsrMemberMgtMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrMemberMgtMain";
            this.Size = new System.Drawing.Size(937, 600);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
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
            this.cmsOrgTree.ResumeLayout(false);
            this.cmsUserTable.ResumeLayout(false);
            this.cmsOrgRecord.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private CommonControls.Custom.TitleLabel lblLeftAreaTitleforListOrg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private System.Windows.Forms.ContextMenuStrip cmsUserTable;
        private System.Windows.Forms.ToolStripMenuItem mniAddUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mniExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem mniReloadUsers;
        private CommonControls.Custom.TitleLabel lstMember;
        private System.Windows.Forms.ToolStripMenuItem mniRemoveGroups;
        private System.Windows.Forms.ContextMenuStrip cmsOrgTree;
        private System.Windows.Forms.ToolStripMenuItem mniReloadOrgs;
        private System.Windows.Forms.ToolStripMenuItem mniUpdateGroup;
        private System.Windows.Forms.ContextMenuStrip cmsOrgRecord;
        private CommonControls.Custom.CommonDataGridView dgvMembers;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Label lblNotification22;
        private System.Windows.Forms.Label lblentermorthan2letter;
        private System.Windows.Forms.TextBox tbxMemberCode;
        private System.Windows.Forms.CheckBox cbxFilterByMemberCode;
        private System.Windows.Forms.TextBox tbxMemberName;
        private System.Windows.Forms.CheckBox cbxFilterByMemberName;
        private CommonControls.Custom.CommonToolStrip tmsMember;
        private System.Windows.Forms.ToolStripSeparator tssAfterPersoButton;
        private System.Windows.Forms.ToolStripButton btnShowHide;
        private System.Windows.Forms.ToolStripButton btnSyncData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripButton btnReloadMembers;
        private System.Windows.Forms.ToolStripButton btnAddMember;
        private System.Windows.Forms.ToolStripButton btnUpdateMember;
        private System.Windows.Forms.ToolStripButton btnRemoveMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersoStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentityCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentityCardDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentityCardIssue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoneNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPermanentAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTemporaryAddress;
        private System.Windows.Forms.Label lbInfo_FrmAddOrEditOrg;
        private CommonControls.Custom.Line line2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl2_FrmAddOrEditOrg_Name;
        private CommonControls.Custom.CommonTextBox txtCode;
        private CommonControls.Custom.CommonTextBox txtPhone;
        private System.Windows.Forms.Label Phone;
        private CommonControls.Custom.CommonTextBox txtEmail;
        private System.Windows.Forms.Label lbl11_UsrOrganizationMgtMain;
        private CommonControls.Custom.CommonTextBox txtName;
        private System.Windows.Forms.Label lbl1_FrmAddOrEditOrg_Code;
        private CommonControls.Custom.Line line1;
        private TreeOrg treeOrg;
    }
}
