namespace CardChipMgtComponent.WorkItems
{
    partial class UsrCardMgtMain
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrCardMgtMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsCardTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniImportCard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mniExportExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniReloadCards = new System.Windows.Forms.ToolStripMenuItem();
            this.miniToolStrip = new CommonControls.Custom.CommonToolStrip();
            this.lblRightAreaTitleListCard = new CommonControls.Custom.TitleLabel();
            this.line1 = new CommonControls.Custom.Line();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.line2 = new CommonControls.Custom.Line();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImportCard = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHideFilter = new System.Windows.Forms.ToolStripButton();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnReloadCards = new System.Windows.Forms.ToolStripButton();
            this.tsmCard = new CommonControls.Custom.CommonToolStrip();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbtnStatusNormal = new System.Windows.Forms.RadioButton();
            this.rbtnStatusBroken = new System.Windows.Forms.RadioButton();
            this.rbtnStatusLost = new System.Windows.Forms.RadioButton();
            this.cbxFilterByCardType = new System.Windows.Forms.CheckBox();
            this.cmbCardTypes = new System.Windows.Forms.ComboBox();
            this.cbxFilterByPhysicalStt = new System.Windows.Forms.CheckBox();
            this.cbxFilterByPersoStatus = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbtnStatusNotPerso = new System.Windows.Forms.RadioButton();
            this.rbtnStatusPerso = new System.Windows.Forms.RadioButton();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImportedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSttLost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSttBroken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSttPersonalized = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCardList = new CommonControls.Custom.CommonDataGridView();
            this.cmsCardTable.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tsmCard.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlFilterBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).BeginInit();
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
            // mniExportExcelToolStripMenuItem
            // 
            this.mniExportExcelToolStripMenuItem.Image = global::CardChipMgtComponent.Properties.Resources.Excel_16x16;
            this.mniExportExcelToolStripMenuItem.Name = "mniExportExcelToolStripMenuItem";
            this.mniExportExcelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mniExportExcelToolStripMenuItem.Text = "Xuất Ra Excel...";
            this.mniExportExcelToolStripMenuItem.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // mniReloadCards
            // 
            this.mniReloadCards.Image = ((System.Drawing.Image)(resources.GetObject("mniReloadCards.Image")));
            this.mniReloadCards.Name = "mniReloadCards";
            this.mniReloadCards.Size = new System.Drawing.Size(152, 22);
            this.mniReloadCards.Text = "Tải Dữ Liệu";
            this.mniReloadCards.Click += new System.EventHandler(this.btnRefreshCardList_Clicked);
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(82, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.miniToolStrip.Size = new System.Drawing.Size(571, 25);
            this.miniToolStrip.TabIndex = 38;
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
            this.lblRightAreaTitleListCard.TabIndex = 63;
            this.lblRightAreaTitleListCard.Text = "DANH SÁCH THẺ";
            this.lblRightAreaTitleListCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(5, 35);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(790, 1);
            this.line1.TabIndex = 64;
            this.line1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 36);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Size = new System.Drawing.Size(790, 559);
            this.panel1.TabIndex = 67;
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 527);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(776, 20);
            this.pagerPanel1.TabIndex = 40;
            // 
            // line2
            // 
            this.line2.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line2.Dock = System.Windows.Forms.DockStyle.Top;
            this.line2.Location = new System.Drawing.Point(0, 0);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(776, 1);
            this.line2.TabIndex = 77;
            this.line2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvCardList);
            this.panel2.Controls.Add(this.pnlFilterBox);
            this.panel2.Controls.Add(this.tsmCard);
            this.panel2.Controls.Add(this.line2);
            this.panel2.Controls.Add(this.pagerPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(778, 549);
            this.panel2.TabIndex = 38;
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
            this.btnImportCard.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator1.Visible = false;
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
            this.btnExportToExcel.Image = global::CardChipMgtComponent.Properties.Resources.Excel_16x16;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExportToExcel.Text = "Xuất Ra Excel...";
            this.btnExportToExcel.ToolTipText = "Xuất dữ liệu đang hiển thị ra tập tin excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnReloadCards
            // 
            this.btnReloadCards.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadCards.Image = global::CardChipMgtComponent.Properties.Resources.Refresh_16x16;
            this.btnReloadCards.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadCards.Name = "btnReloadCards";
            this.btnReloadCards.Size = new System.Drawing.Size(23, 22);
            this.btnReloadCards.Text = "Tải Dữ Liệu";
            this.btnReloadCards.ToolTipText = "Tải danh sách lượt phát hành";
            // 
            // tsmCard
            // 
            this.tsmCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImportCard,
            this.toolStripSeparator1,
            this.btnShowHideFilter,
            this.btnExportToExcel,
            this.btnReloadCards});
            this.tsmCard.Location = new System.Drawing.Point(0, 1);
            this.tsmCard.Name = "tsmCard";
            this.tsmCard.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsmCard.Size = new System.Drawing.Size(776, 25);
            this.tsmCard.TabIndex = 78;
            this.tsmCard.Text = "tlstripListUser";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rbtnStatusLost);
            this.panel4.Controls.Add(this.rbtnStatusBroken);
            this.panel4.Controls.Add(this.rbtnStatusNormal);
            this.panel4.Location = new System.Drawing.Point(214, 35);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(450, 20);
            this.panel4.TabIndex = 9;
            // 
            // rbtnStatusNormal
            // 
            this.rbtnStatusNormal.Checked = true;
            this.rbtnStatusNormal.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnStatusNormal.Enabled = false;
            this.rbtnStatusNormal.Location = new System.Drawing.Point(0, 0);
            this.rbtnStatusNormal.Name = "rbtnStatusNormal";
            this.rbtnStatusNormal.Size = new System.Drawing.Size(150, 20);
            this.rbtnStatusNormal.TabIndex = 1;
            this.rbtnStatusNormal.TabStop = true;
            this.rbtnStatusNormal.Text = "Bình thường";
            this.rbtnStatusNormal.UseVisualStyleBackColor = true;
            // 
            // rbtnStatusBroken
            // 
            this.rbtnStatusBroken.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnStatusBroken.Enabled = false;
            this.rbtnStatusBroken.Location = new System.Drawing.Point(150, 0);
            this.rbtnStatusBroken.Name = "rbtnStatusBroken";
            this.rbtnStatusBroken.Size = new System.Drawing.Size(150, 20);
            this.rbtnStatusBroken.TabIndex = 3;
            this.rbtnStatusBroken.Text = "Đã bị hư";
            this.rbtnStatusBroken.UseVisualStyleBackColor = true;
            // 
            // rbtnStatusLost
            // 
            this.rbtnStatusLost.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnStatusLost.Enabled = false;
            this.rbtnStatusLost.Location = new System.Drawing.Point(300, 0);
            this.rbtnStatusLost.Name = "rbtnStatusLost";
            this.rbtnStatusLost.Size = new System.Drawing.Size(150, 20);
            this.rbtnStatusLost.TabIndex = 4;
            this.rbtnStatusLost.Text = "Đã bị mất";
            this.rbtnStatusLost.UseVisualStyleBackColor = true;
            // 
            // cbxFilterByCardType
            // 
            this.cbxFilterByCardType.Location = new System.Drawing.Point(8, 8);
            this.cbxFilterByCardType.Name = "cbxFilterByCardType";
            this.cbxFilterByCardType.Size = new System.Drawing.Size(200, 20);
            this.cbxFilterByCardType.TabIndex = 10;
            this.cbxFilterByCardType.Text = "Lọc theo loại thẻ:";
            this.cbxFilterByCardType.UseVisualStyleBackColor = true;
            // 
            // cmbCardTypes
            // 
            this.cmbCardTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCardTypes.Enabled = false;
            this.cmbCardTypes.FormattingEnabled = true;
            this.cmbCardTypes.Location = new System.Drawing.Point(214, 7);
            this.cmbCardTypes.Name = "cmbCardTypes";
            this.cmbCardTypes.Size = new System.Drawing.Size(200, 22);
            this.cmbCardTypes.TabIndex = 11;
            // 
            // cbxFilterByPhysicalStt
            // 
            this.cbxFilterByPhysicalStt.Location = new System.Drawing.Point(8, 35);
            this.cbxFilterByPhysicalStt.Name = "cbxFilterByPhysicalStt";
            this.cbxFilterByPhysicalStt.Size = new System.Drawing.Size(200, 20);
            this.cbxFilterByPhysicalStt.TabIndex = 5;
            this.cbxFilterByPhysicalStt.Text = "Lọc theo trạng thái vật lý:";
            this.cbxFilterByPhysicalStt.UseVisualStyleBackColor = true;
            // 
            // cbxFilterByPersoStatus
            // 
            this.cbxFilterByPersoStatus.Location = new System.Drawing.Point(8, 61);
            this.cbxFilterByPersoStatus.Name = "cbxFilterByPersoStatus";
            this.cbxFilterByPersoStatus.Size = new System.Drawing.Size(200, 20);
            this.cbxFilterByPersoStatus.TabIndex = 13;
            this.cbxFilterByPersoStatus.Text = "Lọc theo trạng thái phát hành:";
            this.cbxFilterByPersoStatus.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbtnStatusPerso);
            this.panel3.Controls.Add(this.rbtnStatusNotPerso);
            this.panel3.Location = new System.Drawing.Point(214, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 20);
            this.panel3.TabIndex = 14;
            // 
            // rbtnStatusNotPerso
            // 
            this.rbtnStatusNotPerso.Checked = true;
            this.rbtnStatusNotPerso.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnStatusNotPerso.Enabled = false;
            this.rbtnStatusNotPerso.Location = new System.Drawing.Point(0, 0);
            this.rbtnStatusNotPerso.Name = "rbtnStatusNotPerso";
            this.rbtnStatusNotPerso.Size = new System.Drawing.Size(150, 20);
            this.rbtnStatusNotPerso.TabIndex = 1;
            this.rbtnStatusNotPerso.TabStop = true;
            this.rbtnStatusNotPerso.Text = "Chưa phát hành";
            this.rbtnStatusNotPerso.UseVisualStyleBackColor = true;
            // 
            // rbtnStatusPerso
            // 
            this.rbtnStatusPerso.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnStatusPerso.Enabled = false;
            this.rbtnStatusPerso.Location = new System.Drawing.Point(150, 0);
            this.rbtnStatusPerso.Name = "rbtnStatusPerso";
            this.rbtnStatusPerso.Size = new System.Drawing.Size(150, 20);
            this.rbtnStatusPerso.TabIndex = 2;
            this.rbtnStatusPerso.Text = "Đã phát hành";
            this.rbtnStatusPerso.UseVisualStyleBackColor = true;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilterBox.ContextMenuStrip = this.cmsCardTable;
            this.pnlFilterBox.Controls.Add(this.panel3);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByPersoStatus);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByPhysicalStt);
            this.pnlFilterBox.Controls.Add(this.cmbCardTypes);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByCardType);
            this.pnlFilterBox.Controls.Add(this.panel4);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 26);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(776, 91);
            this.pnlFilterBox.TabIndex = 79;
            // 
            // colBlank
            // 
            this.colBlank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBlank.DataPropertyName = "Blank";
            this.colBlank.HeaderText = "";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            // 
            // colImportedOn
            // 
            this.colImportedOn.DataPropertyName = "ImportedOn";
            this.colImportedOn.HeaderText = "Thời Gian Nhập";
            this.colImportedOn.Name = "colImportedOn";
            this.colImportedOn.ReadOnly = true;
            this.colImportedOn.Width = 150;
            // 
            // colSttLost
            // 
            this.colSttLost.DataPropertyName = "SttLost";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSttLost.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSttLost.HeaderText = "Đã Bị Mất";
            this.colSttLost.Name = "colSttLost";
            this.colSttLost.ReadOnly = true;
            this.colSttLost.Width = 125;
            // 
            // colSttBroken
            // 
            this.colSttBroken.DataPropertyName = "SttBroken";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSttBroken.DefaultCellStyle = dataGridViewCellStyle5;
            this.colSttBroken.HeaderText = "Đã Bị Hư";
            this.colSttBroken.Name = "colSttBroken";
            this.colSttBroken.ReadOnly = true;
            this.colSttBroken.Width = 125;
            // 
            // colSttPersonalized
            // 
            this.colSttPersonalized.DataPropertyName = "SttPersonalized";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSttPersonalized.DefaultCellStyle = dataGridViewCellStyle6;
            this.colSttPersonalized.HeaderText = "Đã Phát Hành";
            this.colSttPersonalized.Name = "colSttPersonalized";
            this.colSttPersonalized.ReadOnly = true;
            this.colSttPersonalized.Width = 125;
            // 
            // colCardType
            // 
            this.colCardType.DataPropertyName = "CardType";
            this.colCardType.HeaderText = "Loại Thẻ";
            this.colCardType.Name = "colCardType";
            this.colCardType.ReadOnly = true;
            this.colCardType.Width = 150;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.DataPropertyName = "SerialNumber";
            this.colSerialNumber.HeaderText = "Mã Thẻ";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            // 
            // colCardId
            // 
            this.colCardId.DataPropertyName = "CardId";
            this.colCardId.HeaderText = "CardId";
            this.colCardId.Name = "colCardId";
            this.colCardId.ReadOnly = true;
            this.colCardId.Visible = false;
            // 
            // dgvCardList
            // 
            this.dgvCardList.AllowUserToAddRows = false;
            this.dgvCardList.AllowUserToDeleteRows = false;
            this.dgvCardList.AllowUserToOrderColumns = true;
            this.dgvCardList.AllowUserToResizeRows = false;
            this.dgvCardList.BackgroundColor = System.Drawing.Color.White;
            this.dgvCardList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCardList.ColumnHeadersHeight = 26;
            this.dgvCardList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCardId,
            this.colSerialNumber,
            this.colCardType,
            this.colSttPersonalized,
            this.colSttBroken,
            this.colSttLost,
            this.colImportedOn,
            this.colBlank});
            this.dgvCardList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCardList.Location = new System.Drawing.Point(0, 117);
            this.dgvCardList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCardList.Name = "dgvCardList";
            this.dgvCardList.ReadOnly = true;
            this.dgvCardList.RowHeadersVisible = false;
            this.dgvCardList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCardList.Size = new System.Drawing.Size(776, 410);
            this.dgvCardList.TabIndex = 80;
            // 
            // UsrCardMgtMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.lblRightAreaTitleListCard);
            this.Name = "UsrCardMgtMain";
            this.Size = new System.Drawing.Size(800, 600);
            this.cmsCardTable.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tsmCard.ResumeLayout(false);
            this.tsmCard.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pnlFilterBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsCardTable;
        private System.Windows.Forms.ToolStripMenuItem mniImportCard;
        private System.Windows.Forms.ToolStripMenuItem mniReloadCards;
        private System.Windows.Forms.ToolStripMenuItem mniExportExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private CommonControls.Custom.CommonToolStrip miniToolStrip;
        private CommonControls.Custom.TitleLabel lblRightAreaTitleListCard;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CommonControls.Custom.CommonDataGridView dgvCardList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSttPersonalized;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSttBroken;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSttLost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImportedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbtnStatusPerso;
        private System.Windows.Forms.RadioButton rbtnStatusNotPerso;
        private System.Windows.Forms.CheckBox cbxFilterByPersoStatus;
        private System.Windows.Forms.CheckBox cbxFilterByPhysicalStt;
        private System.Windows.Forms.ComboBox cmbCardTypes;
        private System.Windows.Forms.CheckBox cbxFilterByCardType;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbtnStatusLost;
        private System.Windows.Forms.RadioButton rbtnStatusBroken;
        private System.Windows.Forms.RadioButton rbtnStatusNormal;
        private CommonControls.Custom.CommonToolStrip tsmCard;
        private System.Windows.Forms.ToolStripButton btnImportCard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnShowHideFilter;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripButton btnReloadCards;
        private CommonControls.Custom.Line line2;
        private CommonControls.Custom.PagerPanel pagerPanel1;
    }
}
