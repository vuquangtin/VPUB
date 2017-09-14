namespace UserMgtComponent.WorkItems
{
    partial class FrmChangeUserGroup
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cmbGroups = new System.Windows.Forms.ComboBox();
            this.lblChooseNewGroup = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(181, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(75, 141);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 26);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "Xác Nhận...";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.OnButtonConfirmClicked);
            // 
            // cmbGroups
            // 
            this.cmbGroups.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroups.FormattingEnabled = true;
            this.cmbGroups.Location = new System.Drawing.Point(10, 55);
            this.cmbGroups.Name = "cmbGroups";
            this.cmbGroups.Size = new System.Drawing.Size(274, 22);
            this.cmbGroups.TabIndex = 5;
            // 
            // lblChooseNewGroup
            // 
            this.lblChooseNewGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChooseNewGroup.Location = new System.Drawing.Point(10, 5);
            this.lblChooseNewGroup.Name = "lblChooseNewGroup";
            this.lblChooseNewGroup.Size = new System.Drawing.Size(274, 50);
            this.lblChooseNewGroup.TabIndex = 4;
            this.lblChooseNewGroup.Text = "Chọn một nhóm mới trong khung bên dưới rồi nhấn \"Xác Nhận\".";
            // 
            // FrmChangeUserGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 175);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cmbGroups);
            this.Controls.Add(this.lblChooseNewGroup);
            this.Name = "FrmChangeUserGroup";
            this.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Text = "Chọn Nhóm Mới";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ComboBox cmbGroups;
        private System.Windows.Forms.Label lblChooseNewGroup;

    }
}