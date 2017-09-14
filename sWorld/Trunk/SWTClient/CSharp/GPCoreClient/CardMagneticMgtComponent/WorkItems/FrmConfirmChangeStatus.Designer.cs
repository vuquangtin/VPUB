namespace CardMagneticMgtComponent.WorkItems
{
    partial class FrmConfirmChangeStatus
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
            this.lblConfimMessage = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblReasonSuggestion = new System.Windows.Forms.Label();
            this.tbxReason = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblConfimMessage
            // 
            this.lblConfimMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConfimMessage.Location = new System.Drawing.Point(10, 5);
            this.lblConfimMessage.Name = "lblConfimMessage";
            this.lblConfimMessage.Size = new System.Drawing.Size(334, 35);
            this.lblConfimMessage.TabIndex = 1;
            this.lblConfimMessage.Text = "[Confirmation Message]";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnCancel.Location = new System.Drawing.Point(241, 181);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnConfirm.Location = new System.Drawing.Point(135, 181);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 26);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Xác Nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // lblReasonSuggestion
            // 
            this.lblReasonSuggestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReasonSuggestion.Location = new System.Drawing.Point(10, 40);
            this.lblReasonSuggestion.Name = "lblReasonSuggestion";
            this.lblReasonSuggestion.Size = new System.Drawing.Size(334, 40);
            this.lblReasonSuggestion.TabIndex = 6;
            this.lblReasonSuggestion.Text = "Nhập lý do (việc này nhằm giúp cho bạn dễ quản lý thông tin sau này):";
            // 
            // tbxReason
            // 
            this.tbxReason.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbxReason.Location = new System.Drawing.Point(10, 80);
            this.tbxReason.Multiline = true;
            this.tbxReason.Name = "tbxReason";
            this.tbxReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxReason.Size = new System.Drawing.Size(334, 75);
            this.tbxReason.TabIndex = 7;
            // 
            // FrmConfirmChangeStatus
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(354, 215);
            this.Controls.Add(this.tbxReason);
            this.Controls.Add(this.lblReasonSuggestion);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblConfimMessage);
            this.Name = "FrmConfirmChangeStatus";
            this.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Text = "Xác Nhận";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConfimMessage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblReasonSuggestion;
        private System.Windows.Forms.TextBox tbxReason;
    }
}