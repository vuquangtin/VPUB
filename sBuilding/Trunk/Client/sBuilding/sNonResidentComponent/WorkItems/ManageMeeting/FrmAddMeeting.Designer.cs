namespace sNonResidenComponent.WorkItems.ManageMeeting
{
    partial class FrmAddMeeting
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.cbxNameRoom = new System.Windows.Forms.ComboBox();
            this.cbxOrganization = new System.Windows.Forms.ComboBox();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblMeetingInformationNew = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblHourEnd = new System.Windows.Forms.Label();
            this.tbxNameMeeting = new System.Windows.Forms.TextBox();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblGoverningOrganization = new System.Windows.Forms.Label();
            this.dtpDay = new System.Windows.Forms.DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblMeeting = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgvListAttend = new CommonControls.Custom.CommonDataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNamePartaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNameOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPositionPartaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3dotstar = new System.Windows.Forms.Label();
            this.label2dotstar = new System.Windows.Forms.Label();
            this.label1dotstar = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAddAttend = new System.Windows.Forms.Button();
            this.txtPositionAttend = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblNameAttend = new System.Windows.Forms.Label();
            this.txtOrg = new System.Windows.Forms.TextBox();
            this.lblChooseOrg = new System.Windows.Forms.Label();
            this.lblListAttend = new System.Windows.Forms.Label();
            this.lblAttendInfo = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnRefresh1 = new System.Windows.Forms.Button();
            this.lblguideEnterAddMeeting = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbNoteNonResidentAddMeeting = new System.Windows.Forms.Label();
            this.lbTitleNonResidentAddMeeting = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAttend)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1072, 601);
            this.panel1.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1072, 601);
            this.panel3.TabIndex = 112;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 53);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(1072, 471);
            this.splitContainer1.SplitterDistance = 491;
            this.splitContainer1.TabIndex = 137;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dtpStartTime);
            this.panel2.Controls.Add(this.lblStart);
            this.panel2.Controls.Add(this.cbxNameRoom);
            this.panel2.Controls.Add(this.cbxOrganization);
            this.panel2.Controls.Add(this.lblHour);
            this.panel2.Controls.Add(this.lblMeetingInformationNew);
            this.panel2.Controls.Add(this.txtNote);
            this.panel2.Controls.Add(this.lblNotes);
            this.panel2.Controls.Add(this.lblHourEnd);
            this.panel2.Controls.Add(this.tbxNameMeeting);
            this.panel2.Controls.Add(this.dtpEndTime);
            this.panel2.Controls.Add(this.lblGoverningOrganization);
            this.panel2.Controls.Add(this.dtpDay);
            this.panel2.Controls.Add(this.lblTime);
            this.panel2.Controls.Add(this.lblRoom);
            this.panel2.Controls.Add(this.lblMeeting);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 471);
            this.panel2.TabIndex = 139;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CalendarFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.CustomFormat = "HH:mm tt";
            this.dtpStartTime.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(283, 125);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(82, 22);
            this.dtpStartTime.TabIndex = 5;
            this.dtpStartTime.Value = new System.DateTime(2017, 3, 5, 8, 0, 0, 0);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblStart.ForeColor = System.Drawing.Color.Red;
            this.lblStart.Location = new System.Drawing.Point(109, 70);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(24, 14);
            this.lblStart.TabIndex = 213;
            this.lblStart.Text = "(*)";
            // 
            // cbxNameRoom
            // 
            this.cbxNameRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNameRoom.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbxNameRoom.FormattingEnabled = true;
            this.cbxNameRoom.Location = new System.Drawing.Point(141, 95);
            this.cbxNameRoom.Name = "cbxNameRoom";
            this.cbxNameRoom.Size = new System.Drawing.Size(332, 22);
            this.cbxNameRoom.TabIndex = 3;
            // 
            // cbxOrganization
            // 
            this.cbxOrganization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOrganization.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbxOrganization.FormattingEnabled = true;
            this.cbxOrganization.Location = new System.Drawing.Point(141, 35);
            this.cbxOrganization.Name = "cbxOrganization";
            this.cbxOrganization.Size = new System.Drawing.Size(332, 22);
            this.cbxOrganization.TabIndex = 1;
            // 
            // lblHour
            // 
            this.lblHour.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblHour.Location = new System.Drawing.Point(236, 130);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(48, 16);
            this.lblHour.TabIndex = 210;
            this.lblHour.Text = "Giờ:";
            // 
            // lblMeetingInformationNew
            // 
            this.lblMeetingInformationNew.BackColor = System.Drawing.Color.Transparent;
            this.lblMeetingInformationNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMeetingInformationNew.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeetingInformationNew.ForeColor = System.Drawing.Color.Black;
            this.lblMeetingInformationNew.Location = new System.Drawing.Point(0, 0);
            this.lblMeetingInformationNew.Name = "lblMeetingInformationNew";
            this.lblMeetingInformationNew.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblMeetingInformationNew.Size = new System.Drawing.Size(489, 29);
            this.lblMeetingInformationNew.TabIndex = 209;
            this.lblMeetingInformationNew.Text = "THÔNG TIN HỘI HỌP";
            this.lblMeetingInformationNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNote.BackColor = System.Drawing.SystemColors.Window;
            this.txtNote.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtNote.Location = new System.Drawing.Point(141, 154);
            this.txtNote.MaxLength = 224;
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNote.Size = new System.Drawing.Size(332, 310);
            this.txtNote.TabIndex = 7;
            this.txtNote.WordWrap = false;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblNotes.Location = new System.Drawing.Point(17, 158);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(52, 14);
            this.lblNotes.TabIndex = 207;
            this.lblNotes.Text = "Ghi chú:";
            // 
            // lblHourEnd
            // 
            this.lblHourEnd.AutoSize = true;
            this.lblHourEnd.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblHourEnd.Location = new System.Drawing.Point(371, 130);
            this.lblHourEnd.Name = "lblHourEnd";
            this.lblHourEnd.Size = new System.Drawing.Size(11, 14);
            this.lblHourEnd.TabIndex = 205;
            this.lblHourEnd.Text = ":";
            // 
            // tbxNameMeeting
            // 
            this.tbxNameMeeting.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tbxNameMeeting.Location = new System.Drawing.Point(141, 64);
            this.tbxNameMeeting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxNameMeeting.MaxLength = 255;
            this.tbxNameMeeting.Multiline = true;
            this.tbxNameMeeting.Name = "tbxNameMeeting";
            this.tbxNameMeeting.Size = new System.Drawing.Size(332, 26);
            this.tbxNameMeeting.TabIndex = 2;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CalendarFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.CustomFormat = "HH:mm tt";
            this.dtpEndTime.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(391, 125);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(82, 22);
            this.dtpEndTime.TabIndex = 6;
            this.dtpEndTime.Value = new System.DateTime(2017, 3, 5, 17, 0, 0, 0);
            // 
            // lblGoverningOrganization
            // 
            this.lblGoverningOrganization.AutoSize = true;
            this.lblGoverningOrganization.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblGoverningOrganization.Location = new System.Drawing.Point(17, 38);
            this.lblGoverningOrganization.Name = "lblGoverningOrganization";
            this.lblGoverningOrganization.Size = new System.Drawing.Size(92, 14);
            this.lblGoverningOrganization.TabIndex = 175;
            this.lblGoverningOrganization.Text = "Đơn vị tổ chức:";
            // 
            // dtpDay
            // 
            this.dtpDay.CalendarFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDay.CustomFormat = "dd/MM/yyyy";
            this.dtpDay.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDay.Location = new System.Drawing.Point(141, 125);
            this.dtpDay.Name = "dtpDay";
            this.dtpDay.Size = new System.Drawing.Size(89, 22);
            this.dtpDay.TabIndex = 4;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTime.Location = new System.Drawing.Point(17, 130);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(61, 14);
            this.lblTime.TabIndex = 177;
            this.lblTime.Text = "Thời gian:";
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblRoom.Location = new System.Drawing.Point(17, 98);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(46, 14);
            this.lblRoom.TabIndex = 176;
            this.lblRoom.Text = "Phòng:";
            // 
            // lblMeeting
            // 
            this.lblMeeting.AutoSize = true;
            this.lblMeeting.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblMeeting.Location = new System.Drawing.Point(17, 71);
            this.lblMeeting.Name = "lblMeeting";
            this.lblMeeting.Size = new System.Drawing.Size(63, 14);
            this.lblMeeting.TabIndex = 174;
            this.lblMeeting.Text = "Cuộc họp:";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(577, 471);
            this.panel4.TabIndex = 136;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dgvListAttend);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 184);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(575, 285);
            this.panel7.TabIndex = 7;
            // 
            // dgvListAttend
            // 
            this.dgvListAttend.AllowDrop = true;
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
            this.colCheck});
            this.dgvListAttend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListAttend.Location = new System.Drawing.Point(0, 0);
            this.dgvListAttend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListAttend.MultiSelect = false;
            this.dgvListAttend.Name = "dgvListAttend";
            this.dgvListAttend.ReadOnly = true;
            this.dgvListAttend.RowHeadersVisible = false;
            this.dgvListAttend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListAttend.Size = new System.Drawing.Size(575, 285);
            this.dgvListAttend.TabIndex = 13;
            this.dgvListAttend.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListAttend_CellMouseClick);
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
            this.colNameOrg.Width = 140;
            // 
            // colPositionPartaker
            // 
            this.colPositionPartaker.DataPropertyName = "PositionPartaker";
            this.colPositionPartaker.HeaderText = "Chức vụ";
            this.colPositionPartaker.Name = "colPositionPartaker";
            this.colPositionPartaker.ReadOnly = true;
            this.colPositionPartaker.Width = 140;
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
            this.colCheck.Width = 110;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label3dotstar);
            this.panel6.Controls.Add(this.label2dotstar);
            this.panel6.Controls.Add(this.label1dotstar);
            this.panel6.Controls.Add(this.btnRefresh);
            this.panel6.Controls.Add(this.btnAddAttend);
            this.panel6.Controls.Add(this.txtPositionAttend);
            this.panel6.Controls.Add(this.txtName);
            this.panel6.Controls.Add(this.lblPosition);
            this.panel6.Controls.Add(this.lblNameAttend);
            this.panel6.Controls.Add(this.txtOrg);
            this.panel6.Controls.Add(this.lblChooseOrg);
            this.panel6.Controls.Add(this.lblListAttend);
            this.panel6.Controls.Add(this.lblAttendInfo);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(575, 184);
            this.panel6.TabIndex = 6;
            // 
            // label3dotstar
            // 
            this.label3dotstar.AutoSize = true;
            this.label3dotstar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3dotstar.ForeColor = System.Drawing.Color.Red;
            this.label3dotstar.Location = new System.Drawing.Point(126, 94);
            this.label3dotstar.Name = "label3dotstar";
            this.label3dotstar.Size = new System.Drawing.Size(24, 14);
            this.label3dotstar.TabIndex = 229;
            this.label3dotstar.Text = "(*)";
            // 
            // label2dotstar
            // 
            this.label2dotstar.AutoSize = true;
            this.label2dotstar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2dotstar.ForeColor = System.Drawing.Color.Red;
            this.label2dotstar.Location = new System.Drawing.Point(126, 67);
            this.label2dotstar.Name = "label2dotstar";
            this.label2dotstar.Size = new System.Drawing.Size(24, 14);
            this.label2dotstar.TabIndex = 228;
            this.label2dotstar.Text = "(*)";
            // 
            // label1dotstar
            // 
            this.label1dotstar.AutoSize = true;
            this.label1dotstar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1dotstar.ForeColor = System.Drawing.Color.Red;
            this.label1dotstar.Location = new System.Drawing.Point(126, 40);
            this.label1dotstar.Name = "label1dotstar";
            this.label1dotstar.Size = new System.Drawing.Size(24, 14);
            this.label1dotstar.TabIndex = 227;
            this.label1dotstar.Text = "(*)";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.btnRefresh.Location = new System.Drawing.Point(449, 119);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(95, 28);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnAddAttend
            // 
            this.btnAddAttend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAttend.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.btnAddAttend.Location = new System.Drawing.Point(348, 119);
            this.btnAddAttend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddAttend.Name = "btnAddAttend";
            this.btnAddAttend.Size = new System.Drawing.Size(95, 28);
            this.btnAddAttend.TabIndex = 11;
            this.btnAddAttend.Text = "Thêm";
            this.btnAddAttend.UseVisualStyleBackColor = true;
            // 
            // txtPositionAttend
            // 
            this.txtPositionAttend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPositionAttend.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtPositionAttend.Location = new System.Drawing.Point(162, 91);
            this.txtPositionAttend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPositionAttend.MaxLength = 49;
            this.txtPositionAttend.Name = "txtPositionAttend";
            this.txtPositionAttend.Size = new System.Drawing.Size(382, 22);
            this.txtPositionAttend.TabIndex = 10;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtName.Location = new System.Drawing.Point(162, 64);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.MaxLength = 149;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(382, 22);
            this.txtName.TabIndex = 9;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblPosition.Location = new System.Drawing.Point(31, 94);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(56, 14);
            this.lblPosition.TabIndex = 226;
            this.lblPosition.Text = "Chức vụ:";
            // 
            // lblNameAttend
            // 
            this.lblNameAttend.AutoSize = true;
            this.lblNameAttend.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblNameAttend.Location = new System.Drawing.Point(31, 67);
            this.lblNameAttend.Name = "lblNameAttend";
            this.lblNameAttend.Size = new System.Drawing.Size(33, 14);
            this.lblNameAttend.TabIndex = 224;
            this.lblNameAttend.Text = "Tên:";
            // 
            // txtOrg
            // 
            this.txtOrg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrg.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtOrg.Location = new System.Drawing.Point(162, 37);
            this.txtOrg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOrg.MaxLength = 149;
            this.txtOrg.Name = "txtOrg";
            this.txtOrg.Size = new System.Drawing.Size(382, 22);
            this.txtOrg.TabIndex = 8;
            // 
            // lblChooseOrg
            // 
            this.lblChooseOrg.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblChooseOrg.Location = new System.Drawing.Point(31, 39);
            this.lblChooseOrg.Name = "lblChooseOrg";
            this.lblChooseOrg.Size = new System.Drawing.Size(89, 23);
            this.lblChooseOrg.TabIndex = 221;
            this.lblChooseOrg.Text = "Tổ chức:";
            // 
            // lblListAttend
            // 
            this.lblListAttend.BackColor = System.Drawing.Color.Transparent;
            this.lblListAttend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblListAttend.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblListAttend.ForeColor = System.Drawing.Color.Black;
            this.lblListAttend.Location = new System.Drawing.Point(0, 154);
            this.lblListAttend.Name = "lblListAttend";
            this.lblListAttend.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblListAttend.Size = new System.Drawing.Size(575, 30);
            this.lblListAttend.TabIndex = 220;
            this.lblListAttend.Text = "DANH SÁCH NGƯỜI THAM DỰ";
            this.lblListAttend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAttendInfo
            // 
            this.lblAttendInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblAttendInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAttendInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblAttendInfo.ForeColor = System.Drawing.Color.Black;
            this.lblAttendInfo.Location = new System.Drawing.Point(0, 0);
            this.lblAttendInfo.Name = "lblAttendInfo";
            this.lblAttendInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblAttendInfo.Size = new System.Drawing.Size(575, 29);
            this.lblAttendInfo.TabIndex = 217;
            this.lblAttendInfo.Text = "THÔNG TIN NGƯỜI THAM DỰ";
            this.lblAttendInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 524);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panel5.Size = new System.Drawing.Size(1072, 77);
            this.panel5.TabIndex = 136;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.btnRefresh1);
            this.panel8.Controls.Add(this.lblguideEnterAddMeeting);
            this.panel8.Controls.Add(this.btnCancel);
            this.panel8.Controls.Add(this.btnAdd);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 6);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1072, 71);
            this.panel8.TabIndex = 3;
            // 
            // btnRefresh1
            // 
            this.btnRefresh1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh1.AutoSize = true;
            this.btnRefresh1.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.btnRefresh1.Location = new System.Drawing.Point(851, 36);
            this.btnRefresh1.Name = "btnRefresh1";
            this.btnRefresh1.Size = new System.Drawing.Size(95, 27);
            this.btnRefresh1.TabIndex = 15;
            this.btnRefresh1.Text = "Làm mới";
            this.btnRefresh1.UseVisualStyleBackColor = true;
            // 
            // lblguideEnterAddMeeting
            // 
            this.lblguideEnterAddMeeting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.lblguideEnterAddMeeting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblguideEnterAddMeeting.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblguideEnterAddMeeting.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblguideEnterAddMeeting.ForeColor = System.Drawing.Color.Black;
            this.lblguideEnterAddMeeting.Location = new System.Drawing.Point(0, 0);
            this.lblguideEnterAddMeeting.Name = "lblguideEnterAddMeeting";
            this.lblguideEnterAddMeeting.Size = new System.Drawing.Size(1070, 33);
            this.lblguideEnterAddMeeting.TabIndex = 21;
            this.lblguideEnterAddMeeting.Text = "Ấn nút F10 để thêm cuộc họp";
            this.lblguideEnterAddMeeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.btnCancel.Location = new System.Drawing.Point(952, 36);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.btnAdd.Location = new System.Drawing.Point(758, 36);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 27);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lbNoteNonResidentAddMeeting);
            this.panel9.Controls.Add(this.lbTitleNonResidentAddMeeting);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1072, 53);
            this.panel9.TabIndex = 128;
            // 
            // lbNoteNonResidentAddMeeting
            // 
            this.lbNoteNonResidentAddMeeting.AutoSize = true;
            this.lbNoteNonResidentAddMeeting.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoteNonResidentAddMeeting.Location = new System.Drawing.Point(14, 28);
            this.lbNoteNonResidentAddMeeting.Margin = new System.Windows.Forms.Padding(3);
            this.lbNoteNonResidentAddMeeting.Name = "lbNoteNonResidentAddMeeting";
            this.lbNoteNonResidentAddMeeting.Size = new System.Drawing.Size(161, 14);
            this.lbNoteNonResidentAddMeeting.TabIndex = 1;
            this.lbNoteNonResidentAddMeeting.Text = "Tạo cuộc họp vào hệ thống";
            // 
            // lbTitleNonResidentAddMeeting
            // 
            this.lbTitleNonResidentAddMeeting.AutoSize = true;
            this.lbTitleNonResidentAddMeeting.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleNonResidentAddMeeting.Location = new System.Drawing.Point(14, 10);
            this.lbTitleNonResidentAddMeeting.Name = "lbTitleNonResidentAddMeeting";
            this.lbTitleNonResidentAddMeeting.Size = new System.Drawing.Size(168, 14);
            this.lbTitleNonResidentAddMeeting.TabIndex = 0;
            this.lbTitleNonResidentAddMeeting.Text = "Thêm Thông Tin Cuộc Họp";
            // 
            // FrmAddMeeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 613);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAddMeeting";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Cuộc Họp";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAttend)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbNoteNonResidentAddMeeting;
        private System.Windows.Forms.Label lbTitleNonResidentAddMeeting;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.ComboBox cbxNameRoom;
        private System.Windows.Forms.ComboBox cbxOrganization;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblMeetingInformationNew;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblHourEnd;
        private System.Windows.Forms.TextBox tbxNameMeeting;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblGoverningOrganization;
        private System.Windows.Forms.DateTimePicker dtpDay;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblMeeting;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnRefresh1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3dotstar;
        private System.Windows.Forms.Label label2dotstar;
        private System.Windows.Forms.Label label1dotstar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAddAttend;
        private System.Windows.Forms.TextBox txtPositionAttend;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblNameAttend;
        private System.Windows.Forms.TextBox txtOrg;
        private System.Windows.Forms.Label lblChooseOrg;
        private System.Windows.Forms.Label lblListAttend;
        private System.Windows.Forms.Label lblAttendInfo;
        private System.Windows.Forms.Panel panel7;
        private CommonControls.Custom.CommonDataGridView dgvListAttend;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNamePartaker;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameOrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPositionPartaker;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblguideEnterAddMeeting;
    }
}