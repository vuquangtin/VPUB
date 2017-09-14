namespace sTimeKeeping.WorkItems
{
    partial class sheet
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.pnlDetailFill = new System.Windows.Forms.Panel();
            this.pnlDetailRight = new System.Windows.Forms.Panel();
            this.pnlDetailLeft = new System.Windows.Forms.Panel();
            this.pnlTime = new System.Windows.Forms.Panel();
            this.pnlDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.pnlDetailFill);
            this.pnlDetail.Controls.Add(this.pnlDetailRight);
            this.pnlDetail.Controls.Add(this.pnlDetailLeft);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetail.Location = new System.Drawing.Point(0, 26);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(867, 30);
            this.pnlDetail.TabIndex = 5;
            // 
            // pnlDetailFill
            // 
            this.pnlDetailFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetailFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailFill.Location = new System.Drawing.Point(34, 0);
            this.pnlDetailFill.Name = "pnlDetailFill";
            this.pnlDetailFill.Size = new System.Drawing.Size(801, 30);
            this.pnlDetailFill.TabIndex = 5;
            // 
            // pnlDetailRight
            // 
            this.pnlDetailRight.BackColor = System.Drawing.Color.White;
            this.pnlDetailRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetailRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetailRight.Location = new System.Drawing.Point(835, 0);
            this.pnlDetailRight.Name = "pnlDetailRight";
            this.pnlDetailRight.Size = new System.Drawing.Size(32, 30);
            this.pnlDetailRight.TabIndex = 4;
            // 
            // pnlDetailLeft
            // 
            this.pnlDetailLeft.BackColor = System.Drawing.Color.White;
            this.pnlDetailLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetailLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDetailLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlDetailLeft.Name = "pnlDetailLeft";
            this.pnlDetailLeft.Size = new System.Drawing.Size(34, 30);
            this.pnlDetailLeft.TabIndex = 3;
            // 
            // pnlTime
            // 
            this.pnlTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTime.Location = new System.Drawing.Point(0, 0);
            this.pnlTime.Name = "pnlTime";
            this.pnlTime.Size = new System.Drawing.Size(867, 25);
            this.pnlTime.TabIndex = 9;
            // 
            // sheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTime);
            this.Controls.Add(this.pnlDetail);
            this.Name = "sheet";
            this.Size = new System.Drawing.Size(867, 56);
            this.Load += new System.EventHandler(this.sheet_Load);
            this.pnlDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Panel pnlDetailFill;
        private System.Windows.Forms.Panel pnlDetailRight;
        private System.Windows.Forms.Panel pnlDetailLeft;
        private System.Windows.Forms.Panel pnlTime;
    }
}
