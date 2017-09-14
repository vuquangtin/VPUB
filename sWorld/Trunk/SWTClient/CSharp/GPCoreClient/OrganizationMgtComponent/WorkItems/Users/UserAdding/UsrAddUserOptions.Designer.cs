namespace SystemMgtComponent.WorkItems.UserAdding
{
    partial class UsrAddUserOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrAddUserOptions));
            this.btnUseExisting = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbl1_UsrAddUserOptions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUseExisting
            // 
            this.btnUseExisting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUseExisting.Image = ((System.Drawing.Image)(resources.GetObject("btnUseExisting.Image")));
            this.btnUseExisting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUseExisting.Location = new System.Drawing.Point(10, 165);
            this.btnUseExisting.Name = "btnUseExisting";
            this.btnUseExisting.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnUseExisting.Size = new System.Drawing.Size(574, 75);
            this.btnUseExisting.TabIndex = 17;
            this.btnUseExisting.Text = "Tạo tài khoản đăng nhập cho một thành viên của nhà trường";
            this.btnUseExisting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUseExisting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUseExisting.UseVisualStyleBackColor = true;
            this.btnUseExisting.Click += new System.EventHandler(this.OnButtonUseExistingClicked);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 155);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 10);
            this.panel1.TabIndex = 16;
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreateNew.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateNew.Image")));
            this.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNew.Location = new System.Drawing.Point(10, 80);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCreateNew.Size = new System.Drawing.Size(574, 75);
            this.btnCreateNew.TabIndex = 15;
            this.btnCreateNew.Text = "Tạo tài khoản đăng nhập cho cá nhân không phải là thành viên";
            this.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateNew.UseVisualStyleBackColor = true;
            this.btnCreateNew.Click += new System.EventHandler(this.OnButtonCreateNewClicked);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(481, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnButtonCancelClicked);
            // 
            // lbl1_UsrAddUserOptions
            // 
            this.lbl1_UsrAddUserOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl1_UsrAddUserOptions.Location = new System.Drawing.Point(10, 5);
            this.lbl1_UsrAddUserOptions.Name = "lbl1_UsrAddUserOptions";
            this.lbl1_UsrAddUserOptions.Size = new System.Drawing.Size(574, 75);
            this.lbl1_UsrAddUserOptions.TabIndex = 13;
            // 
            // UsrAddUserOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUseExisting);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCreateNew);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbl1_UsrAddUserOptions);
            this.Name = "UsrAddUserOptions";
            this.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Size = new System.Drawing.Size(594, 378);
            this.Load += new System.EventHandler(this.UsrAddUserOptions_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUseExisting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbl1_UsrAddUserOptions;
    }
}
