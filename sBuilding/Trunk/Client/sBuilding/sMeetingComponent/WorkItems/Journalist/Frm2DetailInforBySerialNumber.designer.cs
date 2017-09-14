using System.Windows.Forms;

namespace sMeetingComponent.WorkItems
{
    partial class Frm2DetailInforBySerialNumber : Form
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblguideEnter = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel7PlusInfo = new System.Windows.Forms.Panel();
            this.grblblInforPlus = new System.Windows.Forms.GroupBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNotess = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbxAttendMeeting = new System.Windows.Forms.GroupBox();
            this.panel4ListMeeting = new System.Windows.Forms.Panel();
            this.dgvListMeetingToday = new CommonControls.Custom.CommonDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAttendMeetingClick = new System.Windows.Forms.Label();
            this.panel4Click = new System.Windows.Forms.Panel();
            this.rbtnNotAttendMeeting = new System.Windows.Forms.RadioButton();
            this.rbtnAttendMeeting = new System.Windows.Forms.RadioButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.grblblJournalistInfo = new System.Windows.Forms.GroupBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtLowerFullName = new System.Windows.Forms.TextBox();
            this.txtOrg = new System.Windows.Forms.TextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblBrithDay = new System.Windows.Forms.Label();
            this.txtIdentityCard = new System.Windows.Forms.TextBox();
            this.lblCMND = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblLowerName = new System.Windows.Forms.Label();
            this.lblChooseOrg = new System.Windows.Forms.Label();
            this.colSttnew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeetingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeetingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrganizationMeeting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRoomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListAttend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel7PlusInfo.SuspendLayout();
            this.grblblInforPlus.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbxAttendMeeting.SuspendLayout();
            this.panel4ListMeeting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMeetingToday)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4Click.SuspendLayout();
            this.panel8.SuspendLayout();
            this.grblblJournalistInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblguideEnter);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.panel7PlusInfo);
            this.panel3.Controls.Add(this.btnConfirm);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 550);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(898, 161);
            this.panel3.TabIndex = 1;
            // 
            // lblguideEnter
            // 
            this.lblguideEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblguideEnter.BackColor = System.Drawing.Color.AliceBlue;
            this.lblguideEnter.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblguideEnter.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblguideEnter.Location = new System.Drawing.Point(12, 119);
            this.lblguideEnter.Name = "lblguideEnter";
            this.lblguideEnter.Size = new System.Drawing.Size(435, 33);
            this.lblguideEnter.TabIndex = 18;
            this.lblguideEnter.Text = "Hướng dẫn phím nhanh: Nhấn nút F10 để cho vào";
            this.lblguideEnter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(765, 119);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 33);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel7PlusInfo
            // 
            this.panel7PlusInfo.Controls.Add(this.grblblInforPlus);
            this.panel7PlusInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7PlusInfo.Location = new System.Drawing.Point(0, 0);
            this.panel7PlusInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7PlusInfo.Name = "panel7PlusInfo";
            this.panel7PlusInfo.Size = new System.Drawing.Size(898, 114);
            this.panel7PlusInfo.TabIndex = 1;
            // 
            // grblblInforPlus
            // 
            this.grblblInforPlus.Controls.Add(this.txtNote);
            this.grblblInforPlus.Controls.Add(this.lblNotess);
            this.grblblInforPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grblblInforPlus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grblblInforPlus.Location = new System.Drawing.Point(0, 0);
            this.grblblInforPlus.Name = "grblblInforPlus";
            this.grblblInforPlus.Size = new System.Drawing.Size(898, 114);
            this.grblblInforPlus.TabIndex = 2;
            this.grblblInforPlus.TabStop = false;
            this.grblblInforPlus.Text = "THÔNG TIN THÊM";
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(191, 25);
            this.txtNote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(667, 80);
            this.txtNote.TabIndex = 3;
            // 
            // lblNotess
            // 
            this.lblNotess.AutoSize = true;
            this.lblNotess.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotess.Location = new System.Drawing.Point(75, 25);
            this.lblNotess.Name = "lblNotess";
            this.lblNotess.Size = new System.Drawing.Size(69, 19);
            this.lblNotess.TabIndex = 4;
            this.lblNotess.Text = "Ghi chú:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(666, 119);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(93, 33);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gbxAttendMeeting);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(898, 550);
            this.panel2.TabIndex = 25;
            // 
            // gbxAttendMeeting
            // 
            this.gbxAttendMeeting.BackColor = System.Drawing.SystemColors.Control;
            this.gbxAttendMeeting.Controls.Add(this.panel4ListMeeting);
            this.gbxAttendMeeting.Controls.Add(this.panel1);
            this.gbxAttendMeeting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxAttendMeeting.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAttendMeeting.Location = new System.Drawing.Point(0, 215);
            this.gbxAttendMeeting.Name = "gbxAttendMeeting";
            this.gbxAttendMeeting.Size = new System.Drawing.Size(898, 335);
            this.gbxAttendMeeting.TabIndex = 140;
            this.gbxAttendMeeting.TabStop = false;
            this.gbxAttendMeeting.Text = "THAM DỰ CUỘC HỌP";
            // 
            // panel4ListMeeting
            // 
            this.panel4ListMeeting.Controls.Add(this.dgvListMeetingToday);
            this.panel4ListMeeting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4ListMeeting.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4ListMeeting.Location = new System.Drawing.Point(3, 51);
            this.panel4ListMeeting.Name = "panel4ListMeeting";
            this.panel4ListMeeting.Size = new System.Drawing.Size(892, 281);
            this.panel4ListMeeting.TabIndex = 141;
            // 
            // dgvListMeetingToday
            // 
            this.dgvListMeetingToday.AllowUserToAddRows = false;
            this.dgvListMeetingToday.AllowUserToDeleteRows = false;
            this.dgvListMeetingToday.AllowUserToOrderColumns = true;
            this.dgvListMeetingToday.AllowUserToResizeRows = false;
            this.dgvListMeetingToday.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvListMeetingToday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListMeetingToday.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvListMeetingToday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListMeetingToday.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSttnew,
            this.colMeetingId,
            this.colMeetingName,
            this.colOrganizationMeeting,
            this.colDateTime,
            this.colStartTime,
            this.colEndTime,
            this.colCheck,
            this.colRoomName,
            this.colNumber,
            this.colListAttend});
            this.dgvListMeetingToday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListMeetingToday.Location = new System.Drawing.Point(0, 0);
            this.dgvListMeetingToday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListMeetingToday.MultiSelect = false;
            this.dgvListMeetingToday.Name = "dgvListMeetingToday";
            this.dgvListMeetingToday.ReadOnly = true;
            this.dgvListMeetingToday.RowHeadersVisible = false;
            this.dgvListMeetingToday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListMeetingToday.Size = new System.Drawing.Size(892, 281);
            this.dgvListMeetingToday.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAttendMeetingClick);
            this.panel1.Controls.Add(this.panel4Click);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 28);
            this.panel1.TabIndex = 140;
            // 
            // lblAttendMeetingClick
            // 
            this.lblAttendMeetingClick.AutoSize = true;
            this.lblAttendMeetingClick.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttendMeetingClick.Location = new System.Drawing.Point(72, 3);
            this.lblAttendMeetingClick.Name = "lblAttendMeetingClick";
            this.lblAttendMeetingClick.Size = new System.Drawing.Size(149, 19);
            this.lblAttendMeetingClick.TabIndex = 140;
            this.lblAttendMeetingClick.Text = "Tham dự cuộc họp:";
            this.lblAttendMeetingClick.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4Click
            // 
            this.panel4Click.Controls.Add(this.rbtnNotAttendMeeting);
            this.panel4Click.Controls.Add(this.rbtnAttendMeeting);
            this.panel4Click.Font = new System.Drawing.Font("Tahoma", 12F);
            this.panel4Click.Location = new System.Drawing.Point(224, 3);
            this.panel4Click.Name = "panel4Click";
            this.panel4Click.Size = new System.Drawing.Size(188, 22);
            this.panel4Click.TabIndex = 139;
            // 
            // rbtnNotAttendMeeting
            // 
            this.rbtnNotAttendMeeting.Dock = System.Windows.Forms.DockStyle.Right;
            this.rbtnNotAttendMeeting.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rbtnNotAttendMeeting.Location = new System.Drawing.Point(91, 0);
            this.rbtnNotAttendMeeting.Name = "rbtnNotAttendMeeting";
            this.rbtnNotAttendMeeting.Size = new System.Drawing.Size(97, 22);
            this.rbtnNotAttendMeeting.TabIndex = 6;
            this.rbtnNotAttendMeeting.Text = "Không";
            this.rbtnNotAttendMeeting.UseVisualStyleBackColor = true;
            // 
            // rbtnAttendMeeting
            // 
            this.rbtnAttendMeeting.Checked = true;
            this.rbtnAttendMeeting.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnAttendMeeting.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rbtnAttendMeeting.Location = new System.Drawing.Point(0, 0);
            this.rbtnAttendMeeting.Name = "rbtnAttendMeeting";
            this.rbtnAttendMeeting.Size = new System.Drawing.Size(56, 22);
            this.rbtnAttendMeeting.TabIndex = 4;
            this.rbtnAttendMeeting.TabStop = true;
            this.rbtnAttendMeeting.Text = "Có";
            this.rbtnAttendMeeting.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.grblblJournalistInfo);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(898, 215);
            this.panel8.TabIndex = 122;
            // 
            // grblblJournalistInfo
            // 
            this.grblblJournalistInfo.Controls.Add(this.txtPosition);
            this.grblblJournalistInfo.Controls.Add(this.txtLowerFullName);
            this.grblblJournalistInfo.Controls.Add(this.txtOrg);
            this.grblblJournalistInfo.Controls.Add(this.dtpBirthDate);
            this.grblblJournalistInfo.Controls.Add(this.lblBrithDay);
            this.grblblJournalistInfo.Controls.Add(this.txtIdentityCard);
            this.grblblJournalistInfo.Controls.Add(this.lblCMND);
            this.grblblJournalistInfo.Controls.Add(this.txtPhoneNo);
            this.grblblJournalistInfo.Controls.Add(this.lblTel);
            this.grblblJournalistInfo.Controls.Add(this.txtEmail);
            this.grblblJournalistInfo.Controls.Add(this.lblEmail);
            this.grblblJournalistInfo.Controls.Add(this.lblPosition);
            this.grblblJournalistInfo.Controls.Add(this.lblLowerName);
            this.grblblJournalistInfo.Controls.Add(this.lblChooseOrg);
            this.grblblJournalistInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grblblJournalistInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grblblJournalistInfo.Location = new System.Drawing.Point(0, 0);
            this.grblblJournalistInfo.Name = "grblblJournalistInfo";
            this.grblblJournalistInfo.Size = new System.Drawing.Size(898, 215);
            this.grblblJournalistInfo.TabIndex = 121;
            this.grblblJournalistInfo.TabStop = false;
            this.grblblJournalistInfo.Text = "THÔNG TIN KHÁCH";
            // 
            // txtPosition
            // 
            this.txtPosition.BackColor = System.Drawing.SystemColors.Window;
            this.txtPosition.Enabled = false;
            this.txtPosition.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosition.Location = new System.Drawing.Point(191, 83);
            this.txtPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPosition.Multiline = true;
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(385, 26);
            this.txtPosition.TabIndex = 151;
            // 
            // txtLowerFullName
            // 
            this.txtLowerFullName.BackColor = System.Drawing.SystemColors.Window;
            this.txtLowerFullName.Enabled = false;
            this.txtLowerFullName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLowerFullName.Location = new System.Drawing.Point(191, 23);
            this.txtLowerFullName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLowerFullName.Multiline = true;
            this.txtLowerFullName.Name = "txtLowerFullName";
            this.txtLowerFullName.Size = new System.Drawing.Size(385, 26);
            this.txtLowerFullName.TabIndex = 150;
            // 
            // txtOrg
            // 
            this.txtOrg.BackColor = System.Drawing.SystemColors.Window;
            this.txtOrg.Enabled = false;
            this.txtOrg.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrg.Location = new System.Drawing.Point(191, 53);
            this.txtOrg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOrg.Multiline = true;
            this.txtOrg.Name = "txtOrg";
            this.txtOrg.Size = new System.Drawing.Size(385, 26);
            this.txtOrg.TabIndex = 149;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.CalendarFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpBirthDate.Enabled = false;
            this.dtpBirthDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthDate.Location = new System.Drawing.Point(191, 116);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(105, 27);
            this.dtpBirthDate.TabIndex = 148;
            // 
            // lblBrithDay
            // 
            this.lblBrithDay.AutoSize = true;
            this.lblBrithDay.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrithDay.Location = new System.Drawing.Point(75, 122);
            this.lblBrithDay.Name = "lblBrithDay";
            this.lblBrithDay.Size = new System.Drawing.Size(85, 19);
            this.lblBrithDay.TabIndex = 147;
            this.lblBrithDay.Text = "Ngày sinh:";
            this.lblBrithDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIdentityCard
            // 
            this.txtIdentityCard.BackColor = System.Drawing.SystemColors.Window;
            this.txtIdentityCard.Enabled = false;
            this.txtIdentityCard.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityCard.Location = new System.Drawing.Point(191, 148);
            this.txtIdentityCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIdentityCard.Multiline = true;
            this.txtIdentityCard.Name = "txtIdentityCard";
            this.txtIdentityCard.Size = new System.Drawing.Size(135, 27);
            this.txtIdentityCard.TabIndex = 145;
            // 
            // lblCMND
            // 
            this.lblCMND.AutoSize = true;
            this.lblCMND.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCMND.Location = new System.Drawing.Point(75, 151);
            this.lblCMND.Name = "lblCMND";
            this.lblCMND.Size = new System.Drawing.Size(59, 19);
            this.lblCMND.TabIndex = 146;
            this.lblCMND.Text = "CMND:";
            this.lblCMND.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtPhoneNo.Enabled = false;
            this.txtPhoneNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNo.Location = new System.Drawing.Point(191, 148);
            this.txtPhoneNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhoneNo.Multiline = true;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(135, 27);
            this.txtPhoneNo.TabIndex = 143;
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTel.Location = new System.Drawing.Point(191, 151);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(45, 19);
            this.lblTel.TabIndex = 144;
            this.lblTel.Text = "SĐT:";
            this.lblTel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmail.Enabled = false;
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(191, 179);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(385, 26);
            this.txtEmail.TabIndex = 141;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(75, 182);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(54, 19);
            this.lblEmail.TabIndex = 142;
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(75, 90);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(73, 19);
            this.lblPosition.TabIndex = 140;
            this.lblPosition.Text = "Chức vụ:";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLowerName
            // 
            this.lblLowerName.AutoSize = true;
            this.lblLowerName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerName.Location = new System.Drawing.Point(75, 26);
            this.lblLowerName.Name = "lblLowerName";
            this.lblLowerName.Size = new System.Drawing.Size(42, 19);
            this.lblLowerName.TabIndex = 139;
            this.lblLowerName.Text = "Tên:";
            this.lblLowerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChooseOrg
            // 
            this.lblChooseOrg.AutoSize = true;
            this.lblChooseOrg.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseOrg.Location = new System.Drawing.Point(75, 56);
            this.lblChooseOrg.Name = "lblChooseOrg";
            this.lblChooseOrg.Size = new System.Drawing.Size(74, 19);
            this.lblChooseOrg.TabIndex = 138;
            this.lblChooseOrg.Text = "Cơ quan:";
            this.lblChooseOrg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // colSttnew
            // 
            this.colSttnew.DataPropertyName = "Sttnew";
            this.colSttnew.HeaderText = "STT";
            this.colSttnew.Name = "colSttnew";
            this.colSttnew.ReadOnly = true;
            this.colSttnew.Width = 40;
            // 
            // colMeetingId
            // 
            this.colMeetingId.DataPropertyName = "MeetingId";
            this.colMeetingId.HeaderText = "MeetingId";
            this.colMeetingId.Name = "colMeetingId";
            this.colMeetingId.ReadOnly = true;
            this.colMeetingId.Visible = false;
            // 
            // colMeetingName
            // 
            this.colMeetingName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMeetingName.DataPropertyName = "MeetingName";
            this.colMeetingName.HeaderText = "Cuộc họp";
            this.colMeetingName.Name = "colMeetingName";
            this.colMeetingName.ReadOnly = true;
            // 
            // colOrganizationMeeting
            // 
            this.colOrganizationMeeting.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOrganizationMeeting.DataPropertyName = "OrganizationMeeting";
            this.colOrganizationMeeting.HeaderText = "Đơn vị";
            this.colOrganizationMeeting.Name = "colOrganizationMeeting";
            this.colOrganizationMeeting.ReadOnly = true;
            // 
            // colDateTime
            // 
            this.colDateTime.DataPropertyName = "DateTime";
            this.colDateTime.HeaderText = "DateTime";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.ReadOnly = true;
            // 
            // colStartTime
            // 
            this.colStartTime.DataPropertyName = "StartTime";
            this.colStartTime.HeaderText = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.ReadOnly = true;
            // 
            // colEndTime
            // 
            this.colEndTime.DataPropertyName = "EndTime";
            this.colEndTime.HeaderText = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.ReadOnly = true;
            this.colEndTime.Visible = false;
            // 
            // colCheck
            // 
            this.colCheck.DataPropertyName = "Check";
            this.colCheck.FalseValue = "";
            this.colCheck.HeaderText = "Tham dự họp";
            this.colCheck.IndeterminateValue = "";
            this.colCheck.Name = "colCheck";
            this.colCheck.ReadOnly = true;
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCheck.TrueValue = "";
            this.colCheck.Width = 130;
            // 
            // colRoomName
            // 
            this.colRoomName.DataPropertyName = "RoomName";
            this.colRoomName.HeaderText = "RoomName";
            this.colRoomName.Name = "colRoomName";
            this.colRoomName.ReadOnly = true;
            this.colRoomName.Visible = false;
            // 
            // colNumber
            // 
            this.colNumber.DataPropertyName = "Number";
            this.colNumber.HeaderText = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
            this.colNumber.Visible = false;
            // 
            // colListAttend
            // 
            this.colListAttend.DataPropertyName = "ListAttend";
            this.colListAttend.HeaderText = "Ds người tham dự";
            this.colListAttend.Name = "colListAttend";
            this.colListAttend.ReadOnly = true;
            this.colListAttend.Visible = false;
            // 
            // Frm2DetailInforBySerialNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 711);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Frm2DetailInforBySerialNumber";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm2DetailInforBySerialNumber_FormClosing);
            this.panel3.ResumeLayout(false);
            this.panel7PlusInfo.ResumeLayout(false);
            this.grblblInforPlus.ResumeLayout(false);
            this.grblblInforPlus.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.gbxAttendMeeting.ResumeLayout(false);
            this.panel4ListMeeting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMeetingToday)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4Click.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.grblblJournalistInfo.ResumeLayout(false);
            this.grblblJournalistInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel3;
        private Label lblguideEnter;
        private Button btnCancel;
        private Panel panel7PlusInfo;
        private Button btnConfirm;
        private Panel panel2;
        private Panel panel8;
        private GroupBox gbxAttendMeeting;
        private Panel panel4ListMeeting;
        private CommonControls.Custom.CommonDataGridView dgvListMeetingToday;
        private Panel panel1;
        private Panel panel4Click;
        private RadioButton rbtnNotAttendMeeting;
        private RadioButton rbtnAttendMeeting;
        private Label lblAttendMeetingClick;
        private GroupBox grblblJournalistInfo;
        private TextBox txtPosition;
        private TextBox txtLowerFullName;
        private TextBox txtOrg;
        private DateTimePicker dtpBirthDate;
        private Label lblBrithDay;
        private TextBox txtIdentityCard;
        private Label lblCMND;
        private TextBox txtPhoneNo;
        private Label lblTel;
        private TextBox txtEmail;
        private Label lblEmail;
        private Label lblPosition;
        private Label lblLowerName;
        private Label lblChooseOrg;
        private GroupBox grblblInforPlus;
        private TextBox txtNote;
        private Label lblNotess;
        private DataGridViewTextBoxColumn colSttnew;
        private DataGridViewTextBoxColumn colMeetingId;
        private DataGridViewTextBoxColumn colMeetingName;
        private DataGridViewTextBoxColumn colOrganizationMeeting;
        private DataGridViewTextBoxColumn colDateTime;
        private DataGridViewTextBoxColumn colStartTime;
        private DataGridViewTextBoxColumn colEndTime;
        private DataGridViewCheckBoxColumn colCheck;
        private DataGridViewTextBoxColumn colRoomName;
        private DataGridViewTextBoxColumn colNumber;
        private DataGridViewTextBoxColumn colListAttend;
    }
}