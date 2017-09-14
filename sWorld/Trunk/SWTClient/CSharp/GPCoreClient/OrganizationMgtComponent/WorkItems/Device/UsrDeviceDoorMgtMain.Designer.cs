namespace SystemMgtComponent.WorkItems
{
    partial class UsrDeviceDoorMgtMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrDeviceDoorMgtMain));
            this.lblRightAreaTitle_Device = new CommonControls.Custom.TitleLabel();
            this.line1 = new CommonControls.Custom.Line();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDeviceDoorList = new CommonControls.Custom.CommonDataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpenDoor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCloseDoor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.tbxFillterIp = new System.Windows.Forms.TextBox();
            this.tbxFillterName = new System.Windows.Forms.TextBox();
            this.lblFilterName = new System.Windows.Forms.Label();
            this.lblFilterIp = new System.Windows.Forms.Label();
            this.tsmCard = new CommonControls.Custom.CommonToolStrip();
            this.btnAddDevice = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateDevice = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveDevice = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHideFilter = new System.Windows.Forms.ToolStripButton();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.line2 = new CommonControls.Custom.Line();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceDoorList)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.tsmCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRightAreaTitle_Device
            // 
            this.lblRightAreaTitle_Device.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitle_Device.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitle_Device.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblRightAreaTitle_Device.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitle_Device.Location = new System.Drawing.Point(5, 5);
            this.lblRightAreaTitle_Device.Name = "lblRightAreaTitle_Device";
            this.lblRightAreaTitle_Device.Size = new System.Drawing.Size(790, 30);
            this.lblRightAreaTitle_Device.TabIndex = 63;
            this.lblRightAreaTitle_Device.Text = "DANH SÁCH THIẾT BỊ VÀO/RA";
            this.lblRightAreaTitle_Device.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvDeviceDoorList);
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
            this.colDeviceName,
            this.colIP,
            this.colPort,
            this.colOpenDoor,
            this.colCloseDoor,
            this.colLocked,
            this.colStatus,
            this.colDescription});
            this.dgvDeviceDoorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeviceDoorList.Location = new System.Drawing.Point(0, 89);
            this.dgvDeviceDoorList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDeviceDoorList.Name = "dgvDeviceDoorList";
            this.dgvDeviceDoorList.ReadOnly = true;
            this.dgvDeviceDoorList.RowHeadersVisible = false;
            this.dgvDeviceDoorList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeviceDoorList.Size = new System.Drawing.Size(776, 438);
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
            // colDeviceName
            // 
            this.colDeviceName.DataPropertyName = "Name";
            this.colDeviceName.HeaderText = "Tên Thiết Bị";
            this.colDeviceName.Name = "colDeviceName";
            this.colDeviceName.ReadOnly = true;
            this.colDeviceName.Width = 150;
            // 
            // colIP
            // 
            this.colIP.DataPropertyName = "IP";
            this.colIP.HeaderText = "IP";
            this.colIP.Name = "colIP";
            this.colIP.ReadOnly = true;
            this.colIP.Width = 150;
            // 
            // colPort
            // 
            this.colPort.DataPropertyName = "Port";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPort.DefaultCellStyle = dataGridViewCellStyle4;
            this.colPort.HeaderText = "Port";
            this.colPort.Name = "colPort";
            this.colPort.ReadOnly = true;
            this.colPort.Visible = false;
            this.colPort.Width = 125;
            // 
            // colOpenDoor
            // 
            this.colOpenDoor.DataPropertyName = "TimeOpen";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colOpenDoor.DefaultCellStyle = dataGridViewCellStyle5;
            this.colOpenDoor.HeaderText = "Thời Gian Mở Cửa";
            this.colOpenDoor.Name = "colOpenDoor";
            this.colOpenDoor.ReadOnly = true;
            this.colOpenDoor.Visible = false;
            this.colOpenDoor.Width = 125;
            // 
            // colCloseDoor
            // 
            this.colCloseDoor.DataPropertyName = "TimeClose";
            this.colCloseDoor.HeaderText = "Thời Gian Đóng Cửa";
            this.colCloseDoor.Name = "colCloseDoor";
            this.colCloseDoor.ReadOnly = true;
            this.colCloseDoor.Visible = false;
            this.colCloseDoor.Width = 150;
            // 
            // colLocked
            // 
            this.colLocked.DataPropertyName = "Locked";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colLocked.DefaultCellStyle = dataGridViewCellStyle6;
            this.colLocked.HeaderText = "Đã Bị Khóa";
            this.colLocked.Name = "colLocked";
            this.colLocked.ReadOnly = true;
            this.colLocked.Visible = false;
            this.colLocked.Width = 125;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Visible = false;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "description";
            this.colDescription.HeaderText = "Mô tả";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilterBox.Controls.Add(this.tbxFillterIp);
            this.pnlFilterBox.Controls.Add(this.tbxFillterName);
            this.pnlFilterBox.Controls.Add(this.lblFilterName);
            this.pnlFilterBox.Controls.Add(this.lblFilterIp);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 26);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(776, 63);
            this.pnlFilterBox.TabIndex = 79;
            // 
            // tbxFillterIp
            // 
            this.tbxFillterIp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbxFillterIp.Location = new System.Drawing.Point(188, 35);
            this.tbxFillterIp.Name = "tbxFillterIp";
            this.tbxFillterIp.Size = new System.Drawing.Size(285, 22);
            this.tbxFillterIp.TabIndex = 19;
            this.tbxFillterIp.TextChanged += new System.EventHandler(this.tbxFillterIp_TextChanged);
            // 
            // tbxFillterName
            // 
            this.tbxFillterName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbxFillterName.Location = new System.Drawing.Point(188, 7);
            this.tbxFillterName.Name = "tbxFillterName";
            this.tbxFillterName.Size = new System.Drawing.Size(285, 22);
            this.tbxFillterName.TabIndex = 18;
            this.tbxFillterName.TextChanged += new System.EventHandler(this.tbxFillterName_TextChanged);
            // 
            // lblFilterName
            // 
            this.lblFilterName.AutoSize = true;
            this.lblFilterName.Location = new System.Drawing.Point(25, 10);
            this.lblFilterName.Name = "lblFilterName";
            this.lblFilterName.Size = new System.Drawing.Size(121, 16);
            this.lblFilterName.TabIndex = 17;
            this.lblFilterName.Text = "Lọc theo tên thiết bị";
            // 
            // lblFilterIp
            // 
            this.lblFilterIp.AutoSize = true;
            this.lblFilterIp.Location = new System.Drawing.Point(25, 42);
            this.lblFilterIp.Name = "lblFilterIp";
            this.lblFilterIp.Size = new System.Drawing.Size(71, 16);
            this.lblFilterIp.TabIndex = 16;
            this.lblFilterIp.Text = "Lọc theo IP";
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
            this.toolStripSeparator2});
            this.tsmCard.Location = new System.Drawing.Point(0, 1);
            this.tsmCard.Name = "tsmCard";
            this.tsmCard.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsmCard.Size = new System.Drawing.Size(776, 25);
            this.tsmCard.TabIndex = 78;
            this.tsmCard.Text = "tlstripListUser";
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddDevice.Image = ((System.Drawing.Image)(resources.GetObject("btnAddDevice.Image")));
            this.btnAddDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(23, 22);
            this.btnAddDevice.Text = "Nhập Khóa...";
            this.btnAddDevice.ToolTipText = "Thêm thiết bị vào/ra mới";
            // 
            // btnUpdateDevice
            // 
            this.btnUpdateDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateDevice.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateDevice.Image")));
            this.btnUpdateDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateDevice.Name = "btnUpdateDevice";
            this.btnUpdateDevice.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateDevice.Text = "Cập Nhật...";
            this.btnUpdateDevice.ToolTipText = "Cập nhật thông tin  thiết bị vào/ra";
            // 
            // btnRemoveDevice
            // 
            this.btnRemoveDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveDevice.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveDevice.Image")));
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
            this.btnShowHideFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnShowHideFilter.Image")));
            this.btnShowHideFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHideFilter.Name = "btnShowHideFilter";
            this.btnShowHideFilter.Size = new System.Drawing.Size(23, 22);
            this.btnShowHideFilter.Text = "Ẩn Khung Tìm Kiếm";
            this.btnShowHideFilter.ToolTipText = "Ẩn khung tìm kiếm";
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
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator2.Visible = false;
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
            // UsrDeviceDoorMgtMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.lblRightAreaTitle_Device);
            this.Name = "UsrDeviceDoorMgtMain";
            this.Size = new System.Drawing.Size(800, 600);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceDoorList)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.tsmCard.ResumeLayout(false);
            this.tsmCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CommonControls.Custom.TitleLabel lblRightAreaTitle_Device;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
       
        private System.Windows.Forms.Panel pnlFilterBox;
        private CommonControls.Custom.CommonToolStrip tsmCard;
        private System.Windows.Forms.ToolStripButton btnAddDevice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnShowHideFilter;
        private CommonControls.Custom.Line line2;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnUpdateDevice;
        private System.Windows.Forms.ToolStripButton btnRemoveDevice;
        private CommonControls.Custom.CommonDataGridView dgvDeviceDoorList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOpenDoor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCloseDoor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.Label lblFilterName;
        private System.Windows.Forms.Label lblFilterIp;
        private System.Windows.Forms.TextBox tbxFillterIp;
        private System.Windows.Forms.TextBox tbxFillterName;
    }
}
