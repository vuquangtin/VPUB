namespace ScanComponent.View {
    partial class UsrScanImage {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lblMessage = new System.Windows.Forms.Label();
            this.cmsScanner = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miConnectScanner = new System.Windows.Forms.ToolStripMenuItem();
            this.miDisconnectScanner = new System.Windows.Forms.ToolStripMenuItem();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.cmsScanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(150, 150);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmsScanner
            // 
            this.cmsScanner.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsScanner.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miConnectScanner,
            this.miDisconnectScanner});
            this.cmsScanner.Name = "cmsScanner";
            this.cmsScanner.Size = new System.Drawing.Size(382, 80);
            // 
            // miConnectScanner
            // 
            this.miConnectScanner.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miConnectScanner.Image = global::ScanComponent.Properties.Resources.btnConnect;
            this.miConnectScanner.Name = "miConnectScanner";
            this.miConnectScanner.Size = new System.Drawing.Size(381, 38);
            this.miConnectScanner.Text = "Kết nối tới máy Scan";
            // 
            // miDisconnectScanner
            // 
            this.miDisconnectScanner.Image = global::ScanComponent.Properties.Resources.btnDisConnect;
            this.miDisconnectScanner.Name = "miDisconnectScanner";
            this.miDisconnectScanner.Size = new System.Drawing.Size(381, 38);
            this.miDisconnectScanner.Text = "Ngắt kết nối máy Scan";
            // 
            // pbxImage
            // 
            this.pbxImage.BackColor = System.Drawing.Color.Transparent;
            this.pbxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxImage.Location = new System.Drawing.Point(0, 0);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(150, 150);
            this.pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxImage.TabIndex = 4;
            this.pbxImage.TabStop = false;
            this.pbxImage.Visible = false;
            // 
            // UsrScanImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.ContextMenuStrip = this.cmsScanner;
            this.Controls.Add(this.pbxImage);
            this.Controls.Add(this.lblMessage);
            this.Name = "UsrScanImage";
            this.cmsScanner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ContextMenuStrip cmsScanner;
        private System.Windows.Forms.ToolStripMenuItem miConnectScanner;
        private System.Windows.Forms.ToolStripMenuItem miDisconnectScanner;
        private System.Windows.Forms.PictureBox pbxImage;
    }
}
