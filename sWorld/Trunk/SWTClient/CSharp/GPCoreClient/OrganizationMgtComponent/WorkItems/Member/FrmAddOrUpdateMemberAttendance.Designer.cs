namespace SystemMgtComponent.WorkItems
{
    partial class FrmAddOrUpdateMemberAttendance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddOrUpdateMemberAttendance));
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbNote = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.picMember = new System.Windows.Forms.PictureBox();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtTemporaryAddress = new System.Windows.Forms.TextBox();
            this.txtPermanentAddress = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtDegree = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.rbtnGenderOther = new System.Windows.Forms.RadioButton();
            this.rbtnGenderFemale = new System.Windows.Forms.RadioButton();
            this.rbtnGenderMale = new System.Windows.Forms.RadioButton();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvMemberRelativeList = new CommonControls.Custom.CommonDataGridView();
            this.colMemberRelativeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colContactName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tsmCard = new CommonControls.Custom.CommonToolStrip();
            this.btnAddMemberRelative = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateMemberRelative = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveMemberRelative = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReloadMemberRelative = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberRelativeList)).BeginInit();
            this.panel5.SuspendLayout();
            this.tsmCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lbNote);
            this.panel9.Controls.Add(this.lbTitle);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(741, 75);
            this.panel9.TabIndex = 63;
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNote.Location = new System.Drawing.Point(12, 39);
            this.lbNote.Margin = new System.Windows.Forms.Padding(3);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(278, 14);
            this.lbNote.TabIndex = 1;
            this.lbNote.Text = "Tạo thành viên mới cho phòng ban vào hệ thống.";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(12, 22);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(177, 14);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Thêm Thông Tin Thành Viên";
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 75);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(741, 1);
            this.line1.TabIndex = 65;
            this.line1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(635, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(629, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(6, 26);
            this.panel2.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(529, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 26);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Location = new System.Drawing.Point(523, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(6, 26);
            this.panel4.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(423, 8);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 26);
            this.btnConfirm.TabIndex = 13;
            this.btnConfirm.Text = "Xác Nhận...";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 501);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(741, 41);
            this.panel1.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(741, 25);
            this.label1.TabIndex = 75;
            this.label1.Text = "Thông tin thành viên";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnChooseImage);
            this.panel3.Controls.Add(this.picMember);
            this.panel3.Controls.Add(this.txtNationality);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtCode);
            this.panel3.Controls.Add(this.txtTemporaryAddress);
            this.panel3.Controls.Add(this.txtPermanentAddress);
            this.panel3.Controls.Add(this.txtEmail);
            this.panel3.Controls.Add(this.txtPhoneNo);
            this.panel3.Controls.Add(this.txtPosition);
            this.panel3.Controls.Add(this.txtDegree);
            this.panel3.Controls.Add(this.txtCompany);
            this.panel3.Controls.Add(this.txtLastName);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.label27);
            this.panel3.Controls.Add(this.label28);
            this.panel3.Controls.Add(this.txtFirstName);
            this.panel3.Controls.Add(this.rbtnGenderOther);
            this.panel3.Controls.Add(this.rbtnGenderFemale);
            this.panel3.Controls.Add(this.rbtnGenderMale);
            this.panel3.Controls.Add(this.dtpBirthDate);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 101);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(741, 227);
            this.panel3.TabIndex = 83;
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChooseImage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseImage.Location = new System.Drawing.Point(11, 190);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(127, 26);
            this.btnChooseImage.TabIndex = 16;
            this.btnChooseImage.Text = "Chọn ảnh";
            this.btnChooseImage.UseVisualStyleBackColor = true;
            // 
            // picMember
            // 
            this.picMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMember.Location = new System.Drawing.Point(11, 8);
            this.picMember.Name = "picMember";
            this.picMember.Size = new System.Drawing.Size(127, 178);
            this.picMember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMember.TabIndex = 69;
            this.picMember.TabStop = false;
            // 
            // txtNationality
            // 
            this.txtNationality.Location = new System.Drawing.Point(253, 83);
            this.txtNationality.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtNationality.MaxLength = 255;
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(200, 22);
            this.txtNationality.TabIndex = 68;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 14);
            this.label2.TabIndex = 67;
            this.label2.Text = "Mã thành viên:";
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCode.Location = new System.Drawing.Point(253, 5);
            this.txtCode.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 22);
            this.txtCode.TabIndex = 1;
            // 
            // txtTemporaryAddress
            // 
            this.txtTemporaryAddress.Location = new System.Drawing.Point(253, 187);
            this.txtTemporaryAddress.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtTemporaryAddress.MaxLength = 255;
            this.txtTemporaryAddress.Name = "txtTemporaryAddress";
            this.txtTemporaryAddress.Size = new System.Drawing.Size(480, 22);
            this.txtTemporaryAddress.TabIndex = 12;
            // 
            // txtPermanentAddress
            // 
            this.txtPermanentAddress.Location = new System.Drawing.Point(253, 161);
            this.txtPermanentAddress.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtPermanentAddress.MaxLength = 255;
            this.txtPermanentAddress.Name = "txtPermanentAddress";
            this.txtPermanentAddress.Size = new System.Drawing.Size(480, 22);
            this.txtPermanentAddress.TabIndex = 11;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtEmail.Location = new System.Drawing.Point(533, 135);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtEmail.MaxLength = 255;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 22);
            this.txtEmail.TabIndex = 10;
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPhoneNo.Location = new System.Drawing.Point(253, 135);
            this.txtPhoneNo.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtPhoneNo.MaxLength = 255;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(200, 22);
            this.txtPhoneNo.TabIndex = 9;
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(533, 109);
            this.txtPosition.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtPosition.MaxLength = 255;
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(200, 22);
            this.txtPosition.TabIndex = 8;
            // 
            // txtDegree
            // 
            this.txtDegree.Location = new System.Drawing.Point(253, 109);
            this.txtDegree.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtDegree.MaxLength = 255;
            this.txtDegree.Name = "txtDegree";
            this.txtDegree.Size = new System.Drawing.Size(200, 22);
            this.txtDegree.TabIndex = 7;
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(533, 83);
            this.txtCompany.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtCompany.MaxLength = 255;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(200, 22);
            this.txtCompany.TabIndex = 6;
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLastName.Location = new System.Drawing.Point(253, 31);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtLastName.MaxLength = 150;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 22);
            this.txtLastName.TabIndex = 2;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(468, 86);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 14);
            this.label21.TabIndex = 63;
            this.label21.Text = "Công ty:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(468, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 14);
            this.label5.TabIndex = 62;
            this.label5.Text = "Email:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(151, 190);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 14);
            this.label15.TabIndex = 61;
            this.label15.Text = "ĐC thường trú:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(468, 63);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 14);
            this.label19.TabIndex = 60;
            this.label19.Text = "Giới tính:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(468, 34);
            this.label20.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(33, 14);
            this.label20.TabIndex = 59;
            this.label20.Text = "Tên:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(151, 138);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 14);
            this.label22.TabIndex = 58;
            this.label22.Text = "Điện thoại:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(468, 112);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 14);
            this.label23.TabIndex = 57;
            this.label23.Text = "Chức vụ:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(151, 63);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 14);
            this.label24.TabIndex = 56;
            this.label24.Text = "Ngày sinh:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(151, 34);
            this.label25.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(93, 14);
            this.label25.TabIndex = 55;
            this.label25.Text = "Họ và tên đệm:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(151, 86);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(64, 14);
            this.label26.TabIndex = 54;
            this.label26.Text = "Quốc tịch:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(151, 164);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(71, 14);
            this.label27.TabIndex = 53;
            this.label27.Text = "ĐC tạm trú:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(151, 112);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(57, 14);
            this.label28.TabIndex = 52;
            this.label28.Text = "Trình độ:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFirstName.Location = new System.Drawing.Point(533, 31);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 22);
            this.txtFirstName.TabIndex = 3;
            // 
            // rbtnGenderOther
            // 
            this.rbtnGenderOther.AutoSize = true;
            this.rbtnGenderOther.Location = new System.Drawing.Point(643, 61);
            this.rbtnGenderOther.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.rbtnGenderOther.Name = "rbtnGenderOther";
            this.rbtnGenderOther.Size = new System.Drawing.Size(51, 18);
            this.rbtnGenderOther.TabIndex = 17;
            this.rbtnGenderOther.Text = "Khác";
            this.rbtnGenderOther.UseVisualStyleBackColor = true;
            // 
            // rbtnGenderFemale
            // 
            this.rbtnGenderFemale.AutoSize = true;
            this.rbtnGenderFemale.Location = new System.Drawing.Point(592, 61);
            this.rbtnGenderFemale.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.rbtnGenderFemale.Name = "rbtnGenderFemale";
            this.rbtnGenderFemale.Size = new System.Drawing.Size(41, 18);
            this.rbtnGenderFemale.TabIndex = 16;
            this.rbtnGenderFemale.Text = "Nữ";
            this.rbtnGenderFemale.UseVisualStyleBackColor = true;
            // 
            // rbtnGenderMale
            // 
            this.rbtnGenderMale.AutoSize = true;
            this.rbtnGenderMale.Location = new System.Drawing.Point(533, 61);
            this.rbtnGenderMale.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.rbtnGenderMale.Name = "rbtnGenderMale";
            this.rbtnGenderMale.Size = new System.Drawing.Size(49, 18);
            this.rbtnGenderMale.TabIndex = 15;
            this.rbtnGenderMale.Text = "Nam";
            this.rbtnGenderMale.UseVisualStyleBackColor = true;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Checked = false;
            this.dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthDate.Location = new System.Drawing.Point(253, 57);
            this.dtpBirthDate.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.dtpBirthDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpBirthDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.ShowCheckBox = true;
            this.dtpBirthDate.Size = new System.Drawing.Size(200, 22);
            this.dtpBirthDate.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.dgvMemberRelativeList);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 328);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(741, 173);
            this.panel6.TabIndex = 85;
            // 
            // dgvMemberRelativeList
            // 
            this.dgvMemberRelativeList.AllowUserToAddRows = false;
            this.dgvMemberRelativeList.AllowUserToDeleteRows = false;
            this.dgvMemberRelativeList.AllowUserToOrderColumns = true;
            this.dgvMemberRelativeList.AllowUserToResizeRows = false;
            this.dgvMemberRelativeList.BackgroundColor = System.Drawing.Color.White;
            this.dgvMemberRelativeList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMemberRelativeList.ColumnHeadersHeight = 26;
            this.dgvMemberRelativeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMemberRelativeId,
            this.colImage,
            this.colContactName,
            this.colPhone,
            this.colEmail,
            this.colAddress,
            this.colBlank});
            this.dgvMemberRelativeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMemberRelativeList.Location = new System.Drawing.Point(0, 26);
            this.dgvMemberRelativeList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMemberRelativeList.Name = "dgvMemberRelativeList";
            this.dgvMemberRelativeList.ReadOnly = true;
            this.dgvMemberRelativeList.RowHeadersVisible = false;
            this.dgvMemberRelativeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMemberRelativeList.Size = new System.Drawing.Size(739, 145);
            this.dgvMemberRelativeList.TabIndex = 71;
            // 
            // colMemberRelativeId
            // 
            this.colMemberRelativeId.DataPropertyName = "MemberRelativeId";
            this.colMemberRelativeId.HeaderText = "MemberRelativeId";
            this.colMemberRelativeId.Name = "colMemberRelativeId";
            this.colMemberRelativeId.ReadOnly = true;
            this.colMemberRelativeId.Visible = false;
            // 
            // colImage
            // 
            this.colImage.DataPropertyName = "Image";
            this.colImage.HeaderText = "Ảnh";
            this.colImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            this.colImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colImage.Width = 54;
            // 
            // colContactName
            // 
            this.colContactName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colContactName.DataPropertyName = "ContactName";
            this.colContactName.HeaderText = "Họ Và Tên";
            this.colContactName.Name = "colContactName";
            this.colContactName.ReadOnly = true;
            this.colContactName.Visible = false;
            this.colContactName.Width = 84;
            // 
            // colPhone
            // 
            this.colPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colPhone.DataPropertyName = "Phone";
            this.colPhone.HeaderText = "Số DTDD";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            this.colPhone.Width = 82;
            // 
            // colEmail
            // 
            this.colEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colEmail.DataPropertyName = "Email";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colEmail.DefaultCellStyle = dataGridViewCellStyle1;
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Width = 59;
            // 
            // colAddress
            // 
            this.colAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAddress.DataPropertyName = "Address";
            this.colAddress.HeaderText = "Địa Chỉ";
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            // 
            // colBlank
            // 
            this.colBlank.DataPropertyName = "Blank";
            this.colBlank.HeaderText = "";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            this.colBlank.Width = 5;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tsmCard);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(739, 26);
            this.panel5.TabIndex = 70;
            // 
            // tsmCard
            // 
            this.tsmCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsmCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddMemberRelative,
            this.btnUpdateMemberRelative,
            this.btnRemoveMemberRelative,
            this.toolStripSeparator1,
            this.btnReloadMemberRelative});
            this.tsmCard.Location = new System.Drawing.Point(615, 0);
            this.tsmCard.Name = "tsmCard";
            this.tsmCard.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsmCard.Size = new System.Drawing.Size(124, 26);
            this.tsmCard.TabIndex = 86;
            this.tsmCard.Text = "tlstripListUser";
            // 
            // btnAddMemberRelative
            // 
            this.btnAddMemberRelative.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddMemberRelative.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMemberRelative.Image")));
            this.btnAddMemberRelative.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddMemberRelative.Name = "btnAddMemberRelative";
            this.btnAddMemberRelative.Size = new System.Drawing.Size(23, 23);
            this.btnAddMemberRelative.Text = "Thêm Người Liên Hệ Mới...";
            this.btnAddMemberRelative.ToolTipText = "Thêm người liên hệ mới vào hệ thống.";
            // 
            // btnUpdateMemberRelative
            // 
            this.btnUpdateMemberRelative.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateMemberRelative.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateMemberRelative.Image")));
            this.btnUpdateMemberRelative.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateMemberRelative.Name = "btnUpdateMemberRelative";
            this.btnUpdateMemberRelative.Size = new System.Drawing.Size(23, 23);
            this.btnUpdateMemberRelative.Text = "Cập Nhật Thông Tin Người Liên Hệ...";
            this.btnUpdateMemberRelative.ToolTipText = "Cập nhật thông tin người liên hệ trong hệ thống.";
            // 
            // btnRemoveMemberRelative
            // 
            this.btnRemoveMemberRelative.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveMemberRelative.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveMemberRelative.Image")));
            this.btnRemoveMemberRelative.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveMemberRelative.Name = "btnRemoveMemberRelative";
            this.btnRemoveMemberRelative.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveMemberRelative.Text = "Hủy Người Liên Hệ Khỏi Hệ Thống...";
            this.btnRemoveMemberRelative.ToolTipText = "Hủy người liên hệ khỏi hệ thống";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // btnReloadMemberRelative
            // 
            this.btnReloadMemberRelative.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadMemberRelative.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadMemberRelative.Image")));
            this.btnReloadMemberRelative.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadMemberRelative.Name = "btnReloadMemberRelative";
            this.btnReloadMemberRelative.Size = new System.Drawing.Size(23, 23);
            this.btnReloadMemberRelative.Text = "Tải Dữ Liệu";
            this.btnReloadMemberRelative.ToolTipText = "Tải danh sách thành viên";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(615, 26);
            this.label3.TabIndex = 85;
            this.label3.Text = "Thông tin người liên hệ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmAddOrUpdateMemberAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 542);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(757, 500);
            this.Name = "FrmAddOrUpdateMemberAttendance";
            this.Text = "Nhập thông tin thành viên";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMember)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberRelativeList)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tsmCard.ResumeLayout(false);
            this.tsmCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Label lbTitle;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.PictureBox picMember;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtTemporaryAddress;
        private System.Windows.Forms.TextBox txtPermanentAddress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtDegree;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.RadioButton rbtnGenderOther;
        private System.Windows.Forms.RadioButton rbtnGenderFemale;
        private System.Windows.Forms.RadioButton rbtnGenderMale;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private CommonControls.Custom.CommonDataGridView dgvMemberRelativeList;
        private CommonControls.Custom.CommonToolStrip tsmCard;
        private System.Windows.Forms.ToolStripButton btnAddMemberRelative;
        private System.Windows.Forms.ToolStripButton btnUpdateMemberRelative;
        private System.Windows.Forms.ToolStripButton btnRemoveMemberRelative;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnReloadMemberRelative;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberRelativeId;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContactName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
    }
}