namespace SystemMgtComponent.WorkItems.ExportDataCard
{
    partial class UsrExportDataCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrExportDataCard));
            this.pagerPanel = new CommonControls.Custom.PagerPanel();
            this.tmsMember = new CommonControls.Custom.CommonToolStrip();
            this.btnExportCard = new System.Windows.Forms.ToolStripButton();
            this.dtpPersoDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblDayend = new System.Windows.Forms.Label();
            this.lblToday = new System.Windows.Forms.Label();
            this.dtpPersoDateFrom = new System.Windows.Forms.DateTimePicker();
            this.cbxFilterByExportDate = new System.Windows.Forms.CheckBox();
            this.lblNotification4 = new System.Windows.Forms.Label();
            this.tbxCardType = new System.Windows.Forms.TextBox();
            this.cbxFilterByMemberName = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblListCardChipExport = new CommonControls.Custom.TitleLabel();
            this.dgvCardExport = new CommonControls.Custom.CommonDataGridView();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateExport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlRightMain = new System.Windows.Forms.Panel();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.numbercardCanExport = new System.Windows.Forms.Label();
            this.numbercardExport = new System.Windows.Forms.Label();
            this.numberCard = new System.Windows.Forms.Label();
            this.lblNumberCardCanExport = new System.Windows.Forms.Label();
            this.lblNumberCardExport = new System.Windows.Forms.Label();
            this.lblNumberCard = new System.Windows.Forms.Label();
            this.lblNotification3 = new System.Windows.Forms.Label();
            this.tbxSerialCard = new System.Windows.Forms.TextBox();
            this.lblFilterbyserial = new System.Windows.Forms.CheckBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblLeftAreaTitleforListOrg = new CommonControls.Custom.TitleLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.trvMaster = new System.Windows.Forms.TreeView();
            this.tsmOrg = new CommonControls.Custom.CommonToolStrip();
            this.btnReloadOrgAcquirer = new System.Windows.Forms.ToolStripButton();
            this.tmsMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardExport)).BeginInit();
            this.pnlRightMain.SuspendLayout();
            this.pnlFilterBox.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tsmOrg.SuspendLayout();
            this.SuspendLayout();
            // 
            // pagerPanel
            // 
            this.pagerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel.Location = new System.Drawing.Point(0, 479);
            this.pagerPanel.Name = "pagerPanel";
            this.pagerPanel.Size = new System.Drawing.Size(811, 22);
            this.pagerPanel.TabIndex = 25;
            // 
            // tmsMember
            // 
            this.tmsMember.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportCard});
            this.tmsMember.Location = new System.Drawing.Point(0, 0);
            this.tmsMember.Name = "tmsMember";
            this.tmsMember.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.tmsMember.Size = new System.Drawing.Size(811, 25);
            this.tmsMember.TabIndex = 22;
            this.tmsMember.Text = "toolStrip1";
            // 
            // btnExportCard
            // 
            this.btnExportCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportCard.Image = ((System.Drawing.Image)(resources.GetObject("btnExportCard.Image")));
            this.btnExportCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportCard.Name = "btnExportCard";
            this.btnExportCard.Size = new System.Drawing.Size(23, 22);
            this.btnExportCard.Text = "Xuất dữ liệu";
            this.btnExportCard.ToolTipText = "Xuất dữ liệu thẻ";
            // 
            // dtpPersoDateTo
            // 
            this.dtpPersoDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpPersoDateTo.Enabled = false;
            this.dtpPersoDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPersoDateTo.Location = new System.Drawing.Point(476, 156);
            this.dtpPersoDateTo.Name = "dtpPersoDateTo";
            this.dtpPersoDateTo.Size = new System.Drawing.Size(137, 22);
            this.dtpPersoDateTo.TabIndex = 75;
            // 
            // lblDayend
            // 
            this.lblDayend.AutoSize = true;
            this.lblDayend.Location = new System.Drawing.Point(434, 163);
            this.lblDayend.Name = "lblDayend";
            this.lblDayend.Size = new System.Drawing.Size(36, 16);
            this.lblDayend.TabIndex = 74;
            this.lblDayend.Text = "Đến:";
            // 
            // lblToday
            // 
            this.lblToday.AutoSize = true;
            this.lblToday.Location = new System.Drawing.Point(248, 163);
            this.lblToday.Name = "lblToday";
            this.lblToday.Size = new System.Drawing.Size(29, 16);
            this.lblToday.TabIndex = 73;
            this.lblToday.Text = "Từ:";
            // 
            // dtpPersoDateFrom
            // 
            this.dtpPersoDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpPersoDateFrom.Enabled = false;
            this.dtpPersoDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPersoDateFrom.Location = new System.Drawing.Point(289, 156);
            this.dtpPersoDateFrom.Name = "dtpPersoDateFrom";
            this.dtpPersoDateFrom.Size = new System.Drawing.Size(137, 22);
            this.dtpPersoDateFrom.TabIndex = 72;
            // 
            // cbxFilterByExportDate
            // 
            this.cbxFilterByExportDate.Location = new System.Drawing.Point(12, 156);
            this.cbxFilterByExportDate.Name = "cbxFilterByExportDate";
            this.cbxFilterByExportDate.Size = new System.Drawing.Size(233, 24);
            this.cbxFilterByExportDate.TabIndex = 71;
            this.cbxFilterByExportDate.Text = "Lọc theo ngày xuất:";
            this.cbxFilterByExportDate.UseVisualStyleBackColor = true;
            this.cbxFilterByExportDate.CheckedChanged += new System.EventHandler(this.cbxFilterByExportDate_CheckedChanged);
            // 
            // lblNotification4
            // 
            this.lblNotification4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNotification4.Location = new System.Drawing.Point(434, 125);
            this.lblNotification4.Name = "lblNotification4";
            this.lblNotification4.Size = new System.Drawing.Size(175, 24);
            this.lblNotification4.TabIndex = 68;
            this.lblNotification4.Text = "Vui lòng nhập ít nhất 2 ký tự";
            this.lblNotification4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotification4.Visible = false;
            // 
            // tbxCardType
            // 
            this.tbxCardType.Enabled = false;
            this.tbxCardType.Location = new System.Drawing.Point(252, 125);
            this.tbxCardType.Name = "tbxCardType";
            this.tbxCardType.Size = new System.Drawing.Size(174, 22);
            this.tbxCardType.TabIndex = 65;
            // 
            // cbxFilterByMemberName
            // 
            this.cbxFilterByMemberName.Location = new System.Drawing.Point(12, 125);
            this.cbxFilterByMemberName.Name = "cbxFilterByMemberName";
            this.cbxFilterByMemberName.Size = new System.Drawing.Size(233, 24);
            this.cbxFilterByMemberName.TabIndex = 64;
            this.cbxFilterByMemberName.Text = "Lọc theo loại thẻ:";
            this.cbxFilterByMemberName.UseVisualStyleBackColor = true;
            this.cbxFilterByMemberName.CheckedChanged += new System.EventHandler(this.cbxFilterByMemberName_CheckedChanged);
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 32);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(825, 4);
            this.panel7.TabIndex = 17;
            // 
            // lblListCardChipExport
            // 
            this.lblListCardChipExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblListCardChipExport.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListCardChipExport.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblListCardChipExport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblListCardChipExport.Location = new System.Drawing.Point(0, 0);
            this.lblListCardChipExport.Name = "lblListCardChipExport";
            this.lblListCardChipExport.Size = new System.Drawing.Size(825, 32);
            this.lblListCardChipExport.TabIndex = 16;
            this.lblListCardChipExport.Text = "DANH SÁCH THẺ CHIP ĐÃ XUẤT";
            this.lblListCardChipExport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvCardExport
            // 
            this.dgvCardExport.AllowUserToAddRows = false;
            this.dgvCardExport.AllowUserToDeleteRows = false;
            this.dgvCardExport.AllowUserToOrderColumns = true;
            this.dgvCardExport.AllowUserToResizeRows = false;
            this.dgvCardExport.BackgroundColor = System.Drawing.Color.White;
            this.dgvCardExport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCardExport.ColumnHeadersHeight = 26;
            this.dgvCardExport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.colSerial,
            this.colCardType,
            this.colDateExport});
            this.dgvCardExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCardExport.Location = new System.Drawing.Point(0, 218);
            this.dgvCardExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCardExport.Name = "dgvCardExport";
            this.dgvCardExport.ReadOnly = true;
            this.dgvCardExport.RowHeadersVisible = false;
            this.dgvCardExport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCardExport.Size = new System.Drawing.Size(811, 261);
            this.dgvCardExport.TabIndex = 31;
            // 
            // colIndex
            // 
            this.colIndex.DataPropertyName = "colIndex";
            this.colIndex.HeaderText = "STT";
            this.colIndex.Name = "colIndex";
            this.colIndex.ReadOnly = true;
            // 
            // colSerial
            // 
            this.colSerial.DataPropertyName = "colSerial";
            this.colSerial.HeaderText = "Mã thẻ";
            this.colSerial.Name = "colSerial";
            this.colSerial.ReadOnly = true;
            // 
            // colCardType
            // 
            this.colCardType.DataPropertyName = "colCardType";
            this.colCardType.HeaderText = "Loại thẻ";
            this.colCardType.Name = "colCardType";
            this.colCardType.ReadOnly = true;
            // 
            // colDateExport
            // 
            this.colDateExport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDateExport.DataPropertyName = "colDateExport";
            this.colDateExport.HeaderText = "Ngày xuất dữ liệu";
            this.colDateExport.Name = "colDateExport";
            this.colDateExport.ReadOnly = true;
            // 
            // pnlRightMain
            // 
            this.pnlRightMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRightMain.Controls.Add(this.dgvCardExport);
            this.pnlRightMain.Controls.Add(this.pnlFilterBox);
            this.pnlRightMain.Controls.Add(this.pagerPanel);
            this.pnlRightMain.Controls.Add(this.tmsMember);
            this.pnlRightMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightMain.Location = new System.Drawing.Point(6, 0);
            this.pnlRightMain.Name = "pnlRightMain";
            this.pnlRightMain.Size = new System.Drawing.Size(813, 503);
            this.pnlRightMain.TabIndex = 14;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.Controls.Add(this.numbercardCanExport);
            this.pnlFilterBox.Controls.Add(this.numbercardExport);
            this.pnlFilterBox.Controls.Add(this.numberCard);
            this.pnlFilterBox.Controls.Add(this.lblNumberCardCanExport);
            this.pnlFilterBox.Controls.Add(this.lblNumberCardExport);
            this.pnlFilterBox.Controls.Add(this.lblNumberCard);
            this.pnlFilterBox.Controls.Add(this.lblNotification3);
            this.pnlFilterBox.Controls.Add(this.tbxSerialCard);
            this.pnlFilterBox.Controls.Add(this.lblFilterbyserial);
            this.pnlFilterBox.Controls.Add(this.dtpPersoDateTo);
            this.pnlFilterBox.Controls.Add(this.lblDayend);
            this.pnlFilterBox.Controls.Add(this.lblToday);
            this.pnlFilterBox.Controls.Add(this.dtpPersoDateFrom);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByExportDate);
            this.pnlFilterBox.Controls.Add(this.lblNotification4);
            this.pnlFilterBox.Controls.Add(this.tbxCardType);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByMemberName);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlFilterBox.Size = new System.Drawing.Size(811, 193);
            this.pnlFilterBox.TabIndex = 29;
            // 
            // numbercardCanExport
            // 
            this.numbercardCanExport.AutoSize = true;
            this.numbercardCanExport.Location = new System.Drawing.Point(171, 73);
            this.numbercardCanExport.Name = "numbercardCanExport";
            this.numbercardCanExport.Size = new System.Drawing.Size(15, 16);
            this.numbercardCanExport.TabIndex = 88;
            this.numbercardCanExport.Text = "0";
            // 
            // numbercardExport
            // 
            this.numbercardExport.AutoSize = true;
            this.numbercardExport.Location = new System.Drawing.Point(149, 44);
            this.numbercardExport.Name = "numbercardExport";
            this.numbercardExport.Size = new System.Drawing.Size(15, 16);
            this.numbercardExport.TabIndex = 87;
            this.numbercardExport.Text = "0";
            // 
            // numberCard
            // 
            this.numberCard.AutoSize = true;
            this.numberCard.Location = new System.Drawing.Point(207, 19);
            this.numberCard.Name = "numberCard";
            this.numberCard.Size = new System.Drawing.Size(15, 16);
            this.numberCard.TabIndex = 86;
            this.numberCard.Text = "0";
            // 
            // lblNumberCardCanExport
            // 
            this.lblNumberCardCanExport.AutoSize = true;
            this.lblNumberCardCanExport.Location = new System.Drawing.Point(9, 73);
            this.lblNumberCardCanExport.Name = "lblNumberCardCanExport";
            this.lblNumberCardCanExport.Size = new System.Drawing.Size(165, 16);
            this.lblNumberCardCanExport.TabIndex = 85;
            this.lblNumberCardCanExport.Text = "+ Số lượng thẻ có thể xuất:";
            // 
            // lblNumberCardExport
            // 
            this.lblNumberCardExport.AutoSize = true;
            this.lblNumberCardExport.Location = new System.Drawing.Point(9, 44);
            this.lblNumberCardExport.Name = "lblNumberCardExport";
            this.lblNumberCardExport.Size = new System.Drawing.Size(144, 16);
            this.lblNumberCardExport.TabIndex = 84;
            this.lblNumberCardExport.Text = "+ Số lượng thẻ đã xuất:";
            // 
            // lblNumberCard
            // 
            this.lblNumberCard.AutoSize = true;
            this.lblNumberCard.Location = new System.Drawing.Point(9, 19);
            this.lblNumberCard.Name = "lblNumberCard";
            this.lblNumberCard.Size = new System.Drawing.Size(203, 16);
            this.lblNumberCard.TabIndex = 83;
            this.lblNumberCard.Text = "+ Số lượng thẻ có trong hệ thống:";
            // 
            // lblNotification3
            // 
            this.lblNotification3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNotification3.Location = new System.Drawing.Point(434, 95);
            this.lblNotification3.Name = "lblNotification3";
            this.lblNotification3.Size = new System.Drawing.Size(175, 24);
            this.lblNotification3.TabIndex = 82;
            this.lblNotification3.Text = "Vui lòng nhập ít nhất 2 ký tự";
            this.lblNotification3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotification3.Visible = false;
            // 
            // tbxSerialCard
            // 
            this.tbxSerialCard.Enabled = false;
            this.tbxSerialCard.Location = new System.Drawing.Point(252, 95);
            this.tbxSerialCard.Name = "tbxSerialCard";
            this.tbxSerialCard.Size = new System.Drawing.Size(174, 22);
            this.tbxSerialCard.TabIndex = 81;
            // 
            // lblFilterbyserial
            // 
            this.lblFilterbyserial.Location = new System.Drawing.Point(12, 95);
            this.lblFilterbyserial.Name = "lblFilterbyserial";
            this.lblFilterbyserial.Size = new System.Drawing.Size(233, 24);
            this.lblFilterbyserial.TabIndex = 80;
            this.lblFilterbyserial.Text = "Lọc theo mã thẻ:";
            this.lblFilterbyserial.UseVisualStyleBackColor = true;
            this.lblFilterbyserial.CheckedChanged += new System.EventHandler(this.lblFilterbyserial_CheckedChanged);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.pnlRightMain);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 36);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(6, 0, 6, 5);
            this.panel8.Size = new System.Drawing.Size(825, 508);
            this.panel8.TabIndex = 18;
            // 
            // lblLeftAreaTitleforListOrg
            // 
            this.lblLeftAreaTitleforListOrg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblLeftAreaTitleforListOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftAreaTitleforListOrg.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblLeftAreaTitleforListOrg.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLeftAreaTitleforListOrg.Location = new System.Drawing.Point(0, 0);
            this.lblLeftAreaTitleforListOrg.Name = "lblLeftAreaTitleforListOrg";
            this.lblLeftAreaTitleforListOrg.Size = new System.Drawing.Size(261, 32);
            this.lblLeftAreaTitleforListOrg.TabIndex = 2;
            this.lblLeftAreaTitleforListOrg.Text = "DANH SÁCH TỔ CHỨC";
            this.lblLeftAreaTitleforListOrg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(6, 5);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panel1);
            this.splitContainer.Panel1.Controls.Add(this.lblLeftAreaTitleforListOrg);
            this.splitContainer.Panel1MinSize = 150;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel8);
            this.splitContainer.Panel2.Controls.Add(this.panel7);
            this.splitContainer.Panel2.Controls.Add(this.lblListCardChipExport);
            this.splitContainer.Size = new System.Drawing.Size(1096, 546);
            this.splitContainer.SplitterDistance = 263;
            this.splitContainer.SplitterWidth = 6;
            this.splitContainer.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Size = new System.Drawing.Size(261, 512);
            this.panel1.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.trvMaster);
            this.panel4.Controls.Add(this.tsmOrg);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(6, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(249, 502);
            this.panel4.TabIndex = 57;
            // 
            // trvMaster
            // 
            this.trvMaster.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvMaster.Location = new System.Drawing.Point(0, 25);
            this.trvMaster.Name = "trvMaster";
            this.trvMaster.Size = new System.Drawing.Size(247, 475);
            this.trvMaster.TabIndex = 57;
            // 
            // tsmOrg
            // 
            this.tsmOrg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReloadOrgAcquirer});
            this.tsmOrg.Location = new System.Drawing.Point(0, 0);
            this.tsmOrg.Name = "tsmOrg";
            this.tsmOrg.Size = new System.Drawing.Size(247, 25);
            this.tsmOrg.TabIndex = 56;
            this.tsmOrg.Text = "tlstripListGroup";
            // 
            // btnReloadOrgAcquirer
            // 
            this.btnReloadOrgAcquirer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadOrgAcquirer.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadOrgAcquirer.Image")));
            this.btnReloadOrgAcquirer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadOrgAcquirer.Name = "btnReloadOrgAcquirer";
            this.btnReloadOrgAcquirer.Size = new System.Drawing.Size(23, 22);
            this.btnReloadOrgAcquirer.Text = "Tải Dữ Liệu";
            this.btnReloadOrgAcquirer.ToolTipText = "Tải danh sách tổ chức liên kết";
            // 
            // UsrExportDataCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "UsrExportDataCard";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Size = new System.Drawing.Size(1108, 556);
            this.tmsMember.ResumeLayout(false);
            this.tmsMember.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardExport)).EndInit();
            this.pnlRightMain.ResumeLayout(false);
            this.pnlRightMain.PerformLayout();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tsmOrg.ResumeLayout(false);
            this.tsmOrg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripButton btnExportCard;
        private CommonControls.Custom.PagerPanel pagerPanel;
        private CommonControls.Custom.CommonToolStrip tmsMember;
        private System.Windows.Forms.DateTimePicker dtpPersoDateTo;
        private System.Windows.Forms.Label lblDayend;
        private System.Windows.Forms.Label lblToday;
        private System.Windows.Forms.DateTimePicker dtpPersoDateFrom;
        private System.Windows.Forms.CheckBox cbxFilterByExportDate;
        private System.Windows.Forms.Label lblNotification4;
        private System.Windows.Forms.TextBox tbxCardType;
        private System.Windows.Forms.CheckBox cbxFilterByMemberName;
        private System.Windows.Forms.Panel panel7;
        private CommonControls.Custom.TitleLabel lblListCardChipExport;
        private CommonControls.Custom.CommonDataGridView dgvCardExport;
        private System.Windows.Forms.Panel pnlRightMain;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Label lblNotification3;
        private System.Windows.Forms.TextBox tbxSerialCard;
        private System.Windows.Forms.CheckBox lblFilterbyserial;
        private System.Windows.Forms.Panel panel8;
        private CommonControls.Custom.TitleLabel lblLeftAreaTitleforListOrg;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TreeView trvMaster;
        private CommonControls.Custom.CommonToolStrip tsmOrg;
        private System.Windows.Forms.ToolStripButton btnReloadOrgAcquirer;
        private System.Windows.Forms.Label lblNumberCard;
        private System.Windows.Forms.Label lblNumberCardCanExport;
        private System.Windows.Forms.Label lblNumberCardExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateExport;
        private System.Windows.Forms.Label numbercardCanExport;
        private System.Windows.Forms.Label numbercardExport;
        private System.Windows.Forms.Label numberCard;
    }
}
