namespace sAccessControl
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ttlbUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ttlbTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tpDeviceStatus = new System.Windows.Forms.TabPage();
            this.lblReaderState = new sAccessControl.View.UsrDeviceStatus();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCameraState = new sAccessControl.View.UsrDeviceStatus();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblSubOrgName = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbWaterCost = new System.Windows.Forms.Label();
            this.lbManagerCost = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.commonToolStrip1 = new CommonControls.Custom.CommonToolStrip();
            this.panel3 = new System.Windows.Forms.Panel();
            this.plCamera = new System.Windows.Forms.Panel();
            this.cameraCanvas = new sAccessControl.View.UsrCameraCanvas();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trvDeviceList = new System.Windows.Forms.TreeView();
            this.tsmOrg = new CommonControls.Custom.CommonToolStrip();
            this.btnReloadDevice = new System.Windows.Forms.ToolStripButton();
            this.lblRightAreaTitleListCard = new CommonControls.Custom.TitleLabel();
            this.tsbmLogout = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.tpDeviceStatus.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.commonToolStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.plCamera.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tsmOrg.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.ttlbUser,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel1,
            this.ttlbTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 548);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(924, 22);
            this.statusStrip1.TabIndex = 79;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(57, 17);
            this.toolStripStatusLabel2.Text = "Xin chào:";
            // 
            // ttlbUser
            // 
            this.ttlbUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ttlbUser.Name = "ttlbUser";
            this.ttlbUser.Size = new System.Drawing.Size(65, 17);
            this.ttlbUser.Text = "UserName";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(20, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(61, 17);
            this.toolStripStatusLabel1.Text = "Thời gian:";
            // 
            // ttlbTime
            // 
            this.ttlbTime.BackColor = System.Drawing.SystemColors.Control;
            this.ttlbTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ttlbTime.Name = "ttlbTime";
            this.ttlbTime.Size = new System.Drawing.Size(63, 17);
            this.ttlbTime.Text = "HH:mm:ss";
            // 
            // tpDeviceStatus
            // 
            this.tpDeviceStatus.Controls.Add(this.lblReaderState);
            this.tpDeviceStatus.Controls.Add(this.label2);
            this.tpDeviceStatus.Controls.Add(this.label1);
            this.tpDeviceStatus.Controls.Add(this.lblCameraState);
            this.tpDeviceStatus.Location = new System.Drawing.Point(4, 23);
            this.tpDeviceStatus.Name = "tpDeviceStatus";
            this.tpDeviceStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tpDeviceStatus.Size = new System.Drawing.Size(916, 94);
            this.tpDeviceStatus.TabIndex = 1;
            this.tpDeviceStatus.Text = "Trạng thái thiết bị";
            this.tpDeviceStatus.UseVisualStyleBackColor = true;
            // 
            // lblReaderState
            // 
            this.lblReaderState.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReaderState.Location = new System.Drawing.Point(136, 43);
            this.lblReaderState.Name = "lblReaderState";
            this.lblReaderState.Size = new System.Drawing.Size(175, 25);
            this.lblReaderState.State = sAccessControl.Enums.DeviceState.NotUsed;
            this.lblReaderState.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Đầu đọc thẻ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Camera chụp hình";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCameraState
            // 
            this.lblCameraState.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCameraState.Location = new System.Drawing.Point(136, 8);
            this.lblCameraState.Name = "lblCameraState";
            this.lblCameraState.Size = new System.Drawing.Size(175, 25);
            this.lblCameraState.State = sAccessControl.Enums.DeviceState.NotUsed;
            this.lblCameraState.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(916, 94);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông Tin";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSubOrgName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFullName, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbStatus, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(910, 88);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(762, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 36);
            this.panel1.TabIndex = 1;
            // 
            // lblTime
            // 
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblTime.Location = new System.Drawing.Point(0, 20);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(144, 20);
            this.lblTime.TabIndex = 32;
            this.lblTime.Text = "HH:mm:ss";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDate.Location = new System.Drawing.Point(0, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(144, 20);
            this.lblDate.TabIndex = 31;
            this.lblDate.Text = "dd/MM/yyyy";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(4, 44);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Size = new System.Drawing.Size(145, 43);
            this.label7.TabIndex = 23;
            this.label7.Text = "Căn hộ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(4, 1);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Size = new System.Drawing.Size(145, 42);
            this.label3.TabIndex = 19;
            this.label3.Text = "Mã thành viên";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(307, 1);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Size = new System.Drawing.Size(145, 42);
            this.label4.TabIndex = 20;
            this.label4.Text = "Họ và tên";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(307, 44);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Size = new System.Drawing.Size(145, 43);
            this.label6.TabIndex = 22;
            this.label6.Text = "Nợ phí";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCode
            // 
            this.lblCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblCode.Location = new System.Drawing.Point(156, 1);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(144, 42);
            this.lblCode.TabIndex = 25;
            this.lblCode.Text = "NV6789";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubOrgName
            // 
            this.lblSubOrgName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSubOrgName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubOrgName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblSubOrgName.Location = new System.Drawing.Point(156, 44);
            this.lblSubOrgName.Name = "lblSubOrgName";
            this.lblSubOrgName.Size = new System.Drawing.Size(144, 43);
            this.lblSubOrgName.TabIndex = 26;
            this.lblSubOrgName.Text = "PHÒNG KĨ THUẬT CÔNG NGHỆ";
            this.lblSubOrgName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFullName
            // 
            this.lblFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFullName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblFullName.Location = new System.Drawing.Point(459, 1);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(144, 42);
            this.lblFullName.TabIndex = 27;
            this.lblFullName.Text = "NGUYỄN CÔNG CHÍNH";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(610, 1);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Size = new System.Drawing.Size(145, 41);
            this.label8.TabIndex = 24;
            this.label8.Text = "Ngày giờ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(610, 44);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Size = new System.Drawing.Size(145, 42);
            this.label5.TabIndex = 29;
            this.label5.Text = "Tình trạng";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbStatus
            // 
            this.lbStatus.BackColor = System.Drawing.Color.Teal;
            this.lbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.White;
            this.lbStatus.Location = new System.Drawing.Point(762, 44);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStatus.Size = new System.Drawing.Size(144, 43);
            this.lbStatus.TabIndex = 30;
            this.lbStatus.Text = "ĐÃ VÀO";
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbWaterCost);
            this.panel5.Controls.Add(this.lbManagerCost);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(459, 47);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(144, 37);
            this.panel5.TabIndex = 31;
            // 
            // lbWaterCost
            // 
            this.lbWaterCost.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbWaterCost.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWaterCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lbWaterCost.Location = new System.Drawing.Point(0, 20);
            this.lbWaterCost.Name = "lbWaterCost";
            this.lbWaterCost.Size = new System.Drawing.Size(144, 20);
            this.lbWaterCost.TabIndex = 32;
            this.lbWaterCost.Text = "Tiền nước: 300.000";
            this.lbWaterCost.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbManagerCost
            // 
            this.lbManagerCost.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbManagerCost.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbManagerCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lbManagerCost.Location = new System.Drawing.Point(0, 0);
            this.lbManagerCost.Name = "lbManagerCost";
            this.lbManagerCost.Size = new System.Drawing.Size(144, 20);
            this.lbManagerCost.TabIndex = 31;
            this.lbManagerCost.Text = "Phí quản lý: 5.000.000";
            this.lbManagerCost.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tpDeviceStatus);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 427);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(924, 121);
            this.tabControl1.TabIndex = 80;
            // 
            // commonToolStrip1
            // 
            this.commonToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commonToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbmLogout});
            this.commonToolStrip1.Location = new System.Drawing.Point(0, 402);
            this.commonToolStrip1.Name = "commonToolStrip1";
            this.commonToolStrip1.Size = new System.Drawing.Size(924, 25);
            this.commonToolStrip1.TabIndex = 85;
            this.commonToolStrip1.Text = "tlstripListGroup";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.plCamera);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(924, 402);
            this.panel3.TabIndex = 86;
            // 
            // plCamera
            // 
            this.plCamera.Controls.Add(this.cameraCanvas);
            this.plCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plCamera.Location = new System.Drawing.Point(0, 0);
            this.plCamera.Name = "plCamera";
            this.plCamera.Size = new System.Drawing.Size(654, 402);
            this.plCamera.TabIndex = 85;
            // 
            // cameraCanvas
            // 
            this.cameraCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraCanvas.Location = new System.Drawing.Point(0, 0);
            this.cameraCanvas.Name = "cameraCanvas";
            this.cameraCanvas.Size = new System.Drawing.Size(654, 402);
            this.cameraCanvas.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trvDeviceList);
            this.panel2.Controls.Add(this.tsmOrg);
            this.panel2.Controls.Add(this.lblRightAreaTitleListCard);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(654, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 402);
            this.panel2.TabIndex = 84;
            // 
            // trvDeviceList
            // 
            this.trvDeviceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvDeviceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDeviceList.Location = new System.Drawing.Point(0, 55);
            this.trvDeviceList.Name = "trvDeviceList";
            this.trvDeviceList.Size = new System.Drawing.Size(270, 347);
            this.trvDeviceList.TabIndex = 67;
            // 
            // tsmOrg
            // 
            this.tsmOrg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReloadDevice});
            this.tsmOrg.Location = new System.Drawing.Point(0, 30);
            this.tsmOrg.Name = "tsmOrg";
            this.tsmOrg.Size = new System.Drawing.Size(270, 25);
            this.tsmOrg.TabIndex = 66;
            this.tsmOrg.Text = "tlstripListGroup";
            // 
            // btnReloadDevice
            // 
            this.btnReloadDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadDevice.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadDevice.Image")));
            this.btnReloadDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadDevice.Name = "btnReloadDevice";
            this.btnReloadDevice.Size = new System.Drawing.Size(23, 22);
            this.btnReloadDevice.Text = "Tải Dữ Liệu";
            this.btnReloadDevice.ToolTipText = "Tải danh sách thiết bị";
            // 
            // lblRightAreaTitleListCard
            // 
            this.lblRightAreaTitleListCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitleListCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitleListCard.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblRightAreaTitleListCard.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitleListCard.Location = new System.Drawing.Point(0, 0);
            this.lblRightAreaTitleListCard.Name = "lblRightAreaTitleListCard";
            this.lblRightAreaTitleListCard.Size = new System.Drawing.Size(270, 30);
            this.lblRightAreaTitleListCard.TabIndex = 65;
            this.lblRightAreaTitleListCard.Text = "DANH SÁCH THIẾT BỊ";
            this.lblRightAreaTitleListCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tsbmLogout
            // 
            this.tsbmLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbmLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbmLogout.Image = ((System.Drawing.Image)(resources.GetObject("tsbmLogout.Image")));
            this.tsbmLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbmLogout.Name = "tsbmLogout";
            this.tsbmLogout.Size = new System.Drawing.Size(64, 22);
            this.tsbmLogout.Text = "Đăng xuất";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 570);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.commonToolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Vào/Ra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tpDeviceStatus.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.commonToolStrip1.ResumeLayout(false);
            this.commonToolStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.plCamera.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tsmOrg.ResumeLayout(false);
            this.tsmOrg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel ttlbUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ttlbTime;
        private System.Windows.Forms.TabPage tpDeviceStatus;
        private View.UsrDeviceStatus lblReaderState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private View.UsrDeviceStatus lblCameraState;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblSubOrgName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbWaterCost;
        private System.Windows.Forms.Label lbManagerCost;
        private System.Windows.Forms.TabControl tabControl1;
        private CommonControls.Custom.CommonToolStrip commonToolStrip1;
        private System.Windows.Forms.ToolStripButton tsbmLogout;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel plCamera;
        private View.UsrCameraCanvas cameraCanvas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView trvDeviceList;
        private CommonControls.Custom.CommonToolStrip tsmOrg;
        private System.Windows.Forms.ToolStripButton btnReloadDevice;
        private CommonControls.Custom.TitleLabel lblRightAreaTitleListCard;

    }
}

