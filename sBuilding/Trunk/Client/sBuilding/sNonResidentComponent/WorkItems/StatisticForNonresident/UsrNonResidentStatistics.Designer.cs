namespace sNonResidentComponent.WorkItems.StatisticForNonresident
{
    partial class UsrNonResidentStatistics
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrNonResidentStatistics));
            this.cmsPersoRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniInfor = new System.Windows.Forms.ToolStripMenuItem();
            this.lbltititeStatisticNonrisedentinout = new CommonControls.Custom.TitleLabel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1Outside = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblFilterByDate = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpDateIn2 = new System.Windows.Forms.DateTimePicker();
            this.dtpDateIn = new System.Windows.Forms.DateTimePicker();
            this.dataGridview4Export = new ClientModel.Controls.Commons.CommonDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbxOrgName = new System.Windows.Forms.TextBox();
            this.lblFilterByOrgName = new System.Windows.Forms.Label();
            this.tmsMember = new CommonControls.Custom.CommonToolStrip();
            this.btnShowHide = new System.Windows.Forms.ToolStripButton();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.pagerPanel = new CommonControls.Custom.PagerPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvNonResidentNew = new CommonControls.Custom.CommonDataGridView();
            this.colOrderNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrgId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNameOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberPeople = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInfo = new System.Windows.Forms.DataGridViewImageColumn();
            this.cmsPersoRecord.SuspendLayout();
            this.panel1Outside.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlFilterBox.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridview4Export)).BeginInit();
            this.tmsMember.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNonResidentNew)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsPersoRecord
            // 
            this.cmsPersoRecord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniInfor});
            this.cmsPersoRecord.Name = "contextMenuStrip1";
            this.cmsPersoRecord.Size = new System.Drawing.Size(157, 26);
            // 
            // mniInfor
            // 
            this.mniInfor.Image = global::sNonResidentComponent.Properties.Resources.info16x16;
            this.mniInfor.Name = "mniInfor";
            this.mniInfor.Size = new System.Drawing.Size(156, 22);
            this.mniInfor.Text = "Xem Thông Tin";
            this.mniInfor.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // lbltititeStatisticNonrisedentinout
            // 
            this.lbltititeStatisticNonrisedentinout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.lbltititeStatisticNonrisedentinout.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbltititeStatisticNonrisedentinout.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lbltititeStatisticNonrisedentinout.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbltititeStatisticNonrisedentinout.Location = new System.Drawing.Point(6, 5);
            this.lbltititeStatisticNonrisedentinout.Name = "lbltititeStatisticNonrisedentinout";
            this.lbltititeStatisticNonrisedentinout.Size = new System.Drawing.Size(1054, 32);
            this.lbltititeStatisticNonrisedentinout.TabIndex = 27;
            this.lbltititeStatisticNonrisedentinout.Text = "THỐNG KÊ KHÁCH VÃNG LAI";
            this.lbltititeStatisticNonrisedentinout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "colInfo";
            this.dataGridViewImageColumn1.HeaderText = "Xem chi tiết";
            this.dataGridViewImageColumn1.Image = global::sNonResidentComponent.Properties.Resources.ic_search;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panel1Outside
            // 
            this.panel1Outside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1Outside.Controls.Add(this.panel1);
            this.panel1Outside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1Outside.Location = new System.Drawing.Point(6, 37);
            this.panel1Outside.Name = "panel1Outside";
            this.panel1Outside.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1Outside.Size = new System.Drawing.Size(1054, 604);
            this.panel1Outside.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pnlFilterBox);
            this.panel1.Controls.Add(this.tmsMember);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 592);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.AutoScrollMinSize = new System.Drawing.Size(1000, 0);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.pagerPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1038, 493);
            this.panel2.TabIndex = 4;
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilterBox.Controls.Add(this.panel3);
            this.pnlFilterBox.Controls.Add(this.dataGridview4Export);
            this.pnlFilterBox.Controls.Add(this.tbxOrgName);
            this.pnlFilterBox.Controls.Add(this.lblFilterByOrgName);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 25);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlFilterBox.Size = new System.Drawing.Size(1038, 72);
            this.pnlFilterBox.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblFilterByDate);
            this.panel3.Controls.Add(this.lblTo);
            this.panel3.Controls.Add(this.dtpDateIn2);
            this.panel3.Controls.Add(this.dtpDateIn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(6, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1024, 32);
            this.panel3.TabIndex = 1;
            // 
            // lblFilterByDate
            // 
            this.lblFilterByDate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFilterByDate.Location = new System.Drawing.Point(92, 4);
            this.lblFilterByDate.Name = "lblFilterByDate";
            this.lblFilterByDate.Size = new System.Drawing.Size(141, 24);
            this.lblFilterByDate.TabIndex = 104;
            this.lblFilterByDate.Text = "Lọc theo ngày:";
            this.lblFilterByDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTo
            // 
            this.lblTo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTo.Location = new System.Drawing.Point(367, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(33, 26);
            this.lblTo.TabIndex = 103;
            this.lblTo.Text = "đến";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDateIn2
            // 
            this.dtpDateIn2.CustomFormat = "dd/MM/yyyy";
            this.dtpDateIn2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpDateIn2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateIn2.Location = new System.Drawing.Point(406, 3);
            this.dtpDateIn2.Name = "dtpDateIn2";
            this.dtpDateIn2.Size = new System.Drawing.Size(89, 22);
            this.dtpDateIn2.TabIndex = 2;
            // 
            // dtpDateIn
            // 
            this.dtpDateIn.CustomFormat = "dd/MM/yyyy";
            this.dtpDateIn.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateIn.Location = new System.Drawing.Point(272, 3);
            this.dtpDateIn.Name = "dtpDateIn";
            this.dtpDateIn.Size = new System.Drawing.Size(89, 22);
            this.dtpDateIn.TabIndex = 1;
            // 
            // dataGridview4Export
            // 
            this.dataGridview4Export.AllowUserToAddRows = false;
            this.dataGridview4Export.AllowUserToDeleteRows = false;
            this.dataGridview4Export.AllowUserToOrderColumns = true;
            this.dataGridview4Export.AllowUserToResizeRows = false;
            this.dataGridview4Export.BackgroundColor = System.Drawing.Color.White;
            this.dataGridview4Export.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridview4Export.ColumnHeadersHeight = 26;
            this.dataGridview4Export.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dataGridview4Export.Location = new System.Drawing.Point(546, 23);
            this.dataGridview4Export.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridview4Export.MultiSelect = false;
            this.dataGridview4Export.Name = "dataGridview4Export";
            this.dataGridview4Export.ReadOnly = true;
            this.dataGridview4Export.RowHeadersVisible = false;
            this.dataGridview4Export.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridview4Export.Size = new System.Drawing.Size(232, 510);
            this.dataGridview4Export.TabIndex = 46;
            this.dataGridview4Export.TabStop = false;
            this.dataGridview4Export.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "OrderNum";
            this.dataGridViewTextBoxColumn1.HeaderText = "Stt";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OrgId";
            this.dataGridViewTextBoxColumn2.HeaderText = "colOrgId";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NameOrg";
            this.dataGridViewTextBoxColumn3.HeaderText = "Cơ quan";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn4.HeaderText = "Ngày";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "colNumberPeople";
            this.dataGridViewTextBoxColumn5.HeaderText = "Số người";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // tbxOrgName
            // 
            this.tbxOrgName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tbxOrgName.Location = new System.Drawing.Point(279, 43);
            this.tbxOrgName.MaxLength = 250;
            this.tbxOrgName.Name = "tbxOrgName";
            this.tbxOrgName.Size = new System.Drawing.Size(223, 22);
            this.tbxOrgName.TabIndex = 3;
            // 
            // lblFilterByOrgName
            // 
            this.lblFilterByOrgName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFilterByOrgName.Location = new System.Drawing.Point(99, 42);
            this.lblFilterByOrgName.Name = "lblFilterByOrgName";
            this.lblFilterByOrgName.Size = new System.Drawing.Size(174, 24);
            this.lblFilterByOrgName.TabIndex = 99;
            this.lblFilterByOrgName.Text = "Lọc theo đơn vị tổ chức:";
            this.lblFilterByOrgName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmsMember
            // 
            this.tmsMember.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowHide,
            this.btnExportToExcel,
            this.btnReload});
            this.tmsMember.Location = new System.Drawing.Point(0, 0);
            this.tmsMember.Name = "tmsMember";
            this.tmsMember.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.tmsMember.Size = new System.Drawing.Size(1038, 25);
            this.tmsMember.TabIndex = 5;
            this.tmsMember.Text = "toolStrip1";
            // 
            // btnShowHide
            // 
            this.btnShowHide.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnShowHide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowHide.Image = ((System.Drawing.Image)(resources.GetObject("btnShowHide.Image")));
            this.btnShowHide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(23, 22);
            this.btnShowHide.Text = "Ẩn Khung Tìm Kiếm";
            this.btnShowHide.ToolTipText = "Ẩn khung tìm kiếm";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportToExcel.Enabled = false;
            this.btnExportToExcel.Image = global::sNonResidentComponent.Properties.Resources.Excel_16x16;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExportToExcel.Text = "Xuất Ra Excel...";
            this.btnExportToExcel.ToolTipText = "Xuất dữ liệu đang hiển thị ra tập tin excel";
            // 
            // btnReload
            // 
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(23, 22);
            this.btnReload.Text = "Tải Dữ Liệu";
            this.btnReload.ToolTipText = "Tải danh sách thành viên";
            // 
            // pagerPanel
            // 
            this.pagerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel.Location = new System.Drawing.Point(0, 471);
            this.pagerPanel.Name = "pagerPanel";
            this.pagerPanel.Size = new System.Drawing.Size(1038, 22);
            this.pagerPanel.TabIndex = 31;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvNonResidentNew);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1038, 471);
            this.panel4.TabIndex = 32;
            // 
            // dgvNonResidentNew
            // 
            this.dgvNonResidentNew.AllowUserToAddRows = false;
            this.dgvNonResidentNew.AllowUserToDeleteRows = false;
            this.dgvNonResidentNew.AllowUserToOrderColumns = true;
            this.dgvNonResidentNew.AllowUserToResizeRows = false;
            this.dgvNonResidentNew.BackgroundColor = System.Drawing.Color.White;
            this.dgvNonResidentNew.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNonResidentNew.ColumnHeadersHeight = 26;
            this.dgvNonResidentNew.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderNum,
            this.colOrgId,
            this.colNameOrg,
            this.colDate,
            this.colNumberPeople,
            this.colInfo});
            this.dgvNonResidentNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNonResidentNew.Location = new System.Drawing.Point(0, 0);
            this.dgvNonResidentNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvNonResidentNew.MultiSelect = false;
            this.dgvNonResidentNew.Name = "dgvNonResidentNew";
            this.dgvNonResidentNew.ReadOnly = true;
            this.dgvNonResidentNew.RowHeadersVisible = false;
            this.dgvNonResidentNew.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNonResidentNew.Size = new System.Drawing.Size(1038, 471);
            this.dgvNonResidentNew.TabIndex = 5;
            this.dgvNonResidentNew.TabStop = false;
            // 
            // colOrderNum
            // 
            this.colOrderNum.DataPropertyName = "OrderNum";
            this.colOrderNum.HeaderText = "Stt";
            this.colOrderNum.Name = "colOrderNum";
            this.colOrderNum.ReadOnly = true;
            this.colOrderNum.Width = 40;
            // 
            // colOrgId
            // 
            this.colOrgId.DataPropertyName = "OrgId";
            this.colOrgId.HeaderText = "colOrgId";
            this.colOrgId.Name = "colOrgId";
            this.colOrgId.ReadOnly = true;
            this.colOrgId.Visible = false;
            // 
            // colNameOrg
            // 
            this.colNameOrg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNameOrg.DataPropertyName = "NameOrg";
            this.colNameOrg.HeaderText = "Cơ quan";
            this.colNameOrg.Name = "colNameOrg";
            this.colNameOrg.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "Date";
            this.colDate.HeaderText = "Ngày";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Visible = false;
            this.colDate.Width = 200;
            // 
            // colNumberPeople
            // 
            this.colNumberPeople.DataPropertyName = "colNumberPeople";
            this.colNumberPeople.HeaderText = "Số người";
            this.colNumberPeople.Name = "colNumberPeople";
            this.colNumberPeople.ReadOnly = true;
            this.colNumberPeople.Width = 200;
            // 
            // colInfo
            // 
            this.colInfo.DataPropertyName = "colInfo";
            this.colInfo.HeaderText = "Xem chi tiết";
            this.colInfo.Image = global::sNonResidentComponent.Properties.Resources.ic_search;
            this.colInfo.Name = "colInfo";
            this.colInfo.ReadOnly = true;
            this.colInfo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInfo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // UsrNonResidentStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1Outside);
            this.Controls.Add(this.lbltititeStatisticNonrisedentinout);
            this.Name = "UsrNonResidentStatistics";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Size = new System.Drawing.Size(1066, 646);
            this.cmsPersoRecord.ResumeLayout(false);
            this.panel1Outside.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridview4Export)).EndInit();
            this.tmsMember.ResumeLayout(false);
            this.tmsMember.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNonResidentNew)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsPersoRecord;
        private System.Windows.Forms.ToolStripMenuItem mniInfor;
        private CommonControls.Custom.TitleLabel lbltititeStatisticNonrisedentinout;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Panel panel1Outside;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblFilterByDate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpDateIn2;
        private System.Windows.Forms.DateTimePicker dtpDateIn;
        private ClientModel.Controls.Commons.CommonDataGridView dataGridview4Export;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.TextBox tbxOrgName;
        private System.Windows.Forms.Label lblFilterByOrgName;
        private CommonControls.Custom.CommonToolStrip tmsMember;
        private System.Windows.Forms.ToolStripButton btnShowHide;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.Panel panel4;
        private CommonControls.Custom.CommonDataGridView dgvNonResidentNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrgId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameOrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberPeople;
        private System.Windows.Forms.DataGridViewImageColumn colInfo;
        private CommonControls.Custom.PagerPanel pagerPanel;
    }
}
