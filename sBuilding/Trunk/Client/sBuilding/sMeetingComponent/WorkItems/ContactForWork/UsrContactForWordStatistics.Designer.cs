﻿using System.ComponentModel;

namespace sMeetingComponent.WorkItems.ContactForWork
{
    partial class UsrContactForWordStatistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrContactForWordStatistics));
            this.lblRightAreaTitleListAttendaceContactForWork = new CommonControls.Custom.TitleLabel();
            this.cmsPersoRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniInfor = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1Outside = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridview4Export = new ClientModel.Controls.Commons.CommonDataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAttendMeetingStatisticList = new CommonControls.Custom.CommonDataGridView();
            this.colOrgMeetingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrganizationMeetingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberPeopleInvation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInfo = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFilterByDate = new System.Windows.Forms.Label();
            this.lblTo1 = new System.Windows.Forms.Label();
            this.dtpDateIn2 = new System.Windows.Forms.DateTimePicker();
            this.dtpDateIn = new System.Windows.Forms.DateTimePicker();
            this.cbxNameOrgSearch = new System.Windows.Forms.ComboBox();
            this.lblFilterByOrgName = new System.Windows.Forms.Label();
            this.tsmCard = new CommonControls.Custom.CommonToolStrip();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.cmsPersoRecord.SuspendLayout();
            this.panel1Outside.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridview4Export)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendMeetingStatisticList)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tsmCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRightAreaTitleListAttendaceContactForWork
            // 
            this.lblRightAreaTitleListAttendaceContactForWork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitleListAttendaceContactForWork.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitleListAttendaceContactForWork.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblRightAreaTitleListAttendaceContactForWork.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitleListAttendaceContactForWork.Location = new System.Drawing.Point(6, 5);
            this.lblRightAreaTitleListAttendaceContactForWork.Name = "lblRightAreaTitleListAttendaceContactForWork";
            this.lblRightAreaTitleListAttendaceContactForWork.Size = new System.Drawing.Size(1015, 32);
            this.lblRightAreaTitleListAttendaceContactForWork.TabIndex = 70;
            this.lblRightAreaTitleListAttendaceContactForWork.Text = "THỐNG KÊ LIÊN HỆ CÔNG TÁC";
            this.lblRightAreaTitleListAttendaceContactForWork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmsPersoRecord
            // 
            this.cmsPersoRecord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniInfor});
            this.cmsPersoRecord.Name = "contextMenuStrip1";
            this.cmsPersoRecord.Size = new System.Drawing.Size(157, 26);
            // 
            // mniInfor
            // 
            this.mniInfor.Image = global::sMeetingComponent.Properties.Resources.info16x16;
            this.mniInfor.Name = "mniInfor";
            this.mniInfor.Size = new System.Drawing.Size(156, 22);
            this.mniInfor.Text = "Xem Thông Tin";
            this.mniInfor.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // panel1Outside
            // 
            this.panel1Outside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1Outside.Controls.Add(this.panel1);
            this.panel1Outside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1Outside.Location = new System.Drawing.Point(6, 37);
            this.panel1Outside.Name = "panel1Outside";
            this.panel1Outside.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1Outside.Size = new System.Drawing.Size(1015, 474);
            this.panel1Outside.TabIndex = 71;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 462);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dataGridview4Export);
            this.panel3.Controls.Add(this.dgvAttendMeetingStatisticList);
            this.panel3.Controls.Add(this.pnlFilterBox);
            this.panel3.Controls.Add(this.tsmCard);
            this.panel3.Controls.Add(this.pagerPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1001, 462);
            this.panel3.TabIndex = 2;
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
            this.dataGridViewTextBoxColumn9});
            this.dataGridview4Export.Location = new System.Drawing.Point(553, 63);
            this.dataGridview4Export.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridview4Export.MultiSelect = false;
            this.dataGridview4Export.Name = "dataGridview4Export";
            this.dataGridview4Export.ReadOnly = true;
            this.dataGridview4Export.RowHeadersVisible = false;
            this.dataGridview4Export.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridview4Export.Size = new System.Drawing.Size(245, 360);
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
            this.dataGridViewTextBoxColumn3.Width = 115;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "NumberPeopleInvation";
            this.dataGridViewTextBoxColumn9.HeaderText = "SL được mời";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 105;
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
            this.colNumberPeopleInvation,
            this.colInfo});
            this.dgvAttendMeetingStatisticList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttendMeetingStatisticList.Location = new System.Drawing.Point(0, 100);
            this.dgvAttendMeetingStatisticList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAttendMeetingStatisticList.MultiSelect = false;
            this.dgvAttendMeetingStatisticList.Name = "dgvAttendMeetingStatisticList";
            this.dgvAttendMeetingStatisticList.ReadOnly = true;
            this.dgvAttendMeetingStatisticList.RowHeadersVisible = false;
            this.dgvAttendMeetingStatisticList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendMeetingStatisticList.Size = new System.Drawing.Size(999, 338);
            this.dgvAttendMeetingStatisticList.TabIndex = 5;
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
            this.colOrganizationMeetingName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOrganizationMeetingName.DataPropertyName = "OrganizationMeetingName";
            this.colOrganizationMeetingName.HeaderText = "Đơn vị tổ chức";
            this.colOrganizationMeetingName.Name = "colOrganizationMeetingName";
            this.colOrganizationMeetingName.ReadOnly = true;
            // 
            // colNumberPeopleInvation
            // 
            this.colNumberPeopleInvation.DataPropertyName = "NumberPeopleInvation";
            this.colNumberPeopleInvation.HeaderText = "SL được mời";
            this.colNumberPeopleInvation.Name = "colNumberPeopleInvation";
            this.colNumberPeopleInvation.ReadOnly = true;
            this.colNumberPeopleInvation.Width = 145;
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
            // pnlFilterBox
            // 
            this.pnlFilterBox.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilterBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilterBox.Controls.Add(this.panel2);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlFilterBox.Size = new System.Drawing.Size(999, 75);
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
            this.panel2.Location = new System.Drawing.Point(6, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(985, 61);
            this.panel2.TabIndex = 1;
            // 
            // lblFilterByDate
            // 
            this.lblFilterByDate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFilterByDate.Location = new System.Drawing.Point(92, 3);
            this.lblFilterByDate.Name = "lblFilterByDate";
            this.lblFilterByDate.Size = new System.Drawing.Size(141, 24);
            this.lblFilterByDate.TabIndex = 101;
            this.lblFilterByDate.Text = "Lọc theo ngày:";
            this.lblFilterByDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTo1
            // 
            this.lblTo1.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTo1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTo1.Location = new System.Drawing.Point(369, 4);
            this.lblTo1.Name = "lblTo1";
            this.lblTo1.Size = new System.Drawing.Size(33, 22);
            this.lblTo1.TabIndex = 100;
            this.lblTo1.Text = "đến";
            this.lblTo1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDateIn2
            // 
            this.dtpDateIn2.CustomFormat = "dd/MM/yyyy";
            this.dtpDateIn2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpDateIn2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateIn2.Location = new System.Drawing.Point(408, 3);
            this.dtpDateIn2.Name = "dtpDateIn2";
            this.dtpDateIn2.Size = new System.Drawing.Size(91, 22);
            this.dtpDateIn2.TabIndex = 2;
            // 
            // dtpDateIn
            // 
            this.dtpDateIn.CustomFormat = "dd/MM/yyyy";
            this.dtpDateIn.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateIn.Location = new System.Drawing.Point(272, 3);
            this.dtpDateIn.Name = "dtpDateIn";
            this.dtpDateIn.Size = new System.Drawing.Size(91, 22);
            this.dtpDateIn.TabIndex = 1;
            // 
            // cbxNameOrgSearch
            // 
            this.cbxNameOrgSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNameOrgSearch.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbxNameOrgSearch.FormattingEnabled = true;
            this.cbxNameOrgSearch.Location = new System.Drawing.Point(272, 32);
            this.cbxNameOrgSearch.Name = "cbxNameOrgSearch";
            this.cbxNameOrgSearch.Size = new System.Drawing.Size(227, 22);
            this.cbxNameOrgSearch.TabIndex = 3;
            // 
            // lblFilterByOrgName
            // 
            this.lblFilterByOrgName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFilterByOrgName.Location = new System.Drawing.Point(92, 31);
            this.lblFilterByOrgName.Name = "lblFilterByOrgName";
            this.lblFilterByOrgName.Size = new System.Drawing.Size(174, 24);
            this.lblFilterByOrgName.TabIndex = 96;
            this.lblFilterByOrgName.Text = "Lọc theo đơn vị tổ chức:";
            this.lblFilterByOrgName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsmCard
            // 
            this.tsmCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportToExcel,
            this.btnReload,
            this.btnShowHide});
            this.tsmCard.Location = new System.Drawing.Point(0, 0);
            this.tsmCard.Name = "tsmCard";
            this.tsmCard.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.tsmCard.Size = new System.Drawing.Size(999, 25);
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
            this.btnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExportToExcel.Text = "Xuất Ra Excel...";
            this.btnExportToExcel.ToolTipText = "Xuất dữ liệu đang hiển thị ra tập tin excel";
            // 
            // btnReload
            // 
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(23, 22);
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
            this.btnShowHide.Size = new System.Drawing.Size(23, 22);
            this.btnShowHide.Text = "Ẩn Khung Tìm Kiếm";
            this.btnShowHide.ToolTipText = "Ẩn khung tìm kiếm";
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 438);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(999, 22);
            this.pagerPanel1.TabIndex = 89;
            // 
            // UsrContactForWordStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1Outside);
            this.Controls.Add(this.lblRightAreaTitleListAttendaceContactForWork);
            this.Name = "UsrContactForWordStatistics";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Size = new System.Drawing.Size(1027, 516);
            this.cmsPersoRecord.ResumeLayout(false);
            this.panel1Outside.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridview4Export)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendMeetingStatisticList)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tsmCard.ResumeLayout(false);
            this.tsmCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControls.Custom.TitleLabel lblRightAreaTitleListAttendaceContactForWork;
        private System.Windows.Forms.ContextMenuStrip cmsPersoRecord;
        private System.Windows.Forms.ToolStripMenuItem mniInfor;
        private System.Windows.Forms.DataGridViewImageColumn imageColumns;
        private System.Windows.Forms.Panel panel1Outside;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private ClientModel.Controls.Commons.CommonDataGridView dataGridview4Export;
        private CommonControls.Custom.CommonDataGridView dgvAttendMeetingStatisticList;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFilterByDate;
        private System.Windows.Forms.Label lblTo1;
        private System.Windows.Forms.DateTimePicker dtpDateIn2;
        private System.Windows.Forms.DateTimePicker dtpDateIn;
        private System.Windows.Forms.ComboBox cbxNameOrgSearch;
        private System.Windows.Forms.Label lblFilterByOrgName;
        private CommonControls.Custom.CommonToolStrip tsmCard;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.ToolStripButton btnShowHide;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgMeetingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrganizationMeetingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberPeopleInvation;
        private System.Windows.Forms.DataGridViewImageColumn colInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}
