namespace CardChipMgtComponent.WorkItems
{
    partial class FrmReadCardData
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
            this.lblGuiReadCardData = new System.Windows.Forms.Label();
            this.lblReadCardData = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cardReaderControl = new CardChipService.Controls.CardReaderControl();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGuiReadCardData
            // 
            this.lblGuiReadCardData.AutoSize = true;
            this.lblGuiReadCardData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuiReadCardData.Location = new System.Drawing.Point(10, 36);
            this.lblGuiReadCardData.Margin = new System.Windows.Forms.Padding(3);
            this.lblGuiReadCardData.Name = "lblGuiReadCardData";
            this.lblGuiReadCardData.Size = new System.Drawing.Size(281, 14);
            this.lblGuiReadCardData.TabIndex = 1;
            this.lblGuiReadCardData.Text = "Quét thẻ để đọc dữ liệu thành viên lưu trong thẻ";
            // 
            // lblReadCardData
            // 
            this.lblReadCardData.AutoSize = true;
            this.lblReadCardData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReadCardData.Location = new System.Drawing.Point(10, 20);
            this.lblReadCardData.Name = "lblReadCardData";
            this.lblReadCardData.Size = new System.Drawing.Size(138, 14);
            this.lblReadCardData.TabIndex = 0;
            this.lblReadCardData.Text = "Đọc Dữ Liệu Trên Thẻ";
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Line3DStyle = CommonControls.Custom.Line3DStyle.Inset;
            this.line1.Location = new System.Drawing.Point(0, 70);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(571, 2);
            this.line1.TabIndex = 55;
            this.line1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblGuiReadCardData);
            this.panel2.Controls.Add(this.lblReadCardData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(571, 70);
            this.panel2.TabIndex = 54;
            // 
            // cardReaderControl
            // 
            this.cardReaderControl.AutoSize = true;
            this.cardReaderControl.Location = new System.Drawing.Point(0, 77);
            this.cardReaderControl.MaximumSize = new System.Drawing.Size(570, 330);
            this.cardReaderControl.MinimumSize = new System.Drawing.Size(570, 330);
            this.cardReaderControl.Name = "cardReaderControl";
            this.cardReaderControl.Size = new System.Drawing.Size(570, 330);
            this.cardReaderControl.TabIndex = 56;
            // 
            // FrmReadCardData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 422);
            this.Controls.Add(this.cardReaderControl);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmReadCardData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đọc Dữ Liệu Trên Thẻ";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGuiReadCardData;
        private System.Windows.Forms.Label lblReadCardData;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel2;
        private CardChipService.Controls.CardReaderControl cardReaderControl;

    }
}