namespace sAccessComponent.WorkItems
{
    partial class FrmAddOrEditConfigAccessControll
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
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDeviceDoorList = new CommonControls.Custom.CommonDataGridView();
            this.colIdGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNameGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblGroupDevice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceDoorList)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 343);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(885, 20);
            this.pagerPanel1.TabIndex = 40;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvDeviceDoorList);
            this.panel2.Controls.Add(this.pagerPanel1);
            this.panel2.Location = new System.Drawing.Point(3, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(885, 363);
            this.panel2.TabIndex = 3;
            // 
            // dgvDeviceDoorList
            // 
            this.dgvDeviceDoorList.AllowUserToAddRows = false;
            this.dgvDeviceDoorList.AllowUserToDeleteRows = false;
            this.dgvDeviceDoorList.AllowUserToOrderColumns = true;
            this.dgvDeviceDoorList.AllowUserToResizeRows = false;
            this.dgvDeviceDoorList.BackgroundColor = System.Drawing.Color.White;
            this.dgvDeviceDoorList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDeviceDoorList.ColumnHeadersHeight = 26;
            this.dgvDeviceDoorList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdGroup,
            this.colNameGroup,
            this.colDescription,
            this.colStatus});
            this.dgvDeviceDoorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeviceDoorList.Location = new System.Drawing.Point(0, 0);
            this.dgvDeviceDoorList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDeviceDoorList.Name = "dgvDeviceDoorList";
            this.dgvDeviceDoorList.ReadOnly = true;
            this.dgvDeviceDoorList.RowHeadersVisible = false;
            this.dgvDeviceDoorList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeviceDoorList.Size = new System.Drawing.Size(885, 343);
            this.dgvDeviceDoorList.TabIndex = 80;
            // 
            // colIdGroup
            // 
            this.colIdGroup.DataPropertyName = "id";
            this.colIdGroup.HeaderText = "id";
            this.colIdGroup.Name = "colIdGroup";
            this.colIdGroup.ReadOnly = true;
            this.colIdGroup.Visible = false;
            // 
            // colNameGroup
            // 
            this.colNameGroup.DataPropertyName = "Name";
            this.colNameGroup.HeaderText = "Tên Nhóm";
            this.colNameGroup.Name = "colNameGroup";
            this.colNameGroup.ReadOnly = true;
            this.colNameGroup.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Des";
            this.colDescription.HeaderText = "Mô Tả";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Trạng Thái";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.btnConfirm);
            this.panel3.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(6, 495);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(887, 46);
            this.panel3.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(754, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(631, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 28);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(508, 5);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(117, 28);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Xác Nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblGroupDevice);
            this.panel4.Location = new System.Drawing.Point(2, 90);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(887, 38);
            this.panel4.TabIndex = 5;
            // 
            // lblGroupDevice
            // 
            this.lblGroupDevice.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblGroupDevice.Location = new System.Drawing.Point(223, 4);
            this.lblGroupDevice.Name = "lblGroupDevice";
            this.lblGroupDevice.Size = new System.Drawing.Size(380, 25);
            this.lblGroupDevice.TabIndex = 0;
            this.lblGroupDevice.Text = "DANH SÁCH NHÓM THIẾT BỊ CỬA";
            this.lblGroupDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 6;
            // 
            // FrmAddOrEditConfigAccessControll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 530);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "FrmAddOrEditConfigAccessControll";
            this.Text = "Thêm Mới Nhóm Thiết Bị";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceDoorList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private CommonControls.Custom.CommonDataGridView dgvDeviceDoorList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDes;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblGroupDevice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}