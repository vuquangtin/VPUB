using System.Windows.Forms;
using System.Drawing;

namespace MainForm {
    partial class MainForm
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUpdateInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.sttLabelUseName = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnLocalization = new System.Windows.Forms.Button();
            this.mainWorkspace = new Microsoft.Practices.CompositeUI.WinForms.TabWorkspace();
            this.paletteWorkspace = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.menuBar.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSystem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Padding = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.menuBar.Size = new System.Drawing.Size(792, 24);
            this.menuBar.TabIndex = 3;
            // 
            // mnuSystem
            // 
            this.mnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOptions,
            this.toolStripSeparator1,
            this.mnuUpdateInfo,
            this.mnuChangePassword,
            this.toolStripSeparator4,
            this.mnuLogout,
            this.mnuExit});
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Size = new System.Drawing.Size(75, 20);
            this.mnuSystem.Text = "Hệ Thống";
            // 
            // mnuOptions
            // 
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(242, 22);
            this.mnuOptions.Text = "Cấu Hình Hệ Thống...";
            this.mnuOptions.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(239, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // mnuUpdateInfo
            // 
            this.mnuUpdateInfo.Name = "mnuUpdateInfo";
            this.mnuUpdateInfo.Size = new System.Drawing.Size(242, 22);
            this.mnuUpdateInfo.Text = "Cập nhật thông tin cá nhân...";
            this.mnuUpdateInfo.Visible = false;
            // 
            // mnuChangePassword
            // 
            this.mnuChangePassword.Name = "mnuChangePassword";
            this.mnuChangePassword.Size = new System.Drawing.Size(242, 22);
            this.mnuChangePassword.Text = "Đổi Mật Khẩu...";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(239, 6);
            // 
            // mnuLogout
            // 
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.mnuLogout.Size = new System.Drawing.Size(242, 22);
            this.mnuLogout.Text = "Đăng Xuất...";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeyDisplayString = "";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuExit.Size = new System.Drawing.Size(242, 22);
            this.mnuExit.Text = "Thoát...";
            // 
            // statusBar
            // 
            this.statusBar.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sttLabelUseName});
            this.statusBar.Location = new System.Drawing.Point(0, 551);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(792, 22);
            this.statusBar.TabIndex = 4;
            // 
            // sttLabelUseName
            // 
            this.sttLabelUseName.Name = "sttLabelUseName";
            this.sttLabelUseName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sttLabelUseName.Size = new System.Drawing.Size(101, 17);
            this.sttLabelUseName.Text = "Xin chào: admin";
            // 
            // btnLocalization
            // 
            this.btnLocalization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocalization.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLocalization.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLocalization.Location = new System.Drawing.Point(750, 0);
            this.btnLocalization.Name = "btnLocalization";
            this.btnLocalization.Size = new System.Drawing.Size(42, 23);
            this.btnLocalization.TabIndex = 6;
            this.btnLocalization.Text = "VI";
            this.btnLocalization.UseVisualStyleBackColor = false;
            this.btnLocalization.Visible = false;
            // 
            // mainWorkspace
            // 
            this.mainWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWorkspace.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.mainWorkspace.Location = new System.Drawing.Point(0, 49);
            this.mainWorkspace.Name = "mainWorkspace";
            this.mainWorkspace.SelectedIndex = 0;
            this.mainWorkspace.Size = new System.Drawing.Size(792, 502);
            this.mainWorkspace.SupportCloseButton = true;
            this.mainWorkspace.TabIndex = 5;
            this.mainWorkspace.SmartPartClosing += new System.EventHandler<Microsoft.Practices.CompositeUI.SmartParts.WorkspaceCancelEventArgs>(this.mainWorkspace_SmartPartClosing);
            this.mainWorkspace.SmartPartActivated += new System.EventHandler<Microsoft.Practices.CompositeUI.SmartParts.WorkspaceEventArgs>(this.mainWorkspace_SmartPartActivated);
            // 
            // paletteWorkspace
            // 
            this.paletteWorkspace.BackColor = System.Drawing.SystemColors.Control;
            this.paletteWorkspace.Dock = System.Windows.Forms.DockStyle.Top;
            this.paletteWorkspace.Location = new System.Drawing.Point(0, 24);
            this.paletteWorkspace.Name = "paletteWorkspace";
            this.paletteWorkspace.Size = new System.Drawing.Size(792, 25);
            this.paletteWorkspace.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.btnLocalization);
            this.Controls.Add(this.mainWorkspace);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.paletteWorkspace);
            this.Controls.Add(this.menuBar);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuBar;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace paletteWorkspace;
        private MenuStrip menuBar;
        private StatusStrip statusBar;
        private Microsoft.Practices.CompositeUI.WinForms.TabWorkspace mainWorkspace;
        private ToolStripMenuItem mnuSystem;
        private ToolStripStatusLabel sttLabelUseName;
        private ToolStripMenuItem mnuOptions;
        private ToolStripMenuItem mnuChangePassword;
        private ToolStripMenuItem mnuLogout;
        private ToolStripMenuItem mnuExit;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnuUpdateInfo;
        private Button btnLocalization;
    }
}

