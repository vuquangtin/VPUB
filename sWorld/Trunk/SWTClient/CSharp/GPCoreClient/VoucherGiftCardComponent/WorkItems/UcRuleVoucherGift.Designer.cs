namespace VoucherGiftCardComponent.WorkItems
{
    partial class UcRuleVoucherGift
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcRuleVoucherGift));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvRulesVoucherGift = new CommonControls.Custom.CommonDataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTypeCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.lblNotification1 = new System.Windows.Forms.Label();
            this.cbxFilterByLocation = new System.Windows.Forms.CheckBox();
            this.cbxFilterByVoucherGift = new System.Windows.Forms.CheckBox();
            this.cbxFilterByTitle = new System.Windows.Forms.CheckBox();
            this.tbxMemberTitle = new System.Windows.Forms.TextBox();
            this.cbTypeCard = new System.Windows.Forms.ComboBox();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.tmsMember = new CommonControls.Custom.CommonToolStrip();
            this.btnAddRule = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpdateRule = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveRule = new System.Windows.Forms.ToolStripButton();
            this.tssAfterPersoButton = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.btnReloadRule = new System.Windows.Forms.ToolStripButton();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.lblRightAreaTitleListCard = new CommonControls.Custom.TitleLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRulesVoucherGift)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.tmsMember.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 432);
            this.panel1.TabIndex = 69;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel2.Size = new System.Drawing.Size(791, 430);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvRulesVoucherGift);
            this.panel3.Controls.Add(this.pnlFilterBox);
            this.panel3.Controls.Add(this.tmsMember);
            this.panel3.Controls.Add(this.pagerPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(781, 422);
            this.panel3.TabIndex = 39;
            // 
            // dgvRulesVoucherGift
            // 
            this.dgvRulesVoucherGift.AllowUserToAddRows = false;
            this.dgvRulesVoucherGift.AllowUserToDeleteRows = false;
            this.dgvRulesVoucherGift.AllowUserToOrderColumns = true;
            this.dgvRulesVoucherGift.AllowUserToResizeRows = false;
            this.dgvRulesVoucherGift.BackgroundColor = System.Drawing.Color.White;
            this.dgvRulesVoucherGift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRulesVoucherGift.ColumnHeadersHeight = 26;
            this.dgvRulesVoucherGift.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colTitle,
            this.colTypeCard,
            this.colLocation,
            this.colGender,
            this.colDateBegin,
            this.colDateEnd,
            this.colDescription,
            this.colBlank});
            this.dgvRulesVoucherGift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRulesVoucherGift.Location = new System.Drawing.Point(0, 125);
            this.dgvRulesVoucherGift.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvRulesVoucherGift.MultiSelect = false;
            this.dgvRulesVoucherGift.Name = "dgvRulesVoucherGift";
            this.dgvRulesVoucherGift.ReadOnly = true;
            this.dgvRulesVoucherGift.RowHeadersVisible = false;
            this.dgvRulesVoucherGift.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRulesVoucherGift.Size = new System.Drawing.Size(779, 275);
            this.dgvRulesVoucherGift.TabIndex = 46;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 20;
            // 
            // colTitle
            // 
            this.colTitle.DataPropertyName = "Title";
            this.colTitle.HeaderText = "Tiêu Đề";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.Width = 200;
            // 
            // colTypeCard
            // 
            this.colTypeCard.DataPropertyName = "TypeCard";
            this.colTypeCard.HeaderText = "Loại Phiếu";
            this.colTypeCard.Name = "colTypeCard";
            this.colTypeCard.ReadOnly = true;
            // 
            // colLocation
            // 
            this.colLocation.DataPropertyName = "Location";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colLocation.DefaultCellStyle = dataGridViewCellStyle1;
            this.colLocation.HeaderText = "Địa Điểm";
            this.colLocation.Name = "colLocation";
            this.colLocation.ReadOnly = true;
            this.colLocation.Width = 150;
            // 
            // colGender
            // 
            this.colGender.DataPropertyName = "Gender";
            this.colGender.HeaderText = "Giới Tính";
            this.colGender.Name = "colGender";
            this.colGender.ReadOnly = true;
            // 
            // colDateBegin
            // 
            this.colDateBegin.DataPropertyName = "DateBegin";
            this.colDateBegin.HeaderText = "Ngày Bắt Đầu";
            this.colDateBegin.Name = "colDateBegin";
            this.colDateBegin.ReadOnly = true;
            this.colDateBegin.Width = 150;
            // 
            // colDateEnd
            // 
            this.colDateEnd.DataPropertyName = "DateEnd";
            this.colDateEnd.HeaderText = "Ngày Kết Thúc";
            this.colDateEnd.Name = "colDateEnd";
            this.colDateEnd.ReadOnly = true;
            this.colDateEnd.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Mô Tả";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colBlank
            // 
            this.colBlank.HeaderText = "colBlank";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            this.colBlank.Visible = false;
            this.colBlank.Width = 5;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.Controls.Add(this.lblNotification1);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByLocation);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByVoucherGift);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByTitle);
            this.pnlFilterBox.Controls.Add(this.tbxMemberTitle);
            this.pnlFilterBox.Controls.Add(this.cbTypeCard);
            this.pnlFilterBox.Controls.Add(this.cbLocation);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(779, 100);
            this.pnlFilterBox.TabIndex = 45;
            // 
            // lblNotification1
            // 
            this.lblNotification1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNotification1.Location = new System.Drawing.Point(358, 6);
            this.lblNotification1.Name = "lblNotification1";
            this.lblNotification1.Size = new System.Drawing.Size(150, 22);
            this.lblNotification1.TabIndex = 163;
            this.lblNotification1.Text = "Vui lòng nhập ít nhất 2 ký tự";
            this.lblNotification1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotification1.Visible = false;
            // 
            // cbxFilterByLocation
            // 
            this.cbxFilterByLocation.AutoSize = true;
            this.cbxFilterByLocation.Location = new System.Drawing.Point(8, 64);
            this.cbxFilterByLocation.Name = "cbxFilterByLocation";
            this.cbxFilterByLocation.Size = new System.Drawing.Size(128, 20);
            this.cbxFilterByLocation.TabIndex = 162;
            this.cbxFilterByLocation.Text = "Lọc theo địa điểm";
            this.cbxFilterByLocation.UseVisualStyleBackColor = true;
            this.cbxFilterByLocation.CheckedChanged += new System.EventHandler(this.cbxFilterByMemberLocation_CheckedChanged);
            // 
            // cbxFilterByVoucherGift
            // 
            this.cbxFilterByVoucherGift.AutoSize = true;
            this.cbxFilterByVoucherGift.Location = new System.Drawing.Point(8, 36);
            this.cbxFilterByVoucherGift.Name = "cbxFilterByVoucherGift";
            this.cbxFilterByVoucherGift.Size = new System.Drawing.Size(134, 20);
            this.cbxFilterByVoucherGift.TabIndex = 147;
            this.cbxFilterByVoucherGift.Text = "Lọc theo loại phiếu";
            this.cbxFilterByVoucherGift.UseVisualStyleBackColor = true;
            this.cbxFilterByVoucherGift.CheckedChanged += new System.EventHandler(this.cbxFilterByMemberVoucherGift_CheckedChanged);
            // 
            // cbxFilterByTitle
            // 
            this.cbxFilterByTitle.AutoSize = true;
            this.cbxFilterByTitle.Location = new System.Drawing.Point(8, 8);
            this.cbxFilterByTitle.Name = "cbxFilterByTitle";
            this.cbxFilterByTitle.Size = new System.Drawing.Size(118, 20);
            this.cbxFilterByTitle.TabIndex = 146;
            this.cbxFilterByTitle.Text = "Lọc theo tiêu đề";
            this.cbxFilterByTitle.UseVisualStyleBackColor = true;
            this.cbxFilterByTitle.CheckedChanged += new System.EventHandler(this.cbxFilterByMemberTitle_CheckedChanged);
            // 
            // tbxMemberTitle
            // 
            this.tbxMemberTitle.Enabled = false;
            this.tbxMemberTitle.Location = new System.Drawing.Point(151, 7);
            this.tbxMemberTitle.Name = "tbxMemberTitle";
            this.tbxMemberTitle.Size = new System.Drawing.Size(201, 22);
            this.tbxMemberTitle.TabIndex = 142;
            // 
            // cbTypeCard
            // 
            this.cbTypeCard.Enabled = false;
            this.cbTypeCard.FormattingEnabled = true;
            this.cbTypeCard.Location = new System.Drawing.Point(151, 35);
            this.cbTypeCard.Name = "cbTypeCard";
            this.cbTypeCard.Size = new System.Drawing.Size(201, 22);
            this.cbTypeCard.TabIndex = 130;
            // 
            // cbLocation
            // 
            this.cbLocation.Enabled = false;
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(151, 63);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(201, 22);
            this.cbLocation.TabIndex = 129;
            // 
            // tmsMember
            // 
            this.tmsMember.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddRule,
            this.toolStripSeparator2,
            this.btnUpdateRule,
            this.btnRemoveRule,
            this.tssAfterPersoButton,
            this.btnShowHide,
            this.btnReloadRule});
            this.tmsMember.Location = new System.Drawing.Point(0, 0);
            this.tmsMember.Name = "tmsMember";
            this.tmsMember.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tmsMember.Size = new System.Drawing.Size(779, 25);
            this.tmsMember.TabIndex = 44;
            this.tmsMember.Text = "toolStrip1";
            // 
            // btnAddRule
            // 
            this.btnAddRule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddRule.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRule.Image")));
            this.btnAddRule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(23, 22);
            this.btnAddRule.Text = "Thêm phiếu Mới...";
            this.btnAddRule.ToolTipText = "Thêm phiếu mới vào hệ thống.";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUpdateRule
            // 
            this.btnUpdateRule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateRule.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateRule.Image")));
            this.btnUpdateRule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateRule.Name = "btnUpdateRule";
            this.btnUpdateRule.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateRule.Text = "Cập Nhật Thông Tin Phiếu...";
            this.btnUpdateRule.ToolTipText = "Cập nhật thông tin phiếu trong hệ thống.";
            // 
            // btnRemoveRule
            // 
            this.btnRemoveRule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveRule.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveRule.Image")));
            this.btnRemoveRule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveRule.Name = "btnRemoveRule";
            this.btnRemoveRule.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveRule.Text = "Hủy Phiếu Khỏi Hệ Thống...";
            this.btnRemoveRule.ToolTipText = "Hủy phiếu khỏi hệ thống";
            // 
            // tssAfterPersoButton
            // 
            this.tssAfterPersoButton.Name = "tssAfterPersoButton";
            this.tssAfterPersoButton.Size = new System.Drawing.Size(6, 25);
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
            // btnReloadRule
            // 
            this.btnReloadRule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadRule.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadRule.Image")));
            this.btnReloadRule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadRule.Name = "btnReloadRule";
            this.btnReloadRule.Size = new System.Drawing.Size(23, 22);
            this.btnReloadRule.Text = "Tải Dữ Liệu";
            this.btnReloadRule.ToolTipText = "Tải danh sách phiếu";
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 400);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(779, 20);
            this.pagerPanel1.TabIndex = 40;
            // 
            // lblRightAreaTitleListCard
            // 
            this.lblRightAreaTitleListCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitleListCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitleListCard.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblRightAreaTitleListCard.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitleListCard.Location = new System.Drawing.Point(6, 5);
            this.lblRightAreaTitleListCard.Name = "lblRightAreaTitleListCard";
            this.lblRightAreaTitleListCard.Size = new System.Drawing.Size(793, 30);
            this.lblRightAreaTitleListCard.TabIndex = 68;
            this.lblRightAreaTitleListCard.Text = " DANH SÁCH CẤU HÌNH PHIẾU";
            this.lblRightAreaTitleListCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UcRuleVoucherGift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblRightAreaTitleListCard);
            this.Name = "UcRuleVoucherGift";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Size = new System.Drawing.Size(805, 472);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRulesVoucherGift)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.tmsMember.ResumeLayout(false);
            this.tmsMember.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CommonControls.Custom.CommonDataGridView dgvRulesVoucherGift;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Label lblNotification1;
        private System.Windows.Forms.CheckBox cbxFilterByLocation;
        private System.Windows.Forms.CheckBox cbxFilterByVoucherGift;
        private System.Windows.Forms.CheckBox cbxFilterByTitle;
        private System.Windows.Forms.TextBox tbxMemberTitle;
        private System.Windows.Forms.ComboBox cbTypeCard;
        private System.Windows.Forms.ComboBox cbLocation;
        private CommonControls.Custom.CommonToolStrip tmsMember;
        private System.Windows.Forms.ToolStripButton btnAddRule;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnUpdateRule;
        private System.Windows.Forms.ToolStripButton btnRemoveRule;
        private System.Windows.Forms.ToolStripSeparator tssAfterPersoButton;
        private System.Windows.Forms.ToolStripButton btnShowHide;
        private System.Windows.Forms.ToolStripButton btnReloadRule;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private CommonControls.Custom.TitleLabel lblRightAreaTitleListCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;

    }
}
