namespace PersoMgtComponent.WorkItems
{
    partial class FrmChooseExpDate
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
            this.lblGuiChooseExpDate = new System.Windows.Forms.Label();
            this.dtpExpDate = new System.Windows.Forms.DateTimePicker();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGuiChooseExpDate
            // 
            this.lblGuiChooseExpDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGuiChooseExpDate.Location = new System.Drawing.Point(10, 5);
            this.lblGuiChooseExpDate.Name = "lblGuiChooseExpDate";
            this.lblGuiChooseExpDate.Size = new System.Drawing.Size(274, 75);
            this.lblGuiChooseExpDate.TabIndex = 0;
            this.lblGuiChooseExpDate.Text = "Ngày hết hạn phải trễ hơn ngày hiện tại. Thời điểm hết hạn của lượt phát hành sẽ " +
                "là 0 giờ của ngày mà bạn chọn.";
            // 
            // dtpExpDate
            // 
            this.dtpExpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpExpDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpDate.Location = new System.Drawing.Point(10, 80);
            this.dtpExpDate.Name = "dtpExpDate";
            this.dtpExpDate.Size = new System.Drawing.Size(274, 22);
            this.dtpExpDate.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnConfirm.Location = new System.Drawing.Point(75, 141);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 26);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Xác Nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(181, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmChooseExpDate
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(294, 175);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.dtpExpDate);
            this.Controls.Add(this.lblGuiChooseExpDate);
            this.Name = "FrmChooseExpDate";
            this.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Text = "Chọn Ngày Hết Hạn";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGuiChooseExpDate;
        private System.Windows.Forms.DateTimePicker dtpExpDate;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}