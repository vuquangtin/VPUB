using System;
using System.Windows.Forms;

namespace sMeetingComponent.WorkItems
{
   public partial class UsrJournalistAttendMeeting 
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3List = new System.Windows.Forms.Panel();
            this.panel4InsideListMeeting = new System.Windows.Forms.Panel();
            this.dgvMeetingList = new CommonControls.Custom.CommonDataGridView();
            this.colOrderNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNameMeeting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrganizationMeeting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJournalist = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberPeopleInvation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3Reload = new System.Windows.Forms.Panel();
            this.btnReloadListMeeting = new System.Windows.Forms.Button();
            this.lblListMeeting = new CommonControls.Custom.TitleLabel();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.panelCheck = new System.Windows.Forms.Panel();
            this.panelCheckCard = new System.Windows.Forms.Panel();
            this.txtCheckCardChip = new CommonControls.Custom.TitleLabel();
            this.panelCheckCardShow = new System.Windows.Forms.Panel();
            this.lblGuideCardCheck = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.lblGuiChooseReader = new System.Windows.Forms.Label();
            this.cmbReaders = new System.Windows.Forms.ComboBox();
            this.lblChooseReader = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnListDevices = new System.Windows.Forms.Button();
            this.panelNotInvitation = new System.Windows.Forms.Panel();
            this.lblGuideAddMeetingNotcard = new System.Windows.Forms.Label();
            this.panel3button = new System.Windows.Forms.Panel();
            this.btnAddMeetingNotCard = new System.Windows.Forms.Button();
            this.lblNotCheckBarcode = new CommonControls.Custom.TitleLabel();
            this.panelCheckInvitation = new System.Windows.Forms.Panel();
            this.lblCheckBarcodeGuile = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblCheckBarcode = new CommonControls.Custom.TitleLabel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3List.SuspendLayout();
            this.panel4InsideListMeeting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeetingList)).BeginInit();
            this.panel3Reload.SuspendLayout();
            this.panelCheck.SuspendLayout();
            this.panelCheckCard.SuspendLayout();
            this.panelCheckCardShow.SuspendLayout();
            this.panelNotInvitation.SuspendLayout();
            this.panel3button.SuspendLayout();
            this.panelCheckInvitation.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(921, 636);
            this.panel1.TabIndex = 129;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3List);
            this.panel2.Controls.Add(this.panelCheck);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(921, 636);
            this.panel2.TabIndex = 3;
            // 
            // panel3List
            // 
            this.panel3List.Controls.Add(this.panel4InsideListMeeting);
            this.panel3List.Controls.Add(this.panel3Reload);
            this.panel3List.Controls.Add(this.pagerPanel1);
            this.panel3List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3List.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3List.Location = new System.Drawing.Point(0, 115);
            this.panel3List.Name = "panel3List";
            this.panel3List.Size = new System.Drawing.Size(919, 519);
            this.panel3List.TabIndex = 3;
            // 
            // panel4InsideListMeeting
            // 
            this.panel4InsideListMeeting.Controls.Add(this.dgvMeetingList);
            this.panel4InsideListMeeting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4InsideListMeeting.Location = new System.Drawing.Point(0, 30);
            this.panel4InsideListMeeting.Name = "panel4InsideListMeeting";
            this.panel4InsideListMeeting.Size = new System.Drawing.Size(919, 467);
            this.panel4InsideListMeeting.TabIndex = 97;
            // 
            // dgvMeetingList
            // 
            this.dgvMeetingList.AllowUserToAddRows = false;
            this.dgvMeetingList.AllowUserToDeleteRows = false;
            this.dgvMeetingList.AllowUserToOrderColumns = true;
            this.dgvMeetingList.AllowUserToResizeRows = false;
            this.dgvMeetingList.BackgroundColor = System.Drawing.Color.White;
            this.dgvMeetingList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMeetingList.ColumnHeadersHeight = 30;
            this.dgvMeetingList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderNum,
            this.colNameMeeting,
            this.colOrganizationMeeting,
            this.colJournalist,
            this.colDateTime,
            this.colStartTime,
            this.colEndTime,
            this.colRoom,
            this.colNumberPeopleInvation,
            this.colDescription});
            this.dgvMeetingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMeetingList.Location = new System.Drawing.Point(0, 0);
            this.dgvMeetingList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMeetingList.MultiSelect = false;
            this.dgvMeetingList.Name = "dgvMeetingList";
            this.dgvMeetingList.ReadOnly = true;
            this.dgvMeetingList.RowHeadersVisible = false;
            this.dgvMeetingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeetingList.ShowCellToolTips = false;
            this.dgvMeetingList.Size = new System.Drawing.Size(919, 467);
            this.dgvMeetingList.TabIndex = 7;
            this.dgvMeetingList.TabStop = false;
            // 
            // colOrderNum
            // 
            this.colOrderNum.DataPropertyName = "OrderNum";
            this.colOrderNum.HeaderText = "Stt";
            this.colOrderNum.Name = "colOrderNum";
            this.colOrderNum.ReadOnly = true;
            this.colOrderNum.Width = 40;
            // 
            // colNameMeeting
            // 
            this.colNameMeeting.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNameMeeting.DataPropertyName = "NameMeeting";
            this.colNameMeeting.HeaderText = "Cuộc họp";
            this.colNameMeeting.Name = "colNameMeeting";
            this.colNameMeeting.ReadOnly = true;
            // 
            // colOrganizationMeeting
            // 
            this.colOrganizationMeeting.DataPropertyName = "OrganizationMeeting";
            this.colOrganizationMeeting.HeaderText = "Đơn vị tổ chức";
            this.colOrganizationMeeting.Name = "colOrganizationMeeting";
            this.colOrganizationMeeting.ReadOnly = true;
            this.colOrganizationMeeting.Width = 170;
            // 
            // colJournalist
            // 
            this.colJournalist.DataPropertyName = "Journalist";
            this.colJournalist.HeaderText = "Nhà Báo";
            this.colJournalist.Name = "colJournalist";
            this.colJournalist.ReadOnly = true;
            this.colJournalist.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colJournalist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colJournalist.Visible = false;
            // 
            // colDateTime
            // 
            this.colDateTime.DataPropertyName = "DateTime";
            this.colDateTime.HeaderText = "Ngày";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.ReadOnly = true;
            // 
            // colStartTime
            // 
            this.colStartTime.DataPropertyName = "InputTime";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colStartTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.colStartTime.HeaderText = "Giờ Bắt Đầu";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.ReadOnly = true;
            this.colStartTime.Width = 105;
            // 
            // colEndTime
            // 
            this.colEndTime.DataPropertyName = "EndTime";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEndTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.colEndTime.HeaderText = "Giờ Kết Thúc";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.ReadOnly = true;
            this.colEndTime.Visible = false;
            this.colEndTime.Width = 105;
            // 
            // colRoom
            // 
            this.colRoom.DataPropertyName = "Room";
            this.colRoom.HeaderText = "Phòng";
            this.colRoom.Name = "colRoom";
            this.colRoom.ReadOnly = true;
            this.colRoom.Visible = false;
            this.colRoom.Width = 90;
            // 
            // colNumberPeopleInvation
            // 
            this.colNumberPeopleInvation.DataPropertyName = "NumberPeopleInvation";
            this.colNumberPeopleInvation.HeaderText = "Số lượng";
            this.colNumberPeopleInvation.Name = "colNumberPeopleInvation";
            this.colNumberPeopleInvation.ReadOnly = true;
            this.colNumberPeopleInvation.Width = 165;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Mô tả";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 90;
            // 
            // panel3Reload
            // 
            this.panel3Reload.Controls.Add(this.btnReloadListMeeting);
            this.panel3Reload.Controls.Add(this.lblListMeeting);
            this.panel3Reload.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3Reload.Location = new System.Drawing.Point(0, 0);
            this.panel3Reload.Name = "panel3Reload";
            this.panel3Reload.Size = new System.Drawing.Size(919, 30);
            this.panel3Reload.TabIndex = 96;
            // 
            // btnReloadListMeeting
            // 
            this.btnReloadListMeeting.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReloadListMeeting.Image = global::sMeetingComponent.Properties.Resources.Refresh_16x16;
            this.btnReloadListMeeting.Location = new System.Drawing.Point(874, 0);
            this.btnReloadListMeeting.Name = "btnReloadListMeeting";
            this.btnReloadListMeeting.Size = new System.Drawing.Size(45, 30);
            this.btnReloadListMeeting.TabIndex = 74;
            this.btnReloadListMeeting.UseVisualStyleBackColor = true;
            // 
            // lblListMeeting
            // 
            this.lblListMeeting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblListMeeting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblListMeeting.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblListMeeting.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblListMeeting.Location = new System.Drawing.Point(0, 0);
            this.lblListMeeting.Name = "lblListMeeting";
            this.lblListMeeting.Size = new System.Drawing.Size(919, 30);
            this.lblListMeeting.TabIndex = 72;
            this.lblListMeeting.Text = "DANH SÁCH CUỘC HỌP TRONG NGÀY";
            this.lblListMeeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 497);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(919, 22);
            this.pagerPanel1.TabIndex = 94;
            this.pagerPanel1.TabStop = false;
            // 
            // panelCheck
            // 
            this.panelCheck.Controls.Add(this.panelCheckCard);
            this.panelCheck.Controls.Add(this.panelNotInvitation);
            this.panelCheck.Controls.Add(this.panelCheckInvitation);
            this.panelCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCheck.Location = new System.Drawing.Point(0, 0);
            this.panelCheck.Name = "panelCheck";
            this.panelCheck.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panelCheck.Size = new System.Drawing.Size(919, 115);
            this.panelCheck.TabIndex = 2;
            // 
            // panelCheckCard
            // 
            this.panelCheckCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCheckCard.Controls.Add(this.txtCheckCardChip);
            this.panelCheckCard.Controls.Add(this.panelCheckCardShow);
            this.panelCheckCard.Controls.Add(this.btnStart);
            this.panelCheckCard.Controls.Add(this.btnPause);
            this.panelCheckCard.Controls.Add(this.btnListDevices);
            this.panelCheckCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCheckCard.Location = new System.Drawing.Point(350, 0);
            this.panelCheckCard.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.panelCheckCard.MinimumSize = new System.Drawing.Size(280, 110);
            this.panelCheckCard.Name = "panelCheckCard";
            this.panelCheckCard.Size = new System.Drawing.Size(280, 110);
            this.panelCheckCard.TabIndex = 4;
            // 
            // txtCheckCardChip
            // 
            this.txtCheckCardChip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.txtCheckCardChip.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCheckCardChip.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtCheckCardChip.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtCheckCardChip.Location = new System.Drawing.Point(0, 0);
            this.txtCheckCardChip.Name = "txtCheckCardChip";
            this.txtCheckCardChip.Size = new System.Drawing.Size(278, 32);
            this.txtCheckCardChip.TabIndex = 80;
            this.txtCheckCardChip.Text = "THAM DỰ HỌP CÓ THẺ";
            this.txtCheckCardChip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCheckCardShow
            // 
            this.panelCheckCardShow.Controls.Add(this.lblGuideCardCheck);
            this.panelCheckCardShow.Controls.Add(this.lblStatus);
            this.panelCheckCardShow.Controls.Add(this.lblCurrentStatus);
            this.panelCheckCardShow.Controls.Add(this.lblGuiChooseReader);
            this.panelCheckCardShow.Controls.Add(this.cmbReaders);
            this.panelCheckCardShow.Controls.Add(this.lblChooseReader);
            this.panelCheckCardShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCheckCardShow.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelCheckCardShow.Location = new System.Drawing.Point(0, 0);
            this.panelCheckCardShow.Name = "panelCheckCardShow";
            this.panelCheckCardShow.Size = new System.Drawing.Size(278, 108);
            this.panelCheckCardShow.TabIndex = 2;
            // 
            // lblGuideCardCheck
            // 
            this.lblGuideCardCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGuideCardCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.lblGuideCardCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGuideCardCheck.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Italic);
            this.lblGuideCardCheck.Location = new System.Drawing.Point(0, 62);
            this.lblGuideCardCheck.Name = "lblGuideCardCheck";
            this.lblGuideCardCheck.Size = new System.Drawing.Size(279, 48);
            this.lblGuideCardCheck.TabIndex = 146;
            this.lblGuideCardCheck.Text = "Vui lòng đưa thẻ vào đầu đọc thẻ để quét thông tin";
            this.lblGuideCardCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(0, 32);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(278, 30);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Chưa kết nối với thiết bị đọc";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStatus.Location = new System.Drawing.Point(0, 85);
            this.lblCurrentStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(278, 20);
            this.lblCurrentStatus.TabIndex = 144;
            this.lblCurrentStatus.Text = "Trạng thái hiện tại:";
            this.lblCurrentStatus.Visible = false;
            // 
            // lblGuiChooseReader
            // 
            this.lblGuiChooseReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGuiChooseReader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuiChooseReader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGuiChooseReader.Location = new System.Drawing.Point(0, 46);
            this.lblGuiChooseReader.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblGuiChooseReader.Name = "lblGuiChooseReader";
            this.lblGuiChooseReader.Size = new System.Drawing.Size(278, 39);
            this.lblGuiChooseReader.TabIndex = 143;
            this.lblGuiChooseReader.Text = "Nếu thiết bị của bạn không được liệt kê trong khung trên, hãy đảm bảo thiết bị đã" +
    " được kết nối đúng cách với máy tính, sau đó, nhấn nút \"Tìm Thiết Bị\".";
            this.lblGuiChooseReader.Visible = false;
            // 
            // cmbReaders
            // 
            this.cmbReaders.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbReaders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReaders.FormattingEnabled = true;
            this.cmbReaders.Location = new System.Drawing.Point(0, 20);
            this.cmbReaders.Name = "cmbReaders";
            this.cmbReaders.Size = new System.Drawing.Size(278, 26);
            this.cmbReaders.TabIndex = 2;
            this.cmbReaders.TabStop = false;
            this.cmbReaders.Visible = false;
            // 
            // lblChooseReader
            // 
            this.lblChooseReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChooseReader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseReader.Location = new System.Drawing.Point(0, 0);
            this.lblChooseReader.Name = "lblChooseReader";
            this.lblChooseReader.Size = new System.Drawing.Size(278, 20);
            this.lblChooseReader.TabIndex = 141;
            this.lblChooseReader.Text = "Chọn thiết bị đọc thẻ:";
            this.lblChooseReader.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(8, 76);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(130, 30);
            this.btnStart.TabIndex = 3;
            this.btnStart.TabStop = false;
            this.btnStart.Text = "Bắt Đầu";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPause.Enabled = false;
            this.btnPause.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(144, 76);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(130, 30);
            this.btnPause.TabIndex = 4;
            this.btnPause.TabStop = false;
            this.btnPause.Text = "Tạm Ngưng";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Visible = false;
            // 
            // btnListDevices
            // 
            this.btnListDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnListDevices.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListDevices.Location = new System.Drawing.Point(280, 78);
            this.btnListDevices.Name = "btnListDevices";
            this.btnListDevices.Size = new System.Drawing.Size(130, 30);
            this.btnListDevices.TabIndex = 5;
            this.btnListDevices.TabStop = false;
            this.btnListDevices.Text = "Tìm Thiết Bị";
            this.btnListDevices.UseVisualStyleBackColor = true;
            this.btnListDevices.Visible = false;
            // 
            // panelNotInvitation
            // 
            this.panelNotInvitation.Controls.Add(this.lblGuideAddMeetingNotcard);
            this.panelNotInvitation.Controls.Add(this.panel3button);
            this.panelNotInvitation.Controls.Add(this.lblNotCheckBarcode);
            this.panelNotInvitation.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelNotInvitation.Location = new System.Drawing.Point(529, 0);
            this.panelNotInvitation.MinimumSize = new System.Drawing.Size(390, 110);
            this.panelNotInvitation.Name = "panelNotInvitation";
            this.panelNotInvitation.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.panelNotInvitation.Size = new System.Drawing.Size(390, 110);
            this.panelNotInvitation.TabIndex = 2;
            this.panelNotInvitation.Visible = false;
            // 
            // lblGuideAddMeetingNotcard
            // 
            this.lblGuideAddMeetingNotcard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.lblGuideAddMeetingNotcard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGuideAddMeetingNotcard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGuideAddMeetingNotcard.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Italic);
            this.lblGuideAddMeetingNotcard.Location = new System.Drawing.Point(3, 62);
            this.lblGuideAddMeetingNotcard.Name = "lblGuideAddMeetingNotcard";
            this.lblGuideAddMeetingNotcard.Size = new System.Drawing.Size(387, 48);
            this.lblGuideAddMeetingNotcard.TabIndex = 110;
            this.lblGuideAddMeetingNotcard.Text = "Vui lòng nhấn nút  F1 hoặc nút \"Đăng Ký\" và điền thông tin cần thiết trước khi và" +
    "o tham dự họp ";
            this.lblGuideAddMeetingNotcard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3button
            // 
            this.panel3button.BackColor = System.Drawing.Color.White;
            this.panel3button.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3button.Controls.Add(this.btnAddMeetingNotCard);
            this.panel3button.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3button.Location = new System.Drawing.Point(3, 32);
            this.panel3button.Name = "panel3button";
            this.panel3button.Size = new System.Drawing.Size(387, 30);
            this.panel3button.TabIndex = 81;
            // 
            // btnAddMeetingNotCard
            // 
            this.btnAddMeetingNotCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMeetingNotCard.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddMeetingNotCard.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddMeetingNotCard.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMeetingNotCard.Location = new System.Drawing.Point(108, -1);
            this.btnAddMeetingNotCard.Name = "btnAddMeetingNotCard";
            this.btnAddMeetingNotCard.Size = new System.Drawing.Size(176, 30);
            this.btnAddMeetingNotCard.TabIndex = 2;
            this.btnAddMeetingNotCard.Text = "Đăng Ký";
            this.btnAddMeetingNotCard.UseVisualStyleBackColor = false;
            // 
            // lblNotCheckBarcode
            // 
            this.lblNotCheckBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblNotCheckBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNotCheckBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblNotCheckBarcode.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNotCheckBarcode.Location = new System.Drawing.Point(3, 0);
            this.lblNotCheckBarcode.Name = "lblNotCheckBarcode";
            this.lblNotCheckBarcode.Size = new System.Drawing.Size(387, 32);
            this.lblNotCheckBarcode.TabIndex = 80;
            this.lblNotCheckBarcode.Text = "THAM DỰ HỌP KHÔNG CÓ THẺ/THƯ MỜI";
            this.lblNotCheckBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCheckInvitation
            // 
            this.panelCheckInvitation.Controls.Add(this.lblCheckBarcodeGuile);
            this.panelCheckInvitation.Controls.Add(this.txtBarcode);
            this.panelCheckInvitation.Controls.Add(this.lblCheckBarcode);
            this.panelCheckInvitation.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelCheckInvitation.Location = new System.Drawing.Point(0, 0);
            this.panelCheckInvitation.MinimumSize = new System.Drawing.Size(350, 110);
            this.panelCheckInvitation.Name = "panelCheckInvitation";
            this.panelCheckInvitation.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.panelCheckInvitation.Size = new System.Drawing.Size(350, 110);
            this.panelCheckInvitation.TabIndex = 1;
            this.panelCheckInvitation.Visible = false;
            // 
            // lblCheckBarcodeGuile
            // 
            this.lblCheckBarcodeGuile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.lblCheckBarcodeGuile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCheckBarcodeGuile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCheckBarcodeGuile.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Italic);
            this.lblCheckBarcodeGuile.Location = new System.Drawing.Point(0, 62);
            this.lblCheckBarcodeGuile.Name = "lblCheckBarcodeGuile";
            this.lblCheckBarcodeGuile.Size = new System.Drawing.Size(347, 48);
            this.lblCheckBarcodeGuile.TabIndex = 106;
            this.lblCheckBarcodeGuile.Text = "Vui lòng đưa thư mời vào đầu đọc barcode hoặc nhập mã barcode";
            this.lblCheckBarcodeGuile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBarcode
            // 
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(0, 32);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.txtBarcode.MaxLength = 29;
            this.txtBarcode.Multiline = true;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(347, 30);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCheckBarcode
            // 
            this.lblCheckBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblCheckBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCheckBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblCheckBarcode.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCheckBarcode.Location = new System.Drawing.Point(0, 0);
            this.lblCheckBarcode.Name = "lblCheckBarcode";
            this.lblCheckBarcode.Size = new System.Drawing.Size(347, 32);
            this.lblCheckBarcode.TabIndex = 80;
            this.lblCheckBarcode.Text = "THAM DỰ HỌP CÓ THƯ MỜI";
            this.lblCheckBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(67, 22);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(68, 26);
            // 
            // UsrJournalistAttendMeeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UsrJournalistAttendMeeting";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Size = new System.Drawing.Size(933, 646);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3List.ResumeLayout(false);
            this.panel4InsideListMeeting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeetingList)).EndInit();
            this.panel3Reload.ResumeLayout(false);
            this.panelCheck.ResumeLayout(false);
            this.panelCheckCard.ResumeLayout(false);
            this.panelCheckCardShow.ResumeLayout(false);
            this.panelNotInvitation.ResumeLayout(false);
            this.panel3button.ResumeLayout(false);
            this.panelCheckInvitation.ResumeLayout(false);
            this.panelCheckInvitation.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lblTH2step3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion


        private System.Windows.Forms.Panel panel1;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ContextMenuStrip contextMenuStrip1;
        private Panel panel2;
        private Panel panel3List;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private Panel panelCheck;
        private Panel panelCheckInvitation;
        private CommonControls.Custom.TitleLabel lblCheckBarcode;
        private Panel panelCheckCard;
        private CommonControls.Custom.TitleLabel txtCheckCardChip;
        private Button btnPause;
        private Button btnListDevices;
        private Button btnStart;
        private Panel panelCheckCardShow;
        private Label lblCurrentStatus;
        private Label lblGuiChooseReader;
        private ComboBox cmbReaders;
        private Label lblChooseReader;
        private TextBox txtBarcode;
        private Label lblCheckBarcodeGuile;
        private Label lblStatus;
        private Label lblGuideCardCheck;
        private Panel panelNotInvitation;
        private Label lblGuideAddMeetingNotcard;
        private Panel panel3button;
        private Button btnAddMeetingNotCard;
        private CommonControls.Custom.TitleLabel lblNotCheckBarcode;
        private Panel panel3Reload;
        private Button btnReloadListMeeting;
        private CommonControls.Custom.TitleLabel lblListMeeting;
        private Panel panel4InsideListMeeting;
        private CommonControls.Custom.CommonDataGridView dgvMeetingList;
        private DataGridViewTextBoxColumn colOrderNum;
        private DataGridViewTextBoxColumn colNameMeeting;
        private DataGridViewTextBoxColumn colOrganizationMeeting;
        private DataGridViewCheckBoxColumn colJournalist;
        private DataGridViewTextBoxColumn colDateTime;
        private DataGridViewTextBoxColumn colStartTime;
        private DataGridViewTextBoxColumn colEndTime;
        private DataGridViewTextBoxColumn colRoom;
        private DataGridViewTextBoxColumn colNumberPeopleInvation;
        private DataGridViewTextBoxColumn colDescription;
    }
}
