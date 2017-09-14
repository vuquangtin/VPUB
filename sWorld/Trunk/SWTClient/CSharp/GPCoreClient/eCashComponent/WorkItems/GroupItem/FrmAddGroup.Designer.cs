namespace eCashComponent
{
    partial class FrmAddGroup
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbxDescriptionGroup = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxGroupName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.panel9.Size = new System.Drawing.Size(628, 81);
            this.panel9.TabIndex = 65;
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNote.Location = new System.Drawing.Point(14, 42);
            this.lbNote.Margin = new System.Windows.Forms.Padding(3);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(234, 14);
            this.lbNote.TabIndex = 1;
            this.lbNote.Text = "Thêm thông tin nhóm mới vào hệ thống.";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(14, 24);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(144, 14);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Thêm Thông Tin Nhóm";
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 81);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(628, 1);
            this.line1.TabIndex = 66;
            this.line1.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.tbxDescriptionGroup);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.tbxGroupName);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 109);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel6.Size = new System.Drawing.Size(628, 168);
            this.panel6.TabIndex = 93;
            // 
            // tbxDescriptionGroup
            // 
            this.tbxDescriptionGroup.Location = new System.Drawing.Point(90, 37);
            this.tbxDescriptionGroup.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.tbxDescriptionGroup.MaxLength = 255;
            this.tbxDescriptionGroup.Multiline = true;
            this.tbxDescriptionGroup.Name = "tbxDescriptionGroup";
            this.tbxDescriptionGroup.Size = new System.Drawing.Size(528, 123);
            this.tbxDescriptionGroup.TabIndex = 61;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 60;
            this.label6.Text = "Mô tả:";
            // 
            // tbxGroupName
            // 
            this.tbxGroupName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbxGroupName.Location = new System.Drawing.Point(90, 12);
            this.tbxGroupName.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.tbxGroupName.Name = "tbxGroupName";
            this.tbxGroupName.Size = new System.Drawing.Size(221, 22);
            this.tbxGroupName.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(12, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 57;
            this.label4.Text = "Tên nhóm:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 277);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(628, 41);
            this.panel1.TabIndex = 92;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(307, 8);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 26);
            this.btnConfirm.TabIndex = 13;
            this.btnConfirm.Text = "Xác Nhận...";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(407, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(6, 26);
            this.panel4.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(413, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 26);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(513, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(6, 26);
            this.panel2.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(519, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(0, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(628, 27);
            this.label3.TabIndex = 91;
            this.label3.Text = "Thông tin nhóm";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmAddGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 318);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.Name = "FrmAddGroup";
            this.Text = "Thêm Nhóm";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Label lbTitle;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox tbxDescriptionGroup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxGroupName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
    }
}