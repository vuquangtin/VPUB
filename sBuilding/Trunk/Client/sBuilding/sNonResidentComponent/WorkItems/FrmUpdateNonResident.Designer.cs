namespace sNonResidentComponent.WorkItems
{
    partial class FrmUpdateNonResident
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlParent = new System.Windows.Forms.Panel();
            this.pnlMainRight = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMeetingInfo = new System.Windows.Forms.Panel();
            this.pnlMeetingInfoInside = new System.Windows.Forms.Panel();
            this.dgvMeetingList = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeetingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeetingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPadding = new System.Windows.Forms.Panel();
            this.lblOrgMeeting = new System.Windows.Forms.Label();
            this.dgvOrgList = new System.Windows.Forms.DataGridView();
            this.colOrgNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlReason = new System.Windows.Forms.Panel();
            this.tbxReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblMeetingInformation = new System.Windows.Forms.Label();
            this.pnlPeopleInfo = new System.Windows.Forms.Panel();
            this.pnlPeopleInfoInside = new System.Windows.Forms.Panel();
            this.lblPassport = new System.Windows.Forms.Label();
            this.btnUpdateInfo = new System.Windows.Forms.Button();
            this.lblInfoNonResident = new System.Windows.Forms.Label();
            this.tbxPosition = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.tbxCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.rbtmale = new System.Windows.Forms.RadioButton();
            this.rbtfemale = new System.Windows.Forms.RadioButton();
            this.lblGender = new System.Windows.Forms.Label();
            this.tbxIdentityCard = new System.Windows.Forms.TextBox();
            this.tbxPhoneNumber = new System.Windows.Forms.TextBox();
            this.tbxFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.pnlButtonInside = new System.Windows.Forms.Panel();
            this.lblMessageExit = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.pnlCamera = new System.Windows.Forms.Panel();
            this.pnlCameraInside = new System.Windows.Forms.Panel();
            this.picMember = new System.Windows.Forms.PictureBox();
            this.lblImagenonresidentIdentitycard = new System.Windows.Forms.Label();
            this.picMemberIdentityCard = new System.Windows.Forms.PictureBox();
            this.lblImageNonresident = new System.Windows.Forms.Label();
            this.pnlParent.SuspendLayout();
            this.pnlMainRight.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlMeetingInfo.SuspendLayout();
            this.pnlMeetingInfoInside.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeetingList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrgList)).BeginInit();
            this.pnlReason.SuspendLayout();
            this.pnlPeopleInfo.SuspendLayout();
            this.pnlPeopleInfoInside.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.pnlButtonInside.SuspendLayout();
            this.pnlCamera.SuspendLayout();
            this.pnlCameraInside.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMemberIdentityCard)).BeginInit();
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
            this.pnlParent.Size = new System.Drawing.Size(1228, 628);
            this.pnlParent.TabIndex = 2;
            // 
            // pnlMainRight
            // 
            this.pnlMainRight.Controls.Add(this.pnlMain);
            this.pnlMainRight.Controls.Add(this.pnlButton);
            this.pnlMainRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainRight.Location = new System.Drawing.Point(0, 0);
            this.pnlMainRight.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlMainRight.Name = "pnlMainRight";
            this.pnlMainRight.Size = new System.Drawing.Size(828, 628);
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
            this.pnlMain.Size = new System.Drawing.Size(828, 581);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlMeetingInfo
            // 
            this.pnlMeetingInfo.Controls.Add(this.pnlMeetingInfoInside);
            this.pnlMeetingInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMeetingInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlMeetingInfo.Name = "pnlMeetingInfo";
            this.pnlMeetingInfo.Padding = new System.Windows.Forms.Padding(0, 0, 3, 6);
            this.pnlMeetingInfo.Size = new System.Drawing.Size(558, 581);
            this.pnlMeetingInfo.TabIndex = 0;
            // 
            // pnlMeetingInfoInside
            // 
            this.pnlMeetingInfoInside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMeetingInfoInside.Controls.Add(this.dgvMeetingList);
            this.pnlMeetingInfoInside.Controls.Add(this.pnlPadding);
            this.pnlMeetingInfoInside.Controls.Add(this.lblOrgMeeting);
            this.pnlMeetingInfoInside.Controls.Add(this.dgvOrgList);
            this.pnlMeetingInfoInside.Controls.Add(this.pnlReason);
            this.pnlMeetingInfoInside.Controls.Add(this.lblMeetingInformation);
            this.pnlMeetingInfoInside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMeetingInfoInside.Location = new System.Drawing.Point(0, 0);
            this.pnlMeetingInfoInside.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlMeetingInfoInside.Name = "pnlMeetingInfoInside";
            this.pnlMeetingInfoInside.Size = new System.Drawing.Size(555, 575);
            this.pnlMeetingInfoInside.TabIndex = 0;
            // 
            // dgvMeetingList
            // 
            this.dgvMeetingList.AllowUserToAddRows = false;
            this.dgvMeetingList.AllowUserToDeleteRows = false;
            this.dgvMeetingList.AllowUserToResizeRows = false;
            this.dgvMeetingList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMeetingList.BackgroundColor = System.Drawing.Color.White;
            this.dgvMeetingList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMeetingList.ColumnHeadersHeight = 30;
            this.dgvMeetingList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colMeetingName,
            this.colOrg,
            this.colMeetingDate,
            this.colTimeStart});
            this.dgvMeetingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMeetingList.Enabled = false;
            this.dgvMeetingList.Location = new System.Drawing.Point(0, 28);
            this.dgvMeetingList.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.dgvMeetingList.MultiSelect = false;
            this.dgvMeetingList.Name = "dgvMeetingList";
            this.dgvMeetingList.ReadOnly = true;
            this.dgvMeetingList.RowHeadersVisible = false;
            this.dgvMeetingList.RowHeadersWidth = 40;
            this.dgvMeetingList.RowTemplate.Height = 33;
            this.dgvMeetingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeetingList.Size = new System.Drawing.Size(553, 180);
            this.dgvMeetingList.TabIndex = 4;
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
            this.colMeetingName.FillWeight = 35F;
            this.colMeetingName.HeaderText = "Tên cuộc họp";
            this.colMeetingName.Name = "colMeetingName";
            this.colMeetingName.ReadOnly = true;
            // 
            // colOrg
            // 
            this.colOrg.DataPropertyName = "colOrg";
            this.colOrg.FillWeight = 20F;
            this.colOrg.HeaderText = "Đơn vị liên hệ";
            this.colOrg.Name = "colOrg";
            this.colOrg.ReadOnly = true;
            // 
            // colMeetingDate
            // 
            this.colMeetingDate.DataPropertyName = "colMeetingDate";
            this.colMeetingDate.FillWeight = 17F;
            this.colMeetingDate.HeaderText = "Ngày";
            this.colMeetingDate.Name = "colMeetingDate";
            this.colMeetingDate.ReadOnly = true;
            // 
            // colTimeStart
            // 
            this.colTimeStart.DataPropertyName = "colTimeStart";
            this.colTimeStart.FillWeight = 20F;
            this.colTimeStart.HeaderText = "Giờ bắt đầu";
            this.colTimeStart.Name = "colTimeStart";
            this.colTimeStart.ReadOnly = true;
            // 
            // pnlPadding
            // 
            this.pnlPadding.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPadding.Location = new System.Drawing.Point(0, 208);
            this.pnlPadding.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlPadding.Name = "pnlPadding";
            this.pnlPadding.Size = new System.Drawing.Size(553, 10);
            this.pnlPadding.TabIndex = 2;
            // 
            // lblOrgMeeting
            // 
            this.lblOrgMeeting.BackColor = System.Drawing.Color.Transparent;
            this.lblOrgMeeting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblOrgMeeting.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrgMeeting.ForeColor = System.Drawing.Color.Black;
            this.lblOrgMeeting.Location = new System.Drawing.Point(0, 218);
            this.lblOrgMeeting.Margin = new System.Windows.Forms.Padding(3);
            this.lblOrgMeeting.Name = "lblOrgMeeting";
            this.lblOrgMeeting.Size = new System.Drawing.Size(553, 28);
            this.lblOrgMeeting.TabIndex = 3;
            this.lblOrgMeeting.Text = "ĐƠN VỊ LIÊN HỆ";
            this.lblOrgMeeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvOrgList
            // 
            this.dgvOrgList.AllowUserToAddRows = false;
            this.dgvOrgList.AllowUserToDeleteRows = false;
            this.dgvOrgList.AllowUserToResizeRows = false;
            this.dgvOrgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrgList.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrgList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrgList.ColumnHeadersHeight = 30;
            this.dgvOrgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrgNo,
            this.colOrgName});
            this.dgvOrgList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvOrgList.Enabled = false;
            this.dgvOrgList.Location = new System.Drawing.Point(0, 246);
            this.dgvOrgList.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.dgvOrgList.MultiSelect = false;
            this.dgvOrgList.Name = "dgvOrgList";
            this.dgvOrgList.ReadOnly = true;
            this.dgvOrgList.RowHeadersVisible = false;
            this.dgvOrgList.RowHeadersWidth = 40;
            this.dgvOrgList.RowTemplate.Height = 33;
            this.dgvOrgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrgList.Size = new System.Drawing.Size(553, 234);
            this.dgvOrgList.TabIndex = 0;
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
            // colOrgName
            // 
            this.colOrgName.DataPropertyName = "colOrgName";
            this.colOrgName.FillWeight = 82F;
            this.colOrgName.HeaderText = "Đơn vị liên hệ";
            this.colOrgName.Name = "colOrgName";
            this.colOrgName.ReadOnly = true;
            // 
            // pnlReason
            // 
            this.pnlReason.Controls.Add(this.tbxReason);
            this.pnlReason.Controls.Add(this.lblReason);
            this.pnlReason.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlReason.Location = new System.Drawing.Point(0, 480);
            this.pnlReason.Margin = new System.Windows.Forms.Padding(0);
            this.pnlReason.Name = "pnlReason";
            this.pnlReason.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.pnlReason.Size = new System.Drawing.Size(553, 93);
            this.pnlReason.TabIndex = 0;
            // 
            // tbxReason
            // 
            this.tbxReason.BackColor = System.Drawing.Color.White;
            this.tbxReason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxReason.Enabled = false;
            this.tbxReason.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxReason.Location = new System.Drawing.Point(60, 6);
            this.tbxReason.Margin = new System.Windows.Forms.Padding(6, 11, 12, 11);
            this.tbxReason.MaxLength = 250;
            this.tbxReason.Multiline = true;
            this.tbxReason.Name = "tbxReason";
            this.tbxReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxReason.Size = new System.Drawing.Size(493, 81);
            this.tbxReason.TabIndex = 2;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblReason.Enabled = false;
            this.lblReason.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.Location = new System.Drawing.Point(6, 6);
            this.lblReason.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(54, 19);
            this.lblReason.TabIndex = 0;
            this.lblReason.Text = "Lý do:";
            this.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMeetingInformation
            // 
            this.lblMeetingInformation.BackColor = System.Drawing.Color.Transparent;
            this.lblMeetingInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMeetingInformation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblMeetingInformation.ForeColor = System.Drawing.Color.Black;
            this.lblMeetingInformation.Location = new System.Drawing.Point(0, 0);
            this.lblMeetingInformation.Margin = new System.Windows.Forms.Padding(3);
            this.lblMeetingInformation.Name = "lblMeetingInformation";
            this.lblMeetingInformation.Size = new System.Drawing.Size(553, 28);
            this.lblMeetingInformation.TabIndex = 0;
            this.lblMeetingInformation.Text = "THÔNG TIN HỘI HỌP";
            this.lblMeetingInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPeopleInfo
            // 
            this.pnlPeopleInfo.Controls.Add(this.pnlPeopleInfoInside);
            this.pnlPeopleInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPeopleInfo.Location = new System.Drawing.Point(558, 0);
            this.pnlPeopleInfo.Name = "pnlPeopleInfo";
            this.pnlPeopleInfo.Padding = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.pnlPeopleInfo.Size = new System.Drawing.Size(270, 581);
            this.pnlPeopleInfo.TabIndex = 0;
            // 
            // pnlPeopleInfoInside
            // 
            this.pnlPeopleInfoInside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPeopleInfoInside.Controls.Add(this.lblPassport);
            this.pnlPeopleInfoInside.Controls.Add(this.btnUpdateInfo);
            this.pnlPeopleInfoInside.Controls.Add(this.lblInfoNonResident);
            this.pnlPeopleInfoInside.Controls.Add(this.tbxPosition);
            this.pnlPeopleInfoInside.Controls.Add(this.lblPosition);
            this.pnlPeopleInfoInside.Controls.Add(this.tbxCompany);
            this.pnlPeopleInfoInside.Controls.Add(this.lblCompany);
            this.pnlPeopleInfoInside.Controls.Add(this.rbtmale);
            this.pnlPeopleInfoInside.Controls.Add(this.rbtfemale);
            this.pnlPeopleInfoInside.Controls.Add(this.lblGender);
            this.pnlPeopleInfoInside.Controls.Add(this.tbxIdentityCard);
            this.pnlPeopleInfoInside.Controls.Add(this.tbxPhoneNumber);
            this.pnlPeopleInfoInside.Controls.Add(this.tbxFullName);
            this.pnlPeopleInfoInside.Controls.Add(this.lblFullName);
            this.pnlPeopleInfoInside.Controls.Add(this.lblPhoneNumber);
            this.pnlPeopleInfoInside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPeopleInfoInside.Location = new System.Drawing.Point(3, 0);
            this.pnlPeopleInfoInside.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPeopleInfoInside.Name = "pnlPeopleInfoInside";
            this.pnlPeopleInfoInside.Size = new System.Drawing.Size(264, 575);
            this.pnlPeopleInfoInside.TabIndex = 0;
            // 
            // lblPassport
            // 
            this.lblPassport.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassport.Location = new System.Drawing.Point(3, 192);
            this.lblPassport.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblPassport.Name = "lblPassport";
            this.lblPassport.Size = new System.Drawing.Size(70, 49);
            this.lblPassport.TabIndex = 18;
            this.lblPassport.Text = "CMND/ Passport:";
            this.lblPassport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUpdateInfo
            // 
            this.btnUpdateInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateInfo.Location = new System.Drawing.Point(82, 534);
            this.btnUpdateInfo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnUpdateInfo.Name = "btnUpdateInfo";
            this.btnUpdateInfo.Size = new System.Drawing.Size(107, 33);
            this.btnUpdateInfo.TabIndex = 17;
            this.btnUpdateInfo.Text = "Cập nhật";
            this.btnUpdateInfo.UseVisualStyleBackColor = true;
            this.btnUpdateInfo.Visible = false;
            // 
            // lblInfoNonResident
            // 
            this.lblInfoNonResident.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoNonResident.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfoNonResident.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblInfoNonResident.ForeColor = System.Drawing.Color.Black;
            this.lblInfoNonResident.Location = new System.Drawing.Point(0, 0);
            this.lblInfoNonResident.Margin = new System.Windows.Forms.Padding(3);
            this.lblInfoNonResident.Name = "lblInfoNonResident";
            this.lblInfoNonResident.Size = new System.Drawing.Size(262, 28);
            this.lblInfoNonResident.TabIndex = 0;
            this.lblInfoNonResident.Text = "THÔNG TIN KHÁCH VÃNG LAI";
            this.lblInfoNonResident.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxPosition
            // 
            this.tbxPosition.BackColor = System.Drawing.Color.White;
            this.tbxPosition.Enabled = false;
            this.tbxPosition.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPosition.Location = new System.Drawing.Point(82, 124);
            this.tbxPosition.Margin = new System.Windows.Forms.Padding(6, 11, 12, 11);
            this.tbxPosition.MaxLength = 250;
            this.tbxPosition.Name = "tbxPosition";
            this.tbxPosition.Size = new System.Drawing.Size(170, 24);
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
            this.tbxCompany.BackColor = System.Drawing.Color.White;
            this.tbxCompany.Enabled = false;
            this.tbxCompany.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCompany.Location = new System.Drawing.Point(82, 83);
            this.tbxCompany.Margin = new System.Windows.Forms.Padding(6, 11, 12, 11);
            this.tbxCompany.MaxLength = 250;
            this.tbxCompany.Name = "tbxCompany";
            this.tbxCompany.Size = new System.Drawing.Size(170, 24);
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
            this.rbtmale.Enabled = false;
            this.rbtmale.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtmale.Location = new System.Drawing.Point(132, 165);
            this.rbtmale.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.rbtmale.Name = "rbtmale";
            this.rbtmale.Size = new System.Drawing.Size(54, 21);
            this.rbtmale.TabIndex = 7;
            this.rbtmale.Text = "Nam";
            this.rbtmale.UseVisualStyleBackColor = true;
            // 
            // rbtfemale
            // 
            this.rbtfemale.AutoSize = true;
            this.rbtfemale.Checked = true;
            this.rbtfemale.Enabled = false;
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
            this.tbxIdentityCard.BackColor = System.Drawing.Color.White;
            this.tbxIdentityCard.Enabled = false;
            this.tbxIdentityCard.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxIdentityCard.Location = new System.Drawing.Point(82, 205);
            this.tbxIdentityCard.Margin = new System.Windows.Forms.Padding(6, 11, 12, 11);
            this.tbxIdentityCard.MaxLength = 10;
            this.tbxIdentityCard.Name = "tbxIdentityCard";
            this.tbxIdentityCard.Size = new System.Drawing.Size(170, 24);
            this.tbxIdentityCard.TabIndex = 8;
            // 
            // tbxPhoneNumber
            // 
            this.tbxPhoneNumber.BackColor = System.Drawing.Color.White;
            this.tbxPhoneNumber.Enabled = false;
            this.tbxPhoneNumber.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPhoneNumber.Location = new System.Drawing.Point(82, 246);
            this.tbxPhoneNumber.Margin = new System.Windows.Forms.Padding(6, 11, 12, 11);
            this.tbxPhoneNumber.MaxLength = 13;
            this.tbxPhoneNumber.Name = "tbxPhoneNumber";
            this.tbxPhoneNumber.Size = new System.Drawing.Size(170, 24);
            this.tbxPhoneNumber.TabIndex = 9;
            // 
            // tbxFullName
            // 
            this.tbxFullName.BackColor = System.Drawing.Color.White;
            this.tbxFullName.Enabled = false;
            this.tbxFullName.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFullName.Location = new System.Drawing.Point(82, 42);
            this.tbxFullName.Margin = new System.Windows.Forms.Padding(6, 11, 12, 11);
            this.tbxFullName.MaxLength = 48;
            this.tbxFullName.Name = "tbxFullName";
            this.tbxFullName.Size = new System.Drawing.Size(170, 24);
            this.tbxFullName.TabIndex = 3;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(3, 41);
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
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.pnlButtonInside);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 581);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlButton.Size = new System.Drawing.Size(828, 47);
            this.pnlButton.TabIndex = 0;
            // 
            // pnlButtonInside
            // 
            this.pnlButtonInside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlButtonInside.Controls.Add(this.lblMessageExit);
            this.pnlButtonInside.Controls.Add(this.btnCancel);
            this.pnlButtonInside.Controls.Add(this.btnConfirm);
            this.pnlButtonInside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtonInside.Location = new System.Drawing.Point(0, 0);
            this.pnlButtonInside.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlButtonInside.Name = "pnlButtonInside";
            this.pnlButtonInside.Size = new System.Drawing.Size(825, 47);
            this.pnlButtonInside.TabIndex = 0;
            // 
            // lblMessageExit
            // 
            this.lblMessageExit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMessageExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.lblMessageExit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMessageExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageExit.ForeColor = System.Drawing.Color.Black;
            this.lblMessageExit.Location = new System.Drawing.Point(0, 6);
            this.lblMessageExit.Name = "lblMessageExit";
            this.lblMessageExit.Size = new System.Drawing.Size(553, 33);
            this.lblMessageExit.TabIndex = 22;
            this.lblMessageExit.Text = "Ấn nút F10 để cập nhật cuộc họp";
            this.lblMessageExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(692, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 33);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(561, 6);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(125, 33);
            this.btnConfirm.TabIndex = 17;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // pnlCamera
            // 
            this.pnlCamera.Controls.Add(this.pnlCameraInside);
            this.pnlCamera.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCamera.Location = new System.Drawing.Point(828, 0);
            this.pnlCamera.Name = "pnlCamera";
            this.pnlCamera.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnlCamera.Size = new System.Drawing.Size(400, 628);
            this.pnlCamera.TabIndex = 0;
            // 
            // pnlCameraInside
            // 
            this.pnlCameraInside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCameraInside.Controls.Add(this.picMember);
            this.pnlCameraInside.Controls.Add(this.lblImagenonresidentIdentitycard);
            this.pnlCameraInside.Controls.Add(this.picMemberIdentityCard);
            this.pnlCameraInside.Controls.Add(this.lblImageNonresident);
            this.pnlCameraInside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCameraInside.Location = new System.Drawing.Point(3, 0);
            this.pnlCameraInside.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlCameraInside.Name = "pnlCameraInside";
            this.pnlCameraInside.Size = new System.Drawing.Size(397, 628);
            this.pnlCameraInside.TabIndex = 0;
            // 
            // picMember
            // 
            this.picMember.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picMember.Location = new System.Drawing.Point(0, 317);
            this.picMember.Name = "picMember";
            this.picMember.Size = new System.Drawing.Size(395, 280);
            this.picMember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMember.TabIndex = 210;
            this.picMember.TabStop = false;
            // 
            // lblImagenonresidentIdentitycard
            // 
            this.lblImagenonresidentIdentitycard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.lblImagenonresidentIdentitycard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblImagenonresidentIdentitycard.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblImagenonresidentIdentitycard.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImagenonresidentIdentitycard.Location = new System.Drawing.Point(0, 280);
            this.lblImagenonresidentIdentitycard.Margin = new System.Windows.Forms.Padding(0);
            this.lblImagenonresidentIdentitycard.Name = "lblImagenonresidentIdentitycard";
            this.lblImagenonresidentIdentitycard.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.lblImagenonresidentIdentitycard.Size = new System.Drawing.Size(395, 29);
            this.lblImagenonresidentIdentitycard.TabIndex = 209;
            this.lblImagenonresidentIdentitycard.Text = "Hình ảnh CMND";
            this.lblImagenonresidentIdentitycard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picMemberIdentityCard
            // 
            this.picMemberIdentityCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.picMemberIdentityCard.Location = new System.Drawing.Point(0, 0);
            this.picMemberIdentityCard.Name = "picMemberIdentityCard";
            this.picMemberIdentityCard.Size = new System.Drawing.Size(395, 280);
            this.picMemberIdentityCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMemberIdentityCard.TabIndex = 208;
            this.picMemberIdentityCard.TabStop = false;
            // 
            // lblImageNonresident
            // 
            this.lblImageNonresident.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.lblImageNonresident.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblImageNonresident.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblImageNonresident.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageNonresident.Location = new System.Drawing.Point(0, 597);
            this.lblImageNonresident.Margin = new System.Windows.Forms.Padding(0);
            this.lblImageNonresident.Name = "lblImageNonresident";
            this.lblImageNonresident.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblImageNonresident.Size = new System.Drawing.Size(395, 29);
            this.lblImageNonresident.TabIndex = 0;
            this.lblImageNonresident.Text = "Hình ảnh khách vãng lai";
            this.lblImageNonresident.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmUpdateNonResident
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 640);
            this.Controls.Add(this.pnlParent);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "FrmUpdateNonResident";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.ShowInTaskbar = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Tin Khách Vãng Lai";
            this.TopMost = true;
            this.pnlParent.ResumeLayout(false);
            this.pnlMainRight.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMeetingInfo.ResumeLayout(false);
            this.pnlMeetingInfoInside.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeetingList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrgList)).EndInit();
            this.pnlReason.ResumeLayout(false);
            this.pnlReason.PerformLayout();
            this.pnlPeopleInfo.ResumeLayout(false);
            this.pnlPeopleInfoInside.ResumeLayout(false);
            this.pnlPeopleInfoInside.PerformLayout();
            this.pnlButton.ResumeLayout(false);
            this.pnlButtonInside.ResumeLayout(false);
            this.pnlCamera.ResumeLayout(false);
            this.pnlCameraInside.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMemberIdentityCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlParent;
        private System.Windows.Forms.Panel pnlMainRight;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlMeetingInfo;
        private System.Windows.Forms.Panel pnlMeetingInfoInside;
        private System.Windows.Forms.DataGridView dgvOrgList;
        private System.Windows.Forms.Panel pnlReason;
        private System.Windows.Forms.TextBox tbxReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblMeetingInformation;
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
        private System.Windows.Forms.TextBox tbxPhoneNumber;
        private System.Windows.Forms.TextBox tbxFullName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Panel pnlButtonInside;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel pnlCamera;
        private System.Windows.Forms.Panel pnlCameraInside;
        private System.Windows.Forms.PictureBox picMember;
        private System.Windows.Forms.Label lblImagenonresidentIdentitycard;
        private System.Windows.Forms.PictureBox picMemberIdentityCard;
        private System.Windows.Forms.Label lblImageNonresident;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgName;
        private System.Windows.Forms.DataGridView dgvMeetingList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeetingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeetingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeStart;
        private System.Windows.Forms.Panel pnlPadding;
        private System.Windows.Forms.Label lblOrgMeeting;
        private System.Windows.Forms.Label lblMessageExit;
        private System.Windows.Forms.Button btnUpdateInfo;
        private System.Windows.Forms.Label lblPassport;
    }
}