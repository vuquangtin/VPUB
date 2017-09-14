namespace CardChipMgtComponent.WorkItems
{
    partial class FrmConfirmClearData
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
            this.lblAreSureConfirmClearData = new System.Windows.Forms.Label();
            this.cbxDontAskLater = new System.Windows.Forms.CheckBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblNoteConfirmClearData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAreSureConfirmClearData
            // 
            this.lblAreSureConfirmClearData.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAreSureConfirmClearData.Location = new System.Drawing.Point(5, 4);
            this.lblAreSureConfirmClearData.Name = "lblAreSureConfirmClearData";
            this.lblAreSureConfirmClearData.Size = new System.Drawing.Size(344, 75);
            this.lblAreSureConfirmClearData.TabIndex = 0;
            this.lblAreSureConfirmClearData.Text = "Bạn có chắc muốn xóa dữ liệu trên thẻ này không? Lưu ý là việc này đồng nghĩa với" +
    " việc lượt phát hành thẻ tương ứng (nếu có) sẽ bị hủy.";
            // 
            // cbxDontAskLater
            // 
            this.cbxDontAskLater.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxDontAskLater.Location = new System.Drawing.Point(5, 79);
            this.cbxDontAskLater.Name = "cbxDontAskLater";
            this.cbxDontAskLater.Size = new System.Drawing.Size(344, 20);
            this.cbxDontAskLater.TabIndex = 1;
            this.cbxDontAskLater.Text = "Không cần hỏi ở những lần thao tác sau.";
            this.cbxDontAskLater.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnConfirm.Location = new System.Drawing.Point(140, 142);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 26);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Xác Nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnCancel.Location = new System.Drawing.Point(246, 142);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblNoteConfirmClearData
            // 
            this.lblNoteConfirmClearData.AutoSize = true;
            this.lblNoteConfirmClearData.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNoteConfirmClearData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteConfirmClearData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNoteConfirmClearData.Location = new System.Drawing.Point(5, 99);
            this.lblNoteConfirmClearData.Name = "lblNoteConfirmClearData";
            this.lblNoteConfirmClearData.Size = new System.Drawing.Size(282, 13);
            this.lblNoteConfirmClearData.TabIndex = 4;
            this.lblNoteConfirmClearData.Text = "(Chương trình sẽ tự động hủy lượt phát hành tương ứng)";
            // 
            // FrmConfirmClearData
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(354, 175);
            this.Controls.Add(this.lblNoteConfirmClearData);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cbxDontAskLater);
            this.Controls.Add(this.lblAreSureConfirmClearData);
            this.Name = "FrmConfirmClearData";
            this.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác Nhận Xóa Dữ liệu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAreSureConfirmClearData;
        private System.Windows.Forms.CheckBox cbxDontAskLater;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNoteConfirmClearData;
    }
}