namespace sAccessComponent.WorkItems
{
    partial class FrmAddOrEditMontlyDebt
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
            this.line1 = new CommonControls.Custom.Line();
            this.lblInfoNoQuaHan = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numMontlyDebt = new System.Windows.Forms.NumericUpDown();
            this.lblNoQuaHanConfig = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMontlyDebt)).BeginInit();
            this.SuspendLayout();
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(275, 1);
            this.line1.TabIndex = 63;
            this.line1.TabStop = false;
            // 
            // lblInfoNoQuaHan
            // 
            this.lblInfoNoQuaHan.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfoNoQuaHan.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblInfoNoQuaHan.Location = new System.Drawing.Point(0, 1);
            this.lblInfoNoQuaHan.Name = "lblInfoNoQuaHan";
            this.lblInfoNoQuaHan.Padding = new System.Windows.Forms.Padding(5);
            this.lblInfoNoQuaHan.Size = new System.Drawing.Size(275, 58);
            this.lblInfoNoQuaHan.TabIndex = 74;
            this.lblInfoNoQuaHan.Text = "Cấu hình tổng số ngày nợ quá hạn. Nếu vượt quá tổng số ngày nợ quá hạn sẽ không c" +
    "ho vào cửa.";
            this.lblInfoNoQuaHan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 104);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(275, 44);
            this.panel1.TabIndex = 77;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(18, 8);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(117, 28);
            this.btnConfirm.TabIndex = 19;
            this.btnConfirm.Text = "Xác Nhận...";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(134, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(7, 28);
            this.panel3.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(141, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 28);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.numMontlyDebt);
            this.panel2.Controls.Add(this.lblNoQuaHanConfig);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 45);
            this.panel2.TabIndex = 78;
            // 
            // numMontlyDebt
            // 
            this.numMontlyDebt.Location = new System.Drawing.Point(181, 11);
            this.numMontlyDebt.Name = "numMontlyDebt";
            this.numMontlyDebt.Size = new System.Drawing.Size(76, 22);
            this.numMontlyDebt.TabIndex = 44;
            // 
            // lblNoQuaHanConfig
            // 
            this.lblNoQuaHanConfig.AutoSize = true;
            this.lblNoQuaHanConfig.Location = new System.Drawing.Point(14, 13);
            this.lblNoQuaHanConfig.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblNoQuaHanConfig.Name = "lblNoQuaHanConfig";
            this.lblNoQuaHanConfig.Size = new System.Drawing.Size(158, 16);
            this.lblNoQuaHanConfig.TabIndex = 43;
            this.lblNoQuaHanConfig.Text = "Tổng số ngày nợ quá hạn:";
            // 
            // FrmAddOrEditMontlyDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 148);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblInfoNoQuaHan);
            this.Controls.Add(this.line1);
            this.Name = "FrmAddOrEditMontlyDebt";
            this.Text = "Cấu Hình Tổng Ngày Nợ Quá Hạn";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMontlyDebt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Label lblInfoNoQuaHan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNoQuaHanConfig;
        private System.Windows.Forms.NumericUpDown numMontlyDebt;
    }
}