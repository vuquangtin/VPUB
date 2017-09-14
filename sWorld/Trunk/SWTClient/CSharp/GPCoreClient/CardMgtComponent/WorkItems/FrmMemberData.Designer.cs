namespace CardMgtComponent.WorkItems
{
    partial class FrmMemberData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMemberData));
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbxHideAfterTagRemoved = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDataOnCard = new System.Windows.Forms.Label();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.line1 = new CommonControls.Custom.Line();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGUIMemberData = new System.Windows.Forms.Label();
            this.lblMemberData = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbxHideAfterTagRemoved);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lblDataOnCard);
            this.panel2.Controls.Add(this.lblSerialNumber);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel2.Size = new System.Drawing.Size(394, 218);
            this.panel2.TabIndex = 20;
            // 
            // cbxHideAfterTagRemoved
            // 
            this.cbxHideAfterTagRemoved.AutoSize = true;
            this.cbxHideAfterTagRemoved.Checked = true;
            this.cbxHideAfterTagRemoved.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxHideAfterTagRemoved.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxHideAfterTagRemoved.Location = new System.Drawing.Point(10, 140);
            this.cbxHideAfterTagRemoved.Name = "cbxHideAfterTagRemoved";
            this.cbxHideAfterTagRemoved.Size = new System.Drawing.Size(374, 20);
            this.cbxHideAfterTagRemoved.TabIndex = 25;
            this.cbxHideAfterTagRemoved.Text = "Đóng hộp thoại này sau khi đưa thẻ ra khỏi thiết bị đọc";
            this.cbxHideAfterTagRemoved.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 130);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(374, 10);
            this.panel3.TabIndex = 23;
            // 
            // lblDataOnCard
            // 
            this.lblDataOnCard.BackColor = System.Drawing.Color.White;
            this.lblDataOnCard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDataOnCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDataOnCard.Location = new System.Drawing.Point(10, 30);
            this.lblDataOnCard.Name = "lblDataOnCard";
            this.lblDataOnCard.Size = new System.Drawing.Size(374, 100);
            this.lblDataOnCard.TabIndex = 22;
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSerialNumber.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNumber.Location = new System.Drawing.Point(10, 5);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(374, 25);
            this.lblSerialNumber.TabIndex = 19;
            this.lblSerialNumber.Text = "Mã Thẻ:";
            this.lblSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(281, 180);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 26);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Line3DStyle = CommonControls.Custom.Line3DStyle.Inset;
            this.line1.Location = new System.Drawing.Point(0, 75);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(394, 2);
            this.line1.TabIndex = 19;
            this.line1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblGUIMemberData);
            this.panel1.Controls.Add(this.lblMemberData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 75);
            this.panel1.TabIndex = 18;
            // 
            // lblGUIMemberData
            // 
            this.lblGUIMemberData.AutoSize = true;
            this.lblGUIMemberData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGUIMemberData.Location = new System.Drawing.Point(12, 39);
            this.lblGUIMemberData.Margin = new System.Windows.Forms.Padding(3);
            this.lblGUIMemberData.Name = "lblGUIMemberData";
            this.lblGUIMemberData.Size = new System.Drawing.Size(240, 14);
            this.lblGUIMemberData.TabIndex = 1;
            this.lblGUIMemberData.Text = "Thông tin của hội viên được lưu trong thẻ";
            // 
            // lblMemberData
            // 
            this.lblMemberData.AutoSize = true;
            this.lblMemberData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberData.Location = new System.Drawing.Point(12, 22);
            this.lblMemberData.Name = "lblMemberData";
            this.lblMemberData.Size = new System.Drawing.Size(122, 14);
            this.lblMemberData.TabIndex = 0;
            this.lblMemberData.Text = "Thông Tin Hội Viên";
            // 
            // FrmMemberData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 295);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMemberData";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.Text = "Thông Tin Hội Viên";
            this.Load += new System.EventHandler(this.FrmMemberData_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDataOnCard;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Button btnClose;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGUIMemberData;
        private System.Windows.Forms.Label lblMemberData;
        private System.Windows.Forms.CheckBox cbxHideAfterTagRemoved;
        private System.Windows.Forms.Panel panel3;

    }
}