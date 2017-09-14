namespace CardChipService.Controls
{
    partial class CardReaderControl
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
            this.dgvResult = new CommonControls.Custom.CommonDataGridView();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // lblListResultImportCardData
            // 
            this.lblListResultImportCardData.AutoSize = true;
            this.lblListResultImportCardData.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListResultImportCardData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListResultImportCardData.Location = new System.Drawing.Point(0, 0);
            this.lblListResultImportCardData.Margin = new System.Windows.Forms.Padding(3);
            this.lblListResultImportCardData.Name = "lblListResultImportCardData";
            this.lblListResultImportCardData.Size = new System.Drawing.Size(113, 14);
            this.lblListResultImportCardData.TabIndex = 29;
            this.lblListResultImportCardData.Text = "Danh sách kết quả:";
            this.lblListResultImportCardData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(456, 298);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 26);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Đóng...";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnListDevices
            // 
            this.btnListDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListDevices.Location = new System.Drawing.Point(350, 298);
            this.btnListDevices.Name = "btnListDevices";
            this.btnListDevices.Size = new System.Drawing.Size(100, 26);
            this.btnListDevices.TabIndex = 27;
            this.btnListDevices.Text = "Tìm Thiết Bị";
            this.btnListDevices.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(244, 298);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(100, 26);
            this.btnPause.TabIndex = 26;
            this.btnPause.Text = "Tạm Ngưng";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(138, 298);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 26);
            this.btnStart.TabIndex = 25;
            this.btnStart.Text = "Bắt Đầu";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblStatus);
            this.panel5.Controls.Add(this.lblCurrentStatus);
            this.panel5.Controls.Add(this.lblGuiChooseReader);
            this.panel5.Controls.Add(this.cmbReaders);
            this.panel5.Controls.Add(this.lblChooseReader);
            this.panel5.Location = new System.Drawing.Point(3, 146);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(564, 133);
            this.panel5.TabIndex = 24;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(0, 96);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(564, 35);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Chưa kết nối với thiết bị đọc";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStatus.Location = new System.Drawing.Point(0, 76);
            this.lblCurrentStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(564, 20);
            this.lblCurrentStatus.TabIndex = 3;
            this.lblCurrentStatus.Text = "Trạng thái hiện tại:";
            // 
            // lblGuiChooseReader
            // 
            this.lblGuiChooseReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGuiChooseReader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuiChooseReader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGuiChooseReader.Location = new System.Drawing.Point(0, 41);
            this.lblGuiChooseReader.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblGuiChooseReader.Name = "lblGuiChooseReader";
            this.lblGuiChooseReader.Size = new System.Drawing.Size(564, 35);
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
            this.cmbReaders.Size = new System.Drawing.Size(564, 21);
            this.cmbReaders.TabIndex = 1;
            // 
            // lblChooseReader
            // 
            this.lblChooseReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChooseReader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseReader.Location = new System.Drawing.Point(0, 0);
            this.lblChooseReader.Name = "lblChooseReader";
            this.lblChooseReader.Size = new System.Drawing.Size(564, 20);
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
            this.colType,
            this.colResult,
            this.colBlank});
            this.dgvResult.Location = new System.Drawing.Point(-2, 19);
            this.dgvResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(570, 127);
            this.dgvResult.TabIndex = 30;
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
            // CardReaderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.lblListResultImportCardData);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnListDevices);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel5);
            this.MaximumSize = new System.Drawing.Size(570, 330);
            this.MinimumSize = new System.Drawing.Size(570, 330);
            this.Name = "CardReaderControl";
            this.Size = new System.Drawing.Size(570, 330);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonControls.Custom.CommonDataGridView dgvResult;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
    }
}
