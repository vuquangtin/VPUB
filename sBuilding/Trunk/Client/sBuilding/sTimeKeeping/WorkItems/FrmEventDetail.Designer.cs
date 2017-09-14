namespace sTimeKeeping.WorkItems
{
    partial class FrmEventDetail
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
            this.lblEvDetailName = new System.Windows.Forms.Label();
            this.lblEvDetailDateView = new System.Windows.Forms.Label();
            this.lblEvDetailDate = new System.Windows.Forms.Label();
            this.lblEvDetailTimeBegin = new System.Windows.Forms.Label();
            this.lblEvDetailHourKeep = new System.Windows.Forms.Label();
            this.lblEvDetailTimeBeginView = new System.Windows.Forms.Label();
            this.lblEvDetailDescription = new System.Windows.Forms.Label();
            this.lblEvDetailHourKeepView = new System.Windows.Forms.Label();
            this.lblEvDetailDescriptionView = new System.Windows.Forms.Label();
            this.lblEvDetailTimetype = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEvDetailName
            // 
            this.lblEvDetailName.AutoSize = true;
            this.lblEvDetailName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvDetailName.Location = new System.Drawing.Point(24, 17);
            this.lblEvDetailName.Name = "lblEvDetailName";
            this.lblEvDetailName.Size = new System.Drawing.Size(174, 17);
            this.lblEvDetailName.TabIndex = 0;
            this.lblEvDetailName.Text = "Training nhân viên mới";
            // 
            // lblEvDetailDateView
            // 
            this.lblEvDetailDateView.AutoSize = true;
            this.lblEvDetailDateView.Location = new System.Drawing.Point(107, 52);
            this.lblEvDetailDateView.Name = "lblEvDetailDateView";
            this.lblEvDetailDateView.Size = new System.Drawing.Size(61, 13);
            this.lblEvDetailDateView.TabIndex = 1;
            this.lblEvDetailDateView.Text = "2016-12-09";
            // 
            // lblEvDetailDate
            // 
            this.lblEvDetailDate.AutoSize = true;
            this.lblEvDetailDate.Location = new System.Drawing.Point(24, 52);
            this.lblEvDetailDate.Name = "lblEvDetailDate";
            this.lblEvDetailDate.Size = new System.Drawing.Size(35, 13);
            this.lblEvDetailDate.TabIndex = 2;
            this.lblEvDetailDate.Text = "Ngày:";
            // 
            // lblEvDetailTimeBegin
            // 
            this.lblEvDetailTimeBegin.AutoSize = true;
            this.lblEvDetailTimeBegin.Location = new System.Drawing.Point(24, 79);
            this.lblEvDetailTimeBegin.Name = "lblEvDetailTimeBegin";
            this.lblEvDetailTimeBegin.Size = new System.Drawing.Size(66, 13);
            this.lblEvDetailTimeBegin.TabIndex = 3;
            this.lblEvDetailTimeBegin.Text = "Giờ bắt đầu:";
            // 
            // lblEvDetailHourKeep
            // 
            this.lblEvDetailHourKeep.AutoSize = true;
            this.lblEvDetailHourKeep.Location = new System.Drawing.Point(24, 106);
            this.lblEvDetailHourKeep.Name = "lblEvDetailHourKeep";
            this.lblEvDetailHourKeep.Size = new System.Drawing.Size(40, 13);
            this.lblEvDetailHourKeep.TabIndex = 4;
            this.lblEvDetailHourKeep.Text = "Số giờ:";
            // 
            // lblEvDetailTimeBeginView
            // 
            this.lblEvDetailTimeBeginView.AutoSize = true;
            this.lblEvDetailTimeBeginView.Location = new System.Drawing.Point(107, 79);
            this.lblEvDetailTimeBeginView.Name = "lblEvDetailTimeBeginView";
            this.lblEvDetailTimeBeginView.Size = new System.Drawing.Size(34, 13);
            this.lblEvDetailTimeBeginView.TabIndex = 5;
            this.lblEvDetailTimeBeginView.Text = "10:30";
            // 
            // lblEvDetailDescription
            // 
            this.lblEvDetailDescription.AutoSize = true;
            this.lblEvDetailDescription.Location = new System.Drawing.Point(24, 135);
            this.lblEvDetailDescription.Name = "lblEvDetailDescription";
            this.lblEvDetailDescription.Size = new System.Drawing.Size(37, 13);
            this.lblEvDetailDescription.TabIndex = 6;
            this.lblEvDetailDescription.Text = "Mô tả:";
            // 
            // lblEvDetailHourKeepView
            // 
            this.lblEvDetailHourKeepView.AutoSize = true;
            this.lblEvDetailHourKeepView.Location = new System.Drawing.Point(107, 106);
            this.lblEvDetailHourKeepView.Name = "lblEvDetailHourKeepView";
            this.lblEvDetailHourKeepView.Size = new System.Drawing.Size(13, 13);
            this.lblEvDetailHourKeepView.TabIndex = 7;
            this.lblEvDetailHourKeepView.Text = "4";
            // 
            // lblEvDetailDescriptionView
            // 
            this.lblEvDetailDescriptionView.AutoSize = true;
            this.lblEvDetailDescriptionView.Location = new System.Drawing.Point(107, 135);
            this.lblEvDetailDescriptionView.Name = "lblEvDetailDescriptionView";
            this.lblEvDetailDescriptionView.Size = new System.Drawing.Size(156, 13);
            this.lblEvDetailDescriptionView.TabIndex = 8;
            this.lblEvDetailDescriptionView.Text = "Training nhân viên mới tại SWT";
            // 
            // lblEvDetailTimetype
            // 
            this.lblEvDetailTimetype.AutoSize = true;
            this.lblEvDetailTimetype.Location = new System.Drawing.Point(131, 106);
            this.lblEvDetailTimetype.Name = "lblEvDetailTimetype";
            this.lblEvDetailTimetype.Size = new System.Drawing.Size(21, 13);
            this.lblEvDetailTimetype.TabIndex = 9;
            this.lblEvDetailTimetype.Text = "giờ";
            // 
            // FrmEventDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(298, 187);
            this.ControlBox = false;
            this.Controls.Add(this.lblEvDetailTimetype);
            this.Controls.Add(this.lblEvDetailDescriptionView);
            this.Controls.Add(this.lblEvDetailHourKeepView);
            this.Controls.Add(this.lblEvDetailDescription);
            this.Controls.Add(this.lblEvDetailTimeBeginView);
            this.Controls.Add(this.lblEvDetailHourKeep);
            this.Controls.Add(this.lblEvDetailTimeBegin);
            this.Controls.Add(this.lblEvDetailDate);
            this.Controls.Add(this.lblEvDetailDateView);
            this.Controls.Add(this.lblEvDetailName);
            this.Name = "FrmEventDetail";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Detail";
            this.Load += new System.EventHandler(this.FrmEventDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEvDetailName;
        private System.Windows.Forms.Label lblEvDetailDateView;
        private System.Windows.Forms.Label lblEvDetailDate;
        private System.Windows.Forms.Label lblEvDetailTimeBegin;
        private System.Windows.Forms.Label lblEvDetailHourKeep;
        private System.Windows.Forms.Label lblEvDetailTimeBeginView;
        private System.Windows.Forms.Label lblEvDetailDescription;
        private System.Windows.Forms.Label lblEvDetailHourKeepView;
        private System.Windows.Forms.Label lblEvDetailDescriptionView;
        private System.Windows.Forms.Label lblEvDetailTimetype;
    }
}