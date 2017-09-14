namespace AttendanceComponent.WorkItems
{
    partial class UcAttendanceHistory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcAttendanceHistory));
            this.lblRightAreaTitleListAttendace = new CommonControls.Custom.TitleLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvAttendanceList = new CommonControls.Custom.CommonDataGridView();
            this.colAttendanceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImageIn = new System.Windows.Forms.DataGridViewImageColumn();
            this.colImageOut = new System.Windows.Forms.DataGridViewImageColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.dtpDateIn = new System.Windows.Forms.DateTimePicker();
            this.cbxLoadImage = new System.Windows.Forms.CheckBox();
            this.tbxSerialNumber = new System.Windows.Forms.TextBox();
            this.cbxFilterByDate = new System.Windows.Forms.CheckBox();
            this.cbxFilterBySerialNumber = new System.Windows.Forms.CheckBox();
            this.tsmCard = new CommonControls.Custom.CommonToolStrip();
            this.btnSendSms = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHideFilter = new System.Windows.Forms.ToolStripButton();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnReloadCards = new System.Windows.Forms.ToolStripButton();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.cmsAttendanceRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniSendSMS = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceList)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.tsmCard.SuspendLayout();
            this.cmsAttendanceRecord.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRightAreaTitleListAttendace
            // 
            this.lblRightAreaTitleListAttendace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitleListAttendace.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitleListAttendace.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblRightAreaTitleListAttendace.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitleListAttendace.Location = new System.Drawing.Point(5, 5);
            this.lblRightAreaTitleListAttendace.Name = "lblRightAreaTitleListAttendace";
            this.lblRightAreaTitleListAttendace.Size = new System.Drawing.Size(756, 30);
            this.lblRightAreaTitleListAttendace.TabIndex = 64;
            this.lblRightAreaTitleListAttendace.Text = "THỐNG KÊ VÀO/RA";
            this.lblRightAreaTitleListAttendace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 540);
            this.panel1.TabIndex = 65;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel2.Size = new System.Drawing.Size(754, 538);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvAttendanceList);
            this.panel3.Controls.Add(this.pnlFilterBox);
            this.panel3.Controls.Add(this.tsmCard);
            this.panel3.Controls.Add(this.pagerPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(744, 530);
            this.panel3.TabIndex = 0;
            // 
            // dgvAttendanceList
            // 
            this.dgvAttendanceList.AllowUserToAddRows = false;
            this.dgvAttendanceList.AllowUserToDeleteRows = false;
            this.dgvAttendanceList.AllowUserToOrderColumns = true;
            this.dgvAttendanceList.AllowUserToResizeRows = false;
            this.dgvAttendanceList.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendanceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAttendanceList.ColumnHeadersHeight = 26;
            this.dgvAttendanceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAttendanceId,
            this.colMemberId,
            this.colSerialNumber,
            this.colMemberCode,
            this.colMemberFullName,
            this.colDateIn,
            this.colDateOut,
            this.colImageIn,
            this.colImageOut,
            this.colBlank});
            this.dgvAttendanceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttendanceList.Location = new System.Drawing.Point(0, 117);
            this.dgvAttendanceList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAttendanceList.Name = "dgvAttendanceList";
            this.dgvAttendanceList.ReadOnly = true;
            this.dgvAttendanceList.RowHeadersVisible = false;
            this.dgvAttendanceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendanceList.Size = new System.Drawing.Size(742, 391);
            this.dgvAttendanceList.TabIndex = 92;
            // 
            // colAttendanceId
            // 
            this.colAttendanceId.DataPropertyName = "AttendanceId";
            this.colAttendanceId.HeaderText = "AttendanceId";
            this.colAttendanceId.Name = "colAttendanceId";
            this.colAttendanceId.ReadOnly = true;
            this.colAttendanceId.Visible = false;
            // 
            // colMemberId
            // 
            this.colMemberId.DataPropertyName = "MemberId";
            this.colMemberId.HeaderText = "MemberId";
            this.colMemberId.Name = "colMemberId";
            this.colMemberId.ReadOnly = true;
            this.colMemberId.Visible = false;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.DataPropertyName = "SerialNumber";
            this.colSerialNumber.HeaderText = "Mã Thẻ";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            // 
            // colMemberCode
            // 
            this.colMemberCode.DataPropertyName = "MemberCode";
            this.colMemberCode.HeaderText = "Mã Thành Viên";
            this.colMemberCode.Name = "colMemberCode";
            this.colMemberCode.ReadOnly = true;
            // 
            // colMemberFullName
            // 
            this.colMemberFullName.DataPropertyName = "MemberFullName";
            this.colMemberFullName.HeaderText = "Họ Và Tên";
            this.colMemberFullName.Name = "colMemberFullName";
            this.colMemberFullName.ReadOnly = true;
            this.colMemberFullName.Width = 150;
            // 
            // colDateIn
            // 
            this.colDateIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDateIn.DataPropertyName = "DateIn";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDateIn.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDateIn.HeaderText = "Ngày giờ vào";
            this.colDateIn.Name = "colDateIn";
            this.colDateIn.ReadOnly = true;
            this.colDateIn.Width = 106;
            // 
            // colDateOut
            // 
            this.colDateOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDateOut.DataPropertyName = "DateOut";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDateOut.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDateOut.HeaderText = "Ngày Giờ Ra";
            this.colDateOut.Name = "colDateOut";
            this.colDateOut.ReadOnly = true;
            this.colDateOut.Width = 102;
            // 
            // colImageIn
            // 
            this.colImageIn.DataPropertyName = "colImageIn";
            this.colImageIn.HeaderText = "Ảnh Vào";
            this.colImageIn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colImageIn.Name = "colImageIn";
            this.colImageIn.ReadOnly = true;
            this.colImageIn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colImageOut
            // 
            this.colImageOut.DataPropertyName = "colImageOut";
            this.colImageOut.HeaderText = "Ảnh Ra";
            this.colImageOut.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colImageOut.Name = "colImageOut";
            this.colImageOut.ReadOnly = true;
            this.colImageOut.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colBlank
            // 
            this.colBlank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBlank.DataPropertyName = "Blank";
            this.colBlank.HeaderText = "";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilterBox.Controls.Add(this.dtpDateIn);
            this.pnlFilterBox.Controls.Add(this.cbxLoadImage);
            this.pnlFilterBox.Controls.Add(this.tbxSerialNumber);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByDate);
            this.pnlFilterBox.Controls.Add(this.cbxFilterBySerialNumber);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(742, 92);
            this.pnlFilterBox.TabIndex = 91;
            // 
            // dtpDateIn
            // 
            this.dtpDateIn.CustomFormat = "dd/MM/yyyy";
            this.dtpDateIn.Enabled = false;
            this.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateIn.Location = new System.Drawing.Point(181, 35);
            this.dtpDateIn.Name = "dtpDateIn";
            this.dtpDateIn.Size = new System.Drawing.Size(180, 22);
            this.dtpDateIn.TabIndex = 70;
            // 
            // cbxLoadImage
            // 
            this.cbxLoadImage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cbxLoadImage.Location = new System.Drawing.Point(5, 62);
            this.cbxLoadImage.Name = "cbxLoadImage";
            this.cbxLoadImage.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.cbxLoadImage.Size = new System.Drawing.Size(732, 25);
            this.cbxLoadImage.TabIndex = 69;
            this.cbxLoadImage.Text = "Tải trước hình vào/ra (tùy chọn này sẽ làm chậm tốc độ tải dữ liệu)";
            this.cbxLoadImage.UseVisualStyleBackColor = true;
            // 
            // tbxSerialNumber
            // 
            this.tbxSerialNumber.Enabled = false;
            this.tbxSerialNumber.Location = new System.Drawing.Point(181, 8);
            this.tbxSerialNumber.Name = "tbxSerialNumber";
            this.tbxSerialNumber.Size = new System.Drawing.Size(180, 22);
            this.tbxSerialNumber.TabIndex = 66;
            // 
            // cbxFilterByDate
            // 
            this.cbxFilterByDate.Location = new System.Drawing.Point(8, 34);
            this.cbxFilterByDate.Name = "cbxFilterByDate";
            this.cbxFilterByDate.Size = new System.Drawing.Size(167, 20);
            this.cbxFilterByDate.TabIndex = 13;
            this.cbxFilterByDate.Text = "Lọc theo ngày:";
            this.cbxFilterByDate.UseVisualStyleBackColor = true;
            this.cbxFilterByDate.CheckedChanged += new System.EventHandler(this.cbxFilterByDate_CheckedChanged);
            // 
            // cbxFilterBySerialNumber
            // 
            this.cbxFilterBySerialNumber.Location = new System.Drawing.Point(8, 8);
            this.cbxFilterBySerialNumber.Name = "cbxFilterBySerialNumber";
            this.cbxFilterBySerialNumber.Size = new System.Drawing.Size(167, 20);
            this.cbxFilterBySerialNumber.TabIndex = 10;
            this.cbxFilterBySerialNumber.Text = "Lọc theo mã thẻ:";
            this.cbxFilterBySerialNumber.UseVisualStyleBackColor = true;
            this.cbxFilterBySerialNumber.CheckedChanged += new System.EventHandler(this.cbxFilterBySerialNumber_CheckedChanged);
            // 
            // tsmCard
            // 
            this.tsmCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSendSms,
            this.toolStripSeparator1,
            this.btnShowHideFilter,
            this.btnExportToExcel,
            this.btnReloadCards});
            this.tsmCard.Location = new System.Drawing.Point(0, 0);
            this.tsmCard.Name = "tsmCard";
            this.tsmCard.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsmCard.Size = new System.Drawing.Size(742, 25);
            this.tsmCard.TabIndex = 90;
            this.tsmCard.Text = "tlstripListUser";
            // 
            // btnSendSms
            // 
            this.btnSendSms.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSendSms.Image = ((System.Drawing.Image)(resources.GetObject("btnSendSms.Image")));
            this.btnSendSms.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSendSms.Name = "btnSendSms";
            this.btnSendSms.Size = new System.Drawing.Size(23, 22);
            this.btnSendSms.Text = "Nhập Khóa...";
            this.btnSendSms.ToolTipText = "Gửi tin nhắn";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            this.btnExportToExcel.Image = global::AttendanceComponent.Properties.Resources.Excel_16x16;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExportToExcel.Text = "Xuất Ra Excel...";
            this.btnExportToExcel.ToolTipText = "Xuất dữ liệu đang hiển thị ra tập tin excel";
            // 
            // btnReloadCards
            // 
            this.btnReloadCards.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadCards.Image = global::AttendanceComponent.Properties.Resources.Refresh_16x16;
            this.btnReloadCards.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadCards.Name = "btnReloadCards";
            this.btnReloadCards.Size = new System.Drawing.Size(23, 22);
            this.btnReloadCards.Text = "Tải Dữ Liệu";
            this.btnReloadCards.ToolTipText = "Tải danh sách lượt phát hành";
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 508);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(742, 20);
            this.pagerPanel1.TabIndex = 89;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "colImageIn";
            this.dataGridViewImageColumn1.HeaderText = "Ảnh Vào";
            this.dataGridViewImageColumn1.Image = global::AttendanceComponent.Properties.Resources.NoImage;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cmsAttendanceRecord
            // 
            this.cmsAttendanceRecord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniSendSMS,
            this.mniViewAttendance});
            this.cmsAttendanceRecord.Name = "contextMenuStrip1";
            this.cmsAttendanceRecord.Size = new System.Drawing.Size(176, 48);
            // 
            // mniSendSMS
            // 
            this.mniSendSMS.Name = "mniSendSMS";
            this.mniSendSMS.Size = new System.Drawing.Size(175, 22);
            this.mniSendSMS.Text = "Gửi Tin Nhắn...";
            // 
            // mniViewAttendance
            // 
            this.mniViewAttendance.Name = "mniViewAttendance";
            this.mniViewAttendance.Size = new System.Drawing.Size(175, 22);
            this.mniViewAttendance.Text = "Xem Lượt Vào/Ra...";
            // 
            // UcAttendanceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblRightAreaTitleListAttendace);
            this.Name = "UcAttendanceHistory";
            this.Size = new System.Drawing.Size(766, 580);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceList)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.tsmCard.ResumeLayout(false);
            this.tsmCard.PerformLayout();
            this.cmsAttendanceRecord.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControls.Custom.TitleLabel lblRightAreaTitleListAttendace;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CommonControls.Custom.CommonDataGridView dgvAttendanceList;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.CheckBox cbxFilterByDate;
        private System.Windows.Forms.CheckBox cbxFilterBySerialNumber;
        private CommonControls.Custom.CommonToolStrip tsmCard;
        private System.Windows.Forms.ToolStripButton btnSendSms;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnShowHideFilter;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripButton btnReloadCards;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private System.Windows.Forms.TextBox tbxSerialNumber;
        private System.Windows.Forms.CheckBox cbxLoadImage;
        private System.Windows.Forms.DateTimePicker dtpDateIn;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAttendanceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateOut;
        private System.Windows.Forms.DataGridViewImageColumn colImageIn;
        private System.Windows.Forms.DataGridViewImageColumn colImageOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
        private System.Windows.Forms.ContextMenuStrip cmsAttendanceRecord;
        private System.Windows.Forms.ToolStripMenuItem mniSendSMS;
        private System.Windows.Forms.ToolStripMenuItem mniViewAttendance;

    }
}
