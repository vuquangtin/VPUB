﻿namespace SystemMgtComponent.WorkItems.IntegratingExcel
{
    partial class FrmReadExcelData
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
            this.btnNext = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cbxReviewData = new System.Windows.Forms.CheckBox();
            this.line1 = new CommonControls.Custom.Line();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbl1_FrmReadExcelData = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(481, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Hủy Bỏ...";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(375, 344);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 26);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Tiếp Tục";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage.Location = new System.Drawing.Point(10, 40);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(574, 50);
            this.lblMessage.TabIndex = 15;
            this.lblMessage.Text = "Đang chuẩn bị...";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(10, 10);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(574, 30);
            this.progressBar1.TabIndex = 14;
            // 
            // cbxReviewData
            // 
            this.cbxReviewData.AutoSize = true;
            this.cbxReviewData.Checked = true;
            this.cbxReviewData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxReviewData.Location = new System.Drawing.Point(13, 275);
            this.cbxReviewData.Name = "cbxReviewData";
            this.cbxReviewData.Size = new System.Drawing.Size(373, 20);
            this.cbxReviewData.TabIndex = 13;
            this.cbxReviewData.Text = "Kiểm tra lại dữ liệu trước khi tiến hành tích hợp vào hệ thống";
            this.cbxReviewData.UseVisualStyleBackColor = true;
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
            this.line1.TabIndex = 61;
            this.line1.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lbl1_FrmReadExcelData);
            this.panel9.Controls.Add(this.label10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(594, 75);
            this.panel9.TabIndex = 60;
            // 
            // lbl1_FrmReadExcelData
            // 
            this.lbl1_FrmReadExcelData.AutoSize = true;
            this.lbl1_FrmReadExcelData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1_FrmReadExcelData.Location = new System.Drawing.Point(12, 39);
            this.lbl1_FrmReadExcelData.Margin = new System.Windows.Forms.Padding(3);
            this.lbl1_FrmReadExcelData.Name = "lbl1_FrmReadExcelData";
            this.lbl1_FrmReadExcelData.Size = new System.Drawing.Size(445, 14);
            this.lbl1_FrmReadExcelData.TabIndex = 1;
            this.lbl1_FrmReadExcelData.Text = "Phân tích dữ liệu từ tập tin MS Excel và đồng bộ với cơ sở dữ liệu của hệ thống.";
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
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.cbxReviewData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 77);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.panel1.Size = new System.Drawing.Size(594, 378);
            this.panel1.TabIndex = 62;
            // 
            // FrmReadExcelData
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(594, 455);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.Name = "FrmReadExcelData";
            this.Text = "Đọc Dữ Liệu Từ Tập Tin Access";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox cbxReviewData;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbl1_FrmReadExcelData;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
    }
}