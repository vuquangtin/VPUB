namespace sTimeKeeping.WorkItems
{
    partial class TimeKeepingConfig
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
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbNote = new System.Windows.Forms.Label();
            this.lblThemUngDung = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.numericBuoi = new System.Windows.Forms.NumericUpDown();
            this.lblBuoi = new System.Windows.Forms.Label();
            this.lblThu = new System.Windows.Forms.Label();
            this.dgvResult = new CommonControls.Custom.CommonDataGridView();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView = new CommonControls.Custom.CommonDataGridView();
            this.dataGridViewTimeSession = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTimeBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTimeEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTimeDelate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewDecription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblListResultReadCardData = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnListDevices = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.comboThu = new System.Windows.Forms.ComboBox();
            this.panel9.SuspendLayout();
            this.pnlFilterBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBuoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lbNote);
            this.panel9.Controls.Add(this.lblThemUngDung);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(643, 68);
            this.panel9.TabIndex = 63;
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNote.Location = new System.Drawing.Point(14, 38);
            this.lbNote.Margin = new System.Windows.Forms.Padding(3);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(520, 14);
            this.lbNote.TabIndex = 1;
            this.lbNote.Text = "Thêm hoặc sửa các cấu hình thời gian làm việc của hệ thống. Dùng để chấm công nhâ" +
    "n viên.";
            // 
            // lblThemUngDung
            // 
            this.lblThemUngDung.AutoSize = true;
            this.lblThemUngDung.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThemUngDung.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblThemUngDung.Location = new System.Drawing.Point(14, 16);
            this.lblThemUngDung.Name = "lblThemUngDung";
            this.lblThemUngDung.Size = new System.Drawing.Size(172, 14);
            this.lblThemUngDung.TabIndex = 0;
            this.lblThemUngDung.Text = "Cấu hình thời gian làm việc";
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Top;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(0, 68);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(643, 27);
            this.label20.TabIndex = 75;
            this.label20.Text = "Thông tin thời gian làm việc:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.Controls.Add(this.comboThu);
            this.pnlFilterBox.Controls.Add(this.numericBuoi);
            this.pnlFilterBox.Controls.Add(this.lblBuoi);
            this.pnlFilterBox.Controls.Add(this.lblThu);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 95);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilterBox.Size = new System.Drawing.Size(643, 48);
            this.pnlFilterBox.TabIndex = 76;
            // 
            // numericBuoi
            // 
            this.numericBuoi.Location = new System.Drawing.Point(276, 16);
            this.numericBuoi.Name = "numericBuoi";
            this.numericBuoi.Size = new System.Drawing.Size(76, 20);
            this.numericBuoi.TabIndex = 88;
            // 
            // lblBuoi
            // 
            this.lblBuoi.AutoSize = true;
            this.lblBuoi.Location = new System.Drawing.Point(193, 18);
            this.lblBuoi.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblBuoi.Name = "lblBuoi";
            this.lblBuoi.Size = new System.Drawing.Size(74, 13);
            this.lblBuoi.TabIndex = 87;
            this.lblBuoi.Text = "Số buổi/ngày:";
            // 
            // lblThu
            // 
            this.lblThu.AutoSize = true;
            this.lblThu.Location = new System.Drawing.Point(15, 19);
            this.lblThu.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblThu.Name = "lblThu";
            this.lblThu.Size = new System.Drawing.Size(29, 13);
            this.lblThu.TabIndex = 85;
            this.lblThu.Text = "Thứ:";
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
            this.dgvResult.Location = new System.Drawing.Point(0, 143);
            this.dgvResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(643, 207);
            this.dgvResult.TabIndex = 77;
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
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView);
            this.panel3.Controls.Add(this.lblListResultReadCardData);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 143);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel3.Size = new System.Drawing.Size(643, 207);
            this.panel3.TabIndex = 78;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersHeight = 26;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTimeSession,
            this.dataGridViewTimeBegin,
            this.dataGridViewTimeEnd,
            this.dataGridViewTimeDelate,
            this.colColor,
            this.dataGridViewDecription});
            this.dataGridView.Location = new System.Drawing.Point(17, 27);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(610, 123);
            this.dataGridView.TabIndex = 16;
            // 
            // dataGridViewTimeSession
            // 
            this.dataGridViewTimeSession.DataPropertyName = "SerialNumber";
            this.dataGridViewTimeSession.HeaderText = "Buổi";
            this.dataGridViewTimeSession.Name = "dataGridViewTimeSession";
            this.dataGridViewTimeSession.ReadOnly = true;
            // 
            // dataGridViewTimeBegin
            // 
            this.dataGridViewTimeBegin.DataPropertyName = "SerialNumber";
            this.dataGridViewTimeBegin.HeaderText = "Giờ bắt đầu";
            this.dataGridViewTimeBegin.Name = "dataGridViewTimeBegin";
            this.dataGridViewTimeBegin.ReadOnly = true;
            // 
            // dataGridViewTimeEnd
            // 
            this.dataGridViewTimeEnd.DataPropertyName = "Type";
            this.dataGridViewTimeEnd.HeaderText = "Số giờ làm việc";
            this.dataGridViewTimeEnd.Name = "dataGridViewTimeEnd";
            this.dataGridViewTimeEnd.ReadOnly = true;
            // 
            // dataGridViewTimeDelate
            // 
            this.dataGridViewTimeDelate.DataPropertyName = "Result";
            this.dataGridViewTimeDelate.HeaderText = "Thời gian trễ";
            this.dataGridViewTimeDelate.Name = "dataGridViewTimeDelate";
            this.dataGridViewTimeDelate.ReadOnly = true;
            // 
            // colColor
            // 
            this.colColor.HeaderText = "Màu hiển thị";
            this.colColor.Name = "colColor";
            this.colColor.ReadOnly = true;
            // 
            // dataGridViewDecription
            // 
            this.dataGridViewDecription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewDecription.HeaderText = "Mô tả";
            this.dataGridViewDecription.Name = "dataGridViewDecription";
            this.dataGridViewDecription.ReadOnly = true;
            // 
            // lblListResultReadCardData
            // 
            this.lblListResultReadCardData.AutoSize = true;
            this.lblListResultReadCardData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListResultReadCardData.Location = new System.Drawing.Point(15, 8);
            this.lblListResultReadCardData.Margin = new System.Windows.Forms.Padding(3);
            this.lblListResultReadCardData.Name = "lblListResultReadCardData";
            this.lblListResultReadCardData.Size = new System.Drawing.Size(109, 14);
            this.lblListResultReadCardData.TabIndex = 15;
            this.lblListResultReadCardData.Text = "Cấu hình thời gian:";
            this.lblListResultReadCardData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnListDevices);
            this.panel5.Controls.Add(this.btnClose);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(10, 151);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(623, 51);
            this.panel5.TabIndex = 10;
            // 
            // btnListDevices
            // 
            this.btnListDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListDevices.Location = new System.Drawing.Point(379, 18);
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
            this.btnClose.Location = new System.Drawing.Point(497, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 26);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Hủy";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // comboThu
            // 
            this.comboThu.FormattingEnabled = true;
            this.comboThu.Location = new System.Drawing.Point(54, 16);
            this.comboThu.Name = "comboThu";
            this.comboThu.Size = new System.Drawing.Size(121, 21);
            this.comboThu.TabIndex = 89;
            // 
            // TimeKeepingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 350);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.pnlFilterBox);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.panel9);
            this.Name = "TimeKeepingConfig";
            this.Text = "TimeKeepingConfig";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBuoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Label lblThemUngDung;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Label lblThu;
        private CommonControls.Custom.CommonDataGridView dgvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
        private System.Windows.Forms.Panel panel3;
        private CommonControls.Custom.CommonDataGridView dataGridView;
        private System.Windows.Forms.Label lblListResultReadCardData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnListDevices;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTimeSession;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTimeBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTimeEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTimeDelate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewDecription;
        private System.Windows.Forms.NumericUpDown numericBuoi;
        private System.Windows.Forms.Label lblBuoi;
        private System.Windows.Forms.ComboBox comboThu;



    }
}