namespace sTimeKeeping.WorkItems
{
    partial class TimeKeepingEvent
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
            this.btnListDevices = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblListResultReadCardData = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbxOrgCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxDecription = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateIn = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvResult = new CommonControls.Custom.CommonDataGridView();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTenEvent = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblThemUngDung = new System.Windows.Forms.Label();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lbNote = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnListDevices
            // 
            this.btnListDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListDevices.Location = new System.Drawing.Point(340, 18);
            this.btnListDevices.Name = "btnListDevices";
            this.btnListDevices.Size = new System.Drawing.Size(100, 26);
            this.btnListDevices.TabIndex = 13;
            this.btnListDevices.Text = "Chấp nhận";
            this.btnListDevices.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(458, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 26);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Hủy";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblListResultReadCardData
            // 
            this.lblListResultReadCardData.AutoSize = true;
            this.lblListResultReadCardData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListResultReadCardData.Location = new System.Drawing.Point(15, 8);
            this.lblListResultReadCardData.Margin = new System.Windows.Forms.Padding(3);
            this.lblListResultReadCardData.Name = "lblListResultReadCardData";
            this.lblListResultReadCardData.Size = new System.Drawing.Size(38, 14);
            this.lblListResultReadCardData.TabIndex = 15;
            this.lblListResultReadCardData.Text = "Ngày:";
            this.lblListResultReadCardData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnListDevices);
            this.panel5.Controls.Add(this.btnClose);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(10, 156);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(584, 51);
            this.panel5.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbxOrgCode);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.tbxDecription);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.dtpDateIn);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lblListResultReadCardData);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 156);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel3.Size = new System.Drawing.Size(604, 212);
            this.panel3.TabIndex = 83;
            // 
            // cbxOrgCode
            // 
            this.cbxOrgCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOrgCode.FormattingEnabled = true;
            this.cbxOrgCode.Location = new System.Drawing.Point(408, 6);
            this.cbxOrgCode.Name = "cbxOrgCode";
            this.cbxOrgCode.Size = new System.Drawing.Size(179, 21);
            this.cbxOrgCode.TabIndex = 94;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 93;
            this.label4.Text = "Màu hiển thị:";
            // 
            // tbxDecription
            // 
            this.tbxDecription.Enabled = false;
            this.tbxDecription.Location = new System.Drawing.Point(90, 71);
            this.tbxDecription.Multiline = true;
            this.tbxDecription.Name = "tbxDecription";
            this.tbxDecription.Size = new System.Drawing.Size(497, 79);
            this.tbxDecription.TabIndex = 88;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(408, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(179, 20);
            this.textBox2.TabIndex = 92;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 87;
            this.label1.Text = "Mô tả:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(90, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 20);
            this.textBox1.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 91;
            this.label3.Text = "Số giờ:";
            // 
            // dtpDateIn
            // 
            this.dtpDateIn.CustomFormat = "dd/MM/yyyy";
            this.dtpDateIn.Enabled = false;
            this.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateIn.Location = new System.Drawing.Point(90, 6);
            this.dtpDateIn.Name = "dtpDateIn";
            this.dtpDateIn.Size = new System.Drawing.Size(183, 20);
            this.dtpDateIn.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 89;
            this.label2.Text = "Giờ bắt đầu:";
            // 
            // colBlank
            // 
            this.colBlank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBlank.HeaderText = "";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "Type";
            this.colType.HeaderText = "Loại Thẻ";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 150;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.DataPropertyName = "SerialNumber";
            this.colSerialNumber.HeaderText = "Mã Thẻ";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToOrderColumns = true;
            this.dgvResult.AllowUserToResizeRows = false;
            this.dgvResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvResult.ColumnHeadersHeight = 26;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSerialNumber,
            this.colType,
            this.colResult,
            this.colBlank});
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(0, 156);
            this.dgvResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(604, 212);
            this.dgvResult.TabIndex = 82;
            // 
            // colResult
            // 
            this.colResult.DataPropertyName = "Result";
            this.colResult.HeaderText = "Kết Quả";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            this.colResult.Width = 300;
            // 
            // lblTenEvent
            // 
            this.lblTenEvent.AutoSize = true;
            this.lblTenEvent.Location = new System.Drawing.Point(15, 18);
            this.lblTenEvent.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblTenEvent.Name = "lblTenEvent";
            this.lblTenEvent.Size = new System.Drawing.Size(66, 13);
            this.lblTenEvent.TabIndex = 85;
            this.lblTenEvent.Text = "Tên sự kiện:";
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Top;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(0, 124);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(604, 32);
            this.label20.TabIndex = 80;
            this.label20.Text = "Thông tin chi tiết:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblThemUngDung
            // 
            this.lblThemUngDung.AutoSize = true;
            this.lblThemUngDung.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThemUngDung.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblThemUngDung.Location = new System.Drawing.Point(14, 16);
            this.lblThemUngDung.Name = "lblThemUngDung";
            this.lblThemUngDung.Size = new System.Drawing.Size(142, 14);
            this.lblThemUngDung.TabIndex = 0;
            this.lblThemUngDung.Text = "Thêm thông tin event";
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.Controls.Add(this.tbxName);
            this.pnlFilterBox.Controls.Add(this.lblTenEvent);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 68);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(604, 56);
            this.pnlFilterBox.TabIndex = 81;
            // 
            // tbxName
            // 
            this.tbxName.Enabled = false;
            this.tbxName.Location = new System.Drawing.Point(83, 15);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(505, 20);
            this.tbxName.TabIndex = 86;
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNote.Location = new System.Drawing.Point(14, 38);
            this.lbNote.Margin = new System.Windows.Forms.Padding(3);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(463, 14);
            this.lbNote.TabIndex = 1;
            this.lbNote.Text = "Thêm hoặc sửa các thông tin event của hệ thống. Dùng để chấm công nhân viên.";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lbNote);
            this.panel9.Controls.Add(this.lblThemUngDung);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(604, 68);
            this.panel9.TabIndex = 79;
            // 
            // TimeKeepingEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 368);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.pnlFilterBox);
            this.Controls.Add(this.panel9);
            this.Name = "TimeKeepingEvent";
            this.Text = "TimeKeepingEvent";
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnListDevices;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblListResultReadCardData;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private CommonControls.Custom.CommonDataGridView dgvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.Label lblTenEvent;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblThemUngDung;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TextBox tbxDecription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateIn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxOrgCode;
    }
}