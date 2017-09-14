namespace SystemMgtComponent.WorkItems
{
    partial class frmAddOrEditGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddOrEditGroup));
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbNote = new System.Windows.Forms.Label();
            this.lblTitle_frmAddOrEditGroup = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.line2 = new CommonControls.Custom.Line();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvGroupList = new CommonControls.Custom.CommonDataGridView();
            this.colGroupCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plAddOrEdit = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbxGroupName = new CommonControls.Custom.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxGroupCode = new CommonControls.Custom.CommonTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tsmOrg = new CommonControls.Custom.CommonToolStrip();
            this.btnAddGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpdateGroup = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReloadOrgs = new System.Windows.Forms.ToolStripButton();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupList)).BeginInit();
            this.plAddOrEdit.SuspendLayout();
            this.tsmOrg.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lbNote);
            this.panel9.Controls.Add(this.lblTitle_frmAddOrEditGroup);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(482, 75);
            this.panel9.TabIndex = 62;
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNote.Location = new System.Drawing.Point(12, 39);
            this.lbNote.Margin = new System.Windows.Forms.Padding(3);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(205, 14);
            this.lbNote.TabIndex = 1;
            this.lbNote.Text = "Thêm một nhóm mới vào hệ thống.";
            // 
            // lblTitle_frmAddOrEditGroup
            // 
            this.lblTitle_frmAddOrEditGroup.AutoSize = true;
            this.lblTitle_frmAddOrEditGroup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_frmAddOrEditGroup.Location = new System.Drawing.Point(12, 22);
            this.lblTitle_frmAddOrEditGroup.Name = "lblTitle_frmAddOrEditGroup";
            this.lblTitle_frmAddOrEditGroup.Size = new System.Drawing.Size(105, 14);
            this.lblTitle_frmAddOrEditGroup.TabIndex = 0;
            this.lblTitle_frmAddOrEditGroup.Text = "Thêm Nhóm Mới";
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 75);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(482, 1);
            this.line1.TabIndex = 64;
            this.line1.TabStop = false;
            // 
            // line2
            // 
            this.line2.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line2.Dock = System.Windows.Forms.DockStyle.Top;
            this.line2.Location = new System.Drawing.Point(0, 76);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(482, 1);
            this.line2.TabIndex = 66;
            this.line2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dgvGroupList);
            this.panel2.Controls.Add(this.plAddOrEdit);
            this.panel2.Controls.Add(this.tsmOrg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(482, 320);
            this.panel2.TabIndex = 69;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 272);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(482, 48);
            this.panel3.TabIndex = 71;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Location = new System.Drawing.Point(371, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgvGroupList
            // 
            this.dgvGroupList.AllowUserToAddRows = false;
            this.dgvGroupList.AllowUserToDeleteRows = false;
            this.dgvGroupList.AllowUserToOrderColumns = true;
            this.dgvGroupList.AllowUserToResizeRows = false;
            this.dgvGroupList.BackgroundColor = System.Drawing.Color.White;
            this.dgvGroupList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGroupList.ColumnHeadersHeight = 26;
            this.dgvGroupList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGroupCode,
            this.colGroupName,
            this.colBlank});
            this.dgvGroupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroupList.Location = new System.Drawing.Point(0, 60);
            this.dgvGroupList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvGroupList.Name = "dgvGroupList";
            this.dgvGroupList.ReadOnly = true;
            this.dgvGroupList.RowHeadersVisible = false;
            this.dgvGroupList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroupList.Size = new System.Drawing.Size(482, 260);
            this.dgvGroupList.TabIndex = 69;
            // 
            // colGroupCode
            // 
            this.colGroupCode.DataPropertyName = "GroupCode";
            this.colGroupCode.HeaderText = "Mã Nhóm";
            this.colGroupCode.Name = "colGroupCode";
            this.colGroupCode.ReadOnly = true;
            // 
            // colGroupName
            // 
            this.colGroupName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGroupName.DataPropertyName = "GroupName";
            this.colGroupName.HeaderText = "Tên Nhóm";
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.ReadOnly = true;
            // 
            // colBlank
            // 
            this.colBlank.DataPropertyName = "Blank";
            this.colBlank.HeaderText = "";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            this.colBlank.Width = 20;
            // 
            // plAddOrEdit
            // 
            this.plAddOrEdit.Controls.Add(this.btnSave);
            this.plAddOrEdit.Controls.Add(this.panel4);
            this.plAddOrEdit.Controls.Add(this.tbxGroupName);
            this.plAddOrEdit.Controls.Add(this.label1);
            this.plAddOrEdit.Controls.Add(this.tbxGroupCode);
            this.plAddOrEdit.Controls.Add(this.label8);
            this.plAddOrEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.plAddOrEdit.Location = new System.Drawing.Point(0, 25);
            this.plAddOrEdit.Name = "plAddOrEdit";
            this.plAddOrEdit.Padding = new System.Windows.Forms.Padding(5);
            this.plAddOrEdit.Size = new System.Drawing.Size(482, 35);
            this.plAddOrEdit.TabIndex = 70;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.Location = new System.Drawing.Point(391, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 84;
            this.btnSave.Text = "Lưu lại";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(385, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(6, 25);
            this.panel4.TabIndex = 83;
            // 
            // tbxGroupName
            // 
            this.tbxGroupName.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbxGroupName.Location = new System.Drawing.Point(268, 5);
            this.tbxGroupName.Name = "tbxGroupName";
            this.tbxGroupName.Size = new System.Drawing.Size(117, 22);
            this.tbxGroupName.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(195, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 81;
            this.label1.Text = "Tên nhóm:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxGroupCode
            // 
            this.tbxGroupCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbxGroupCode.Location = new System.Drawing.Point(78, 5);
            this.tbxGroupCode.Name = "tbxGroupCode";
            this.tbxGroupCode.Size = new System.Drawing.Size(117, 22);
            this.tbxGroupCode.TabIndex = 80;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(5, 5);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 25);
            this.label8.TabIndex = 79;
            this.label8.Text = "Mã nhóm:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsmOrg
            // 
            this.tsmOrg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddGroup,
            this.toolStripSeparator4,
            this.btnUpdateGroup,
            this.btnRemoveGroup,
            this.toolStripSeparator10,
            this.btnReloadOrgs});
            this.tsmOrg.Location = new System.Drawing.Point(0, 0);
            this.tsmOrg.Name = "tsmOrg";
            this.tsmOrg.Size = new System.Drawing.Size(482, 25);
            this.tsmOrg.TabIndex = 62;
            this.tsmOrg.Text = "tlstripListGroup";
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGroup.Image")));
            this.btnAddGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(23, 22);
            this.btnAddGroup.Text = "Thêm Tổ Chức Mới...";
            this.btnAddGroup.ToolTipText = "Thêm tổ chức mới";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUpdateGroup
            // 
            this.btnUpdateGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateGroup.Image")));
            this.btnUpdateGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateGroup.Name = "btnUpdateGroup";
            this.btnUpdateGroup.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateGroup.Text = "Cập Nhật...";
            this.btnUpdateGroup.ToolTipText = "Cập nhật thông tin nhóm";
            this.btnUpdateGroup.Visible = false;
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveGroup.Image")));
            this.btnRemoveGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveGroup.Text = "Hủy tổ chức khỏi hệ thống";
            this.btnRemoveGroup.ToolTipText = "Hủy tổ chức khỏi hệ thống";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
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
            // frmAddOrEditGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 397);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.Name = "frmAddOrEditGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Nhóm Tổ Chức Con";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupList)).EndInit();
            this.plAddOrEdit.ResumeLayout(false);
            this.plAddOrEdit.PerformLayout();
            this.tsmOrg.ResumeLayout(false);
            this.tsmOrg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Label lblTitle_frmAddOrEditGroup;
        private CommonControls.Custom.Line line1;
        private CommonControls.Custom.Line line2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private CommonControls.Custom.CommonDataGridView dgvGroupList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
        private System.Windows.Forms.Panel plAddOrEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel4;
        private CommonControls.Custom.CommonTextBox tbxGroupName;
        private System.Windows.Forms.Label label1;
        private CommonControls.Custom.CommonTextBox tbxGroupCode;
        private System.Windows.Forms.Label label8;
        private CommonControls.Custom.CommonToolStrip tsmOrg;
        private System.Windows.Forms.ToolStripButton btnAddGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnUpdateGroup;
        private System.Windows.Forms.ToolStripButton btnRemoveGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnReloadOrgs;
    }
}