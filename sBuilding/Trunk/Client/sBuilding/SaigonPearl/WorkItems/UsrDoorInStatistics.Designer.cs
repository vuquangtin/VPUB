namespace sAccessComponent.WorkItems
{
    partial class UsrDoorInStatistics
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrDoorInStatistics));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mniViewDoorOut = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAttendanceRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.miniToolStrip = new CommonControls.Custom.CommonToolStrip();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkAutoCloseNode = new System.Windows.Forms.CheckBox();
            this.trvDeviceList = new System.Windows.Forms.TreeView();
            this.tsmOrg = new CommonControls.Custom.CommonToolStrip();
            this.btnAddSubOrg = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpdateSubOrg = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveSubOrg = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSyncManagerCost = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReloadDevice = new System.Windows.Forms.ToolStripButton();
            this.lblLeftAreaTitleGroupDoor = new CommonControls.Custom.TitleLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDoorOutList = new CommonControls.Custom.CommonDataGridView();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.dtpDateIn = new System.Windows.Forms.DateTimePicker();
            this.cbxLoadImage = new System.Windows.Forms.CheckBox();
            this.tbxSerialNumber = new System.Windows.Forms.TextBox();
            this.cbxFilterByDate = new System.Windows.Forms.CheckBox();
            this.cbxFilterBySerialNumber = new System.Windows.Forms.CheckBox();
            this.tsmCard = new CommonControls.Custom.CommonToolStrip();
            this.btnShowHideFilter = new System.Windows.Forms.ToolStripButton();
            this.btnReloadCards = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.lblRightAreaTitleListAttendace = new CommonControls.Custom.TitleLabel();
            this.colDoorOutId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImageIn = new System.Windows.Forms.DataGridViewImageColumn();
            this.colImageOut = new System.Windows.Forms.DataGridViewImageColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsAttendanceRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tsmOrg.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoorOutList)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.tsmCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // mniViewDoorOut
            // 
            this.mniViewDoorOut.Name = "mniViewDoorOut";
            this.mniViewDoorOut.Size = new System.Drawing.Size(175, 22);
            this.mniViewDoorOut.Text = "Xem Lượt Vào/Ra...";
            // 
            // cmsAttendanceRecord
            // 
            this.cmsAttendanceRecord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniViewDoorOut});
            this.cmsAttendanceRecord.Name = "contextMenuStrip1";
            this.cmsAttendanceRecord.Size = new System.Drawing.Size(176, 26);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "colImageIn";
            this.dataGridViewImageColumn1.HeaderText = "Ảnh Vào";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.miniToolStrip.Size = new System.Drawing.Size(776, 25);
            this.miniToolStrip.TabIndex = 90;
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(5, 5);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panel4);
            this.splitContainer.Panel1.Controls.Add(this.lblLeftAreaTitleGroupDoor);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel1);
            this.splitContainer.Panel2.Controls.Add(this.lblRightAreaTitleListAttendace);
            this.splitContainer.Size = new System.Drawing.Size(790, 590);
            this.splitContainer.SplitterDistance = 200;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 68;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 30);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(198, 558);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.chkAutoCloseNode);
            this.panel5.Controls.Add(this.trvDeviceList);
            this.panel5.Controls.Add(this.tsmOrg);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(5, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(188, 548);
            this.panel5.TabIndex = 57;
            // 
            // chkAutoCloseNode
            // 
            this.chkAutoCloseNode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chkAutoCloseNode.Location = new System.Drawing.Point(0, 526);
            this.chkAutoCloseNode.Name = "chkAutoCloseNode";
            this.chkAutoCloseNode.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.chkAutoCloseNode.Size = new System.Drawing.Size(186, 20);
            this.chkAutoCloseNode.TabIndex = 58;
            this.chkAutoCloseNode.Text = "Tự động rút gọn danh sách";
            this.chkAutoCloseNode.UseVisualStyleBackColor = true;
            // 
            // trvDeviceList
            // 
            this.trvDeviceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvDeviceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDeviceList.Location = new System.Drawing.Point(0, 25);
            this.trvDeviceList.Name = "trvDeviceList";
            this.trvDeviceList.Size = new System.Drawing.Size(186, 521);
            this.trvDeviceList.TabIndex = 57;
            // 
            // tsmOrg
            // 
            this.tsmOrg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddSubOrg,
            this.toolStripSeparator4,
            this.btnUpdateSubOrg,
            this.btnRemoveSubOrg,
            this.toolStripSeparator1,
            this.btnSyncManagerCost,
            this.toolStripSeparator10,
            this.btnReloadDevice});
            this.tsmOrg.Location = new System.Drawing.Point(0, 0);
            this.tsmOrg.Name = "tsmOrg";
            this.tsmOrg.Size = new System.Drawing.Size(186, 25);
            this.tsmOrg.TabIndex = 56;
            this.tsmOrg.Text = "tlstripListGroup";
            // 
            // btnAddSubOrg
            // 
            this.btnAddSubOrg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddSubOrg.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSubOrg.Image")));
            this.btnAddSubOrg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddSubOrg.Name = "btnAddSubOrg";
            this.btnAddSubOrg.Size = new System.Drawing.Size(23, 22);
            this.btnAddSubOrg.Text = "Thêm Tổ Chức Mới...";
            this.btnAddSubOrg.ToolTipText = "Thêm tổ chức mới";
            this.btnAddSubOrg.Visible = false;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator4.Visible = false;
            // 
            // btnUpdateSubOrg
            // 
            this.btnUpdateSubOrg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateSubOrg.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateSubOrg.Image")));
            this.btnUpdateSubOrg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateSubOrg.Name = "btnUpdateSubOrg";
            this.btnUpdateSubOrg.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateSubOrg.Text = "Cập Nhật...";
            this.btnUpdateSubOrg.ToolTipText = "Cập nhật thông tin nhóm";
            this.btnUpdateSubOrg.Visible = false;
            // 
            // btnRemoveSubOrg
            // 
            this.btnRemoveSubOrg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveSubOrg.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveSubOrg.Image")));
            this.btnRemoveSubOrg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveSubOrg.Name = "btnRemoveSubOrg";
            this.btnRemoveSubOrg.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveSubOrg.Text = "Hủy...";
            this.btnRemoveSubOrg.ToolTipText = "Hủy nhóm khỏi hệ thống";
            this.btnRemoveSubOrg.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator1.Visible = false;
            // 
            // btnSyncManagerCost
            // 
            this.btnSyncManagerCost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSyncManagerCost.Image = ((System.Drawing.Image)(resources.GetObject("btnSyncManagerCost.Image")));
            this.btnSyncManagerCost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSyncManagerCost.Name = "btnSyncManagerCost";
            this.btnSyncManagerCost.Size = new System.Drawing.Size(23, 22);
            this.btnSyncManagerCost.Text = "Tích Hợp Dữ Liệu...";
            this.btnSyncManagerCost.ToolTipText = "Tích hợp dữ liệu phí quản lý và tiền nước vào hệ thống";
            this.btnSyncManagerCost.Visible = false;
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator10.Visible = false;
            // 
            // btnReloadDevice
            // 
            this.btnReloadDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadDevice.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadDevice.Image")));
            this.btnReloadDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadDevice.Name = "btnReloadDevice";
            this.btnReloadDevice.Size = new System.Drawing.Size(23, 22);
            this.btnReloadDevice.Text = "Tải Dữ Liệu";
            this.btnReloadDevice.ToolTipText = "Tải danh sách nhóm";
            // 
            // lblLeftAreaTitleGroupDoor
            // 
            this.lblLeftAreaTitleGroupDoor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblLeftAreaTitleGroupDoor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftAreaTitleGroupDoor.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblLeftAreaTitleGroupDoor.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLeftAreaTitleGroupDoor.Location = new System.Drawing.Point(0, 0);
            this.lblLeftAreaTitleGroupDoor.Name = "lblLeftAreaTitleGroupDoor";
            this.lblLeftAreaTitleGroupDoor.Size = new System.Drawing.Size(198, 30);
            this.lblLeftAreaTitleGroupDoor.TabIndex = 2;
            this.lblLeftAreaTitleGroupDoor.Text = "DANH SÁCH THIẾT BỊ CỬA";
            this.lblLeftAreaTitleGroupDoor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 558);
            this.panel1.TabIndex = 70;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(583, 558);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvDoorOutList);
            this.panel3.Controls.Add(this.pnlFilterBox);
            this.panel3.Controls.Add(this.tsmCard);
            this.panel3.Controls.Add(this.pagerPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(573, 548);
            this.panel3.TabIndex = 1;
            // 
            // dgvDoorOutList
            // 
            this.dgvDoorOutList.AllowUserToAddRows = false;
            this.dgvDoorOutList.AllowUserToDeleteRows = false;
            this.dgvDoorOutList.AllowUserToOrderColumns = true;
            this.dgvDoorOutList.AllowUserToResizeRows = false;
            this.dgvDoorOutList.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoorOutList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDoorOutList.ColumnHeadersHeight = 26;
            this.dgvDoorOutList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDoorOutId,
            this.colMemberId,
            this.colCardId,
            this.colApartment,
            this.colMemberCode,
            this.colFullName,
            this.colDateIn,
            this.colDateOut,
            this.colImageIn,
            this.colImageOut,
            this.colBlank});
            this.dgvDoorOutList.Location = new System.Drawing.Point(0, 117);
            this.dgvDoorOutList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDoorOutList.MultiSelect = false;
            this.dgvDoorOutList.Name = "dgvDoorOutList";
            this.dgvDoorOutList.ReadOnly = true;
            this.dgvDoorOutList.RowHeadersVisible = false;
            this.dgvDoorOutList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoorOutList.Size = new System.Drawing.Size(571, 409);
            this.dgvDoorOutList.TabIndex = 92;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilterBox.Controls.Add(this.dtpDateIn);
            this.pnlFilterBox.Controls.Add(this.cbxLoadImage);
            this.pnlFilterBox.Controls.Add(this.tbxSerialNumber);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByDate);
            this.pnlFilterBox.Controls.Add(this.cbxFilterBySerialNumber);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(571, 92);
            this.pnlFilterBox.TabIndex = 91;
            // 
            // dtpDateIn
            // 
            this.dtpDateIn.CustomFormat = "dd/MM/yyyy";
            this.dtpDateIn.Enabled = false;
            this.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateIn.Location = new System.Drawing.Point(181, 35);
            this.dtpDateIn.Name = "dtpDateIn";
            this.dtpDateIn.Size = new System.Drawing.Size(180, 22);
            this.dtpDateIn.TabIndex = 70;
            // 
            // cbxLoadImage
            // 
            this.cbxLoadImage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cbxLoadImage.Location = new System.Drawing.Point(5, 62);
            this.cbxLoadImage.Name = "cbxLoadImage";
            this.cbxLoadImage.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.cbxLoadImage.Size = new System.Drawing.Size(561, 25);
            this.cbxLoadImage.TabIndex = 69;
            this.cbxLoadImage.Text = "Tải trước hình vào/ra (tùy chọn này sẽ làm chậm tốc độ tải dữ liệu)";
            this.cbxLoadImage.UseVisualStyleBackColor = true;
            // 
            // tbxSerialNumber
            // 
            this.tbxSerialNumber.Enabled = false;
            this.tbxSerialNumber.Location = new System.Drawing.Point(181, 8);
            this.tbxSerialNumber.Name = "tbxSerialNumber";
            this.tbxSerialNumber.Size = new System.Drawing.Size(180, 22);
            this.tbxSerialNumber.TabIndex = 66;
            // 
            // cbxFilterByDate
            // 
            this.cbxFilterByDate.Location = new System.Drawing.Point(8, 34);
            this.cbxFilterByDate.Name = "cbxFilterByDate";
            this.cbxFilterByDate.Size = new System.Drawing.Size(167, 20);
            this.cbxFilterByDate.TabIndex = 13;
            this.cbxFilterByDate.Text = "Lọc theo ngày:";
            this.cbxFilterByDate.UseVisualStyleBackColor = true;
            // 
            // cbxFilterBySerialNumber
            // 
            this.cbxFilterBySerialNumber.Location = new System.Drawing.Point(8, 8);
            this.cbxFilterBySerialNumber.Name = "cbxFilterBySerialNumber";
            this.cbxFilterBySerialNumber.Size = new System.Drawing.Size(167, 20);
            this.cbxFilterBySerialNumber.TabIndex = 10;
            this.cbxFilterBySerialNumber.Text = "Lọc theo mã thẻ:";
            this.cbxFilterBySerialNumber.UseVisualStyleBackColor = true;
            // 
            // tsmCard
            // 
            this.tsmCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowHideFilter,
            this.btnReloadCards,
            this.toolStripSeparator2,
            this.btnExportToExcel});
            this.tsmCard.Location = new System.Drawing.Point(0, 0);
            this.tsmCard.Name = "tsmCard";
            this.tsmCard.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsmCard.Size = new System.Drawing.Size(571, 25);
            this.tsmCard.TabIndex = 90;
            this.tsmCard.Text = "tlstripListUser";
            // 
            // btnShowHideFilter
            // 
            this.btnShowHideFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnShowHideFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowHideFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnShowHideFilter.Image")));
            this.btnShowHideFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHideFilter.Name = "btnShowHideFilter";
            this.btnShowHideFilter.Size = new System.Drawing.Size(23, 22);
            this.btnShowHideFilter.Text = "Ẩn Khung Tìm Kiếm";
            this.btnShowHideFilter.ToolTipText = "Ẩn khung tìm kiếm";
            // 
            // btnReloadCards
            // 
            this.btnReloadCards.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadCards.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadCards.Image")));
            this.btnReloadCards.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadCards.Name = "btnReloadCards";
            this.btnReloadCards.Size = new System.Drawing.Size(23, 22);
            this.btnReloadCards.Text = "Tải Dữ Liệu";
            this.btnReloadCards.ToolTipText = "Tải danh sách lượt phát hành";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportToExcel.Image = global::sAccessComponent.Properties.Resources.Excel_16x16;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExportToExcel.Text = "Xuất Ra Excel...";
            this.btnExportToExcel.ToolTipText = "Xuất dữ liệu đang hiển thị ra tập tin excel";
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 526);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(571, 20);
            this.pagerPanel1.TabIndex = 89;
            // 
            // lblRightAreaTitleListAttendace
            // 
            this.lblRightAreaTitleListAttendace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitleListAttendace.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitleListAttendace.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblRightAreaTitleListAttendace.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitleListAttendace.Location = new System.Drawing.Point(0, 0);
            this.lblRightAreaTitleListAttendace.Name = "lblRightAreaTitleListAttendace";
            this.lblRightAreaTitleListAttendace.Size = new System.Drawing.Size(583, 30);
            this.lblRightAreaTitleListAttendace.TabIndex = 69;
            this.lblRightAreaTitleListAttendace.Text = "THỐNG KÊ VÀO/RA";
            this.lblRightAreaTitleListAttendace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colDoorOutId
            // 
            this.colDoorOutId.DataPropertyName = "DoorOutId";
            this.colDoorOutId.HeaderText = "DoorOutId";
            this.colDoorOutId.Name = "colDoorOutId";
            this.colDoorOutId.ReadOnly = true;
            this.colDoorOutId.Visible = false;
            // 
            // colMemberId
            // 
            this.colMemberId.DataPropertyName = "MemberId";
            this.colMemberId.HeaderText = "MemberId";
            this.colMemberId.Name = "colMemberId";
            this.colMemberId.ReadOnly = true;
            this.colMemberId.Visible = false;
            // 
            // colCardId
            // 
            this.colCardId.DataPropertyName = "SerialNumber";
            this.colCardId.HeaderText = "Mã Thẻ";
            this.colCardId.Name = "colCardId";
            this.colCardId.ReadOnly = true;
            // 
            // colApartment
            // 
            this.colApartment.DataPropertyName = "SubOrgName";
            this.colApartment.HeaderText = "Căn Hộ";
            this.colApartment.Name = "colApartment";
            this.colApartment.ReadOnly = true;
            // 
            // colMemberCode
            // 
            this.colMemberCode.DataPropertyName = "MemberCode";
            this.colMemberCode.HeaderText = "Mã Thành Viên";
            this.colMemberCode.Name = "colMemberCode";
            this.colMemberCode.ReadOnly = true;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "MemberFullName";
            this.colFullName.HeaderText = "Họ Và Tên";
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            this.colFullName.Width = 150;
            // 
            // colDateIn
            // 
            this.colDateIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDateIn.DataPropertyName = "DateIn";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDateIn.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDateIn.HeaderText = "Ngày giờ vào";
            this.colDateIn.Name = "colDateIn";
            this.colDateIn.ReadOnly = true;
            this.colDateIn.Width = 102;
            // 
            // colDateOut
            // 
            this.colDateOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDateOut.DataPropertyName = "DateOut";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDateOut.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDateOut.HeaderText = "Ngày Giờ Ra";
            this.colDateOut.Name = "colDateOut";
            this.colDateOut.ReadOnly = true;
            this.colDateOut.Width = 97;
            // 
            // colImageIn
            // 
            this.colImageIn.DataPropertyName = "colImageIn";
            this.colImageIn.HeaderText = "Ảnh Vào";
            this.colImageIn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colImageIn.Name = "colImageIn";
            this.colImageIn.ReadOnly = true;
            this.colImageIn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colImageOut
            // 
            this.colImageOut.DataPropertyName = "colImageOut";
            this.colImageOut.HeaderText = "Ảnh Ra";
            this.colImageOut.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colImageOut.Name = "colImageOut";
            this.colImageOut.ReadOnly = true;
            this.colImageOut.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colBlank
            // 
            this.colBlank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBlank.DataPropertyName = "Blank";
            this.colBlank.HeaderText = "";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            // 
            // UsrDoorInStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrDoorInStatistics";
            this.Size = new System.Drawing.Size(800, 600);
            this.cmsAttendanceRecord.ResumeLayout(false);
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
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoorOutList)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.tsmCard.ResumeLayout(false);
            this.tsmCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mniViewDoorOut;
        private System.Windows.Forms.ContextMenuStrip cmsAttendanceRecord;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private CommonControls.Custom.CommonToolStrip miniToolStrip;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox chkAutoCloseNode;
        private System.Windows.Forms.TreeView trvDeviceList;
        private CommonControls.Custom.CommonToolStrip tsmOrg;
        private System.Windows.Forms.ToolStripButton btnAddSubOrg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnUpdateSubOrg;
        private System.Windows.Forms.ToolStripButton btnRemoveSubOrg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSyncManagerCost;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnReloadDevice;
        private CommonControls.Custom.TitleLabel lblLeftAreaTitleGroupDoor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CommonControls.Custom.TitleLabel lblRightAreaTitleListAttendace;
        private System.Windows.Forms.Panel panel3;
        private CommonControls.Custom.CommonDataGridView dgvDoorOutList;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.DateTimePicker dtpDateIn;
        private System.Windows.Forms.CheckBox cbxLoadImage;
        private System.Windows.Forms.TextBox tbxSerialNumber;
        private System.Windows.Forms.CheckBox cbxFilterByDate;
        private System.Windows.Forms.CheckBox cbxFilterBySerialNumber;
        private CommonControls.Custom.CommonToolStrip tsmCard;
        private System.Windows.Forms.ToolStripButton btnShowHideFilter;
        private System.Windows.Forms.ToolStripButton btnReloadCards;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoorOutId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateOut;
        private System.Windows.Forms.DataGridViewImageColumn colImageIn;
        private System.Windows.Forms.DataGridViewImageColumn colImageOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
    }
}
