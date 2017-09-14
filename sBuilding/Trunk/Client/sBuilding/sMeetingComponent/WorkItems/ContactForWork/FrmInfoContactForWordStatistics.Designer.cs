namespace sMeetingComponent.WorkItems.ContactForWork
{
    partial class FrmInfoContactForWordStatistics
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPersonAttendDetail = new CommonControls.Custom.CommonDataGridView();
            this.pagerPanel = new CommonControls.Custom.PagerPanel();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtdtpDateIn2 = new System.Windows.Forms.TextBox();
            this.txtdtpDateIn = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.dataGridview4Export = new ClientModel.Controls.Commons.CommonDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPositionEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentityCardEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhoneEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbxOrgName = new System.Windows.Forms.TextBox();
            this.lblGoverningOrganization = new System.Windows.Forms.Label();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.tmsMember = new CommonControls.Custom.CommonToolStrip();
            this.lbltitleLabelInfoMeetinginoutContactForWork = new CommonControls.Custom.TitleLabel();
            this.colOrderNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNameAttendMeeting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrgPartaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInputTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutputTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentityCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonAttendDetail)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridview4Export)).BeginInit();
            this.tmsMember.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPersonAttendDetail
            // 
            this.dgvPersonAttendDetail.AllowUserToAddRows = false;
            this.dgvPersonAttendDetail.AllowUserToDeleteRows = false;
            this.dgvPersonAttendDetail.AllowUserToOrderColumns = true;
            this.dgvPersonAttendDetail.AllowUserToResizeRows = false;
            this.dgvPersonAttendDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvPersonAttendDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPersonAttendDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPersonAttendDetail.ColumnHeadersHeight = 26;
            this.dgvPersonAttendDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderNum,
            this.colNameAttendMeeting,
            this.colPosition,
            this.colOrgPartaker,
            this.colDateTime,
            this.colInputTime,
            this.colOutputTime,
            this.colIdentityCard,
            this.colPhone,
            this.colNote});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPersonAttendDetail.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPersonAttendDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonAttendDetail.Location = new System.Drawing.Point(6, 128);
            this.dgvPersonAttendDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPersonAttendDetail.MultiSelect = false;
            this.dgvPersonAttendDetail.Name = "dgvPersonAttendDetail";
            this.dgvPersonAttendDetail.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPersonAttendDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPersonAttendDetail.RowHeadersVisible = false;
            this.dgvPersonAttendDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonAttendDetail.Size = new System.Drawing.Size(1222, 525);
            this.dgvPersonAttendDetail.TabIndex = 97;
            // 
            // pagerPanel
            // 
            this.pagerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel.Location = new System.Drawing.Point(6, 653);
            this.pagerPanel.Name = "pagerPanel";
            this.pagerPanel.Size = new System.Drawing.Size(1222, 22);
            this.pagerPanel.TabIndex = 101;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilterBox.Controls.Add(this.lblTime);
            this.pnlFilterBox.Controls.Add(this.txtdtpDateIn2);
            this.pnlFilterBox.Controls.Add(this.txtdtpDateIn);
            this.pnlFilterBox.Controls.Add(this.lblTo);
            this.pnlFilterBox.Controls.Add(this.dataGridview4Export);
            this.pnlFilterBox.Controls.Add(this.tbxOrgName);
            this.pnlFilterBox.Controls.Add(this.lblGoverningOrganization);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(6, 63);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlFilterBox.Size = new System.Drawing.Size(1222, 65);
            this.pnlFilterBox.TabIndex = 100;
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTime.Location = new System.Drawing.Point(122, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(112, 22);
            this.lblTime.TabIndex = 159;
            this.lblTime.Text = "Thời gian:";
            // 
            // txtdtpDateIn2
            // 
            this.txtdtpDateIn2.BackColor = System.Drawing.Color.White;
            this.txtdtpDateIn2.Enabled = false;
            this.txtdtpDateIn2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtdtpDateIn2.Location = new System.Drawing.Point(430, 6);
            this.txtdtpDateIn2.Name = "txtdtpDateIn2";
            this.txtdtpDateIn2.Size = new System.Drawing.Size(103, 22);
            this.txtdtpDateIn2.TabIndex = 158;
            // 
            // txtdtpDateIn
            // 
            this.txtdtpDateIn.BackColor = System.Drawing.Color.White;
            this.txtdtpDateIn.Enabled = false;
            this.txtdtpDateIn.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtdtpDateIn.Location = new System.Drawing.Point(273, 6);
            this.txtdtpDateIn.Name = "txtdtpDateIn";
            this.txtdtpDateIn.Size = new System.Drawing.Size(103, 22);
            this.txtdtpDateIn.TabIndex = 157;
            // 
            // lblTo
            // 
            this.lblTo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTo.Location = new System.Drawing.Point(384, 8);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(40, 23);
            this.lblTo.TabIndex = 156;
            this.lblTo.Text = "đến";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataGridview4Export
            // 
            this.dataGridview4Export.AllowUserToAddRows = false;
            this.dataGridview4Export.AllowUserToDeleteRows = false;
            this.dataGridview4Export.AllowUserToOrderColumns = true;
            this.dataGridview4Export.AllowUserToResizeRows = false;
            this.dataGridview4Export.BackgroundColor = System.Drawing.Color.White;
            this.dataGridview4Export.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridview4Export.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridview4Export.ColumnHeadersHeight = 26;
            this.dataGridview4Export.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.colPositionEx,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.colIdentityCardEx,
            this.colPhoneEx,
            this.dataGridViewTextBoxColumn7});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridview4Export.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridview4Export.Location = new System.Drawing.Point(672, 9);
            this.dataGridview4Export.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridview4Export.MultiSelect = false;
            this.dataGridview4Export.Name = "dataGridview4Export";
            this.dataGridview4Export.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridview4Export.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridview4Export.RowHeadersVisible = false;
            this.dataGridview4Export.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridview4Export.Size = new System.Drawing.Size(240, 256);
            this.dataGridview4Export.TabIndex = 145;
            this.dataGridview4Export.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "OrderNum";
            this.dataGridViewTextBoxColumn1.HeaderText = "Stt";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NameAttendMeeting";
            this.dataGridViewTextBoxColumn2.HeaderText = "Người Tham Dự";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "OrgPartaker";
            this.dataGridViewTextBoxColumn3.HeaderText = "Tổ chức";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // colPositionEx
            // 
            this.colPositionEx.DataPropertyName = "colPosition";
            this.colPositionEx.HeaderText = "Chức vụ";
            this.colPositionEx.Name = "colPositionEx";
            this.colPositionEx.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DateTime";
            this.dataGridViewTextBoxColumn4.HeaderText = "Ngày";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "InputTime";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn5.HeaderText = "Giờ Vào";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "OutputTime";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn6.HeaderText = "Giờ Ra";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // colIdentityCardEx
            // 
            this.colIdentityCardEx.DataPropertyName = "colIdentityCard";
            this.colIdentityCardEx.HeaderText = "CMND";
            this.colIdentityCardEx.Name = "colIdentityCardEx";
            this.colIdentityCardEx.ReadOnly = true;
            // 
            // colPhoneEx
            // 
            this.colPhoneEx.DataPropertyName = "colPhone";
            this.colPhoneEx.HeaderText = "SDT";
            this.colPhoneEx.Name = "colPhoneEx";
            this.colPhoneEx.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Note";
            this.dataGridViewTextBoxColumn7.HeaderText = "Ghi Chú";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // tbxOrgName
            // 
            this.tbxOrgName.BackColor = System.Drawing.Color.White;
            this.tbxOrgName.Enabled = false;
            this.tbxOrgName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tbxOrgName.Location = new System.Drawing.Point(273, 34);
            this.tbxOrgName.Name = "tbxOrgName";
            this.tbxOrgName.Size = new System.Drawing.Size(260, 22);
            this.tbxOrgName.TabIndex = 112;
            // 
            // lblGoverningOrganization
            // 
            this.lblGoverningOrganization.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblGoverningOrganization.Location = new System.Drawing.Point(122, 37);
            this.lblGoverningOrganization.Name = "lblGoverningOrganization";
            this.lblGoverningOrganization.Size = new System.Drawing.Size(123, 19);
            this.lblGoverningOrganization.TabIndex = 110;
            this.lblGoverningOrganization.Text = "Đơn vị tổ chức:";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportToExcel.Enabled = false;
            this.btnExportToExcel.Image = global::sMeetingComponent.Properties.Resources.Excel_16x16;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExportToExcel.Text = "Xuất Ra Excel...";
            this.btnExportToExcel.ToolTipText = "Xuất dữ liệu đang hiển thị ra tập tin excel";
            // 
            // tmsMember
            // 
            this.tmsMember.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportToExcel});
            this.tmsMember.Location = new System.Drawing.Point(6, 38);
            this.tmsMember.Name = "tmsMember";
            this.tmsMember.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.tmsMember.Size = new System.Drawing.Size(1222, 25);
            this.tmsMember.TabIndex = 99;
            this.tmsMember.Text = "toolStrip1";
            // 
            // lbltitleLabelInfoMeetinginoutContactForWork
            // 
            this.lbltitleLabelInfoMeetinginoutContactForWork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lbltitleLabelInfoMeetinginoutContactForWork.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbltitleLabelInfoMeetinginoutContactForWork.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lbltitleLabelInfoMeetinginoutContactForWork.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbltitleLabelInfoMeetinginoutContactForWork.Location = new System.Drawing.Point(6, 6);
            this.lbltitleLabelInfoMeetinginoutContactForWork.Name = "lbltitleLabelInfoMeetinginoutContactForWork";
            this.lbltitleLabelInfoMeetinginoutContactForWork.Size = new System.Drawing.Size(1222, 32);
            this.lbltitleLabelInfoMeetinginoutContactForWork.TabIndex = 98;
            this.lbltitleLabelInfoMeetinginoutContactForWork.Text = "THÔNG TIN CHI TIẾT LIÊN HỆ CÔNG TÁC";
            this.lbltitleLabelInfoMeetinginoutContactForWork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colOrderNum
            // 
            this.colOrderNum.DataPropertyName = "OrderNum";
            this.colOrderNum.HeaderText = "Stt";
            this.colOrderNum.Name = "colOrderNum";
            this.colOrderNum.ReadOnly = true;
            this.colOrderNum.Width = 40;
            // 
            // colNameAttendMeeting
            // 
            this.colNameAttendMeeting.DataPropertyName = "NameAttendMeeting";
            this.colNameAttendMeeting.HeaderText = "Người Tham Dự";
            this.colNameAttendMeeting.Name = "colNameAttendMeeting";
            this.colNameAttendMeeting.ReadOnly = true;
            this.colNameAttendMeeting.Width = 200;
            // 
            // colPosition
            // 
            this.colPosition.DataPropertyName = "colPosition";
            this.colPosition.HeaderText = "Chức vụ";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            // 
            // colOrgPartaker
            // 
            this.colOrgPartaker.DataPropertyName = "OrgPartaker";
            this.colOrgPartaker.HeaderText = "Tổ chức";
            this.colOrgPartaker.Name = "colOrgPartaker";
            this.colOrgPartaker.ReadOnly = true;
            this.colOrgPartaker.Width = 200;
            // 
            // colDateTime
            // 
            this.colDateTime.DataPropertyName = "DateTime";
            this.colDateTime.HeaderText = "Ngày";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.ReadOnly = true;
            this.colDateTime.Width = 80;
            // 
            // colInputTime
            // 
            this.colInputTime.DataPropertyName = "InputTime";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colInputTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.colInputTime.HeaderText = "Giờ Vào";
            this.colInputTime.Name = "colInputTime";
            this.colInputTime.ReadOnly = true;
            this.colInputTime.Width = 80;
            // 
            // colOutputTime
            // 
            this.colOutputTime.DataPropertyName = "OutputTime";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colOutputTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.colOutputTime.HeaderText = "Giờ Ra";
            this.colOutputTime.Name = "colOutputTime";
            this.colOutputTime.ReadOnly = true;
            this.colOutputTime.Visible = false;
            this.colOutputTime.Width = 80;
            // 
            // colIdentityCard
            // 
            this.colIdentityCard.DataPropertyName = "colIdentityCard";
            this.colIdentityCard.HeaderText = "CMND";
            this.colIdentityCard.Name = "colIdentityCard";
            this.colIdentityCard.ReadOnly = true;
            // 
            // colPhone
            // 
            this.colPhone.DataPropertyName = "colPhone";
            this.colPhone.HeaderText = "SDT";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            // 
            // colNote
            // 
            this.colNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNote.DataPropertyName = "Note";
            this.colNote.HeaderText = "Ghi Chú";
            this.colNote.Name = "colNote";
            this.colNote.ReadOnly = true;
            // 
            // FrmInfoContactForWordStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 681);
            this.Controls.Add(this.dgvPersonAttendDetail);
            this.Controls.Add(this.pagerPanel);
            this.Controls.Add(this.pnlFilterBox);
            this.Controls.Add(this.tmsMember);
            this.Controls.Add(this.lbltitleLabelInfoMeetinginoutContactForWork);
            this.Name = "FrmInfoContactForWordStatistics";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin chi tiết hội họp";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonAttendDetail)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridview4Export)).EndInit();
            this.tmsMember.ResumeLayout(false);
            this.tmsMember.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CommonControls.Custom.CommonDataGridView dgvPersonAttendDetail;
        private ClientModel.Controls.Commons.CommonDataGridView dataGridview4Export;
        private CommonControls.Custom.PagerPanel pagerPanel;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.TextBox tbxOrgName;
        private System.Windows.Forms.Label lblGoverningOrganization;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private CommonControls.Custom.CommonToolStrip tmsMember;
        private CommonControls.Custom.TitleLabel lbltitleLabelInfoMeetinginoutContactForWork;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtdtpDateIn2;
        private System.Windows.Forms.TextBox txtdtpDateIn;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPositionEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentityCardEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoneEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameAttendMeeting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgPartaker;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInputTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutputTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentityCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
    }
}