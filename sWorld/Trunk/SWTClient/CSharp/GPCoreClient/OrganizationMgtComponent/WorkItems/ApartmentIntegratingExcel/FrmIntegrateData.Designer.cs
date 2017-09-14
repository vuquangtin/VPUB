namespace SystemMgtComponent.WorkItems.ApartmentIntegratingExcel
{
    partial class FrmIntegrateData
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.line1 = new CommonControls.Custom.Line();
            this.panel9 = new System.Windows.Forms.Panel();
            this.String2 = new System.Windows.Forms.Label();
            this.lblDataIntegration = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCurrentWork = new System.Windows.Forms.Label();
            this.prgCurrent = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(471, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Hủy Bỏ...";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Line3DStyle = CommonControls.Custom.Line3DStyle.Inset;
            this.line1.Location = new System.Drawing.Point(0, 75);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(594, 2);
            this.line1.TabIndex = 59;
            this.line1.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.String2);
            this.panel9.Controls.Add(this.lblDataIntegration);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(594, 75);
            this.panel9.TabIndex = 58;
            // 
            // String2
            // 
            this.String2.AutoSize = true;
            this.String2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.String2.Location = new System.Drawing.Point(12, 39);
            this.String2.Margin = new System.Windows.Forms.Padding(3);
            this.String2.Name = "String2";
            this.String2.Size = new System.Drawing.Size(445, 14);
            this.String2.TabIndex = 1;
            this.String2.Text = "Phân tích dữ liệu từ tập tin MS Excel và đồng bộ với cơ sở dữ liệu của hệ thống.";
            // 
            // lblDataIntegration
            // 
            this.lblDataIntegration.AutoSize = true;
            this.lblDataIntegration.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataIntegration.Location = new System.Drawing.Point(12, 22);
            this.lblDataIntegration.Name = "lblDataIntegration";
            this.lblDataIntegration.Size = new System.Drawing.Size(111, 14);
            this.lblDataIntegration.TabIndex = 0;
            this.lblDataIntegration.Text = "Tích Hợp Dữ Liệu";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 77);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.panel1.Size = new System.Drawing.Size(594, 378);
            this.panel1.TabIndex = 60;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblCurrentWork);
            this.panel3.Controls.Add(this.prgCurrent);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(574, 86);
            this.panel3.TabIndex = 19;
            // 
            // lblCurrentWork
            // 
            this.lblCurrentWork.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentWork.Location = new System.Drawing.Point(0, 30);
            this.lblCurrentWork.Name = "lblCurrentWork";
            this.lblCurrentWork.Size = new System.Drawing.Size(574, 50);
            this.lblCurrentWork.TabIndex = 17;
            this.lblCurrentWork.Text = "Đang chuẩn bị...";
            this.lblCurrentWork.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prgCurrent
            // 
            this.prgCurrent.Dock = System.Windows.Forms.DockStyle.Top;
            this.prgCurrent.Location = new System.Drawing.Point(0, 0);
            this.prgCurrent.Name = "prgCurrent";
            this.prgCurrent.Size = new System.Drawing.Size(574, 30);
            this.prgCurrent.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(10, 331);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(574, 42);
            this.panel2.TabIndex = 18;
            // 
            // FrmIntegrateData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 455);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.Name = "FrmIntegrateData";
            this.Text = "Tích Hợp Dữ Liệu";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label String2;
        private System.Windows.Forms.Label lblDataIntegration;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCurrentWork;
        private System.Windows.Forms.ProgressBar prgCurrent;
        private System.Windows.Forms.Panel panel2;
    }
}