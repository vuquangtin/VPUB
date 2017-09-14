namespace sTimeKeeping.WorkItems.EventIntegratingExcel
{
    partial class FrmEventConnectionConfig
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
            this.lbl1_FrmConnectionConfig = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbSubOrg = new System.Windows.Forms.ComboBox();
            this.lblSubOrg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupMemberContact = new System.Windows.Forms.GroupBox();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.cbxMemberName = new System.Windows.Forms.ComboBox();
            this.lblMemberCode = new System.Windows.Forms.Label();
            this.cbxMemberCode = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbxStartRowIndex = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBoxMemberInfo = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmbDescription = new System.Windows.Forms.ComboBox();
            this.lblEventName = new System.Windows.Forms.Label();
            this.lblHourBegin = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.cmbHourKeeping = new System.Windows.Forms.ComboBox();
            this.cmbEventName = new System.Windows.Forms.ComboBox();
            this.lblHourKeeping = new System.Windows.Forms.Label();
            this.cmbDate = new System.Windows.Forms.ComboBox();
            this.cmbHourBegin = new System.Windows.Forms.ComboBox();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupMemberContact.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStartRowIndex)).BeginInit();
            this.groupBoxMemberInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lbl1_FrmConnectionConfig);
            this.panel9.Controls.Add(this.label10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(662, 69);
            this.panel9.TabIndex = 61;
            // 
            // lbl1_FrmConnectionConfig
            // 
            this.lbl1_FrmConnectionConfig.AutoSize = true;
            this.lbl1_FrmConnectionConfig.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1_FrmConnectionConfig.Location = new System.Drawing.Point(12, 39);
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
            this.label10.Location = new System.Drawing.Point(12, 22);
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
            this.line1.Location = new System.Drawing.Point(0, 69);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(662, 2);
            this.line1.TabIndex = 62;
            this.line1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 396);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(662, 40);
            this.panel2.TabIndex = 53;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(442, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 26);
            this.btnNext.TabIndex = 18;
            this.btnNext.Text = "Tiếp Tục";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(557, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmbSubOrg);
            this.panel4.Controls.Add(this.lblSubOrg);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtInputFilePath);
            this.panel4.Controls.Add(this.btnSelectFile);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(662, 118);
            this.panel4.TabIndex = 56;
            // 
            // cmbSubOrg
            // 
            this.cmbSubOrg.FormattingEnabled = true;
            this.cmbSubOrg.Location = new System.Drawing.Point(137, 61);
            this.cmbSubOrg.Name = "cmbSubOrg";
            this.cmbSubOrg.Size = new System.Drawing.Size(158, 22);
            this.cmbSubOrg.TabIndex = 33;
            // 
            // lblSubOrg
            // 
            this.lblSubOrg.AutoSize = true;
            this.lblSubOrg.Location = new System.Drawing.Point(6, 64);
            this.lblSubOrg.Name = "lblSubOrg";
            this.lblSubOrg.Size = new System.Drawing.Size(73, 16);
            this.lblSubOrg.TabIndex = 31;
            this.lblSubOrg.Text = "Phòng ban:";
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
            this.txtInputFilePath.Location = new System.Drawing.Point(6, 25);
            this.txtInputFilePath.Name = "txtInputFilePath";
            this.txtInputFilePath.ReadOnly = true;
            this.txtInputFilePath.Size = new System.Drawing.Size(597, 22);
            this.txtInputFilePath.TabIndex = 4;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Location = new System.Drawing.Point(609, 24);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(50, 23);
            this.btnSelectFile.TabIndex = 5;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Cấu hình vị trí các cột dữ liệu trên tập tin MS Excel:";
            // 
            // groupMemberContact
            // 
            this.groupMemberContact.Controls.Add(this.lblMemberName);
            this.groupMemberContact.Controls.Add(this.cbxMemberName);
            this.groupMemberContact.Controls.Add(this.lblMemberCode);
            this.groupMemberContact.Controls.Add(this.cbxMemberCode);
            this.groupMemberContact.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupMemberContact.Location = new System.Drawing.Point(0, 230);
            this.groupMemberContact.Name = "groupMemberContact";
            this.groupMemberContact.Size = new System.Drawing.Size(662, 59);
            this.groupMemberContact.TabIndex = 58;
            this.groupMemberContact.TabStop = false;
            this.groupMemberContact.Text = "Thông tin thành viên";
            // 
            // lblMemberName
            // 
            this.lblMemberName.AutoSize = true;
            this.lblMemberName.Location = new System.Drawing.Point(311, 25);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(125, 16);
            this.lblMemberName.TabIndex = 36;
            this.lblMemberName.Text = "Cột Họ và tên CBCC:";
            // 
            // cbxMemberName
            // 
            this.cbxMemberName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMemberName.FormattingEnabled = true;
            this.cbxMemberName.Location = new System.Drawing.Point(464, 22);
            this.cbxMemberName.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cbxMemberName.Name = "cbxMemberName";
            this.cbxMemberName.Size = new System.Drawing.Size(75, 22);
            this.cbxMemberName.TabIndex = 37;
            // 
            // lblMemberCode
            // 
            this.lblMemberCode.AutoSize = true;
            this.lblMemberCode.Location = new System.Drawing.Point(6, 25);
            this.lblMemberCode.Name = "lblMemberCode";
            this.lblMemberCode.Size = new System.Drawing.Size(88, 16);
            this.lblMemberCode.TabIndex = 34;
            this.lblMemberCode.Text = "Cột Mã CBCC:";
            // 
            // cbxMemberCode
            // 
            this.cbxMemberCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMemberCode.FormattingEnabled = true;
            this.cbxMemberCode.Location = new System.Drawing.Point(137, 22);
            this.cbxMemberCode.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cbxMemberCode.Name = "cbxMemberCode";
            this.cbxMemberCode.Size = new System.Drawing.Size(75, 22);
            this.cbxMemberCode.TabIndex = 35;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.groupMemberContact);
            this.panel1.Controls.Add(this.groupBoxMemberInfo);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 436);
            this.panel1.TabIndex = 63;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbxStartRowIndex);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 289);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(662, 107);
            this.panel3.TabIndex = 59;
            // 
            // tbxStartRowIndex
            // 
            this.tbxStartRowIndex.Location = new System.Drawing.Point(348, 8);
            this.tbxStartRowIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbxStartRowIndex.Name = "tbxStartRowIndex";
            this.tbxStartRowIndex.Size = new System.Drawing.Size(76, 22);
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
            this.label14.Location = new System.Drawing.Point(3, 10);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(339, 16);
            this.label14.TabIndex = 39;
            this.label14.Text = "Cấu hình vị trí dòng dữ liệu đầu tiên trên tập tin MS Excel:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(429, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(152, 16);
            this.label15.TabIndex = 41;
            this.label15.Text = "(không tính dòng tiêu đề)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 42);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(419, 48);
            this.label16.TabIndex = 42;
            this.label16.Text = "Lưu ý:\r\n- Chọn các cột dữ liệu tương ứng trên tập tin MS Excel, còn lại để trống." +
    "\r\n- Định dạng kiểu ngày-tháng-năm (Ví dụ: 20-07-1989)\r\n";
            // 
            // groupBoxMemberInfo
            // 
            this.groupBoxMemberInfo.Controls.Add(this.lblDescription);
            this.groupBoxMemberInfo.Controls.Add(this.cmbDescription);
            this.groupBoxMemberInfo.Controls.Add(this.lblEventName);
            this.groupBoxMemberInfo.Controls.Add(this.lblHourBegin);
            this.groupBoxMemberInfo.Controls.Add(this.lblDate);
            this.groupBoxMemberInfo.Controls.Add(this.cmbHourKeeping);
            this.groupBoxMemberInfo.Controls.Add(this.cmbEventName);
            this.groupBoxMemberInfo.Controls.Add(this.lblHourKeeping);
            this.groupBoxMemberInfo.Controls.Add(this.cmbDate);
            this.groupBoxMemberInfo.Controls.Add(this.cmbHourBegin);
            this.groupBoxMemberInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxMemberInfo.Location = new System.Drawing.Point(0, 118);
            this.groupBoxMemberInfo.Name = "groupBoxMemberInfo";
            this.groupBoxMemberInfo.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBoxMemberInfo.Size = new System.Drawing.Size(662, 112);
            this.groupBoxMemberInfo.TabIndex = 57;
            this.groupBoxMemberInfo.TabStop = false;
            this.groupBoxMemberInfo.Text = "Thông tin sự kiện";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 77);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(78, 16);
            this.lblDescription.TabIndex = 54;
            this.lblDescription.Text = "Cột Ghi chú:";
            // 
            // cmbDescription
            // 
            this.cmbDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDescription.FormattingEnabled = true;
            this.cmbDescription.Location = new System.Drawing.Point(137, 74);
            this.cmbDescription.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbDescription.Name = "cmbDescription";
            this.cmbDescription.Size = new System.Drawing.Size(75, 22);
            this.cmbDescription.TabIndex = 56;
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Location = new System.Drawing.Point(6, 25);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(103, 16);
            this.lblEventName.TabIndex = 21;
            this.lblEventName.Text = "Cột Tên sự kiện:";
            // 
            // lblHourBegin
            // 
            this.lblHourBegin.AutoSize = true;
            this.lblHourBegin.Location = new System.Drawing.Point(311, 25);
            this.lblHourBegin.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblHourBegin.Name = "lblHourBegin";
            this.lblHourBegin.Size = new System.Drawing.Size(101, 16);
            this.lblHourBegin.TabIndex = 26;
            this.lblHourBegin.Text = "Cột Giờ bắt đầu:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(6, 51);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(64, 16);
            this.lblDate.TabIndex = 27;
            this.lblDate.Text = "Cột Ngày:";
            // 
            // cmbHourKeeping
            // 
            this.cmbHourKeeping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHourKeeping.FormattingEnabled = true;
            this.cmbHourKeeping.Location = new System.Drawing.Point(464, 48);
            this.cmbHourKeeping.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbHourKeeping.Name = "cmbHourKeeping";
            this.cmbHourKeeping.Size = new System.Drawing.Size(75, 22);
            this.cmbHourKeeping.TabIndex = 47;
            // 
            // cmbEventName
            // 
            this.cmbEventName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEventName.FormattingEnabled = true;
            this.cmbEventName.Location = new System.Drawing.Point(137, 22);
            this.cmbEventName.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbEventName.Name = "cmbEventName";
            this.cmbEventName.Size = new System.Drawing.Size(75, 22);
            this.cmbEventName.TabIndex = 30;
            // 
            // lblHourKeeping
            // 
            this.lblHourKeeping.AutoSize = true;
            this.lblHourKeeping.Location = new System.Drawing.Point(311, 51);
            this.lblHourKeeping.Name = "lblHourKeeping";
            this.lblHourKeeping.Size = new System.Drawing.Size(133, 16);
            this.lblHourKeeping.TabIndex = 44;
            this.lblHourKeeping.Text = "Cột Thời gian diễn ra:";
            // 
            // cmbDate
            // 
            this.cmbDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDate.FormattingEnabled = true;
            this.cmbDate.Location = new System.Drawing.Point(137, 48);
            this.cmbDate.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbDate.Name = "cmbDate";
            this.cmbDate.Size = new System.Drawing.Size(75, 22);
            this.cmbDate.TabIndex = 35;
            // 
            // cmbHourBegin
            // 
            this.cmbHourBegin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHourBegin.FormattingEnabled = true;
            this.cmbHourBegin.Location = new System.Drawing.Point(464, 22);
            this.cmbHourBegin.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbHourBegin.Name = "cmbHourBegin";
            this.cmbHourBegin.Size = new System.Drawing.Size(75, 22);
            this.cmbHourBegin.TabIndex = 36;
            // 
            // FrmEventConnectionConfig
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(662, 507);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.Name = "FrmEventConnectionConfig";
            this.Text = "Tích Hợp - Cấu Hình Kết Nối";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupMemberContact.ResumeLayout(false);
            this.groupMemberContact.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStartRowIndex)).EndInit();
            this.groupBoxMemberInfo.ResumeLayout(false);
            this.groupBoxMemberInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbl1_FrmConnectionConfig;
        private System.Windows.Forms.Label label10;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputFilePath;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.GroupBox groupMemberContact;
        private System.Windows.Forms.Label lblMemberName;
        private System.Windows.Forms.ComboBox cbxMemberName;
        private System.Windows.Forms.Label lblMemberCode;
        private System.Windows.Forms.ComboBox cbxMemberCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBoxMemberInfo;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cmbDescription;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.Label lblHourBegin;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbHourKeeping;
        private System.Windows.Forms.ComboBox cmbEventName;
        private System.Windows.Forms.Label lblHourKeeping;
        private System.Windows.Forms.ComboBox cmbDate;
        private System.Windows.Forms.ComboBox cmbHourBegin;
        private System.Windows.Forms.NumericUpDown tbxStartRowIndex;
        private System.Windows.Forms.Label lblSubOrg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSubOrg;
    }
}