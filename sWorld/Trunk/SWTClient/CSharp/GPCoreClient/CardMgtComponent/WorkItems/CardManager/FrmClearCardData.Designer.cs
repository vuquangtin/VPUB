namespace CardChipMgtComponent.WorkItems
{
    partial class FrmClearCardData
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblGuiClearCardData = new System.Windows.Forms.Label();
            this.lblClearCardData = new System.Windows.Forms.Label();
            this.cardReaderControl = new CardChipService.Controls.CardReaderControl();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblGuiClearCardData);
            this.panel2.Controls.Add(this.lblClearCardData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(569, 81);
            this.panel2.TabIndex = 56;
            // 
            // lblGuiClearCardData
            // 
            this.lblGuiClearCardData.AutoSize = true;
            this.lblGuiClearCardData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuiClearCardData.Location = new System.Drawing.Point(14, 42);
            this.lblGuiClearCardData.Margin = new System.Windows.Forms.Padding(3);
            this.lblGuiClearCardData.Name = "lblGuiClearCardData";
            this.lblGuiClearCardData.Size = new System.Drawing.Size(461, 14);
            this.lblGuiClearCardData.TabIndex = 1;
            this.lblGuiClearCardData.Text = "Quét thẻ để xóa dữ liệu của tất cả ứng dụng trên thẻ và phục hồi khóa mặc định.";
            // 
            // lblClearCardData
            // 
            this.lblClearCardData.AutoSize = true;
            this.lblClearCardData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearCardData.Location = new System.Drawing.Point(14, 24);
            this.lblClearCardData.Name = "lblClearCardData";
            this.lblClearCardData.Size = new System.Drawing.Size(138, 14);
            this.lblClearCardData.TabIndex = 0;
            this.lblClearCardData.Text = "Xóa Dữ Liệu Trên Thẻ";
            // 
            // cardReaderControl
            // 
            this.cardReaderControl.Location = new System.Drawing.Point(0, 88);
            this.cardReaderControl.MaximumSize = new System.Drawing.Size(570, 330);
            this.cardReaderControl.MinimumSize = new System.Drawing.Size(570, 330);
            this.cardReaderControl.Name = "cardReaderControl";
            this.cardReaderControl.Size = new System.Drawing.Size(570, 330);
            this.cardReaderControl.TabIndex = 57;
            // 
            // FrmClearCardData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 422);
            this.Controls.Add(this.cardReaderControl);
            this.Controls.Add(this.panel2);
            this.Name = "FrmClearCardData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmClearCardData2";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblGuiClearCardData;
        private System.Windows.Forms.Label lblClearCardData;
        private CardChipService.Controls.CardReaderControl cardReaderControl;
    }
}