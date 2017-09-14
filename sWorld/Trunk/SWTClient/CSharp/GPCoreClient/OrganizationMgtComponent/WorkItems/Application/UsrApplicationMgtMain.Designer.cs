namespace SystemMgtComponent.WorkItems
{
    partial class UsrApplicationMgtMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrApplicationMgtMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvAppList = new CommonControls.Custom.CommonDataGridView();
            this.colAppId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.cmsCardTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniImportCard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.xuấtRaExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniReloadCards = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbtnStatusPerso = new System.Windows.Forms.RadioButton();
            this.rbtnStatusNotPerso = new System.Windows.Forms.RadioButton();
            this.cbxFilterByPersoStatus = new System.Windows.Forms.CheckBox();
            this.cbxFilterByPhysicalStt = new System.Windows.Forms.CheckBox();
            this.cmbCardTypes = new System.Windows.Forms.ComboBox();
            this.cbxFilterByCardType = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbtnStatusLost = new System.Windows.Forms.RadioButton();
            this.rbtnStatusBroken = new System.Windows.Forms.RadioButton();
            this.rbtnStatusNormal = new System.Windows.Forms.RadioButton();
            this.tsmCard = new CommonControls.Custom.CommonToolStrip();
            this.btnAddApp = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateApp = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveApp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.btnReloadApp = new System.Windows.Forms.ToolStripButton();
            this.lblRightAreaTitleListApp = new CommonControls.Custom.TitleLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppList)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.cmsCardTable.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tsmCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 35);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Size = new System.Drawing.Size(790, 560);
            this.panel1.TabIndex = 37;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvAppList);
            this.panel2.Controls.Add(this.pnlFilterBox);
            this.panel2.Controls.Add(this.tsmCard);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(778, 550);
            this.panel2.TabIndex = 38;
            // 
            // dgvAppList
            // 
            this.dgvAppList.AllowUserToAddRows = false;
            this.dgvAppList.AllowUserToDeleteRows = false;
            this.dgvAppList.AllowUserToOrderColumns = true;
            this.dgvAppList.AllowUserToResizeRows = false;
            this.dgvAppList.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAppList.ColumnHeadersHeight = 26;
            this.dgvAppList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAppId,
            this.colAppCode,
            this.colAppName,
            this.colDescription,
            this.colBlank});
            this.dgvAppList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAppList.Location = new System.Drawing.Point(0, 25);
            this.dgvAppList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAppList.Name = "dgvAppList";
            this.dgvAppList.ReadOnly = true;
            this.dgvAppList.RowHeadersVisible = false;
            this.dgvAppList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppList.Size = new System.Drawing.Size(776, 523);
            this.dgvAppList.TabIndex = 60;
            // 
            // colAppId
            // 
            this.colAppId.DataPropertyName = "AppId";
            this.colAppId.HeaderText = "AppId";
            this.colAppId.Name = "colAppId";
            this.colAppId.ReadOnly = true;
            this.colAppId.Visible = false;
            // 
            // colAppCode
            // 
            this.colAppCode.DataPropertyName = "AppCode";
            this.colAppCode.HeaderText = "Mã Ứng Dụng";
            this.colAppCode.Name = "colAppCode";
            this.colAppCode.ReadOnly = true;
            this.colAppCode.Visible = false;
            // 
            // colAppName
            // 
            this.colAppName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAppName.DataPropertyName = "AppName";
            this.colAppName.HeaderText = "Tên Ứng Dụng";
            this.colAppName.Name = "colAppName";
            this.colAppName.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDescription.HeaderText = "Mô Tả";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colBlank
            // 
            this.colBlank.DataPropertyName = "Blank";
            this.colBlank.HeaderText = "";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            this.colBlank.Width = 20;
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
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(776, 0);
            this.pnlFilterBox.TabIndex = 59;
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
            this.mniReloadCards.Name = "mniReloadCards";
            this.mniReloadCards.Size = new System.Drawing.Size(152, 22);
            this.mniReloadCards.Text = "Tải Dữ Liệu";
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
            // cbxFilterByPersoStatus
            // 
            this.cbxFilterByPersoStatus.Location = new System.Drawing.Point(8, 61);
            this.cbxFilterByPersoStatus.Name = "cbxFilterByPersoStatus";
            this.cbxFilterByPersoStatus.Size = new System.Drawing.Size(200, 20);
            this.cbxFilterByPersoStatus.TabIndex = 13;
            this.cbxFilterByPersoStatus.Text = "Lọc theo trạng thái phát hành:";
            this.cbxFilterByPersoStatus.UseVisualStyleBackColor = true;
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
            // cbxFilterByCardType
            // 
            this.cbxFilterByCardType.Location = new System.Drawing.Point(8, 8);
            this.cbxFilterByCardType.Name = "cbxFilterByCardType";
            this.cbxFilterByCardType.Size = new System.Drawing.Size(200, 20);
            this.cbxFilterByCardType.TabIndex = 10;
            this.cbxFilterByCardType.Text = "Lọc theo loại thẻ:";
            this.cbxFilterByCardType.UseVisualStyleBackColor = true;
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
            // tsmCard
            // 
            this.tsmCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddApp,
            this.btnUpdateApp,
            this.btnRemoveApp,
            this.toolStripSeparator1,
            this.btnShowHide,
            this.btnReloadApp});
            this.tsmCard.Location = new System.Drawing.Point(0, 0);
            this.tsmCard.Name = "tsmCard";
            this.tsmCard.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsmCard.Size = new System.Drawing.Size(776, 25);
            this.tsmCard.TabIndex = 38;
            this.tsmCard.Text = "tlstripListUser";
            // 
            // btnAddApp
            // 
            this.btnAddApp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddApp.Image = ((System.Drawing.Image)(resources.GetObject("btnAddApp.Image")));
            this.btnAddApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddApp.Name = "btnAddApp";
            this.btnAddApp.Size = new System.Drawing.Size(23, 22);
            this.btnAddApp.Text = "Thêm Ứng Dụng Mới...";
            this.btnAddApp.ToolTipText = "Thêm ứng dụng mới vào hệ thống.";
            // 
            // btnUpdateApp
            // 
            this.btnUpdateApp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateApp.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateApp.Image")));
            this.btnUpdateApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateApp.Name = "btnUpdateApp";
            this.btnUpdateApp.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateApp.Text = "Cập Nhật Thông Tin Ứng Dụng...";
            this.btnUpdateApp.ToolTipText = "Cập nhật thông tin ứng dụng trong hệ thống.";
            // 
            // btnRemoveApp
            // 
            this.btnRemoveApp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveApp.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveApp.Image")));
            this.btnRemoveApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveApp.Name = "btnRemoveApp";
            this.btnRemoveApp.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveApp.Text = "Hủy Ứng Dụng Khỏi Hệ Thống...";
            this.btnRemoveApp.ToolTipText = "Hủy ứng dụng khỏi hệ thống";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // btnReloadApp
            // 
            this.btnReloadApp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadApp.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadApp.Image")));
            this.btnReloadApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadApp.Name = "btnReloadApp";
            this.btnReloadApp.Size = new System.Drawing.Size(23, 22);
            this.btnReloadApp.Text = "Tải Dữ Liệu";
            this.btnReloadApp.ToolTipText = "Tải danh sách thành viên";
            // 
            // lblRightAreaTitleListApp
            // 
            this.lblRightAreaTitleListApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitleListApp.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitleListApp.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblRightAreaTitleListApp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitleListApp.Location = new System.Drawing.Point(5, 5);
            this.lblRightAreaTitleListApp.Name = "lblRightAreaTitleListApp";
            this.lblRightAreaTitleListApp.Size = new System.Drawing.Size(790, 30);
            this.lblRightAreaTitleListApp.TabIndex = 36;
            this.lblRightAreaTitleListApp.Text = "DANH SÁCH ỨNG DỤNG";
            this.lblRightAreaTitleListApp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsrApplicationMgtMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblRightAreaTitleListApp);
            this.Name = "UsrApplicationMgtMain";
            this.Size = new System.Drawing.Size(800, 600);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppList)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.cmsCardTable.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tsmCard.ResumeLayout(false);
            this.tsmCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CommonControls.Custom.CommonToolStrip tsmCard;
        private CommonControls.Custom.TitleLabel lblRightAreaTitleListApp;
        private System.Windows.Forms.ContextMenuStrip cmsCardTable;
        private System.Windows.Forms.ToolStripMenuItem mniImportCard;
        private System.Windows.Forms.ToolStripMenuItem mniReloadCards;
        private System.Windows.Forms.ToolStripMenuItem xuấtRaExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private CommonControls.Custom.CommonDataGridView dgvAppList;
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
        private System.Windows.Forms.ToolStripButton btnAddApp;
        private System.Windows.Forms.ToolStripButton btnUpdateApp;
        private System.Windows.Forms.ToolStripButton btnRemoveApp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnShowHide;
        private System.Windows.Forms.ToolStripButton btnReloadApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
    }
}
