namespace SystemMgtComponent.WorkItems.ExportDataCard
{
    partial class FrmExportDataCard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panCenter = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCardData = new ClientModel.Controls.Commons.CommonDataGridView();
            this.OrgmasterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orgmastercode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.physycalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Typecript = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headerPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LicenseMaster = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panbottom = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblexportcardata = new System.Windows.Forms.Label();
            this.exportcardata = new System.Windows.Forms.Label();
            this.panTop = new System.Windows.Forms.Panel();
            this.tbxNumberCard = new System.Windows.Forms.NumericUpDown();
            this.lblNumberExport = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panCenter.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardData)).BeginInit();
            this.panbottom.SuspendLayout();
            this.panTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxNumberCard)).BeginInit();
            this.SuspendLayout();
            // 
            // panCenter
            // 
            this.panCenter.Controls.Add(this.panel2);
            this.panCenter.Controls.Add(this.panbottom);
            this.panCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panCenter.Location = new System.Drawing.Point(0, 97);
            this.panCenter.Name = "panCenter";
            this.panCenter.Size = new System.Drawing.Size(800, 398);
            this.panCenter.TabIndex = 48;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvCardData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 352);
            this.panel2.TabIndex = 54;
            // 
            // dgvCardData
            // 
            this.dgvCardData.AllowUserToAddRows = false;
            this.dgvCardData.AllowUserToDeleteRows = false;
            this.dgvCardData.AllowUserToOrderColumns = true;
            this.dgvCardData.AllowUserToResizeRows = false;
            this.dgvCardData.BackgroundColor = System.Drawing.Color.White;
            this.dgvCardData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCardData.ColumnHeadersHeight = 26;
            this.dgvCardData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrgmasterId,
            this.orgmastercode,
            this.physycalStatus,
            this.serial,
            this.CardType,
            this.Typecript,
            this.headerPosition,
            this.LicenseMaster});
            this.dgvCardData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCardData.Location = new System.Drawing.Point(0, 0);
            this.dgvCardData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCardData.MultiSelect = false;
            this.dgvCardData.Name = "dgvCardData";
            this.dgvCardData.ReadOnly = true;
            this.dgvCardData.RowHeadersVisible = false;
            this.dgvCardData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCardData.Size = new System.Drawing.Size(800, 352);
            this.dgvCardData.TabIndex = 53;
            // 
            // OrgmasterId
            // 
            this.OrgmasterId.DataPropertyName = "OrgmasterId";
            this.OrgmasterId.HeaderText = "OrgmasterId";
            this.OrgmasterId.Name = "OrgmasterId";
            this.OrgmasterId.ReadOnly = true;
            // 
            // orgmastercode
            // 
            this.orgmastercode.DataPropertyName = "orgmastercode";
            this.orgmastercode.HeaderText = "Mã tổ chức";
            this.orgmastercode.Name = "orgmastercode";
            this.orgmastercode.ReadOnly = true;
            // 
            // physycalStatus
            // 
            this.physycalStatus.DataPropertyName = "physycalStatus";
            this.physycalStatus.HeaderText = "Trạng thái vật lý";
            this.physycalStatus.Name = "physycalStatus";
            this.physycalStatus.ReadOnly = true;
            // 
            // serial
            // 
            this.serial.DataPropertyName = "serial";
            this.serial.HeaderText = "Mã thẻ";
            this.serial.Name = "serial";
            this.serial.ReadOnly = true;
            // 
            // CardType
            // 
            this.CardType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CardType.DataPropertyName = "CardType";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CardType.DefaultCellStyle = dataGridViewCellStyle1;
            this.CardType.HeaderText = "Loại thẻ";
            this.CardType.Name = "CardType";
            this.CardType.ReadOnly = true;
            // 
            // Typecript
            // 
            this.Typecript.DataPropertyName = "Typecript";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Typecript.DefaultCellStyle = dataGridViewCellStyle2;
            this.Typecript.HeaderText = "Loại mã hóa";
            this.Typecript.Name = "Typecript";
            this.Typecript.ReadOnly = true;
            // 
            // headerPosition
            // 
            this.headerPosition.DataPropertyName = "headerPosition";
            this.headerPosition.HeaderText = "Vị trí bắt đầu";
            this.headerPosition.Name = "headerPosition";
            this.headerPosition.ReadOnly = true;
            // 
            // LicenseMaster
            // 
            this.LicenseMaster.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LicenseMaster.DataPropertyName = "LicenseMaster";
            this.LicenseMaster.HeaderText = "LicenseMaster";
            this.LicenseMaster.Name = "LicenseMaster";
            this.LicenseMaster.ReadOnly = true;
            // 
            // panbottom
            // 
            this.panbottom.Controls.Add(this.btnExport);
            this.panbottom.Controls.Add(this.btnExit);
            this.panbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panbottom.Location = new System.Drawing.Point(0, 352);
            this.panbottom.Name = "panbottom";
            this.panbottom.Size = new System.Drawing.Size(800, 46);
            this.panbottom.TabIndex = 53;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(632, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 31);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Xuất dữ liệu";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(713, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 31);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // lblexportcardata
            // 
            this.lblexportcardata.AutoSize = true;
            this.lblexportcardata.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblexportcardata.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblexportcardata.Location = new System.Drawing.Point(22, 35);
            this.lblexportcardata.Margin = new System.Windows.Forms.Padding(3);
            this.lblexportcardata.Name = "lblexportcardata";
            this.lblexportcardata.Size = new System.Drawing.Size(165, 14);
            this.lblexportcardata.TabIndex = 50;
            this.lblexportcardata.Text = "Xuất dữ liệu thẻ ra file excel.";
            // 
            // exportcardata
            // 
            this.exportcardata.AutoSize = true;
            this.exportcardata.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exportcardata.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportcardata.Location = new System.Drawing.Point(22, 18);
            this.exportcardata.Name = "exportcardata";
            this.exportcardata.Size = new System.Drawing.Size(107, 14);
            this.exportcardata.TabIndex = 49;
            this.exportcardata.Text = "Xuất dữ liệu thẻ";
            // 
            // panTop
            // 
            this.panTop.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panTop.Controls.Add(this.tbxNumberCard);
            this.panTop.Controls.Add(this.lblNumberExport);
            this.panTop.Controls.Add(this.lblexportcardata);
            this.panTop.Controls.Add(this.exportcardata);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(800, 97);
            this.panTop.TabIndex = 47;
            // 
            // tbxNumberCard
            // 
            this.tbxNumberCard.Location = new System.Drawing.Point(159, 64);
            this.tbxNumberCard.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbxNumberCard.Name = "tbxNumberCard";
            this.tbxNumberCard.Size = new System.Drawing.Size(62, 21);
            this.tbxNumberCard.TabIndex = 52;
            this.tbxNumberCard.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNumberExport
            // 
            this.lblNumberExport.AutoSize = true;
            this.lblNumberExport.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNumberExport.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberExport.Location = new System.Drawing.Point(22, 67);
            this.lblNumberExport.Margin = new System.Windows.Forms.Padding(3);
            this.lblNumberExport.Name = "lblNumberExport";
            this.lblNumberExport.Size = new System.Drawing.Size(130, 14);
            this.lblNumberExport.TabIndex = 51;
            this.lblNumberExport.Text = "Số lượng thẻ cần xuất";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "OrgmasterId";
            this.dataGridViewTextBoxColumn1.HeaderText = "OrgmasterId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "orgmastercode";
            this.dataGridViewTextBoxColumn2.HeaderText = "Mã tổ chức";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "physycalStatus";
            this.dataGridViewTextBoxColumn3.HeaderText = "Trạng thái vật lý";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "serial";
            this.dataGridViewTextBoxColumn4.HeaderText = "Mã thẻ";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CardType";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn5.HeaderText = "Loại thẻ";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Typecript";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn6.HeaderText = "Loại mã hóa";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "headerPosition";
            this.dataGridViewTextBoxColumn7.HeaderText = "Vị trí bắt đầu";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "LicenseMaster";
            this.dataGridViewTextBoxColumn8.HeaderText = "LicenseMaster";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // FrmExportDataCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.panCenter);
            this.Controls.Add(this.panTop);
            this.Name = "FrmExportDataCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panCenter.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardData)).EndInit();
            this.panbottom.ResumeLayout(false);
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxNumberCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panCenter;
        private System.Windows.Forms.Label lblexportcardata;
        private System.Windows.Forms.Label exportcardata;
        private System.Windows.Forms.Panel panel2;
        private ClientModel.Controls.Commons.CommonDataGridView dgvCardData;
        private System.Windows.Forms.Panel panbottom;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Label lblNumberExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.NumericUpDown tbxNumberCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrgmasterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn orgmastercode;
        private System.Windows.Forms.DataGridViewTextBoxColumn physycalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Typecript;
        private System.Windows.Forms.DataGridViewTextBoxColumn headerPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn LicenseMaster;
    }
}