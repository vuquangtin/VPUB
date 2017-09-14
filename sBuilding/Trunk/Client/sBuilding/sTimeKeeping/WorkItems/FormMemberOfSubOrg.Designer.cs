namespace sTimeKeeping.WorkItems
{
    partial class FormMemberOfSubOrg
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
            this.pnlFilterBox = new System.Windows.Forms.Panel();
            this.lblFilters = new System.Windows.Forms.Label();
            this.lblInfoDelete = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblInfoAdd = new System.Windows.Forms.Label();
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgvMemberListEvent = new CommonControls.Custom.CommonDataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventMemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCmnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.line2 = new CommonControls.Custom.Line();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            this.pnlFilterBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberListEvent)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilterBox
            // 
            this.pnlFilterBox.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilterBox.Controls.Add(this.lblFilters);
            this.pnlFilterBox.Controls.Add(this.lblInfoDelete);
            this.pnlFilterBox.Controls.Add(this.label12);
            this.pnlFilterBox.Controls.Add(this.lblInfoAdd);
            this.pnlFilterBox.Controls.Add(this.tbxCode);
            this.pnlFilterBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBox.Location = new System.Drawing.Point(0, 1);
            this.pnlFilterBox.Name = "pnlFilterBox";
            this.pnlFilterBox.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlFilterBox.Size = new System.Drawing.Size(871, 58);
            this.pnlFilterBox.TabIndex = 79;
            // 
            // lblFilters
            // 
            this.lblFilters.AutoSize = true;
            this.lblFilters.Location = new System.Drawing.Point(11, 11);
            this.lblFilters.Name = "lblFilters";
            this.lblFilters.Size = new System.Drawing.Size(117, 16);
            this.lblFilters.TabIndex = 113;
            this.lblFilters.Text = "Nhâp điều kiện lọc:";
            // 
            // lblInfoDelete
            // 
            this.lblInfoDelete.AutoSize = true;
            this.lblInfoDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoDelete.Location = new System.Drawing.Point(27, 37);
            this.lblInfoDelete.Margin = new System.Windows.Forms.Padding(3);
            this.lblInfoDelete.Name = "lblInfoDelete";
            this.lblInfoDelete.Size = new System.Drawing.Size(434, 14);
            this.lblInfoDelete.TabIndex = 112;
            this.lblInfoDelete.Text = "Chọn người xóa khỏi sự kiện. Nhấn giữ phím Ctrl để chọn nhiều người để xóa.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(5, 35);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 14);
            this.label12.TabIndex = 111;
            this.label12.Text = "(*)";
            // 
            // lblInfoAdd
            // 
            this.lblInfoAdd.AutoSize = true;
            this.lblInfoAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoAdd.Location = new System.Drawing.Point(27, 37);
            this.lblInfoAdd.Margin = new System.Windows.Forms.Padding(3);
            this.lblInfoAdd.Name = "lblInfoAdd";
            this.lblInfoAdd.Size = new System.Drawing.Size(462, 14);
            this.lblInfoAdd.TabIndex = 110;
            this.lblInfoAdd.Text = "Chọn người tham gia sự kiện. Nhấn giữ phím Ctrl để chọn nhiều người cho sự kiện.";
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(167, 7);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(150, 22);
            this.tbxCode.TabIndex = 109;
            this.tbxCode.TextChanged += new System.EventHandler(this.tbxCode_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.panel1.Size = new System.Drawing.Size(887, 414);
            this.panel1.TabIndex = 68;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.pnlFilterBox);
            this.panel2.Controls.Add(this.line2);
            this.panel2.Controls.Add(this.pagerPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(873, 404);
            this.panel2.TabIndex = 38;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(871, 329);
            this.panel4.TabIndex = 83;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dgvMemberListEvent);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(871, 285);
            this.panel7.TabIndex = 85;
            // 
            // dgvMemberListEvent
            // 
            this.dgvMemberListEvent.AllowUserToAddRows = false;
            this.dgvMemberListEvent.AllowUserToDeleteRows = false;
            this.dgvMemberListEvent.AllowUserToOrderColumns = true;
            this.dgvMemberListEvent.AllowUserToResizeRows = false;
            this.dgvMemberListEvent.BackgroundColor = System.Drawing.Color.White;
            this.dgvMemberListEvent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMemberListEvent.ColumnHeadersHeight = 26;
            this.dgvMemberListEvent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colEventMemberId,
            this.colCode,
            this.colName,
            this.colPhone,
            this.colCmnd,
            this.colEmail});
            this.dgvMemberListEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMemberListEvent.Location = new System.Drawing.Point(0, 0);
            this.dgvMemberListEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMemberListEvent.Name = "dgvMemberListEvent";
            this.dgvMemberListEvent.ReadOnly = true;
            this.dgvMemberListEvent.RowHeadersVisible = false;
            this.dgvMemberListEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMemberListEvent.Size = new System.Drawing.Size(871, 285);
            this.dgvMemberListEvent.TabIndex = 109;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "colId";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 125;
            // 
            // colEventMemberId
            // 
            this.colEventMemberId.DataPropertyName = "colEventMemberId";
            this.colEventMemberId.HeaderText = "colEventMemberId";
            this.colEventMemberId.Name = "colEventMemberId";
            this.colEventMemberId.ReadOnly = true;
            this.colEventMemberId.Visible = false;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "colCode";
            this.colCode.HeaderText = "Mã thành viên";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 120;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "colName";
            this.colName.HeaderText = "Tên Thành Viên";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // colPhone
            // 
            this.colPhone.DataPropertyName = "colPhone";
            this.colPhone.HeaderText = "Số Điện Thoại";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            this.colPhone.Width = 150;
            // 
            // colCmnd
            // 
            this.colCmnd.DataPropertyName = "colCmnd";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCmnd.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCmnd.HeaderText = "Số CMND";
            this.colCmnd.Name = "colCmnd";
            this.colCmnd.ReadOnly = true;
            this.colCmnd.Width = 125;
            // 
            // colEmail
            // 
            this.colEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEmail.DataPropertyName = "colEmail";
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnAccept);
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 285);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(871, 44);
            this.panel5.TabIndex = 83;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(657, 12);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(94, 23);
            this.btnAccept.TabIndex = 116;
            this.btnAccept.Text = "Xác nhận";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(776, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 23);
            this.btnCancel.TabIndex = 117;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // line2
            // 
            this.line2.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line2.Dock = System.Windows.Forms.DockStyle.Top;
            this.line2.Location = new System.Drawing.Point(0, 0);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(871, 1);
            this.line2.TabIndex = 77;
            this.line2.TabStop = false;
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 388);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(871, 14);
            this.pagerPanel1.TabIndex = 40;
            // 
            // FormMemberOfSubOrg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 414);
            this.Controls.Add(this.panel1);
            this.Name = "FormMemberOfSubOrg";
            this.Text = "Danh sách thành viên";
            this.Load += new System.EventHandler(this.FormMemberOfSubOrg_Load);
            this.pnlFilterBox.ResumeLayout(false);
            this.pnlFilterBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberListEvent)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilterBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CommonControls.Custom.Line line2;
        private CommonControls.Custom.PagerPanel pagerPanel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblInfoAdd;
        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.Label lblInfoDelete;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private CommonControls.Custom.CommonDataGridView dgvMemberListEvent;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventMemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCmnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.Label lblFilters;
    }
}