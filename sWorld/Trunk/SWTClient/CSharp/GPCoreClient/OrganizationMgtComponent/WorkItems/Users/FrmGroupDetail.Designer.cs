namespace SystemMgtComponent.WorkItems.Users
{
    partial class FrmGroupDetail
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.trvFunctions = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFunctionDescription = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCheckFunctionforUser = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxGroupDescription = new CommonControls.Custom.CommonTextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.tbxGroupName = new CommonControls.Custom.CommonTextBox();
            this.lblNameGroup = new System.Windows.Forms.Label();
            this.lblImportInfobaseGroup = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(159, 45);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 30);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Xác Nhận...";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.OnButtonConfirmClicked);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(371, 45);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnButtonCancelClicked);
            // 
            // trvFunctions
            // 
            this.trvFunctions.CheckBoxes = true;
            this.trvFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvFunctions.Location = new System.Drawing.Point(0, 195);
            this.trvFunctions.Name = "trvFunctions";
            this.trvFunctions.Size = new System.Drawing.Size(474, 179);
            this.trvFunctions.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblFunctionDescription);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnConfirm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 374);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel2.Size = new System.Drawing.Size(474, 78);
            this.panel2.TabIndex = 9;
            // 
            // lblFunctionDescription
            // 
            this.lblFunctionDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFunctionDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFunctionDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFunctionDescription.Location = new System.Drawing.Point(0, 5);
            this.lblFunctionDescription.Name = "lblFunctionDescription";
            this.lblFunctionDescription.Size = new System.Drawing.Size(474, 30);
            this.lblFunctionDescription.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(265, 45);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.OnButtonRefreshClicked);
            // 
            // lblCheckFunctionforUser
            // 
            this.lblCheckFunctionforUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCheckFunctionforUser.Location = new System.Drawing.Point(0, 155);
            this.lblCheckFunctionforUser.Margin = new System.Windows.Forms.Padding(3, 25, 3, 3);
            this.lblCheckFunctionforUser.Name = "lblCheckFunctionforUser";
            this.lblCheckFunctionforUser.Size = new System.Drawing.Size(474, 40);
            this.lblCheckFunctionforUser.TabIndex = 7;
            this.lblCheckFunctionforUser.Text = "Đánh dấu chọn vào các chức năng mà bạn cho phép các tài khoản trong nhóm này được" +
    " quyền thực hiện. Việc cấp quyền cần được xem xét cẩn thận.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbxGroupDescription);
            this.panel1.Controls.Add(this.lblNotes);
            this.panel1.Controls.Add(this.tbxGroupName);
            this.panel1.Controls.Add(this.lblNameGroup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 120);
            this.panel1.TabIndex = 6;
            // 
            // tbxGroupDescription
            // 
            this.tbxGroupDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxGroupDescription.Location = new System.Drawing.Point(80, 36);
            this.tbxGroupDescription.Multiline = true;
            this.tbxGroupDescription.Name = "tbxGroupDescription";
            this.tbxGroupDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxGroupDescription.Size = new System.Drawing.Size(389, 75);
            this.tbxGroupDescription.TabIndex = 4;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(3, 39);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(3);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(66, 16);
            this.lblNotes.TabIndex = 3;
            this.lblNotes.Text = "Chú thích:";
            // 
            // tbxGroupName
            // 
            this.tbxGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxGroupName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbxGroupName.Location = new System.Drawing.Point(80, 7);
            this.tbxGroupName.MaxLength = 255;
            this.tbxGroupName.Name = "tbxGroupName";
            this.tbxGroupName.Size = new System.Drawing.Size(389, 23);
            this.tbxGroupName.TabIndex = 2;
            // 
            // lblNameGroup
            // 
            this.lblNameGroup.AutoSize = true;
            this.lblNameGroup.Location = new System.Drawing.Point(3, 10);
            this.lblNameGroup.Margin = new System.Windows.Forms.Padding(3);
            this.lblNameGroup.Name = "lblNameGroup";
            this.lblNameGroup.Size = new System.Drawing.Size(71, 16);
            this.lblNameGroup.TabIndex = 1;
            this.lblNameGroup.Text = "Tên nhóm:";
            // 
            // lblImportInfobaseGroup
            // 
            this.lblImportInfobaseGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblImportInfobaseGroup.Location = new System.Drawing.Point(0, 0);
            this.lblImportInfobaseGroup.Margin = new System.Windows.Forms.Padding(3);
            this.lblImportInfobaseGroup.Name = "lblImportInfobaseGroup";
            this.lblImportInfobaseGroup.Size = new System.Drawing.Size(474, 35);
            this.lblImportInfobaseGroup.TabIndex = 0;
            this.lblImportInfobaseGroup.Text = "Nhập các thông tin cơ bản của nhóm. Lưu ý: tên nhóm có chiều dài tối đa 255 ký tự" +
    " và không được đặt trùng với các nhóm hiện có.";
            // 
            // FrmGroupDetail
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(474, 452);
            this.Controls.Add(this.trvFunctions);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblCheckFunctionforUser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblImportInfobaseGroup);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmGroupDetail";
            this.Text = "Nhóm tài khoản";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblImportInfobaseGroup;
        private System.Windows.Forms.Label lblNameGroup;
        private CommonControls.Custom.CommonTextBox tbxGroupName;
        private System.Windows.Forms.Label lblNotes;
        private CommonControls.Custom.CommonTextBox tbxGroupDescription;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCheckFunctionforUser;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView trvFunctions;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblFunctionDescription;
    }
}