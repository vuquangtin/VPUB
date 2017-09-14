using CommonHelper.Constants;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using System.Resources;
namespace sTimeKeeping.WorkItems
{
    partial class UsrTimeEvent 
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

        private void getAll()
        {

        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrTimeEvent));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsCardTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniImportCard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mniExportExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniReloadCards = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRightEvent = new CommonControls.Custom.TitleLabel();
            this.line1 = new CommonControls.Custom.Line();
            this.cmsOrgTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniReloadOrgs = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.trvOrganizations = new System.Windows.Forms.TreeView();
            this.tsmOrg = new CommonControls.Custom.CommonToolStrip();
            this.btnRefreshOrg = new System.Windows.Forms.ToolStripButton();
            this.lblLeftAreaTitleEvent = new CommonControls.Custom.TitleLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvEvent = new CommonControls.Custom.CommonDataGridView();
            this.colEventId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventMemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimebegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbxFilterByEventName = new System.Windows.Forms.Label();
            this.commonToolStrip1 = new CommonControls.Custom.CommonToolStrip();
            this.menuAdd = new System.Windows.Forms.ToolStripButton();
            this.menuEdit = new System.Windows.Forms.ToolStripButton();
            this.menuDelete = new System.Windows.Forms.ToolStripButton();
            this.menuSync = new System.Windows.Forms.ToolStripButton();
            this.menuReload = new System.Windows.Forms.ToolStripButton();
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.lblDateEnd = new System.Windows.Forms.Label();
            this.lbLDateBegin = new System.Windows.Forms.Label();
            this.line2 = new CommonControls.Custom.Line();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.miniToolStrip = new CommonControls.Custom.CommonToolStrip();
            this.cmsMemberRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAddMemevent = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDeleteMemEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCardTable.SuspendLayout();
            this.cmsOrgTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tsmOrg.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvent)).BeginInit();
            this.panel3.SuspendLayout();
            this.commonToolStrip1.SuspendLayout();
            this.cmsMemberRecord.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsCardTable
            // 
            this.cmsCardTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniImportCard,
            this.toolStripSeparator3,
            this.mniExportExcelToolStripMenuItem,
            this.mniReloadCards});
            this.cmsCardTable.Name = "contextMenuStrip1";
            this.cmsCardTable.Size = new System.Drawing.Size(153, 76);
            // 
            // mniImportCard
            // 
            this.mniImportCard.Name = "mniImportCard";
            this.mniImportCard.Size = new System.Drawing.Size(152, 22);
            this.mniImportCard.Text = "Nhập Khóa...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // mniExportExcelToolStripMenuItem
            // 
            this.mniExportExcelToolStripMenuItem.Name = "mniExportExcelToolStripMenuItem";
            this.mniExportExcelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mniExportExcelToolStripMenuItem.Text = "Xuất Ra Excel...";
            // 
            // mniReloadCards
            // 
            this.mniReloadCards.Name = "mniReloadCards";
            this.mniReloadCards.Size = new System.Drawing.Size(152, 22);
            this.mniReloadCards.Text = "Tải Dữ Liệu";
            // 
            // lblRightEvent
            // 
            this.lblRightEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightEvent.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblRightEvent.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightEvent.Location = new System.Drawing.Point(0, 0);
            this.lblRightEvent.Name = "lblRightEvent";
            this.lblRightEvent.Size = new System.Drawing.Size(782, 30);
            this.lblRightEvent.TabIndex = 34;
            this.lblRightEvent.Text = "ĐĂNG KÝ LỊCH HỌP - CÔNG TÁC - NGHỈ PHÉP";
            this.lblRightEvent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(1022, 1);
            this.line1.TabIndex = 71;
            this.line1.TabStop = false;
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
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panel4);
            this.splitContainer.Panel1.Controls.Add(this.lblLeftAreaTitleEvent);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel1);
            this.splitContainer.Panel2.Controls.Add(this.lblRightEvent);
            this.splitContainer.Size = new System.Drawing.Size(1022, 504);
            this.splitContainer.SplitterDistance = 233;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 70;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 30);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(231, 472);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.trvOrganizations);
            this.panel5.Controls.Add(this.tsmOrg);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(5, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(221, 462);
            this.panel5.TabIndex = 57;
            // 
            // trvOrganizations
            // 
            this.trvOrganizations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvOrganizations.ContextMenuStrip = this.cmsOrgTree;
            this.trvOrganizations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvOrganizations.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvOrganizations.Location = new System.Drawing.Point(0, 25);
            this.trvOrganizations.Name = "trvOrganizations";
            this.trvOrganizations.Size = new System.Drawing.Size(219, 435);
            this.trvOrganizations.TabIndex = 57;
            // 
            // tsmOrg
            // 
            this.tsmOrg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshOrg});
            this.tsmOrg.Location = new System.Drawing.Point(0, 0);
            this.tsmOrg.Name = "tsmOrg";
            this.tsmOrg.Size = new System.Drawing.Size(219, 25);
            this.tsmOrg.TabIndex = 56;
            this.tsmOrg.Text = "tlstripListGroup";
            // 
            // btnRefreshOrg
            // 
            this.btnRefreshOrg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshOrg.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshOrg.Image")));
            this.btnRefreshOrg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshOrg.Name = "btnRefreshOrg";
            this.btnRefreshOrg.Size = new System.Drawing.Size(23, 22);
            this.btnRefreshOrg.Text = "Tải dữ liệu";
            this.btnRefreshOrg.ToolTipText = "Tải dữ liệu";
            this.btnRefreshOrg.Click += new System.EventHandler(this.btnReloadOrgEvent_Click);
            // 
            // lblLeftAreaTitleEvent
            // 
            this.lblLeftAreaTitleEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblLeftAreaTitleEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftAreaTitleEvent.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblLeftAreaTitleEvent.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLeftAreaTitleEvent.Location = new System.Drawing.Point(0, 0);
            this.lblLeftAreaTitleEvent.Name = "lblLeftAreaTitleEvent";
            this.lblLeftAreaTitleEvent.Size = new System.Drawing.Size(231, 30);
            this.lblLeftAreaTitleEvent.TabIndex = 2;
            this.lblLeftAreaTitleEvent.Text = "DANH SÁCH PHÒNG BAN";
            this.lblLeftAreaTitleEvent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Size = new System.Drawing.Size(782, 472);
            this.panel1.TabIndex = 67;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.line2);
            this.panel2.Controls.Add(this.pagerPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 462);
            this.panel2.TabIndex = 38;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvEvent);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 96);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(768, 344);
            this.panel6.TabIndex = 80;
            // 
            // dgvEvent
            // 
            this.dgvEvent.AllowDrop = true;
            this.dgvEvent.AllowUserToAddRows = false;
            this.dgvEvent.AllowUserToDeleteRows = false;
            this.dgvEvent.AllowUserToOrderColumns = true;
            this.dgvEvent.AllowUserToResizeRows = false;
            this.dgvEvent.BackgroundColor = System.Drawing.Color.White;
            this.dgvEvent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEvent.ColumnHeadersHeight = 26;
            this.dgvEvent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEventId,
            this.colEventMemberId,
            this.colDate,
            this.colEventName,
            this.colMember,
            this.colTimebegin,
            this.colNumberHour,
            this.colDescription,
            this.colDetail});
            this.dgvEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEvent.Location = new System.Drawing.Point(0, 0);
            this.dgvEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvEvent.Name = "dgvEvent";
            this.dgvEvent.ReadOnly = true;
            this.dgvEvent.RowHeadersVisible = false;
            this.dgvEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvent.Size = new System.Drawing.Size(768, 344);
            this.dgvEvent.TabIndex = 107;
            // 
            // colEventId
            // 
            this.colEventId.DataPropertyName = "EventId";
            this.colEventId.HeaderText = "EventId";
            this.colEventId.Name = "colEventId";
            this.colEventId.ReadOnly = true;
            this.colEventId.Visible = false;
            // 
            // colEventMemberId
            // 
            this.colEventMemberId.DataPropertyName = "colEventMemberId";
            this.colEventMemberId.HeaderText = "EventMemberId";
            this.colEventMemberId.Name = "colEventMemberId";
            this.colEventMemberId.ReadOnly = true;
            this.colEventMemberId.Visible = false;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "colDate";
            this.colDate.HeaderText = "Ngày";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colEventName
            // 
            this.colEventName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEventName.DataPropertyName = "colEventName";
            this.colEventName.FillWeight = 80F;
            this.colEventName.HeaderText = "Tên sự kiện";
            this.colEventName.Name = "colEventName";
            this.colEventName.ReadOnly = true;
            // 
            // colMember
            // 
            this.colMember.DataPropertyName = "colMember";
            this.colMember.HeaderText = "Người đăng ký";
            this.colMember.Name = "colMember";
            this.colMember.ReadOnly = true;
            this.colMember.Visible = false;
            this.colMember.Width = 106;
            // 
            // colTimebegin
            // 
            this.colTimebegin.DataPropertyName = "timebegin";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTimebegin.DefaultCellStyle = dataGridViewCellStyle1;
            this.colTimebegin.HeaderText = "Giờ bắt đầu";
            this.colTimebegin.Name = "colTimebegin";
            this.colTimebegin.ReadOnly = true;
            this.colTimebegin.Width = 107;
            // 
            // colNumberHour
            // 
            this.colNumberHour.DataPropertyName = "numberHour";
            this.colNumberHour.HeaderText = "Số giờ";
            this.colNumberHour.Name = "colNumberHour";
            this.colNumberHour.ReadOnly = true;
            this.colNumberHour.Width = 120;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "description";
            this.colDescription.FillWeight = 120F;
            this.colDescription.HeaderText = "Mô tả";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colDetail
            // 
            this.colDetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDetail.DataPropertyName = "colDetail";
            this.colDetail.FillWeight = 20F;
            this.colDetail.HeaderText = "Xem chi tiết";
            this.colDetail.Image = ((System.Drawing.Image)(resources.GetObject("colDetail.Image")));
            this.colDetail.Name = "colDetail";
            this.colDetail.ReadOnly = true;
            this.colDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDetail.ToolTipText = "Xem chi tiết";
            this.colDetail.Width = 68;
            // 
            // panel3
            // 
            this.panel3.AllowDrop = true;
            this.panel3.Controls.Add(this.cbxFilterByEventName);
            this.panel3.Controls.Add(this.commonToolStrip1);
            this.panel3.Controls.Add(this.tbxCode);
            this.panel3.Controls.Add(this.dtpDateEnd);
            this.panel3.Controls.Add(this.dtpDateBegin);
            this.panel3.Controls.Add(this.lblDateEnd);
            this.panel3.Controls.Add(this.lbLDateBegin);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(768, 95);
            this.panel3.TabIndex = 79;
            // 
            // cbxFilterByEventName
            // 
            this.cbxFilterByEventName.AutoSize = true;
            this.cbxFilterByEventName.Location = new System.Drawing.Point(18, 67);
            this.cbxFilterByEventName.Name = "cbxFilterByEventName";
            this.cbxFilterByEventName.Size = new System.Drawing.Size(107, 13);
            this.cbxFilterByEventName.TabIndex = 115;
            this.cbxFilterByEventName.Text = "Lọc theo tên sự kiện:";
            // 
            // commonToolStrip1
            // 
            this.commonToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.commonToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdd,
            this.menuEdit,
            this.menuDelete,
            this.menuSync,
            this.menuReload});
            this.commonToolStrip1.Location = new System.Drawing.Point(4, 0);
            this.commonToolStrip1.Name = "commonToolStrip1";
            this.commonToolStrip1.Size = new System.Drawing.Size(158, 25);
            this.commonToolStrip1.TabIndex = 100;
            this.commonToolStrip1.Text = "tlstripListGroup";
            // 
            // menuAdd
            // 
            this.menuAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuAdd.Enabled = false;
            this.menuAdd.Image = ((System.Drawing.Image)(resources.GetObject("menuAdd.Image")));
            this.menuAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuAdd.Name = "menuAdd";
            this.menuAdd.Size = new System.Drawing.Size(23, 22);
            this.menuAdd.Text = "Thêm sự kiện";
            this.menuAdd.ToolTipText = "Thêm sự kiện mới";
            // 
            // menuEdit
            // 
            this.menuEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuEdit.Enabled = false;
            this.menuEdit.Image = ((System.Drawing.Image)(resources.GetObject("menuEdit.Image")));
            this.menuEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(23, 22);
            this.menuEdit.Text = "Sửa sự kiện";
            // 
            // menuDelete
            // 
            this.menuDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuDelete.Enabled = false;
            this.menuDelete.Image = ((System.Drawing.Image)(resources.GetObject("menuDelete.Image")));
            this.menuDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(23, 22);
            this.menuDelete.Text = "Xóa sự kiện";
            // 
            // menuSync
            // 
            this.menuSync.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuSync.Enabled = false;
            this.menuSync.Image = ((System.Drawing.Image)(resources.GetObject("menuSync.Image")));
            this.menuSync.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSync.Name = "menuSync";
            this.menuSync.Size = new System.Drawing.Size(23, 22);
            this.menuSync.Text = "toolStripButton1";
            this.menuSync.Click += new System.EventHandler(this.menuSync_Click);
            // 
            // menuReload
            // 
            this.menuReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuReload.Enabled = false;
            this.menuReload.Image = ((System.Drawing.Image)(resources.GetObject("menuReload.Image")));
            this.menuReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuReload.Name = "menuReload";
            this.menuReload.Size = new System.Drawing.Size(23, 22);
            this.menuReload.Text = "Tải dữ liệu";
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(131, 64);
            this.tbxCode.MaxLength = 1000;
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(243, 20);
            this.tbxCode.TabIndex = 106;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.CustomFormat = "dd/MM/yyyy";
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateEnd.Location = new System.Drawing.Point(272, 33);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(102, 20);
            this.dtpDateEnd.TabIndex = 104;
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.CustomFormat = "dd/MM/yyyy";
            this.dtpDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateBegin.Location = new System.Drawing.Point(76, 33);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(108, 20);
            this.dtpDateBegin.TabIndex = 102;
            // 
            // lblDateEnd
            // 
            this.lblDateEnd.AutoSize = true;
            this.lblDateEnd.Location = new System.Drawing.Point(208, 36);
            this.lblDateEnd.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblDateEnd.Name = "lblDateEnd";
            this.lblDateEnd.Size = new System.Drawing.Size(56, 13);
            this.lblDateEnd.TabIndex = 103;
            this.lblDateEnd.Text = "Đến ngày:";
            // 
            // lbLDateBegin
            // 
            this.lbLDateBegin.AutoSize = true;
            this.lbLDateBegin.Location = new System.Drawing.Point(18, 36);
            this.lbLDateBegin.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lbLDateBegin.Name = "lbLDateBegin";
            this.lbLDateBegin.Size = new System.Drawing.Size(49, 13);
            this.lbLDateBegin.TabIndex = 101;
            this.lbLDateBegin.Text = "Từ ngày:";
            // 
            // line2
            // 
            this.line2.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line2.Dock = System.Windows.Forms.DockStyle.Top;
            this.line2.Location = new System.Drawing.Point(0, 0);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(768, 1);
            this.line2.TabIndex = 77;
            this.line2.TabStop = false;
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 440);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(768, 20);
            this.pagerPanel1.TabIndex = 40;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(78, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(81, 25);
            this.miniToolStrip.TabIndex = 57;
            // 
            // cmsMemberRecord
            // 
            this.cmsMemberRecord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAddMemevent,
            this.mniDeleteMemEvent});
            this.cmsMemberRecord.Name = "contextMenuStrip1";
            this.cmsMemberRecord.Size = new System.Drawing.Size(227, 48);
            // 
            // mniAddMemevent
            // 
            this.mniAddMemevent.Image = ((System.Drawing.Image)(resources.GetObject("mniAddMemevent.Image")));
            this.mniAddMemevent.Name = "mniAddMemevent";
            this.mniAddMemevent.Size = new System.Drawing.Size(226, 22);
            this.mniAddMemevent.Text = "Thêm thành viên vào sự kiện";
            this.mniAddMemevent.Click += new System.EventHandler(this.mniAddMemevent_Click);
            // 
            // mniDeleteMemEvent
            // 
            this.mniDeleteMemEvent.Image = ((System.Drawing.Image)(resources.GetObject("mniDeleteMemEvent.Image")));
            this.mniDeleteMemEvent.Name = "mniDeleteMemEvent";
            this.mniDeleteMemEvent.Size = new System.Drawing.Size(226, 22);
            this.mniDeleteMemEvent.Text = "Xóa thành viên khỏi sự kiện";
            this.mniDeleteMemEvent.Click += new System.EventHandler(this.mniDeleteMemEvent_Click);
            // 
            // UsrTimeEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.line1);
            this.Controls.Add(this.splitContainer);
            this.Name = "UsrTimeEvent";
            this.Size = new System.Drawing.Size(1022, 504);
            this.cmsCardTable.ResumeLayout(false);
            this.cmsOrgTree.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tsmOrg.ResumeLayout(false);
            this.tsmOrg.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvent)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.commonToolStrip1.ResumeLayout(false);
            this.commonToolStrip1.PerformLayout();
            this.cmsMemberRecord.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsCardTable;
        private System.Windows.Forms.ToolStripMenuItem mniImportCard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mniExportExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniReloadCards;
        private CommonControls.Custom.TitleLabel lblRightEvent;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.ContextMenuStrip cmsOrgTree;
        private System.Windows.Forms.ToolStripMenuItem mniReloadOrgs;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CommonControls.Custom.Line line2;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private CommonControls.Custom.CommonToolStrip miniToolStrip;
        private System.Windows.Forms.Panel panel3;
        private CommonControls.Custom.CommonToolStrip commonToolStrip1;
        private System.Windows.Forms.ToolStripButton menuAdd;
        private System.Windows.Forms.ToolStripButton menuEdit;
        private System.Windows.Forms.ToolStripButton menuReload;
        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.Label lblDateEnd;
        private System.Windows.Forms.Label lbLDateBegin;
        private System.Windows.Forms.ContextMenuStrip cmsMemberRecord;
        private System.Windows.Forms.ToolStripMenuItem mniAddMemevent;
        private System.Windows.Forms.ToolStripMenuItem mniDeleteMemEvent;
        private System.Windows.Forms.ToolStripButton menuDelete;
        private System.Windows.Forms.Panel panel6;
        private CommonControls.Custom.CommonDataGridView dgvEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventMemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimebegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewImageColumn colDetail;
        private System.Windows.Forms.Label cbxFilterByEventName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TreeView trvOrganizations;
        private CommonControls.Custom.CommonToolStrip tsmOrg;
        private System.Windows.Forms.ToolStripButton btnRefreshOrg;
        private CommonControls.Custom.TitleLabel lblLeftAreaTitleEvent;
        private System.Windows.Forms.ToolStripButton menuSync;
    }
}
