namespace eCashComponent.WorkItems.Config
{
    partial class UsrConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrConfig));
            this.lblCardConfig = new CommonControls.Custom.TitleLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mniExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsHistoryTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniReloadData = new System.Windows.Forms.ToolStripMenuItem();
            this.panelConfigTransaction = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvEcashConfig = new CommonControls.Custom.CommonDataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmsConfig = new CommonControls.Custom.CommonToolStrip();
            this.btnAddConfig = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateConfig = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveConfig = new System.Windows.Forms.ToolStripButton();
            this.tssAfterPersoButton = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.btnReloadConfig = new System.Windows.Forms.ToolStripButton();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.cbxFilterByCardConfigName = new System.Windows.Forms.CheckBox();
            this.cbxFilterByApplyTime = new System.Windows.Forms.CheckBox();
            this.dtpApplyTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.lbFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpApplyTimeTo = new System.Windows.Forms.DateTimePicker();
            this.cbxFilterByAmount = new System.Windows.Forms.CheckBox();
            this.tbxConfigAmount = new System.Windows.Forms.TextBox();
            this.tbxConfigTypeTransaction = new System.Windows.Forms.TextBox();
            this.lblNotification1 = new System.Windows.Forms.Label();
            this.lblNotification2 = new System.Windows.Forms.Label();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.cmsHistoryTable.SuspendLayout();
            this.panelConfigTransaction.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEcashConfig)).BeginInit();
            this.tmsConfig.SuspendLayout();
            this.pnlFilterBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCardConfig
            // 
            this.lblCardConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblCardConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCardConfig.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblCardConfig.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCardConfig.Location = new System.Drawing.Point(6, 5);
            this.lblCardConfig.Name = "lblCardConfig";
            this.lblCardConfig.Size = new System.Drawing.Size(765, 32);
            this.lblCardConfig.TabIndex = 40;
            this.lblCardConfig.Text = "CẤU HÌNH GIAO DỊCH";
            this.lblCardConfig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // mniExportToExcel
            // 
            this.mniExportToExcel.Name = "mniExportToExcel";
            this.mniExportToExcel.Size = new System.Drawing.Size(152, 22);
            this.mniExportToExcel.Text = "Xuất Ra Excel...";
            // 
            // cmsHistoryTable
            // 
            this.cmsHistoryTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniExportToExcel,
            this.toolStripSeparator2,
            this.mniReloadData});
            this.cmsHistoryTable.Name = "contextMenuStrip1";
            this.cmsHistoryTable.Size = new System.Drawing.Size(153, 54);
            // 
            // mniReloadData
            // 
            this.mniReloadData.Name = "mniReloadData";
            this.mniReloadData.Size = new System.Drawing.Size(152, 22);
            this.mniReloadData.Text = "Tải Dữ Liệu";
            // 
            // panelConfigTransaction
            // 
            this.panelConfigTransaction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelConfigTransaction.Controls.Add(this.panel2);
            this.panelConfigTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConfigTransaction.Location = new System.Drawing.Point(6, 37);
            this.panelConfigTransaction.Name = "panelConfigTransaction";
            this.panelConfigTransaction.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.panelConfigTransaction.Size = new System.Drawing.Size(765, 454);
            this.panelConfigTransaction.TabIndex = 42;
            
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvEcashConfig);
            this.panel2.Controls.Add(this.tmsConfig);
            this.panel2.Controls.Add(this.pagerPanel1);
            this.panel2.Controls.Add(this.pnlFilterBox);
            this.panel2.Location = new System.Drawing.Point(6, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 444);
            this.panel2.TabIndex = 38;
            // 
            // dgvEcashConfig
            // 
            this.dgvEcashConfig.AllowUserToAddRows = false;
            this.dgvEcashConfig.AllowUserToDeleteRows = false;
            this.dgvEcashConfig.AllowUserToOrderColumns = true;
            this.dgvEcashConfig.AllowUserToResizeRows = false;
            this.dgvEcashConfig.BackgroundColor = System.Drawing.Color.White;
            this.dgvEcashConfig.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEcashConfig.ColumnHeadersHeight = 26;
            this.dgvEcashConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colAmount,
            this.colStartDate,
            this.colEndDate,
            this.colDescription,
            this.colBlank});
            this.dgvEcashConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEcashConfig.Location = new System.Drawing.Point(0, 122);
            this.dgvEcashConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvEcashConfig.Name = "dgvEcashConfig";
            this.dgvEcashConfig.ReadOnly = true;
            this.dgvEcashConfig.RowHeadersVisible = false;
            this.dgvEcashConfig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEcashConfig.Size = new System.Drawing.Size(749, 298);
            this.dgvEcashConfig.TabIndex = 49;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 5;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Tên Cấu Hình Dịch Vụ";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 150;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Số Tiền Được Phép Giao Dịch";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Visible = false;
            this.colAmount.Width = 200;
            // 
            // colStartDate
            // 
            this.colStartDate.DataPropertyName = "StartDate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colStartDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colStartDate.HeaderText = "Ngày Bắt Đầu";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.ReadOnly = true;
            this.colStartDate.Width = 200;
            // 
            // colEndDate
            // 
            this.colEndDate.DataPropertyName = "EndDate";
            this.colEndDate.HeaderText = "Ngày Kết Thúc";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.ReadOnly = true;
            this.colEndDate.Width = 150;
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
            this.colBlank.HeaderText = "";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            this.colBlank.Width = 5;
            // 
            // tmsConfig
            // 
            this.tmsConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddConfig,
            this.btnUpdateConfig,
            this.btnRemoveConfig,
            this.tssAfterPersoButton,
            this.btnShowHide,
            this.btnReloadConfig});
            this.tmsConfig.Location = new System.Drawing.Point(0, 97);
            this.tmsConfig.Name = "tmsConfig";
            this.tmsConfig.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.tmsConfig.Size = new System.Drawing.Size(749, 25);
            this.tmsConfig.TabIndex = 48;
            this.tmsConfig.Text = "toolStrip1";
            // 
            // btnAddConfig
            // 
            this.btnAddConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnAddConfig.Image")));
            this.btnAddConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddConfig.Name = "btnAddConfig";
            this.btnAddConfig.Size = new System.Drawing.Size(23, 22);
            this.btnAddConfig.Text = "Thêm Cấu Hình Mới...";
            this.btnAddConfig.ToolTipText = "Thêm cấu hình mới vào hệ thống.";
            // 
            // btnUpdateConfig
            // 
            this.btnUpdateConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateConfig.Image")));
            this.btnUpdateConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateConfig.Name = "btnUpdateConfig";
            this.btnUpdateConfig.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateConfig.Text = "Cập Nhật Thông Tin Cấu Hình...";
            this.btnUpdateConfig.ToolTipText = "Cập nhật thông tin danh mục trong hệ thống.";
            // 
            // btnRemoveConfig
            // 
            this.btnRemoveConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveConfig.Image")));
            this.btnRemoveConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveConfig.Name = "btnRemoveConfig";
            this.btnRemoveConfig.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveConfig.Text = "Hủy Cấu hình Khỏi Hệ Thống...";
            this.btnRemoveConfig.ToolTipText = "Hủy cấu hình khỏi hệ thống";
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
            // btnReloadConfig
            // 
            this.btnReloadConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadConfig.Image")));
            this.btnReloadConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadConfig.Name = "btnReloadConfig";
            this.btnReloadConfig.Size = new System.Drawing.Size(23, 22);
            this.btnReloadConfig.Text = "Tải Dữ Liệu";
            this.btnReloadConfig.ToolTipText = "Tải danh sách cấu hình";
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 420);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(749, 22);
            this.pagerPanel1.TabIndex = 40;
            // 
            // cbxFilterByCardConfigName
            // 
            this.cbxFilterByCardConfigName.Location = new System.Drawing.Point(9, 9);
            this.cbxFilterByCardConfigName.Name = "cbxFilterByCardConfigName";
            this.cbxFilterByCardConfigName.Size = new System.Drawing.Size(233, 24);
            this.cbxFilterByCardConfigName.TabIndex = 10;
            this.cbxFilterByCardConfigName.Text = "Lọc theo tên của cấu hình giao dịch:";
            this.cbxFilterByCardConfigName.UseVisualStyleBackColor = true;
            this.cbxFilterByCardConfigName.CheckedChanged += new System.EventHandler(this.cbxFilterByCardConfigName_CheckedChanged);
            // 
            // cbxFilterByApplyTime
            // 
            this.cbxFilterByApplyTime.Location = new System.Drawing.Point(9, 66);
            this.cbxFilterByApplyTime.Name = "cbxFilterByApplyTime";
            this.cbxFilterByApplyTime.Size = new System.Drawing.Size(233, 24);
            this.cbxFilterByApplyTime.TabIndex = 13;
            this.cbxFilterByApplyTime.Text = "Lọc theo khoảng thời gian áp dụng:";
            this.cbxFilterByApplyTime.UseVisualStyleBackColor = true;
            this.cbxFilterByApplyTime.CheckedChanged += new System.EventHandler(this.cbxFilterByApplyTime_CheckedChanged);
            // 
            // dtpApplyTimeFrom
            // 
            this.dtpApplyTimeFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpApplyTimeFrom.Enabled = false;
            this.dtpApplyTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplyTimeFrom.Location = new System.Drawing.Point(287, 66);
            this.dtpApplyTimeFrom.Name = "dtpApplyTimeFrom";
            this.dtpApplyTimeFrom.Size = new System.Drawing.Size(137, 22);
            this.dtpApplyTimeFrom.TabIndex = 15;
            // 
            // lbFrom
            // 
            this.lbFrom.Location = new System.Drawing.Point(248, 66);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(33, 24);
            this.lbFrom.TabIndex = 16;
            this.lbFrom.Text = "Từ:";
            this.lbFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(430, 66);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(42, 24);
            this.lblTo.TabIndex = 17;
            this.lblTo.Text = "Đến:";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpApplyTimeTo
            // 
            this.dtpApplyTimeTo.CustomFormat = "dd/MM/yyyy";
            this.dtpApplyTimeTo.Enabled = false;
            this.dtpApplyTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplyTimeTo.Location = new System.Drawing.Point(478, 65);
            this.dtpApplyTimeTo.Name = "dtpApplyTimeTo";
            this.dtpApplyTimeTo.Size = new System.Drawing.Size(137, 22);
            this.dtpApplyTimeTo.TabIndex = 18;
            // 
            // cbxFilterByAmount
            // 
            this.cbxFilterByAmount.Location = new System.Drawing.Point(9, 36);
            this.cbxFilterByAmount.Name = "cbxFilterByAmount";
            this.cbxFilterByAmount.Size = new System.Drawing.Size(233, 24);
            this.cbxFilterByAmount.TabIndex = 20;
            this.cbxFilterByAmount.Text = "Lọc theo số tiền:";
            this.cbxFilterByAmount.UseVisualStyleBackColor = true;
            this.cbxFilterByAmount.CheckedChanged += new System.EventHandler(this.cbxFilterByAmount_CheckedChanged);
            // 
            // tbxConfigAmount
            // 
            this.tbxConfigAmount.Enabled = false;
            this.tbxConfigAmount.Location = new System.Drawing.Point(250, 38);
            this.tbxConfigAmount.Name = "tbxConfigAmount";
            this.tbxConfigAmount.Size = new System.Drawing.Size(174, 22);
            this.tbxConfigAmount.TabIndex = 46;
            // 
            // tbxConfigTypeTransaction
            // 
            this.tbxConfigTypeTransaction.Enabled = false;
            this.tbxConfigTypeTransaction.Location = new System.Drawing.Point(250, 10);
            this.tbxConfigTypeTransaction.Name = "tbxConfigTypeTransaction";
            this.tbxConfigTypeTransaction.Size = new System.Drawing.Size(174, 22);
            this.tbxConfigTypeTransaction.TabIndex = 47;
            // 
            // lblNotification1
            // 
            this.lblNotification1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNotification1.Location = new System.Drawing.Point(430, 11);
            this.lblNotification1.Name = "lblNotification1";
            this.lblNotification1.Size = new System.Drawing.Size(150, 22);
            this.lblNotification1.TabIndex = 164;
            this.lblNotification1.Text = "Vui lòng nhập ít nhất 2 ký tự";
            this.lblNotification1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotification1.Visible = false;
            // 
            // lblNotification2
            // 
            this.lblNotification2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNotification2.Location = new System.Drawing.Point(430, 39);
            this.lblNotification2.Name = "lblNotification2";
            this.lblNotification2.Size = new System.Drawing.Size(150, 22);
            this.lblNotification2.TabIndex = 164;
            this.lblNotification2.Text = "Vui lòng nhập ít nhất 2 ký tự";
            this.lblNotification2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotification2.Visible = false;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.ContextMenuStrip = this.cmsHistoryTable;
            this.pnlFilterBox.Controls.Add(this.lblNotification2);
            this.pnlFilterBox.Controls.Add(this.lblNotification1);
            this.pnlFilterBox.Controls.Add(this.tbxConfigTypeTransaction);
            this.pnlFilterBox.Controls.Add(this.tbxConfigAmount);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByAmount);
            this.pnlFilterBox.Controls.Add(this.dtpApplyTimeTo);
            this.pnlFilterBox.Controls.Add(this.lblTo);
            this.pnlFilterBox.Controls.Add(this.lbFrom);
            this.pnlFilterBox.Controls.Add(this.dtpApplyTimeFrom);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByApplyTime);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByCardConfigName);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 0);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlFilterBox.Size = new System.Drawing.Size(749, 97);
            this.pnlFilterBox.TabIndex = 39;
            // 
            // UsrConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelConfigTransaction);
            this.Controls.Add(this.lblCardConfig);
            this.Name = "UsrConfig";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Size = new System.Drawing.Size(777, 496);
            this.cmsHistoryTable.ResumeLayout(false);
            this.panelConfigTransaction.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEcashConfig)).EndInit();
            this.tmsConfig.ResumeLayout(false);
            this.tmsConfig.PerformLayout();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControls.Custom.TitleLabel lblCardConfig;
        private System.Windows.Forms.ToolStripMenuItem mniReloadData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mniExportToExcel;
        private System.Windows.Forms.ContextMenuStrip cmsHistoryTable;
        private System.Windows.Forms.Panel panelConfigTransaction;
        private System.Windows.Forms.Panel panel2;
        private CommonControls.Custom.CommonDataGridView dgvEcashConfig;
        private CommonControls.Custom.CommonToolStrip tmsConfig;
        private System.Windows.Forms.ToolStripButton btnAddConfig;
        private System.Windows.Forms.ToolStripButton btnUpdateConfig;
        private System.Windows.Forms.ToolStripButton btnRemoveConfig;
        private System.Windows.Forms.ToolStripSeparator tssAfterPersoButton;
        private System.Windows.Forms.ToolStripButton btnShowHide;
        private System.Windows.Forms.ToolStripButton btnReloadConfig;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Label lblNotification2;
        private System.Windows.Forms.Label lblNotification1;
        private System.Windows.Forms.TextBox tbxConfigTypeTransaction;
        private System.Windows.Forms.TextBox tbxConfigAmount;
        private System.Windows.Forms.CheckBox cbxFilterByAmount;
        private System.Windows.Forms.DateTimePicker dtpApplyTimeTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.DateTimePicker dtpApplyTimeFrom;
        private System.Windows.Forms.CheckBox cbxFilterByApplyTime;
        private System.Windows.Forms.CheckBox cbxFilterByCardConfigName;
    }
}
