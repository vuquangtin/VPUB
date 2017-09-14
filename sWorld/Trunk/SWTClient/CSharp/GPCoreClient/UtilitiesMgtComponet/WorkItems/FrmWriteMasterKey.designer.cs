namespace UtilitiesMgtComponet.WorkItems
{
    partial class FrmWriteMasterKey
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblGuiClearCardData = new System.Windows.Forms.Label();
            this.lblClearCardData = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvResult = new CommonControls.Custom.CommonDataGridView();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblListResultImportCardData = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnListDevices = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.lblGuiChooseReader = new System.Windows.Forms.Label();
            this.cmbReaders = new System.Windows.Forms.ComboBox();
            this.lblChooseReader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblChooseSubjectPerso = new System.Windows.Forms.Label();
            this.cmbMasterInfo = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Line3DStyle = CommonControls.Custom.Line3DStyle.Inset;
            this.line1.Location = new System.Drawing.Point(0, 50);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(594, 2);
            this.line1.TabIndex = 59;
            this.line1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblGuiClearCardData);
            this.panel2.Controls.Add(this.lblClearCardData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 50);
            this.panel2.TabIndex = 58;
            // 
            // lblGuiClearCardData
            // 
            this.lblGuiClearCardData.AutoSize = true;
            this.lblGuiClearCardData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuiClearCardData.Location = new System.Drawing.Point(9, 26);
            this.lblGuiClearCardData.Margin = new System.Windows.Forms.Padding(3);
            this.lblGuiClearCardData.Name = "lblGuiClearCardData";
            this.lblGuiClearCardData.Size = new System.Drawing.Size(294, 14);
            this.lblGuiClearCardData.TabIndex = 1;
            this.lblGuiClearCardData.Text = "Quét thẻ để nhập khóa của chủ thể phát hành thẻ.";
            // 
            // lblClearCardData
            // 
            this.lblClearCardData.AutoSize = true;
            this.lblClearCardData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearCardData.Location = new System.Drawing.Point(9, 9);
            this.lblClearCardData.Name = "lblClearCardData";
            this.lblClearCardData.Size = new System.Drawing.Size(216, 14);
            this.lblClearCardData.TabIndex = 0;
            this.lblClearCardData.Text = "Nhập khóa của chủ thể phát hành";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvResult);
            this.panel3.Controls.Add(this.lblListResultImportCardData);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnListDevices);
            this.panel3.Controls.Add(this.btnPause);
            this.panel3.Controls.Add(this.btnStart);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 90);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel3.Size = new System.Drawing.Size(594, 365);
            this.panel3.TabIndex = 61;
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
            this.colResult,
            this.colBlank});
            this.dgvResult.Location = new System.Drawing.Point(12, 27);
            this.dgvResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(570, 127);
            this.dgvResult.TabIndex = 16;
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
            this.colType.Width = 150;
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
            // lblListResultImportCardData
            // 
            this.lblListResultImportCardData.AutoSize = true;
            this.lblListResultImportCardData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListResultImportCardData.Location = new System.Drawing.Point(12, 8);
            this.lblListResultImportCardData.Margin = new System.Windows.Forms.Padding(3);
            this.lblListResultImportCardData.Name = "lblListResultImportCardData";
            this.lblListResultImportCardData.Size = new System.Drawing.Size(113, 14);
            this.lblListResultImportCardData.TabIndex = 15;
            this.lblListResultImportCardData.Text = "Danh sách kết quả:";
            this.lblListResultImportCardData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(482, 327);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 26);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Đóng...";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnListDevices
            // 
            this.btnListDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListDevices.Location = new System.Drawing.Point(376, 327);
            this.btnListDevices.Name = "btnListDevices";
            this.btnListDevices.Size = new System.Drawing.Size(100, 26);
            this.btnListDevices.TabIndex = 13;
            this.btnListDevices.Text = "Tìm Thiết Bị";
            this.btnListDevices.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(270, 327);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(100, 26);
            this.btnPause.TabIndex = 12;
            this.btnPause.Text = "Tạm Ngưng";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(164, 327);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 26);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Bắt Đầu";
            this.btnStart.UseVisualStyleBackColor = true;
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
            this.panel5.Location = new System.Drawing.Point(13, 159);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(569, 150);
            this.panel5.TabIndex = 10;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(0, 97);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(569, 35);
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
            this.lblCurrentStatus.Size = new System.Drawing.Size(569, 20);
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
            this.lblGuiChooseReader.Size = new System.Drawing.Size(569, 35);
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
            this.cmbReaders.Size = new System.Drawing.Size(569, 22);
            this.cmbReaders.TabIndex = 1;
            // 
            // lblChooseReader
            // 
            this.lblChooseReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChooseReader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseReader.Location = new System.Drawing.Point(0, 0);
            this.lblChooseReader.Name = "lblChooseReader";
            this.lblChooseReader.Size = new System.Drawing.Size(569, 20);
            this.lblChooseReader.TabIndex = 0;
            this.lblChooseReader.Text = "Chọn thiết bị đọc thẻ:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblChooseSubjectPerso);
            this.panel1.Controls.Add(this.cmbMasterInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 38);
            this.panel1.TabIndex = 60;
            // 
            // lblChooseSubjectPerso
            // 
            this.lblChooseSubjectPerso.AutoSize = true;
            this.lblChooseSubjectPerso.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseSubjectPerso.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChooseSubjectPerso.Location = new System.Drawing.Point(9, 10);
            this.lblChooseSubjectPerso.Name = "lblChooseSubjectPerso";
            this.lblChooseSubjectPerso.Size = new System.Drawing.Size(146, 14);
            this.lblChooseSubjectPerso.TabIndex = 1;
            this.lblChooseSubjectPerso.Text = "Chọn chủ thể phát hành:";
            // 
            // cmbMasterInfo
            // 
            this.cmbMasterInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMasterInfo.FormattingEnabled = true;
            this.cmbMasterInfo.Location = new System.Drawing.Point(161, 7);
            this.cmbMasterInfo.Name = "cmbMasterInfo";
            this.cmbMasterInfo.Size = new System.Drawing.Size(421, 22);
            this.cmbMasterInfo.TabIndex = 55;
            // 
            // frmImportMasterKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 455);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmImportMasterKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập Khóa Của Chủ Thể Phát Hành";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CommonControls.Custom.CommonDataGridView dgvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
        private System.Windows.Forms.Label lblListResultImportCardData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnListDevices;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Label lblGuiChooseReader;
        private System.Windows.Forms.ComboBox cmbReaders;
        private System.Windows.Forms.Label lblChooseReader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblChooseSubjectPerso;
        private System.Windows.Forms.ComboBox cmbMasterInfo;
        private System.Windows.Forms.Label lblGuiClearCardData;
        private System.Windows.Forms.Label lblClearCardData;

    }
}