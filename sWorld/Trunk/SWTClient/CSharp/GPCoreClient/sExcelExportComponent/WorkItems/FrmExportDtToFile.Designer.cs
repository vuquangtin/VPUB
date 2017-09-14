namespace sExcelExportComponent.WorkItems
{
    partial class FrmExportDtToFile
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
                this.panel1 = new System.Windows.Forms.Panel();
                this.lblDescription = new System.Windows.Forms.Label();
                this.panel2 = new System.Windows.Forms.Panel();
                this.prgCurrent = new System.Windows.Forms.ProgressBar();
                this.lblCurrentWork = new System.Windows.Forms.Label();
                this.panel4 = new System.Windows.Forms.Panel();
                this.btnOpenFile = new System.Windows.Forms.Button();
                this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                this.panel1.SuspendLayout();
                this.panel2.SuspendLayout();
                this.panel4.SuspendLayout();
                this.SuspendLayout();
                // 
                // panel1
                // 
                this.panel1.BackColor = System.Drawing.Color.White;
                this.panel1.Controls.Add(this.lblDescription);
                this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
                this.panel1.Location = new System.Drawing.Point(0, 0);
                this.panel1.Name = "panel1";
                this.panel1.Padding = new System.Windows.Forms.Padding(5);
                this.panel1.Size = new System.Drawing.Size(594, 75);
                this.panel1.TabIndex = 63;
                // 
                // lblDescription
                // 
                this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
                this.lblDescription.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblDescription.Location = new System.Drawing.Point(5, 5);
                this.lblDescription.Margin = new System.Windows.Forms.Padding(3);
                this.lblDescription.Name = "lblDescription";
                this.lblDescription.Size = new System.Drawing.Size(584, 65);
                this.lblDescription.TabIndex = 1;
                this.lblDescription.Text = "Xuất dữ liệu vé tháng ra các định dạng tập tin được hỗ trợ";
                this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
               
                // panel2
                // 
                this.panel2.Controls.Add(this.prgCurrent);
                this.panel2.Controls.Add(this.lblCurrentWork);
                this.panel2.Controls.Add(this.panel4);
                this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
                this.panel2.Location = new System.Drawing.Point(0, 77);
                this.panel2.Name = "panel2";
                this.panel2.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
                this.panel2.Size = new System.Drawing.Size(594, 378);
                this.panel2.TabIndex = 65;
                // 
                // prgCurrent
                // 
                this.prgCurrent.Dock = System.Windows.Forms.DockStyle.Top;
                this.prgCurrent.Location = new System.Drawing.Point(5, 10);
                this.prgCurrent.Name = "prgCurrent";
                this.prgCurrent.Size = new System.Drawing.Size(584, 30);
                this.prgCurrent.TabIndex = 72;
                // 
                // lblCurrentWork
                // 
                this.lblCurrentWork.AutoSize = true;
                this.lblCurrentWork.Location = new System.Drawing.Point(5, 46);
                this.lblCurrentWork.Margin = new System.Windows.Forms.Padding(3);
                this.lblCurrentWork.Name = "lblCurrentWork";
                this.lblCurrentWork.Size = new System.Drawing.Size(0, 14);
                this.lblCurrentWork.TabIndex = 71;
                // 
                // panel4
                // 
                this.panel4.Controls.Add(this.btnOpenFile);
                this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.panel4.Location = new System.Drawing.Point(5, 333);
                this.panel4.Name = "panel4";
                this.panel4.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
                this.panel4.Size = new System.Drawing.Size(584, 40);
                this.panel4.TabIndex = 70;
                // 
                // btnOpenFile
                // 
                this.btnOpenFile.Dock = System.Windows.Forms.DockStyle.Right;
                this.btnOpenFile.Enabled = false;
                this.btnOpenFile.Location = new System.Drawing.Point(484, 10);
                this.btnOpenFile.Name = "btnOpenFile";
                this.btnOpenFile.Size = new System.Drawing.Size(100, 30);
                this.btnOpenFile.TabIndex = 0;
                this.btnOpenFile.Text = "Mở Tập Tin";
                this.btnOpenFile.UseVisualStyleBackColor = true;
                // 
                // saveFileDialog
                // 
                this.saveFileDialog.SupportMultiDottedExtensions = true;
                // 
                // FrmExportDtToFile
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(594, 455);
                this.Controls.Add(this.panel2);
                this.Controls.Add(this.panel1);
                this.Name = "FrmExportDtToFile";
                this.Padding = new System.Windows.Forms.Padding(0);
                this.Text = "Xuất Dữ Liệu Vé Tháng";
                this.panel1.ResumeLayout(false);
                this.panel2.ResumeLayout(false);
                this.panel2.PerformLayout();
                this.panel4.ResumeLayout(false);
                this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.Panel panel1;
            private System.Windows.Forms.Label lblDescription;
            private System.Windows.Forms.Panel panel2;
            private System.Windows.Forms.Panel panel4;
            private System.Windows.Forms.Button btnOpenFile;
            private System.Windows.Forms.Label lblCurrentWork;
            private System.Windows.Forms.SaveFileDialog saveFileDialog;
            private System.Windows.Forms.ProgressBar prgCurrent;
        }
    
}
