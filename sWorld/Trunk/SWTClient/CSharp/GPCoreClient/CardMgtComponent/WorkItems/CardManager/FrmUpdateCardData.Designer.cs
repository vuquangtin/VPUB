namespace CardChipMgtComponent.WorkItems
{
    partial class FrmUpdateCardData
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
            this.lblGuiUpdateCardData = new System.Windows.Forms.Label();
            this.lblUpdateCardData = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cardReaderControl = new CardChipService.Controls.CardReaderControl();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGuiUpdateCardData
            // 
            this.lblGuiUpdateCardData.AutoSize = true;
            this.lblGuiUpdateCardData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuiUpdateCardData.Location = new System.Drawing.Point(10, 36);
            this.lblGuiUpdateCardData.Margin = new System.Windows.Forms.Padding(3);
            this.lblGuiUpdateCardData.Name = "lblGuiUpdateCardData";
            this.lblGuiUpdateCardData.Size = new System.Drawing.Size(468, 14);
            this.lblGuiUpdateCardData.TabIndex = 1;
            this.lblGuiUpdateCardData.Text = "Quét thẻ để kiểm tra và đồng bộ dữ liệu các ứng dụng trên thẻ nếu có sự thay đổi";
            // 
            // lblUpdateCardData
            // 
            this.lblUpdateCardData.AutoSize = true;
            this.lblUpdateCardData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateCardData.Location = new System.Drawing.Point(10, 20);
            this.lblUpdateCardData.Name = "lblUpdateCardData";
            this.lblUpdateCardData.Size = new System.Drawing.Size(168, 14);
            this.lblUpdateCardData.TabIndex = 0;
            this.lblUpdateCardData.Text = "Đồng Bộ Dữ Liệu Trên Thẻ";
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
            this.panel2.Controls.Add(this.lblGuiUpdateCardData);
            this.panel2.Controls.Add(this.lblUpdateCardData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(571, 70);
            this.panel2.TabIndex = 54;
            // 
            // cardReaderControl
            // 
            this.cardReaderControl.AutoSize = true;
            this.cardReaderControl.Location = new System.Drawing.Point(0, 79);
            this.cardReaderControl.MaximumSize = new System.Drawing.Size(570, 330);
            this.cardReaderControl.MinimumSize = new System.Drawing.Size(570, 330);
            this.cardReaderControl.Name = "cardReaderControl";
            this.cardReaderControl.Size = new System.Drawing.Size(570, 330);
            this.cardReaderControl.TabIndex = 56;
            // 
            // FrmUpdateCardData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 422);
            this.Controls.Add(this.cardReaderControl);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmUpdateCardData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đồng Bộ Dữ Liệu Trên Thẻ";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGuiUpdateCardData;
        private System.Windows.Forms.Label lblUpdateCardData;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel2;
        private CardChipService.Controls.CardReaderControl cardReaderControl;

    }
}