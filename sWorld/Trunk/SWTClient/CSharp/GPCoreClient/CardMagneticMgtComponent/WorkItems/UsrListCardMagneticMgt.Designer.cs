namespace MemberMgtComponent.WorkItems
{
    partial class UsrListCardMagneticMgt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrListCardMagneticMgt));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCardMagneticList = new CommonControls.Custom.CommonDataGridView();
            this.colMagneticId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrgMasterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrgPartnerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssuerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPartnerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSLogicalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.cmsCardTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniImportCard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.xuấtRaExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniReloadCards = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxFilterByCardType = new System.Windows.Forms.CheckBox();
            this.cmbCardTypes = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbtnStatusDeActive = new System.Windows.Forms.RadioButton();
            this.rbtnStatusActive = new System.Windows.Forms.RadioButton();
            this.cbxFilterLogicalStatus = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbPartnerInfo = new System.Windows.Forms.ComboBox();
            this.lblPartnerKey = new System.Windows.Forms.Label();
            this.cmbMasterInfo = new System.Windows.Forms.ComboBox();
            this.lblMasterKey = new System.Windows.Forms.Label();
            this.tsmCard = new CommonControls.Custom.CommonToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHideFilter = new System.Windows.Forms.ToolStripButton();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnReloadCards = new System.Windows.Forms.ToolStripButton();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.lblRightAreaTitleListCard = new CommonControls.Custom.TitleLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardMagneticList)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.cmsCardTable.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tsmCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(2, 33);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Size = new System.Drawing.Size(796, 564);
            this.panel1.TabIndex = 41;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvCardMagneticList);
            this.panel2.Controls.Add(this.pnlFilterBox);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.tsmCard);
            this.panel2.Controls.Add(this.pagerPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(790, 556);
            this.panel2.TabIndex = 38;
            // 
            // dgvCardMagneticList
            // 
            this.dgvCardMagneticList.AllowUserToAddRows = false;
            this.dgvCardMagneticList.AllowUserToDeleteRows = false;
            this.dgvCardMagneticList.AllowUserToOrderColumns = true;
            this.dgvCardMagneticList.AllowUserToResizeRows = false;
            this.dgvCardMagneticList.BackgroundColor = System.Drawing.Color.White;
            this.dgvCardMagneticList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCardMagneticList.ColumnHeadersHeight = 26;
            this.dgvCardMagneticList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMagneticId,
            this.colOrgMasterId,
            this.colOrgPartnerId,
            this.colIssuerCode,
            this.colPartnerCode,
            this.colCardNumber,
            this.colStartDate,
            this.colExpirationDate,
            this.colSLogicalStatus,
            this.colBlank});
            this.dgvCardMagneticList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCardMagneticList.Location = new System.Drawing.Point(0, 133);
            this.dgvCardMagneticList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCardMagneticList.Name = "dgvCardMagneticList";
            this.dgvCardMagneticList.ReadOnly = true;
            this.dgvCardMagneticList.RowHeadersVisible = false;
            this.dgvCardMagneticList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCardMagneticList.Size = new System.Drawing.Size(788, 400);
            this.dgvCardMagneticList.TabIndex = 64;
            // 
            // colMagneticId
            // 
            this.colMagneticId.DataPropertyName = "MagneticId";
            this.colMagneticId.HeaderText = "MagneticId";
            this.colMagneticId.Name = "colMagneticId";
            this.colMagneticId.ReadOnly = true;
            this.colMagneticId.Visible = false;
            // 
            // colOrgMasterId
            // 
            this.colOrgMasterId.DataPropertyName = "OrgMasterId";
            this.colOrgMasterId.HeaderText = "Mã phát hành";
            this.colOrgMasterId.Name = "colOrgMasterId";
            this.colOrgMasterId.ReadOnly = true;
            // 
            // colOrgPartnerId
            // 
            this.colOrgPartnerId.DataPropertyName = "OrgPartnerId";
            this.colOrgPartnerId.HeaderText = "Mã đồng phát hành";
            this.colOrgPartnerId.Name = "colOrgPartnerId";
            this.colOrgPartnerId.ReadOnly = true;
            this.colOrgPartnerId.Width = 150;
            // 
            // colIssuerCode
            // 
            this.colIssuerCode.DataPropertyName = "IssuerCode";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colIssuerCode.DefaultCellStyle = dataGridViewCellStyle4;
            this.colIssuerCode.HeaderText = "Code phát hành";
            this.colIssuerCode.Name = "colIssuerCode";
            this.colIssuerCode.ReadOnly = true;
            this.colIssuerCode.Width = 150;
            // 
            // colPartnerCode
            // 
            this.colPartnerCode.DataPropertyName = "PartnerCode";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPartnerCode.DefaultCellStyle = dataGridViewCellStyle5;
            this.colPartnerCode.HeaderText = "Code đồng phát hành";
            this.colPartnerCode.Name = "colPartnerCode";
            this.colPartnerCode.ReadOnly = true;
            this.colPartnerCode.Width = 150;
            // 
            // colCardNumber
            // 
            this.colCardNumber.DataPropertyName = "CardNumber";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCardNumber.DefaultCellStyle = dataGridViewCellStyle6;
            this.colCardNumber.HeaderText = "Số thẻ";
            this.colCardNumber.Name = "colCardNumber";
            this.colCardNumber.ReadOnly = true;
            this.colCardNumber.Width = 125;
            // 
            // colStartDate
            // 
            this.colStartDate.DataPropertyName = "StartDate";
            this.colStartDate.HeaderText = "Ngày phát hành";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.ReadOnly = true;
            // 
            // colExpirationDate
            // 
            this.colExpirationDate.DataPropertyName = "ExpirationDate";
            this.colExpirationDate.HeaderText = "Ngày hết hạn";
            this.colExpirationDate.Name = "colExpirationDate";
            this.colExpirationDate.ReadOnly = true;
            // 
            // colSLogicalStatus
            // 
            this.colSLogicalStatus.DataPropertyName = "LogicalStatus";
            this.colSLogicalStatus.HeaderText = "Tình trạng";
            this.colSLogicalStatus.Name = "colSLogicalStatus";
            this.colSLogicalStatus.ReadOnly = true;
            // 
            // colBlank
            // 
            this.colBlank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBlank.DataPropertyName = "Blank";
            this.colBlank.HeaderText = "";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.ContextMenuStrip = this.cmsCardTable;
            this.pnlFilterBox.Controls.Add(this.cbxFilterByCardType);
            this.pnlFilterBox.Controls.Add(this.cmbCardTypes);
            this.pnlFilterBox.Controls.Add(this.panel3);
            this.pnlFilterBox.Controls.Add(this.cbxFilterLogicalStatus);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 64);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(788, 69);
            this.pnlFilterBox.TabIndex = 63;
            // 
            // cmsCardTable
            // 
            this.cmsCardTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniImportCard,
            this.toolStripSeparator3,
            this.xuấtRaExcelToolStripMenuItem,
            this.mniReloadCards});
            this.cmsCardTable.Name = "contextMenuStrip1";
            this.cmsCardTable.Size = new System.Drawing.Size(153, 76);
            // 
            // mniImportCard
            // 
            this.mniImportCard.Image = ((System.Drawing.Image)(resources.GetObject("mniImportCard.Image")));
            this.mniImportCard.Name = "mniImportCard";
            this.mniImportCard.Size = new System.Drawing.Size(152, 22);
            this.mniImportCard.Text = "Nhập Khóa...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // xuấtRaExcelToolStripMenuItem
            // 
            this.xuấtRaExcelToolStripMenuItem.Name = "xuấtRaExcelToolStripMenuItem";
            this.xuấtRaExcelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.xuấtRaExcelToolStripMenuItem.Text = "Xuất Ra Excel...";
            // 
            // mniReloadCards
            // 
            this.mniReloadCards.Image = ((System.Drawing.Image)(resources.GetObject("mniReloadCards.Image")));
            this.mniReloadCards.Name = "mniReloadCards";
            this.mniReloadCards.Size = new System.Drawing.Size(152, 22);
            this.mniReloadCards.Text = "Tải Dữ Liệu";
            // 
            // cbxFilterByCardType
            // 
            this.cbxFilterByCardType.Location = new System.Drawing.Point(11, 10);
            this.cbxFilterByCardType.Name = "cbxFilterByCardType";
            this.cbxFilterByCardType.Size = new System.Drawing.Size(126, 20);
            this.cbxFilterByCardType.TabIndex = 17;
            this.cbxFilterByCardType.Text = "Lọc theo loại thẻ:";
            this.cbxFilterByCardType.UseVisualStyleBackColor = true;
            // 
            // cmbCardTypes
            // 
            this.cmbCardTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCardTypes.Enabled = false;
            this.cmbCardTypes.FormattingEnabled = true;
            this.cmbCardTypes.Location = new System.Drawing.Point(214, 8);
            this.cmbCardTypes.Name = "cmbCardTypes";
            this.cmbCardTypes.Size = new System.Drawing.Size(228, 22);
            this.cmbCardTypes.TabIndex = 16;
            this.cmbCardTypes.SelectedIndexChanged += new System.EventHandler(this.cmbCardTypes_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbtnStatusDeActive);
            this.panel3.Controls.Add(this.rbtnStatusActive);
            this.panel3.Location = new System.Drawing.Point(214, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 20);
            this.panel3.TabIndex = 14;
            // 
            // rbtnStatusDeActive
            // 
            this.rbtnStatusDeActive.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnStatusDeActive.Enabled = false;
            this.rbtnStatusDeActive.Location = new System.Drawing.Point(150, 0);
            this.rbtnStatusDeActive.Name = "rbtnStatusDeActive";
            this.rbtnStatusDeActive.Size = new System.Drawing.Size(150, 20);
            this.rbtnStatusDeActive.TabIndex = 2;
            this.rbtnStatusDeActive.Text = "Chưa kích hoạt";
            this.rbtnStatusDeActive.UseVisualStyleBackColor = true;
            // 
            // rbtnStatusActive
            // 
            this.rbtnStatusActive.Checked = true;
            this.rbtnStatusActive.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnStatusActive.Location = new System.Drawing.Point(0, 0);
            this.rbtnStatusActive.Name = "rbtnStatusActive";
            this.rbtnStatusActive.Size = new System.Drawing.Size(150, 20);
            this.rbtnStatusActive.TabIndex = 1;
            this.rbtnStatusActive.TabStop = true;
            this.rbtnStatusActive.Text = "Đã kích hoạt";
            this.rbtnStatusActive.UseVisualStyleBackColor = true;
            // 
            // cbxFilterLogicalStatus
            // 
            this.cbxFilterLogicalStatus.Location = new System.Drawing.Point(11, 42);
            this.cbxFilterLogicalStatus.Name = "cbxFilterLogicalStatus";
            this.cbxFilterLogicalStatus.Size = new System.Drawing.Size(200, 20);
            this.cbxFilterLogicalStatus.TabIndex = 13;
            this.cbxFilterLogicalStatus.Text = "Lọc theo trạng thái:";
            this.cbxFilterLogicalStatus.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.cmbPartnerInfo);
            this.panel5.Controls.Add(this.lblPartnerKey);
            this.panel5.Controls.Add(this.cmbMasterInfo);
            this.panel5.Controls.Add(this.lblMasterKey);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 25);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(788, 39);
            this.panel5.TabIndex = 62;
            // 
            // cmbPartnerInfo
            // 
            this.cmbPartnerInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPartnerInfo.FormattingEnabled = true;
            this.cmbPartnerInfo.Location = new System.Drawing.Point(557, 10);
            this.cmbPartnerInfo.Name = "cmbPartnerInfo";
            this.cmbPartnerInfo.Size = new System.Drawing.Size(228, 22);
            this.cmbPartnerInfo.TabIndex = 10;
            this.cmbPartnerInfo.SelectedIndexChanged += new System.EventHandler(this.cmbPartnerInfo_SelectedIndexChanged);
            // 
            // lblPartnerKey
            // 
            this.lblPartnerKey.AutoSize = true;
            this.lblPartnerKey.Location = new System.Drawing.Point(369, 13);
            this.lblPartnerKey.Name = "lblPartnerKey";
            this.lblPartnerKey.Size = new System.Drawing.Size(182, 14);
            this.lblPartnerKey.TabIndex = 9;
            this.lblPartnerKey.Text = "Chọn tổ chức  đồng phát hành:";
            // 
            // cmbMasterInfo
            // 
            this.cmbMasterInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMasterInfo.Enabled = false;
            this.cmbMasterInfo.FormattingEnabled = true;
            this.cmbMasterInfo.Location = new System.Drawing.Point(157, 10);
            this.cmbMasterInfo.Name = "cmbMasterInfo";
            this.cmbMasterInfo.Size = new System.Drawing.Size(206, 22);
            this.cmbMasterInfo.TabIndex = 8;
            this.cmbMasterInfo.SelectedIndexChanged += new System.EventHandler(this.cmbMasterInfo_SelectedIndexChanged);
            // 
            // lblMasterKey
            // 
            this.lblMasterKey.AutoSize = true;
            this.lblMasterKey.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterKey.Location = new System.Drawing.Point(5, 13);
            this.lblMasterKey.Name = "lblMasterKey";
            this.lblMasterKey.Size = new System.Drawing.Size(146, 14);
            this.lblMasterKey.TabIndex = 7;
            this.lblMasterKey.Text = "Chọn tổ chức phát hành:";
            // 
            // tsmCard
            // 
            this.tsmCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnShowHideFilter,
            this.btnExportToExcel,
            this.btnReloadCards});
            this.tsmCard.Location = new System.Drawing.Point(0, 0);
            this.tsmCard.Name = "tsmCard";
            this.tsmCard.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsmCard.Size = new System.Drawing.Size(788, 25);
            this.tsmCard.TabIndex = 61;
            this.tsmCard.Text = "tlstripListUser";
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
            this.btnExportToExcel.Image = global::MemberMgtComponent.Properties.Resources.Excel_16x16;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExportToExcel.Text = "Xuất Ra Excel...";
            this.btnExportToExcel.ToolTipText = "Xuất dữ liệu đang hiển thị ra tập tin excel";
            // 
            // btnReloadCards
            // 
            this.btnReloadCards.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadCards.Image = global::MemberMgtComponent.Properties.Resources.Refresh_16x16;
            this.btnReloadCards.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadCards.Name = "btnReloadCards";
            this.btnReloadCards.Size = new System.Drawing.Size(23, 22);
            this.btnReloadCards.Text = "Tải Dữ Liệu";
            this.btnReloadCards.ToolTipText = "Tải danh sách lượt phát hành";
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 533);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(788, 21);
            this.pagerPanel1.TabIndex = 40;
            // 
            // lblRightAreaTitleListCard
            // 
            this.lblRightAreaTitleListCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitleListCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitleListCard.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblRightAreaTitleListCard.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitleListCard.Location = new System.Drawing.Point(2, 3);
            this.lblRightAreaTitleListCard.Name = "lblRightAreaTitleListCard";
            this.lblRightAreaTitleListCard.Size = new System.Drawing.Size(796, 30);
            this.lblRightAreaTitleListCard.TabIndex = 40;
            this.lblRightAreaTitleListCard.Text = "DANH SÁCH THẺ TỪ";
            this.lblRightAreaTitleListCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsrListCardMagneticMgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblRightAreaTitleListCard);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrListCardMagneticMgt";
            this.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Size = new System.Drawing.Size(800, 600);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardMagneticList)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.cmsCardTable.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tsmCard.ResumeLayout(false);
            this.tsmCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip cmsCardTable;
        private System.Windows.Forms.ToolStripMenuItem mniImportCard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem xuấtRaExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniReloadCards;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private CommonControls.Custom.TitleLabel lblRightAreaTitleListCard;
        private CommonControls.Custom.CommonToolStrip tsmCard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnShowHideFilter;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripButton btnReloadCards;
        private CommonControls.Custom.CommonDataGridView dgvCardMagneticList;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.ComboBox cmbCardTypes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbtnStatusDeActive;
        private System.Windows.Forms.RadioButton rbtnStatusActive;
        private System.Windows.Forms.CheckBox cbxFilterLogicalStatus;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cmbPartnerInfo;
        private System.Windows.Forms.Label lblPartnerKey;
        private System.Windows.Forms.ComboBox cmbMasterInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMagneticId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgMasterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgPartnerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssuerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartnerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpirationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSLogicalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
        private System.Windows.Forms.CheckBox cbxFilterByCardType;
        private System.Windows.Forms.Label lblMasterKey;

    }
}
