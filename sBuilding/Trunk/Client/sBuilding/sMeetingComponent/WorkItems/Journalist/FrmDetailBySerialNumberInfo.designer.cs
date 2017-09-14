using System.Windows.Forms;

namespace sMeetingComponent.WorkItems
{
    public partial class FrmDetailBySerialNumberInfo : Form
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
            this.panel3GuideSubmit = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblguideEnter = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMeetingInfo = new System.Windows.Forms.Panel();
            this.pnlMeetingInfoInside = new System.Windows.Forms.Panel();
            this.panel2Meeting = new System.Windows.Forms.Panel();
            this.panel4ListMeeting = new System.Windows.Forms.Panel();
            this.dgvListMeetingToday = new CommonControls.Custom.CommonDataGridView();
            this.colSttnew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeetingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeetingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrganizationMeeting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRoomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListAttend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblGuide = new System.Windows.Forms.Label();
            this.lblMeetingInformationNew = new System.Windows.Forms.Label();
            this.pnlReason = new System.Windows.Forms.Panel();
            this.panel1OrgInside = new System.Windows.Forms.Panel();
            this.lblReason = new System.Windows.Forms.Label();
            this.tbxReason = new System.Windows.Forms.TextBox();
            this.panel1ListOrg = new System.Windows.Forms.Panel();
            this.dgvOrgList = new CommonControls.Custom.CommonDataGridView();
            this.colOrgNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrgId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckOrg = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblInfoContactOrg = new System.Windows.Forms.Label();
            this.pnlPeopleInfo = new System.Windows.Forms.Panel();
            this.panel8InfoParkerInside = new System.Windows.Forms.Panel();
            this.panel1Image = new System.Windows.Forms.Panel();
            this.picMember = new System.Windows.Forms.PictureBox();
            this.lblImageCBCC = new System.Windows.Forms.Label();
            this.panel1ParkerInfo = new System.Windows.Forms.Panel();
            this.lblJournalistInfo = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtOrg = new System.Windows.Forms.TextBox();
            this.lblChooseOrg = new System.Windows.Forms.Label();
            this.txtIdentityCard = new System.Windows.Forms.TextBox();
            this.lblCMND = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.txtLowerFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.panel3GuideSubmit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlMeetingInfo.SuspendLayout();
            this.pnlMeetingInfoInside.SuspendLayout();
            this.panel2Meeting.SuspendLayout();
            this.panel4ListMeeting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMeetingToday)).BeginInit();
            this.pnlReason.SuspendLayout();
            this.panel1OrgInside.SuspendLayout();
            this.panel1ListOrg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrgList)).BeginInit();
            this.pnlPeopleInfo.SuspendLayout();
            this.panel8InfoParkerInside.SuspendLayout();
            this.panel1Image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).BeginInit();
            this.panel1ParkerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3GuideSubmit
            // 
            this.panel3GuideSubmit.Controls.Add(this.panel1);
            this.panel3GuideSubmit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3GuideSubmit.Location = new System.Drawing.Point(6, 629);
            this.panel3GuideSubmit.Name = "panel3GuideSubmit";
            this.panel3GuideSubmit.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panel3GuideSubmit.Size = new System.Drawing.Size(1222, 81);
            this.panel3GuideSubmit.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblguideEnter);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1222, 78);
            this.panel1.TabIndex = 1;
            // 
            // lblguideEnter
            // 
            this.lblguideEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.lblguideEnter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblguideEnter.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblguideEnter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblguideEnter.ForeColor = System.Drawing.Color.Black;
            this.lblguideEnter.Location = new System.Drawing.Point(0, 0);
            this.lblguideEnter.Name = "lblguideEnter";
            this.lblguideEnter.Size = new System.Drawing.Size(1220, 33);
            this.lblguideEnter.TabIndex = 21;
            this.lblguideEnter.Text = "Ấn nút F10 để cho vào";
            this.lblguideEnter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1119, 38);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 33);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(1020, 38);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(93, 33);
            this.btnConfirm.TabIndex = 19;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlMeetingInfo);
            this.pnlMain.Controls.Add(this.pnlPeopleInfo);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(6, 6);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1222, 623);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlMeetingInfo
            // 
            this.pnlMeetingInfo.Controls.Add(this.pnlMeetingInfoInside);
            this.pnlMeetingInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMeetingInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlMeetingInfo.Name = "pnlMeetingInfo";
            this.pnlMeetingInfo.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.pnlMeetingInfo.Size = new System.Drawing.Size(830, 623);
            this.pnlMeetingInfo.TabIndex = 0;
            // 
            // pnlMeetingInfoInside
            // 
            this.pnlMeetingInfoInside.Controls.Add(this.panel2Meeting);
            this.pnlMeetingInfoInside.Controls.Add(this.pnlReason);
            this.pnlMeetingInfoInside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMeetingInfoInside.Location = new System.Drawing.Point(0, 0);
            this.pnlMeetingInfoInside.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlMeetingInfoInside.Name = "pnlMeetingInfoInside";
            this.pnlMeetingInfoInside.Size = new System.Drawing.Size(827, 620);
            this.pnlMeetingInfoInside.TabIndex = 0;
            // 
            // panel2Meeting
            // 
            this.panel2Meeting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2Meeting.Controls.Add(this.panel4ListMeeting);
            this.panel2Meeting.Controls.Add(this.lblGuide);
            this.panel2Meeting.Controls.Add(this.lblMeetingInformationNew);
            this.panel2Meeting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2Meeting.Location = new System.Drawing.Point(0, 0);
            this.panel2Meeting.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.panel2Meeting.Name = "panel2Meeting";
            this.panel2Meeting.Size = new System.Drawing.Size(827, 308);
            this.panel2Meeting.TabIndex = 0;
            // 
            // panel4ListMeeting
            // 
            this.panel4ListMeeting.Controls.Add(this.dgvListMeetingToday);
            this.panel4ListMeeting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4ListMeeting.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4ListMeeting.Location = new System.Drawing.Point(0, 62);
            this.panel4ListMeeting.Name = "panel4ListMeeting";
            this.panel4ListMeeting.Size = new System.Drawing.Size(825, 244);
            this.panel4ListMeeting.TabIndex = 238;
            // 
            // dgvListMeetingToday
            // 
            this.dgvListMeetingToday.AllowUserToAddRows = false;
            this.dgvListMeetingToday.AllowUserToDeleteRows = false;
            this.dgvListMeetingToday.AllowUserToOrderColumns = true;
            this.dgvListMeetingToday.AllowUserToResizeRows = false;
            this.dgvListMeetingToday.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvListMeetingToday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListMeetingToday.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvListMeetingToday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListMeetingToday.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSttnew,
            this.colMeetingId,
            this.colMeetingName,
            this.colOrganizationMeeting,
            this.colDateTime,
            this.colStartTime,
            this.colEndTime,
            this.colCheck,
            this.colRoomName,
            this.colNumber,
            this.colListAttend});
            this.dgvListMeetingToday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListMeetingToday.Location = new System.Drawing.Point(0, 0);
            this.dgvListMeetingToday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListMeetingToday.MultiSelect = false;
            this.dgvListMeetingToday.Name = "dgvListMeetingToday";
            this.dgvListMeetingToday.ReadOnly = true;
            this.dgvListMeetingToday.RowHeadersVisible = false;
            this.dgvListMeetingToday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListMeetingToday.Size = new System.Drawing.Size(825, 244);
            this.dgvListMeetingToday.TabIndex = 1;
            this.dgvListMeetingToday.TabStop = false;
            // 
            // colSttnew
            // 
            this.colSttnew.DataPropertyName = "Sttnew";
            this.colSttnew.HeaderText = "STT";
            this.colSttnew.Name = "colSttnew";
            this.colSttnew.ReadOnly = true;
            this.colSttnew.Width = 50;
            // 
            // colMeetingId
            // 
            this.colMeetingId.DataPropertyName = "MeetingId";
            this.colMeetingId.HeaderText = "MeetingId";
            this.colMeetingId.Name = "colMeetingId";
            this.colMeetingId.ReadOnly = true;
            this.colMeetingId.Visible = false;
            // 
            // colMeetingName
            // 
            this.colMeetingName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMeetingName.DataPropertyName = "MeetingName";
            this.colMeetingName.HeaderText = "Cuộc họp";
            this.colMeetingName.Name = "colMeetingName";
            this.colMeetingName.ReadOnly = true;
            // 
            // colOrganizationMeeting
            // 
            this.colOrganizationMeeting.DataPropertyName = "OrganizationMeeting";
            this.colOrganizationMeeting.HeaderText = "Đơn vị";
            this.colOrganizationMeeting.Name = "colOrganizationMeeting";
            this.colOrganizationMeeting.ReadOnly = true;
            this.colOrganizationMeeting.Width = 200;
            // 
            // colDateTime
            // 
            this.colDateTime.DataPropertyName = "DateTime";
            this.colDateTime.HeaderText = "DateTime";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.ReadOnly = true;
            this.colDateTime.Width = 90;
            // 
            // colStartTime
            // 
            this.colStartTime.DataPropertyName = "StartTime";
            this.colStartTime.HeaderText = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.ReadOnly = true;
            this.colStartTime.Width = 115;
            // 
            // colEndTime
            // 
            this.colEndTime.DataPropertyName = "EndTime";
            this.colEndTime.HeaderText = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.ReadOnly = true;
            this.colEndTime.Visible = false;
            // 
            // colCheck
            // 
            this.colCheck.DataPropertyName = "Check";
            this.colCheck.FalseValue = "";
            this.colCheck.HeaderText = "Tham dự họp";
            this.colCheck.IndeterminateValue = "";
            this.colCheck.Name = "colCheck";
            this.colCheck.ReadOnly = true;
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCheck.TrueValue = "";
            // 
            // colRoomName
            // 
            this.colRoomName.DataPropertyName = "RoomName";
            this.colRoomName.HeaderText = "RoomName";
            this.colRoomName.Name = "colRoomName";
            this.colRoomName.ReadOnly = true;
            this.colRoomName.Visible = false;
            // 
            // colNumber
            // 
            this.colNumber.DataPropertyName = "Number";
            this.colNumber.HeaderText = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
            this.colNumber.Visible = false;
            // 
            // colListAttend
            // 
            this.colListAttend.DataPropertyName = "ListAttend";
            this.colListAttend.HeaderText = "Ds người tham dự";
            this.colListAttend.Name = "colListAttend";
            this.colListAttend.ReadOnly = true;
            this.colListAttend.Visible = false;
            // 
            // lblGuide
            // 
            this.lblGuide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.lblGuide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGuide.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGuide.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic);
            this.lblGuide.Location = new System.Drawing.Point(0, 29);
            this.lblGuide.Margin = new System.Windows.Forms.Padding(3);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(825, 33);
            this.lblGuide.TabIndex = 237;
            this.lblGuide.Text = "Ấn ↑ để di chuyển lên. Ấn ↓ để di chuyển xuống. Ấn khoảng trắng  ̺  để chọn.";
            this.lblGuide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMeetingInformationNew
            // 
            this.lblMeetingInformationNew.BackColor = System.Drawing.Color.Transparent;
            this.lblMeetingInformationNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMeetingInformationNew.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeetingInformationNew.ForeColor = System.Drawing.Color.Black;
            this.lblMeetingInformationNew.Location = new System.Drawing.Point(0, 0);
            this.lblMeetingInformationNew.Name = "lblMeetingInformationNew";
            this.lblMeetingInformationNew.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblMeetingInformationNew.Size = new System.Drawing.Size(825, 29);
            this.lblMeetingInformationNew.TabIndex = 236;
            this.lblMeetingInformationNew.Text = "THÔNG TIN CUỘC HỌP";
            this.lblMeetingInformationNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlReason
            // 
            this.pnlReason.Controls.Add(this.panel1OrgInside);
            this.pnlReason.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlReason.Location = new System.Drawing.Point(0, 308);
            this.pnlReason.Margin = new System.Windows.Forms.Padding(0);
            this.pnlReason.Name = "pnlReason";
            this.pnlReason.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlReason.Size = new System.Drawing.Size(827, 312);
            this.pnlReason.TabIndex = 0;
            // 
            // panel1OrgInside
            // 
            this.panel1OrgInside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1OrgInside.Controls.Add(this.lblReason);
            this.panel1OrgInside.Controls.Add(this.tbxReason);
            this.panel1OrgInside.Controls.Add(this.panel1ListOrg);
            this.panel1OrgInside.Controls.Add(this.lblInfoContactOrg);
            this.panel1OrgInside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1OrgInside.Location = new System.Drawing.Point(0, 6);
            this.panel1OrgInside.Name = "panel1OrgInside";
            this.panel1OrgInside.Size = new System.Drawing.Size(827, 306);
            this.panel1OrgInside.TabIndex = 8;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.Location = new System.Drawing.Point(4, 217);
            this.lblReason.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(54, 19);
            this.lblReason.TabIndex = 240;
            this.lblReason.Text = "Lý do:";
            this.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxReason
            // 
            this.tbxReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxReason.BackColor = System.Drawing.Color.White;
            this.tbxReason.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxReason.Location = new System.Drawing.Point(82, 217);
            this.tbxReason.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.tbxReason.MaxLength = 250;
            this.tbxReason.Multiline = true;
            this.tbxReason.Name = "tbxReason";
            this.tbxReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxReason.Size = new System.Drawing.Size(738, 81);
            this.tbxReason.TabIndex = 239;
            this.tbxReason.WordWrap = false;
            // 
            // panel1ListOrg
            // 
            this.panel1ListOrg.Controls.Add(this.dgvOrgList);
            this.panel1ListOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1ListOrg.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1ListOrg.Location = new System.Drawing.Point(0, 29);
            this.panel1ListOrg.Name = "panel1ListOrg";
            this.panel1ListOrg.Size = new System.Drawing.Size(825, 183);
            this.panel1ListOrg.TabIndex = 238;
            // 
            // dgvOrgList
            // 
            this.dgvOrgList.AllowUserToAddRows = false;
            this.dgvOrgList.AllowUserToDeleteRows = false;
            this.dgvOrgList.AllowUserToOrderColumns = true;
            this.dgvOrgList.AllowUserToResizeRows = false;
            this.dgvOrgList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvOrgList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrgList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvOrgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrgNo,
            this.colOrgId,
            this.colOrgName,
            this.colCheckOrg});
            this.dgvOrgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrgList.Enabled = false;
            this.dgvOrgList.Location = new System.Drawing.Point(0, 0);
            this.dgvOrgList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvOrgList.MultiSelect = false;
            this.dgvOrgList.Name = "dgvOrgList";
            this.dgvOrgList.ReadOnly = true;
            this.dgvOrgList.RowHeadersVisible = false;
            this.dgvOrgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrgList.Size = new System.Drawing.Size(825, 183);
            this.dgvOrgList.TabIndex = 0;
            // 
            // colOrgNo
            // 
            this.colOrgNo.DataPropertyName = "colOrgNo";
            this.colOrgNo.HeaderText = "STT";
            this.colOrgNo.Name = "colOrgNo";
            this.colOrgNo.ReadOnly = true;
            this.colOrgNo.Width = 50;
            // 
            // colOrgId
            // 
            this.colOrgId.DataPropertyName = "colOrgId";
            this.colOrgId.HeaderText = "MeetingId";
            this.colOrgId.Name = "colOrgId";
            this.colOrgId.ReadOnly = true;
            this.colOrgId.Visible = false;
            // 
            // colOrgName
            // 
            this.colOrgName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOrgName.DataPropertyName = "colOrgName";
            this.colOrgName.HeaderText = "Đơn vị liên hệ";
            this.colOrgName.Name = "colOrgName";
            this.colOrgName.ReadOnly = true;
            // 
            // colCheckOrg
            // 
            this.colCheckOrg.DataPropertyName = "colCheckOrg";
            this.colCheckOrg.FalseValue = "";
            this.colCheckOrg.HeaderText = "Tham dự";
            this.colCheckOrg.IndeterminateValue = "";
            this.colCheckOrg.Name = "colCheckOrg";
            this.colCheckOrg.ReadOnly = true;
            this.colCheckOrg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheckOrg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCheckOrg.TrueValue = "";
            // 
            // lblInfoContactOrg
            // 
            this.lblInfoContactOrg.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoContactOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfoContactOrg.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoContactOrg.ForeColor = System.Drawing.Color.Black;
            this.lblInfoContactOrg.Location = new System.Drawing.Point(0, 0);
            this.lblInfoContactOrg.Name = "lblInfoContactOrg";
            this.lblInfoContactOrg.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblInfoContactOrg.Size = new System.Drawing.Size(825, 29);
            this.lblInfoContactOrg.TabIndex = 237;
            this.lblInfoContactOrg.Text = "THÔNG TIN LIÊN HỆ";
            this.lblInfoContactOrg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPeopleInfo
            // 
            this.pnlPeopleInfo.Controls.Add(this.panel8InfoParkerInside);
            this.pnlPeopleInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPeopleInfo.Location = new System.Drawing.Point(830, 0);
            this.pnlPeopleInfo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlPeopleInfo.Name = "pnlPeopleInfo";
            this.pnlPeopleInfo.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.pnlPeopleInfo.Size = new System.Drawing.Size(392, 623);
            this.pnlPeopleInfo.TabIndex = 0;
            // 
            // panel8InfoParkerInside
            // 
            this.panel8InfoParkerInside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8InfoParkerInside.Controls.Add(this.panel1Image);
            this.panel8InfoParkerInside.Controls.Add(this.panel1ParkerInfo);
            this.panel8InfoParkerInside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8InfoParkerInside.Location = new System.Drawing.Point(3, 0);
            this.panel8InfoParkerInside.Name = "panel8InfoParkerInside";
            this.panel8InfoParkerInside.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.panel8InfoParkerInside.Size = new System.Drawing.Size(389, 620);
            this.panel8InfoParkerInside.TabIndex = 1;
            // 
            // panel1Image
            // 
            this.panel1Image.Controls.Add(this.picMember);
            this.panel1Image.Controls.Add(this.lblImageCBCC);
            this.panel1Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1Image.Location = new System.Drawing.Point(0, 235);
            this.panel1Image.Name = "panel1Image";
            this.panel1Image.Size = new System.Drawing.Size(384, 383);
            this.panel1Image.TabIndex = 238;
            this.panel1Image.Visible = false;
            // 
            // picMember
            // 
            this.picMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMember.Location = new System.Drawing.Point(0, 19);
            this.picMember.Name = "picMember";
            this.picMember.Size = new System.Drawing.Size(384, 364);
            this.picMember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMember.TabIndex = 221;
            this.picMember.TabStop = false;
            // 
            // lblImageCBCC
            // 
            this.lblImageCBCC.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblImageCBCC.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageCBCC.Location = new System.Drawing.Point(0, 0);
            this.lblImageCBCC.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblImageCBCC.Name = "lblImageCBCC";
            this.lblImageCBCC.Size = new System.Drawing.Size(384, 19);
            this.lblImageCBCC.TabIndex = 220;
            this.lblImageCBCC.Text = "Hình ảnh ";
            this.lblImageCBCC.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1ParkerInfo
            // 
            this.panel1ParkerInfo.Controls.Add(this.lblJournalistInfo);
            this.panel1ParkerInfo.Controls.Add(this.txtPosition);
            this.panel1ParkerInfo.Controls.Add(this.lblPosition);
            this.panel1ParkerInfo.Controls.Add(this.txtOrg);
            this.panel1ParkerInfo.Controls.Add(this.lblChooseOrg);
            this.panel1ParkerInfo.Controls.Add(this.txtIdentityCard);
            this.panel1ParkerInfo.Controls.Add(this.lblCMND);
            this.panel1ParkerInfo.Controls.Add(this.txtPhoneNo);
            this.panel1ParkerInfo.Controls.Add(this.txtLowerFullName);
            this.panel1ParkerInfo.Controls.Add(this.lblFullName);
            this.panel1ParkerInfo.Controls.Add(this.lblTel);
            this.panel1ParkerInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1ParkerInfo.Location = new System.Drawing.Point(0, 0);
            this.panel1ParkerInfo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel1ParkerInfo.Name = "panel1ParkerInfo";
            this.panel1ParkerInfo.Size = new System.Drawing.Size(384, 235);
            this.panel1ParkerInfo.TabIndex = 237;
            // 
            // lblJournalistInfo
            // 
            this.lblJournalistInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblJournalistInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblJournalistInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJournalistInfo.ForeColor = System.Drawing.Color.Black;
            this.lblJournalistInfo.Location = new System.Drawing.Point(0, 0);
            this.lblJournalistInfo.Name = "lblJournalistInfo";
            this.lblJournalistInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblJournalistInfo.Size = new System.Drawing.Size(384, 29);
            this.lblJournalistInfo.TabIndex = 293;
            this.lblJournalistInfo.Text = "THÔNG TIN KHÁCH";
            this.lblJournalistInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPosition
            // 
            this.txtPosition.BackColor = System.Drawing.Color.White;
            this.txtPosition.Enabled = false;
            this.txtPosition.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosition.Location = new System.Drawing.Point(130, 118);
            this.txtPosition.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.txtPosition.MaxLength = 49;
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(244, 27);
            this.txtPosition.TabIndex = 285;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(7, 119);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(3);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(73, 19);
            this.lblPosition.TabIndex = 292;
            this.lblPosition.Text = "Chức vụ:";
            // 
            // txtOrg
            // 
            this.txtOrg.BackColor = System.Drawing.Color.White;
            this.txtOrg.Enabled = false;
            this.txtOrg.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrg.Location = new System.Drawing.Point(130, 77);
            this.txtOrg.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.txtOrg.MaxLength = 49;
            this.txtOrg.Name = "txtOrg";
            this.txtOrg.Size = new System.Drawing.Size(244, 27);
            this.txtOrg.TabIndex = 284;
            // 
            // lblChooseOrg
            // 
            this.lblChooseOrg.AutoSize = true;
            this.lblChooseOrg.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseOrg.Location = new System.Drawing.Point(7, 78);
            this.lblChooseOrg.Margin = new System.Windows.Forms.Padding(3);
            this.lblChooseOrg.Name = "lblChooseOrg";
            this.lblChooseOrg.Size = new System.Drawing.Size(61, 19);
            this.lblChooseOrg.TabIndex = 291;
            this.lblChooseOrg.Text = "Đơn vị:";
            // 
            // txtIdentityCard
            // 
            this.txtIdentityCard.BackColor = System.Drawing.Color.White;
            this.txtIdentityCard.Enabled = false;
            this.txtIdentityCard.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityCard.Location = new System.Drawing.Point(130, 160);
            this.txtIdentityCard.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.txtIdentityCard.MaxLength = 10;
            this.txtIdentityCard.Name = "txtIdentityCard";
            this.txtIdentityCard.Size = new System.Drawing.Size(244, 27);
            this.txtIdentityCard.TabIndex = 286;
            // 
            // lblCMND
            // 
            this.lblCMND.AutoSize = true;
            this.lblCMND.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCMND.Location = new System.Drawing.Point(7, 162);
            this.lblCMND.Margin = new System.Windows.Forms.Padding(3);
            this.lblCMND.Name = "lblCMND";
            this.lblCMND.Size = new System.Drawing.Size(59, 19);
            this.lblCMND.TabIndex = 290;
            this.lblCMND.Text = "CMND:";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.BackColor = System.Drawing.Color.White;
            this.txtPhoneNo.Enabled = false;
            this.txtPhoneNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNo.Location = new System.Drawing.Point(130, 198);
            this.txtPhoneNo.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.txtPhoneNo.MaxLength = 13;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(244, 27);
            this.txtPhoneNo.TabIndex = 287;
            // 
            // txtLowerFullName
            // 
            this.txtLowerFullName.BackColor = System.Drawing.Color.White;
            this.txtLowerFullName.Enabled = false;
            this.txtLowerFullName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLowerFullName.Location = new System.Drawing.Point(130, 37);
            this.txtLowerFullName.Margin = new System.Windows.Forms.Padding(3, 3, 6, 6);
            this.txtLowerFullName.MaxLength = 49;
            this.txtLowerFullName.Name = "txtLowerFullName";
            this.txtLowerFullName.Size = new System.Drawing.Size(244, 27);
            this.txtLowerFullName.TabIndex = 283;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(7, 39);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(3);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(83, 19);
            this.lblFullName.TabIndex = 288;
            this.lblFullName.Text = "Họ và tên:";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTel.Location = new System.Drawing.Point(7, 199);
            this.lblTel.Margin = new System.Windows.Forms.Padding(3);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(87, 19);
            this.lblTel.TabIndex = 289;
            this.lblTel.Text = "Điện thoại:";
            // 
            // FrmDetailBySerialNumberInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 716);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panel3GuideSubmit);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmDetailBySerialNumberInfo";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel3GuideSubmit.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMeetingInfo.ResumeLayout(false);
            this.pnlMeetingInfoInside.ResumeLayout(false);
            this.panel2Meeting.ResumeLayout(false);
            this.panel4ListMeeting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMeetingToday)).EndInit();
            this.pnlReason.ResumeLayout(false);
            this.panel1OrgInside.ResumeLayout(false);
            this.panel1OrgInside.PerformLayout();
            this.panel1ListOrg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrgList)).EndInit();
            this.pnlPeopleInfo.ResumeLayout(false);
            this.panel8InfoParkerInside.ResumeLayout(false);
            this.panel1Image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).EndInit();
            this.panel1ParkerInfo.ResumeLayout(false);
            this.panel1ParkerInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel3GuideSubmit;
        private Panel pnlMain;
        private Panel pnlMeetingInfo;
        private Panel pnlMeetingInfoInside;
        private Panel pnlReason;
        private Panel pnlPeopleInfo;
        private Panel panel2Meeting;
        private Panel panel8InfoParkerInside;
        private Panel panel1Image;
        private PictureBox picMember;
        private Label lblImageCBCC;
        private Panel panel1ParkerInfo;
        private TextBox txtPosition;
        private Label lblPosition;
        private TextBox txtOrg;
        private Label lblChooseOrg;
        private TextBox txtIdentityCard;
        private Label lblCMND;
        private TextBox txtPhoneNo;
        private TextBox txtLowerFullName;
        private Label lblFullName;
        private Label lblTel;
        private Label lblJournalistInfo;
        private Label lblMeetingInformationNew;
        private Panel panel4ListMeeting;
        private CommonControls.Custom.CommonDataGridView dgvListMeetingToday;
        private Label lblGuide;
        private Panel panel1OrgInside;
        private Label lblInfoContactOrg;
        private Label lblReason;
        private TextBox tbxReason;
        private Panel panel1ListOrg;
        private CommonControls.Custom.CommonDataGridView dgvOrgList;
        private Panel panel1;
        private Label lblguideEnter;
        private Button btnCancel;
        private Button btnConfirm;
        private DataGridViewTextBoxColumn colSttnew;
        private DataGridViewTextBoxColumn colMeetingId;
        private DataGridViewTextBoxColumn colMeetingName;
        private DataGridViewTextBoxColumn colOrganizationMeeting;
        private DataGridViewTextBoxColumn colDateTime;
        private DataGridViewTextBoxColumn colStartTime;
        private DataGridViewTextBoxColumn colEndTime;
        private DataGridViewCheckBoxColumn colCheck;
        private DataGridViewTextBoxColumn colRoomName;
        private DataGridViewTextBoxColumn colNumber;
        private DataGridViewTextBoxColumn colListAttend;
        private DataGridViewTextBoxColumn colOrgNo;
        private DataGridViewTextBoxColumn colOrgId;
        private DataGridViewTextBoxColumn colOrgName;
        private DataGridViewCheckBoxColumn colCheckOrg;
    }
}