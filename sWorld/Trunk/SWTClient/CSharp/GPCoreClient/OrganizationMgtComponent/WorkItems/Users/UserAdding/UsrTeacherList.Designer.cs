namespace UserMgtComponent.WorkItems.UserAdding
{
    partial class UsrTeacherList
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
            CommonControls.Custom.CommonDataGridView dgvTeacherList;
            this.colTeacherId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeacherCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbDepartments = new System.Windows.Forms.ComboBox();
            this.cmbFaculties = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pagerPanel1 = new CommonControls.Custom.PagerPanel();
            dgvTeacherList = new CommonControls.Custom.CommonDataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvTeacherList)).BeginInit();
            this.SuspendLayout();
            // 
            // colTeacherId
            // 
            this.colTeacherId.DataPropertyName = "TeacherId";
            this.colTeacherId.HeaderText = "";
            this.colTeacherId.Name = "colTeacherId";
            this.colTeacherId.ReadOnly = true;
            this.colTeacherId.Visible = false;
            this.colTeacherId.Width = 125;
            // 
            // colTeacherCode
            // 
            this.colTeacherCode.DataPropertyName = "TeacherCode";
            this.colTeacherCode.HeaderText = "Mã Giảng Viên";
            this.colTeacherCode.Name = "colTeacherCode";
            this.colTeacherCode.ReadOnly = true;
            this.colTeacherCode.Width = 125;
            // 
            // colLastName
            // 
            this.colLastName.DataPropertyName = "LastName";
            this.colLastName.HeaderText = "Họ";
            this.colLastName.Name = "colLastName";
            this.colLastName.ReadOnly = true;
            this.colLastName.Width = 150;
            // 
            // colFirstName
            // 
            this.colFirstName.DataPropertyName = "FirstName";
            this.colFirstName.HeaderText = "Tên";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.ReadOnly = true;
            // 
            // colTitle
            // 
            this.colTitle.DataPropertyName = "Title";
            this.colTitle.HeaderText = "Chức Danh";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.Width = 150;
            // 
            // colPosition
            // 
            this.colPosition.DataPropertyName = "Position";
            this.colPosition.HeaderText = "Chức Vụ";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            this.colPosition.Width = 150;
            // 
            // colWorking
            // 
            this.colWorking.DataPropertyName = "Working";
            this.colWorking.HeaderText = "Đã Nghỉ";
            this.colWorking.Name = "colWorking";
            this.colWorking.ReadOnly = true;
            this.colWorking.Width = 125;
            // 
            // colBlank
            // 
            this.colBlank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBlank.HeaderText = "";
            this.colBlank.Name = "colBlank";
            this.colBlank.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbDepartments);
            this.panel1.Controls.Add(this.cmbFaculties);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 71);
            this.panel1.TabIndex = 0;
            // 
            // cmbDepartments
            // 
            this.cmbDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartments.FormattingEnabled = true;
            this.cmbDepartments.Location = new System.Drawing.Point(348, 33);
            this.cmbDepartments.Name = "cmbDepartments";
            this.cmbDepartments.Size = new System.Drawing.Size(200, 22);
            this.cmbDepartments.TabIndex = 8;
            // 
            // cmbFaculties
            // 
            this.cmbFaculties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFaculties.FormattingEnabled = true;
            this.cmbFaculties.Location = new System.Drawing.Point(59, 33);
            this.cmbFaculties.Name = "cmbFaculties";
            this.cmbFaculties.Size = new System.Drawing.Size(200, 22);
            this.cmbFaculties.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(282, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bộ môn:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Khoa:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(820, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chọn thông tin cá nhân từ một giảng viên của nhà trường.";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnBack);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(10, 377);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel2.Size = new System.Drawing.Size(820, 31);
            this.panel2.TabIndex = 6;
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBack.Location = new System.Drawing.Point(0, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 26);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Quay Lại";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.Location = new System.Drawing.Point(508, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 26);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Tiếp Tục";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(608, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(6, 26);
            this.panel4.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(614, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 26);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(714, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(6, 26);
            this.panel3.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(720, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(dgvTeacherList);
            this.panel5.Controls.Add(this.pagerPanel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(10, 76);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(820, 301);
            this.panel5.TabIndex = 7;
            // 
            // dgvTeacherList
            // 
            dgvTeacherList.AllowUserToAddRows = false;
            dgvTeacherList.AllowUserToDeleteRows = false;
            dgvTeacherList.AllowUserToOrderColumns = true;
            dgvTeacherList.AllowUserToResizeRows = false;
            dgvTeacherList.BackgroundColor = System.Drawing.Color.White;
            dgvTeacherList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvTeacherList.ColumnHeadersHeight = 26;
            dgvTeacherList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTeacherId,
            this.colTeacherCode,
            this.colLastName,
            this.colFirstName,
            this.colTitle,
            this.colPosition,
            this.colWorking,
            this.colBlank});
            dgvTeacherList.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvTeacherList.Location = new System.Drawing.Point(0, 0);
            dgvTeacherList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgvTeacherList.MultiSelect = false;
            dgvTeacherList.Name = "dgvTeacherList";
            dgvTeacherList.ReadOnly = true;
            dgvTeacherList.RowHeadersVisible = false;
            dgvTeacherList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvTeacherList.Size = new System.Drawing.Size(818, 279);
            dgvTeacherList.TabIndex = 1;
            // 
            // pagerPanel1
            // 
            this.pagerPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerPanel1.Location = new System.Drawing.Point(0, 279);
            this.pagerPanel1.Name = "pagerPanel1";
            this.pagerPanel1.Size = new System.Drawing.Size(818, 20);
            this.pagerPanel1.TabIndex = 0;
            // 
            // UsrTeacherList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UsrTeacherList";
            this.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Size = new System.Drawing.Size(840, 413);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(dgvTeacherList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFaculties;
        private System.Windows.Forms.ComboBox cmbDepartments;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeacherId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeacherCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlank;
        private CommonControls.Custom.PagerPanel pagerPanel1;
    }
}
