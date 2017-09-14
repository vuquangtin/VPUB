namespace CABDemo
{
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
            this.components = new System.ComponentModel.Container();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.mainWorkspace = new Microsoft.Practices.CompositeUI.WinForms.TabWorkspace();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Padding = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.menuBar.Size = new System.Drawing.Size(784, 24);
            this.menuBar.TabIndex = 9;
            // 
            // mainWorkspace
            // 
            this.mainWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWorkspace.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.mainWorkspace.Location = new System.Drawing.Point(0, 24);
            this.mainWorkspace.Name = "mainWorkspace";
            this.mainWorkspace.SelectedIndex = 0;
            this.mainWorkspace.Size = new System.Drawing.Size(784, 538);
            this.mainWorkspace.SupportCloseButton = true;
            this.mainWorkspace.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.mainWorkspace);
            this.Controls.Add(this.menuBar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAB demo";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.MenuStrip menuBar;
        private Microsoft.Practices.CompositeUI.WinForms.TabWorkspace mainWorkspace;

    }
}

