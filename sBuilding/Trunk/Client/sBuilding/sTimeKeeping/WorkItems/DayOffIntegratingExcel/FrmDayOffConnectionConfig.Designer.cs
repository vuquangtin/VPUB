namespace sTimeKeeping.WorkItems.DayOffIntegratingExcel
{
    partial class FrmDayOffConnectionConfig
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbxStartRowIndex = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBoxMemberInfo = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmbNote = new System.Windows.Forms.ComboBox();
            this.lblMemberCode = new System.Windows.Forms.Label();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cbxMemberCode = new System.Windows.Forms.ComboBox();
            this.lblTypeDayOff = new System.Windows.Forms.Label();
            this.cmbDate = new System.Windows.Forms.ComboBox();
            this.cbxMemberName = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbl1_FrmConnectionConfig = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStartRowIndex)).BeginInit();
            this.groupBoxMemberInfo.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.groupBoxMemberInfo);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 365);
            this.panel1.TabIndex = 66;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbxStartRowIndex);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 188);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(663, 134);
            this.panel3.TabIndex = 59;
            // 
            // tbxStartRowIndex
            // 
            this.tbxStartRowIndex.Location = new System.Drawing.Point(406, 9);
            this.tbxStartRowIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbxStartRowIndex.Name = "tbxStartRowIndex";
            this.tbxStartRowIndex.Size = new System.Drawing.Size(89, 22);
            this.tbxStartRowIndex.TabIndex = 43;
            this.tbxStartRowIndex.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 11);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 11, 3, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(339, 16);
            this.label14.TabIndex = 39;
            this.label14.Text = "Cấu hình vị trí dòng dữ liệu đầu tiên trên tập tin MS Excel:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(500, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(152, 16);
            this.label15.TabIndex = 41;
            this.label15.Text = "(không tính dòng tiêu đề)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 45);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 11, 3, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(419, 48);
            this.label16.TabIndex = 42;
            this.label16.Text = "Lưu ý:\r\n- Chọn các cột dữ liệu tương ứng trên tập tin MS Excel, còn lại để trống." +
    "\r\n- Định dạng kiểu ngày-tháng-năm (Ví dụ: 20-07-1989)\r\n";
            // 
            // groupBoxMemberInfo
            // 
            this.groupBoxMemberInfo.Controls.Add(this.lblDescription);
            this.groupBoxMemberInfo.Controls.Add(this.cmbNote);
            this.groupBoxMemberInfo.Controls.Add(this.lblMemberCode);
            this.groupBoxMemberInfo.Controls.Add(this.lblMemberName);
            this.groupBoxMemberInfo.Controls.Add(this.lblDate);
            this.groupBoxMemberInfo.Controls.Add(this.cmbType);
            this.groupBoxMemberInfo.Controls.Add(this.cbxMemberCode);
            this.groupBoxMemberInfo.Controls.Add(this.lblTypeDayOff);
            this.groupBoxMemberInfo.Controls.Add(this.cmbDate);
            this.groupBoxMemberInfo.Controls.Add(this.cbxMemberName);
            this.groupBoxMemberInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxMemberInfo.Location = new System.Drawing.Point(0, 89);
            this.groupBoxMemberInfo.Name = "groupBoxMemberInfo";
            this.groupBoxMemberInfo.Padding = new System.Windows.Forms.Padding(3, 11, 3, 3);
            this.groupBoxMemberInfo.Size = new System.Drawing.Size(663, 99);
            this.groupBoxMemberInfo.TabIndex = 57;
            this.groupBoxMemberInfo.TabStop = false;
            this.groupBoxMemberInfo.Text = "Thông tin nghỉ phép";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(7, 83);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(78, 16);
            this.lblDescription.TabIndex = 54;
            this.lblDescription.Text = "Cột Ghi chú:";
            this.lblDescription.Visible = false;
            // 
            // cmbNote
            // 
            this.cmbNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNote.FormattingEnabled = true;
            this.cmbNote.Location = new System.Drawing.Point(160, 80);
            this.cmbNote.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.cmbNote.Name = "cmbNote";
            this.cmbNote.Size = new System.Drawing.Size(87, 22);
            this.cmbNote.TabIndex = 56;
            this.cmbNote.Visible = false;
            // 
            // lblMemberCode
            // 
            this.lblMemberCode.AutoSize = true;
            this.lblMemberCode.Location = new System.Drawing.Point(7, 27);
            this.lblMemberCode.Name = "lblMemberCode";
            this.lblMemberCode.Size = new System.Drawing.Size(88, 16);
            this.lblMemberCode.TabIndex = 21;
            this.lblMemberCode.Text = "Cột Mã CBCC:";
            // 
            // lblMemberName
            // 
            this.lblMemberName.AutoSize = true;
            this.lblMemberName.Location = new System.Drawing.Point(363, 27);
            this.lblMemberName.Margin = new System.Windows.Forms.Padding(12, 0, 3, 0);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(125, 16);
            this.lblMemberName.TabIndex = 26;
            this.lblMemberName.Text = "Cột Họ và tên CBCC:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(7, 55);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(92, 16);
            this.lblDate.TabIndex = 27;
            this.lblDate.Text = "Cột Ngày nghỉ:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(541, 52);
            this.cmbType.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(87, 22);
            this.cmbType.TabIndex = 47;
            // 
            // cbxMemberCode
            // 
            this.cbxMemberCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMemberCode.FormattingEnabled = true;
            this.cbxMemberCode.Location = new System.Drawing.Point(160, 24);
            this.cbxMemberCode.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.cbxMemberCode.Name = "cbxMemberCode";
            this.cbxMemberCode.Size = new System.Drawing.Size(87, 22);
            this.cbxMemberCode.TabIndex = 30;
            // 
            // lblTypeDayOff
            // 
            this.lblTypeDayOff.AutoSize = true;
            this.lblTypeDayOff.Location = new System.Drawing.Point(363, 55);
            this.lblTypeDayOff.Name = "lblTypeDayOff";
            this.lblTypeDayOff.Size = new System.Drawing.Size(119, 16);
            this.lblTypeDayOff.TabIndex = 44;
            this.lblTypeDayOff.Text = "Cột Loại nghỉ phép:";
            // 
            // cmbDate
            // 
            this.cmbDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDate.FormattingEnabled = true;
            this.cmbDate.Location = new System.Drawing.Point(160, 52);
            this.cmbDate.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.cmbDate.Name = "cmbDate";
            this.cmbDate.Size = new System.Drawing.Size(87, 22);
            this.cmbDate.TabIndex = 35;
            // 
            // cbxMemberName
            // 
            this.cbxMemberName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMemberName.FormattingEnabled = true;
            this.cbxMemberName.Location = new System.Drawing.Point(541, 24);
            this.cbxMemberName.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.cbxMemberName.Name = "cbxMemberName";
            this.cbxMemberName.Size = new System.Drawing.Size(87, 22);
            this.cbxMemberName.TabIndex = 36;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtInputFilePath);
            this.panel4.Controls.Add(this.btnSelectFile);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(663, 89);
            this.panel4.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chỉ đường dẫn đến tập tin MS Excel chứa dữ liệu cần tích hợp.";
            // 
            // txtInputFilePath
            // 
            this.txtInputFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFilePath.Location = new System.Drawing.Point(7, 27);
            this.txtInputFilePath.Name = "txtInputFilePath";
            this.txtInputFilePath.ReadOnly = true;
            this.txtInputFilePath.Size = new System.Drawing.Size(586, 22);
            this.txtInputFilePath.TabIndex = 4;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Location = new System.Drawing.Point(601, 26);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(58, 25);
            this.btnSelectFile.TabIndex = 5;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 11, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Cấu hình vị trí các cột dữ liệu trên tập tin MS Excel:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 322);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(663, 43);
            this.panel2.TabIndex = 53;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(406, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(117, 28);
            this.btnNext.TabIndex = 18;
            this.btnNext.Text = "Tiếp Tục";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(540, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 28);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lbl1_FrmConnectionConfig);
            this.panel9.Controls.Add(this.label10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(663, 74);
            this.panel9.TabIndex = 64;
            // 
            // lbl1_FrmConnectionConfig
            // 
            this.lbl1_FrmConnectionConfig.AutoSize = true;
            this.lbl1_FrmConnectionConfig.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1_FrmConnectionConfig.Location = new System.Drawing.Point(14, 42);
            this.lbl1_FrmConnectionConfig.Margin = new System.Windows.Forms.Padding(3);
            this.lbl1_FrmConnectionConfig.Name = "lbl1_FrmConnectionConfig";
            this.lbl1_FrmConnectionConfig.Size = new System.Drawing.Size(449, 14);
            this.lbl1_FrmConnectionConfig.TabIndex = 1;
            this.lbl1_FrmConnectionConfig.Text = "Phân tích dữ liệu từ tập tin MS Excel và đồng bộ với cơ sở dữ liệu của hệ thống.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tích Hợp Dữ Liệu";
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Line3DStyle = CommonControls.Custom.Line3DStyle.Inset;
            this.line1.Location = new System.Drawing.Point(0, 0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(663, 2);
            this.line1.TabIndex = 65;
            this.line1.TabStop = false;
            // 
            // FrmDayOffConnectionConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 441);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.line1);
            this.Name = "FrmDayOffConnectionConfig";
            this.Text = "Tích Hợp - Cấu Hình Kết Nối";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStartRowIndex)).EndInit();
            this.groupBoxMemberInfo.ResumeLayout(false);
            this.groupBoxMemberInfo.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown tbxStartRowIndex;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBoxMemberInfo;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cmbNote;
        private System.Windows.Forms.Label lblMemberCode;
        private System.Windows.Forms.Label lblMemberName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cbxMemberCode;
        private System.Windows.Forms.Label lblTypeDayOff;
        private System.Windows.Forms.ComboBox cmbDate;
        private System.Windows.Forms.ComboBox cbxMemberName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputFilePath;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbl1_FrmConnectionConfig;
        private System.Windows.Forms.Label label10;
        private CommonControls.Custom.Line line1;
    }
}