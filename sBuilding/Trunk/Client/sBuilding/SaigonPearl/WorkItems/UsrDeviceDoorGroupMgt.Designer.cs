namespace sAccessComponent.WorkItems
{
    partial class UsrDeviceDoorGroupMgt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrDeviceDoorGroupMgt));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.miniToolStrip = new CommonControls.Custom.CommonToolStrip();
            this.lblRightAreaTitleListCard = new CommonControls.Custom.TitleLabel();
            this.line1 = new CommonControls.Custom.Line();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDeviceDoorList = new System.Windows.Forms.DataGridView();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.txbDescription = new System.Windows.Forms.TextBox();
            this.txbNameGroup = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblNameGroup = new System.Windows.Forms.Label();
            this.commonToolStrip1 = new CommonControls.Custom.CommonToolStrip();
            this.btnAddDeviceDoor = new System.Windows.Forms.ToolStripButton();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.line2 = new CommonControls.Custom.Line();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.trvOrganizations = new System.Windows.Forms.TreeView();
            this.cmsOrgTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniReloadOrgs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOrg = new CommonControls.Custom.CommonToolStrip();
            this.btnAddGroup = new System.Windows.Forms.ToolStripButton();
            this.btnEditGroup = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveGroup = new System.Windows.Forms.ToolStripButton();
            this.btnReloadGroup = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblLeftAreaTitleGroup = new CommonControls.Custom.TitleLabel();
            this.lblRightAreaTitlegGroupDevice = new CommonControls.Custom.TitleLabel();
            this.colDeviceDoorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddDevice = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceDoorList)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.commonToolStrip1.SuspendLayout();
            this.cmsOrgTree.SuspendLayout();
            this.tsmOrg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
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
            this.lblRightAreaTitleListCard.Text = "DANH SÁCH THIẾT BỊ VÀO/RA";
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
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Size = new System.Drawing.Size(858, 558);
            this.panel1.TabIndex = 67;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvDeviceDoorList);
            this.panel2.Controls.Add(this.pnlFilterBox);
            this.panel2.Controls.Add(this.line2);
            this.panel2.Controls.Add(this.pagerPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(846, 548);
            this.panel2.TabIndex = 38;
            // 
            // dgvDeviceDoorList
            // 
            this.dgvDeviceDoorList.AllowUserToAddRows = false;
            this.dgvDeviceDoorList.AllowUserToDeleteRows = false;
            this.dgvDeviceDoorList.AllowUserToOrderColumns = true;
            this.dgvDeviceDoorList.AllowUserToResizeRows = false;
            this.dgvDeviceDoorList.BackgroundColor = System.Drawing.Color.White;
            this.dgvDeviceDoorList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDeviceDoorList.ColumnHeadersHeight = 26;
            this.dgvDeviceDoorList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeviceDoorId,
            this.colId,
            this.colDeviceName,
            this.colIP,
            this.colDeviceDescription,
            this.colAddDevice});
            this.dgvDeviceDoorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeviceDoorList.Location = new System.Drawing.Point(0, 80);
            this.dgvDeviceDoorList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDeviceDoorList.Name = "dgvDeviceDoorList";
            this.dgvDeviceDoorList.RowHeadersVisible = false;
            this.dgvDeviceDoorList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeviceDoorList.Size = new System.Drawing.Size(844, 446);
            this.dgvDeviceDoorList.TabIndex = 80;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilterBox.Controls.Add(this.txbDescription);
            this.pnlFilterBox.Controls.Add(this.txbNameGroup);
            this.pnlFilterBox.Controls.Add(this.lblDescription);
            this.pnlFilterBox.Controls.Add(this.lblNameGroup);
            this.pnlFilterBox.Controls.Add(this.commonToolStrip1);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 1);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(844, 79);
            this.pnlFilterBox.TabIndex = 79;
            // 
            // txbDescription
            // 
            this.txbDescription.Enabled = false;
            this.txbDescription.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txbDescription.Location = new System.Drawing.Point(442, 41);
            this.txbDescription.Multiline = true;
            this.txbDescription.Name = "txbDescription";
            this.txbDescription.Size = new System.Drawing.Size(500, 22);
            this.txbDescription.TabIndex = 62;
            // 
            // txbNameGroup
            // 
            this.txbNameGroup.Enabled = false;
            this.txbNameGroup.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txbNameGroup.Location = new System.Drawing.Point(108, 37);
            this.txbNameGroup.Name = "txbNameGroup";
            this.txbNameGroup.Size = new System.Drawing.Size(205, 24);
            this.txbNameGroup.TabIndex = 61;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblDescription.Location = new System.Drawing.Point(335, 44);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(87, 17);
            this.lblDescription.TabIndex = 59;
            this.lblDescription.Text = "Mô tả nhóm:";
            // 
            // lblNameGroup
            // 
            this.lblNameGroup.AutoSize = true;
            this.lblNameGroup.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblNameGroup.Location = new System.Drawing.Point(17, 44);
            this.lblNameGroup.Name = "lblNameGroup";
            this.lblNameGroup.Size = new System.Drawing.Size(76, 17);
            this.lblNameGroup.TabIndex = 58;
            this.lblNameGroup.Text = "Tên nhóm:";
            // 
            // commonToolStrip1
            // 
            this.commonToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddDeviceDoor,
            this.btnReload});
            this.commonToolStrip1.Location = new System.Drawing.Point(5, 5);
            this.commonToolStrip1.Name = "commonToolStrip1";
            this.commonToolStrip1.Size = new System.Drawing.Size(834, 25);
            this.commonToolStrip1.TabIndex = 57;
            this.commonToolStrip1.Text = "tlstripListGroup";
            // 
            // btnAddDeviceDoor
            // 
            this.btnAddDeviceDoor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddDeviceDoor.Enabled = false;
            this.btnAddDeviceDoor.Image = ((System.Drawing.Image)(resources.GetObject("btnAddDeviceDoor.Image")));
            this.btnAddDeviceDoor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDeviceDoor.Name = "btnAddDeviceDoor";
            this.btnAddDeviceDoor.Size = new System.Drawing.Size(23, 22);
            this.btnAddDeviceDoor.Text = "Cập nhật";
            this.btnAddDeviceDoor.ToolTipText = "Cập nhật";
            this.btnAddDeviceDoor.Click += new System.EventHandler(this.btnAddDeviceDoor_Click);
            // 
            // btnReload
            // 
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(23, 22);
            this.btnReload.Text = "Làm mới";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // line2
            // 
            this.line2.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line2.Dock = System.Windows.Forms.DockStyle.Top;
            this.line2.Location = new System.Drawing.Point(0, 0);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(844, 1);
            this.line2.TabIndex = 77;
            this.line2.TabStop = false;
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 526);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(844, 20);
            this.pagerPanel1.TabIndex = 40;
            // 
            // trvOrganizations
            // 
            this.trvOrganizations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvOrganizations.ContextMenuStrip = this.cmsOrgTree;
            this.trvOrganizations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvOrganizations.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvOrganizations.Location = new System.Drawing.Point(0, 25);
            this.trvOrganizations.Name = "trvOrganizations";
            this.trvOrganizations.Size = new System.Drawing.Size(209, 521);
            this.trvOrganizations.TabIndex = 57;
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
            // tsmOrg
            // 
            this.tsmOrg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddGroup,
            this.btnEditGroup,
            this.btnRemoveGroup,
            this.btnReloadGroup});
            this.tsmOrg.Location = new System.Drawing.Point(0, 0);
            this.tsmOrg.Name = "tsmOrg";
            this.tsmOrg.Size = new System.Drawing.Size(209, 25);
            this.tsmOrg.TabIndex = 56;
            this.tsmOrg.Text = "tlstripListGroup";
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGroup.Image")));
            this.btnAddGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(23, 22);
            this.btnAddGroup.Text = "Thêm nhóm mới...";
            this.btnAddGroup.ToolTipText = "Thêm nhóm mới";
            // 
            // btnEditGroup
            // 
            this.btnEditGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnEditGroup.Image")));
            this.btnEditGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditGroup.Name = "btnEditGroup";
            this.btnEditGroup.Size = new System.Drawing.Size(23, 22);
            this.btnEditGroup.Text = "Tải Dữ Liệu";
            this.btnEditGroup.ToolTipText = "Sửa nhóm";
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveGroup.Image")));
            this.btnRemoveGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveGroup.Text = "Tải Dữ Liệu";
            this.btnRemoveGroup.ToolTipText = "Xóa nhóm";
            // 
            // btnReloadGroup
            // 
            this.btnReloadGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadGroup.Image")));
            this.btnReloadGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadGroup.Name = "btnReloadGroup";
            this.btnReloadGroup.Size = new System.Drawing.Size(23, 22);
            this.btnReloadGroup.Text = "Tải Dữ Liệu";
            this.btnReloadGroup.ToolTipText = "Tải dữ liệu";
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
            this.splitContainer.Panel1.Controls.Add(this.panel4);
            this.splitContainer.Panel1.Controls.Add(this.lblLeftAreaTitleGroup);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel1);
            this.splitContainer.Panel2.Controls.Add(this.lblRightAreaTitlegGroupDevice);
            this.splitContainer.Size = new System.Drawing.Size(1088, 590);
            this.splitContainer.SplitterDistance = 223;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 30);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(221, 558);
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
            this.panel5.Size = new System.Drawing.Size(211, 548);
            this.panel5.TabIndex = 57;
            // 
            // lblLeftAreaTitleGroup
            // 
            this.lblLeftAreaTitleGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblLeftAreaTitleGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftAreaTitleGroup.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblLeftAreaTitleGroup.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLeftAreaTitleGroup.Location = new System.Drawing.Point(0, 0);
            this.lblLeftAreaTitleGroup.Name = "lblLeftAreaTitleGroup";
            this.lblLeftAreaTitleGroup.Size = new System.Drawing.Size(221, 30);
            this.lblLeftAreaTitleGroup.TabIndex = 2;
            this.lblLeftAreaTitleGroup.Text = "DANH SÁCH NHÓM CỬA";
            this.lblLeftAreaTitleGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRightAreaTitlegGroupDevice
            // 
            this.lblRightAreaTitlegGroupDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitlegGroupDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitlegGroupDevice.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblRightAreaTitlegGroupDevice.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitlegGroupDevice.Location = new System.Drawing.Point(0, 0);
            this.lblRightAreaTitlegGroupDevice.Name = "lblRightAreaTitlegGroupDevice";
            this.lblRightAreaTitlegGroupDevice.Size = new System.Drawing.Size(858, 30);
            this.lblRightAreaTitlegGroupDevice.TabIndex = 34;
            this.lblRightAreaTitlegGroupDevice.Text = "DANH SÁCH THIẾT BỊ  VÀO/RA";
            this.lblRightAreaTitlegGroupDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colDeviceDoorId
            // 
            this.colDeviceDoorId.DataPropertyName = "DeviceDoorId";
            this.colDeviceDoorId.HeaderText = "DeviceDoorId";
            this.colDeviceDoorId.Name = "colDeviceDoorId";
            this.colDeviceDoorId.ReadOnly = true;
            this.colDeviceDoorId.Visible = false;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colDeviceName
            // 
            this.colDeviceName.DataPropertyName = "Name";
            this.colDeviceName.HeaderText = "Tên Thiết Bị";
            this.colDeviceName.Name = "colDeviceName";
            this.colDeviceName.ReadOnly = true;
            this.colDeviceName.Width = 175;
            // 
            // colIP
            // 
            this.colIP.DataPropertyName = "IP";
            this.colIP.HeaderText = "IP";
            this.colIP.Name = "colIP";
            this.colIP.ReadOnly = true;
            this.colIP.Width = 200;
            // 
            // colDeviceDescription
            // 
            this.colDeviceDescription.DataPropertyName = "Des";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.colDeviceDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDeviceDescription.HeaderText = "Mô tả thiết bị";
            this.colDeviceDescription.Name = "colDeviceDescription";
            this.colDeviceDescription.ReadOnly = true;
            this.colDeviceDescription.Width = 400;
            // 
            // colAddDevice
            // 
            this.colAddDevice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAddDevice.DataPropertyName = "colAddDevice";
            this.colAddDevice.FalseValue = "false";
            this.colAddDevice.HeaderText = "Thêm thiết bị vào nhóm cửa";
            this.colAddDevice.Name = "colAddDevice";
            this.colAddDevice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAddDevice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAddDevice.TrueValue = "true";
            // 
            // UsrDeviceDoorGroupMgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "UsrDeviceDoorGroupMgt";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Size = new System.Drawing.Size(1100, 600);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceDoorList)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.commonToolStrip1.ResumeLayout(false);
            this.commonToolStrip1.PerformLayout();
            this.cmsOrgTree.ResumeLayout(false);
            this.tsmOrg.ResumeLayout(false);
            this.tsmOrg.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private CommonControls.Custom.CommonToolStrip miniToolStrip;
        private CommonControls.Custom.TitleLabel lblRightAreaTitleListCard;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
       
        private System.Windows.Forms.Panel pnlFilterBox;
        private CommonControls.Custom.Line line2;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private System.Windows.Forms.DataGridView dgvDeviceDoorList;
        private System.Windows.Forms.TreeView trvOrganizations;
        private CommonControls.Custom.CommonToolStrip tsmOrg;
        private CommonControls.Custom.TitleLabel lblLeftAreaTitleGroup;
        private CommonControls.Custom.TitleLabel lblRightAreaTitlegGroupDevice;
        private System.Windows.Forms.ContextMenuStrip cmsOrgTree;
        private System.Windows.Forms.ToolStripMenuItem mniReloadOrgs;
        private System.Windows.Forms.ToolStripButton btnAddGroup;
        private System.Windows.Forms.ToolStripButton btnEditGroup;
        private System.Windows.Forms.ToolStripButton btnRemoveGroup;
        private System.Windows.Forms.ToolStripButton btnReloadGroup;
        private CommonControls.Custom.CommonToolStrip commonToolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddDeviceDoor;
        private System.Windows.Forms.Label lblNameGroup;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txbNameGroup;
        private System.Windows.Forms.TextBox txbDescription;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceDoorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAddDevice;
    }
}

