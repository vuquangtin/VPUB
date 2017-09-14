namespace SystemMgtComponent.WorkItems
{
    partial class frmAddOrEditContact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddOrEditContact));
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbNote = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.line2 = new CommonControls.Custom.Line();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvContactList = new CommonControls.Custom.CommonDataGridView();
            this.colContactName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plAddOrEdit = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbxPhone = new CommonControls.Custom.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxContactName = new CommonControls.Custom.CommonTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tsmOrg = new CommonControls.Custom.CommonToolStrip();
            this.btnAddContact = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpdateContact = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveContact = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReloadContact = new System.Windows.Forms.ToolStripButton();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactList)).BeginInit();
            this.plAddOrEdit.SuspendLayout();
            this.tsmOrg.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lbNote);
            this.panel9.Controls.Add(this.lbTitle);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(518, 75);
            this.panel9.TabIndex = 62;
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNote.Location = new System.Drawing.Point(12, 39);
            this.lbNote.Margin = new System.Windows.Forms.Padding(3);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(219, 14);
            this.lbNote.TabIndex = 1;
            this.lbNote.Text = "Thêm người liên hệ mới vào hệ thống.";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(12, 22);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(155, 14);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Thêm Người Liên Hệ Mới";
            this.lbTitle.Click += new System.EventHandler(this.lbTitle_Click);
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 75);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(518, 1);
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
            this.line2.Size = new System.Drawing.Size(518, 1);
            this.line2.TabIndex = 66;
            this.line2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dgvContactList);
            this.panel2.Controls.Add(this.plAddOrEdit);
            this.panel2.Controls.Add(this.tsmOrg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(518, 320);
            this.panel2.TabIndex = 69;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 272);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(518, 48);
            this.panel3.TabIndex = 71;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Location = new System.Drawing.Point(410, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgvContactList
            // 
            this.dgvContactList.AllowUserToAddRows = false;
            this.dgvContactList.AllowUserToDeleteRows = false;
            this.dgvContactList.AllowUserToOrderColumns = true;
            this.dgvContactList.AllowUserToResizeRows = false;
            this.dgvContactList.BackgroundColor = System.Drawing.Color.White;
            this.dgvContactList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvContactList.ColumnHeadersHeight = 26;
            this.dgvContactList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colContactName,
            this.colPhone,
            this.colBlank});
            this.dgvContactList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContactList.Location = new System.Drawing.Point(0, 60);
            this.dgvContactList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvContactList.Name = "dgvContactList";
            this.dgvContactList.ReadOnly = true;
            this.dgvContactList.RowHeadersVisible = false;
            this.dgvContactList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContactList.Size = new System.Drawing.Size(518, 260);
            this.dgvContactList.TabIndex = 69;
            // 
            // colContactName
            // 
            this.colContactName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colContactName.DataPropertyName = "ContactName";
            this.colContactName.HeaderText = "Tên Người Liên Hệ";
            this.colContactName.Name = "colContactName";
            this.colContactName.ReadOnly = true;
            this.colContactName.Width = 138;
            // 
            // colPhone
            // 
            this.colPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPhone.DataPropertyName = "Phone";
            this.colPhone.HeaderText = "Số ĐTDD";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
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
            this.plAddOrEdit.Controls.Add(this.tbxPhone);
            this.plAddOrEdit.Controls.Add(this.label1);
            this.plAddOrEdit.Controls.Add(this.tbxContactName);
            this.plAddOrEdit.Controls.Add(this.label8);
            this.plAddOrEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.plAddOrEdit.Location = new System.Drawing.Point(0, 25);
            this.plAddOrEdit.Name = "plAddOrEdit";
            this.plAddOrEdit.Padding = new System.Windows.Forms.Padding(5);
            this.plAddOrEdit.Size = new System.Drawing.Size(518, 35);
            this.plAddOrEdit.TabIndex = 70;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.Location = new System.Drawing.Point(427, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 84;
            this.btnSave.Text = "Lưu lại";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(421, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(6, 25);
            this.panel4.TabIndex = 83;
            // 
            // tbxPhone
            // 
            this.tbxPhone.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbxPhone.Location = new System.Drawing.Point(304, 5);
            this.tbxPhone.Name = "tbxPhone";
            this.tbxPhone.Size = new System.Drawing.Size(117, 22);
            this.tbxPhone.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(231, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 81;
            this.label1.Text = "Số ĐTDD:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxContactName
            // 
            this.tbxContactName.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbxContactName.Location = new System.Drawing.Point(95, 5);
            this.tbxContactName.Name = "tbxContactName";
            this.tbxContactName.Size = new System.Drawing.Size(136, 22);
            this.tbxContactName.TabIndex = 80;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(5, 5);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 25);
            this.label8.TabIndex = 79;
            this.label8.Text = "Người liên hệ:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsmOrg
            // 
            this.tsmOrg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddContact,
            this.toolStripSeparator4,
            this.btnUpdateContact,
            this.btnRemoveContact,
            this.toolStripSeparator10,
            this.btnReloadContact});
            this.tsmOrg.Location = new System.Drawing.Point(0, 0);
            this.tsmOrg.Name = "tsmOrg";
            this.tsmOrg.Size = new System.Drawing.Size(518, 25);
            this.tsmOrg.TabIndex = 62;
            this.tsmOrg.Text = "tlstripListGroup";
            // 
            // btnAddContact
            // 
            this.btnAddContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddContact.Image = ((System.Drawing.Image)(resources.GetObject("btnAddContact.Image")));
            this.btnAddContact.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(23, 22);
            this.btnAddContact.Text = "Thêm Tổ Chức Mới...";
            this.btnAddContact.ToolTipText = "Thêm người liên hệ mới";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUpdateContact
            // 
            this.btnUpdateContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateContact.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateContact.Image")));
            this.btnUpdateContact.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateContact.Name = "btnUpdateContact";
            this.btnUpdateContact.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateContact.Text = "Cập Nhật...";
            this.btnUpdateContact.ToolTipText = "Cập nhật thông tin người liên hệ";
            this.btnUpdateContact.Visible = false;
            // 
            // btnRemoveContact
            // 
            this.btnRemoveContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveContact.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveContact.Image")));
            this.btnRemoveContact.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveContact.Name = "btnRemoveContact";
            this.btnRemoveContact.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveContact.Text = "Hủy tổ chức khỏi hệ thống";
            this.btnRemoveContact.ToolTipText = "Hủy người liên hệ khỏi hệ thống";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // btnReloadContact
            // 
            this.btnReloadContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReloadContact.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadContact.Image")));
            this.btnReloadContact.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadContact.Name = "btnReloadContact";
            this.btnReloadContact.Size = new System.Drawing.Size(23, 22);
            this.btnReloadContact.Text = "Tải Dữ Liệu";
            this.btnReloadContact.ToolTipText = "Tải danh sách người liên hệ";
            // 
            // frmAddOrEditContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 397);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.Name = "frmAddOrEditContact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Người Liên Hệ Khác";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactList)).EndInit();
            this.plAddOrEdit.ResumeLayout(false);
            this.plAddOrEdit.PerformLayout();
            this.tsmOrg.ResumeLayout(false);
            this.tsmOrg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Label lbTitle;
        private CommonControls.Custom.Line line1;
        private CommonControls.Custom.Line line2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private CommonControls.Custom.CommonDataGridView dgvContactList;
        private System.Windows.Forms.Panel plAddOrEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel4;
        private CommonControls.Custom.CommonTextBox tbxPhone;
        private System.Windows.Forms.Label label1;
        private CommonControls.Custom.CommonTextBox tbxContactName;
        private System.Windows.Forms.Label label8;
        private CommonControls.Custom.CommonToolStrip tsmOrg;
        private System.Windows.Forms.ToolStripButton btnAddContact;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnUpdateContact;
        private System.Windows.Forms.ToolStripButton btnRemoveContact;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnReloadContact;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContactName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
    }
}