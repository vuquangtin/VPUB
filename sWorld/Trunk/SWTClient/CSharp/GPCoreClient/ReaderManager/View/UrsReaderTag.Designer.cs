namespace ReaderManager.View
{
    partial class UrsReaderTag
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbReaderName = new System.Windows.Forms.Label();
            this.labell = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbReaderName);
            this.panel1.Controls.Add(this.labell);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnDisconnect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panel1.Size = new System.Drawing.Size(676, 34);
            this.panel1.TabIndex = 0;
            // 
            // lbReaderName
            // 
            this.lbReaderName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbReaderName.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.lbReaderName.Location = new System.Drawing.Point(86, 3);
            this.lbReaderName.Name = "lbReaderName";
            this.lbReaderName.Size = new System.Drawing.Size(345, 31);
            this.lbReaderName.TabIndex = 6;
            this.lbReaderName.Text = "ACR 122U Reader";
            this.lbReaderName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labell
            // 
            this.labell.Dock = System.Windows.Forms.DockStyle.Left;
            this.labell.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.labell.Location = new System.Drawing.Point(0, 3);
            this.labell.Name = "labell";
            this.labell.Size = new System.Drawing.Size(86, 31);
            this.labell.TabIndex = 5;
            this.labell.Text = "Tên thiết bị:";
            this.labell.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnConnect
            // 
            this.btnConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnect.Image = global::ReaderManager.Properties.Resources.Play_icon;
            this.btnConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect.Location = new System.Drawing.Point(431, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(120, 31);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Bắt Đầu (F7)";
            this.btnConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(551, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 31);
            this.panel2.TabIndex = 3;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDisconnect.Image = global::ReaderManager.Properties.Resources.Stop_icon;
            this.btnDisconnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisconnect.Location = new System.Drawing.Point(556, 3);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(120, 31);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Kết Thúc (F8)";
            this.btnDisconnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbMessage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(676, 53);
            this.panel3.TabIndex = 1;
            // 
            // lbMessage
            // 
            this.lbMessage.BackColor = System.Drawing.Color.Teal;
            this.lbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMessage.Font = new System.Drawing.Font("Tahoma", 12.25F, System.Drawing.FontStyle.Bold);
            this.lbMessage.ForeColor = System.Drawing.Color.White;
            this.lbMessage.Location = new System.Drawing.Point(0, 0);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(676, 53);
            this.lbMessage.TabIndex = 6;
            this.lbMessage.Text = "THÀNH CÔNG";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UrsReaderTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.Name = "UrsReaderTag";
            this.Size = new System.Drawing.Size(676, 87);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labell;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Label lbReaderName;
    }
}
