namespace SystemMgtComponent.WorkItems.ClearCard
{
    partial class FrmClearEmptyCard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblChooseSubjectPerso = new System.Windows.Forms.Label();
            this.cmbMasterInfo = new System.Windows.Forms.ComboBox();
            this.line1 = new CommonControls.Custom.Line();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblGuiClearCardData = new System.Windows.Forms.Label();
            this.lblDelteEmptycard = new System.Windows.Forms.Label();
            this.cardReaderControl = new CardChipService.Controls.CardReaderControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblChooseSubjectPerso);
            this.panel1.Controls.Add(this.cmbMasterInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 38);
            this.panel1.TabIndex = 63;
            // 
            // lblChooseSubjectPerso
            // 
            this.lblChooseSubjectPerso.AutoSize = true;
            this.lblChooseSubjectPerso.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseSubjectPerso.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChooseSubjectPerso.Location = new System.Drawing.Point(9, 10);
            this.lblChooseSubjectPerso.Name = "lblChooseSubjectPerso";
            this.lblChooseSubjectPerso.Size = new System.Drawing.Size(146, 14);
            this.lblChooseSubjectPerso.TabIndex = 1;
            this.lblChooseSubjectPerso.Text = "Chọn chủ thể phát hành:";
            // 
            // cmbMasterInfo
            // 
            this.cmbMasterInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMasterInfo.FormattingEnabled = true;
            this.cmbMasterInfo.Location = new System.Drawing.Point(195, 7);
            this.cmbMasterInfo.Name = "cmbMasterInfo";
            this.cmbMasterInfo.Size = new System.Drawing.Size(375, 21);
            this.cmbMasterInfo.TabIndex = 55;
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Line3DStyle = CommonControls.Custom.Line3DStyle.Inset;
            this.line1.Location = new System.Drawing.Point(0, 50);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(575, 2);
            this.line1.TabIndex = 62;
            this.line1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblGuiClearCardData);
            this.panel2.Controls.Add(this.lblDelteEmptycard);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 50);
            this.panel2.TabIndex = 61;
            // 
            // lblGuiClearCardData
            // 
            this.lblGuiClearCardData.AutoSize = true;
            this.lblGuiClearCardData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuiClearCardData.Location = new System.Drawing.Point(9, 26);
            this.lblGuiClearCardData.Margin = new System.Windows.Forms.Padding(3);
            this.lblGuiClearCardData.Name = "lblGuiClearCardData";
            this.lblGuiClearCardData.Size = new System.Drawing.Size(163, 14);
            this.lblGuiClearCardData.TabIndex = 1;
            this.lblGuiClearCardData.Text = "Quét thẻ để xóa trắng thẻ.";
            // 
            // lblDelteEmptycard
            // 
            this.lblDelteEmptycard.AutoSize = true;
            this.lblDelteEmptycard.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelteEmptycard.Location = new System.Drawing.Point(9, 9);
            this.lblDelteEmptycard.Name = "lblDelteEmptycard";
            this.lblDelteEmptycard.Size = new System.Drawing.Size(95, 14);
            this.lblDelteEmptycard.TabIndex = 0;
            this.lblDelteEmptycard.Text = "Xóa Trắng Thẻ";
            // 
            // cardReaderControl
            // 
            this.cardReaderControl.AutoSize = true;
            this.cardReaderControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardReaderControl.Location = new System.Drawing.Point(0, 90);
            this.cardReaderControl.MaximumSize = new System.Drawing.Size(570, 330);
            this.cardReaderControl.MinimumSize = new System.Drawing.Size(570, 330);
            this.cardReaderControl.Name = "cardReaderControl";
            this.cardReaderControl.Size = new System.Drawing.Size(570, 330);
            this.cardReaderControl.TabIndex = 64;
            // 
            // FrmClearEmptyCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 427);
            this.Controls.Add(this.cardReaderControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmClearEmptyCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmClearEmptyCards";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblChooseSubjectPerso;
        private System.Windows.Forms.ComboBox cmbMasterInfo;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblGuiClearCardData;
        private System.Windows.Forms.Label lblDelteEmptycard;
        private CardChipService.Controls.CardReaderControl cardReaderControl;
    }
}