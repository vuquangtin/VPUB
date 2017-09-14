namespace SystemMgtComponent.WorkItems
{
    partial class frmSendSmsToContact
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
            this.lblNote = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.line2 = new CommonControls.Custom.Line();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbxSmsContent = new CommonControls.Custom.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstContact = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSendSMS = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lblNote);
            this.panel9.Controls.Add(this.lbTitle);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(518, 75);
            this.panel9.TabIndex = 62;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(12, 39);
            this.lblNote.Margin = new System.Windows.Forms.Padding(3);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(177, 14);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "Gửi tin nhắn cho người liên hệ.";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(12, 22);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(84, 14);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Gửi Tin Nhắn";
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 75);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(518, 1);
            this.line1.TabIndex = 64;
            this.line1.TabStop = false;
            // 
            // line2
            // 
            this.line2.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line2.Dock = System.Windows.Forms.DockStyle.Top;
            this.line2.Location = new System.Drawing.Point(0, 76);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(518, 1);
            this.line2.TabIndex = 66;
            this.line2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(518, 320);
            this.panel2.TabIndex = 69;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbxSmsContent);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(200, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panel4.Size = new System.Drawing.Size(318, 272);
            this.panel4.TabIndex = 74;
            // 
            // tbxSmsContent
            // 
            this.tbxSmsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxSmsContent.Location = new System.Drawing.Point(5, 25);
            this.tbxSmsContent.Multiline = true;
            this.tbxSmsContent.Name = "tbxSmsContent";
            this.tbxSmsContent.Size = new System.Drawing.Size(308, 242);
            this.tbxSmsContent.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(5, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 25);
            this.label1.TabIndex = 81;
            this.label1.Text = "Nội dung tin nhắn:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lstContact);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panel1.Size = new System.Drawing.Size(200, 272);
            this.panel1.TabIndex = 73;
            // 
            // lstContact
            // 
            this.lstContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstContact.FormattingEnabled = true;
            this.lstContact.Location = new System.Drawing.Point(5, 25);
            this.lstContact.Name = "lstContact";
            this.lstContact.Size = new System.Drawing.Size(188, 240);
            this.lstContact.TabIndex = 81;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(5, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 25);
            this.label8.TabIndex = 80;
            this.label8.Text = "Người nhận tin nhắn:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSendSMS);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 272);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(518, 48);
            this.panel3.TabIndex = 71;
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSendSMS.Location = new System.Drawing.Point(304, 10);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Size = new System.Drawing.Size(100, 26);
            this.btnSendSMS.TabIndex = 23;
            this.btnSendSMS.Text = "Gửi Tin Nhắn";
            this.btnSendSMS.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Location = new System.Drawing.Point(410, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmSendSmsToContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 397);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.Name = "frmSendSmsToContact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gửi Tin Nhắn";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lbTitle;
        private CommonControls.Custom.Line line1;
        private CommonControls.Custom.Line line2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private CommonControls.Custom.CommonTextBox tbxSmsContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox lstContact;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSendSMS;
    }
}