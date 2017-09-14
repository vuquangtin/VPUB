namespace SystemMgtComponent.WorkItems
{
    partial class TreeOrg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeOrg));
            this.panel4 = new System.Windows.Forms.Panel();
            this.trvOrganizations = new System.Windows.Forms.TreeView();
            this.tsmOrg = new CommonControls.Custom.CommonToolStrip();
            this.btnAddOrg = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateOrg = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveOrg = new System.Windows.Forms.ToolStripButton();
            this.btnReloadOrgs = new System.Windows.Forms.ToolStripButton();
            this.panel4.SuspendLayout();
            this.tsmOrg.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.trvOrganizations);
            this.panel4.Controls.Add(this.tsmOrg);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(6, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(203, 399);
            this.panel4.TabIndex = 60;
            // 
            // trvOrganizations
            // 
            this.trvOrganizations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvOrganizations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvOrganizations.Location = new System.Drawing.Point(0, 25);
            this.trvOrganizations.Name = "trvOrganizations";
            this.trvOrganizations.Size = new System.Drawing.Size(201, 372);
            this.trvOrganizations.TabIndex = 60;
            // 
            // tsmOrg
            // 
            this.tsmOrg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddOrg,
            this.btnUpdateOrg,
            this.btnRemoveOrg,
            this.btnReloadOrgs});
            this.tsmOrg.Location = new System.Drawing.Point(0, 0);
            this.tsmOrg.Name = "tsmOrg";
            this.tsmOrg.Size = new System.Drawing.Size(201, 25);
            this.tsmOrg.TabIndex = 59;
            this.tsmOrg.Text = "tlstripListGroup";
            // 
            // btnAddOrg
            // 
            this.btnAddOrg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddOrg.Enabled = false;
            this.btnAddOrg.Image = ((System.Drawing.Image)(resources.GetObject("btnAddOrg.Image")));
            this.btnAddOrg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddOrg.Name = "btnAddOrg";
            this.btnAddOrg.Size = new System.Drawing.Size(23, 22);
            this.btnAddOrg.Text = "Thêm Tổ Chức Mới...";
            this.btnAddOrg.ToolTipText = "Thêm tổ chức mới";
            // 
            // btnUpdateOrg
            // 
            this.btnUpdateOrg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateOrg.Enabled = false;
            this.btnUpdateOrg.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateOrg.Image")));
            this.btnUpdateOrg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateOrg.Name = "btnUpdateOrg";
            this.btnUpdateOrg.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateOrg.Text = "Cập Nhật...";
            this.btnUpdateOrg.ToolTipText = "Cập nhật thông tin nhóm";
            // 
            // btnRemoveOrg
            // 
            this.btnRemoveOrg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveOrg.Enabled = false;
            this.btnRemoveOrg.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveOrg.Image")));
            this.btnRemoveOrg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveOrg.Name = "btnRemoveOrg";
            this.btnRemoveOrg.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveOrg.Text = "Hủy tổ chức khỏi hệ thống";
            this.btnRemoveOrg.ToolTipText = "Hủy tổ chức khỏi hệ thống";
            // 
            // btnReloadOrgs
            // 
            this.btnReloadOrgs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadOrgs.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadOrgs.Image")));
            this.btnReloadOrgs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadOrgs.Name = "btnReloadOrgs";
            this.btnReloadOrgs.Size = new System.Drawing.Size(23, 22);
            this.btnReloadOrgs.Text = "Tải Dữ Liệu";
            this.btnReloadOrgs.ToolTipText = "Tải danh sách nhóm";
            // 
            // TreeOrg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.panel4);
            this.Name = "TreeOrg";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Size = new System.Drawing.Size(215, 409);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tsmOrg.ResumeLayout(false);
            this.tsmOrg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TreeView trvOrganizations;
        private CommonControls.Custom.CommonToolStrip tsmOrg;
        private System.Windows.Forms.ToolStripButton btnAddOrg;
        private System.Windows.Forms.ToolStripButton btnUpdateOrg;
        private System.Windows.Forms.ToolStripButton btnRemoveOrg;
        private System.Windows.Forms.ToolStripButton btnReloadOrgs;
    }
}
