namespace eCashComponent.WorkItems.TopUp
{
    partial class FrmPayIn
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPayInDesc = new System.Windows.Forms.Label();
            this.lblPayInTitle = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tbnAmount = new System.Windows.Forms.TextBox();
            this.cmbPartnerInfo = new System.Windows.Forms.ComboBox();
            this.lblPartnerKey = new System.Windows.Forms.Label();
            this.line2 = new CommonControls.Custom.Line();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.lblGuiChooseReader = new System.Windows.Forms.Label();
            this.cmbReaders = new System.Windows.Forms.ComboBox();
            this.lblChooseReader = new System.Windows.Forms.Label();
            this.btnListDevices = new System.Windows.Forms.Button();
            this.dgvResult = new CommonControls.Custom.CommonDataGridView();
            this.btnPause = new System.Windows.Forms.Button();
            this.lblListResultImportCardData = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayinDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
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
            this.panel2.Size = new System.Drawing.Size(670, 80);
            this.panel2.TabIndex = 59;
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
            this.lblPayInTitle.Size = new System.Drawing.Size(112, 14);
            this.lblPayInTitle.TabIndex = 0;
            this.lblPayInTitle.Text = "Nạp Tiền Vào Thẻ";
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 80);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(670, 1);
            this.line1.TabIndex = 60;
            this.line1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbnAmount);
            this.panel1.Controls.Add(this.cmbPartnerInfo);
            this.panel1.Controls.Add(this.lblPartnerKey);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 41);
            this.panel1.TabIndex = 139;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(427, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 152;
            this.label4.Text = "Số tiền:";
            // 
            // tbnAmount
            // 
            this.tbnAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbnAmount.Location = new System.Drawing.Point(486, 8);
            this.tbnAmount.Name = "tbnAmount";
            this.tbnAmount.Size = new System.Drawing.Size(175, 22);
            this.tbnAmount.TabIndex = 149;
            // 
            // cmbPartnerInfo
            // 
            this.cmbPartnerInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPartnerInfo.FormattingEnabled = true;
            this.cmbPartnerInfo.Location = new System.Drawing.Point(181, 8);
            this.cmbPartnerInfo.Name = "cmbPartnerInfo";
            this.cmbPartnerInfo.Size = new System.Drawing.Size(175, 22);
            this.cmbPartnerInfo.TabIndex = 145;
            // 
            // lblPartnerKey
            // 
            this.lblPartnerKey.AutoSize = true;
            this.lblPartnerKey.Location = new System.Drawing.Point(10, 11);
            this.lblPartnerKey.Name = "lblPartnerKey";
            this.lblPartnerKey.Size = new System.Drawing.Size(152, 16);
            this.lblPartnerKey.TabIndex = 144;
            this.lblPartnerKey.Text = "Tổ chức đồng phát hành:";
            // 
            // line2
            // 
            this.line2.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line2.Dock = System.Windows.Forms.DockStyle.Top;
            this.line2.Location = new System.Drawing.Point(0, 122);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(670, 1);
            this.line2.TabIndex = 140;
            this.line2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.btnListDevices);
            this.panel3.Controls.Add(this.dgvResult);
            this.panel3.Controls.Add(this.btnPause);
            this.panel3.Controls.Add(this.lblListResultImportCardData);
            this.panel3.Controls.Add(this.btnStart);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 123);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
            this.panel3.Size = new System.Drawing.Size(670, 364);
            this.panel3.TabIndex = 141;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(561, 314);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 26);
            this.btnClose.TabIndex = 141;
            this.btnClose.Text = "Đóng...";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.lblStatus);
            this.panel5.Controls.Add(this.lblCurrentStatus);
            this.panel5.Controls.Add(this.lblGuiChooseReader);
            this.panel5.Controls.Add(this.cmbReaders);
            this.panel5.Controls.Add(this.lblChooseReader);
            this.panel5.Location = new System.Drawing.Point(12, 148);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(649, 150);
            this.panel5.TabIndex = 17;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(0, 97);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(649, 35);
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
            this.lblCurrentStatus.Size = new System.Drawing.Size(649, 20);
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
            this.lblGuiChooseReader.Size = new System.Drawing.Size(649, 35);
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
            this.cmbReaders.Size = new System.Drawing.Size(649, 22);
            this.cmbReaders.TabIndex = 1;
            // 
            // lblChooseReader
            // 
            this.lblChooseReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChooseReader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseReader.Location = new System.Drawing.Point(0, 0);
            this.lblChooseReader.Name = "lblChooseReader";
            this.lblChooseReader.Size = new System.Drawing.Size(649, 20);
            this.lblChooseReader.TabIndex = 0;
            this.lblChooseReader.Text = "Chọn thiết bị đọc thẻ:";
            // 
            // btnListDevices
            // 
            this.btnListDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListDevices.Location = new System.Drawing.Point(455, 314);
            this.btnListDevices.Name = "btnListDevices";
            this.btnListDevices.Size = new System.Drawing.Size(100, 26);
            this.btnListDevices.TabIndex = 140;
            this.btnListDevices.Text = "Tìm Thiết Bị";
            this.btnListDevices.UseVisualStyleBackColor = true;
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
            this.colType,
            this.colMemberName,
            this.colAmount,
            this.colPayinDate,
            this.colResult,
            this.colBlank});
            this.dgvResult.Location = new System.Drawing.Point(13, 32);
            this.dgvResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(648, 114);
            this.dgvResult.TabIndex = 16;
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(349, 313);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(100, 26);
            this.btnPause.TabIndex = 139;
            this.btnPause.Text = "Tạm Ngưng";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // lblListResultImportCardData
            // 
            this.lblListResultImportCardData.AutoSize = true;
            this.lblListResultImportCardData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListResultImportCardData.Location = new System.Drawing.Point(14, 9);
            this.lblListResultImportCardData.Margin = new System.Windows.Forms.Padding(3);
            this.lblListResultImportCardData.Name = "lblListResultImportCardData";
            this.lblListResultImportCardData.Size = new System.Drawing.Size(113, 14);
            this.lblListResultImportCardData.TabIndex = 15;
            this.lblListResultImportCardData.Text = "Danh sách kết quả:";
            this.lblListResultImportCardData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(243, 314);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 26);
            this.btnStart.TabIndex = 138;
            this.btnStart.Text = "Bắt Đầu";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.DataPropertyName = "SerialNumber";
            this.colSerialNumber.HeaderText = "Mã Thẻ";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "Type";
            this.colType.HeaderText = "Loại Thẻ";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Visible = false;
            this.colType.Width = 150;
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
            // colPayinDate
            // 
            this.colPayinDate.DataPropertyName = "PayInDate";
            this.colPayinDate.HeaderText = "Ngày Nạp";
            this.colPayinDate.Name = "colPayinDate";
            this.colPayinDate.ReadOnly = true;
            this.colPayinDate.Width = 150;
            // 
            // colResult
            // 
            this.colResult.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colResult.DataPropertyName = "Result";
            this.colResult.HeaderText = "Kết Quả";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            // 
            // colBlank
            // 
            this.colBlank.HeaderText = "";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            this.colBlank.Width = 5;
            // 
            // FrmPayIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 473);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmPayIn";
            this.Text = "Nạp Tiền";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblPayInDesc;
        private System.Windows.Forms.Label lblPayInTitle;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbnAmount;
        private System.Windows.Forms.ComboBox cmbPartnerInfo;
        private System.Windows.Forms.Label lblPartnerKey;
        private CommonControls.Custom.Line line2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Label lblGuiChooseReader;
        private System.Windows.Forms.ComboBox cmbReaders;
        private System.Windows.Forms.Label lblChooseReader;
        private System.Windows.Forms.Button btnListDevices;
        private CommonControls.Custom.CommonDataGridView dgvResult;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblListResultImportCardData;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayinDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
    }
}