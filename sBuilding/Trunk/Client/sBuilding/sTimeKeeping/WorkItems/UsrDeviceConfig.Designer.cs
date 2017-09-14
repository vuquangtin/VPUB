namespace sTimeKeeping.WorkItems
{
    partial class UsrDeviceConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrDeviceConfig));
            this.tsmCard = new CommonControls.Custom.CommonToolStrip();
            this.btnAddDevice = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateDevice = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveDevice = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHideFilter = new System.Windows.Forms.ToolStripButton();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.line2 = new CommonControls.Custom.Line();
            this.cmsOrgTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniReloadOrgs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOrg = new CommonControls.Custom.CommonToolStrip();
            this.btnRefreshOrg = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.trvOrganizations = new System.Windows.Forms.TreeView();
            this.lblLeftAreaTitleOrg = new CommonControls.Custom.TitleLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDeviceDoorList = new System.Windows.Forms.DataGridView();
            this.colDeviceDoorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceNameConfig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIPConfig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesConfig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeKeeping = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.lblTimeKeeping = new System.Windows.Forms.Label();
            this.commonToolStrip1 = new CommonControls.Custom.CommonToolStrip();
            this.tsbcheck = new System.Windows.Forms.ToolStripButton();
            this.btnReloadConfig = new System.Windows.Forms.ToolStripButton();
            this.lblDevice = new System.Windows.Forms.Label();
            this.lblRightAreaTitle_DeviceInOut = new CommonControls.Custom.TitleLabel();
            this.line1 = new CommonControls.Custom.Line();
            this.tsmCard.SuspendLayout();
            this.cmsOrgTree.SuspendLayout();
            this.tsmOrg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceDoorList)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.commonToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsmCard
            // 
            this.tsmCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddDevice,
            this.btnUpdateDevice,
            this.btnRemoveDevice,
            this.toolStripSeparator1,
            this.btnShowHideFilter,
            this.btnReload,
            this.toolStripSeparator2,
            this.btnExportToExcel});
            this.tsmCard.Location = new System.Drawing.Point(0, 1);
            this.tsmCard.Name = "tsmCard";
            this.tsmCard.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.tsmCard.Size = new System.Drawing.Size(866, 25);
            this.tsmCard.TabIndex = 78;
            this.tsmCard.Text = "tlstripListUser";
            this.tsmCard.Visible = false;
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(23, 22);
            this.btnAddDevice.Text = "Thêm thiết bị...";
            this.btnAddDevice.ToolTipText = "Thêm thiết bị vào/ra mới";
            // 
            // btnUpdateDevice
            // 
            this.btnUpdateDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateDevice.Name = "btnUpdateDevice";
            this.btnUpdateDevice.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateDevice.Text = "Cập Nhật...";
            this.btnUpdateDevice.ToolTipText = "Cập nhật thông tin  thiết bị vào/ra";
            // 
            // btnRemoveDevice
            // 
            this.btnRemoveDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveDevice.Name = "btnRemoveDevice";
            this.btnRemoveDevice.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveDevice.Text = "Hủy...";
            this.btnRemoveDevice.ToolTipText = "Hủy thiết bị vào/ra khỏi hệ thống";
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
            this.btnShowHideFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHideFilter.Name = "btnShowHideFilter";
            this.btnShowHideFilter.Size = new System.Drawing.Size(23, 22);
            this.btnShowHideFilter.Text = "Ẩn Khung Tìm Kiếm";
            this.btnShowHideFilter.ToolTipText = "Ẩn khung tìm kiếm";
            // 
            // btnReload
            // 
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(23, 22);
            this.btnReload.Text = "Tải Dữ Liệu";
            this.btnReload.ToolTipText = "Tải danh sách lượt phát hành";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator2.Visible = false;
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
            // line2
            // 
            this.line2.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line2.Dock = System.Windows.Forms.DockStyle.Top;
            this.line2.Location = new System.Drawing.Point(0, 0);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(866, 1);
            this.line2.TabIndex = 77;
            this.line2.TabStop = false;
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
            this.btnRefreshOrg});
            this.tsmOrg.Location = new System.Drawing.Point(0, 0);
            this.tsmOrg.Name = "tsmOrg";
            this.tsmOrg.Size = new System.Drawing.Size(203, 25);
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
            this.btnRefreshOrg.Text = "Tải Dữ Liệu";
            this.btnRefreshOrg.ToolTipText = "Tải dữ liệu";
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(6, 6);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panel4);
            this.splitContainer.Panel1.Controls.Add(this.lblLeftAreaTitleOrg);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel1);
            this.splitContainer.Panel2.Controls.Add(this.lblRightAreaTitle_DeviceInOut);
            this.splitContainer.Size = new System.Drawing.Size(1109, 610);
            this.splitContainer.SplitterDistance = 219;
            this.splitContainer.SplitterWidth = 6;
            this.splitContainer.TabIndex = 65;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 32);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel4.Size = new System.Drawing.Size(217, 576);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.trvOrganizations);
            this.panel5.Controls.Add(this.tsmOrg);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(6, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(205, 566);
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
            this.trvOrganizations.Size = new System.Drawing.Size(203, 539);
            this.trvOrganizations.TabIndex = 57;
            // 
            // lblLeftAreaTitleOrg
            // 
            this.lblLeftAreaTitleOrg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblLeftAreaTitleOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftAreaTitleOrg.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblLeftAreaTitleOrg.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLeftAreaTitleOrg.Location = new System.Drawing.Point(0, 0);
            this.lblLeftAreaTitleOrg.Name = "lblLeftAreaTitleOrg";
            this.lblLeftAreaTitleOrg.Size = new System.Drawing.Size(217, 32);
            this.lblLeftAreaTitleOrg.TabIndex = 2;
            this.lblLeftAreaTitleOrg.Text = "DANH SÁCH TỔ CHỨC";
            this.lblLeftAreaTitleOrg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.panel1.Size = new System.Drawing.Size(882, 576);
            this.panel1.TabIndex = 67;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvDeviceDoorList);
            this.panel2.Controls.Add(this.pnlFilterBox);
            this.panel2.Controls.Add(this.tsmCard);
            this.panel2.Controls.Add(this.line2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(868, 566);
            this.panel2.TabIndex = 38;
            // 
            // dgvDeviceDoorList
            // 
            this.dgvDeviceDoorList.AllowUserToAddRows = false;
            this.dgvDeviceDoorList.AllowUserToDeleteRows = false;
            this.dgvDeviceDoorList.AllowUserToOrderColumns = true;
            this.dgvDeviceDoorList.AllowUserToResizeRows = false;
            this.dgvDeviceDoorList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDeviceDoorList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDeviceDoorList.ColumnHeadersHeight = 26;
            this.dgvDeviceDoorList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeviceDoorId,
            this.colDeviceNameConfig,
            this.colIPConfig,
            this.colDesConfig,
            this.colTimeKeeping});
            this.dgvDeviceDoorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeviceDoorList.Location = new System.Drawing.Point(0, 86);
            this.dgvDeviceDoorList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDeviceDoorList.Name = "dgvDeviceDoorList";
            this.dgvDeviceDoorList.RowHeadersVisible = false;
            this.dgvDeviceDoorList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeviceDoorList.Size = new System.Drawing.Size(866, 478);
            this.dgvDeviceDoorList.TabIndex = 80;
            // 
            // colDeviceDoorId
            // 
            this.colDeviceDoorId.DataPropertyName = "colDeviceDoorId";
            this.colDeviceDoorId.HeaderText = "DeviceId";
            this.colDeviceDoorId.Name = "colDeviceDoorId";
            this.colDeviceDoorId.Visible = false;
            this.colDeviceDoorId.Width = 40;
            // 
            // colDeviceNameConfig
            // 
            this.colDeviceNameConfig.DataPropertyName = "colDeviceNameConfig";
            this.colDeviceNameConfig.HeaderText = "Tên";
            this.colDeviceNameConfig.Name = "colDeviceNameConfig";
            this.colDeviceNameConfig.ReadOnly = true;
            this.colDeviceNameConfig.Width = 200;
            // 
            // colIPConfig
            // 
            this.colIPConfig.DataPropertyName = "colIPConfig";
            this.colIPConfig.HeaderText = "IP";
            this.colIPConfig.Name = "colIPConfig";
            this.colIPConfig.ReadOnly = true;
            this.colIPConfig.Width = 125;
            // 
            // colDesConfig
            // 
            this.colDesConfig.DataPropertyName = "colDesConfig";
            this.colDesConfig.HeaderText = "Mô tả";
            this.colDesConfig.Name = "colDesConfig";
            this.colDesConfig.ReadOnly = true;
            this.colDesConfig.Width = 500;
            // 
            // colTimeKeeping
            // 
            this.colTimeKeeping.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTimeKeeping.DataPropertyName = "Check";
            this.colTimeKeeping.FalseValue = "false";
            this.colTimeKeeping.HeaderText = "Thiết bị chấm công";
            this.colTimeKeeping.IndeterminateValue = "";
            this.colTimeKeeping.Name = "colTimeKeeping";
            this.colTimeKeeping.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTimeKeeping.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colTimeKeeping.TrueValue = "true";
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilterBox.Controls.Add(this.lblTimeKeeping);
            this.pnlFilterBox.Controls.Add(this.commonToolStrip1);
            this.pnlFilterBox.Controls.Add(this.lblDevice);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 1);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlFilterBox.Size = new System.Drawing.Size(866, 85);
            this.pnlFilterBox.TabIndex = 79;
            // 
            // lblTimeKeeping
            // 
            this.lblTimeKeeping.AutoSize = true;
            this.lblTimeKeeping.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeKeeping.Location = new System.Drawing.Point(9, 61);
            this.lblTimeKeeping.Name = "lblTimeKeeping";
            this.lblTimeKeeping.Size = new System.Drawing.Size(195, 16);
            this.lblTimeKeeping.TabIndex = 58;
            this.lblTimeKeeping.Text = "Chọn thiết bị chấm công và Save";
            // 
            // commonToolStrip1
            // 
            this.commonToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbcheck,
            this.btnReloadConfig});
            this.commonToolStrip1.Location = new System.Drawing.Point(6, 5);
            this.commonToolStrip1.Name = "commonToolStrip1";
            this.commonToolStrip1.Size = new System.Drawing.Size(854, 25);
            this.commonToolStrip1.TabIndex = 57;
            this.commonToolStrip1.Text = "tlstripListGroup";
            // 
            // tsbcheck
            // 
            this.tsbcheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbcheck.Enabled = false;
            this.tsbcheck.Image = ((System.Drawing.Image)(resources.GetObject("tsbcheck.Image")));
            this.tsbcheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbcheck.Name = "tsbcheck";
            this.tsbcheck.Size = new System.Drawing.Size(23, 22);
            this.tsbcheck.ToolTipText = "Save DeviceConfig";
            // 
            // btnReloadConfig
            // 
            this.btnReloadConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadConfig.Enabled = false;
            this.btnReloadConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadConfig.Image")));
            this.btnReloadConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadConfig.Name = "btnReloadConfig";
            this.btnReloadConfig.Size = new System.Drawing.Size(23, 22);
            this.btnReloadConfig.Text = "Làm mới";
            this.btnReloadConfig.Click += new System.EventHandler(this.btnReloadConfig_Click);
            // 
            // lblDevice
            // 
            this.lblDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDevice.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblDevice.Location = new System.Drawing.Point(6, 5);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(854, 75);
            this.lblDevice.TabIndex = 0;
            this.lblDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRightAreaTitle_DeviceInOut
            // 
            this.lblRightAreaTitle_DeviceInOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitle_DeviceInOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitle_DeviceInOut.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblRightAreaTitle_DeviceInOut.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitle_DeviceInOut.Location = new System.Drawing.Point(0, 0);
            this.lblRightAreaTitle_DeviceInOut.Name = "lblRightAreaTitle_DeviceInOut";
            this.lblRightAreaTitle_DeviceInOut.Size = new System.Drawing.Size(882, 32);
            this.lblRightAreaTitle_DeviceInOut.TabIndex = 34;
            this.lblRightAreaTitle_DeviceInOut.Text = "DANH SÁCH THIẾT BỊ VÀO/RA";
            this.lblRightAreaTitle_DeviceInOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(6, 5);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(1109, 1);
            this.line1.TabIndex = 68;
            this.line1.TabStop = false;
            // 
            // UsrDeviceConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.line1);
            this.Name = "UsrDeviceConfig";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Size = new System.Drawing.Size(1121, 621);
            this.tsmCard.ResumeLayout(false);
            this.tsmCard.PerformLayout();
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
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceDoorList)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.commonToolStrip1.ResumeLayout(false);
            this.commonToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion
        private CommonControls.Custom.CommonToolStrip tsmCard;
        private System.Windows.Forms.ToolStripButton btnAddDevice;
        private System.Windows.Forms.ToolStripButton btnUpdateDevice;
        private System.Windows.Forms.ToolStripButton btnRemoveDevice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnShowHideFilter;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private CommonControls.Custom.Line line2;
        private System.Windows.Forms.ContextMenuStrip cmsOrgTree;
        private System.Windows.Forms.ToolStripMenuItem mniReloadOrgs;
        private CommonControls.Custom.CommonToolStrip tsmOrg;
        private System.Windows.Forms.ToolStripButton btnRefreshOrg;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TreeView trvOrganizations;
        private CommonControls.Custom.TitleLabel lblLeftAreaTitleOrg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlFilterBox;
        private CommonControls.Custom.CommonToolStrip commonToolStrip1;
        private System.Windows.Forms.Label lblDevice;
        private CommonControls.Custom.TitleLabel lblRightAreaTitle_DeviceInOut;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.ToolStripButton tsbcheck;
        private System.Windows.Forms.Label lblTimeKeeping;
        private System.Windows.Forms.DataGridView dgvDeviceDoorList;
        private System.Windows.Forms.ToolStripButton btnReloadConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceDoorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceNameConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIPConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesConfig;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTimeKeeping;
    }
}
