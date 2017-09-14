namespace PersoMgtComponent.WorkItems
{
    partial class UsrPersoMgtMain
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
                if (loadFacultyWorker != null && loadFacultyWorker.IsBusy)
                {
                    loadFacultyWorker.CancelAsync();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrPersoMgtMain));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trvOrganizations = new System.Windows.Forms.TreeView();
            this.tmsOrganization = new CommonControls.Custom.CommonToolStrip();
            this.btnReloadOrgs = new System.Windows.Forms.ToolStripButton();
            this.plHideShowOrg = new System.Windows.Forms.Panel();
            this.cmbPartnerInfo = new System.Windows.Forms.ComboBox();
            this.lblPartnerKey = new System.Windows.Forms.Label();
            this.cbxAutoCloseNode = new System.Windows.Forms.CheckBox();
            this.lblLeftAreaTitleforListPartner = new CommonControls.Custom.TitleLabel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pnlRightMain = new System.Windows.Forms.Panel();
            this.dgvPersoes = new CommonControls.Custom.CommonDataGridView();
            this.colChipPersoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPermanentAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTemporaryAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhoneNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDegree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersoStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersoDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.cmsPersoTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xuấtRaExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniReloadPersoes = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxOnlyShowRecordsNeedToUpdate = new System.Windows.Forms.CheckBox();
            this.cbxShowCanceledPersoes = new System.Windows.Forms.CheckBox();
            this.cbxShowTeacherColumns = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbtnSttExpired = new System.Windows.Forms.RadioButton();
            this.rbtnSttCanceled = new System.Windows.Forms.RadioButton();
            this.rbtnSttLocked = new System.Windows.Forms.RadioButton();
            this.rbtnSttNormal = new System.Windows.Forms.RadioButton();
            this.dtpPersoDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpPersoDateFrom = new System.Windows.Forms.DateTimePicker();
            this.cbxFilterByPersoDate = new System.Windows.Forms.CheckBox();
            this.cbxFilterByPersoStatus = new System.Windows.Forms.CheckBox();
            this.lblNotification1 = new System.Windows.Forms.Label();
            this.tbxMemberName = new System.Windows.Forms.TextBox();
            this.cbxFilterByMemberName = new System.Windows.Forms.CheckBox();
            this.pagerPanel = new CommonControls.Custom.PagerPanel();
            this.tmsTeacher = new CommonControls.Custom.CommonToolStrip();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.btnLockPerso = new System.Windows.Forms.ToolStripButton();
            this.btnUnLockPerso = new System.Windows.Forms.ToolStripButton();
            this.btnCancelPerso = new System.Windows.Forms.ToolStripButton();
            this.btnExtendPerso = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMarkBroken = new System.Windows.Forms.ToolStripButton();
            this.btnUnMarkBroken = new System.Windows.Forms.ToolStripButton();
            this.btnMarkLost = new System.Windows.Forms.ToolStripButton();
            this.btnUnMarkLost = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnReloadPersoes = new System.Windows.Forms.ToolStripButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblRightAreaTitlePerso = new CommonControls.Custom.TitleLabel();
            this.cmsOrgTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniReloadOrgs = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPersoRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniLockPerso = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUnlockPerso = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCancelPerso = new System.Windows.Forms.ToolStripMenuItem();
            this.mniExtendPerso = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mniMarkBroken = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUnMarkBroken = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMarkLost = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUnMarkLost = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tmsOrganization.SuspendLayout();
            this.plHideShowOrg.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnlRightMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersoes)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.cmsPersoTable.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tmsTeacher.SuspendLayout();
            this.cmsOrgTree.SuspendLayout();
            this.cmsPersoRecord.SuspendLayout();
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
            this.splitContainer.Panel2.Controls.Add(this.lblRightAreaTitlePerso);
            this.splitContainer.Size = new System.Drawing.Size(990, 590);
            this.splitContainer.SplitterDistance = 250;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cbxAutoCloseNode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(248, 558);
            this.panel1.TabIndex = 3;
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
            this.panel2.Size = new System.Drawing.Size(238, 528);
            this.panel2.TabIndex = 53;
            // 
            // trvOrganizations
            // 
            this.trvOrganizations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvOrganizations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvOrganizations.Location = new System.Drawing.Point(0, 80);
            this.trvOrganizations.Name = "trvOrganizations";
            this.trvOrganizations.Size = new System.Drawing.Size(236, 446);
            this.trvOrganizations.TabIndex = 60;
            // 
            // tmsOrganization
            // 
            this.tmsOrganization.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReloadOrgs});
            this.tmsOrganization.Location = new System.Drawing.Point(0, 55);
            this.tmsOrganization.Name = "tmsOrganization";
            this.tmsOrganization.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tmsOrganization.Size = new System.Drawing.Size(236, 25);
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
            this.plHideShowOrg.Size = new System.Drawing.Size(236, 55);
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
            this.cmbPartnerInfo.Size = new System.Drawing.Size(221, 22);
            this.cmbPartnerInfo.TabIndex = 4;
            this.cmbPartnerInfo.SelectedIndexChanged += new System.EventHandler(this.cmbPartnerInfo_SelectedIndexChanged);
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
            // cbxAutoCloseNode
            // 
            this.cbxAutoCloseNode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cbxAutoCloseNode.Location = new System.Drawing.Point(5, 533);
            this.cbxAutoCloseNode.Name = "cbxAutoCloseNode";
            this.cbxAutoCloseNode.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.cbxAutoCloseNode.Size = new System.Drawing.Size(238, 20);
            this.cbxAutoCloseNode.TabIndex = 52;
            this.cbxAutoCloseNode.Text = "Tự động rút gọn danh sách";
            this.cbxAutoCloseNode.UseVisualStyleBackColor = true;
            // 
            // lblLeftAreaTitleforListPartner
            // 
            this.lblLeftAreaTitleforListPartner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblLeftAreaTitleforListPartner.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftAreaTitleforListPartner.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblLeftAreaTitleforListPartner.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLeftAreaTitleforListPartner.Location = new System.Drawing.Point(0, 0);
            this.lblLeftAreaTitleforListPartner.Name = "lblLeftAreaTitleforListPartner";
            this.lblLeftAreaTitleforListPartner.Size = new System.Drawing.Size(248, 30);
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
            this.panel8.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panel8.Size = new System.Drawing.Size(733, 554);
            this.panel8.TabIndex = 18;
            // 
            // pnlRightMain
            // 
            this.pnlRightMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRightMain.Controls.Add(this.dgvPersoes);
            this.pnlRightMain.Controls.Add(this.pnlFilterBox);
            this.pnlRightMain.Controls.Add(this.pagerPanel);
            this.pnlRightMain.Controls.Add(this.tmsTeacher);
            this.pnlRightMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightMain.Location = new System.Drawing.Point(5, 0);
            this.pnlRightMain.Name = "pnlRightMain";
            this.pnlRightMain.Size = new System.Drawing.Size(723, 549);
            this.pnlRightMain.TabIndex = 14;
            // 
            // dgvPersoes
            // 
            this.dgvPersoes.AllowUserToAddRows = false;
            this.dgvPersoes.AllowUserToDeleteRows = false;
            this.dgvPersoes.AllowUserToOrderColumns = true;
            this.dgvPersoes.AllowUserToResizeRows = false;
            this.dgvPersoes.BackgroundColor = System.Drawing.Color.White;
            this.dgvPersoes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPersoes.ColumnHeadersHeight = 26;
            this.dgvPersoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChipPersoId,
            this.colCardId,
            this.colMemberId,
            this.colLastName,
            this.colFirstName,
            this.colBirthDate,
            this.colPermanentAddress,
            this.colTemporaryAddress,
            this.colPhoneNo,
            this.colEmail,
            this.colDegree,
            this.colTitle,
            this.colPosition,
            this.colSerialNumber,
            this.colCardStatus,
            this.colPersoStatus,
            this.colPersoDate,
            this.colExpirationDate,
            this.colNotes});
            this.dgvPersoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersoes.Location = new System.Drawing.Point(0, 171);
            this.dgvPersoes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPersoes.Name = "dgvPersoes";
            this.dgvPersoes.ReadOnly = true;
            this.dgvPersoes.RowHeadersVisible = false;
            this.dgvPersoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersoes.Size = new System.Drawing.Size(721, 356);
            this.dgvPersoes.TabIndex = 31;
            // 
            // colChipPersoId
            // 
            this.colChipPersoId.DataPropertyName = "ChipPersoId";
            this.colChipPersoId.HeaderText = "Mã Lượt";
            this.colChipPersoId.Name = "colChipPersoId";
            this.colChipPersoId.ReadOnly = true;
            // 
            // colCardId
            // 
            this.colCardId.DataPropertyName = "CardId";
            this.colCardId.HeaderText = "CardId";
            this.colCardId.Name = "colCardId";
            this.colCardId.ReadOnly = true;
            this.colCardId.Visible = false;
            // 
            // colMemberId
            // 
            this.colMemberId.DataPropertyName = "MemberId";
            this.colMemberId.HeaderText = "MemberId";
            this.colMemberId.Name = "colMemberId";
            this.colMemberId.ReadOnly = true;
            this.colMemberId.Visible = false;
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
            this.colBirthDate.Visible = false;
            // 
            // colPermanentAddress
            // 
            this.colPermanentAddress.DataPropertyName = "PermanentAddress";
            this.colPermanentAddress.HeaderText = "Địa Chỉ Thường Trú";
            this.colPermanentAddress.Name = "colPermanentAddress";
            this.colPermanentAddress.ReadOnly = true;
            this.colPermanentAddress.Visible = false;
            this.colPermanentAddress.Width = 250;
            // 
            // colTemporaryAddress
            // 
            this.colTemporaryAddress.DataPropertyName = "TemporaryAddress";
            this.colTemporaryAddress.HeaderText = "Địa Chỉ Tạm Thời";
            this.colTemporaryAddress.Name = "colTemporaryAddress";
            this.colTemporaryAddress.ReadOnly = true;
            this.colTemporaryAddress.Visible = false;
            this.colTemporaryAddress.Width = 250;
            // 
            // colPhoneNo
            // 
            this.colPhoneNo.DataPropertyName = "PhoneNo";
            this.colPhoneNo.HeaderText = "Số Điện Thoại";
            this.colPhoneNo.Name = "colPhoneNo";
            this.colPhoneNo.ReadOnly = true;
            this.colPhoneNo.Visible = false;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Visible = false;
            this.colEmail.Width = 150;
            // 
            // colDegree
            // 
            this.colDegree.DataPropertyName = "Degree";
            this.colDegree.HeaderText = "Trình Độ";
            this.colDegree.Name = "colDegree";
            this.colDegree.ReadOnly = true;
            this.colDegree.Visible = false;
            // 
            // colTitle
            // 
            this.colTitle.DataPropertyName = "Title";
            this.colTitle.HeaderText = "Chức Danh";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.Visible = false;
            // 
            // colPosition
            // 
            this.colPosition.DataPropertyName = "Position";
            this.colPosition.HeaderText = "Chức Vụ";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            this.colPosition.Visible = false;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.DataPropertyName = "SerialNumber";
            this.colSerialNumber.HeaderText = "Mã Thẻ";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            // 
            // colCardStatus
            // 
            this.colCardStatus.DataPropertyName = "CardStatus";
            this.colCardStatus.HeaderText = "TT Thẻ";
            this.colCardStatus.Name = "colCardStatus";
            this.colCardStatus.ReadOnly = true;
            this.colCardStatus.Width = 125;
            // 
            // colPersoStatus
            // 
            this.colPersoStatus.DataPropertyName = "PersoStatus";
            this.colPersoStatus.HeaderText = "TT Phát Hành";
            this.colPersoStatus.Name = "colPersoStatus";
            this.colPersoStatus.ReadOnly = true;
            this.colPersoStatus.Width = 125;
            // 
            // colPersoDate
            // 
            this.colPersoDate.DataPropertyName = "PersoDate";
            this.colPersoDate.HeaderText = "Ngày Phát Hành";
            this.colPersoDate.Name = "colPersoDate";
            this.colPersoDate.ReadOnly = true;
            this.colPersoDate.Width = 125;
            // 
            // colExpirationDate
            // 
            this.colExpirationDate.DataPropertyName = "ExpirationDate";
            this.colExpirationDate.HeaderText = "Ngày Hết Hạn";
            this.colExpirationDate.Name = "colExpirationDate";
            this.colExpirationDate.ReadOnly = true;
            this.colExpirationDate.Width = 125;
            // 
            // colNotes
            // 
            this.colNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNotes.DataPropertyName = "Notes";
            this.colNotes.HeaderText = "Ghi Chú";
            this.colNotes.MinimumWidth = 250;
            this.colNotes.Name = "colNotes";
            this.colNotes.ReadOnly = true;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.ContextMenuStrip = this.cmsPersoTable;
            this.pnlFilterBox.Controls.Add(this.cbxOnlyShowRecordsNeedToUpdate);
            this.pnlFilterBox.Controls.Add(this.cbxShowCanceledPersoes);
            this.pnlFilterBox.Controls.Add(this.cbxShowTeacherColumns);
            this.pnlFilterBox.Controls.Add(this.panel3);
            this.pnlFilterBox.Controls.Add(this.dtpPersoDateTo);
            this.pnlFilterBox.Controls.Add(this.label2);
            this.pnlFilterBox.Controls.Add(this.label1);
            this.pnlFilterBox.Controls.Add(this.dtpPersoDateFrom);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByPersoDate);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByPersoStatus);
            this.pnlFilterBox.Controls.Add(this.lblNotification1);
            this.pnlFilterBox.Controls.Add(this.tbxMemberName);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByMemberName);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(721, 146);
            this.pnlFilterBox.TabIndex = 29;
            // 
            // cmsPersoTable
            // 
            this.cmsPersoTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xuấtRaExcelToolStripMenuItem,
            this.mniReloadPersoes});
            this.cmsPersoTable.Name = "contextMenuStrip1";
            this.cmsPersoTable.Size = new System.Drawing.Size(153, 48);
            // 
            // xuấtRaExcelToolStripMenuItem
            // 
            this.xuấtRaExcelToolStripMenuItem.Image = global::PersoMgtComponent.Properties.Resources.Excel_16x16;
            this.xuấtRaExcelToolStripMenuItem.Name = "xuấtRaExcelToolStripMenuItem";
            this.xuấtRaExcelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.xuấtRaExcelToolStripMenuItem.Text = "Xuất Ra Excel...";
            this.xuấtRaExcelToolStripMenuItem.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // mniReloadPersoes
            // 
            this.mniReloadPersoes.Image = ((System.Drawing.Image)(resources.GetObject("mniReloadPersoes.Image")));
            this.mniReloadPersoes.Name = "mniReloadPersoes";
            this.mniReloadPersoes.Size = new System.Drawing.Size(152, 22);
            this.mniReloadPersoes.Text = "Tải Dữ Liệu";
            // 
            // cbxOnlyShowRecordsNeedToUpdate
            // 
            this.cbxOnlyShowRecordsNeedToUpdate.Location = new System.Drawing.Point(8, 120);
            this.cbxOnlyShowRecordsNeedToUpdate.Name = "cbxOnlyShowRecordsNeedToUpdate";
            this.cbxOnlyShowRecordsNeedToUpdate.Size = new System.Drawing.Size(555, 22);
            this.cbxOnlyShowRecordsNeedToUpdate.TabIndex = 79;
            this.cbxOnlyShowRecordsNeedToUpdate.Text = "Chỉ hiển thị những lượt phát hành cần cập nhật dữ liệu thành viên";
            this.cbxOnlyShowRecordsNeedToUpdate.UseVisualStyleBackColor = true;
            // 
            // cbxShowCanceledPersoes
            // 
            this.cbxShowCanceledPersoes.Checked = true;
            this.cbxShowCanceledPersoes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxShowCanceledPersoes.Location = new System.Drawing.Point(264, 92);
            this.cbxShowCanceledPersoes.Name = "cbxShowCanceledPersoes";
            this.cbxShowCanceledPersoes.Size = new System.Drawing.Size(300, 22);
            this.cbxShowCanceledPersoes.TabIndex = 78;
            this.cbxShowCanceledPersoes.Text = "Hiển thị những lượt phát hành đã bị hủy";
            this.cbxShowCanceledPersoes.UseVisualStyleBackColor = true;
            // 
            // cbxShowTeacherColumns
            // 
            this.cbxShowTeacherColumns.Location = new System.Drawing.Point(8, 92);
            this.cbxShowTeacherColumns.Name = "cbxShowTeacherColumns";
            this.cbxShowTeacherColumns.Size = new System.Drawing.Size(250, 22);
            this.cbxShowTeacherColumns.TabIndex = 77;
            this.cbxShowTeacherColumns.Text = "Hiện đầy đủ thông tin của thành viên";
            this.cbxShowTeacherColumns.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbtnSttExpired);
            this.panel3.Controls.Add(this.rbtnSttCanceled);
            this.panel3.Controls.Add(this.rbtnSttLocked);
            this.panel3.Controls.Add(this.rbtnSttNormal);
            this.panel3.Location = new System.Drawing.Point(214, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(440, 22);
            this.panel3.TabIndex = 76;
            // 
            // rbtnSttExpired
            // 
            this.rbtnSttExpired.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnSttExpired.Enabled = false;
            this.rbtnSttExpired.Location = new System.Drawing.Point(330, 0);
            this.rbtnSttExpired.Name = "rbtnSttExpired";
            this.rbtnSttExpired.Size = new System.Drawing.Size(110, 22);
            this.rbtnSttExpired.TabIndex = 7;
            this.rbtnSttExpired.Text = "Đã Hết Hạn";
            this.rbtnSttExpired.UseVisualStyleBackColor = true;
            // 
            // rbtnSttCanceled
            // 
            this.rbtnSttCanceled.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnSttCanceled.Enabled = false;
            this.rbtnSttCanceled.Location = new System.Drawing.Point(220, 0);
            this.rbtnSttCanceled.Name = "rbtnSttCanceled";
            this.rbtnSttCanceled.Size = new System.Drawing.Size(110, 22);
            this.rbtnSttCanceled.TabIndex = 6;
            this.rbtnSttCanceled.Text = "Đã Bị Hủy";
            this.rbtnSttCanceled.UseVisualStyleBackColor = true;
            // 
            // rbtnSttLocked
            // 
            this.rbtnSttLocked.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnSttLocked.Enabled = false;
            this.rbtnSttLocked.Location = new System.Drawing.Point(110, 0);
            this.rbtnSttLocked.Name = "rbtnSttLocked";
            this.rbtnSttLocked.Size = new System.Drawing.Size(110, 22);
            this.rbtnSttLocked.TabIndex = 5;
            this.rbtnSttLocked.Text = "Đang Bị Khóa";
            this.rbtnSttLocked.UseVisualStyleBackColor = true;
            // 
            // rbtnSttNormal
            // 
            this.rbtnSttNormal.Checked = true;
            this.rbtnSttNormal.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnSttNormal.Enabled = false;
            this.rbtnSttNormal.Location = new System.Drawing.Point(0, 0);
            this.rbtnSttNormal.Name = "rbtnSttNormal";
            this.rbtnSttNormal.Size = new System.Drawing.Size(110, 22);
            this.rbtnSttNormal.TabIndex = 4;
            this.rbtnSttNormal.TabStop = true;
            this.rbtnSttNormal.Text = "Bình Thường";
            this.rbtnSttNormal.UseVisualStyleBackColor = true;
            // 
            // dtpPersoDateTo
            // 
            this.dtpPersoDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpPersoDateTo.Enabled = false;
            this.dtpPersoDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPersoDateTo.Location = new System.Drawing.Point(415, 64);
            this.dtpPersoDateTo.Name = "dtpPersoDateTo";
            this.dtpPersoDateTo.Size = new System.Drawing.Size(118, 22);
            this.dtpPersoDateTo.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 74;
            this.label2.Text = "Đến:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 16);
            this.label1.TabIndex = 73;
            this.label1.Text = "Từ:";
            // 
            // dtpPersoDateFrom
            // 
            this.dtpPersoDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpPersoDateFrom.Enabled = false;
            this.dtpPersoDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPersoDateFrom.Location = new System.Drawing.Point(249, 64);
            this.dtpPersoDateFrom.Name = "dtpPersoDateFrom";
            this.dtpPersoDateFrom.Size = new System.Drawing.Size(118, 22);
            this.dtpPersoDateFrom.TabIndex = 72;
            // 
            // cbxFilterByPersoDate
            // 
            this.cbxFilterByPersoDate.Location = new System.Drawing.Point(8, 64);
            this.cbxFilterByPersoDate.Name = "cbxFilterByPersoDate";
            this.cbxFilterByPersoDate.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByPersoDate.TabIndex = 71;
            this.cbxFilterByPersoDate.Text = "Lọc theo ngày phát hành:";
            this.cbxFilterByPersoDate.UseVisualStyleBackColor = true;
            // 
            // cbxFilterByPersoStatus
            // 
            this.cbxFilterByPersoStatus.Location = new System.Drawing.Point(8, 36);
            this.cbxFilterByPersoStatus.Name = "cbxFilterByPersoStatus";
            this.cbxFilterByPersoStatus.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByPersoStatus.TabIndex = 70;
            this.cbxFilterByPersoStatus.Text = "Lọc theo trạng thái:";
            this.cbxFilterByPersoStatus.UseVisualStyleBackColor = true;
            // 
            // lblNotification1
            // 
            this.lblNotification1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNotification1.Location = new System.Drawing.Point(370, 8);
            this.lblNotification1.Name = "lblNotification1";
            this.lblNotification1.Size = new System.Drawing.Size(150, 22);
            this.lblNotification1.TabIndex = 68;
            this.lblNotification1.Text = "Vui lòng nhập ít nhất 2 ký tự";
            this.lblNotification1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotification1.Visible = false;
            // 
            // tbxMemberName
            // 
            this.tbxMemberName.Enabled = false;
            this.tbxMemberName.Location = new System.Drawing.Point(214, 8);
            this.tbxMemberName.Name = "tbxMemberName";
            this.tbxMemberName.Size = new System.Drawing.Size(150, 22);
            this.tbxMemberName.TabIndex = 65;
            this.tbxMemberName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxTeacherName_KeyDown);
            // 
            // cbxFilterByMemberName
            // 
            this.cbxFilterByMemberName.Location = new System.Drawing.Point(8, 8);
            this.cbxFilterByMemberName.Name = "cbxFilterByMemberName";
            this.cbxFilterByMemberName.Size = new System.Drawing.Size(200, 22);
            this.cbxFilterByMemberName.TabIndex = 64;
            this.cbxFilterByMemberName.Text = "Lọc theo tên thành viên:";
            this.cbxFilterByMemberName.UseVisualStyleBackColor = true;
            // 
            // pagerPanel
            // 
            this.pagerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel.Location = new System.Drawing.Point(0, 527);
            this.pagerPanel.Name = "pagerPanel";
            this.pagerPanel.Size = new System.Drawing.Size(721, 20);
            this.pagerPanel.TabIndex = 25;
            // 
            // tmsTeacher
            // 
            this.tmsTeacher.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowHide,
            this.btnLockPerso,
            this.btnUnLockPerso,
            this.btnCancelPerso,
            this.btnExtendPerso,
            this.toolStripSeparator2,
            this.btnMarkBroken,
            this.btnUnMarkBroken,
            this.btnMarkLost,
            this.btnUnMarkLost,
            this.toolStripSeparator1,
            this.btnExportToExcel,
            this.btnReloadPersoes});
            this.tmsTeacher.Location = new System.Drawing.Point(0, 0);
            this.tmsTeacher.Name = "tmsTeacher";
            this.tmsTeacher.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tmsTeacher.Size = new System.Drawing.Size(721, 25);
            this.tmsTeacher.TabIndex = 22;
            this.tmsTeacher.Text = "toolStrip1";
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
            // btnLockPerso
            // 
            this.btnLockPerso.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLockPerso.Image = ((System.Drawing.Image)(resources.GetObject("btnLockPerso.Image")));
            this.btnLockPerso.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLockPerso.Name = "btnLockPerso";
            this.btnLockPerso.Size = new System.Drawing.Size(23, 22);
            this.btnLockPerso.Text = "Khóa...";
            this.btnLockPerso.ToolTipText = "Khóa lượt phát hành";
            this.btnLockPerso.Click += new System.EventHandler(this.btnLockPerso_Click);
            // 
            // btnUnLockPerso
            // 
            this.btnUnLockPerso.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnLockPerso.Image = ((System.Drawing.Image)(resources.GetObject("btnUnLockPerso.Image")));
            this.btnUnLockPerso.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnLockPerso.Name = "btnUnLockPerso";
            this.btnUnLockPerso.Size = new System.Drawing.Size(23, 22);
            this.btnUnLockPerso.Text = "Mở Khóa...";
            this.btnUnLockPerso.Click += new System.EventHandler(this.btnUnLockPerso_Click);
            // 
            // btnCancelPerso
            // 
            this.btnCancelPerso.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancelPerso.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelPerso.Image")));
            this.btnCancelPerso.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelPerso.Name = "btnCancelPerso";
            this.btnCancelPerso.Size = new System.Drawing.Size(23, 22);
            this.btnCancelPerso.Text = "Hủy...";
            this.btnCancelPerso.ToolTipText = "Hủy lượt phát hành";
            this.btnCancelPerso.Click += new System.EventHandler(this.btnCancelPerso_Click);
            // 
            // btnExtendPerso
            // 
            this.btnExtendPerso.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExtendPerso.Image = global::PersoMgtComponent.Properties.Resources.Extend_16x16;
            this.btnExtendPerso.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExtendPerso.Name = "btnExtendPerso";
            this.btnExtendPerso.Size = new System.Drawing.Size(23, 22);
            this.btnExtendPerso.Text = "Gia Hạn...";
            this.btnExtendPerso.ToolTipText = "Gia hạn lượt phát hành đã hết hạn";
            this.btnExtendPerso.Click += new System.EventHandler(this.btnExtendPerso_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnMarkBroken
            // 
            this.btnMarkBroken.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMarkBroken.Image = global::PersoMgtComponent.Properties.Resources.MarkBlue_16x16;
            this.btnMarkBroken.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMarkBroken.Name = "btnMarkBroken";
            this.btnMarkBroken.Size = new System.Drawing.Size(23, 22);
            this.btnMarkBroken.Text = "Đánh Dấu Hư...";
            this.btnMarkBroken.ToolTipText = "Đánh dấu thẻ đã bị hư";
            this.btnMarkBroken.Click += new System.EventHandler(this.btnMarkBroken_Clicked);
            // 
            // btnUnMarkBroken
            // 
            this.btnUnMarkBroken.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnMarkBroken.Image = global::PersoMgtComponent.Properties.Resources.MarkBlack_16x16;
            this.btnUnMarkBroken.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnMarkBroken.Name = "btnUnMarkBroken";
            this.btnUnMarkBroken.Size = new System.Drawing.Size(23, 22);
            this.btnUnMarkBroken.Text = "Hủy Đánh Dấu Hư...";
            this.btnUnMarkBroken.ToolTipText = "Hủy đánh dấu thẻ đã bị hư";
            this.btnUnMarkBroken.Click += new System.EventHandler(this.btnUnMarkBroken_Clicked);
            // 
            // btnMarkLost
            // 
            this.btnMarkLost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMarkLost.Image = global::PersoMgtComponent.Properties.Resources.MarkRed_16x16;
            this.btnMarkLost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMarkLost.Name = "btnMarkLost";
            this.btnMarkLost.Size = new System.Drawing.Size(23, 22);
            this.btnMarkLost.Text = "Đánh Dấu Mất...";
            this.btnMarkLost.ToolTipText = "Đánh dấu thẻ đã bị mất";
            this.btnMarkLost.Click += new System.EventHandler(this.btnMarkLost_Clicked);
            // 
            // btnUnMarkLost
            // 
            this.btnUnMarkLost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnMarkLost.Image = global::PersoMgtComponent.Properties.Resources.MarkBlack_16x16;
            this.btnUnMarkLost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnMarkLost.Name = "btnUnMarkLost";
            this.btnUnMarkLost.Size = new System.Drawing.Size(23, 22);
            this.btnUnMarkLost.Text = "Hủy Đánh Dấu Mất...";
            this.btnUnMarkLost.ToolTipText = "Hủy đánh dấu thẻ đã bị mất";
            this.btnUnMarkLost.Click += new System.EventHandler(this.btnUnMarkLost_Clicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportToExcel.Image = global::PersoMgtComponent.Properties.Resources.Excel_16x16;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExportToExcel.Text = "Xuất Ra Excel...";
            this.btnExportToExcel.ToolTipText = "Xuất dữ liệu đang hiển thị ra tập tin excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnReloadPersoes
            // 
            this.btnReloadPersoes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadPersoes.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadPersoes.Image")));
            this.btnReloadPersoes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadPersoes.Name = "btnReloadPersoes";
            this.btnReloadPersoes.Size = new System.Drawing.Size(23, 22);
            this.btnReloadPersoes.Text = "Tải Dữ Liệu";
            this.btnReloadPersoes.ToolTipText = "Tải danh sách lượt phát hành";
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 30);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(733, 4);
            this.panel7.TabIndex = 17;
            // 
            // lblRightAreaTitlePerso
            // 
            this.lblRightAreaTitlePerso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitlePerso.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitlePerso.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblRightAreaTitlePerso.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitlePerso.Location = new System.Drawing.Point(0, 0);
            this.lblRightAreaTitlePerso.Name = "lblRightAreaTitlePerso";
            this.lblRightAreaTitlePerso.Size = new System.Drawing.Size(733, 30);
            this.lblRightAreaTitlePerso.TabIndex = 16;
            this.lblRightAreaTitlePerso.Text = "DANH SÁCH LƯỢT PHÁT HÀNH";
            this.lblRightAreaTitlePerso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // cmsPersoRecord
            // 
            this.cmsPersoRecord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniLockPerso,
            this.mniUnlockPerso,
            this.mniCancelPerso,
            this.mniExtendPerso,
            this.toolStripSeparator3,
            this.mniMarkBroken,
            this.mniUnMarkBroken,
            this.mniMarkLost,
            this.mniUnMarkLost});
            this.cmsPersoRecord.Name = "contextMenuStrip1";
            this.cmsPersoRecord.Size = new System.Drawing.Size(221, 186);
            // 
            // mniLockPerso
            // 
            this.mniLockPerso.Image = global::PersoMgtComponent.Properties.Resources.Lock_16x16;
            this.mniLockPerso.Name = "mniLockPerso";
            this.mniLockPerso.Size = new System.Drawing.Size(220, 22);
            this.mniLockPerso.Text = "Khóa Lượt Phát Hành...";
            this.mniLockPerso.Click += new System.EventHandler(this.btnLockPerso_Click);
            // 
            // mniUnlockPerso
            // 
            this.mniUnlockPerso.Image = global::PersoMgtComponent.Properties.Resources.UnLock_16x16;
            this.mniUnlockPerso.Name = "mniUnlockPerso";
            this.mniUnlockPerso.Size = new System.Drawing.Size(220, 22);
            this.mniUnlockPerso.Text = "Mở Khóa Lượt Phát Hành...";
            this.mniUnlockPerso.Click += new System.EventHandler(this.btnUnLockPerso_Click);
            // 
            // mniCancelPerso
            // 
            this.mniCancelPerso.Image = global::PersoMgtComponent.Properties.Resources.Cancel_16x16;
            this.mniCancelPerso.Name = "mniCancelPerso";
            this.mniCancelPerso.Size = new System.Drawing.Size(220, 22);
            this.mniCancelPerso.Text = "Hủy Lượt Phát Hành...";
            this.mniCancelPerso.Click += new System.EventHandler(this.btnCancelPerso_Click);
            // 
            // mniExtendPerso
            // 
            this.mniExtendPerso.Image = global::PersoMgtComponent.Properties.Resources.Extend_16x16;
            this.mniExtendPerso.Name = "mniExtendPerso";
            this.mniExtendPerso.Size = new System.Drawing.Size(220, 22);
            this.mniExtendPerso.Text = "Gia Hạn Lượt Phát Hành...";
            this.mniExtendPerso.Click += new System.EventHandler(this.btnExtendPerso_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(217, 6);
            // 
            // mniMarkBroken
            // 
            this.mniMarkBroken.Image = global::PersoMgtComponent.Properties.Resources.MarkBlue_16x16;
            this.mniMarkBroken.Name = "mniMarkBroken";
            this.mniMarkBroken.Size = new System.Drawing.Size(220, 22);
            this.mniMarkBroken.Text = "Đánh Dấu Thẻ Bị Hư...";
            this.mniMarkBroken.Click += new System.EventHandler(this.btnMarkBroken_Clicked);
            // 
            // mniUnMarkBroken
            // 
            this.mniUnMarkBroken.Image = global::PersoMgtComponent.Properties.Resources.MarkBlack_16x16;
            this.mniUnMarkBroken.Name = "mniUnMarkBroken";
            this.mniUnMarkBroken.Size = new System.Drawing.Size(220, 22);
            this.mniUnMarkBroken.Text = "Hủy Đánh Dấu Thẻ Bị Hư...";
            this.mniUnMarkBroken.Click += new System.EventHandler(this.btnUnMarkBroken_Clicked);
            // 
            // mniMarkLost
            // 
            this.mniMarkLost.Image = global::PersoMgtComponent.Properties.Resources.MarkRed_16x16;
            this.mniMarkLost.Name = "mniMarkLost";
            this.mniMarkLost.Size = new System.Drawing.Size(220, 22);
            this.mniMarkLost.Text = "Đánh Dấu Thẻ Bị Mất...";
            this.mniMarkLost.Click += new System.EventHandler(this.btnMarkLost_Clicked);
            // 
            // mniUnMarkLost
            // 
            this.mniUnMarkLost.Image = global::PersoMgtComponent.Properties.Resources.MarkBlack_16x16;
            this.mniUnMarkLost.Name = "mniUnMarkLost";
            this.mniUnMarkLost.Size = new System.Drawing.Size(220, 22);
            this.mniUnMarkLost.Text = "Hủy Đánh Dấu Thẻ Bị Mất...";
            this.mniUnMarkLost.Click += new System.EventHandler(this.btnUnMarkLost_Clicked);
            // 
            // UsrPersoMgtMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "UsrPersoMgtMain";
            this.Size = new System.Drawing.Size(1000, 600);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersoes)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.cmsPersoTable.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tmsTeacher.ResumeLayout(false);
            this.tmsTeacher.PerformLayout();
            this.cmsOrgTree.ResumeLayout(false);
            this.cmsPersoRecord.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private CommonControls.Custom.TitleLabel lblLeftAreaTitleforListPartner;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private CommonControls.Custom.TitleLabel lblRightAreaTitlePerso;
        private System.Windows.Forms.Panel pnlRightMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbxAutoCloseNode;
        private CommonControls.Custom.CommonToolStrip tmsTeacher;
        private System.Windows.Forms.ToolStripButton btnShowHide;
        private CommonControls.Custom.PagerPanel pagerPanel;
        private System.Windows.Forms.ToolStripButton btnReloadPersoes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton btnLockPerso;
        private System.Windows.Forms.ToolStripButton btnUnLockPerso;
        private System.Windows.Forms.ToolStripButton btnCancelPerso;
        private CommonControls.Custom.CommonDataGridView dgvPersoes;
        private System.Windows.Forms.ContextMenuStrip cmsOrgTree;
        private System.Windows.Forms.ToolStripMenuItem mniReloadOrgs;
        private System.Windows.Forms.ContextMenuStrip cmsPersoTable;
        private System.Windows.Forms.ToolStripMenuItem mniReloadPersoes;
        private System.Windows.Forms.ContextMenuStrip cmsPersoRecord;
        private System.Windows.Forms.ToolStripMenuItem mniLockPerso;
        private System.Windows.Forms.ToolStripMenuItem mniUnlockPerso;
        private System.Windows.Forms.ToolStripMenuItem mniCancelPerso;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem xuấtRaExcelToolStripMenuItem;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.CheckBox cbxOnlyShowRecordsNeedToUpdate;
        private System.Windows.Forms.CheckBox cbxShowCanceledPersoes;
        private System.Windows.Forms.CheckBox cbxShowTeacherColumns;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbtnSttCanceled;
        private System.Windows.Forms.RadioButton rbtnSttLocked;
        private System.Windows.Forms.RadioButton rbtnSttNormal;
        private System.Windows.Forms.DateTimePicker dtpPersoDateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpPersoDateFrom;
        private System.Windows.Forms.CheckBox cbxFilterByPersoDate;
        private System.Windows.Forms.CheckBox cbxFilterByPersoStatus;
        private System.Windows.Forms.Label lblNotification1;
        private System.Windows.Forms.TextBox tbxMemberName;
        private System.Windows.Forms.CheckBox cbxFilterByMemberName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExtendPerso;
        private System.Windows.Forms.ToolStripMenuItem mniExtendPerso;
        private System.Windows.Forms.RadioButton rbtnSttExpired;
        private System.Windows.Forms.ToolStripButton btnMarkBroken;
        private System.Windows.Forms.ToolStripButton btnUnMarkBroken;
        private System.Windows.Forms.ToolStripButton btnMarkLost;
        private System.Windows.Forms.ToolStripButton btnUnMarkLost;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mniMarkBroken;
        private System.Windows.Forms.ToolStripMenuItem mniUnMarkBroken;
        private System.Windows.Forms.ToolStripMenuItem mniMarkLost;
        private System.Windows.Forms.ToolStripMenuItem mniUnMarkLost;
        private System.Windows.Forms.TreeView trvOrganizations;
        private CommonControls.Custom.CommonToolStrip tmsOrganization;
        private System.Windows.Forms.ToolStripButton btnReloadOrgs;
        private System.Windows.Forms.Panel plHideShowOrg;
        private System.Windows.Forms.Label lblPartnerKey;
        private System.Windows.Forms.ComboBox cmbPartnerInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChipPersoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPermanentAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTemporaryAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoneNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDegree;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersoStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersoDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpirationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotes;
    }
}
