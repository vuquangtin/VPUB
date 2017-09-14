namespace TreeViewColumnsProject
{
	partial class Form1
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.treeViewColumns1 = new TreeViewColumnsProject.TreeViewColumns1();
            this.treeViewColumns11 = new TreeViewColumnsProject.TreeViewColumns1();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.treeViewColumns1);
            this.flowLayoutPanel1.Controls.Add(this.treeViewColumns11);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 40);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(915, 692);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // treeViewColumns1
            // 
            this.treeViewColumns1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.treeViewColumns1.Location = new System.Drawing.Point(3, 3);
            this.treeViewColumns1.Name = "treeViewColumns1";
            this.treeViewColumns1.Padding = new System.Windows.Forms.Padding(1);
            this.treeViewColumns1.Size = new System.Drawing.Size(915, 769);
            this.treeViewColumns1.TabIndex = 0;
            // 
            // treeViewColumns11
            // 
            this.treeViewColumns11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.treeViewColumns11.Location = new System.Drawing.Point(3, 778);
            this.treeViewColumns11.Name = "treeViewColumns11";
            this.treeViewColumns11.Padding = new System.Windows.Forms.Padding(1);
            this.treeViewColumns11.Size = new System.Drawing.Size(870, 610);
            this.treeViewColumns11.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 729);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Example TreeViewColumns (lite)";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private TreeViewColumns1 treeViewColumns1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private TreeViewColumns1 treeViewColumns11;




	}
}

