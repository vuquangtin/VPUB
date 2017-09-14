namespace MemberMgtComponent.WorkItems.IntegratingExcel
{
    partial class FrmConnectionConfig
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
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtInputFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbCompanyName = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbEmail = new System.Windows.Forms.ComboBox();
            this.cmbPermanentAddress = new System.Windows.Forms.ComboBox();
            this.cmbLastName = new System.Windows.Forms.ComboBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbxStartRowIndex = new CommonControls.Custom.NumberOnlyTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbPhoneNo = new System.Windows.Forms.ComboBox();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.cmbFirstName = new System.Windows.Forms.ComboBox();
            this.cmbBirthDate = new System.Windows.Forms.ComboBox();
            this.cmbNationality = new System.Windows.Forms.ComboBox();
            this.cmbTemporaryAddress = new System.Windows.Forms.ComboBox();
            this.cmbDegree = new System.Windows.Forms.ComboBox();
            this.cmbCode = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Location = new System.Drawing.Point(600, 31);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(50, 23);
            this.btnSelectFile.TabIndex = 5;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtInputFilePath
            // 
            this.txtInputFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFilePath.Location = new System.Drawing.Point(12, 32);
            this.txtInputFilePath.Name = "txtInputFilePath";
            this.txtInputFilePath.ReadOnly = true;
            this.txtInputFilePath.Size = new System.Drawing.Size(582, 22);
            this.txtInputFilePath.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chỉ đường dẫn đến tập tin MS Excel chứa dữ liệu cần tích hợp.";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(550, 347);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(444, 347);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 26);
            this.btnNext.TabIndex = 18;
            this.btnNext.Text = "Tiếp Tục";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.label10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(662, 75);
            this.panel9.TabIndex = 61;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 39);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(445, 14);
            this.label8.TabIndex = 1;
            this.label8.Text = "Phân tích dữ liệu từ tập tin MS Excel và đồng bộ với cơ sở dữ liệu của hệ thống";
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
            this.line1.Location = new System.Drawing.Point(0, 75);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(662, 2);
            this.line1.TabIndex = 62;
            this.line1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbCompanyName);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.cmbEmail);
            this.panel1.Controls.Add(this.cmbPermanentAddress);
            this.panel1.Controls.Add(this.cmbLastName);
            this.panel1.Controls.Add(this.cmbGender);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.tbxStartRowIndex);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.cmbPhoneNo);
            this.panel1.Controls.Add(this.cmbPosition);
            this.panel1.Controls.Add(this.cmbFirstName);
            this.panel1.Controls.Add(this.cmbBirthDate);
            this.panel1.Controls.Add(this.cmbNationality);
            this.panel1.Controls.Add(this.cmbTemporaryAddress);
            this.panel1.Controls.Add(this.cmbDegree);
            this.panel1.Controls.Add(this.cmbCode);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnSelectFile);
            this.panel1.Controls.Add(this.txtInputFilePath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 77);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.panel1.Size = new System.Drawing.Size(662, 385);
            this.panel1.TabIndex = 63;
            // 
            // cmbCompanyName
            // 
            this.cmbCompanyName.FormattingEnabled = true;
            this.cmbCompanyName.Location = new System.Drawing.Point(124, 139);
            this.cmbCompanyName.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbCompanyName.Name = "cmbCompanyName";
            this.cmbCompanyName.Size = new System.Drawing.Size(75, 22);
            this.cmbCompanyName.TabIndex = 52;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 142);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 16);
            this.label21.TabIndex = 51;
            this.label21.Text = "Cột Công Ty:";
            // 
            // cmbEmail
            // 
            this.cmbEmail.FormattingEnabled = true;
            this.cmbEmail.Location = new System.Drawing.Point(349, 165);
            this.cmbEmail.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbEmail.Name = "cmbEmail";
            this.cmbEmail.Size = new System.Drawing.Size(75, 22);
            this.cmbEmail.TabIndex = 50;
            // 
            // cmbPermanentAddress
            // 
            this.cmbPermanentAddress.FormattingEnabled = true;
            this.cmbPermanentAddress.Location = new System.Drawing.Point(572, 165);
            this.cmbPermanentAddress.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbPermanentAddress.Name = "cmbPermanentAddress";
            this.cmbPermanentAddress.Size = new System.Drawing.Size(75, 22);
            this.cmbPermanentAddress.TabIndex = 49;
            // 
            // cmbLastName
            // 
            this.cmbLastName.FormattingEnabled = true;
            this.cmbLastName.Location = new System.Drawing.Point(572, 87);
            this.cmbLastName.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbLastName.Name = "cmbLastName";
            this.cmbLastName.Size = new System.Drawing.Size(75, 22);
            this.cmbLastName.TabIndex = 48;
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(349, 113);
            this.cmbGender.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(75, 22);
            this.cmbGender.TabIndex = 47;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(214, 168);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 16);
            this.label17.TabIndex = 46;
            this.label17.Text = "Cột Email:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(439, 168);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(125, 16);
            this.label18.TabIndex = 45;
            this.label18.Text = "Cột ĐC Thường Trú:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(214, 116);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 16);
            this.label19.TabIndex = 44;
            this.label19.Text = "Cột Giới Tính:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(439, 90);
            this.label20.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 16);
            this.label20.TabIndex = 43;
            this.label20.Text = "Cột Tên:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 268);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(450, 16);
            this.label16.TabIndex = 42;
            this.label16.Text = "Lưu ý: Chọn các cột dữ liệu tương ứng trên tập tin MS Excel, còn lại để trống.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(436, 236);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(152, 16);
            this.label15.TabIndex = 41;
            this.label15.Text = "(không tính dòng tiêu đề)";
            // 
            // tbxStartRowIndex
            // 
            this.tbxStartRowIndex.Location = new System.Drawing.Point(355, 233);
            this.tbxStartRowIndex.Name = "tbxStartRowIndex";
            this.tbxStartRowIndex.Size = new System.Drawing.Size(75, 22);
            this.tbxStartRowIndex.TabIndex = 40;
            this.tbxStartRowIndex.Text = "2";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 236);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(339, 16);
            this.label14.TabIndex = 39;
            this.label14.Text = "Cấu hình vị trí dòng dữ liệu đầu tiên trên tập tin MS Excel:";
            // 
            // cmbPhoneNo
            // 
            this.cmbPhoneNo.FormattingEnabled = true;
            this.cmbPhoneNo.Location = new System.Drawing.Point(124, 165);
            this.cmbPhoneNo.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbPhoneNo.Name = "cmbPhoneNo";
            this.cmbPhoneNo.Size = new System.Drawing.Size(75, 22);
            this.cmbPhoneNo.TabIndex = 38;
            // 
            // cmbPosition
            // 
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(572, 139);
            this.cmbPosition.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(75, 22);
            this.cmbPosition.TabIndex = 37;
            // 
            // cmbFirstName
            // 
            this.cmbFirstName.FormattingEnabled = true;
            this.cmbFirstName.Location = new System.Drawing.Point(349, 87);
            this.cmbFirstName.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbFirstName.Name = "cmbFirstName";
            this.cmbFirstName.Size = new System.Drawing.Size(75, 22);
            this.cmbFirstName.TabIndex = 36;
            // 
            // cmbBirthDate
            // 
            this.cmbBirthDate.FormattingEnabled = true;
            this.cmbBirthDate.Location = new System.Drawing.Point(124, 113);
            this.cmbBirthDate.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbBirthDate.Name = "cmbBirthDate";
            this.cmbBirthDate.Size = new System.Drawing.Size(75, 22);
            this.cmbBirthDate.TabIndex = 35;
            // 
            // cmbNationality
            // 
            this.cmbNationality.FormattingEnabled = true;
            this.cmbNationality.Location = new System.Drawing.Point(572, 113);
            this.cmbNationality.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbNationality.Name = "cmbNationality";
            this.cmbNationality.Size = new System.Drawing.Size(75, 22);
            this.cmbNationality.TabIndex = 34;
            // 
            // cmbTemporaryAddress
            // 
            this.cmbTemporaryAddress.FormattingEnabled = true;
            this.cmbTemporaryAddress.Location = new System.Drawing.Point(124, 191);
            this.cmbTemporaryAddress.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbTemporaryAddress.Name = "cmbTemporaryAddress";
            this.cmbTemporaryAddress.Size = new System.Drawing.Size(75, 22);
            this.cmbTemporaryAddress.TabIndex = 33;
            // 
            // cmbDegree
            // 
            this.cmbDegree.FormattingEnabled = true;
            this.cmbDegree.Location = new System.Drawing.Point(349, 139);
            this.cmbDegree.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbDegree.Name = "cmbDegree";
            this.cmbDegree.Size = new System.Drawing.Size(75, 22);
            this.cmbDegree.TabIndex = 32;
            // 
            // cmbCode
            // 
            this.cmbCode.FormattingEnabled = true;
            this.cmbCode.Location = new System.Drawing.Point(124, 87);
            this.cmbCode.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.cmbCode.Name = "cmbCode";
            this.cmbCode.Size = new System.Drawing.Size(75, 22);
            this.cmbCode.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 16);
            this.label13.TabIndex = 29;
            this.label13.Text = "Cột Điện Thoại:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(439, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 16);
            this.label12.TabIndex = 28;
            this.label12.Text = "Cột Chức Vụ:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 16);
            this.label11.TabIndex = 27;
            this.label11.Text = "Cột Ngày Sinh:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(214, 90);
            this.label9.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 16);
            this.label9.TabIndex = 26;
            this.label9.Text = "Cột Họ Và Tên Đệm:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(439, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "Cột Quốc Tịch:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Cột ĐC Tạm Trú:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Cột Trình Độ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Cột Mã TV:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Cấu hình vị trí các cột dữ liệu trên tập tin MS Excel:";
            // 
            // FrmConnectionConfig
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(662, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.Name = "FrmConnectionConfig";
            this.Text = "Tích Hợp - Cấu Hình Kết Nối";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtInputFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPhoneNo;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.ComboBox cmbFirstName;
        private System.Windows.Forms.ComboBox cmbBirthDate;
        private System.Windows.Forms.ComboBox cmbNationality;
        private System.Windows.Forms.ComboBox cmbTemporaryAddress;
        private System.Windows.Forms.ComboBox cmbDegree;
        private System.Windows.Forms.ComboBox cmbCode;
        private System.Windows.Forms.Label label14;
        private CommonControls.Custom.NumberOnlyTextBox tbxStartRowIndex;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbEmail;
        private System.Windows.Forms.ComboBox cmbPermanentAddress;
        private System.Windows.Forms.ComboBox cmbLastName;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbCompanyName;
        private System.Windows.Forms.Label label21;
    }
}