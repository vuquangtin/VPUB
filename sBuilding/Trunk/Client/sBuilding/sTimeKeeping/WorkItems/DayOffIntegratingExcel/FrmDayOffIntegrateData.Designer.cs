namespace sTimeKeeping.WorkItems.DayOffIntegratingExcel
{
    partial class FrmDayOffIntegrateData
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
            this.dgvRecord = new CommonControls.Custom.CommonDataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.line1 = new CommonControls.Custom.Line();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbl1_FrmIntegrateData = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl2_lbl1_FrmIntegrateData = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCurrentWork = new System.Windows.Forms.Label();
            this.prgCurrent = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecord)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRecord
            // 
            this.dgvRecord.AllowUserToAddRows = false;
            this.dgvRecord.AllowUserToDeleteRows = false;
            this.dgvRecord.AllowUserToOrderColumns = true;
            this.dgvRecord.AllowUserToResizeRows = false;
            this.dgvRecord.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecord.Location = new System.Drawing.Point(0, 27);
            this.dgvRecord.Name = "dgvRecord";
            this.dgvRecord.ReadOnly = true;
            this.dgvRecord.RowHeadersVisible = false;
            this.dgvRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecord.Size = new System.Drawing.Size(595, 308);
            this.dgvRecord.TabIndex = 34;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(475, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 28);
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
            this.line1.Location = new System.Drawing.Point(0, 81);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(619, 2);
            this.line1.TabIndex = 62;
            this.line1.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lbl1_FrmIntegrateData);
            this.panel9.Controls.Add(this.label10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(619, 81);
            this.panel9.TabIndex = 61;
            // 
            // lbl1_FrmIntegrateData
            // 
            this.lbl1_FrmIntegrateData.AutoSize = true;
            this.lbl1_FrmIntegrateData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1_FrmIntegrateData.Location = new System.Drawing.Point(14, 42);
            this.lbl1_FrmIntegrateData.Margin = new System.Windows.Forms.Padding(3);
            this.lbl1_FrmIntegrateData.Name = "lbl1_FrmIntegrateData";
            this.lbl1_FrmIntegrateData.Size = new System.Drawing.Size(449, 14);
            this.lbl1_FrmIntegrateData.TabIndex = 1;
            this.lbl1_FrmIntegrateData.Text = "Phân tích dữ liệu từ tập tin MS Excel và đồng bộ với cơ sở dữ liệu của hệ thống.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tích Hợp Dữ Liệu";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(12, 11, 12, 5);
            this.panel1.Size = new System.Drawing.Size(619, 489);
            this.panel1.TabIndex = 63;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvRecord);
            this.panel4.Controls.Add(this.lbl2_lbl1_FrmIntegrateData);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(12, 104);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(595, 335);
            this.panel4.TabIndex = 20;
            // 
            // lbl2_lbl1_FrmIntegrateData
            // 
            this.lbl2_lbl1_FrmIntegrateData.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl2_lbl1_FrmIntegrateData.Location = new System.Drawing.Point(0, 0);
            this.lbl2_lbl1_FrmIntegrateData.Name = "lbl2_lbl1_FrmIntegrateData";
            this.lbl2_lbl1_FrmIntegrateData.Size = new System.Drawing.Size(595, 27);
            this.lbl2_lbl1_FrmIntegrateData.TabIndex = 33;
            this.lbl2_lbl1_FrmIntegrateData.Text = "Danh sách thành viên bị lỗi khi cập nhật vào hệ thống";
            this.lbl2_lbl1_FrmIntegrateData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblCurrentWork);
            this.panel3.Controls.Add(this.prgCurrent);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(12, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(595, 93);
            this.panel3.TabIndex = 19;
            // 
            // lblCurrentWork
            // 
            this.lblCurrentWork.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentWork.Location = new System.Drawing.Point(0, 32);
            this.lblCurrentWork.Name = "lblCurrentWork";
            this.lblCurrentWork.Size = new System.Drawing.Size(595, 54);
            this.lblCurrentWork.TabIndex = 17;
            this.lblCurrentWork.Text = "Đang chuẩn bị...";
            this.lblCurrentWork.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prgCurrent
            // 
            this.prgCurrent.Dock = System.Windows.Forms.DockStyle.Top;
            this.prgCurrent.Location = new System.Drawing.Point(0, 0);
            this.prgCurrent.Name = "prgCurrent";
            this.prgCurrent.Size = new System.Drawing.Size(595, 32);
            this.prgCurrent.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(12, 439);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(595, 45);
            this.panel2.TabIndex = 18;
            // 
            // FrmDayOffIntegrateData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 489);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDayOffIntegrateData";
            this.Text = "FrmDayOffIntegrateData";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecord)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControls.Custom.CommonDataGridView dgvRecord;
        private System.Windows.Forms.Button btnCancel;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbl1_FrmIntegrateData;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl2_lbl1_FrmIntegrateData;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCurrentWork;
        private System.Windows.Forms.ProgressBar prgCurrent;
        private System.Windows.Forms.Panel panel2;
    }
}