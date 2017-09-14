namespace sMeetingComponent.WorkItems.ScheduleMeeting

{
    partial class FrmPartakerList
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvListAttend = new ClientModel.Controls.Commons.CommonDataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNamePartaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNameOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPositionPartaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblHourEnd = new System.Windows.Forms.Label();
            this.txtnote = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtNameMeeting = new System.Windows.Forms.TextBox();
            this.lblMeeting = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtdtpDateIn2 = new System.Windows.Forms.TextBox();
            this.txtdtpDateIn = new System.Windows.Forms.TextBox();
            this.tbxOrgName = new System.Windows.Forms.TextBox();
            this.lblGoverningOrganization = new System.Windows.Forms.Label();
            this.tmsMember = new CommonControls.Custom.CommonToolStrip();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.lblListAttend = new System.Windows.Forms.Label();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAttend)).BeginInit();
            this.pnlFilterBox.SuspendLayout();
            this.tmsMember.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.pnlFilterBox);
            this.panel4.Controls.Add(this.tmsMember);
            this.panel4.Controls.Add(this.lblListAttend);
            this.panel4.Controls.Add(this.pagerPanel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(6, 6);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1222, 649);
            this.panel4.TabIndex = 132;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvListAttend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 208);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1220, 417);
            this.panel1.TabIndex = 216;
            // 
            // dgvListAttend
            // 
            this.dgvListAttend.AllowUserToAddRows = false;
            this.dgvListAttend.AllowUserToDeleteRows = false;
            this.dgvListAttend.AllowUserToOrderColumns = true;
            this.dgvListAttend.AllowUserToResizeRows = false;
            this.dgvListAttend.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvListAttend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListAttend.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvListAttend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListAttend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colNamePartaker,
            this.colNameOrg,
            this.colPositionPartaker,
            this.colCheck});
            this.dgvListAttend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListAttend.Location = new System.Drawing.Point(0, 0);
            this.dgvListAttend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListAttend.MultiSelect = false;
            this.dgvListAttend.Name = "dgvListAttend";
            this.dgvListAttend.ReadOnly = true;
            this.dgvListAttend.RowHeadersVisible = false;
            this.dgvListAttend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListAttend.Size = new System.Drawing.Size(1220, 417);
            this.dgvListAttend.TabIndex = 1;
            // 
            // colSTT
            // 
            this.colSTT.DataPropertyName = "STT";
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 40;
            // 
            // colNamePartaker
            // 
            this.colNamePartaker.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNamePartaker.DataPropertyName = "NamePartaker";
            this.colNamePartaker.HeaderText = "Tên";
            this.colNamePartaker.Name = "colNamePartaker";
            this.colNamePartaker.ReadOnly = true;
            // 
            // colNameOrg
            // 
            this.colNameOrg.DataPropertyName = "NameOrg";
            this.colNameOrg.HeaderText = "Tổ chức";
            this.colNameOrg.Name = "colNameOrg";
            this.colNameOrg.ReadOnly = true;
            this.colNameOrg.Width = 300;
            // 
            // colPositionPartaker
            // 
            this.colPositionPartaker.DataPropertyName = "PositionPartaker";
            this.colPositionPartaker.HeaderText = "Chức vụ";
            this.colPositionPartaker.Name = "colPositionPartaker";
            this.colPositionPartaker.ReadOnly = true;
            this.colPositionPartaker.Width = 300;
            // 
            // colCheck
            // 
            this.colCheck.DataPropertyName = "Check";
            this.colCheck.FalseValue = "";
            this.colCheck.HeaderText = "Tham dự họp";
            this.colCheck.IndeterminateValue = "";
            this.colCheck.Name = "colCheck";
            this.colCheck.ReadOnly = true;
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCheck.TrueValue = "";
            this.colCheck.Visible = false;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilterBox.Controls.Add(this.lblHour);
            this.pnlFilterBox.Controls.Add(this.lblHourEnd);
            this.pnlFilterBox.Controls.Add(this.txtnote);
            this.pnlFilterBox.Controls.Add(this.lblNotes);
            this.pnlFilterBox.Controls.Add(this.txtDate);
            this.pnlFilterBox.Controls.Add(this.txtNameMeeting);
            this.pnlFilterBox.Controls.Add(this.lblMeeting);
            this.pnlFilterBox.Controls.Add(this.lblTime);
            this.pnlFilterBox.Controls.Add(this.txtdtpDateIn2);
            this.pnlFilterBox.Controls.Add(this.txtdtpDateIn);
            this.pnlFilterBox.Controls.Add(this.tbxOrgName);
            this.pnlFilterBox.Controls.Add(this.lblGoverningOrganization);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Enabled = false;
            this.pnlFilterBox.Font = new System.Drawing.Font("Tahoma", 9F);
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 55);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlFilterBox.Size = new System.Drawing.Size(1220, 153);
            this.pnlFilterBox.TabIndex = 215;
            // 
            // lblHour
            // 
            this.lblHour.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblHour.Location = new System.Drawing.Point(384, 67);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(41, 20);
            this.lblHour.TabIndex = 144;
            this.lblHour.Text = "Giờ:";
            // 
            // lblHourEnd
            // 
            this.lblHourEnd.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblHourEnd.Location = new System.Drawing.Point(486, 67);
            this.lblHourEnd.Name = "lblHourEnd";
            this.lblHourEnd.Size = new System.Drawing.Size(12, 24);
            this.lblHourEnd.TabIndex = 143;
            this.lblHourEnd.Text = ":";
            this.lblHourEnd.Visible = false;
            // 
            // txtnote
            // 
            this.txtnote.BackColor = System.Drawing.Color.White;
            this.txtnote.Enabled = false;
            this.txtnote.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtnote.Location = new System.Drawing.Point(214, 93);
            this.txtnote.Multiline = true;
            this.txtnote.Name = "txtnote";
            this.txtnote.Size = new System.Drawing.Size(266, 50);
            this.txtnote.TabIndex = 140;
            // 
            // lblNotes
            // 
            this.lblNotes.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblNotes.Location = new System.Drawing.Point(89, 96);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(123, 20);
            this.lblNotes.TabIndex = 139;
            this.lblNotes.Text = "Ghi chú:";
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.White;
            this.txtDate.Enabled = false;
            this.txtDate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtDate.Location = new System.Drawing.Point(214, 64);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(80, 22);
            this.txtDate.TabIndex = 130;
            // 
            // txtNameMeeting
            // 
            this.txtNameMeeting.BackColor = System.Drawing.Color.White;
            this.txtNameMeeting.CausesValidation = false;
            this.txtNameMeeting.Enabled = false;
            this.txtNameMeeting.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtNameMeeting.Location = new System.Drawing.Point(214, 35);
            this.txtNameMeeting.Name = "txtNameMeeting";
            this.txtNameMeeting.Size = new System.Drawing.Size(266, 22);
            this.txtNameMeeting.TabIndex = 129;
            // 
            // lblMeeting
            // 
            this.lblMeeting.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblMeeting.Location = new System.Drawing.Point(89, 38);
            this.lblMeeting.Name = "lblMeeting";
            this.lblMeeting.Size = new System.Drawing.Size(104, 20);
            this.lblMeeting.TabIndex = 127;
            this.lblMeeting.Text = "Cuộc họp:";
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTime.Location = new System.Drawing.Point(89, 67);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(96, 20);
            this.lblTime.TabIndex = 119;
            this.lblTime.Text = "Thời gian:";
            // 
            // txtdtpDateIn2
            // 
            this.txtdtpDateIn2.BackColor = System.Drawing.Color.White;
            this.txtdtpDateIn2.Enabled = false;
            this.txtdtpDateIn2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtdtpDateIn2.Location = new System.Drawing.Point(504, 64);
            this.txtdtpDateIn2.Name = "txtdtpDateIn2";
            this.txtdtpDateIn2.Size = new System.Drawing.Size(49, 22);
            this.txtdtpDateIn2.TabIndex = 116;
            this.txtdtpDateIn2.Visible = false;
            // 
            // txtdtpDateIn
            // 
            this.txtdtpDateIn.BackColor = System.Drawing.Color.White;
            this.txtdtpDateIn.Enabled = false;
            this.txtdtpDateIn.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtdtpDateIn.Location = new System.Drawing.Point(431, 64);
            this.txtdtpDateIn.Name = "txtdtpDateIn";
            this.txtdtpDateIn.Size = new System.Drawing.Size(49, 22);
            this.txtdtpDateIn.TabIndex = 115;
            // 
            // tbxOrgName
            // 
            this.tbxOrgName.BackColor = System.Drawing.Color.White;
            this.tbxOrgName.Enabled = false;
            this.tbxOrgName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tbxOrgName.Location = new System.Drawing.Point(214, 6);
            this.tbxOrgName.Name = "tbxOrgName";
            this.tbxOrgName.Size = new System.Drawing.Size(266, 22);
            this.tbxOrgName.TabIndex = 112;
            // 
            // lblGoverningOrganization
            // 
            this.lblGoverningOrganization.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblGoverningOrganization.Location = new System.Drawing.Point(89, 9);
            this.lblGoverningOrganization.Name = "lblGoverningOrganization";
            this.lblGoverningOrganization.Size = new System.Drawing.Size(123, 19);
            this.lblGoverningOrganization.TabIndex = 110;
            this.lblGoverningOrganization.Text = "Đơn vị tổ chức:";
            // 
            // tmsMember
            // 
            this.tmsMember.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportToExcel});
            this.tmsMember.Location = new System.Drawing.Point(0, 30);
            this.tmsMember.Name = "tmsMember";
            this.tmsMember.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.tmsMember.Size = new System.Drawing.Size(1220, 25);
            this.tmsMember.TabIndex = 2;
            this.tmsMember.Text = "toolStrip1";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportToExcel.Enabled = false;
            this.btnExportToExcel.Image = global::sMeetingComponent.Properties.Resources.Excel_16x16;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExportToExcel.Text = "Xuất Ra Excel...";
            this.btnExportToExcel.ToolTipText = "Xuất dữ liệu đang hiển thị ra tập tin excel";
            // 
            // lblListAttend
            // 
            this.lblListAttend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lblListAttend.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListAttend.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblListAttend.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblListAttend.Location = new System.Drawing.Point(0, 0);
            this.lblListAttend.Name = "lblListAttend";
            this.lblListAttend.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblListAttend.Size = new System.Drawing.Size(1220, 30);
            this.lblListAttend.TabIndex = 212;
            this.lblListAttend.Text = "DANH SÁCH NGƯỜI THAM DỰ";
            this.lblListAttend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 625);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(1220, 22);
            this.pagerPanel1.TabIndex = 102;
            // 
            // FrmPartakerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 661);
            this.Controls.Add(this.panel4);
            this.Name = "FrmPartakerList";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách Người Tham dự";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAttend)).EndInit();
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.tmsMember.ResumeLayout(false);
            this.tmsMember.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private System.Windows.Forms.Label lblListAttend;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblHourEnd;
        private System.Windows.Forms.TextBox txtnote;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtNameMeeting;
        private System.Windows.Forms.Label lblMeeting;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtdtpDateIn2;
        private System.Windows.Forms.TextBox txtdtpDateIn;
        private System.Windows.Forms.TextBox tbxOrgName;
        private System.Windows.Forms.Label lblGoverningOrganization;
        private CommonControls.Custom.CommonToolStrip tmsMember;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.Panel panel1;
        //  private CommonControls.Custom.CommonDataGridView dgvListAttend;
        private ClientModel.Controls.Commons.CommonDataGridView dgvListAttend;

        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNamePartaker;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameOrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPositionPartaker;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
    }
}