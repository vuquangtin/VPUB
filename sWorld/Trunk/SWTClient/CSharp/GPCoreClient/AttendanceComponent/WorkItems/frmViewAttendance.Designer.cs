namespace AttendanceComponent.WorkItems
{
    partial class frmViewAttendance
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxPosition = new System.Windows.Forms.TextBox();
            this.tbxSubOrgName = new System.Windows.Forms.TextBox();
            this.tbxMemberCode = new System.Windows.Forms.TextBox();
            this.tbxSerialNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.picAttendanceOut = new System.Windows.Forms.PictureBox();
            this.lbDateTimeOut = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.picAttendanceIn = new System.Windows.Forms.PictureBox();
            this.lbDateTimeIn = new System.Windows.Forms.Label();
            this.panel9.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAttendanceOut)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAttendanceIn)).BeginInit();
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
            this.panel9.Size = new System.Drawing.Size(816, 75);
            this.panel9.TabIndex = 63;
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNote.Location = new System.Drawing.Point(12, 39);
            this.lbNote.Margin = new System.Windows.Forms.Padding(3);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(150, 14);
            this.lbNote.TabIndex = 1;
            this.lbNote.Text = "Xem thông tin lượt vào/ra";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(12, 22);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(182, 14);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Xem Thông Tin Lượt Vào/Ra";
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 75);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(816, 1);
            this.line1.TabIndex = 64;
            this.line1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 552);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(816, 48);
            this.panel3.TabIndex = 72;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Location = new System.Drawing.Point(704, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbl
            // 
            this.lbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.lbl.Location = new System.Drawing.Point(0, 76);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(816, 25);
            this.lbl.TabIndex = 78;
            this.lbl.Text = "Thông tin thành viên";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbxPosition);
            this.panel1.Controls.Add(this.tbxSubOrgName);
            this.panel1.Controls.Add(this.tbxMemberCode);
            this.panel1.Controls.Add(this.tbxSerialNumber);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtFullName);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 63);
            this.panel1.TabIndex = 79;
            // 
            // tbxPosition
            // 
            this.tbxPosition.Location = new System.Drawing.Point(275, 33);
            this.tbxPosition.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tbxPosition.Name = "tbxPosition";
            this.tbxPosition.ReadOnly = true;
            this.tbxPosition.Size = new System.Drawing.Size(103, 22);
            this.tbxPosition.TabIndex = 73;
            // 
            // tbxSubOrgName
            // 
            this.tbxSubOrgName.Location = new System.Drawing.Point(63, 33);
            this.tbxSubOrgName.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tbxSubOrgName.Name = "tbxSubOrgName";
            this.tbxSubOrgName.ReadOnly = true;
            this.tbxSubOrgName.Size = new System.Drawing.Size(103, 22);
            this.tbxSubOrgName.TabIndex = 72;
            // 
            // tbxMemberCode
            // 
            this.tbxMemberCode.Location = new System.Drawing.Point(275, 7);
            this.tbxMemberCode.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tbxMemberCode.Name = "tbxMemberCode";
            this.tbxMemberCode.ReadOnly = true;
            this.tbxMemberCode.Size = new System.Drawing.Size(103, 22);
            this.tbxMemberCode.TabIndex = 71;
            // 
            // tbxSerialNumber
            // 
            this.tbxSerialNumber.Location = new System.Drawing.Point(63, 7);
            this.tbxSerialNumber.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tbxSerialNumber.Name = "tbxSerialNumber";
            this.tbxSerialNumber.ReadOnly = true;
            this.tbxSerialNumber.Size = new System.Drawing.Size(103, 22);
            this.tbxSerialNumber.TabIndex = 70;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 69;
            this.label5.Text = "Chức vụ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 16);
            this.label4.TabIndex = 68;
            this.label4.Text = "Lớp:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 67;
            this.label3.Text = "Mã thành viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 66;
            this.label2.Text = "Mã thẻ:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(461, 7);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(200, 22);
            this.txtFullName.TabIndex = 64;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(386, 10);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 16);
            this.label21.TabIndex = 65;
            this.label21.Text = "Họ và tên:";
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(0, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(816, 25);
            this.label6.TabIndex = 80;
            this.label6.Text = "Thông tin hình ảnh";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 189);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(816, 363);
            this.panel2.TabIndex = 81;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.lbDateTimeOut);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(409, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(400, 351);
            this.panel5.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.picAttendanceOut);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 25);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(5);
            this.panel7.Size = new System.Drawing.Size(398, 324);
            this.panel7.TabIndex = 83;
            // 
            // picAttendanceOut
            // 
            this.picAttendanceOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAttendanceOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picAttendanceOut.Location = new System.Drawing.Point(5, 5);
            this.picAttendanceOut.Name = "picAttendanceOut";
            this.picAttendanceOut.Size = new System.Drawing.Size(388, 314);
            this.picAttendanceOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAttendanceOut.TabIndex = 0;
            this.picAttendanceOut.TabStop = false;
            // 
            // lbDateTimeOut
            // 
            this.lbDateTimeOut.BackColor = System.Drawing.Color.Teal;
            this.lbDateTimeOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbDateTimeOut.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.lbDateTimeOut.ForeColor = System.Drawing.Color.White;
            this.lbDateTimeOut.Location = new System.Drawing.Point(0, 0);
            this.lbDateTimeOut.Name = "lbDateTimeOut";
            this.lbDateTimeOut.Size = new System.Drawing.Size(398, 25);
            this.lbDateTimeOut.TabIndex = 81;
            this.lbDateTimeOut.Text = "Thời gian ra: dd/MM/yyyy hh:mm:ss";
            this.lbDateTimeOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.lbDateTimeIn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(5, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(400, 351);
            this.panel4.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.picAttendanceIn);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 25);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(5);
            this.panel6.Size = new System.Drawing.Size(398, 324);
            this.panel6.TabIndex = 82;
            // 
            // picAttendanceIn
            // 
            this.picAttendanceIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAttendanceIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picAttendanceIn.Location = new System.Drawing.Point(5, 5);
            this.picAttendanceIn.Name = "picAttendanceIn";
            this.picAttendanceIn.Size = new System.Drawing.Size(388, 314);
            this.picAttendanceIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAttendanceIn.TabIndex = 0;
            this.picAttendanceIn.TabStop = false;
            // 
            // lbDateTimeIn
            // 
            this.lbDateTimeIn.BackColor = System.Drawing.Color.Green;
            this.lbDateTimeIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbDateTimeIn.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.lbDateTimeIn.ForeColor = System.Drawing.Color.White;
            this.lbDateTimeIn.Location = new System.Drawing.Point(0, 0);
            this.lbDateTimeIn.Name = "lbDateTimeIn";
            this.lbDateTimeIn.Size = new System.Drawing.Size(398, 25);
            this.lbDateTimeIn.TabIndex = 81;
            this.lbDateTimeIn.Text = "Thời gian vào: dd/MM/yyyy hh:mm:ss";
            this.lbDateTimeIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmViewAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 600);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.Name = "frmViewAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem Thông Tin Lượt Vào/Ra";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAttendanceOut)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAttendanceIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Label lbTitle;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxPosition;
        private System.Windows.Forms.TextBox tbxSubOrgName;
        private System.Windows.Forms.TextBox tbxMemberCode;
        private System.Windows.Forms.TextBox tbxSerialNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbDateTimeIn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox picAttendanceOut;
        private System.Windows.Forms.Label lbDateTimeOut;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox picAttendanceIn;
    }
}