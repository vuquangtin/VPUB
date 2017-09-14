namespace eCashComponent.WorkItems.PayOut
{
    partial class DeductPayOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeductPayOut));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPayInDesc = new System.Windows.Forms.Label();
            this.lblPayInTitle = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSelectItemShow = new CommonControls.Custom.CommonDataGridView();
            this.colitemshow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.lblGuiChooseReader = new System.Windows.Forms.Label();
            this.cmbReaders = new System.Windows.Forms.ComboBox();
            this.lblChooseReader = new System.Windows.Forms.Label();
            this.dgvResult = new CommonControls.Custom.CommonDataGridView();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmountStay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayinDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblListResultReadCardData = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnListDevices = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.miniToolStrip = new CommonControls.Custom.CommonToolStrip();
            this.btnReloadGroupItem = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvGroupItemConfig = new CommonControls.Custom.CommonDataGridView();
            this.tmsConfig = new CommonControls.Custom.CommonToolStrip();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectItemShow)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupItemConfig)).BeginInit();
            this.tmsConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblPayInDesc);
            this.panel2.Controls.Add(this.lblPayInTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(885, 80);
            this.panel2.TabIndex = 61;
            // 
            // lblPayInDesc
            // 
            this.lblPayInDesc.AutoSize = true;
            this.lblPayInDesc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayInDesc.Location = new System.Drawing.Point(12, 40);
            this.lblPayInDesc.Margin = new System.Windows.Forms.Padding(3);
            this.lblPayInDesc.Name = "lblPayInDesc";
            this.lblPayInDesc.Size = new System.Drawing.Size(245, 14);
            this.lblPayInDesc.TabIndex = 1;
            this.lblPayInDesc.Text = "Cập nhật thông tin số tiền cần ghi vào thẻ.";
            // 
            // lblPayInTitle
            // 
            this.lblPayInTitle.AutoSize = true;
            this.lblPayInTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayInTitle.Location = new System.Drawing.Point(12, 23);
            this.lblPayInTitle.Name = "lblPayInTitle";
            this.lblPayInTitle.Size = new System.Drawing.Size(126, 14);
            this.lblPayInTitle.TabIndex = 0;
            this.lblPayInTitle.Text = "Thanh toán dịch vụ";
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 80);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(885, 1);
            this.line1.TabIndex = 62;
            this.line1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(267, 81);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 550);
            this.panel3.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(613, 27);
            this.label1.TabIndex = 64;
            this.label1.Text = "Danh sách dịch vụ đã chọn:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvSelectItemShow
            // 
            this.dgvSelectItemShow.AllowDrop = true;
            this.dgvSelectItemShow.AllowUserToAddRows = false;
            this.dgvSelectItemShow.AllowUserToDeleteRows = false;
            this.dgvSelectItemShow.AllowUserToOrderColumns = true;
            this.dgvSelectItemShow.AllowUserToResizeRows = false;
            this.dgvSelectItemShow.BackgroundColor = System.Drawing.Color.White;
            this.dgvSelectItemShow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSelectItemShow.ColumnHeadersHeight = 26;
            this.dgvSelectItemShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSelectItemShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colitemshow,
            this.colItemPrice,
            this.colStartDate,
            this.colEndDate,
            this.dataGridViewTextBoxColumn3});
            this.dgvSelectItemShow.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvSelectItemShow.Location = new System.Drawing.Point(0, 27);
            this.dgvSelectItemShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSelectItemShow.MultiSelect = false;
            this.dgvSelectItemShow.Name = "dgvSelectItemShow";
            this.dgvSelectItemShow.ReadOnly = true;
            this.dgvSelectItemShow.RowHeadersVisible = false;
            this.dgvSelectItemShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectItemShow.Size = new System.Drawing.Size(613, 182);
            this.dgvSelectItemShow.TabIndex = 65;
            // 
            // colitemshow
            // 
            this.colitemshow.DataPropertyName = "ItemShow";
            this.colitemshow.HeaderText = "Tên Danh Mục";
            this.colitemshow.Name = "colitemshow";
            this.colitemshow.ReadOnly = true;
            this.colitemshow.Width = 150;
            // 
            // colItemPrice
            // 
            this.colItemPrice.DataPropertyName = "Price";
            this.colItemPrice.HeaderText = "Giá Tiền";
            this.colItemPrice.Name = "colItemPrice";
            this.colItemPrice.ReadOnly = true;
            // 
            // colStartDate
            // 
            this.colStartDate.DataPropertyName = "StartDate";
            this.colStartDate.HeaderText = "Ngày Bắt Đầu";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.ReadOnly = true;
            this.colStartDate.Width = 150;
            // 
            // colEndDate
            // 
            this.colEndDate.DataPropertyName = "EndDate";
            this.colEndDate.HeaderText = "Ngày Kết Thúc";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.ReadOnly = true;
            this.colEndDate.Width = 300;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.dgvResult);
            this.panel5.Controls.Add(this.lblListResultReadCardData);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 209);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
            this.panel5.Size = new System.Drawing.Size(613, 341);
            this.panel5.TabIndex = 66;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lblStatus);
            this.panel7.Controls.Add(this.lblCurrentStatus);
            this.panel7.Controls.Add(this.lblGuiChooseReader);
            this.panel7.Controls.Add(this.cmbReaders);
            this.panel7.Controls.Add(this.lblChooseReader);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(12, 155);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(589, 134);
            this.panel7.TabIndex = 19;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(0, 97);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(589, 35);
            this.lblStatus.TabIndex = 4;
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
            this.lblCurrentStatus.Size = new System.Drawing.Size(589, 20);
            this.lblCurrentStatus.TabIndex = 3;
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
            this.lblGuiChooseReader.Size = new System.Drawing.Size(589, 35);
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
            this.cmbReaders.Size = new System.Drawing.Size(589, 22);
            this.cmbReaders.TabIndex = 1;
            // 
            // lblChooseReader
            // 
            this.lblChooseReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChooseReader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseReader.Location = new System.Drawing.Point(0, 0);
            this.lblChooseReader.Name = "lblChooseReader";
            this.lblChooseReader.Size = new System.Drawing.Size(589, 20);
            this.lblChooseReader.TabIndex = 0;
            this.lblChooseReader.Text = "Chọn thiết bị đọc thẻ:";
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToOrderColumns = true;
            this.dgvResult.AllowUserToResizeRows = false;
            this.dgvResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResult.ColumnHeadersHeight = 26;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSerialNumber,
            this.colMemberName,
            this.colAmount,
            this.colAmountStay,
            this.colPayinDate,
            this.colResult,
            this.colBlank});
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvResult.Location = new System.Drawing.Point(12, 32);
            this.dgvResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(589, 123);
            this.dgvResult.TabIndex = 17;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.DataPropertyName = "SerialNumber";
            this.colSerialNumber.HeaderText = "Mã Thẻ";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            // 
            // colMemberName
            // 
            this.colMemberName.DataPropertyName = "MemberName";
            this.colMemberName.HeaderText = "Tên Thành Viên";
            this.colMemberName.Name = "colMemberName";
            this.colMemberName.ReadOnly = true;
            this.colMemberName.Width = 150;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Số Tiền";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colAmountStay
            // 
            this.colAmountStay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAmountStay.DataPropertyName = "AmountStay";
            this.colAmountStay.HeaderText = "Tiền Còn Trong Thẻ";
            this.colAmountStay.Name = "colAmountStay";
            this.colAmountStay.ReadOnly = true;
            this.colAmountStay.Width = 148;
            // 
            // colPayinDate
            // 
            this.colPayinDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colPayinDate.DataPropertyName = "PayInDate";
            this.colPayinDate.HeaderText = "Ngày Trừ";
            this.colPayinDate.Name = "colPayinDate";
            this.colPayinDate.ReadOnly = true;
            this.colPayinDate.Width = 86;
            // 
            // colResult
            // 
            this.colResult.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colResult.DataPropertyName = "Result";
            this.colResult.HeaderText = "Kết Quả";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            this.colResult.Width = 78;
            // 
            // colBlank
            // 
            this.colBlank.HeaderText = "";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            this.colBlank.Width = 5;
            // 
            // lblListResultReadCardData
            // 
            this.lblListResultReadCardData.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListResultReadCardData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListResultReadCardData.Location = new System.Drawing.Point(12, 5);
            this.lblListResultReadCardData.Margin = new System.Windows.Forms.Padding(3);
            this.lblListResultReadCardData.Name = "lblListResultReadCardData";
            this.lblListResultReadCardData.Size = new System.Drawing.Size(589, 27);
            this.lblListResultReadCardData.TabIndex = 15;
            this.lblListResultReadCardData.Text = "Danh sách kết quả:";
            this.lblListResultReadCardData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnStart);
            this.panel6.Controls.Add(this.btnPause);
            this.panel6.Controls.Add(this.btnListDevices);
            this.panel6.Controls.Add(this.btnClose);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(12, 289);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(589, 47);
            this.panel6.TabIndex = 10;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(97, 11);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(117, 28);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Bắt Đầu";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(220, 11);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(117, 28);
            this.btnPause.TabIndex = 12;
            this.btnPause.Text = "Tạm Ngưng";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // btnListDevices
            // 
            this.btnListDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListDevices.Location = new System.Drawing.Point(343, 11);
            this.btnListDevices.Name = "btnListDevices";
            this.btnListDevices.Size = new System.Drawing.Size(117, 28);
            this.btnListDevices.TabIndex = 13;
            this.btnListDevices.Text = "Tìm Thiết Bị";
            this.btnListDevices.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(466, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 28);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Đóng...";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.dgvSelectItemShow);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(272, 81);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(613, 550);
            this.panel4.TabIndex = 65;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.miniToolStrip.Size = new System.Drawing.Size(263, 25);
            this.miniToolStrip.TabIndex = 61;
            // 
            // btnReloadGroupItem
            // 
            this.btnReloadGroupItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadGroupItem.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadGroupItem.Image")));
            this.btnReloadGroupItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadGroupItem.Name = "btnReloadGroupItem";
            this.btnReloadGroupItem.Size = new System.Drawing.Size(23, 22);
            this.btnReloadGroupItem.Text = "Tải Dữ Liệu";
            this.btnReloadGroupItem.ToolTipText = "Tải danh sách cấu hình";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvGroupItemConfig);
            this.panel1.Controls.Add(this.tmsConfig);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(267, 550);
            this.panel1.TabIndex = 63;
            // 
            // dgvGroupItemConfig
            // 
            this.dgvGroupItemConfig.AllowUserToAddRows = false;
            this.dgvGroupItemConfig.AllowUserToDeleteRows = false;
            this.dgvGroupItemConfig.AllowUserToOrderColumns = true;
            this.dgvGroupItemConfig.AllowUserToResizeRows = false;
            this.dgvGroupItemConfig.BackgroundColor = System.Drawing.Color.White;
            this.dgvGroupItemConfig.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGroupItemConfig.ColumnHeadersHeight = 26;
            this.dgvGroupItemConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroupItemConfig.Location = new System.Drawing.Point(1, 26);
            this.dgvGroupItemConfig.MultiSelect = false;
            this.dgvGroupItemConfig.Name = "dgvGroupItemConfig";
            this.dgvGroupItemConfig.ReadOnly = true;
            this.dgvGroupItemConfig.RowHeadersVisible = false;
            this.dgvGroupItemConfig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroupItemConfig.Size = new System.Drawing.Size(263, 521);
            this.dgvGroupItemConfig.TabIndex = 64;
            // 
            // tmsConfig
            // 
            this.tmsConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReloadGroupItem});
            this.tmsConfig.Location = new System.Drawing.Point(1, 1);
            this.tmsConfig.Name = "tmsConfig";
            this.tmsConfig.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.tmsConfig.Size = new System.Drawing.Size(263, 25);
            this.tmsConfig.TabIndex = 61;
            this.tmsConfig.Text = "toolStrip1";
            // 
            // DeductPayOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 631);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel2);
            this.Name = "DeductPayOut";
            this.Text = "Thanh toán dịch vụ";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectItemShow)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupItemConfig)).EndInit();
            this.tmsConfig.ResumeLayout(false);
            this.tmsConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblPayInDesc;
        private System.Windows.Forms.Label lblPayInTitle;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private CommonControls.Custom.CommonDataGridView dgvSelectItemShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colitemshow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Label lblGuiChooseReader;
        private System.Windows.Forms.ComboBox cmbReaders;
        private System.Windows.Forms.Label lblChooseReader;
        private CommonControls.Custom.CommonDataGridView dgvResult;
        private System.Windows.Forms.Label lblListResultReadCardData;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnListDevices;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel4;
        private CommonControls.Custom.CommonToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStripButton btnReloadGroupItem;
        private System.Windows.Forms.Panel panel1;
        private CommonControls.Custom.CommonDataGridView dgvGroupItemConfig;
        private CommonControls.Custom.CommonToolStrip tmsConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmountStay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayinDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
    }
}