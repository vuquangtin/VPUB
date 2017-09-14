namespace VoucherGiftCardComponent.WorkItems
{
    partial class FrmShowAndAddRuleCard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowAndAddRuleCard));
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRightAreaTitleListCard = new CommonControls.Custom.TitleLabel();
            this.dgvCardRules = new CommonControls.Custom.CommonDataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQrCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commonToolStrip1 = new CommonControls.Custom.CommonToolStrip();
            this.btnSaveCardRules = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.tmsMember = new CommonControls.Custom.CommonToolStrip();
            this.btnAddRule = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpdateRule = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveRule = new System.Windows.Forms.ToolStripButton();
            this.tssAfterPersoButton = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.btnReloadRule = new System.Windows.Forms.ToolStripButton();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.pnlFilterBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardRules)).BeginInit();
            this.commonToolStrip1.SuspendLayout();
            this.tmsMember.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.Controls.Add(this.commonToolStrip1);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(901, 31);
            this.pnlFilterBox.TabIndex = 45;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel2.Size = new System.Drawing.Size(913, 484);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvCardRules);
            this.panel3.Controls.Add(this.pnlFilterBox);
            this.panel3.Controls.Add(this.tmsMember);
            this.panel3.Controls.Add(this.pagerPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(903, 476);
            this.panel3.TabIndex = 39;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 486);
            this.panel1.TabIndex = 71;
            // 
            // lblRightAreaTitleListCard
            // 
            this.lblRightAreaTitleListCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblRightAreaTitleListCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRightAreaTitleListCard.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblRightAreaTitleListCard.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRightAreaTitleListCard.Location = new System.Drawing.Point(0, 0);
            this.lblRightAreaTitleListCard.Name = "lblRightAreaTitleListCard";
            this.lblRightAreaTitleListCard.Size = new System.Drawing.Size(915, 30);
            this.lblRightAreaTitleListCard.TabIndex = 70;
            this.lblRightAreaTitleListCard.Text = "DANH SÁCH CARD THEO CẤU HÌNH PHIẾU";
            this.lblRightAreaTitleListCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvCardRules
            // 
            this.dgvCardRules.AllowUserToAddRows = false;
            this.dgvCardRules.AllowUserToDeleteRows = false;
            this.dgvCardRules.AllowUserToOrderColumns = true;
            this.dgvCardRules.AllowUserToResizeRows = false;
            this.dgvCardRules.BackgroundColor = System.Drawing.Color.White;
            this.dgvCardRules.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCardRules.ColumnHeadersHeight = 26;
            this.dgvCardRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colLastName,
            this.colFirstName,
            this.colTelephone,
            this.colQrCode,
            this.colBarCode,
            this.colSerial,
            this.colBlank});
            this.dgvCardRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCardRules.Location = new System.Drawing.Point(0, 56);
            this.dgvCardRules.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCardRules.MultiSelect = false;
            this.dgvCardRules.Name = "dgvCardRules";
            this.dgvCardRules.ReadOnly = true;
            this.dgvCardRules.RowHeadersVisible = false;
            this.dgvCardRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCardRules.Size = new System.Drawing.Size(901, 398);
            this.dgvCardRules.TabIndex = 46;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colLastName
            // 
            this.colLastName.DataPropertyName = "LastName";
            this.colLastName.HeaderText = "Họ Tên Đệm";
            this.colLastName.Name = "colLastName";
            this.colLastName.ReadOnly = true;
            this.colLastName.Width = 250;
            // 
            // colFirstName
            // 
            this.colFirstName.DataPropertyName = "FirstName";
            this.colFirstName.HeaderText = "Tên";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.ReadOnly = true;
            // 
            // colTelephone
            // 
            this.colTelephone.DataPropertyName = "Telephone";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTelephone.DefaultCellStyle = dataGridViewCellStyle1;
            this.colTelephone.HeaderText = "Số Điện Thoại";
            this.colTelephone.Name = "colTelephone";
            this.colTelephone.ReadOnly = true;
            this.colTelephone.Width = 120;
            // 
            // colQrCode
            // 
            this.colQrCode.DataPropertyName = "QrCode";
            this.colQrCode.HeaderText = "QR Code";
            this.colQrCode.Name = "colQrCode";
            this.colQrCode.ReadOnly = true;
            this.colQrCode.Width = 120;
            // 
            // colBarCode
            // 
            this.colBarCode.DataPropertyName = "BarCode";
            this.colBarCode.HeaderText = "Bar Code ";
            this.colBarCode.Name = "colBarCode";
            this.colBarCode.ReadOnly = true;
            this.colBarCode.Width = 120;
            // 
            // colSerial
            // 
            this.colSerial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSerial.DataPropertyName = "Serial";
            this.colSerial.HeaderText = "Serial";
            this.colSerial.Name = "colSerial";
            this.colSerial.ReadOnly = true;
            // 
            // colBlank
            // 
            this.colBlank.HeaderText = "colBlank";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            this.colBlank.Visible = false;
            this.colBlank.Width = 5;
            // 
            // commonToolStrip1
            // 
            this.commonToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveCardRules,
            this.toolStripButton4});
            this.commonToolStrip1.Location = new System.Drawing.Point(5, 5);
            this.commonToolStrip1.Name = "commonToolStrip1";
            this.commonToolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.commonToolStrip1.Size = new System.Drawing.Size(891, 25);
            this.commonToolStrip1.TabIndex = 45;
            this.commonToolStrip1.Text = "toolStrip1";
            // 
            // btnSaveCardRules
            // 
            this.btnSaveCardRules.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveCardRules.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveCardRules.Image")));
            this.btnSaveCardRules.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveCardRules.Name = "btnSaveCardRules";
            this.btnSaveCardRules.Size = new System.Drawing.Size(23, 22);
            this.btnSaveCardRules.Text = "Lưu Danh Sách Card Mới Này...";
            this.btnSaveCardRules.ToolTipText = "Lưu danh sách Card mới này vào hệ thống.";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Ẩn Khung Tìm Kiếm";
            this.toolStripButton4.ToolTipText = "Ẩn khung tìm kiếm";
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
            this.tmsMember.Size = new System.Drawing.Size(901, 25);
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
            this.pagerPanel1.Location = new System.Drawing.Point(0, 454);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(901, 20);
            this.pagerPanel1.TabIndex = 40;
            // 
            // FrmShowAndAddRuleCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 486);
            this.Controls.Add(this.lblRightAreaTitleListCard);
            this.Controls.Add(this.panel1);
            this.Name = "FrmShowAndAddRuleCard";
            this.Text = "Thông Tin Cấu Hình Phiếu";
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardRules)).EndInit();
            this.commonToolStrip1.ResumeLayout(false);
            this.commonToolStrip1.PerformLayout();
            this.tmsMember.ResumeLayout(false);
            this.tmsMember.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControls.Custom.TitleLabel lblRightAreaTitleListCard;
        private System.Windows.Forms.ToolStripButton btnReloadRule;
        private System.Windows.Forms.ToolStripButton btnShowHide;
        private System.Windows.Forms.ToolStripSeparator tssAfterPersoButton;
        private System.Windows.Forms.ToolStripButton btnRemoveRule;
        private System.Windows.Forms.ToolStripButton btnUpdateRule;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnAddRule;
        private CommonControls.Custom.CommonToolStrip tmsMember;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CommonControls.Custom.CommonDataGridView dgvCardRules;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQrCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
        private CommonControls.Custom.CommonToolStrip commonToolStrip1;
        private System.Windows.Forms.ToolStripButton btnSaveCardRules;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}