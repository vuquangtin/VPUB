namespace sTimeKeeping.WorkItems
{
    partial class FrmTimeEvent
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTimeEvent));
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.lblDetail = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label91 = new System.Windows.Forms.Label();
            this.lblRequired = new System.Windows.Forms.Label();
            this.lbNote = new System.Windows.Forms.Label();
            this.lblThemEvent = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvMemberListEvent = new CommonControls.Custom.CommonDataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventMemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCmnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblFilters = new System.Windows.Forms.Label();
            this.btnLoadUpdate = new System.Windows.Forms.Button();
            this.btnDelMemEvent = new System.Windows.Forms.Button();
            this.btnAddMemEvent = new System.Windows.Forms.Button();
            this.label121 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label131 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.numericMinutes = new System.Windows.Forms.NumericUpDown();
            this.label51 = new System.Windows.Forms.Label();
            this.numericHour = new System.Windows.Forms.NumericUpDown();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblTenEvent = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.dtpDateIn = new System.Windows.Forms.DateTimePicker();
            this.lbldateevent = new System.Windows.Forms.Label();
            this.lblHourNumber = new System.Windows.Forms.Label();
            this.lblHourBegin = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.line2 = new CommonControls.Custom.Line();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cmsMemberRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAddMemevent = new System.Windows.Forms.ToolStripMenuItem();
            this.lblInfoAdd = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberListEvent)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHour)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.cmsMemberRecord.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(183, 7);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(150, 22);
            this.tbxCode.TabIndex = 118;
            // 
            // lblDetail
            // 
            this.lblDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetail.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblDetail.Location = new System.Drawing.Point(0, 71);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(821, 24);
            this.lblDetail.TabIndex = 84;
            this.lblDetail.Text = "Thông tin chi tiết:";
            this.lblDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.label91);
            this.panel4.Controls.Add(this.lblRequired);
            this.panel4.Controls.Add(this.lbNote);
            this.panel4.Controls.Add(this.lblThemEvent);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(821, 70);
            this.panel4.TabIndex = 80;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label91.ForeColor = System.Drawing.Color.Red;
            this.label91.Location = new System.Drawing.Point(123, 49);
            this.label91.Margin = new System.Windows.Forms.Padding(3);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(24, 14);
            this.label91.TabIndex = 101;
            this.label91.Text = "(*)";
            // 
            // lblRequired
            // 
            this.lblRequired.AutoSize = true;
            this.lblRequired.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired.Location = new System.Drawing.Point(17, 50);
            this.lblRequired.Margin = new System.Windows.Forms.Padding(3);
            this.lblRequired.Name = "lblRequired";
            this.lblRequired.Size = new System.Drawing.Size(670, 14);
            this.lblRequired.TabIndex = 2;
            this.lblRequired.Text = "Các trường có dấu  *   là trường bắt buộc, các trường không bắt buộc nếu không ch" +
    "ỉnh sửa sẽ tự động chọn mặc định.";
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNote.Location = new System.Drawing.Point(16, 32);
            this.lbNote.Margin = new System.Windows.Forms.Padding(3);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(602, 14);
            this.lbNote.TabIndex = 1;
            this.lbNote.Text = "Thêm hoặc sửa các thông tin lịch họp - công tác - nghỉ phép của nhân viên. Dùng đ" +
    "ể chấm công nhân viên.";
            // 
            // lblThemEvent
            // 
            this.lblThemEvent.AutoSize = true;
            this.lblThemEvent.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThemEvent.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblThemEvent.Location = new System.Drawing.Point(16, 11);
            this.lblThemEvent.Name = "lblThemEvent";
            this.lblThemEvent.Size = new System.Drawing.Size(296, 14);
            this.lblThemEvent.TabIndex = 0;
            this.lblThemEvent.Text = "Thêm thông tin lịch họp - công tác - nghỉ phép";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 95);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
            this.panel3.Size = new System.Drawing.Size(821, 478);
            this.panel3.TabIndex = 86;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnAccept);
            this.panel7.Controls.Add(this.btnReload);
            this.panel7.Controls.Add(this.btnClose);
            this.panel7.Location = new System.Drawing.Point(3, 418);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(815, 54);
            this.panel7.TabIndex = 2;
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(400, 15);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(117, 28);
            this.btnAccept.TabIndex = 125;
            this.btnAccept.Text = "Xác nhận";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReload.Location = new System.Drawing.Point(535, 15);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(117, 28);
            this.btnReload.TabIndex = 126;
            this.btnReload.Text = "Làm mới";
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(673, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 28);
            this.btnClose.TabIndex = 127;
            this.btnClose.Text = "Hủy bỏ";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvMemberListEvent);
            this.panel6.Location = new System.Drawing.Point(3, 164);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(815, 248);
            this.panel6.TabIndex = 1;
            // 
            // dgvMemberListEvent
            // 
            this.dgvMemberListEvent.AllowUserToAddRows = false;
            this.dgvMemberListEvent.AllowUserToDeleteRows = false;
            this.dgvMemberListEvent.AllowUserToOrderColumns = true;
            this.dgvMemberListEvent.AllowUserToResizeRows = false;
            this.dgvMemberListEvent.BackgroundColor = System.Drawing.Color.White;
            this.dgvMemberListEvent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMemberListEvent.ColumnHeadersHeight = 26;
            this.dgvMemberListEvent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colEventMemberId,
            this.colCode,
            this.colName,
            this.colPhone,
            this.colCmnd,
            this.colEmail});
            this.dgvMemberListEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMemberListEvent.Location = new System.Drawing.Point(0, 0);
            this.dgvMemberListEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMemberListEvent.Name = "dgvMemberListEvent";
            this.dgvMemberListEvent.ReadOnly = true;
            this.dgvMemberListEvent.RowHeadersVisible = false;
            this.dgvMemberListEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMemberListEvent.Size = new System.Drawing.Size(815, 248);
            this.dgvMemberListEvent.TabIndex = 124;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "colId";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 125;
            // 
            // colEventMemberId
            // 
            this.colEventMemberId.DataPropertyName = "colEventMemberId";
            this.colEventMemberId.HeaderText = "eventMemberId";
            this.colEventMemberId.Name = "colEventMemberId";
            this.colEventMemberId.ReadOnly = true;
            this.colEventMemberId.Visible = false;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "colCode";
            this.colCode.HeaderText = "Mã Thành viên";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 120;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "colName";
            this.colName.HeaderText = "Tên Thành viên";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // colPhone
            // 
            this.colPhone.DataPropertyName = "colPhone";
            this.colPhone.HeaderText = "Số Điện Thoại";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            this.colPhone.Width = 180;
            // 
            // colCmnd
            // 
            this.colCmnd.DataPropertyName = "colCmnd";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCmnd.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCmnd.HeaderText = "Số CMND";
            this.colCmnd.Name = "colCmnd";
            this.colCmnd.ReadOnly = true;
            this.colCmnd.Width = 140;
            // 
            // colEmail
            // 
            this.colEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEmail.DataPropertyName = "colEmail";
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 164);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel10);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(822, 163);
            this.panel5.TabIndex = 11;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.lblFilters);
            this.panel10.Controls.Add(this.btnLoadUpdate);
            this.panel10.Controls.Add(this.btnDelMemEvent);
            this.panel10.Controls.Add(this.btnAddMemEvent);
            this.panel10.Controls.Add(this.label121);
            this.panel10.Controls.Add(this.lblInfoAdd);
            this.panel10.Controls.Add(this.tbxCode);
            this.panel10.Location = new System.Drawing.Point(3, 105);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(814, 56);
            this.panel10.TabIndex = 103;
            // 
            // lblFilters
            // 
            this.lblFilters.AutoSize = true;
            this.lblFilters.Location = new System.Drawing.Point(9, 11);
            this.lblFilters.Name = "lblFilters";
            this.lblFilters.Size = new System.Drawing.Size(151, 16);
            this.lblFilters.TabIndex = 117;
            this.lblFilters.Text = "Lọc theo tên người dùng:";
            // 
            // btnLoadUpdate
            // 
            this.btnLoadUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadUpdate.Image")));
            this.btnLoadUpdate.Location = new System.Drawing.Point(686, 28);
            this.btnLoadUpdate.Name = "btnLoadUpdate";
            this.btnLoadUpdate.Size = new System.Drawing.Size(31, 25);
            this.btnLoadUpdate.TabIndex = 121;
            this.btnLoadUpdate.UseVisualStyleBackColor = true;
            this.btnLoadUpdate.Visible = false;
            this.btnLoadUpdate.Click += new System.EventHandler(this.btnLoadUpdate_Click);
            // 
            // btnDelMemEvent
            // 
            this.btnDelMemEvent.Image = ((System.Drawing.Image)(resources.GetObject("btnDelMemEvent.Image")));
            this.btnDelMemEvent.Location = new System.Drawing.Point(768, 28);
            this.btnDelMemEvent.Name = "btnDelMemEvent";
            this.btnDelMemEvent.Size = new System.Drawing.Size(31, 25);
            this.btnDelMemEvent.TabIndex = 123;
            this.btnDelMemEvent.UseVisualStyleBackColor = true;
            this.btnDelMemEvent.Visible = false;
            this.btnDelMemEvent.Click += new System.EventHandler(this.btnDelMemEvent_Click);
            // 
            // btnAddMemEvent
            // 
            this.btnAddMemEvent.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMemEvent.Image")));
            this.btnAddMemEvent.Location = new System.Drawing.Point(727, 28);
            this.btnAddMemEvent.Name = "btnAddMemEvent";
            this.btnAddMemEvent.Size = new System.Drawing.Size(31, 25);
            this.btnAddMemEvent.TabIndex = 122;
            this.btnAddMemEvent.Tag = "";
            this.btnAddMemEvent.UseVisualStyleBackColor = true;
            this.btnAddMemEvent.Visible = false;
            this.btnAddMemEvent.Click += new System.EventHandler(this.btnAddMemEvent_Click);
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label121.ForeColor = System.Drawing.Color.Red;
            this.label121.Location = new System.Drawing.Point(5, 37);
            this.label121.Margin = new System.Windows.Forms.Padding(3);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(24, 14);
            this.label121.TabIndex = 119;
            this.label121.Text = "(*)";
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.label131);
            this.panel8.Controls.Add(this.label81);
            this.panel8.Controls.Add(this.label71);
            this.panel8.Controls.Add(this.numericMinutes);
            this.panel8.Controls.Add(this.label51);
            this.panel8.Controls.Add(this.numericHour);
            this.panel8.Controls.Add(this.tbxName);
            this.panel8.Controls.Add(this.lblTenEvent);
            this.panel8.Controls.Add(this.tbxDescription);
            this.panel8.Controls.Add(this.txtHour);
            this.panel8.Controls.Add(this.lblDescription);
            this.panel8.Controls.Add(this.dtpDateIn);
            this.panel8.Controls.Add(this.lbldateevent);
            this.panel8.Controls.Add(this.lblHourNumber);
            this.panel8.Controls.Add(this.lblHourBegin);
            this.panel8.Location = new System.Drawing.Point(4, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(814, 98);
            this.panel8.TabIndex = 102;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(294, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 14);
            this.label1.TabIndex = 113;
            this.label1.Text = "(*)";
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label131.ForeColor = System.Drawing.Color.Red;
            this.label131.Location = new System.Drawing.Point(462, 11);
            this.label131.Margin = new System.Windows.Forms.Padding(3);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(24, 14);
            this.label131.TabIndex = 107;
            this.label131.Text = "(*)";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.ForeColor = System.Drawing.Color.Red;
            this.label81.Location = new System.Drawing.Point(81, 44);
            this.label81.Margin = new System.Windows.Forms.Padding(3);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(24, 14);
            this.label81.TabIndex = 109;
            this.label81.Text = "(*)";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.ForeColor = System.Drawing.Color.Red;
            this.label71.Location = new System.Drawing.Point(81, 11);
            this.label71.Margin = new System.Windows.Forms.Padding(3);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(24, 14);
            this.label71.TabIndex = 105;
            this.label71.Text = "(*)";
            // 
            // numericMinutes
            // 
            this.numericMinutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numericMinutes.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericMinutes.Location = new System.Drawing.Point(174, 41);
            this.numericMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericMinutes.Name = "numericMinutes";
            this.numericMinutes.Size = new System.Drawing.Size(45, 22);
            this.numericMinutes.TabIndex = 112;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(157, 41);
            this.label51.Margin = new System.Windows.Forms.Padding(3);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(15, 19);
            this.label51.TabIndex = 111;
            this.label51.Text = ":";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericHour
            // 
            this.numericHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numericHour.Location = new System.Drawing.Point(111, 41);
            this.numericHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericHour.Name = "numericHour";
            this.numericHour.Size = new System.Drawing.Size(44, 22);
            this.numericHour.TabIndex = 110;
            // 
            // tbxName
            // 
            this.tbxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbxName.Location = new System.Drawing.Point(111, 9);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(261, 22);
            this.tbxName.TabIndex = 106;
            // 
            // lblTenEvent
            // 
            this.lblTenEvent.AutoSize = true;
            this.lblTenEvent.Location = new System.Drawing.Point(6, 11);
            this.lblTenEvent.Margin = new System.Windows.Forms.Padding(7, 2, 7, 2);
            this.lblTenEvent.Name = "lblTenEvent";
            this.lblTenEvent.Size = new System.Drawing.Size(80, 16);
            this.lblTenEvent.TabIndex = 105;
            this.lblTenEvent.Text = "Tên sự kiện:";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(497, 41);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(302, 43);
            this.tbxDescription.TabIndex = 116;
            // 
            // txtHour
            // 
            this.txtHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtHour.Location = new System.Drawing.Point(334, 41);
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(38, 22);
            this.txtHour.TabIndex = 114;
            this.txtHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNo_KeyPress);
            this.txtHour.Leave += new System.EventHandler(this.txtHour_Leave);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(427, 44);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(7, 2, 7, 2);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(45, 16);
            this.lblDescription.TabIndex = 115;
            this.lblDescription.Text = "Mô tả:";
            // 
            // dtpDateIn
            // 
            this.dtpDateIn.CustomFormat = "dd/MM/yyyy";
            this.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateIn.Location = new System.Drawing.Point(497, 9);
            this.dtpDateIn.Name = "dtpDateIn";
            this.dtpDateIn.Size = new System.Drawing.Size(185, 22);
            this.dtpDateIn.TabIndex = 108;
            // 
            // lbldateevent
            // 
            this.lbldateevent.AutoSize = true;
            this.lbldateevent.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldateevent.Location = new System.Drawing.Point(427, 10);
            this.lbldateevent.Margin = new System.Windows.Forms.Padding(3);
            this.lbldateevent.Name = "lbldateevent";
            this.lbldateevent.Size = new System.Drawing.Size(38, 14);
            this.lbldateevent.TabIndex = 107;
            this.lbldateevent.Text = "Ngày:";
            this.lbldateevent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHourNumber
            // 
            this.lblHourNumber.AutoSize = true;
            this.lblHourNumber.Location = new System.Drawing.Point(251, 44);
            this.lblHourNumber.Margin = new System.Windows.Forms.Padding(7, 2, 7, 2);
            this.lblHourNumber.Name = "lblHourNumber";
            this.lblHourNumber.Size = new System.Drawing.Size(49, 16);
            this.lblHourNumber.TabIndex = 113;
            this.lblHourNumber.Text = "Số giờ:";
            // 
            // lblHourBegin
            // 
            this.lblHourBegin.AutoSize = true;
            this.lblHourBegin.Location = new System.Drawing.Point(8, 44);
            this.lblHourBegin.Margin = new System.Windows.Forms.Padding(7, 2, 7, 2);
            this.lblHourBegin.Name = "lblHourBegin";
            this.lblHourBegin.Size = new System.Drawing.Size(78, 16);
            this.lblHourBegin.TabIndex = 109;
            this.lblHourBegin.Text = "Giờ bắt đầu:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(582, -15);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 14);
            this.label10.TabIndex = 100;
            this.label10.Text = "(*)";
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 71);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlFilterBox.Size = new System.Drawing.Size(821, 502);
            this.pnlFilterBox.TabIndex = 85;
            // 
            // line2
            // 
            this.line2.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line2.Dock = System.Windows.Forms.DockStyle.Top;
            this.line2.Location = new System.Drawing.Point(0, 0);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(821, 1);
            this.line2.TabIndex = 77;
            this.line2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lblDetail);
            this.panel2.Controls.Add(this.pnlFilterBox);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.line2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(823, 575);
            this.panel2.TabIndex = 41;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.panel4);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 1);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(821, 70);
            this.panel9.TabIndex = 80;
            // 
            // cmsMemberRecord
            // 
            this.cmsMemberRecord.Enabled = false;
            this.cmsMemberRecord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAddMemevent});
            this.cmsMemberRecord.Name = "contextMenuStrip1";
            this.cmsMemberRecord.Size = new System.Drawing.Size(227, 26);
            // 
            // mniAddMemevent
            // 
            this.mniAddMemevent.Enabled = false;
            this.mniAddMemevent.Image = ((System.Drawing.Image)(resources.GetObject("mniAddMemevent.Image")));
            this.mniAddMemevent.Name = "mniAddMemevent";
            this.mniAddMemevent.Size = new System.Drawing.Size(226, 22);
            this.mniAddMemevent.Text = "Thêm thành viên vào sự kiện";
            this.mniAddMemevent.Click += new System.EventHandler(this.mniAddMemevent_Click);
            // 
            // lblInfoAdd
            // 
            this.lblInfoAdd.AutoSize = true;
            this.lblInfoAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoAdd.Location = new System.Drawing.Point(26, 37);
            this.lblInfoAdd.Margin = new System.Windows.Forms.Padding(3);
            this.lblInfoAdd.Name = "lblInfoAdd";
            this.lblInfoAdd.Size = new System.Drawing.Size(462, 14);
            this.lblInfoAdd.TabIndex = 120;
            this.lblInfoAdd.Text = "Chọn người tham gia sự kiện. Nhấn giữ phím Ctrl để chọn nhiều người cho sự kiện.";
            // 
            // FrmTimeEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 575);
            this.Controls.Add(this.panel2);
            this.Name = "FrmTimeEvent";
            this.Text = "Thêm sự kiện";
            this.Load += new System.EventHandler(this.FrmTimeEvent_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberListEvent)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHour)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.cmsMemberRecord.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label lblRequired;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Label lblThemEvent;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label131;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.NumericUpDown numericMinutes;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.NumericUpDown numericHour;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label lblTenEvent;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.TextBox txtHour;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lbldateevent;
        private System.Windows.Forms.Label lblHourNumber;
        private System.Windows.Forms.Label lblHourBegin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlFilterBox;
        private CommonControls.Custom.Line line2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ContextMenuStrip cmsMemberRecord;
        private System.Windows.Forms.ToolStripMenuItem mniAddMemevent;
        private System.Windows.Forms.Button btnDelMemEvent;
        private System.Windows.Forms.Button btnAddMemEvent;
        private System.Windows.Forms.Button btnLoadUpdate;
        private System.Windows.Forms.Label lblFilters;
        private CommonControls.Custom.CommonDataGridView dgvMemberListEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventMemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCmnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateIn;
        private System.Windows.Forms.Label lblInfoAdd;
    }
}