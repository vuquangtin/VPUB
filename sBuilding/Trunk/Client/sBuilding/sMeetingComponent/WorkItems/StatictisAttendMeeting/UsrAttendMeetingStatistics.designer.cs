using System.ComponentModel;

namespace sMeetingComponent.WorkItems.StatictisAttendMeeting
{
    partial class UsrAttendMeetingStatistics
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrAttendMeetingStatistics));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblRightAreaTitleListAttendace = new CommonControls.Custom.TitleLabel();
            this.cmsPersoRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniInfor = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1Outside = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvAttendMeetingStatisticList = new CommonControls.Custom.CommonDataGridView();
            this.colOrgMeetingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrganizationMeetingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeetingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeetingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberPeopleInvation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberPeopleAttend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberAddPeopleAttend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberJournalist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberNonResident = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInfo = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlStatistic = new System.Windows.Forms.Panel();
            this.txtNumberOutSide = new System.Windows.Forms.TextBox();
            this.txtNumberJournalist = new System.Windows.Forms.TextBox();
            this.txtNumberAdded = new System.Windows.Forms.TextBox();
            this.txtNumberAttender = new System.Windows.Forms.TextBox();
            this.txtNumberRegister = new System.Windows.Forms.TextBox();
            this.lblSumOutSide = new System.Windows.Forms.Label();
            this.lblSumJournalist = new System.Windows.Forms.Label();
            this.lblSumAdded = new System.Windows.Forms.Label();
            this.lblSumAttender = new System.Windows.Forms.Label();
            this.lblSumRegister = new System.Windows.Forms.Label();
            this.commonDataGridView1 = new ClientModel.Controls.Commons.CommonDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPositionPartakerEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsNonResidentEx = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentityCardEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhoneEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFilterByDate = new System.Windows.Forms.Label();
            this.lblTo1 = new System.Windows.Forms.Label();
            this.dtpDateIn2 = new System.Windows.Forms.DateTimePicker();
            this.dtpDateIn = new System.Windows.Forms.DateTimePicker();
            this.cbxNameOrgSearch = new System.Windows.Forms.ComboBox();
            this.lblFilterByOrgName = new System.Windows.Forms.Label();
            this.txtMeetingNameSearchs = new System.Windows.Forms.TextBox();
            this.lblFilterByMeetingName = new System.Windows.Forms.Label();
            this.tsmCard = new CommonControls.Custom.CommonToolStrip();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.dataGridview4Export = new ClientModel.Controls.Commons.CommonDataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberNonResidentEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsPersoRecord.SuspendLayout();
            this.panel1Outside.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendMeetingStatisticList)).BeginInit();
            this.pnlStatistic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView1)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tsmCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridview4Export)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRightAreaTitleListAttendace
            // 
            this.lblRightAreaTitleListAttendace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitleListAttendace.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitleListAttendace.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblRightAreaTitleListAttendace.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitleListAttendace.Location = new System.Drawing.Point(12, 11);
            this.lblRightAreaTitleListAttendace.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRightAreaTitleListAttendace.Name = "lblRightAreaTitleListAttendace";
            this.lblRightAreaTitleListAttendace.Size = new System.Drawing.Size(2030, 69);
            this.lblRightAreaTitleListAttendace.TabIndex = 70;
            this.lblRightAreaTitleListAttendace.Text = "THỐNG KÊ HỘI HỌP";
            this.lblRightAreaTitleListAttendace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmsPersoRecord
            // 
            this.cmsPersoRecord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniInfor});
            this.cmsPersoRecord.Name = "contextMenuStrip1";
            this.cmsPersoRecord.Size = new System.Drawing.Size(271, 42);
            // 
            // mniInfor
            // 
            this.mniInfor.Image = global::sMeetingComponent.Properties.Resources.info16x16;
            this.mniInfor.Name = "mniInfor";
            this.mniInfor.Size = new System.Drawing.Size(270, 38);
            this.mniInfor.Text = "Xem Thông Tin";
            this.mniInfor.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // panel1Outside
            // 
            this.panel1Outside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1Outside.Controls.Add(this.panel1);
            this.panel1Outside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1Outside.Location = new System.Drawing.Point(12, 80);
            this.panel1Outside.Margin = new System.Windows.Forms.Padding(6);
            this.panel1Outside.Name = "panel1Outside";
            this.panel1Outside.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.panel1Outside.Size = new System.Drawing.Size(2030, 1015);
            this.panel1Outside.TabIndex = 71;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(12, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2004, 991);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvAttendMeetingStatisticList);
            this.panel3.Controls.Add(this.pnlStatistic);
            this.panel3.Controls.Add(this.commonDataGridView1);
            this.panel3.Controls.Add(this.pnlFilterBox);
            this.panel3.Controls.Add(this.tsmCard);
            this.panel3.Controls.Add(this.pagerPanel1);
            this.panel3.Controls.Add(this.dataGridview4Export);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2004, 991);
            this.panel3.TabIndex = 2;
            // 
            // dgvAttendMeetingStatisticList
            // 
            this.dgvAttendMeetingStatisticList.AllowUserToAddRows = false;
            this.dgvAttendMeetingStatisticList.AllowUserToDeleteRows = false;
            this.dgvAttendMeetingStatisticList.AllowUserToOrderColumns = true;
            this.dgvAttendMeetingStatisticList.AllowUserToResizeRows = false;
            this.dgvAttendMeetingStatisticList.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendMeetingStatisticList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAttendMeetingStatisticList.ColumnHeadersHeight = 26;
            this.dgvAttendMeetingStatisticList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrgMeetingId,
            this.colSTT,
            this.colOrganizationMeetingName,
            this.colMeetingId,
            this.colMeetingName,
            this.colDateTime,
            this.colStartTime,
            this.colEndTime,
            this.colNumberPeopleInvation,
            this.colNumberPeopleAttend,
            this.colNumberAddPeopleAttend,
            this.colNumberJournalist,
            this.colNumberNonResident,
            this.colNumberTotal,
            this.colInfo});
            this.dgvAttendMeetingStatisticList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttendMeetingStatisticList.Location = new System.Drawing.Point(0, 439);
            this.dgvAttendMeetingStatisticList.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.dgvAttendMeetingStatisticList.MultiSelect = false;
            this.dgvAttendMeetingStatisticList.Name = "dgvAttendMeetingStatisticList";
            this.dgvAttendMeetingStatisticList.ReadOnly = true;
            this.dgvAttendMeetingStatisticList.RowHeadersVisible = false;
            this.dgvAttendMeetingStatisticList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendMeetingStatisticList.Size = new System.Drawing.Size(2002, 503);
            this.dgvAttendMeetingStatisticList.TabIndex = 106;
            // 
            // colOrgMeetingId
            // 
            this.colOrgMeetingId.DataPropertyName = "OrgMeetingId";
            this.colOrgMeetingId.HeaderText = "organizationMeetingId";
            this.colOrgMeetingId.Name = "colOrgMeetingId";
            this.colOrgMeetingId.ReadOnly = true;
            this.colOrgMeetingId.Visible = false;
            // 
            // colSTT
            // 
            this.colSTT.DataPropertyName = "STT";
            this.colSTT.HeaderText = "Stt";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 40;
            // 
            // colOrganizationMeetingName
            // 
            this.colOrganizationMeetingName.DataPropertyName = "OrganizationMeetingName";
            this.colOrganizationMeetingName.HeaderText = "Đơn vị tổ chức";
            this.colOrganizationMeetingName.Name = "colOrganizationMeetingName";
            this.colOrganizationMeetingName.ReadOnly = true;
            this.colOrganizationMeetingName.Width = 120;
            // 
            // colMeetingId
            // 
            this.colMeetingId.DataPropertyName = "MeetingId";
            this.colMeetingId.HeaderText = "MeetingId";
            this.colMeetingId.Name = "colMeetingId";
            this.colMeetingId.ReadOnly = true;
            this.colMeetingId.Visible = false;
            this.colMeetingId.Width = 101;
            // 
            // colMeetingName
            // 
            this.colMeetingName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMeetingName.DataPropertyName = "MeetingName";
            this.colMeetingName.HeaderText = "Cuộc Họp";
            this.colMeetingName.Name = "colMeetingName";
            this.colMeetingName.ReadOnly = true;
            // 
            // colDateTime
            // 
            this.colDateTime.DataPropertyName = "DateTime";
            this.colDateTime.HeaderText = "Ngày";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.ReadOnly = true;
            this.colDateTime.Width = 80;
            // 
            // colStartTime
            // 
            this.colStartTime.DataPropertyName = "InputTime";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colStartTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.colStartTime.HeaderText = "Giờ Bắt Đầu";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.ReadOnly = true;
            this.colStartTime.Width = 90;
            // 
            // colEndTime
            // 
            this.colEndTime.DataPropertyName = "OutputTime";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEndTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.colEndTime.HeaderText = "Giờ Kết Thúc";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.ReadOnly = true;
            this.colEndTime.Visible = false;
            this.colEndTime.Width = 90;
            // 
            // colNumberPeopleInvation
            // 
            this.colNumberPeopleInvation.DataPropertyName = "NumberPeopleInvation";
            this.colNumberPeopleInvation.HeaderText = "SL được mời";
            this.colNumberPeopleInvation.Name = "colNumberPeopleInvation";
            this.colNumberPeopleInvation.ReadOnly = true;
            this.colNumberPeopleInvation.Width = 145;
            // 
            // colNumberPeopleAttend
            // 
            this.colNumberPeopleAttend.DataPropertyName = "NumberPeopleAttend";
            this.colNumberPeopleAttend.HeaderText = "SL tham dự";
            this.colNumberPeopleAttend.Name = "colNumberPeopleAttend";
            this.colNumberPeopleAttend.ReadOnly = true;
            this.colNumberPeopleAttend.Width = 115;
            // 
            // colNumberAddPeopleAttend
            // 
            this.colNumberAddPeopleAttend.DataPropertyName = "NumberAddPeopleAttend";
            this.colNumberAddPeopleAttend.HeaderText = "SL thêm Vào";
            this.colNumberAddPeopleAttend.Name = "colNumberAddPeopleAttend";
            this.colNumberAddPeopleAttend.ReadOnly = true;
            this.colNumberAddPeopleAttend.Width = 90;
            // 
            // colNumberJournalist
            // 
            this.colNumberJournalist.DataPropertyName = "NumberJournalist";
            this.colNumberJournalist.HeaderText = "SL Nhà Báo";
            this.colNumberJournalist.Name = "colNumberJournalist";
            this.colNumberJournalist.ReadOnly = true;
            this.colNumberJournalist.Width = 80;
            // 
            // colNumberNonResident
            // 
            this.colNumberNonResident.DataPropertyName = "colNumberNonResident";
            this.colNumberNonResident.HeaderText = "Khách vãng lai";
            this.colNumberNonResident.Name = "colNumberNonResident";
            this.colNumberNonResident.ReadOnly = true;
            this.colNumberNonResident.Width = 130;
            // 
            // colNumberTotal
            // 
            this.colNumberTotal.DataPropertyName = "NumberTotal";
            this.colNumberTotal.HeaderText = "Tổng SL tham dự";
            this.colNumberTotal.Name = "colNumberTotal";
            this.colNumberTotal.ReadOnly = true;
            this.colNumberTotal.Width = 120;
            // 
            // colInfo
            // 
            this.colInfo.DataPropertyName = "colInfo";
            this.colInfo.FillWeight = 20F;
            this.colInfo.HeaderText = "Xem chi tiết";
            this.colInfo.Image = global::sMeetingComponent.Properties.Resources.ic_search;
            this.colInfo.Name = "colInfo";
            this.colInfo.ReadOnly = true;
            this.colInfo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInfo.ToolTipText = "Xem chi tiết";
            // 
            // pnlStatistic
            // 
            this.pnlStatistic.Controls.Add(this.txtNumberOutSide);
            this.pnlStatistic.Controls.Add(this.txtNumberJournalist);
            this.pnlStatistic.Controls.Add(this.txtNumberAdded);
            this.pnlStatistic.Controls.Add(this.txtNumberAttender);
            this.pnlStatistic.Controls.Add(this.txtNumberRegister);
            this.pnlStatistic.Controls.Add(this.lblSumOutSide);
            this.pnlStatistic.Controls.Add(this.lblSumJournalist);
            this.pnlStatistic.Controls.Add(this.lblSumAdded);
            this.pnlStatistic.Controls.Add(this.lblSumAttender);
            this.pnlStatistic.Controls.Add(this.lblSumRegister);
            this.pnlStatistic.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatistic.Location = new System.Drawing.Point(0, 253);
            this.pnlStatistic.Name = "pnlStatistic";
            this.pnlStatistic.Size = new System.Drawing.Size(2002, 186);
            this.pnlStatistic.TabIndex = 105;
            // 
            // txtNumberOutSide
            // 
            this.txtNumberOutSide.Enabled = false;
            this.txtNumberOutSide.Location = new System.Drawing.Point(932, 127);
            this.txtNumberOutSide.Margin = new System.Windows.Forms.Padding(6);
            this.txtNumberOutSide.Name = "txtNumberOutSide";
            this.txtNumberOutSide.Size = new System.Drawing.Size(76, 37);
            this.txtNumberOutSide.TabIndex = 0;
            this.txtNumberOutSide.TabStop = false;
            // 
            // txtNumberJournalist
            // 
            this.txtNumberJournalist.Enabled = false;
            this.txtNumberJournalist.Location = new System.Drawing.Point(932, 75);
            this.txtNumberJournalist.Margin = new System.Windows.Forms.Padding(6);
            this.txtNumberJournalist.Name = "txtNumberJournalist";
            this.txtNumberJournalist.Size = new System.Drawing.Size(76, 37);
            this.txtNumberJournalist.TabIndex = 0;
            this.txtNumberJournalist.TabStop = false;
            // 
            // txtNumberAdded
            // 
            this.txtNumberAdded.Enabled = false;
            this.txtNumberAdded.Location = new System.Drawing.Point(932, 21);
            this.txtNumberAdded.Margin = new System.Windows.Forms.Padding(6);
            this.txtNumberAdded.Name = "txtNumberAdded";
            this.txtNumberAdded.Size = new System.Drawing.Size(76, 37);
            this.txtNumberAdded.TabIndex = 0;
            this.txtNumberAdded.TabStop = false;
            // 
            // txtNumberAttender
            // 
            this.txtNumberAttender.Enabled = false;
            this.txtNumberAttender.Location = new System.Drawing.Point(484, 74);
            this.txtNumberAttender.Margin = new System.Windows.Forms.Padding(6);
            this.txtNumberAttender.Name = "txtNumberAttender";
            this.txtNumberAttender.Size = new System.Drawing.Size(76, 37);
            this.txtNumberAttender.TabIndex = 0;
            this.txtNumberAttender.TabStop = false;
            // 
            // txtNumberRegister
            // 
            this.txtNumberRegister.Enabled = false;
            this.txtNumberRegister.Location = new System.Drawing.Point(484, 21);
            this.txtNumberRegister.Margin = new System.Windows.Forms.Padding(6);
            this.txtNumberRegister.Name = "txtNumberRegister";
            this.txtNumberRegister.Size = new System.Drawing.Size(76, 37);
            this.txtNumberRegister.TabIndex = 17;
            // 
            // lblSumOutSide
            // 
            this.lblSumOutSide.AutoSize = true;
            this.lblSumOutSide.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumOutSide.Location = new System.Drawing.Point(627, 131);
            this.lblSumOutSide.Margin = new System.Windows.Forms.Padding(6, 12, 6, 12);
            this.lblSumOutSide.Name = "lblSumOutSide";
            this.lblSumOutSide.Size = new System.Drawing.Size(292, 29);
            this.lblSumOutSide.TabIndex = 14;
            this.lblSumOutSide.Text = "Tổng số đơn vị bên ngoài:";
            // 
            // lblSumJournalist
            // 
            this.lblSumJournalist.AutoSize = true;
            this.lblSumJournalist.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumJournalist.Location = new System.Drawing.Point(627, 78);
            this.lblSumJournalist.Margin = new System.Windows.Forms.Padding(6, 12, 6, 12);
            this.lblSumJournalist.Name = "lblSumJournalist";
            this.lblSumJournalist.Size = new System.Drawing.Size(200, 29);
            this.lblSumJournalist.TabIndex = 12;
            this.lblSumJournalist.Text = "Tổng số nhà báo:";
            // 
            // lblSumAdded
            // 
            this.lblSumAdded.AutoSize = true;
            this.lblSumAdded.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumAdded.Location = new System.Drawing.Point(627, 25);
            this.lblSumAdded.Margin = new System.Windows.Forms.Padding(6, 12, 6, 12);
            this.lblSumAdded.Name = "lblSumAdded";
            this.lblSumAdded.Size = new System.Drawing.Size(282, 29);
            this.lblSumAdded.TabIndex = 10;
            this.lblSumAdded.Text = "Tổng số người thêm vào:";
            // 
            // lblSumAttender
            // 
            this.lblSumAttender.AutoSize = true;
            this.lblSumAttender.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumAttender.Location = new System.Drawing.Point(199, 78);
            this.lblSumAttender.Margin = new System.Windows.Forms.Padding(6, 12, 6, 12);
            this.lblSumAttender.Name = "lblSumAttender";
            this.lblSumAttender.Size = new System.Drawing.Size(272, 29);
            this.lblSumAttender.TabIndex = 8;
            this.lblSumAttender.Text = "Tổng số người tham dự:";
            // 
            // lblSumRegister
            // 
            this.lblSumRegister.AutoSize = true;
            this.lblSumRegister.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumRegister.Location = new System.Drawing.Point(199, 25);
            this.lblSumRegister.Margin = new System.Windows.Forms.Padding(6, 12, 6, 12);
            this.lblSumRegister.Name = "lblSumRegister";
            this.lblSumRegister.Size = new System.Drawing.Size(267, 29);
            this.lblSumRegister.TabIndex = 2;
            this.lblSumRegister.Text = "Tổng số người đăng ký:";
            // 
            // commonDataGridView1
            // 
            this.commonDataGridView1.AllowUserToAddRows = false;
            this.commonDataGridView1.AllowUserToDeleteRows = false;
            this.commonDataGridView1.AllowUserToOrderColumns = true;
            this.commonDataGridView1.AllowUserToResizeRows = false;
            this.commonDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.commonDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.commonDataGridView1.ColumnHeadersHeight = 26;
            this.commonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.colPositionPartakerEx,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.colIsNonResidentEx,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.colIdentityCardEx,
            this.colPhoneEx,
            this.dataGridViewTextBoxColumn23,
            this.colCheckEx});
            this.commonDataGridView1.Location = new System.Drawing.Point(1400, 328);
            this.commonDataGridView1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.commonDataGridView1.MultiSelect = false;
            this.commonDataGridView1.Name = "commonDataGridView1";
            this.commonDataGridView1.ReadOnly = true;
            this.commonDataGridView1.RowHeadersVisible = false;
            this.commonDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.commonDataGridView1.Size = new System.Drawing.Size(266, 551);
            this.commonDataGridView1.TabIndex = 104;
            this.commonDataGridView1.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "OrderNum";
            this.dataGridViewTextBoxColumn1.HeaderText = "Stt";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "colMeetingId";
            this.dataGridViewTextBoxColumn4.HeaderText = "colMeetingId";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "MeetingName";
            this.dataGridViewTextBoxColumn14.HeaderText = "Cuộc Họp";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Visible = false;
            this.dataGridViewTextBoxColumn14.Width = 300;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "OrganizationMeetingName";
            this.dataGridViewTextBoxColumn15.HeaderText = "Đơn Vị Tổ Chức";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            this.dataGridViewTextBoxColumn15.Width = 200;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "StartTime";
            this.dataGridViewTextBoxColumn16.HeaderText = "Giờ Bắt Đầu";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "EndTime";
            this.dataGridViewTextBoxColumn17.HeaderText = "Giờ Kết Thúc";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Visible = false;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "NameAttendMeeting";
            this.dataGridViewTextBoxColumn18.HeaderText = "Người Tham Dự";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 170;
            // 
            // colPositionPartakerEx
            // 
            this.colPositionPartakerEx.DataPropertyName = "colPositionPartaker";
            this.colPositionPartakerEx.HeaderText = "Chức vụ";
            this.colPositionPartakerEx.Name = "colPositionPartakerEx";
            this.colPositionPartakerEx.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "OrgPartaker";
            this.dataGridViewTextBoxColumn19.HeaderText = "Tổ chức";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 160;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "PeopleAdded";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Được thêm vào";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            this.dataGridViewCheckBoxColumn1.Width = 120;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "Journalist";
            this.dataGridViewCheckBoxColumn2.HeaderText = "Nhà Báo";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn2.Visible = false;
            this.dataGridViewCheckBoxColumn2.Width = 90;
            // 
            // colIsNonResidentEx
            // 
            this.colIsNonResidentEx.DataPropertyName = "colIsNonResident";
            this.colIsNonResidentEx.HeaderText = "Khách vãng lai";
            this.colIsNonResidentEx.Name = "colIsNonResidentEx";
            this.colIsNonResidentEx.ReadOnly = true;
            this.colIsNonResidentEx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsNonResidentEx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsNonResidentEx.Visible = false;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "DateTime";
            this.dataGridViewTextBoxColumn20.HeaderText = "Ngày";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Visible = false;
            this.dataGridViewTextBoxColumn20.Width = 80;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "InputTime";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn21.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn21.HeaderText = "Giờ Vào";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Visible = false;
            this.dataGridViewTextBoxColumn21.Width = 80;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "OutputTime";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn22.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn22.HeaderText = "Giờ Ra";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Visible = false;
            this.dataGridViewTextBoxColumn22.Width = 80;
            // 
            // colIdentityCardEx
            // 
            this.colIdentityCardEx.DataPropertyName = "colIdentityCard";
            this.colIdentityCardEx.HeaderText = "CMND";
            this.colIdentityCardEx.Name = "colIdentityCardEx";
            this.colIdentityCardEx.ReadOnly = true;
            this.colIdentityCardEx.Visible = false;
            // 
            // colPhoneEx
            // 
            this.colPhoneEx.DataPropertyName = "colPhone";
            this.colPhoneEx.HeaderText = "SĐT";
            this.colPhoneEx.Name = "colPhoneEx";
            this.colPhoneEx.ReadOnly = true;
            this.colPhoneEx.Visible = false;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn23.DataPropertyName = "Note";
            this.dataGridViewTextBoxColumn23.HeaderText = "Ghi Chú";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Visible = false;
            // 
            // colCheckEx
            // 
            this.colCheckEx.DataPropertyName = "colCheck";
            this.colCheckEx.HeaderText = "Tham dự";
            this.colCheckEx.Name = "colCheckEx";
            this.colCheckEx.ReadOnly = true;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilterBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilterBox.Controls.Add(this.panel2);
            this.pnlFilterBox.Controls.Add(this.txtMeetingNameSearchs);
            this.pnlFilterBox.Controls.Add(this.lblFilterByMeetingName);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 39);
            this.pnlFilterBox.Margin = new System.Windows.Forms.Padding(6);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.pnlFilterBox.Size = new System.Drawing.Size(2002, 214);
            this.pnlFilterBox.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblFilterByDate);
            this.panel2.Controls.Add(this.lblTo1);
            this.panel2.Controls.Add(this.dtpDateIn2);
            this.panel2.Controls.Add(this.dtpDateIn);
            this.panel2.Controls.Add(this.cbxNameOrgSearch);
            this.panel2.Controls.Add(this.lblFilterByOrgName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(12, 11);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1976, 128);
            this.panel2.TabIndex = 1;
            // 
            // lblFilterByDate
            // 
            this.lblFilterByDate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFilterByDate.Location = new System.Drawing.Point(184, 6);
            this.lblFilterByDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFilterByDate.Name = "lblFilterByDate";
            this.lblFilterByDate.Size = new System.Drawing.Size(282, 51);
            this.lblFilterByDate.TabIndex = 101;
            this.lblFilterByDate.Text = "Lọc theo ngày:";
            this.lblFilterByDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTo1
            // 
            this.lblTo1.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTo1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTo1.Location = new System.Drawing.Point(738, 9);
            this.lblTo1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTo1.Name = "lblTo1";
            this.lblTo1.Size = new System.Drawing.Size(66, 47);
            this.lblTo1.TabIndex = 100;
            this.lblTo1.Text = "đến";
            this.lblTo1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDateIn2
            // 
            this.dtpDateIn2.CustomFormat = "dd/MM/yyyy";
            this.dtpDateIn2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpDateIn2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateIn2.Location = new System.Drawing.Point(816, 6);
            this.dtpDateIn2.Margin = new System.Windows.Forms.Padding(6);
            this.dtpDateIn2.Name = "dtpDateIn2";
            this.dtpDateIn2.Size = new System.Drawing.Size(178, 36);
            this.dtpDateIn2.TabIndex = 2;
            // 
            // dtpDateIn
            // 
            this.dtpDateIn.CustomFormat = "dd/MM/yyyy";
            this.dtpDateIn.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateIn.Location = new System.Drawing.Point(544, 6);
            this.dtpDateIn.Margin = new System.Windows.Forms.Padding(6);
            this.dtpDateIn.Name = "dtpDateIn";
            this.dtpDateIn.Size = new System.Drawing.Size(178, 36);
            this.dtpDateIn.TabIndex = 1;
            // 
            // cbxNameOrgSearch
            // 
            this.cbxNameOrgSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNameOrgSearch.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbxNameOrgSearch.FormattingEnabled = true;
            this.cbxNameOrgSearch.Location = new System.Drawing.Point(544, 69);
            this.cbxNameOrgSearch.Margin = new System.Windows.Forms.Padding(6);
            this.cbxNameOrgSearch.Name = "cbxNameOrgSearch";
            this.cbxNameOrgSearch.Size = new System.Drawing.Size(450, 37);
            this.cbxNameOrgSearch.TabIndex = 3;
            // 
            // lblFilterByOrgName
            // 
            this.lblFilterByOrgName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFilterByOrgName.Location = new System.Drawing.Point(184, 66);
            this.lblFilterByOrgName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFilterByOrgName.Name = "lblFilterByOrgName";
            this.lblFilterByOrgName.Size = new System.Drawing.Size(348, 51);
            this.lblFilterByOrgName.TabIndex = 96;
            this.lblFilterByOrgName.Text = "Lọc theo đơn vị tổ chức:";
            this.lblFilterByOrgName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMeetingNameSearchs
            // 
            this.txtMeetingNameSearchs.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMeetingNameSearchs.Location = new System.Drawing.Point(558, 154);
            this.txtMeetingNameSearchs.Margin = new System.Windows.Forms.Padding(6);
            this.txtMeetingNameSearchs.MaxLength = 250;
            this.txtMeetingNameSearchs.Name = "txtMeetingNameSearchs";
            this.txtMeetingNameSearchs.Size = new System.Drawing.Size(449, 36);
            this.txtMeetingNameSearchs.TabIndex = 4;
            // 
            // lblFilterByMeetingName
            // 
            this.lblFilterByMeetingName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFilterByMeetingName.Location = new System.Drawing.Point(198, 152);
            this.lblFilterByMeetingName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFilterByMeetingName.Name = "lblFilterByMeetingName";
            this.lblFilterByMeetingName.Size = new System.Drawing.Size(348, 51);
            this.lblFilterByMeetingName.TabIndex = 85;
            this.lblFilterByMeetingName.Text = "Lọc theo tên cuộc họp:";
            this.lblFilterByMeetingName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsmCard
            // 
            this.tsmCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportToExcel,
            this.btnReload,
            this.btnShowHide});
            this.tsmCard.Location = new System.Drawing.Point(0, 0);
            this.tsmCard.Name = "tsmCard";
            this.tsmCard.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.tsmCard.Size = new System.Drawing.Size(2002, 39);
            this.tsmCard.TabIndex = 6;
            this.tsmCard.Text = "tlstripListUser";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportToExcel.Enabled = false;
            this.btnExportToExcel.Image = global::sMeetingComponent.Properties.Resources.Excel_16x16;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(36, 36);
            this.btnExportToExcel.Text = "Xuất Ra Excel...";
            this.btnExportToExcel.ToolTipText = "Xuất dữ liệu đang hiển thị ra tập tin excel";
            // 
            // btnReload
            // 
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(36, 36);
            this.btnReload.Text = "Tải Dữ Liệu";
            this.btnReload.ToolTipText = "Tải danh sách thống kê";
            // 
            // btnShowHide
            // 
            this.btnShowHide.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnShowHide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowHide.Image = ((System.Drawing.Image)(resources.GetObject("btnShowHide.Image")));
            this.btnShowHide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(36, 36);
            this.btnShowHide.Text = "Ẩn Khung Tìm Kiếm";
            this.btnShowHide.ToolTipText = "Ẩn khung tìm kiếm";
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 942);
            this.pagerPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(2002, 47);
            this.pagerPanel1.TabIndex = 89;
            // 
            // dataGridview4Export
            // 
            this.dataGridview4Export.AllowUserToAddRows = false;
            this.dataGridview4Export.AllowUserToDeleteRows = false;
            this.dataGridview4Export.AllowUserToOrderColumns = true;
            this.dataGridview4Export.AllowUserToResizeRows = false;
            this.dataGridview4Export.BackgroundColor = System.Drawing.Color.White;
            this.dataGridview4Export.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridview4Export.ColumnHeadersHeight = 26;
            this.dataGridview4Export.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.colNumberNonResidentEx,
            this.dataGridViewTextBoxColumn13});
            this.dataGridview4Export.Location = new System.Drawing.Point(71, 304);
            this.dataGridview4Export.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.dataGridview4Export.MultiSelect = false;
            this.dataGridview4Export.Name = "dataGridview4Export";
            this.dataGridview4Export.ReadOnly = true;
            this.dataGridview4Export.RowHeadersVisible = false;
            this.dataGridview4Export.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridview4Export.Size = new System.Drawing.Size(842, 771);
            this.dataGridview4Export.TabIndex = 93;
            this.dataGridview4Export.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "STT";
            this.dataGridViewTextBoxColumn2.HeaderText = "Stt";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "OrganizationMeetingName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Đơn vị tổ chức";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 220;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "MeetingName";
            this.dataGridViewTextBoxColumn5.HeaderText = "Cuộc Họp";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DateTime";
            this.dataGridViewTextBoxColumn6.HeaderText = "Ngày";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "InputTime";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn7.HeaderText = "Giờ Bắt Đầu";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "OutputTime";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn8.HeaderText = "Giờ Kết Thúc";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 90;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "NumberPeopleInvation";
            this.dataGridViewTextBoxColumn9.HeaderText = "SL được mời";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 105;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "NumberPeopleAttend";
            this.dataGridViewTextBoxColumn10.HeaderText = "SL tham dự";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 105;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "NumberAddPeopleAttend";
            this.dataGridViewTextBoxColumn11.HeaderText = "SL thêm Vào";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 90;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "NumberJournalist";
            this.dataGridViewTextBoxColumn12.HeaderText = "SL Nhà Báo";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 122;
            // 
            // colNumberNonResidentEx
            // 
            this.colNumberNonResidentEx.DataPropertyName = "colNumberNonResident";
            this.colNumberNonResidentEx.HeaderText = "Khách Vãng Lai";
            this.colNumberNonResidentEx.Name = "colNumberNonResidentEx";
            this.colNumberNonResidentEx.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "NumberTotal";
            this.dataGridViewTextBoxColumn13.HeaderText = "Tổng SL tham dự";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 120;
            // 
            // UsrAttendMeetingStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1Outside);
            this.Controls.Add(this.lblRightAreaTitleListAttendace);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UsrAttendMeetingStatistics";
            this.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.Size = new System.Drawing.Size(2054, 1106);
            this.cmsPersoRecord.ResumeLayout(false);
            this.panel1Outside.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendMeetingStatisticList)).EndInit();
            this.pnlStatistic.ResumeLayout(false);
            this.pnlStatistic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView1)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tsmCard.ResumeLayout(false);
            this.tsmCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridview4Export)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControls.Custom.TitleLabel lblRightAreaTitleListAttendace;
        private System.Windows.Forms.ContextMenuStrip cmsPersoRecord;
        private System.Windows.Forms.ToolStripMenuItem mniInfor;
        private System.Windows.Forms.DataGridViewImageColumn imageColumns;
        private System.Windows.Forms.Panel panel1Outside;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private ClientModel.Controls.Commons.CommonDataGridView dataGridview4Export;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberNonResidentEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFilterByDate;
        private System.Windows.Forms.Label lblTo1;
        private System.Windows.Forms.DateTimePicker dtpDateIn2;
        private System.Windows.Forms.DateTimePicker dtpDateIn;
        private System.Windows.Forms.ComboBox cbxNameOrgSearch;
        private System.Windows.Forms.Label lblFilterByOrgName;
        private System.Windows.Forms.TextBox txtMeetingNameSearchs;
        private System.Windows.Forms.Label lblFilterByMeetingName;
        private CommonControls.Custom.CommonToolStrip tsmCard;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.ToolStripButton btnShowHide;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private CommonControls.Custom.CommonDataGridView dgvAttendMeetingStatisticList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgMeetingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrganizationMeetingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeetingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeetingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberPeopleInvation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberPeopleAttend;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberAddPeopleAttend;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberJournalist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberNonResident;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberTotal;
        private System.Windows.Forms.DataGridViewImageColumn colInfo;
        private System.Windows.Forms.Panel pnlStatistic;
        private ClientModel.Controls.Commons.CommonDataGridView commonDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPositionPartakerEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsNonResidentEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentityCardEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoneEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckEx;
        private System.Windows.Forms.Label lblSumJournalist;
        private System.Windows.Forms.Label lblSumOutSide;
        private System.Windows.Forms.Label lblSumAdded;
        private System.Windows.Forms.Label lblSumAttender;
        private System.Windows.Forms.Label lblSumRegister;
        private System.Windows.Forms.TextBox txtNumberRegister;
        private System.Windows.Forms.TextBox txtNumberOutSide;
        private System.Windows.Forms.TextBox txtNumberJournalist;
        private System.Windows.Forms.TextBox txtNumberAdded;
        private System.Windows.Forms.TextBox txtNumberAttender;
    }
}
