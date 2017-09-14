using System;

namespace sAccessComponent.WorkItems
{
    partial class UsrConfigAccessControll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrConfigAccessControll));
            this.miniToolStrip = new CommonControls.Custom.CommonToolStrip();
            this.lblRightAreaTitleListCard = new CommonControls.Custom.TitleLabel();
            this.line1 = new CommonControls.Custom.Line();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDeviceDoorList = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNameGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescriptionDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.txbDes = new System.Windows.Forms.TextBox();
            this.txbName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblNameGroup = new System.Windows.Forms.Label();
            this.lblListDevice = new System.Windows.Forms.Label();
            this.commonToolStrip1 = new CommonControls.Custom.CommonToolStrip();
            this.btnSaveListDeviceGroup = new System.Windows.Forms.ToolStripButton();
            this.line2 = new CommonControls.Custom.Line();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.btnReloadGroup = new System.Windows.Forms.ToolStripButton();
            this.trvOrganizations = new System.Windows.Forms.TreeView();
            this.cmsOrgTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniReloadOrgs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOrg = new CommonControls.Custom.CommonToolStrip();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblLeftAreaTitleGroupUser = new CommonControls.Custom.TitleLabel();
            this.lblRightAreaTitleGroupDevice = new CommonControls.Custom.TitleLabel();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
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
            this.panel1.Size = new System.Drawing.Size(712, 558);
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
            this.panel2.Size = new System.Drawing.Size(700, 548);
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
            this.colId,
            this.colNameGroup,
            this.colDescriptionDevice,
            this.colCheck});
            this.dgvDeviceDoorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeviceDoorList.Location = new System.Drawing.Point(0, 82);
            this.dgvDeviceDoorList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDeviceDoorList.Name = "dgvDeviceDoorList";
            this.dgvDeviceDoorList.RowHeadersVisible = false;
            this.dgvDeviceDoorList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeviceDoorList.Size = new System.Drawing.Size(698, 444);
            this.dgvDeviceDoorList.TabIndex = 80;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colNameGroup
            // 
            this.colNameGroup.DataPropertyName = "Name";
            this.colNameGroup.HeaderText = "Tên nhóm thiết bị";
            this.colNameGroup.Name = "colNameGroup";
            this.colNameGroup.ReadOnly = true;
            this.colNameGroup.Width = 150;
            // 
            // colDescriptionDevice
            // 
            this.colDescriptionDevice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescriptionDevice.DataPropertyName = "des";
            this.colDescriptionDevice.HeaderText = "Mô tả nhóm thiết bị";
            this.colDescriptionDevice.Name = "colDescriptionDevice";
            this.colDescriptionDevice.ReadOnly = true;
            // 
            // colCheck
            // 
            this.colCheck.DataPropertyName = "colCheck";
            this.colCheck.FalseValue = "false";
            this.colCheck.HeaderText = "Thêm vào nhóm thành viên";
            this.colCheck.Name = "colCheck";
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCheck.TrueValue = "true";
            this.colCheck.Width = 215;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilterBox.Controls.Add(this.txbDes);
            this.pnlFilterBox.Controls.Add(this.txbName);
            this.pnlFilterBox.Controls.Add(this.lblDescription);
            this.pnlFilterBox.Controls.Add(this.lblNameGroup);
            this.pnlFilterBox.Controls.Add(this.lblListDevice);
            this.pnlFilterBox.Controls.Add(this.commonToolStrip1);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 1);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(698, 81);
            this.pnlFilterBox.TabIndex = 79;
            // 
            // txbDes
            // 
            this.txbDes.Enabled = false;
            this.txbDes.Location = new System.Drawing.Point(389, 36);
            this.txbDes.Multiline = true;
            this.txbDes.Name = "txbDes";
            this.txbDes.Size = new System.Drawing.Size(314, 22);
            this.txbDes.TabIndex = 5;
            // 
            // txbName
            // 
            this.txbName.Enabled = false;
            this.txbName.Location = new System.Drawing.Point(148, 36);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(181, 22);
            this.txbName.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(335, 39);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(45, 16);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Mô tả:";
            // 
            // lblNameGroup
            // 
            this.lblNameGroup.AutoSize = true;
            this.lblNameGroup.Location = new System.Drawing.Point(8, 39);
            this.lblNameGroup.Name = "lblNameGroup";
            this.lblNameGroup.Size = new System.Drawing.Size(134, 16);
            this.lblNameGroup.TabIndex = 2;
            this.lblNameGroup.Text = "Tên nhóm thành viên:";
            // 
            // lblListDevice
            // 
            this.lblListDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListDevice.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblListDevice.Location = new System.Drawing.Point(5, 30);
            this.lblListDevice.Name = "lblListDevice";
            this.lblListDevice.Size = new System.Drawing.Size(688, 52);
            this.lblListDevice.TabIndex = 0;
            this.lblListDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // commonToolStrip1
            // 
            this.commonToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveListDeviceGroup,
            this.btnReload});
            this.commonToolStrip1.Location = new System.Drawing.Point(5, 5);
            this.commonToolStrip1.Name = "commonToolStrip1";
            this.commonToolStrip1.Size = new System.Drawing.Size(688, 25);
            this.commonToolStrip1.TabIndex = 57;
            this.commonToolStrip1.Text = "tlstripListGroup";
            // 
            // btnSaveListDeviceGroup
            // 
            this.btnSaveListDeviceGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveListDeviceGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveListDeviceGroup.Image")));
            this.btnSaveListDeviceGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveListDeviceGroup.Name = "btnSaveListDeviceGroup";
            this.btnSaveListDeviceGroup.Size = new System.Drawing.Size(23, 22);
            this.btnSaveListDeviceGroup.Text = "Thêm nhóm thiết bị vào nhóm thành viên...";
            this.btnSaveListDeviceGroup.ToolTipText = "Thêm nhóm thiết bị vào nhóm thành viên...";
            this.btnSaveListDeviceGroup.Click += new System.EventHandler(this.btnSaveListDeviceGroup_Click);
            // 
            // line2
            // 
            this.line2.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line2.Dock = System.Windows.Forms.DockStyle.Top;
            this.line2.Location = new System.Drawing.Point(0, 0);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(698, 1);
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
            this.pagerPanel1.Size = new System.Drawing.Size(698, 20);
            this.pagerPanel1.TabIndex = 40;
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
            // trvOrganizations
            // 
            this.trvOrganizations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvOrganizations.ContextMenuStrip = this.cmsOrgTree;
            this.trvOrganizations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvOrganizations.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvOrganizations.Location = new System.Drawing.Point(0, 25);
            this.trvOrganizations.Name = "trvOrganizations";
            this.trvOrganizations.Size = new System.Drawing.Size(238, 521);
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
            this.btnReloadGroup});
            this.tsmOrg.Location = new System.Drawing.Point(0, 0);
            this.tsmOrg.Name = "tsmOrg";
            this.tsmOrg.Size = new System.Drawing.Size(238, 25);
            this.tsmOrg.TabIndex = 56;
            this.tsmOrg.Text = "tlstripListGroup";
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
            this.splitContainer.Panel1.Controls.Add(this.lblLeftAreaTitleGroupUser);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel1);
            this.splitContainer.Panel2.Controls.Add(this.lblRightAreaTitleGroupDevice);
            this.splitContainer.Size = new System.Drawing.Size(971, 590);
            this.splitContainer.SplitterDistance = 252;
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
            this.panel4.Size = new System.Drawing.Size(250, 558);
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
            this.panel5.Size = new System.Drawing.Size(240, 548);
            this.panel5.TabIndex = 57;
            // 
            // lblLeftAreaTitleGroupUser
            // 
            this.lblLeftAreaTitleGroupUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblLeftAreaTitleGroupUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftAreaTitleGroupUser.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblLeftAreaTitleGroupUser.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLeftAreaTitleGroupUser.Location = new System.Drawing.Point(0, 0);
            this.lblLeftAreaTitleGroupUser.Name = "lblLeftAreaTitleGroupUser";
            this.lblLeftAreaTitleGroupUser.Size = new System.Drawing.Size(250, 30);
            this.lblLeftAreaTitleGroupUser.TabIndex = 2;
            this.lblLeftAreaTitleGroupUser.Text = "DANH SÁCH NHÓM THÀNH VIÊN";
            this.lblLeftAreaTitleGroupUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRightAreaTitleGroupDevice
            // 
            this.lblRightAreaTitleGroupDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitleGroupDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitleGroupDevice.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblRightAreaTitleGroupDevice.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitleGroupDevice.Location = new System.Drawing.Point(0, 0);
            this.lblRightAreaTitleGroupDevice.Name = "lblRightAreaTitleGroupDevice";
            this.lblRightAreaTitleGroupDevice.Size = new System.Drawing.Size(712, 30);
            this.lblRightAreaTitleGroupDevice.TabIndex = 34;
            this.lblRightAreaTitleGroupDevice.Text = "DANH SÁCH NHÓM THIẾT BỊ  VÀO/RA";
            this.lblRightAreaTitleGroupDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReload
            // 
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(23, 22);
            this.btnReload.Text = "toolStripButton1";
            this.btnReload.ToolTipText = "Làm mới";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // UsrConfigAccessControll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "UsrConfigAccessControll";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Size = new System.Drawing.Size(983, 600);
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
        private CommonControls.Custom.TitleLabel lblLeftAreaTitleGroupUser;
        private CommonControls.Custom.TitleLabel lblRightAreaTitleGroupDevice;
        private System.Windows.Forms.ContextMenuStrip cmsOrgTree;
        private System.Windows.Forms.ToolStripMenuItem mniReloadOrgs;
        private System.Windows.Forms.ToolStripButton btnReloadGroup;
        private System.Windows.Forms.Label lblListDevice;
        private System.Windows.Forms.ToolStripButton btnDeleteDeviceDoor;
        private System.Windows.Forms.Label lblNameGroup;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txbDes;
        private System.Windows.Forms.TextBox txbName;
        private CommonControls.Custom.CommonToolStrip commonToolStrip1;
        private System.Windows.Forms.ToolStripButton btnSaveListDeviceGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescriptionDevice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.ToolStripButton btnReload;
    }
}
