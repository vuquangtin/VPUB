namespace CardMagneticMgtComponent.WorkItems
{
    partial class UsrListCardMagnetic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrListCardMagnetic));
            this.cmsCardTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniMarkBroken = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mniMarkLost = new System.Windows.Forms.ToolStripMenuItem();
            this.đánhDấuInThẻToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCard = new CommonControls.Custom.CommonToolStrip();
            this.btnImportCard = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHideFilter = new System.Windows.Forms.ToolStripButton();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnReloadCards = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCard = new CommonControls.Custom.CommonDataGridView();
            this.colMagneticId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrgMasterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrgPartnerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubOrgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMasterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartnerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrackData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPinCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColActiveCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTypeCrypto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrintedStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhysicalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.cmbCardPhysicalStatus = new System.Windows.Forms.ComboBox();
            this.cbxFilterByCardPhysicalStatus = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbtnStatusNoPrinted = new System.Windows.Forms.RadioButton();
            this.rbtnStatusPrinted = new System.Windows.Forms.RadioButton();
            this.cbxFilterByPrintedStatus = new System.Windows.Forms.CheckBox();
            this.cmbCardTypes = new System.Windows.Forms.ComboBox();
            this.cbxFilterByCardType = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tmsTeacher = new CommonControls.Custom.CommonToolStrip();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.btnMarkBroken = new System.Windows.Forms.ToolStripButton();
            this.btnMarkLost = new System.Windows.Forms.ToolStripButton();
            this.btnMarkPrinted = new System.Windows.Forms.ToolStripButton();
            this.btnExportExcel = new System.Windows.Forms.ToolStripButton();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.line1 = new CommonControls.Custom.Line();
            this.lblRightAreaTitleListCard = new CommonControls.Custom.TitleLabel();
            this.cmsCardTable.SuspendLayout();
            this.tsmCard.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCard)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tmsTeacher.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsCardTable
            // 
            this.cmsCardTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniMarkBroken,
            this.toolStripSeparator3,
            this.mniMarkLost,
            this.đánhDấuInThẻToolStripMenuItem});
            this.cmsCardTable.Name = "contextMenuStrip1";
            this.cmsCardTable.Size = new System.Drawing.Size(179, 76);
            // 
            // mniMarkBroken
            // 
            this.mniMarkBroken.Image = global::CardMagneticMgtComponent.Properties.Resources.MarkBlue_16x16;
            this.mniMarkBroken.Name = "mniMarkBroken";
            this.mniMarkBroken.Size = new System.Drawing.Size(178, 22);
            this.mniMarkBroken.Text = "Đánh dấu hư thẻ...";
            this.mniMarkBroken.Click += new System.EventHandler(this.btnMarkBroken_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(175, 6);
            // 
            // mniMarkLost
            // 
            this.mniMarkLost.Image = global::CardMagneticMgtComponent.Properties.Resources.MarkRed_16x16;
            this.mniMarkLost.Name = "mniMarkLost";
            this.mniMarkLost.Size = new System.Drawing.Size(178, 22);
            this.mniMarkLost.Text = "Đánh dấu mất thẻ...";
            this.mniMarkLost.Click += new System.EventHandler(this.btnMarkLost_Click);
            // 
            // đánhDấuInThẻToolStripMenuItem
            // 
            this.đánhDấuInThẻToolStripMenuItem.Image = global::CardMagneticMgtComponent.Properties.Resources.MarkBlack_16x16;
            this.đánhDấuInThẻToolStripMenuItem.Name = "đánhDấuInThẻToolStripMenuItem";
            this.đánhDấuInThẻToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.đánhDấuInThẻToolStripMenuItem.Text = "Đánh dấu in thẻ...";
            this.đánhDấuInThẻToolStripMenuItem.Click += new System.EventHandler(this.btnMarkPrinted_Click);
            // 
            // tsmCard
            // 
            this.tsmCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImportCard,
            this.toolStripSeparator1,
            this.btnShowHideFilter,
            this.btnExportToExcel,
            this.btnReloadCards});
            this.tsmCard.Location = new System.Drawing.Point(0, 0);
            this.tsmCard.Name = "tsmCard";
            this.tsmCard.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsmCard.Size = new System.Drawing.Size(778, 25);
            this.tsmCard.TabIndex = 38;
            this.tsmCard.Text = "tlstripListUser";
            // 
            // btnImportCard
            // 
            this.btnImportCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImportCard.Image = ((System.Drawing.Image)(resources.GetObject("btnImportCard.Image")));
            this.btnImportCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportCard.Name = "btnImportCard";
            this.btnImportCard.Size = new System.Drawing.Size(23, 22);
            this.btnImportCard.Text = "Nhập Khóa...";
            this.btnImportCard.ToolTipText = "Nhập khóa mới vào hệ thống";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // btnExportToExcel
            // 
            this.btnExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExportToExcel.Text = "Xuất Ra Excel...";
            this.btnExportToExcel.ToolTipText = "Xuất dữ liệu đang hiển thị ra tập tin excel";
            // 
            // btnReloadCards
            // 
            this.btnReloadCards.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadCards.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadCards.Name = "btnReloadCards";
            this.btnReloadCards.Size = new System.Drawing.Size(23, 22);
            this.btnReloadCards.Text = "Tải Dữ Liệu";
            this.btnReloadCards.ToolTipText = "Tải danh sách lượt phát hành";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvCard);
            this.panel1.Controls.Add(this.pnlFilterBox);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pagerPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 36);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Size = new System.Drawing.Size(790, 559);
            this.panel1.TabIndex = 72;
            // 
            // dgvCard
            // 
            this.dgvCard.AllowUserToAddRows = false;
            this.dgvCard.AllowUserToDeleteRows = false;
            this.dgvCard.AllowUserToOrderColumns = true;
            this.dgvCard.AllowUserToResizeRows = false;
            this.dgvCard.BackgroundColor = System.Drawing.Color.White;
            this.dgvCard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCard.ColumnHeadersHeight = 26;
            this.dgvCard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMagneticId,
            this.colOrgMasterId,
            this.colOrgPartnerId,
            this.colOrgName,
            this.colSubOrgName,
            this.colMasterCode,
            this.PartnerCode,
            this.colFullName,
            this.colCompany,
            this.colPhoneNumber,
            this.colSerialCard,
            this.colCardType,
            this.colTrackData,
            this.colPinCode,
            this.ColActiveCode,
            this.colTypeCrypto,
            this.colPrintedStatus,
            this.colPhysicalStatus,
            this.colStartDate,
            this.colExpireDate,
            this.colNotes});
            this.dgvCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCard.Location = new System.Drawing.Point(5, 125);
            this.dgvCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCard.Name = "dgvCard";
            this.dgvCard.ReadOnly = true;
            this.dgvCard.RowHeadersVisible = false;
            this.dgvCard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCard.Size = new System.Drawing.Size(778, 408);
            this.dgvCard.TabIndex = 86;
            // 
            // colMagneticId
            // 
            this.colMagneticId.DataPropertyName = "MagneticId";
            this.colMagneticId.HeaderText = "Mã Thẻ";
            this.colMagneticId.Name = "colMagneticId";
            this.colMagneticId.ReadOnly = true;
            // 
            // colOrgMasterId
            // 
            this.colOrgMasterId.DataPropertyName = "OrgMasterId";
            this.colOrgMasterId.HeaderText = "OrgMasterId";
            this.colOrgMasterId.Name = "colOrgMasterId";
            this.colOrgMasterId.ReadOnly = true;
            this.colOrgMasterId.Visible = false;
            // 
            // colOrgPartnerId
            // 
            this.colOrgPartnerId.DataPropertyName = "OrgPartnerId";
            this.colOrgPartnerId.HeaderText = "OrgPartnerId";
            this.colOrgPartnerId.Name = "colOrgPartnerId";
            this.colOrgPartnerId.ReadOnly = true;
            this.colOrgPartnerId.Visible = false;
            // 
            // colOrgName
            // 
            this.colOrgName.DataPropertyName = "OrgName";
            this.colOrgName.HeaderText = "Tên Tổ Chức";
            this.colOrgName.Name = "colOrgName";
            this.colOrgName.ReadOnly = true;
            // 
            // colSubOrgName
            // 
            this.colSubOrgName.DataPropertyName = "SubOrgName";
            this.colSubOrgName.HeaderText = "Tổ Chức Con";
            this.colSubOrgName.Name = "colSubOrgName";
            this.colSubOrgName.ReadOnly = true;
            this.colSubOrgName.Width = 200;
            // 
            // colMasterCode
            // 
            this.colMasterCode.DataPropertyName = "MasterCode";
            this.colMasterCode.HeaderText = "MasterCode";
            this.colMasterCode.Name = "colMasterCode";
            this.colMasterCode.ReadOnly = true;
            this.colMasterCode.Visible = false;
            // 
            // PartnerCode
            // 
            this.PartnerCode.HeaderText = "PartnerCode";
            this.PartnerCode.Name = "PartnerCode";
            this.PartnerCode.ReadOnly = true;
            this.PartnerCode.Visible = false;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            this.colFullName.HeaderText = "Họ Tên";
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            this.colFullName.Width = 150;
            // 
            // colCompany
            // 
            this.colCompany.DataPropertyName = "Company";
            this.colCompany.HeaderText = "Công Ty";
            this.colCompany.Name = "colCompany";
            this.colCompany.ReadOnly = true;
            // 
            // colPhoneNumber
            // 
            this.colPhoneNumber.DataPropertyName = "PhoneNumber";
            this.colPhoneNumber.HeaderText = "Số Điện Thoại";
            this.colPhoneNumber.Name = "colPhoneNumber";
            this.colPhoneNumber.ReadOnly = true;
            this.colPhoneNumber.Visible = false;
            // 
            // colSerialCard
            // 
            this.colSerialCard.DataPropertyName = "SerialCard";
            this.colSerialCard.HeaderText = "Mã Số Thẻ";
            this.colSerialCard.Name = "colSerialCard";
            this.colSerialCard.ReadOnly = true;
            // 
            // colCardType
            // 
            this.colCardType.DataPropertyName = "CardType";
            this.colCardType.HeaderText = "Loại Thẻ";
            this.colCardType.Name = "colCardType";
            this.colCardType.ReadOnly = true;
            // 
            // colTrackData
            // 
            this.colTrackData.DataPropertyName = "TrackData";
            this.colTrackData.HeaderText = "Track Từ";
            this.colTrackData.Name = "colTrackData";
            this.colTrackData.ReadOnly = true;
            this.colTrackData.Width = 150;
            // 
            // colPinCode
            // 
            this.colPinCode.DataPropertyName = "PinCode";
            this.colPinCode.HeaderText = "PinCode";
            this.colPinCode.Name = "colPinCode";
            this.colPinCode.ReadOnly = true;
            // 
            // ColActiveCode
            // 
            this.ColActiveCode.DataPropertyName = "ActiveCode";
            this.ColActiveCode.HeaderText = "ActiveCode";
            this.ColActiveCode.Name = "ColActiveCode";
            this.ColActiveCode.ReadOnly = true;
            this.ColActiveCode.Visible = false;
            // 
            // colTypeCrypto
            // 
            this.colTypeCrypto.DataPropertyName = "TypeCrypto";
            this.colTypeCrypto.HeaderText = "TypeCrypto";
            this.colTypeCrypto.Name = "colTypeCrypto";
            this.colTypeCrypto.ReadOnly = true;
            this.colTypeCrypto.Visible = false;
            // 
            // colPrintedStatus
            // 
            this.colPrintedStatus.DataPropertyName = "PrintedStatus";
            this.colPrintedStatus.HeaderText = "Trạng Thái In";
            this.colPrintedStatus.Name = "colPrintedStatus";
            this.colPrintedStatus.ReadOnly = true;
            this.colPrintedStatus.Width = 125;
            // 
            // colPhysicalStatus
            // 
            this.colPhysicalStatus.DataPropertyName = "PhysicalStatus";
            this.colPhysicalStatus.HeaderText = "Trạng Thái Thẻ";
            this.colPhysicalStatus.Name = "colPhysicalStatus";
            this.colPhysicalStatus.ReadOnly = true;
            this.colPhysicalStatus.Width = 125;
            // 
            // colStartDate
            // 
            this.colStartDate.DataPropertyName = "StartDate";
            this.colStartDate.HeaderText = "Ngày Phát Hành";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.ReadOnly = true;
            this.colStartDate.Width = 125;
            // 
            // colExpireDate
            // 
            this.colExpireDate.DataPropertyName = "ExpireDate";
            this.colExpireDate.HeaderText = "Ngày Hết Hạn";
            this.colExpireDate.Name = "colExpireDate";
            this.colExpireDate.ReadOnly = true;
            this.colExpireDate.Width = 125;
            // 
            // colNotes
            // 
            this.colNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNotes.DataPropertyName = "Notes";
            this.colNotes.HeaderText = "Ghi Chú";
            this.colNotes.MinimumWidth = 250;
            this.colNotes.Name = "colNotes";
            this.colNotes.ReadOnly = true;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilterBox.Controls.Add(this.cmbCardPhysicalStatus);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByCardPhysicalStatus);
            this.pnlFilterBox.Controls.Add(this.panel4);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByPrintedStatus);
            this.pnlFilterBox.Controls.Add(this.cmbCardTypes);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByCardType);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(5, 32);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.pnlFilterBox.Size = new System.Drawing.Size(778, 93);
            this.pnlFilterBox.TabIndex = 85;
            // 
            // cmbCardPhysicalStatus
            // 
            this.cmbCardPhysicalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCardPhysicalStatus.Enabled = false;
            this.cmbCardPhysicalStatus.FormattingEnabled = true;
            this.cmbCardPhysicalStatus.Location = new System.Drawing.Point(204, 37);
            this.cmbCardPhysicalStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.cmbCardPhysicalStatus.Name = "cmbCardPhysicalStatus";
            this.cmbCardPhysicalStatus.Size = new System.Drawing.Size(232, 22);
            this.cmbCardPhysicalStatus.TabIndex = 86;
            // 
            // cbxFilterByCardPhysicalStatus
            // 
            this.cbxFilterByCardPhysicalStatus.Location = new System.Drawing.Point(9, 35);
            this.cbxFilterByCardPhysicalStatus.Name = "cbxFilterByCardPhysicalStatus";
            this.cbxFilterByCardPhysicalStatus.Size = new System.Drawing.Size(174, 26);
            this.cbxFilterByCardPhysicalStatus.TabIndex = 85;
            this.cbxFilterByCardPhysicalStatus.Text = "Lọc theo trạng thái thẻ:";
            this.cbxFilterByCardPhysicalStatus.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rbtnStatusNoPrinted);
            this.panel4.Controls.Add(this.rbtnStatusPrinted);
            this.panel4.Location = new System.Drawing.Point(204, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(216, 25);
            this.panel4.TabIndex = 25;
            // 
            // rbtnStatusNoPrinted
            // 
            this.rbtnStatusNoPrinted.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnStatusNoPrinted.Enabled = false;
            this.rbtnStatusNoPrinted.Location = new System.Drawing.Point(118, 0);
            this.rbtnStatusNoPrinted.Name = "rbtnStatusNoPrinted";
            this.rbtnStatusNoPrinted.Size = new System.Drawing.Size(98, 25);
            this.rbtnStatusNoPrinted.TabIndex = 23;
            this.rbtnStatusNoPrinted.Text = "Chưa in";
            this.rbtnStatusNoPrinted.UseVisualStyleBackColor = true;
            // 
            // rbtnStatusPrinted
            // 
            this.rbtnStatusPrinted.Checked = true;
            this.rbtnStatusPrinted.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnStatusPrinted.Enabled = false;
            this.rbtnStatusPrinted.Location = new System.Drawing.Point(0, 0);
            this.rbtnStatusPrinted.Name = "rbtnStatusPrinted";
            this.rbtnStatusPrinted.Size = new System.Drawing.Size(118, 25);
            this.rbtnStatusPrinted.TabIndex = 22;
            this.rbtnStatusPrinted.TabStop = true;
            this.rbtnStatusPrinted.Text = "Đã in";
            this.rbtnStatusPrinted.UseVisualStyleBackColor = true;
            // 
            // cbxFilterByPrintedStatus
            // 
            this.cbxFilterByPrintedStatus.Location = new System.Drawing.Point(9, 61);
            this.cbxFilterByPrintedStatus.Name = "cbxFilterByPrintedStatus";
            this.cbxFilterByPrintedStatus.Size = new System.Drawing.Size(158, 19);
            this.cbxFilterByPrintedStatus.TabIndex = 21;
            this.cbxFilterByPrintedStatus.Text = "Lọc theo trạng thái in ấn:";
            this.cbxFilterByPrintedStatus.UseVisualStyleBackColor = true;
            // 
            // cmbCardTypes
            // 
            this.cmbCardTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCardTypes.Enabled = false;
            this.cmbCardTypes.FormattingEnabled = true;
            this.cmbCardTypes.Location = new System.Drawing.Point(203, 9);
            this.cmbCardTypes.Name = "cmbCardTypes";
            this.cmbCardTypes.Size = new System.Drawing.Size(232, 22);
            this.cmbCardTypes.TabIndex = 17;
            // 
            // cbxFilterByCardType
            // 
            this.cbxFilterByCardType.Location = new System.Drawing.Point(9, 13);
            this.cbxFilterByCardType.Name = "cbxFilterByCardType";
            this.cbxFilterByCardType.Size = new System.Drawing.Size(171, 19);
            this.cbxFilterByCardType.TabIndex = 16;
            this.cbxFilterByCardType.Text = "Lọc theo loại thẻ:";
            this.cbxFilterByCardType.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tmsTeacher);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(5, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(778, 28);
            this.panel3.TabIndex = 84;
            // 
            // tmsTeacher
            // 
            this.tmsTeacher.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowHide,
            this.btnMarkBroken,
            this.btnMarkLost,
            this.btnMarkPrinted,
            this.btnExportExcel,
            this.btnReload});
            this.tmsTeacher.Location = new System.Drawing.Point(0, 0);
            this.tmsTeacher.Name = "tmsTeacher";
            this.tmsTeacher.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.tmsTeacher.Size = new System.Drawing.Size(776, 25);
            this.tmsTeacher.TabIndex = 81;
            this.tmsTeacher.Text = "toolStrip1";
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
            // btnMarkBroken
            // 
            this.btnMarkBroken.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMarkBroken.Image = global::CardMagneticMgtComponent.Properties.Resources.MarkBlue_16x16;
            this.btnMarkBroken.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMarkBroken.Name = "btnMarkBroken";
            this.btnMarkBroken.Size = new System.Drawing.Size(23, 22);
            this.btnMarkBroken.Text = "Đánh dấu hư thẻ...";
            this.btnMarkBroken.Click += new System.EventHandler(this.btnMarkBroken_Click);
            // 
            // btnMarkLost
            // 
            this.btnMarkLost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMarkLost.Image = global::CardMagneticMgtComponent.Properties.Resources.MarkRed_16x16;
            this.btnMarkLost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMarkLost.Name = "btnMarkLost";
            this.btnMarkLost.Size = new System.Drawing.Size(23, 22);
            this.btnMarkLost.Text = "Đánh dấu mất thẻ...";
            this.btnMarkLost.Click += new System.EventHandler(this.btnMarkLost_Click);
            // 
            // btnMarkPrinted
            // 
            this.btnMarkPrinted.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMarkPrinted.Image = global::CardMagneticMgtComponent.Properties.Resources.MarkBlack_16x16;
            this.btnMarkPrinted.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMarkPrinted.Name = "btnMarkPrinted";
            this.btnMarkPrinted.Size = new System.Drawing.Size(23, 22);
            this.btnMarkPrinted.Text = "Đánh dấu thẻ in...";
            this.btnMarkPrinted.Click += new System.EventHandler(this.btnMarkPrinted_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportExcel.Image = global::CardMagneticMgtComponent.Properties.Resources.Excel_16x16;
            this.btnExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExportExcel.Text = "toolStripButton2";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnReload
            // 
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(23, 22);
            this.btnReload.Text = "Tải Dữ Liệu";
            this.btnReload.ToolTipText = "Tải danh sách lượt phát hành";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(5, 533);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(778, 20);
            this.pagerPanel1.TabIndex = 78;
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(5, 35);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(790, 1);
            this.line1.TabIndex = 70;
            this.line1.TabStop = false;
            // 
            // lblRightAreaTitleListCard
            // 
            this.lblRightAreaTitleListCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitleListCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitleListCard.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblRightAreaTitleListCard.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitleListCard.Location = new System.Drawing.Point(5, 5);
            this.lblRightAreaTitleListCard.Name = "lblRightAreaTitleListCard";
            this.lblRightAreaTitleListCard.Size = new System.Drawing.Size(790, 30);
            this.lblRightAreaTitleListCard.TabIndex = 69;
            this.lblRightAreaTitleListCard.Text = "DANH SÁCH THẺ";
            this.lblRightAreaTitleListCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsrListCardMagnetic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.lblRightAreaTitleListCard);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrListCardMagnetic";
            this.Size = new System.Drawing.Size(800, 600);
            this.cmsCardTable.ResumeLayout(false);
            this.tsmCard.ResumeLayout(false);
            this.tsmCard.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCard)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tmsTeacher.ResumeLayout(false);
            this.tmsTeacher.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsCardTable;
        private System.Windows.Forms.ToolStripMenuItem mniMarkBroken;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mniMarkLost;
        private CommonControls.Custom.CommonToolStrip tsmCard;
        private System.Windows.Forms.ToolStripButton btnImportCard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnShowHideFilter;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripButton btnReloadCards;
        private System.Windows.Forms.Panel panel1;
        private CommonControls.Custom.Line line1;
        private CommonControls.Custom.TitleLabel lblRightAreaTitleListCard;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private CommonControls.Custom.CommonToolStrip tmsTeacher;
        private System.Windows.Forms.ToolStripButton btnShowHide;
        private System.Windows.Forms.ToolStripButton btnMarkBroken;
        private System.Windows.Forms.ToolStripButton btnMarkLost;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.ToolStripButton btnExportExcel;
        private System.Windows.Forms.ToolStripButton btnMarkPrinted;
        private System.Windows.Forms.ToolStripMenuItem đánhDấuInThẻToolStripMenuItem;
        private CommonControls.Custom.CommonDataGridView dgvCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMagneticId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgMasterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgPartnerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubOrgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMasterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartnerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrackData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPinCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColActiveCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeCrypto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrintedStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhysicalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotes;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.ComboBox cmbCardPhysicalStatus;
        private System.Windows.Forms.CheckBox cbxFilterByCardPhysicalStatus;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbtnStatusNoPrinted;
        private System.Windows.Forms.RadioButton rbtnStatusPrinted;
        private System.Windows.Forms.CheckBox cbxFilterByPrintedStatus;
        private System.Windows.Forms.ComboBox cmbCardTypes;
        private System.Windows.Forms.CheckBox cbxFilterByCardType;
        private System.Windows.Forms.Panel panel3;

    }
}
