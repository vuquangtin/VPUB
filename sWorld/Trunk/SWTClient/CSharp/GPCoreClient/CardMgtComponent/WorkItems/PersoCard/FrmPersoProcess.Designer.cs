namespace CardChipMgtComponent.WorkItems
{
    partial class FrmPersoProcess
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.line1 = new CommonControls.Custom.Line();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblGuiPersoProcess = new System.Windows.Forms.Label();
            this.lblPersoProcess = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvMembers = new CommonControls.Custom.CommonDataGridView();
            this.colMemberId1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrgId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubOrgId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMemberTableDescription = new System.Windows.Forms.Label();
            this.lblListMemberWatingIssueCard = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.lblGuiChooseReader = new System.Windows.Forms.Label();
            this.cmbReaders = new System.Windows.Forms.ComboBox();
            this.lblChooseReader = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnListDevices = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvAppData = new CommonControls.Custom.CommonDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgvResult = new CommonControls.Custom.CommonDataGridView();
            this.colMemberFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblResultListIssue = new System.Windows.Forms.Label();
            this.dtpExpiration = new System.Windows.Forms.DateTimePicker();
            this.cbxExpiration = new System.Windows.Forms.CheckBox();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppData)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Line3DStyle = CommonControls.Custom.Line3DStyle.Inset;
            this.line1.Location = new System.Drawing.Point(0, 75);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(792, 2);
            this.line1.TabIndex = 57;
            this.line1.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lblGuiPersoProcess);
            this.panel9.Controls.Add(this.lblPersoProcess);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(792, 75);
            this.panel9.TabIndex = 56;
            // 
            // lblGuiPersoProcess
            // 
            this.lblGuiPersoProcess.AutoSize = true;
            this.lblGuiPersoProcess.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuiPersoProcess.Location = new System.Drawing.Point(12, 39);
            this.lblGuiPersoProcess.Margin = new System.Windows.Forms.Padding(3);
            this.lblGuiPersoProcess.Name = "lblGuiPersoProcess";
            this.lblGuiPersoProcess.Size = new System.Drawing.Size(555, 14);
            this.lblGuiPersoProcess.TabIndex = 1;
            this.lblGuiPersoProcess.Text = "Quét thẻ để cấp thẻ cho thành viên đang được chọn, đồng thời ghi dữ liệu của thàn" +
    "h viên vào thẻ";
            // 
            // lblPersoProcess
            // 
            this.lblPersoProcess.AutoSize = true;
            this.lblPersoProcess.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersoProcess.Location = new System.Drawing.Point(12, 22);
            this.lblPersoProcess.Name = "lblPersoProcess";
            this.lblPersoProcess.Size = new System.Drawing.Size(156, 14);
            this.lblPersoProcess.TabIndex = 0;
            this.lblPersoProcess.Text = "Cấp Thẻ Cho Thành Viên";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 77);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel1.Size = new System.Drawing.Size(792, 599);
            this.panel1.TabIndex = 58;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(10, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.lblListMemberWatingIssueCard);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.panel7);
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(772, 589);
            this.splitContainer1.SplitterDistance = 237;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvMembers);
            this.panel3.Controls.Add(this.lblMemberTableDescription);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(237, 564);
            this.panel3.TabIndex = 15;
            // 
            // dgvMembers
            // 
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.AllowUserToDeleteRows = false;
            this.dgvMembers.AllowUserToOrderColumns = true;
            this.dgvMembers.AllowUserToResizeRows = false;
            this.dgvMembers.BackgroundColor = System.Drawing.Color.White;
            this.dgvMembers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMembers.ColumnHeadersHeight = 26;
            this.dgvMembers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMemberId1,
            this.colOrgId,
            this.colSubOrgId,
            this.colMemberCode,
            this.colLastName1,
            this.colFirstName});
            this.dgvMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMembers.Location = new System.Drawing.Point(0, 0);
            this.dgvMembers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMembers.MultiSelect = false;
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.RowHeadersVisible = false;
            this.dgvMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.Size = new System.Drawing.Size(235, 502);
            this.dgvMembers.TabIndex = 17;
            // 
            // colMemberId1
            // 
            this.colMemberId1.DataPropertyName = "MemberId";
            this.colMemberId1.HeaderText = "MemberId";
            this.colMemberId1.Name = "colMemberId1";
            this.colMemberId1.ReadOnly = true;
            this.colMemberId1.Visible = false;
            // 
            // colOrgId
            // 
            this.colOrgId.DataPropertyName = "OrgId";
            this.colOrgId.HeaderText = "OrgId";
            this.colOrgId.Name = "colOrgId";
            this.colOrgId.ReadOnly = true;
            this.colOrgId.Visible = false;
            // 
            // colSubOrgId
            // 
            this.colSubOrgId.DataPropertyName = "SubOrgId";
            this.colSubOrgId.HeaderText = "SubOrgId";
            this.colSubOrgId.Name = "colSubOrgId";
            this.colSubOrgId.ReadOnly = true;
            this.colSubOrgId.Visible = false;
            // 
            // colMemberCode
            // 
            this.colMemberCode.DataPropertyName = "MemberCode";
            this.colMemberCode.HeaderText = "Mã NV";
            this.colMemberCode.Name = "colMemberCode";
            this.colMemberCode.ReadOnly = true;
            this.colMemberCode.Width = 65;
            // 
            // colLastName1
            // 
            this.colLastName1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLastName1.DataPropertyName = "LastName";
            this.colLastName1.HeaderText = "Họ";
            this.colLastName1.Name = "colLastName1";
            this.colLastName1.ReadOnly = true;
            // 
            // colFirstName
            // 
            this.colFirstName.DataPropertyName = "FirstName";
            this.colFirstName.HeaderText = "Tên";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.ReadOnly = true;
            this.colFirstName.Width = 75;
            // 
            // lblMemberTableDescription
            // 
            this.lblMemberTableDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMemberTableDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberTableDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMemberTableDescription.Location = new System.Drawing.Point(0, 502);
            this.lblMemberTableDescription.Margin = new System.Windows.Forms.Padding(3);
            this.lblMemberTableDescription.Name = "lblMemberTableDescription";
            this.lblMemberTableDescription.Size = new System.Drawing.Size(235, 60);
            this.lblMemberTableDescription.TabIndex = 16;
            this.lblMemberTableDescription.Text = "Thành viên đang được chọn là thành viên sẽ được cấp thẻ trong lượt kế tiếp. Bạn c" +
    "ũng có thể thay đổi thứ tự thành viên nếu muốn.";
            this.lblMemberTableDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblListMemberWatingIssueCard
            // 
            this.lblListMemberWatingIssueCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListMemberWatingIssueCard.Location = new System.Drawing.Point(0, 0);
            this.lblListMemberWatingIssueCard.Margin = new System.Windows.Forms.Padding(0);
            this.lblListMemberWatingIssueCard.Name = "lblListMemberWatingIssueCard";
            this.lblListMemberWatingIssueCard.Size = new System.Drawing.Size(237, 25);
            this.lblListMemberWatingIssueCard.TabIndex = 14;
            this.lblListMemberWatingIssueCard.Text = "Danh sách thành viên chờ cấp thẻ:";
            this.lblListMemberWatingIssueCard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lblStatus);
            this.panel7.Controls.Add(this.lblCurrentStatus);
            this.panel7.Controls.Add(this.lblGuiChooseReader);
            this.panel7.Controls.Add(this.cmbReaders);
            this.panel7.Controls.Add(this.lblChooseReader);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 398);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(525, 150);
            this.panel7.TabIndex = 37;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(0, 97);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(525, 35);
            this.lblStatus.TabIndex = 38;
            this.lblStatus.Text = "Chưa kết nối với thiết bị đọc";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStatus.Location = new System.Drawing.Point(0, 77);
            this.lblCurrentStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(525, 20);
            this.lblCurrentStatus.TabIndex = 37;
            this.lblCurrentStatus.Text = "Trạng thái hiện tại:";
            // 
            // lblGuiChooseReader
            // 
            this.lblGuiChooseReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGuiChooseReader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuiChooseReader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGuiChooseReader.Location = new System.Drawing.Point(0, 42);
            this.lblGuiChooseReader.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblGuiChooseReader.Name = "lblGuiChooseReader";
            this.lblGuiChooseReader.Size = new System.Drawing.Size(525, 35);
            this.lblGuiChooseReader.TabIndex = 2;
            this.lblGuiChooseReader.Text = "Nếu thiết bị của bạn không được liệt kê trong khung trên, hãy đảm bảo thiết bị đã" +
    " được kết nối đúng cách với máy tính, sau đó, nhấn nút \"Tìm Thiết Bị\".";
            // 
            // cmbReaders
            // 
            this.cmbReaders.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbReaders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReaders.FormattingEnabled = true;
            this.cmbReaders.Location = new System.Drawing.Point(0, 20);
            this.cmbReaders.Name = "cmbReaders";
            this.cmbReaders.Size = new System.Drawing.Size(525, 22);
            this.cmbReaders.TabIndex = 1;
            // 
            // lblChooseReader
            // 
            this.lblChooseReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChooseReader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseReader.Location = new System.Drawing.Point(0, 0);
            this.lblChooseReader.Name = "lblChooseReader";
            this.lblChooseReader.Size = new System.Drawing.Size(525, 20);
            this.lblChooseReader.TabIndex = 0;
            this.lblChooseReader.Text = "Chọn thiết bị đọc thẻ:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnClose);
            this.panel6.Controls.Add(this.btnListDevices);
            this.panel6.Controls.Add(this.btnPause);
            this.panel6.Controls.Add(this.btnStart);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 548);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(525, 41);
            this.panel6.TabIndex = 36;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(425, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 26);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Đóng...";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnListDevices
            // 
            this.btnListDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListDevices.Location = new System.Drawing.Point(319, 8);
            this.btnListDevices.Name = "btnListDevices";
            this.btnListDevices.Size = new System.Drawing.Size(100, 26);
            this.btnListDevices.TabIndex = 29;
            this.btnListDevices.Text = "Tìm Thiết Bị";
            this.btnListDevices.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(213, 8);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(100, 26);
            this.btnPause.TabIndex = 28;
            this.btnPause.Text = "Tạm Ngưng";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(107, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 26);
            this.btnStart.TabIndex = 27;
            this.btnStart.Text = "Bắt Đầu";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvAppData);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 589);
            this.panel2.TabIndex = 27;
            // 
            // dgvAppData
            // 
            this.dgvAppData.AllowUserToAddRows = false;
            this.dgvAppData.AllowUserToDeleteRows = false;
            this.dgvAppData.AllowUserToOrderColumns = true;
            this.dgvAppData.AllowUserToResizeRows = false;
            this.dgvAppData.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAppData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppData.Location = new System.Drawing.Point(0, 25);
            this.dgvAppData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAppData.MultiSelect = false;
            this.dgvAppData.Name = "dgvAppData";
            this.dgvAppData.ReadOnly = true;
            this.dgvAppData.RowHeadersVisible = false;
            this.dgvAppData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppData.Size = new System.Drawing.Size(450, 121);
            this.dgvAppData.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(525, 25);
            this.label1.TabIndex = 32;
            this.label1.Text = "Danh sách ứng dụng:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvResult);
            this.panel5.Controls.Add(this.lblResultListIssue);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(525, 388);
            this.panel5.TabIndex = 39;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 388);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(525, 10);
            this.panel4.TabIndex = 38;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dtpExpiration);
            this.panel8.Controls.Add(this.cbxExpiration);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(523, 24);
            this.panel8.TabIndex = 0;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToOrderColumns = true;
            this.dgvResult.AllowUserToResizeRows = false;
            this.dgvResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMemberFullName,
            this.colSerialNumber,
            this.colCardType,
            this.colResult,
            this.colBlank});
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvResult.Location = new System.Drawing.Point(0, 49);
            this.dgvResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(523, 361);
            this.dgvResult.TabIndex = 32;
            // 
            // colMemberFullName
            // 
            this.colMemberFullName.DataPropertyName = "FullName";
            this.colMemberFullName.HeaderText = "Họ Tên";
            this.colMemberFullName.Name = "colMemberFullName";
            this.colMemberFullName.ReadOnly = true;
            this.colMemberFullName.Width = 150;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.DataPropertyName = "SerialNumber";
            this.colSerialNumber.HeaderText = "Mã Thẻ";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            // 
            // colCardType
            // 
            this.colCardType.DataPropertyName = "CardType";
            this.colCardType.HeaderText = "Loại thẻ";
            this.colCardType.Name = "colCardType";
            this.colCardType.ReadOnly = true;
            // 
            // colResult
            // 
            this.colResult.DataPropertyName = "Result";
            this.colResult.HeaderText = "Kết Quả";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            this.colResult.Width = 300;
            // 
            // colBlank
            // 
            this.colBlank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBlank.HeaderText = "";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            // 
            // lblResultListIssue
            // 
            this.lblResultListIssue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResultListIssue.Location = new System.Drawing.Point(0, 24);
            this.lblResultListIssue.Name = "lblResultListIssue";
            this.lblResultListIssue.Size = new System.Drawing.Size(523, 25);
            this.lblResultListIssue.TabIndex = 33;
            this.lblResultListIssue.Text = "Danh sách kết quả:";
            this.lblResultListIssue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpExpiration
            // 
            this.dtpExpiration.CustomFormat = "dd/MM/yyyy";
            this.dtpExpiration.Enabled = false;
            this.dtpExpiration.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpiration.Location = new System.Drawing.Point(137, 3);
            this.dtpExpiration.Name = "dtpExpiration";
            this.dtpExpiration.Size = new System.Drawing.Size(118, 22);
            this.dtpExpiration.TabIndex = 74;
            // 
            // cbxExpiration
            // 
            this.cbxExpiration.Location = new System.Drawing.Point(6, 3);
            this.cbxExpiration.Name = "cbxExpiration";
            this.cbxExpiration.Size = new System.Drawing.Size(114, 22);
            this.cbxExpiration.TabIndex = 73;
            this.cbxExpiration.Text = "Ngày hết hạn";
            this.cbxExpiration.UseVisualStyleBackColor = true;
            this.cbxExpiration.CheckedChanged += new System.EventHandler(this.cbxExpiration_CheckedChanged);
            // 
            // FrmPersoProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 676);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.MaximizeBox = true;
            this.Name = "FrmPersoProcess";
            this.Text = "Cấp Thẻ Cho Thành Viên";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppData)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblGuiPersoProcess;
        private System.Windows.Forms.Label lblPersoProcess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblListMemberWatingIssueCard;
        private System.Windows.Forms.Panel panel3;
        private CommonControls.Custom.CommonDataGridView dgvMembers;
        private System.Windows.Forms.Label lblMemberTableDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberCode2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Label lblGuiChooseReader;
        private System.Windows.Forms.ComboBox cmbReaders;
        private System.Windows.Forms.Label lblChooseReader;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnListDevices;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberId1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubOrgId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
        private CommonControls.Custom.CommonDataGridView dgvAppData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private CommonControls.Custom.CommonDataGridView dgvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
        private System.Windows.Forms.Label lblResultListIssue;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DateTimePicker dtpExpiration;
        private System.Windows.Forms.CheckBox cbxExpiration;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colMemberId2;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colMemberFullName;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colMemberId1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colMemberCode1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colMemberId2;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colMemberFullName;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colMemberCode2;

    }
}