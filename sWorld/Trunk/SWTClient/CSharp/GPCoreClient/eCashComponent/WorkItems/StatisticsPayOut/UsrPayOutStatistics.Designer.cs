namespace eCashComponent.WorkItems.StatisticsPayOut
{
    partial class UsrPayOutStatistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrPayOutStatistics));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvStatisticTopUp = new CommonControls.Custom.CommonDataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeTopUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmountstay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataReadToCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Blank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.lblNotification1 = new System.Windows.Forms.Label();
            this.tbxSerialNumber = new System.Windows.Forms.TextBox();
            this.cbxFilterBySerialNumber = new System.Windows.Forms.CheckBox();
            this.dtpApplyTimeTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lbFrom = new System.Windows.Forms.Label();
            this.dtpApplyTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.cbxFilterByApplyTime = new System.Windows.Forms.CheckBox();
            this.lblNotification2 = new System.Windows.Forms.Label();
            this.tbxPayIn = new System.Windows.Forms.TextBox();
            this.cbxFilterByPayIn = new System.Windows.Forms.CheckBox();
            this.tmsItem = new CommonControls.Custom.CommonToolStrip();
            this.tssAfterPersoButton = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.btnReloadTopUp = new System.Windows.Forms.ToolStripButton();
            this.lblAreaTitle = new CommonControls.Custom.TitleLabel();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatisticTopUp)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.tmsItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvStatisticTopUp);
            this.panel2.Controls.Add(this.pnlFilterBox);
            this.panel2.Controls.Add(this.tmsItem);
            this.panel2.Controls.Add(this.lblAreaTitle);
            this.panel2.Controls.Add(this.pagerPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(894, 644);
            this.panel2.TabIndex = 58;
            // 
            // dgvStatisticTopUp
            // 
            this.dgvStatisticTopUp.AllowUserToAddRows = false;
            this.dgvStatisticTopUp.AllowUserToDeleteRows = false;
            this.dgvStatisticTopUp.AllowUserToOrderColumns = true;
            this.dgvStatisticTopUp.AllowUserToResizeRows = false;
            this.dgvStatisticTopUp.BackgroundColor = System.Drawing.Color.White;
            this.dgvStatisticTopUp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStatisticTopUp.ColumnHeadersHeight = 26;
            this.dgvStatisticTopUp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colMemberCode,
            this.colMemberId,
            this.colItemName,
            this.colMemberName,
            this.colAmount,
            this.colTimeTopUp,
            this.colAmountstay,
            this.colIpAddress,
            this.colDataReadToCard,
            this.colStatus,
            this.Blank});
            this.dgvStatisticTopUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatisticTopUp.Location = new System.Drawing.Point(0, 148);
            this.dgvStatisticTopUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvStatisticTopUp.Name = "dgvStatisticTopUp";
            this.dgvStatisticTopUp.ReadOnly = true;
            this.dgvStatisticTopUp.RowHeadersVisible = false;
            this.dgvStatisticTopUp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatisticTopUp.Size = new System.Drawing.Size(892, 470);
            this.dgvStatisticTopUp.TabIndex = 61;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colMemberCode
            // 
            this.colMemberCode.DataPropertyName = "MemberCode";
            this.colMemberCode.HeaderText = "Mã Thành Viên";
            this.colMemberCode.Name = "colMemberCode";
            this.colMemberCode.ReadOnly = true;
            this.colMemberCode.Width = 130;
            // 
            // colMemberId
            // 
            this.colMemberId.DataPropertyName = "MemberId";
            this.colMemberId.HeaderText = "Mã Thành Viên";
            this.colMemberId.Name = "colMemberId";
            this.colMemberId.ReadOnly = true;
            this.colMemberId.Visible = false;
            this.colMemberId.Width = 150;
            // 
            // colItemName
            // 
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colItemName.DataPropertyName = "ItemName";
            this.colItemName.HeaderText = "Dịch Vụ";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            this.colItemName.Width = 76;
            // 
            // colMemberName
            // 
            this.colMemberName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMemberName.DataPropertyName = "MemberName";
            this.colMemberName.HeaderText = "Tên Thành Viên";
            this.colMemberName.Name = "colMemberName";
            this.colMemberName.ReadOnly = true;
            this.colMemberName.Width = 124;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Số Tiền Trừ";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 150;
            // 
            // colTimeTopUp
            // 
            this.colTimeTopUp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTimeTopUp.DataPropertyName = "PayInDate";
            this.colTimeTopUp.HeaderText = "Thời Gian Trừ Tiền";
            this.colTimeTopUp.Name = "colTimeTopUp";
            this.colTimeTopUp.ReadOnly = true;
            this.colTimeTopUp.Width = 141;
            // 
            // colAmountstay
            // 
            this.colAmountstay.DataPropertyName = "Amountstay";
            this.colAmountstay.HeaderText = "Tiền Còn Trong Thẻ";
            this.colAmountstay.Name = "colAmountstay";
            this.colAmountstay.ReadOnly = true;
            this.colAmountstay.Width = 150;
            // 
            // colIpAddress
            // 
            this.colIpAddress.DataPropertyName = "IpAddress";
            this.colIpAddress.HeaderText = "Máy Trừ Tiền";
            this.colIpAddress.Name = "colIpAddress";
            this.colIpAddress.ReadOnly = true;
            this.colIpAddress.Visible = false;
            this.colIpAddress.Width = 150;
            // 
            // colDataReadToCard
            // 
            this.colDataReadToCard.DataPropertyName = "DataReadToCard";
            this.colDataReadToCard.HeaderText = "Dữ Liệu Trên Thẻ";
            this.colDataReadToCard.Name = "colDataReadToCard";
            this.colDataReadToCard.ReadOnly = true;
            this.colDataReadToCard.Visible = false;
            this.colDataReadToCard.Width = 200;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Tình Trạng Thẻ";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // Blank
            // 
            this.Blank.HeaderText = "";
            this.Blank.Name = "Blank";
            this.Blank.ReadOnly = true;
            this.Blank.Width = 5;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.Controls.Add(this.lblNotification1);
            this.pnlFilterBox.Controls.Add(this.tbxSerialNumber);
            this.pnlFilterBox.Controls.Add(this.cbxFilterBySerialNumber);
            this.pnlFilterBox.Controls.Add(this.dtpApplyTimeTo);
            this.pnlFilterBox.Controls.Add(this.lblTo);
            this.pnlFilterBox.Controls.Add(this.lbFrom);
            this.pnlFilterBox.Controls.Add(this.dtpApplyTimeFrom);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByApplyTime);
            this.pnlFilterBox.Controls.Add(this.lblNotification2);
            this.pnlFilterBox.Controls.Add(this.tbxPayIn);
            this.pnlFilterBox.Controls.Add(this.cbxFilterByPayIn);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 57);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.pnlFilterBox.Size = new System.Drawing.Size(892, 91);
            this.pnlFilterBox.TabIndex = 60;
            // 
            // lblNotification1
            // 
            this.lblNotification1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNotification1.Location = new System.Drawing.Point(494, 29);
            this.lblNotification1.Name = "lblNotification1";
            this.lblNotification1.Size = new System.Drawing.Size(204, 26);
            this.lblNotification1.TabIndex = 52;
            this.lblNotification1.Text = "Vui lòng nhập ít nhất 2 ký tự";
            this.lblNotification1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotification1.Visible = false;
            // 
            // tbxSerialNumber
            // 
            this.tbxSerialNumber.Enabled = false;
            this.tbxSerialNumber.Location = new System.Drawing.Point(252, 32);
            this.tbxSerialNumber.Name = "tbxSerialNumber";
            this.tbxSerialNumber.Size = new System.Drawing.Size(236, 22);
            this.tbxSerialNumber.TabIndex = 51;
            // 
            // cbxFilterBySerialNumber
            // 
            this.cbxFilterBySerialNumber.Location = new System.Drawing.Point(10, 30);
            this.cbxFilterBySerialNumber.Name = "cbxFilterBySerialNumber";
            this.cbxFilterBySerialNumber.Size = new System.Drawing.Size(236, 26);
            this.cbxFilterBySerialNumber.TabIndex = 50;
            this.cbxFilterBySerialNumber.Text = "Lọc theo mã thẻ:";
            this.cbxFilterBySerialNumber.UseVisualStyleBackColor = true;
            this.cbxFilterBySerialNumber.CheckedChanged += new System.EventHandler(this.cbxFilterBySerialNumber_CheckedChanged);
            // 
            // dtpApplyTimeTo
            // 
            this.dtpApplyTimeTo.CustomFormat = "dd/MM/yyyy";
            this.dtpApplyTimeTo.Enabled = false;
            this.dtpApplyTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplyTimeTo.Location = new System.Drawing.Point(518, 59);
            this.dtpApplyTimeTo.Name = "dtpApplyTimeTo";
            this.dtpApplyTimeTo.Size = new System.Drawing.Size(159, 22);
            this.dtpApplyTimeTo.TabIndex = 49;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(463, 59);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(49, 26);
            this.lblTo.TabIndex = 48;
            this.lblTo.Text = "Đến:";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFrom
            // 
            this.lbFrom.Location = new System.Drawing.Point(252, 59);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(40, 26);
            this.lbFrom.TabIndex = 47;
            this.lbFrom.Text = "Từ:";
            this.lbFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpApplyTimeFrom
            // 
            this.dtpApplyTimeFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpApplyTimeFrom.Enabled = false;
            this.dtpApplyTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplyTimeFrom.Location = new System.Drawing.Point(298, 59);
            this.dtpApplyTimeFrom.Name = "dtpApplyTimeFrom";
            this.dtpApplyTimeFrom.Size = new System.Drawing.Size(159, 22);
            this.dtpApplyTimeFrom.TabIndex = 46;
            // 
            // cbxFilterByApplyTime
            // 
            this.cbxFilterByApplyTime.Location = new System.Drawing.Point(10, 60);
            this.cbxFilterByApplyTime.Name = "cbxFilterByApplyTime";
            this.cbxFilterByApplyTime.Size = new System.Drawing.Size(236, 26);
            this.cbxFilterByApplyTime.TabIndex = 45;
            this.cbxFilterByApplyTime.Text = "Lọc theo khoảng thời gian trừ tiền:";
            this.cbxFilterByApplyTime.UseVisualStyleBackColor = true;
            this.cbxFilterByApplyTime.CheckedChanged += new System.EventHandler(this.cbxFilterByApplyTime_CheckedChanged);
            // 
            // lblNotification2
            // 
            this.lblNotification2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNotification2.Location = new System.Drawing.Point(494, 2);
            this.lblNotification2.Name = "lblNotification2";
            this.lblNotification2.Size = new System.Drawing.Size(204, 26);
            this.lblNotification2.TabIndex = 42;
            this.lblNotification2.Text = "Vui lòng nhập ít nhất 2 ký tự";
            this.lblNotification2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotification2.Visible = false;
            // 
            // tbxPayIn
            // 
            this.tbxPayIn.Enabled = false;
            this.tbxPayIn.Location = new System.Drawing.Point(252, 5);
            this.tbxPayIn.Name = "tbxPayIn";
            this.tbxPayIn.Size = new System.Drawing.Size(236, 22);
            this.tbxPayIn.TabIndex = 35;
            // 
            // cbxFilterByPayIn
            // 
            this.cbxFilterByPayIn.Location = new System.Drawing.Point(10, 3);
            this.cbxFilterByPayIn.Name = "cbxFilterByPayIn";
            this.cbxFilterByPayIn.Size = new System.Drawing.Size(236, 26);
            this.cbxFilterByPayIn.TabIndex = 34;
            this.cbxFilterByPayIn.Text = "Lọc theo số tiền trừ:";
            this.cbxFilterByPayIn.UseVisualStyleBackColor = true;
            this.cbxFilterByPayIn.CheckedChanged += new System.EventHandler(this.cbxFilterByPayIn_CheckedChanged);
            // 
            // tmsItem
            // 
            this.tmsItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssAfterPersoButton,
            this.btnShowHide,
            this.btnReloadTopUp});
            this.tmsItem.Location = new System.Drawing.Point(0, 32);
            this.tmsItem.Name = "tmsItem";
            this.tmsItem.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.tmsItem.Size = new System.Drawing.Size(892, 25);
            this.tmsItem.TabIndex = 59;
            this.tmsItem.Text = "toolStrip1";
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
            // btnReloadTopUp
            // 
            this.btnReloadTopUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadTopUp.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadTopUp.Image")));
            this.btnReloadTopUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadTopUp.Name = "btnReloadTopUp";
            this.btnReloadTopUp.Size = new System.Drawing.Size(23, 22);
            this.btnReloadTopUp.Text = "Tải Dữ Liệu";
            this.btnReloadTopUp.ToolTipText = "Tải danh sách danh mục";
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblAreaTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAreaTitle.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblAreaTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblAreaTitle.Location = new System.Drawing.Point(0, 0);
            this.lblAreaTitle.Name = "lblAreaTitle";
            this.lblAreaTitle.Size = new System.Drawing.Size(892, 32);
            this.lblAreaTitle.TabIndex = 58;
            this.lblAreaTitle.Text = "THỐNG KÊ TRỪ TIỀN";
            this.lblAreaTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 618);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(892, 24);
            this.pagerPanel1.TabIndex = 47;
            // 
            // UsrPayOutStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "UsrPayOutStatistics";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Size = new System.Drawing.Size(906, 654);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatisticTopUp)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.tmsItem.ResumeLayout(false);
            this.tmsItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private CommonControls.Custom.CommonDataGridView dgvStatisticTopUp;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Label lblNotification1;
        private System.Windows.Forms.TextBox tbxSerialNumber;
        private System.Windows.Forms.CheckBox cbxFilterBySerialNumber;
        private System.Windows.Forms.DateTimePicker dtpApplyTimeTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.DateTimePicker dtpApplyTimeFrom;
        private System.Windows.Forms.CheckBox cbxFilterByApplyTime;
        private System.Windows.Forms.Label lblNotification2;
        private System.Windows.Forms.TextBox tbxPayIn;
        private System.Windows.Forms.CheckBox cbxFilterByPayIn;
        private CommonControls.Custom.CommonToolStrip tmsItem;
        private System.Windows.Forms.ToolStripSeparator tssAfterPersoButton;
        private System.Windows.Forms.ToolStripButton btnShowHide;
        private System.Windows.Forms.ToolStripButton btnReloadTopUp;
        private CommonControls.Custom.TitleLabel lblAreaTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeTopUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmountstay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataReadToCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Blank;
    }
}
