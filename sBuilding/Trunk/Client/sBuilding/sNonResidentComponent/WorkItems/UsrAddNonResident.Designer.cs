namespace sNonResidentComponent.WorkItems
{
    partial class UsrAddNonResident
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
            this.pnlParent = new System.Windows.Forms.Panel();
            this.pnlMainRight = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMeetingInfo = new System.Windows.Forms.Panel();
            this.pnlMeetingInfoInside = new System.Windows.Forms.Panel();
            this.pnlPadding1 = new System.Windows.Forms.Panel();
            this.lblOrgMeeting = new System.Windows.Forms.Label();
            this.dgvOrgList = new System.Windows.Forms.DataGridView();
            this.colOrgNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPeople = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrgId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPadding2 = new System.Windows.Forms.Panel();
            this.lblMemberSubOrg = new System.Windows.Forms.Label();
            this.dgvMemberSubOrgList = new System.Windows.Forms.DataGridView();
            this.colMemberSubOrgNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberSubOrgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberSubOrgId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMeetingList = new System.Windows.Forms.DataGridView();
            this.colMeetingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrganizationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeetingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeetingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblGuide = new System.Windows.Forms.Label();
            this.pnlLabelMeeting = new System.Windows.Forms.Panel();
            this.lblMeetingInformation = new System.Windows.Forms.Label();
            this.btnRefreshMeetingList = new System.Windows.Forms.Button();
            this.pnlPeopleInfo = new System.Windows.Forms.Panel();
            this.pnlPeopleInfoInside = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.pnlCardInside = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblGuideCardCheck = new System.Windows.Forms.Label();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.lblGuiChooseReader = new System.Windows.Forms.Label();
            this.cmbReaders = new System.Windows.Forms.ComboBox();
            this.lblChooseReader = new System.Windows.Forms.Label();
            this.lblCheckCardChip = new System.Windows.Forms.Label();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnListDevices = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblInfoNonResident = new System.Windows.Forms.Label();
            this.tbxPosition = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.tbxCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.rbtmale = new System.Windows.Forms.RadioButton();
            this.rbtfemale = new System.Windows.Forms.RadioButton();
            this.lblGender = new System.Windows.Forms.Label();
            this.tbxIdentityCard = new System.Windows.Forms.TextBox();
            this.lblPassport = new System.Windows.Forms.Label();
            this.tbxPhoneNumber = new System.Windows.Forms.TextBox();
            this.tbxFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.pnlCamera = new System.Windows.Forms.Panel();
            this.pnlCameraInside = new System.Windows.Forms.Panel();
            this.lblnonresidentIdentitycard = new System.Windows.Forms.Label();
            this.usiIDCard = new ScanComponent.View.UsrScanImage();
            this.faceCanvas = new CameraComponent.View.UsrCameraCanvas();
            this.lblNonresident = new System.Windows.Forms.Label();
            this.pnlParent.SuspendLayout();
            this.pnlMainRight.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlMeetingInfo.SuspendLayout();
            this.pnlMeetingInfoInside.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberSubOrgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeetingList)).BeginInit();
            this.pnlLabelMeeting.SuspendLayout();
            this.pnlPeopleInfo.SuspendLayout();
            this.pnlPeopleInfoInside.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.pnlCardInside.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.pnlCamera.SuspendLayout();
            this.pnlCameraInside.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlParent
            // 
            this.pnlParent.Controls.Add(this.pnlMainRight);
            this.pnlParent.Controls.Add(this.pnlCamera);
            this.pnlParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParent.Location = new System.Drawing.Point(6, 6);
            this.pnlParent.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlParent.Name = "pnlParent";
            this.pnlParent.Size = new System.Drawing.Size(1188, 588);
            this.pnlParent.TabIndex = 0;
            // 
            // pnlMainRight
            // 
            this.pnlMainRight.Controls.Add(this.pnlMain);
            this.pnlMainRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainRight.Location = new System.Drawing.Point(0, 0);
            this.pnlMainRight.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlMainRight.Name = "pnlMainRight";
            this.pnlMainRight.Size = new System.Drawing.Size(788, 588);
            this.pnlMainRight.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlMeetingInfo);
            this.pnlMain.Controls.Add(this.pnlPeopleInfo);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(788, 588);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlMeetingInfo
            // 
            this.pnlMeetingInfo.Controls.Add(this.pnlMeetingInfoInside);
            this.pnlMeetingInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMeetingInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlMeetingInfo.Name = "pnlMeetingInfo";
            this.pnlMeetingInfo.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlMeetingInfo.Size = new System.Drawing.Size(488, 588);
            this.pnlMeetingInfo.TabIndex = 0;
            // 
            // pnlMeetingInfoInside
            // 
            this.pnlMeetingInfoInside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMeetingInfoInside.Controls.Add(this.pnlPadding1);
            this.pnlMeetingInfoInside.Controls.Add(this.lblOrgMeeting);
            this.pnlMeetingInfoInside.Controls.Add(this.dgvOrgList);
            this.pnlMeetingInfoInside.Controls.Add(this.pnlPadding2);
            this.pnlMeetingInfoInside.Controls.Add(this.lblMemberSubOrg);
            this.pnlMeetingInfoInside.Controls.Add(this.dgvMemberSubOrgList);
            this.pnlMeetingInfoInside.Controls.Add(this.dgvMeetingList);
            this.pnlMeetingInfoInside.Controls.Add(this.lblGuide);
            this.pnlMeetingInfoInside.Controls.Add(this.pnlLabelMeeting);
            this.pnlMeetingInfoInside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMeetingInfoInside.Location = new System.Drawing.Point(0, 0);
            this.pnlMeetingInfoInside.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlMeetingInfoInside.Name = "pnlMeetingInfoInside";
            this.pnlMeetingInfoInside.Size = new System.Drawing.Size(485, 588);
            this.pnlMeetingInfoInside.TabIndex = 0;
            // 
            // pnlPadding1
            // 
            this.pnlPadding1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPadding1.Location = new System.Drawing.Point(0, 122);
            this.pnlPadding1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlPadding1.Name = "pnlPadding1";
            this.pnlPadding1.Size = new System.Drawing.Size(483, 9);
            this.pnlPadding1.TabIndex = 5;
            // 
            // lblOrgMeeting
            // 
            this.lblOrgMeeting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblOrgMeeting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblOrgMeeting.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrgMeeting.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblOrgMeeting.Location = new System.Drawing.Point(0, 131);
            this.lblOrgMeeting.Margin = new System.Windows.Forms.Padding(3);
            this.lblOrgMeeting.Name = "lblOrgMeeting";
            this.lblOrgMeeting.Size = new System.Drawing.Size(483, 28);
            this.lblOrgMeeting.TabIndex = 6;
            this.lblOrgMeeting.Text = "ĐƠN VỊ LIÊN HỆ";
            this.lblOrgMeeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvOrgList
            // 
            this.dgvOrgList.AllowDrop = true;
            this.dgvOrgList.AllowUserToAddRows = false;
            this.dgvOrgList.AllowUserToDeleteRows = false;
            this.dgvOrgList.AllowUserToResizeRows = false;
            this.dgvOrgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrgList.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrgList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrgList.ColumnHeadersHeight = 30;
            this.dgvOrgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrgNo,
            this.colIsPeople,
            this.colOrgName,
            this.colOrgId});
            this.dgvOrgList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvOrgList.Enabled = false;
            this.dgvOrgList.Location = new System.Drawing.Point(0, 159);
            this.dgvOrgList.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.dgvOrgList.MultiSelect = false;
            this.dgvOrgList.Name = "dgvOrgList";
            this.dgvOrgList.ReadOnly = true;
            this.dgvOrgList.RowHeadersVisible = false;
            this.dgvOrgList.RowHeadersWidth = 40;
            this.dgvOrgList.RowTemplate.Height = 33;
            this.dgvOrgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrgList.Size = new System.Drawing.Size(483, 170);
            this.dgvOrgList.TabIndex = 7;
            this.dgvOrgList.TabStop = false;
            // 
            // colOrgNo
            // 
            this.colOrgNo.DataPropertyName = "colOrgNo";
            this.colOrgNo.FillWeight = 8F;
            this.colOrgNo.HeaderText = "STT";
            this.colOrgNo.Name = "colOrgNo";
            this.colOrgNo.ReadOnly = true;
            this.colOrgNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colIsPeople
            // 
            this.colIsPeople.DataPropertyName = "colIsPeople";
            this.colIsPeople.HeaderText = "IsPeople";
            this.colIsPeople.Name = "colIsPeople";
            this.colIsPeople.ReadOnly = true;
            this.colIsPeople.Visible = false;
            // 
            // colOrgName
            // 
            this.colOrgName.DataPropertyName = "colOrgName";
            this.colOrgName.FillWeight = 82F;
            this.colOrgName.HeaderText = "Đơn vị liên hệ";
            this.colOrgName.Name = "colOrgName";
            this.colOrgName.ReadOnly = true;
            // 
            // colOrgId
            // 
            this.colOrgId.DataPropertyName = "colOrgId";
            this.colOrgId.HeaderText = "Id";
            this.colOrgId.Name = "colOrgId";
            this.colOrgId.ReadOnly = true;
            this.colOrgId.Visible = false;
            // 
            // pnlPadding2
            // 
            this.pnlPadding2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPadding2.Location = new System.Drawing.Point(0, 329);
            this.pnlPadding2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlPadding2.Name = "pnlPadding2";
            this.pnlPadding2.Size = new System.Drawing.Size(483, 9);
            this.pnlPadding2.TabIndex = 2;
            // 
            // lblMemberSubOrg
            // 
            this.lblMemberSubOrg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblMemberSubOrg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMemberSubOrg.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblMemberSubOrg.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMemberSubOrg.Location = new System.Drawing.Point(0, 338);
            this.lblMemberSubOrg.Margin = new System.Windows.Forms.Padding(3);
            this.lblMemberSubOrg.Name = "lblMemberSubOrg";
            this.lblMemberSubOrg.Size = new System.Drawing.Size(483, 28);
            this.lblMemberSubOrg.TabIndex = 3;
            this.lblMemberSubOrg.Text = "HỌ VÀ TÊN/PHÒNG BAN";
            this.lblMemberSubOrg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvMemberSubOrgList
            // 
            this.dgvMemberSubOrgList.AllowDrop = true;
            this.dgvMemberSubOrgList.AllowUserToAddRows = false;
            this.dgvMemberSubOrgList.AllowUserToDeleteRows = false;
            this.dgvMemberSubOrgList.AllowUserToResizeRows = false;
            this.dgvMemberSubOrgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMemberSubOrgList.BackgroundColor = System.Drawing.Color.White;
            this.dgvMemberSubOrgList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMemberSubOrgList.ColumnHeadersHeight = 30;
            this.dgvMemberSubOrgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMemberSubOrgNo,
            this.colMemberSubOrgName,
            this.colMemberSubOrgId});
            this.dgvMemberSubOrgList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvMemberSubOrgList.Enabled = false;
            this.dgvMemberSubOrgList.Location = new System.Drawing.Point(0, 366);
            this.dgvMemberSubOrgList.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.dgvMemberSubOrgList.MultiSelect = false;
            this.dgvMemberSubOrgList.Name = "dgvMemberSubOrgList";
            this.dgvMemberSubOrgList.ReadOnly = true;
            this.dgvMemberSubOrgList.RowHeadersVisible = false;
            this.dgvMemberSubOrgList.RowHeadersWidth = 40;
            this.dgvMemberSubOrgList.RowTemplate.Height = 33;
            this.dgvMemberSubOrgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMemberSubOrgList.Size = new System.Drawing.Size(483, 220);
            this.dgvMemberSubOrgList.TabIndex = 4;
            this.dgvMemberSubOrgList.TabStop = false;
            // 
            // colMemberSubOrgNo
            // 
            this.colMemberSubOrgNo.DataPropertyName = "colMemberSubOrgNo";
            this.colMemberSubOrgNo.FillWeight = 8F;
            this.colMemberSubOrgNo.HeaderText = "STT";
            this.colMemberSubOrgNo.Name = "colMemberSubOrgNo";
            this.colMemberSubOrgNo.ReadOnly = true;
            this.colMemberSubOrgNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colMemberSubOrgName
            // 
            this.colMemberSubOrgName.DataPropertyName = "colMemberSubOrgName";
            this.colMemberSubOrgName.FillWeight = 82F;
            this.colMemberSubOrgName.HeaderText = "Tên";
            this.colMemberSubOrgName.Name = "colMemberSubOrgName";
            this.colMemberSubOrgName.ReadOnly = true;
            // 
            // colMemberSubOrgId
            // 
            this.colMemberSubOrgId.DataPropertyName = "colMemberSubOrgId";
            this.colMemberSubOrgId.HeaderText = "Id";
            this.colMemberSubOrgId.Name = "colMemberSubOrgId";
            this.colMemberSubOrgId.ReadOnly = true;
            this.colMemberSubOrgId.Visible = false;
            // 
            // dgvMeetingList
            // 
            this.dgvMeetingList.AllowDrop = true;
            this.dgvMeetingList.AllowUserToAddRows = false;
            this.dgvMeetingList.AllowUserToDeleteRows = false;
            this.dgvMeetingList.AllowUserToResizeRows = false;
            this.dgvMeetingList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMeetingList.BackgroundColor = System.Drawing.Color.White;
            this.dgvMeetingList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMeetingList.ColumnHeadersHeight = 30;
            this.dgvMeetingList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMeetingId,
            this.colOrganizationId,
            this.colNo,
            this.colMeetingName,
            this.colOrg,
            this.colMeetingDate,
            this.colTimeStart,
            this.colCheck});
            this.dgvMeetingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMeetingList.Location = new System.Drawing.Point(0, 61);
            this.dgvMeetingList.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.dgvMeetingList.MultiSelect = false;
            this.dgvMeetingList.Name = "dgvMeetingList";
            this.dgvMeetingList.ReadOnly = true;
            this.dgvMeetingList.RowHeadersVisible = false;
            this.dgvMeetingList.RowHeadersWidth = 40;
            this.dgvMeetingList.RowTemplate.Height = 33;
            this.dgvMeetingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeetingList.Size = new System.Drawing.Size(483, 525);
            this.dgvMeetingList.TabIndex = 1;
            // 
            // colMeetingId
            // 
            this.colMeetingId.DataPropertyName = "colMeetingId";
            this.colMeetingId.HeaderText = "Id";
            this.colMeetingId.Name = "colMeetingId";
            this.colMeetingId.ReadOnly = true;
            this.colMeetingId.Visible = false;
            // 
            // colOrganizationId
            // 
            this.colOrganizationId.DataPropertyName = "colOrganizationId";
            this.colOrganizationId.HeaderText = "OrgId";
            this.colOrganizationId.Name = "colOrganizationId";
            this.colOrganizationId.ReadOnly = true;
            this.colOrganizationId.Visible = false;
            // 
            // colNo
            // 
            this.colNo.DataPropertyName = "colNo";
            this.colNo.FillWeight = 8F;
            this.colNo.HeaderText = "STT";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            // 
            // colMeetingName
            // 
            this.colMeetingName.DataPropertyName = "colMeetingName";
            this.colMeetingName.FillWeight = 30F;
            this.colMeetingName.HeaderText = "Tên cuộc họp";
            this.colMeetingName.Name = "colMeetingName";
            this.colMeetingName.ReadOnly = true;
            // 
            // colOrg
            // 
            this.colOrg.DataPropertyName = "colOrg";
            this.colOrg.FillWeight = 19F;
            this.colOrg.HeaderText = "Đơn vị liên hệ";
            this.colOrg.Name = "colOrg";
            this.colOrg.ReadOnly = true;
            // 
            // colMeetingDate
            // 
            this.colMeetingDate.DataPropertyName = "colMeetingDate";
            this.colMeetingDate.FillWeight = 13F;
            this.colMeetingDate.HeaderText = "Ngày";
            this.colMeetingDate.Name = "colMeetingDate";
            this.colMeetingDate.ReadOnly = true;
            // 
            // colTimeStart
            // 
            this.colTimeStart.DataPropertyName = "colTimeStart";
            this.colTimeStart.FillWeight = 16F;
            this.colTimeStart.HeaderText = "Giờ bắt đầu";
            this.colTimeStart.Name = "colTimeStart";
            this.colTimeStart.ReadOnly = true;
            // 
            // colCheck
            // 
            this.colCheck.DataPropertyName = "colCheck";
            this.colCheck.FillWeight = 14F;
            this.colCheck.HeaderText = "Tham dự";
            this.colCheck.Name = "colCheck";
            this.colCheck.ReadOnly = true;
            // 
            // lblGuide
            // 
            this.lblGuide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.lblGuide.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGuide.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuide.Location = new System.Drawing.Point(0, 28);
            this.lblGuide.Margin = new System.Windows.Forms.Padding(3);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Padding = new System.Windows.Forms.Padding(3);
            this.lblGuide.Size = new System.Drawing.Size(483, 33);
            this.lblGuide.TabIndex = 0;
            this.lblGuide.Text = "Ấn ↑ để di chuyển lên. Ấn ↓ để di chuyển xuống. Ấn khoảng trắng   ̺  để chọn.";
            this.lblGuide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLabelMeeting
            // 
            this.pnlLabelMeeting.Controls.Add(this.lblMeetingInformation);
            this.pnlLabelMeeting.Controls.Add(this.btnRefreshMeetingList);
            this.pnlLabelMeeting.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLabelMeeting.Location = new System.Drawing.Point(0, 0);
            this.pnlLabelMeeting.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlLabelMeeting.Name = "pnlLabelMeeting";
            this.pnlLabelMeeting.Size = new System.Drawing.Size(483, 28);
            this.pnlLabelMeeting.TabIndex = 0;
            // 
            // lblMeetingInformation
            // 
            this.lblMeetingInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblMeetingInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMeetingInformation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblMeetingInformation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMeetingInformation.Location = new System.Drawing.Point(0, 0);
            this.lblMeetingInformation.Margin = new System.Windows.Forms.Padding(3);
            this.lblMeetingInformation.Name = "lblMeetingInformation";
            this.lblMeetingInformation.Size = new System.Drawing.Size(453, 28);
            this.lblMeetingInformation.TabIndex = 0;
            this.lblMeetingInformation.Text = "THÔNG TIN CUỘC HỌP";
            this.lblMeetingInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefreshMeetingList
            // 
            this.btnRefreshMeetingList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefreshMeetingList.Image = global::sNonResidentComponent.Properties.Resources.btnRefresh;
            this.btnRefreshMeetingList.Location = new System.Drawing.Point(453, 0);
            this.btnRefreshMeetingList.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnRefreshMeetingList.Name = "btnRefreshMeetingList";
            this.btnRefreshMeetingList.Size = new System.Drawing.Size(30, 28);
            this.btnRefreshMeetingList.TabIndex = 0;
            this.btnRefreshMeetingList.TabStop = false;
            this.btnRefreshMeetingList.UseVisualStyleBackColor = true;
            // 
            // pnlPeopleInfo
            // 
            this.pnlPeopleInfo.Controls.Add(this.pnlPeopleInfoInside);
            this.pnlPeopleInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPeopleInfo.Location = new System.Drawing.Point(488, 0);
            this.pnlPeopleInfo.Name = "pnlPeopleInfo";
            this.pnlPeopleInfo.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlPeopleInfo.Size = new System.Drawing.Size(300, 588);
            this.pnlPeopleInfo.TabIndex = 0;
            // 
            // pnlPeopleInfoInside
            // 
            this.pnlPeopleInfoInside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPeopleInfoInside.Controls.Add(this.btnRefresh);
            this.pnlPeopleInfoInside.Controls.Add(this.pnlCard);
            this.pnlPeopleInfoInside.Controls.Add(this.lblInfoNonResident);
            this.pnlPeopleInfoInside.Controls.Add(this.tbxPosition);
            this.pnlPeopleInfoInside.Controls.Add(this.lblPosition);
            this.pnlPeopleInfoInside.Controls.Add(this.tbxCompany);
            this.pnlPeopleInfoInside.Controls.Add(this.lblCompany);
            this.pnlPeopleInfoInside.Controls.Add(this.rbtmale);
            this.pnlPeopleInfoInside.Controls.Add(this.rbtfemale);
            this.pnlPeopleInfoInside.Controls.Add(this.lblGender);
            this.pnlPeopleInfoInside.Controls.Add(this.tbxIdentityCard);
            this.pnlPeopleInfoInside.Controls.Add(this.lblPassport);
            this.pnlPeopleInfoInside.Controls.Add(this.tbxPhoneNumber);
            this.pnlPeopleInfoInside.Controls.Add(this.tbxFullName);
            this.pnlPeopleInfoInside.Controls.Add(this.lblFullName);
            this.pnlPeopleInfoInside.Controls.Add(this.lblPhoneNumber);
            this.pnlPeopleInfoInside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPeopleInfoInside.Location = new System.Drawing.Point(3, 0);
            this.pnlPeopleInfoInside.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPeopleInfoInside.Name = "pnlPeopleInfoInside";
            this.pnlPeopleInfoInside.Size = new System.Drawing.Size(294, 588);
            this.pnlPeopleInfoInside.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(0, 449);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(292, 37);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // pnlCard
            // 
            this.pnlCard.Controls.Add(this.pnlCardInside);
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCard.Location = new System.Drawing.Point(0, 486);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(292, 100);
            this.pnlCard.TabIndex = 11;
            // 
            // pnlCardInside
            // 
            this.pnlCardInside.Controls.Add(this.lblStatus);
            this.pnlCardInside.Controls.Add(this.lblGuideCardCheck);
            this.pnlCardInside.Controls.Add(this.lblCurrentStatus);
            this.pnlCardInside.Controls.Add(this.lblGuiChooseReader);
            this.pnlCardInside.Controls.Add(this.cmbReaders);
            this.pnlCardInside.Controls.Add(this.lblChooseReader);
            this.pnlCardInside.Controls.Add(this.lblCheckCardChip);
            this.pnlCardInside.Controls.Add(this.pnlButton);
            this.pnlCardInside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardInside.Location = new System.Drawing.Point(0, 0);
            this.pnlCardInside.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlCardInside.Name = "pnlCardInside";
            this.pnlCardInside.Size = new System.Drawing.Size(292, 100);
            this.pnlCardInside.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(0, 69);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(292, 0);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Chưa kết nối với thiết bị đọc";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGuideCardCheck
            // 
            this.lblGuideCardCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.lblGuideCardCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGuideCardCheck.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblGuideCardCheck.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuideCardCheck.Location = new System.Drawing.Point(0, 66);
            this.lblGuideCardCheck.Name = "lblGuideCardCheck";
            this.lblGuideCardCheck.Size = new System.Drawing.Size(292, 29);
            this.lblGuideCardCheck.TabIndex = 0;
            this.lblGuideCardCheck.Text = "Vui lòng đưa thẻ vào đầu đọc thẻ để quét thông tin";
            this.lblGuideCardCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentStatus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStatus.Location = new System.Drawing.Point(0, 64);
            this.lblCurrentStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(292, 5);
            this.lblCurrentStatus.TabIndex = 0;
            this.lblCurrentStatus.Text = "Trạng thái hiện tại:";
            this.lblCurrentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrentStatus.Visible = false;
            // 
            // lblGuiChooseReader
            // 
            this.lblGuiChooseReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGuiChooseReader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuiChooseReader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGuiChooseReader.Location = new System.Drawing.Point(0, 59);
            this.lblGuiChooseReader.Margin = new System.Windows.Forms.Padding(3);
            this.lblGuiChooseReader.Name = "lblGuiChooseReader";
            this.lblGuiChooseReader.Size = new System.Drawing.Size(292, 5);
            this.lblGuiChooseReader.TabIndex = 0;
            this.lblGuiChooseReader.Text = "Nếu thiết bị của bạn không được liệt kê trong khung trên, hãy đảm bảo thiết bị đã" +
    " được kết nối đúng cách với máy tính, sau đó, nhấn nút \"Tìm Thiết Bị\".";
            this.lblGuiChooseReader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGuiChooseReader.Visible = false;
            // 
            // cmbReaders
            // 
            this.cmbReaders.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbReaders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReaders.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReaders.FormattingEnabled = true;
            this.cmbReaders.Location = new System.Drawing.Point(0, 33);
            this.cmbReaders.Name = "cmbReaders";
            this.cmbReaders.Size = new System.Drawing.Size(292, 26);
            this.cmbReaders.TabIndex = 0;
            this.cmbReaders.TabStop = false;
            this.cmbReaders.Visible = false;
            // 
            // lblChooseReader
            // 
            this.lblChooseReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChooseReader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseReader.Location = new System.Drawing.Point(0, 28);
            this.lblChooseReader.Margin = new System.Windows.Forms.Padding(0);
            this.lblChooseReader.Name = "lblChooseReader";
            this.lblChooseReader.Size = new System.Drawing.Size(292, 5);
            this.lblChooseReader.TabIndex = 0;
            this.lblChooseReader.Text = "Chọn thiết bị đọc thẻ:";
            this.lblChooseReader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblChooseReader.Visible = false;
            // 
            // lblCheckCardChip
            // 
            this.lblCheckCardChip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblCheckCardChip.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCheckCardChip.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckCardChip.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCheckCardChip.Location = new System.Drawing.Point(0, 0);
            this.lblCheckCardChip.Margin = new System.Windows.Forms.Padding(3);
            this.lblCheckCardChip.Name = "lblCheckCardChip";
            this.lblCheckCardChip.Size = new System.Drawing.Size(292, 28);
            this.lblCheckCardChip.TabIndex = 0;
            this.lblCheckCardChip.Text = "QUÉT THẺ";
            this.lblCheckCardChip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnPause);
            this.pnlButton.Controls.Add(this.btnListDevices);
            this.pnlButton.Controls.Add(this.btnStart);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 95);
            this.pnlButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(292, 5);
            this.pnlButton.TabIndex = 0;
            this.pnlButton.Visible = false;
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(197, 0);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(187, 37);
            this.btnPause.TabIndex = 0;
            this.btnPause.TabStop = false;
            this.btnPause.Text = "Tạm Ngưng";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // btnListDevices
            // 
            this.btnListDevices.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnListDevices.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListDevices.Location = new System.Drawing.Point(105, 0);
            this.btnListDevices.Name = "btnListDevices";
            this.btnListDevices.Size = new System.Drawing.Size(187, 5);
            this.btnListDevices.TabIndex = 0;
            this.btnListDevices.TabStop = false;
            this.btnListDevices.Text = "Tìm Thiết Bị";
            this.btnListDevices.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStart.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(0, 0);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(187, 5);
            this.btnStart.TabIndex = 0;
            this.btnStart.TabStop = false;
            this.btnStart.Text = "Bắt Đầu";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // lblInfoNonResident
            // 
            this.lblInfoNonResident.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblInfoNonResident.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfoNonResident.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblInfoNonResident.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInfoNonResident.Location = new System.Drawing.Point(0, 0);
            this.lblInfoNonResident.Margin = new System.Windows.Forms.Padding(3);
            this.lblInfoNonResident.Name = "lblInfoNonResident";
            this.lblInfoNonResident.Size = new System.Drawing.Size(292, 28);
            this.lblInfoNonResident.TabIndex = 0;
            this.lblInfoNonResident.Text = "THÔNG TIN KHÁCH VÃNG LAI";
            this.lblInfoNonResident.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxPosition
            // 
            this.tbxPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPosition.BackColor = System.Drawing.Color.White;
            this.tbxPosition.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPosition.Location = new System.Drawing.Point(82, 124);
            this.tbxPosition.Margin = new System.Windows.Forms.Padding(6, 11, 12, 11);
            this.tbxPosition.MaxLength = 250;
            this.tbxPosition.Name = "tbxPosition";
            this.tbxPosition.Size = new System.Drawing.Size(198, 24);
            this.tbxPosition.TabIndex = 5;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(3, 124);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(66, 17);
            this.lblPosition.TabIndex = 0;
            this.lblPosition.Text = "Chức vụ:";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxCompany
            // 
            this.tbxCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCompany.BackColor = System.Drawing.Color.White;
            this.tbxCompany.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCompany.Location = new System.Drawing.Point(82, 83);
            this.tbxCompany.Margin = new System.Windows.Forms.Padding(6, 11, 12, 11);
            this.tbxCompany.MaxLength = 250;
            this.tbxCompany.Name = "tbxCompany";
            this.tbxCompany.Size = new System.Drawing.Size(198, 24);
            this.tbxCompany.TabIndex = 4;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(3, 83);
            this.lblCompany.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(53, 17);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Đơn vị:";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbtmale
            // 
            this.rbtmale.AutoSize = true;
            this.rbtmale.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtmale.Location = new System.Drawing.Point(128, 165);
            this.rbtmale.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.rbtmale.Name = "rbtmale";
            this.rbtmale.Size = new System.Drawing.Size(54, 21);
            this.rbtmale.TabIndex = 7;
            this.rbtmale.TabStop = true;
            this.rbtmale.Text = "Nam";
            this.rbtmale.UseVisualStyleBackColor = true;
            // 
            // rbtfemale
            // 
            this.rbtfemale.AutoSize = true;
            this.rbtfemale.Checked = true;
            this.rbtfemale.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtfemale.Location = new System.Drawing.Point(82, 165);
            this.rbtfemale.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.rbtfemale.Name = "rbtfemale";
            this.rbtfemale.Size = new System.Drawing.Size(44, 21);
            this.rbtfemale.TabIndex = 6;
            this.rbtfemale.TabStop = true;
            this.rbtfemale.Text = "Nữ";
            this.rbtfemale.UseVisualStyleBackColor = true;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(3, 163);
            this.lblGender.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(61, 17);
            this.lblGender.TabIndex = 0;
            this.lblGender.Text = "Giới tính:";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxIdentityCard
            // 
            this.tbxIdentityCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxIdentityCard.BackColor = System.Drawing.Color.White;
            this.tbxIdentityCard.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxIdentityCard.Location = new System.Drawing.Point(82, 205);
            this.tbxIdentityCard.Margin = new System.Windows.Forms.Padding(6, 11, 12, 11);
            this.tbxIdentityCard.MaxLength = 20;
            this.tbxIdentityCard.Name = "tbxIdentityCard";
            this.tbxIdentityCard.Size = new System.Drawing.Size(198, 24);
            this.tbxIdentityCard.TabIndex = 8;
            // 
            // lblPassport
            // 
            this.lblPassport.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassport.Location = new System.Drawing.Point(3, 192);
            this.lblPassport.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblPassport.Name = "lblPassport";
            this.lblPassport.Size = new System.Drawing.Size(70, 49);
            this.lblPassport.TabIndex = 0;
            this.lblPassport.Text = "CMND/ Passport:";
            this.lblPassport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxPhoneNumber
            // 
            this.tbxPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPhoneNumber.BackColor = System.Drawing.Color.White;
            this.tbxPhoneNumber.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPhoneNumber.Location = new System.Drawing.Point(82, 246);
            this.tbxPhoneNumber.Margin = new System.Windows.Forms.Padding(6, 11, 12, 11);
            this.tbxPhoneNumber.MaxLength = 13;
            this.tbxPhoneNumber.Name = "tbxPhoneNumber";
            this.tbxPhoneNumber.Size = new System.Drawing.Size(198, 24);
            this.tbxPhoneNumber.TabIndex = 9;
            // 
            // tbxFullName
            // 
            this.tbxFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxFullName.BackColor = System.Drawing.Color.White;
            this.tbxFullName.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFullName.Location = new System.Drawing.Point(82, 42);
            this.tbxFullName.Margin = new System.Windows.Forms.Padding(6, 11, 12, 11);
            this.tbxFullName.MaxLength = 48;
            this.tbxFullName.Name = "tbxFullName";
            this.tbxFullName.Size = new System.Drawing.Size(198, 24);
            this.tbxFullName.TabIndex = 3;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(3, 42);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(73, 17);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "Họ và tên:";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(0, 246);
            this.lblPhoneNumber.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(74, 17);
            this.lblPhoneNumber.TabIndex = 0;
            this.lblPhoneNumber.Text = "Điện thoại:";
            this.lblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCamera
            // 
            this.pnlCamera.Controls.Add(this.pnlCameraInside);
            this.pnlCamera.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCamera.Location = new System.Drawing.Point(788, 0);
            this.pnlCamera.Name = "pnlCamera";
            this.pnlCamera.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnlCamera.Size = new System.Drawing.Size(400, 588);
            this.pnlCamera.TabIndex = 0;
            // 
            // pnlCameraInside
            // 
            this.pnlCameraInside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCameraInside.Controls.Add(this.lblnonresidentIdentitycard);
            this.pnlCameraInside.Controls.Add(this.usiIDCard);
            this.pnlCameraInside.Controls.Add(this.faceCanvas);
            this.pnlCameraInside.Controls.Add(this.lblNonresident);
            this.pnlCameraInside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCameraInside.Location = new System.Drawing.Point(3, 0);
            this.pnlCameraInside.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlCameraInside.Name = "pnlCameraInside";
            this.pnlCameraInside.Size = new System.Drawing.Size(397, 588);
            this.pnlCameraInside.TabIndex = 0;
            // 
            // lblnonresidentIdentitycard
            // 
            this.lblnonresidentIdentitycard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.lblnonresidentIdentitycard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblnonresidentIdentitycard.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblnonresidentIdentitycard.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnonresidentIdentitycard.Location = new System.Drawing.Point(0, 276);
            this.lblnonresidentIdentitycard.Margin = new System.Windows.Forms.Padding(0);
            this.lblnonresidentIdentitycard.Name = "lblnonresidentIdentitycard";
            this.lblnonresidentIdentitycard.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.lblnonresidentIdentitycard.Size = new System.Drawing.Size(395, 29);
            this.lblnonresidentIdentitycard.TabIndex = 5;
            this.lblnonresidentIdentitycard.Text = "Vui lòng scan CMND";
            this.lblnonresidentIdentitycard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usiIDCard
            // 
            this.usiIDCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.usiIDCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.usiIDCard.Location = new System.Drawing.Point(0, 0);
            this.usiIDCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.usiIDCard.Name = "usiIDCard";
            this.usiIDCard.Size = new System.Drawing.Size(395, 276);
            this.usiIDCard.TabIndex = 4;
            // 
            // faceCanvas
            // 
            this.faceCanvas.AutoScroll = true;
            this.faceCanvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.faceCanvas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.faceCanvas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.faceCanvas.Location = new System.Drawing.Point(0, 281);
            this.faceCanvas.Name = "faceCanvas";
            this.faceCanvas.Size = new System.Drawing.Size(395, 276);
            this.faceCanvas.TabIndex = 1;
            this.faceCanvas.TabStop = false;
            // 
            // lblNonresident
            // 
            this.lblNonresident.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.lblNonresident.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNonresident.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblNonresident.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNonresident.Location = new System.Drawing.Point(0, 557);
            this.lblNonresident.Margin = new System.Windows.Forms.Padding(0);
            this.lblNonresident.Name = "lblNonresident";
            this.lblNonresident.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblNonresident.Size = new System.Drawing.Size(395, 29);
            this.lblNonresident.TabIndex = 0;
            this.lblNonresident.Text = "Vui lòng yêu cầu khách hướng mặt vào camera";
            this.lblNonresident.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsrAddNonResident
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlParent);
            this.Name = "UsrAddNonResident";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(1200, 600);
            this.pnlParent.ResumeLayout(false);
            this.pnlMainRight.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMeetingInfo.ResumeLayout(false);
            this.pnlMeetingInfoInside.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberSubOrgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeetingList)).EndInit();
            this.pnlLabelMeeting.ResumeLayout(false);
            this.pnlPeopleInfo.ResumeLayout(false);
            this.pnlPeopleInfoInside.ResumeLayout(false);
            this.pnlPeopleInfoInside.PerformLayout();
            this.pnlCard.ResumeLayout(false);
            this.pnlCardInside.ResumeLayout(false);
            this.pnlButton.ResumeLayout(false);
            this.pnlCamera.ResumeLayout(false);
            this.pnlCameraInside.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlParent;
        private System.Windows.Forms.Panel pnlMainRight;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlCamera;
        private System.Windows.Forms.Panel pnlPeopleInfo;
        private System.Windows.Forms.Panel pnlPeopleInfoInside;
        private System.Windows.Forms.Label lblInfoNonResident;
        private System.Windows.Forms.TextBox tbxPosition;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox tbxCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.RadioButton rbtmale;
        private System.Windows.Forms.RadioButton rbtfemale;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox tbxIdentityCard;
        private System.Windows.Forms.Label lblPassport;
        private System.Windows.Forms.TextBox tbxPhoneNumber;
        private System.Windows.Forms.TextBox tbxFullName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Panel pnlCameraInside;
        private System.Windows.Forms.Label lblNonresident;
        private System.Windows.Forms.Panel pnlMeetingInfo;
        private System.Windows.Forms.Panel pnlMeetingInfoInside;
        private CameraComponent.View.UsrCameraCanvas faceCanvas;
        private System.Windows.Forms.Label lblnonresidentIdentitycard;
        private ScanComponent.View.UsrScanImage usiIDCard;
        private System.Windows.Forms.DataGridView dgvMeetingList;
        private System.Windows.Forms.Label lblGuide;
        private System.Windows.Forms.Panel pnlLabelMeeting;
        private System.Windows.Forms.Button btnRefreshMeetingList;
        private System.Windows.Forms.Label lblMeetingInformation;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Panel pnlCardInside;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblGuideCardCheck;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Label lblGuiChooseReader;
        private System.Windows.Forms.ComboBox cmbReaders;
        private System.Windows.Forms.Label lblChooseReader;
        private System.Windows.Forms.Label lblCheckCardChip;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnListDevices;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel pnlPadding1;
        private System.Windows.Forms.Label lblOrgMeeting;
        private System.Windows.Forms.DataGridView dgvOrgList;
        private System.Windows.Forms.Panel pnlPadding2;
        private System.Windows.Forms.Label lblMemberSubOrg;
        private System.Windows.Forms.DataGridView dgvMemberSubOrgList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeetingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrganizationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeetingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeetingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeStart;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberSubOrgNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberSubOrgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberSubOrgId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsPeople;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgId;
    }
}
