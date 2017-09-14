using System.Windows.Forms;

namespace sMeetingComponent.WorkItems
{
    partial class FrmDetailInforByCardChip: Form
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblguideEnter = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNotess = new System.Windows.Forms.Label();
            this.lblInforPlus = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvListMeetingToday = new CommonControls.Custom.CommonDataGridView();
            this.colSttnew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeetingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeetingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrganizationMeeting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListAttend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtLowerFullName = new System.Windows.Forms.TextBox();
            this.lblListMeetingtoDay = new System.Windows.Forms.Label();
            this.txtOrg = new System.Windows.Forms.TextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblBrithDay = new System.Windows.Forms.Label();
            this.txtIdentityCard = new System.Windows.Forms.TextBox();
            this.lblCMND = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblLowerName = new System.Windows.Forms.Label();
            this.lblChooseOrg = new System.Windows.Forms.Label();
            this.lblJournalistInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvListAttend = new CommonControls.Custom.CommonDataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNamePartaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNameOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPositionPartaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblHour = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblHourEnd = new System.Windows.Forms.Label();
            this.txtOrganizationMeeting = new System.Windows.Forms.TextBox();
            this.txtMeetingName = new System.Windows.Forms.TextBox();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblGoverningOrganization = new System.Windows.Forms.Label();
            this.dtpDay = new System.Windows.Forms.DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblMeeting = new System.Windows.Forms.Label();
            this.lblNameAttendingredient = new System.Windows.Forms.Label();
            this.lblend = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblMeetingInformation = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMeetingToday)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAttend)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblguideEnter);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.btnConfirm);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 563);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1234, 148);
            this.panel3.TabIndex = 23;
            // 
            // lblguideEnter
            // 
            this.lblguideEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblguideEnter.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblguideEnter.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblguideEnter.Location = new System.Drawing.Point(12, 110);
            this.lblguideEnter.Name = "lblguideEnter";
            this.lblguideEnter.Size = new System.Drawing.Size(549, 34);
            this.lblguideEnter.TabIndex = 18;
            this.lblguideEnter.Text = "Hướng dẫn phím nhanh: Vui lòng nhấn nút F10 để cho vào";
            this.lblguideEnter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1112, 108);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 33);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.txtNote);
            this.panel7.Controls.Add(this.lblNotess);
            this.panel7.Controls.Add(this.lblInforPlus);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1234, 104);
            this.panel7.TabIndex = 15;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(142, 34);
            this.txtNote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(1062, 61);
            this.txtNote.TabIndex = 2;
            // 
            // lblNotess
            // 
            this.lblNotess.AutoSize = true;
            this.lblNotess.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotess.Location = new System.Drawing.Point(31, 34);
            this.lblNotess.Name = "lblNotess";
            this.lblNotess.Size = new System.Drawing.Size(69, 19);
            this.lblNotess.TabIndex = 2;
            this.lblNotess.Text = "Ghi chú:";
            // 
            // lblInforPlus
            // 
            this.lblInforPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblInforPlus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInforPlus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInforPlus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInforPlus.Location = new System.Drawing.Point(0, 0);
            this.lblInforPlus.Name = "lblInforPlus";
            this.lblInforPlus.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblInforPlus.Size = new System.Drawing.Size(1232, 32);
            this.lblInforPlus.TabIndex = 1;
            this.lblInforPlus.Text = "THÔNG TIN THÊM";
            this.lblInforPlus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(1013, 108);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(93, 33);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1234, 563);
            this.splitContainer1.SplitterDistance = 632;
            this.splitContainer1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(632, 563);
            this.panel2.TabIndex = 24;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvListMeetingToday);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(0, 290);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(630, 271);
            this.panel4.TabIndex = 123;
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
            this.colCheck,
            this.colDateTime,
            this.colStartTime,
            this.colEndTime,
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
            this.dgvListMeetingToday.Size = new System.Drawing.Size(630, 271);
            this.dgvListMeetingToday.TabIndex = 1;
            this.dgvListMeetingToday.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListMeetingToday_CellMouseClick);
            // 
            // colSttnew
            // 
            this.colSttnew.DataPropertyName = "Sttnew";
            this.colSttnew.HeaderText = "STT";
            this.colSttnew.Name = "colSttnew";
            this.colSttnew.ReadOnly = true;
            this.colSttnew.Width = 40;
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
            this.colOrganizationMeeting.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOrganizationMeeting.DataPropertyName = "OrganizationMeeting";
            this.colOrganizationMeeting.HeaderText = "Đơn vị";
            this.colOrganizationMeeting.Name = "colOrganizationMeeting";
            this.colOrganizationMeeting.ReadOnly = true;
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
            this.colCheck.Width = 130;
            // 
            // colDateTime
            // 
            this.colDateTime.DataPropertyName = "DateTime";
            this.colDateTime.HeaderText = "DateTime";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.ReadOnly = true;
            this.colDateTime.Visible = false;
            // 
            // colStartTime
            // 
            this.colStartTime.DataPropertyName = "StartTime";
            this.colStartTime.HeaderText = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.ReadOnly = true;
            this.colStartTime.Visible = false;
            // 
            // colEndTime
            // 
            this.colEndTime.DataPropertyName = "EndTime";
            this.colEndTime.HeaderText = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.ReadOnly = true;
            this.colEndTime.Visible = false;
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
            // panel8
            // 
            this.panel8.Controls.Add(this.txtPosition);
            this.panel8.Controls.Add(this.txtLowerFullName);
            this.panel8.Controls.Add(this.lblListMeetingtoDay);
            this.panel8.Controls.Add(this.txtOrg);
            this.panel8.Controls.Add(this.dtpBirthDate);
            this.panel8.Controls.Add(this.lblBrithDay);
            this.panel8.Controls.Add(this.txtIdentityCard);
            this.panel8.Controls.Add(this.lblCMND);
            this.panel8.Controls.Add(this.txtPhoneNo);
            this.panel8.Controls.Add(this.lblTel);
            this.panel8.Controls.Add(this.txtEmail);
            this.panel8.Controls.Add(this.lblEmail);
            this.panel8.Controls.Add(this.lblPosition);
            this.panel8.Controls.Add(this.lblLowerName);
            this.panel8.Controls.Add(this.lblChooseOrg);
            this.panel8.Controls.Add(this.lblJournalistInfo);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(630, 290);
            this.panel8.TabIndex = 122;
            // 
            // txtPosition
            // 
            this.txtPosition.BackColor = System.Drawing.SystemColors.Window;
            this.txtPosition.Enabled = false;
            this.txtPosition.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosition.Location = new System.Drawing.Point(168, 97);
            this.txtPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPosition.Multiline = true;
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(385, 26);
            this.txtPosition.TabIndex = 137;
            // 
            // txtLowerFullName
            // 
            this.txtLowerFullName.BackColor = System.Drawing.SystemColors.Window;
            this.txtLowerFullName.Enabled = false;
            this.txtLowerFullName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLowerFullName.Location = new System.Drawing.Point(168, 37);
            this.txtLowerFullName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLowerFullName.Multiline = true;
            this.txtLowerFullName.Name = "txtLowerFullName";
            this.txtLowerFullName.Size = new System.Drawing.Size(385, 26);
            this.txtLowerFullName.TabIndex = 136;
            // 
            // lblListMeetingtoDay
            // 
            this.lblListMeetingtoDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblListMeetingtoDay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblListMeetingtoDay.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListMeetingtoDay.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblListMeetingtoDay.Location = new System.Drawing.Point(0, 260);
            this.lblListMeetingtoDay.Name = "lblListMeetingtoDay";
            this.lblListMeetingtoDay.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblListMeetingtoDay.Size = new System.Drawing.Size(630, 30);
            this.lblListMeetingtoDay.TabIndex = 135;
            this.lblListMeetingtoDay.Text = "DANH SÁCH CUỘC HỌP";
            this.lblListMeetingtoDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrg
            // 
            this.txtOrg.BackColor = System.Drawing.SystemColors.Window;
            this.txtOrg.Enabled = false;
            this.txtOrg.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrg.Location = new System.Drawing.Point(168, 67);
            this.txtOrg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOrg.Multiline = true;
            this.txtOrg.Name = "txtOrg";
            this.txtOrg.Size = new System.Drawing.Size(385, 26);
            this.txtOrg.TabIndex = 134;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.CalendarFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpBirthDate.Enabled = false;
            this.dtpBirthDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthDate.Location = new System.Drawing.Point(168, 130);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(105, 27);
            this.dtpBirthDate.TabIndex = 133;
            // 
            // lblBrithDay
            // 
            this.lblBrithDay.AutoSize = true;
            this.lblBrithDay.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrithDay.Location = new System.Drawing.Point(23, 136);
            this.lblBrithDay.Name = "lblBrithDay";
            this.lblBrithDay.Size = new System.Drawing.Size(85, 19);
            this.lblBrithDay.TabIndex = 132;
            this.lblBrithDay.Text = "Ngày sinh:";
            this.lblBrithDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIdentityCard
            // 
            this.txtIdentityCard.BackColor = System.Drawing.SystemColors.Window;
            this.txtIdentityCard.Enabled = false;
            this.txtIdentityCard.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityCard.Location = new System.Drawing.Point(168, 162);
            this.txtIdentityCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIdentityCard.Multiline = true;
            this.txtIdentityCard.Name = "txtIdentityCard";
            this.txtIdentityCard.Size = new System.Drawing.Size(135, 27);
            this.txtIdentityCard.TabIndex = 130;
            // 
            // lblCMND
            // 
            this.lblCMND.AutoSize = true;
            this.lblCMND.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCMND.Location = new System.Drawing.Point(23, 164);
            this.lblCMND.Name = "lblCMND";
            this.lblCMND.Size = new System.Drawing.Size(59, 19);
            this.lblCMND.TabIndex = 131;
            this.lblCMND.Text = "CMND:";
            this.lblCMND.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtPhoneNo.Enabled = false;
            this.txtPhoneNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNo.Location = new System.Drawing.Point(168, 193);
            this.txtPhoneNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhoneNo.Multiline = true;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(135, 27);
            this.txtPhoneNo.TabIndex = 128;
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTel.Location = new System.Drawing.Point(23, 196);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(45, 19);
            this.lblTel.TabIndex = 129;
            this.lblTel.Text = "SĐT:";
            this.lblTel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmail.Enabled = false;
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(168, 224);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(385, 26);
            this.txtEmail.TabIndex = 126;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(23, 227);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(54, 19);
            this.lblEmail.TabIndex = 127;
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(23, 104);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(73, 19);
            this.lblPosition.TabIndex = 125;
            this.lblPosition.Text = "Chức vụ:";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLowerName
            // 
            this.lblLowerName.AutoSize = true;
            this.lblLowerName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerName.Location = new System.Drawing.Point(23, 40);
            this.lblLowerName.Name = "lblLowerName";
            this.lblLowerName.Size = new System.Drawing.Size(42, 19);
            this.lblLowerName.TabIndex = 124;
            this.lblLowerName.Text = "Tên:";
            this.lblLowerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChooseOrg
            // 
            this.lblChooseOrg.AutoSize = true;
            this.lblChooseOrg.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseOrg.Location = new System.Drawing.Point(23, 70);
            this.lblChooseOrg.Name = "lblChooseOrg";
            this.lblChooseOrg.Size = new System.Drawing.Size(74, 19);
            this.lblChooseOrg.TabIndex = 121;
            this.lblChooseOrg.Text = "Cơ quan:";
            this.lblChooseOrg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblJournalistInfo
            // 
            this.lblJournalistInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblJournalistInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblJournalistInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJournalistInfo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblJournalistInfo.Location = new System.Drawing.Point(0, 0);
            this.lblJournalistInfo.Name = "lblJournalistInfo";
            this.lblJournalistInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblJournalistInfo.Size = new System.Drawing.Size(630, 32);
            this.lblJournalistInfo.TabIndex = 120;
            this.lblJournalistInfo.Text = "THÔNG TIN KHÁCH";
            this.lblJournalistInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 563);
            this.panel1.TabIndex = 24;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvListAttend);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(0, 225);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(596, 336);
            this.panel5.TabIndex = 1;
            // 
            // dgvListAttend
            // 
            this.dgvListAttend.AllowUserToAddRows = false;
            this.dgvListAttend.AllowUserToDeleteRows = false;
            this.dgvListAttend.AllowUserToOrderColumns = true;
            this.dgvListAttend.AllowUserToResizeRows = false;
            this.dgvListAttend.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvListAttend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListAttend.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvListAttend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListAttend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colNamePartaker,
            this.colNameOrg,
            this.colPositionPartaker,
            this.dataGridViewCheckBoxColumn1});
            this.dgvListAttend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListAttend.Location = new System.Drawing.Point(0, 0);
            this.dgvListAttend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListAttend.MultiSelect = false;
            this.dgvListAttend.Name = "dgvListAttend";
            this.dgvListAttend.ReadOnly = true;
            this.dgvListAttend.RowHeadersVisible = false;
            this.dgvListAttend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListAttend.Size = new System.Drawing.Size(596, 336);
            this.dgvListAttend.TabIndex = 5;
            // 
            // colSTT
            // 
            this.colSTT.DataPropertyName = "STT";
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 40;
            // 
            // colNamePartaker
            // 
            this.colNamePartaker.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNamePartaker.DataPropertyName = "NamePartaker";
            this.colNamePartaker.HeaderText = "Tên";
            this.colNamePartaker.Name = "colNamePartaker";
            this.colNamePartaker.ReadOnly = true;
            // 
            // colNameOrg
            // 
            this.colNameOrg.DataPropertyName = "NameOrg";
            this.colNameOrg.HeaderText = "Tổ chức";
            this.colNameOrg.Name = "colNameOrg";
            this.colNameOrg.ReadOnly = true;
            this.colNameOrg.Width = 200;
            // 
            // colPositionPartaker
            // 
            this.colPositionPartaker.DataPropertyName = "PositionPartaker";
            this.colPositionPartaker.HeaderText = "Chức vụ";
            this.colPositionPartaker.Name = "colPositionPartaker";
            this.colPositionPartaker.ReadOnly = true;
            this.colPositionPartaker.Width = 150;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Check";
            this.dataGridViewCheckBoxColumn1.FalseValue = "";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Tham dự họp";
            this.dataGridViewCheckBoxColumn1.IndeterminateValue = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.TrueValue = "";
            this.dataGridViewCheckBoxColumn1.Visible = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblHour);
            this.panel6.Controls.Add(this.textBox1);
            this.panel6.Controls.Add(this.lblNotes);
            this.panel6.Controls.Add(this.lblHourEnd);
            this.panel6.Controls.Add(this.txtOrganizationMeeting);
            this.panel6.Controls.Add(this.txtMeetingName);
            this.panel6.Controls.Add(this.dtpStartTime);
            this.panel6.Controls.Add(this.lblGoverningOrganization);
            this.panel6.Controls.Add(this.dtpDay);
            this.panel6.Controls.Add(this.lblTime);
            this.panel6.Controls.Add(this.txtRoom);
            this.panel6.Controls.Add(this.lblRoom);
            this.panel6.Controls.Add(this.lblMeeting);
            this.panel6.Controls.Add(this.lblNameAttendingredient);
            this.panel6.Controls.Add(this.lblend);
            this.panel6.Controls.Add(this.dtpEndTime);
            this.panel6.Controls.Add(this.lblMeetingInformation);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(596, 225);
            this.panel6.TabIndex = 0;
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHour.Location = new System.Drawing.Point(334, 132);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(39, 19);
            this.lblHour.TabIndex = 240;
            this.lblHour.Text = "Giờ:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(160, 161);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.Size = new System.Drawing.Size(392, 26);
            this.textBox1.TabIndex = 238;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(24, 164);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(69, 19);
            this.lblNotes.TabIndex = 239;
            this.lblNotes.Text = "Ghi chú:";
            // 
            // lblHourEnd
            // 
            this.lblHourEnd.AutoSize = true;
            this.lblHourEnd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHourEnd.Location = new System.Drawing.Point(461, 132);
            this.lblHourEnd.Name = "lblHourEnd";
            this.lblHourEnd.Size = new System.Drawing.Size(15, 19);
            this.lblHourEnd.TabIndex = 237;
            this.lblHourEnd.Text = ":";
            // 
            // txtOrganizationMeeting
            // 
            this.txtOrganizationMeeting.BackColor = System.Drawing.SystemColors.Window;
            this.txtOrganizationMeeting.Enabled = false;
            this.txtOrganizationMeeting.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrganizationMeeting.Location = new System.Drawing.Point(160, 37);
            this.txtOrganizationMeeting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOrganizationMeeting.Multiline = true;
            this.txtOrganizationMeeting.Name = "txtOrganizationMeeting";
            this.txtOrganizationMeeting.Size = new System.Drawing.Size(392, 26);
            this.txtOrganizationMeeting.TabIndex = 236;
            // 
            // txtMeetingName
            // 
            this.txtMeetingName.BackColor = System.Drawing.SystemColors.Window;
            this.txtMeetingName.Enabled = false;
            this.txtMeetingName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeetingName.Location = new System.Drawing.Point(160, 67);
            this.txtMeetingName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMeetingName.Multiline = true;
            this.txtMeetingName.Name = "txtMeetingName";
            this.txtMeetingName.Size = new System.Drawing.Size(392, 26);
            this.txtMeetingName.TabIndex = 235;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CalendarFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.CustomFormat = "hh:mm";
            this.dtpStartTime.Enabled = false;
            this.dtpStartTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(385, 128);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(70, 27);
            this.dtpStartTime.TabIndex = 233;
            // 
            // lblGoverningOrganization
            // 
            this.lblGoverningOrganization.AutoSize = true;
            this.lblGoverningOrganization.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoverningOrganization.Location = new System.Drawing.Point(24, 40);
            this.lblGoverningOrganization.Name = "lblGoverningOrganization";
            this.lblGoverningOrganization.Size = new System.Drawing.Size(118, 19);
            this.lblGoverningOrganization.TabIndex = 228;
            this.lblGoverningOrganization.Text = "Đơn vị tổ chức:";
            // 
            // dtpDay
            // 
            this.dtpDay.CalendarFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDay.CustomFormat = "dd/MM/yyyy";
            this.dtpDay.Enabled = false;
            this.dtpDay.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDay.Location = new System.Drawing.Point(160, 128);
            this.dtpDay.Name = "dtpDay";
            this.dtpDay.Size = new System.Drawing.Size(107, 27);
            this.dtpDay.TabIndex = 232;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(24, 134);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(82, 19);
            this.lblTime.TabIndex = 230;
            this.lblTime.Text = "Thời gian:";
            // 
            // txtRoom
            // 
            this.txtRoom.BackColor = System.Drawing.SystemColors.Window;
            this.txtRoom.Enabled = false;
            this.txtRoom.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoom.Location = new System.Drawing.Point(160, 97);
            this.txtRoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRoom.Multiline = true;
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(392, 26);
            this.txtRoom.TabIndex = 231;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoom.Location = new System.Drawing.Point(24, 100);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(60, 19);
            this.lblRoom.TabIndex = 229;
            this.lblRoom.Text = "Phòng:";
            // 
            // lblMeeting
            // 
            this.lblMeeting.AutoSize = true;
            this.lblMeeting.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeeting.Location = new System.Drawing.Point(24, 70);
            this.lblMeeting.Name = "lblMeeting";
            this.lblMeeting.Size = new System.Drawing.Size(82, 19);
            this.lblMeeting.TabIndex = 227;
            this.lblMeeting.Text = "Cuộc họp:";
            // 
            // lblNameAttendingredient
            // 
            this.lblNameAttendingredient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblNameAttendingredient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblNameAttendingredient.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameAttendingredient.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNameAttendingredient.Location = new System.Drawing.Point(0, 195);
            this.lblNameAttendingredient.Name = "lblNameAttendingredient";
            this.lblNameAttendingredient.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblNameAttendingredient.Size = new System.Drawing.Size(596, 30);
            this.lblNameAttendingredient.TabIndex = 226;
            this.lblNameAttendingredient.Text = "DANH SÁCH NGƯỜI ĐƯỢC MỜI";
            this.lblNameAttendingredient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblend
            // 
            this.lblend.AutoSize = true;
            this.lblend.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblend.Location = new System.Drawing.Point(456, 136);
            this.lblend.Name = "lblend";
            this.lblend.Size = new System.Drawing.Size(15, 19);
            this.lblend.TabIndex = 222;
            this.lblend.Text = ":";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CalendarFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.CustomFormat = "hh:mm";
            this.dtpEndTime.Enabled = false;
            this.dtpEndTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(482, 128);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(70, 27);
            this.dtpEndTime.TabIndex = 219;
            // 
            // lblMeetingInformation
            // 
            this.lblMeetingInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblMeetingInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMeetingInformation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeetingInformation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMeetingInformation.Location = new System.Drawing.Point(0, 0);
            this.lblMeetingInformation.Name = "lblMeetingInformation";
            this.lblMeetingInformation.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblMeetingInformation.Size = new System.Drawing.Size(596, 32);
            this.lblMeetingInformation.TabIndex = 209;
            this.lblMeetingInformation.Text = "THÔNG TIN HỘI HỌP";
            this.lblMeetingInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmDetailInforByCardChip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 711);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmDetailInforByCardChip";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDetailInforByCardChip_FormClosing);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMeetingToday)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAttend)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel3;
        private Label lblguideEnter;
        private Button btnCancel;
        private Panel panel7;
        private TextBox txtNote;
        private Label lblNotess;
        private Label lblInforPlus;
        private Button btnConfirm;
        private SplitContainer splitContainer1;
        private Panel panel2;
        private Panel panel4;
        private Panel panel8;
        private Label lblListMeetingtoDay;
        private TextBox txtOrg;
        private DateTimePicker dtpBirthDate;
        private Label lblBrithDay;
        private TextBox txtIdentityCard;
        private Label lblCMND;
        private TextBox txtPhoneNo;
        private Label lblTel;
        private TextBox txtEmail;
        private Label lblEmail;
        private Label lblPosition;
        private Label lblLowerName;
        private Label lblChooseOrg;
        private Label lblJournalistInfo;
        private Panel panel1;
        private Panel panel5;
        private CommonControls.Custom.CommonDataGridView dgvListAttend;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colNamePartaker;
        private DataGridViewTextBoxColumn colNameOrg;
        private DataGridViewTextBoxColumn colPositionPartaker;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private Panel panel6;
        private Label lblHour;
        private TextBox textBox1;
        private Label lblNotes;
        private Label lblHourEnd;
        private TextBox txtOrganizationMeeting;
        private TextBox txtMeetingName;
        private DateTimePicker dtpStartTime;
        private Label lblGoverningOrganization;
        private DateTimePicker dtpDay;
        private Label lblTime;
        private TextBox txtRoom;
        private Label lblRoom;
        private Label lblMeeting;
        private Label lblNameAttendingredient;
        private Label lblend;
        private DateTimePicker dtpEndTime;
        private Label lblMeetingInformation;
        private CommonControls.Custom.CommonDataGridView dgvListMeetingToday;
        private DataGridViewTextBoxColumn colSttnew;
        private DataGridViewTextBoxColumn colMeetingId;
        private DataGridViewTextBoxColumn colMeetingName;
        private DataGridViewTextBoxColumn colOrganizationMeeting;
        private DataGridViewCheckBoxColumn colCheck;
        private DataGridViewTextBoxColumn colDateTime;
        private DataGridViewTextBoxColumn colStartTime;
        private DataGridViewTextBoxColumn colEndTime;
        private DataGridViewTextBoxColumn colRoomName;
        private DataGridViewTextBoxColumn colNumber;
        private DataGridViewTextBoxColumn colListAttend;
        private TextBox txtPosition;
        private TextBox txtLowerFullName;
    }
}