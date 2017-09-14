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
            this.panel3 = new System.Windows.Forms.Panel();
            this.plCamera = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trvDeviceList = new System.Windows.Forms.TreeView();
            this.tsmOrg = new CommonControls.Custom.CommonToolStrip();
            this.btnReloadDevice = new System.Windows.Forms.ToolStripButton();
            this.lblRightAreaTitleListCard = new CommonControls.Custom.TitleLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.plMemberInfo = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSubOrgName = new System.Windows.Forms.Label();
            this.titleLabel2 = new CommonControls.Custom.TitleLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.titleLabel3 = new CommonControls.Custom.TitleLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbDatePayment = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbManagerCostOld = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbManagerCost = new System.Windows.Forms.Label();
            this.lbWaterCost = new System.Windows.Forms.Label();
            this.titleLabel1 = new CommonControls.Custom.TitleLabel();
            this.commonToolStrip1 = new CommonControls.Custom.CommonToolStrip();
            this.tsbmLogout = new System.Windows.Forms.ToolStripButton();
            this.cameraCanvas = new sAccessControl.View.UsrCameraCanvas();
            this.statusStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.plCamera.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tsmOrg.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.plMemberInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.commonToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 600000;
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
            this.toolStripStatusLabel1.Visible = false;
            // 
            // ttlbTime
            // 
            this.ttlbTime.BackColor = System.Drawing.SystemColors.Control;
            this.ttlbTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ttlbTime.Name = "ttlbTime";
            this.ttlbTime.Size = new System.Drawing.Size(63, 17);
            this.ttlbTime.Text = "HH:mm:ss";
            this.ttlbTime.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.plCamera);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(924, 0);
            this.panel3.TabIndex = 86;
            // 
            // plCamera
            // 
            this.plCamera.Controls.Add(this.cameraCanvas);
            this.plCamera.Location = new System.Drawing.Point(0, 0);
            this.plCamera.Name = "plCamera";
            this.plCamera.Size = new System.Drawing.Size(654, 119);
            this.plCamera.TabIndex = 85;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trvDeviceList);
            this.panel2.Controls.Add(this.tsmOrg);
            this.panel2.Controls.Add(this.lblRightAreaTitleListCard);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(654, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 0);
            this.panel2.TabIndex = 84;
            // 
            // trvDeviceList
            // 
            this.trvDeviceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvDeviceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDeviceList.Location = new System.Drawing.Point(0, 55);
            this.trvDeviceList.Name = "trvDeviceList";
            this.trvDeviceList.Size = new System.Drawing.Size(270, 0);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(924, 523);
            this.tabControl1.TabIndex = 87;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.plMemberInfo);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage1.Size = new System.Drawing.Size(916, 496);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông Tin";
            // 
            // plMemberInfo
            // 
            this.plMemberInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plMemberInfo.Controls.Add(this.tableLayoutPanel1);
            this.plMemberInfo.Controls.Add(this.titleLabel2);
            this.plMemberInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMemberInfo.Location = new System.Drawing.Point(315, 5);
            this.plMemberInfo.Name = "plMemberInfo";
            this.plMemberInfo.Size = new System.Drawing.Size(286, 486);
            this.plMemberInfo.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbEmail, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblCode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbPhone, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFullName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSubOrgName, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 210);
            this.tableLayoutPanel1.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(5, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 40);
            this.label3.TabIndex = 20;
            this.label3.Text = "Mã thành viên";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.BackColor = System.Drawing.Color.White;
            this.lbEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbEmail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lbEmail.Location = new System.Drawing.Point(160, 170);
            this.lbEmail.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(119, 40);
            this.lbEmail.TabIndex = 38;
            this.lbEmail.Text = "chinh.nguyen@smartworld.com.vn";
            this.lbEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.BackColor = System.Drawing.Color.White;
            this.lblCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblCode.Location = new System.Drawing.Point(160, 2);
            this.lblCode.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(119, 40);
            this.lblCode.TabIndex = 26;
            this.lblCode.Text = "NV6789";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(5, 170);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 40);
            this.label2.TabIndex = 36;
            this.label2.Text = "Email";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.BackColor = System.Drawing.Color.White;
            this.lbPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPhone.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lbPhone.Location = new System.Drawing.Point(160, 128);
            this.lbPhone.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(119, 40);
            this.lbPhone.TabIndex = 37;
            this.lbPhone.Text = "0168 2150 463";
            this.lbPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.BackColor = System.Drawing.Color.White;
            this.lblFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFullName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblFullName.Location = new System.Drawing.Point(160, 44);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(119, 40);
            this.lblFullName.TabIndex = 27;
            this.lblFullName.Text = "NGUYỄN CÔNG CHÍNH";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(5, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Size = new System.Drawing.Size(145, 40);
            this.label4.TabIndex = 20;
            this.label4.Text = "Họ và tên";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(5, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 40);
            this.label1.TabIndex = 35;
            this.label1.Text = "Số điện thoại";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(5, 86);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 40);
            this.label7.TabIndex = 23;
            this.label7.Text = "Căn hộ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubOrgName
            // 
            this.lblSubOrgName.AutoSize = true;
            this.lblSubOrgName.BackColor = System.Drawing.Color.White;
            this.lblSubOrgName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSubOrgName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubOrgName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblSubOrgName.Location = new System.Drawing.Point(160, 86);
            this.lblSubOrgName.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.lblSubOrgName.Name = "lblSubOrgName";
            this.lblSubOrgName.Size = new System.Drawing.Size(119, 40);
            this.lblSubOrgName.TabIndex = 26;
            this.lblSubOrgName.Text = "PHÒNG KĨ THUẬT CÔNG NGHỆ";
            this.lblSubOrgName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // titleLabel2
            // 
            this.titleLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.titleLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel2.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.titleLabel2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.titleLabel2.Location = new System.Drawing.Point(0, 0);
            this.titleLabel2.Name = "titleLabel2";
            this.titleLabel2.Size = new System.Drawing.Size(284, 30);
            this.titleLabel2.TabIndex = 34;
            this.titleLabel2.Text = "THÔNG TIN THÀNH VIÊN";
            this.titleLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Controls.Add(this.titleLabel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(601, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(310, 486);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbStatus, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 30);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(303, 84);
            this.tableLayoutPanel3.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(5, 2);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 40);
            this.label8.TabIndex = 24;
            this.label8.Text = "Ngày giờ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(5, 44);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 40);
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
            this.lbStatus.Location = new System.Drawing.Point(158, 42);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStatus.Size = new System.Drawing.Size(142, 42);
            this.lbStatus.TabIndex = 30;
            this.lbStatus.Text = "ĐÃ VÀO";
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.lblDate, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblTime, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(158, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(142, 36);
            this.tableLayoutPanel4.TabIndex = 31;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.White;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDate.Location = new System.Drawing.Point(5, 2);
            this.lblDate.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(132, 16);
            this.lblDate.TabIndex = 31;
            this.lblDate.Text = "dd/MM/yyyy";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.White;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblTime.Location = new System.Drawing.Point(5, 20);
            this.lblTime.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(132, 16);
            this.lblTime.TabIndex = 32;
            this.lblTime.Text = "HH:mm:ss";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // titleLabel3
            // 
            this.titleLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.titleLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel3.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.titleLabel3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.titleLabel3.Location = new System.Drawing.Point(5, 0);
            this.titleLabel3.Name = "titleLabel3";
            this.titleLabel3.Size = new System.Drawing.Size(303, 30);
            this.titleLabel3.TabIndex = 34;
            this.titleLabel3.Text = "TÌNH TRẠNG";
            this.titleLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.tableLayoutPanel2);
            this.panel4.Controls.Add(this.titleLabel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(5, 5);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.panel4.Size = new System.Drawing.Size(310, 486);
            this.panel4.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lbDatePayment, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbManagerCostOld, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbManagerCost, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbWaterCost, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(303, 168);
            this.tableLayoutPanel2.TabIndex = 37;
            // 
            // lbDatePayment
            // 
            this.lbDatePayment.AutoSize = true;
            this.lbDatePayment.BackColor = System.Drawing.Color.White;
            this.lbDatePayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDatePayment.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDatePayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lbDatePayment.Location = new System.Drawing.Point(160, 128);
            this.lbDatePayment.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.lbDatePayment.Name = "lbDatePayment";
            this.lbDatePayment.Size = new System.Drawing.Size(138, 40);
            this.lbDatePayment.TabIndex = 38;
            this.lbDatePayment.Text = "21-12-2015";
            this.lbDatePayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Location = new System.Drawing.Point(5, 128);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 40);
            this.label11.TabIndex = 37;
            this.label11.Text = "Ngày nợ phí";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 37);
            this.label6.TabIndex = 22;
            this.label6.Text = "Nợ phí quản lý";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Salmon;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(5, 86);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 40);
            this.label10.TabIndex = 35;
            this.label10.Text = "Nợ phí quản lý cũ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbManagerCostOld
            // 
            this.lbManagerCostOld.AutoSize = true;
            this.lbManagerCostOld.BackColor = System.Drawing.Color.White;
            this.lbManagerCostOld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbManagerCostOld.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbManagerCostOld.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lbManagerCostOld.Location = new System.Drawing.Point(160, 86);
            this.lbManagerCostOld.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.lbManagerCostOld.Name = "lbManagerCostOld";
            this.lbManagerCostOld.Size = new System.Drawing.Size(138, 40);
            this.lbManagerCostOld.TabIndex = 36;
            this.lbManagerCostOld.Text = "300.000";
            this.lbManagerCostOld.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(5, 44);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 40);
            this.label9.TabIndex = 34;
            this.label9.Text = "Nợ tiền nước";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbManagerCost
            // 
            this.lbManagerCost.AutoSize = true;
            this.lbManagerCost.BackColor = System.Drawing.Color.White;
            this.lbManagerCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbManagerCost.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbManagerCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lbManagerCost.Location = new System.Drawing.Point(160, 2);
            this.lbManagerCost.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.lbManagerCost.Name = "lbManagerCost";
            this.lbManagerCost.Size = new System.Drawing.Size(138, 40);
            this.lbManagerCost.TabIndex = 31;
            this.lbManagerCost.Text = "Phí quản lý: 5.000.000";
            this.lbManagerCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbWaterCost
            // 
            this.lbWaterCost.AutoSize = true;
            this.lbWaterCost.BackColor = System.Drawing.Color.White;
            this.lbWaterCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbWaterCost.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWaterCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lbWaterCost.Location = new System.Drawing.Point(160, 44);
            this.lbWaterCost.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.lbWaterCost.Name = "lbWaterCost";
            this.lbWaterCost.Size = new System.Drawing.Size(138, 40);
            this.lbWaterCost.TabIndex = 32;
            this.lbWaterCost.Text = "Tiền nước: 300.000";
            this.lbWaterCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // titleLabel1
            // 
            this.titleLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.titleLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel1.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.titleLabel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.titleLabel1.Location = new System.Drawing.Point(0, 0);
            this.titleLabel1.Name = "titleLabel1";
            this.titleLabel1.Size = new System.Drawing.Size(303, 30);
            this.titleLabel1.TabIndex = 33;
            this.titleLabel1.Text = "THÔNG TIN PHÍ QUẢN LÝ";
            this.titleLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // commonToolStrip1
            // 
            this.commonToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbmLogout});
            this.commonToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.commonToolStrip1.Name = "commonToolStrip1";
            this.commonToolStrip1.Size = new System.Drawing.Size(924, 25);
            this.commonToolStrip1.TabIndex = 85;
            this.commonToolStrip1.Text = "tlstripListGroup";
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
            // cameraCanvas
            // 
            this.cameraCanvas.Location = new System.Drawing.Point(166, 102);
            this.cameraCanvas.Name = "cameraCanvas";
            this.cameraCanvas.Size = new System.Drawing.Size(488, 300);
            this.cameraCanvas.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 570);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.commonToolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Vào/Ra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.plCamera.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tsmOrg.ResumeLayout(false);
            this.tsmOrg.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.plMemberInfo.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.commonToolStrip1.ResumeLayout(false);
            this.commonToolStrip1.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel plMemberInfo;
        private CommonControls.Custom.TitleLabel titleLabel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSubOrgName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private CommonControls.Custom.TitleLabel titleLabel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbManagerCostOld;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private CommonControls.Custom.TitleLabel titleLabel1;
        private System.Windows.Forms.Label lbWaterCost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbManagerCost;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbDatePayment;
        private System.Windows.Forms.Label label11;

    }
}

