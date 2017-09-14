namespace SystemMgtComponent.WorkItems.ApartmentIntegratingExcel
{
    partial class FrmConnectionConfig
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
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtInputFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.line1 = new CommonControls.Custom.Line();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbxStartRowIndex = new CommonControls.Custom.NumberOnlyTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbManagerCostOld = new System.Windows.Forms.ComboBox();
            this.cmbSumMoney = new System.Windows.Forms.ComboBox();
            this.cmbDayPay = new System.Windows.Forms.ComboBox();
            this.cmbPayWater = new System.Windows.Forms.ComboBox();
            this.cmbPayManager = new System.Windows.Forms.ComboBox();
            this.cmbNameHeadApartment = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbSubOrgId = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Location = new System.Drawing.Point(532, 31);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(50, 23);
            this.btnSelectFile.TabIndex = 5;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtInputFilePath
            // 
            this.txtInputFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFilePath.Location = new System.Drawing.Point(12, 32);
            this.txtInputFilePath.Name = "txtInputFilePath";
            this.txtInputFilePath.ReadOnly = true;
            this.txtInputFilePath.Size = new System.Drawing.Size(514, 22);
            this.txtInputFilePath.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chỉ đường dẫn đến tập tin MS Excel chứa dữ liệu cần tích hợp.";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.label8);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(594, 65);
            this.panel9.TabIndex = 61;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label8.Size = new System.Drawing.Size(594, 65);
            this.label8.TabIndex = 65;
            this.label8.Text = "Phân tích dữ liệu từ tập tin MS Excel và đồng bộ với cơ sở dữ liệu của hệ thống.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Line3DStyle = CommonControls.Custom.Line3DStyle.Inset;
            this.line1.Location = new System.Drawing.Point(0, 65);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(594, 2);
            this.line1.TabIndex = 62;
            this.line1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.tbxStartRowIndex);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.cmbManagerCostOld);
            this.panel1.Controls.Add(this.cmbSumMoney);
            this.panel1.Controls.Add(this.cmbDayPay);
            this.panel1.Controls.Add(this.cmbPayWater);
            this.panel1.Controls.Add(this.cmbPayManager);
            this.panel1.Controls.Add(this.cmbNameHeadApartment);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cmbSubOrgId);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSelectFile);
            this.panel1.Controls.Add(this.txtInputFilePath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 67);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.panel1.Size = new System.Drawing.Size(594, 388);
            this.panel1.TabIndex = 63;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 268);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(424, 16);
            this.label16.TabIndex = 76;
            this.label16.Text = "Lưu ý: Chương trình sẽ bỏ qua những dòng có cột f_masv và id để trống.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(436, 236);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(152, 16);
            this.label15.TabIndex = 75;
            this.label15.Text = "(không tính dòng tiêu đề)";
            // 
            // tbxStartRowIndex
            // 
            this.tbxStartRowIndex.Location = new System.Drawing.Point(361, 233);
            this.tbxStartRowIndex.Name = "tbxStartRowIndex";
            this.tbxStartRowIndex.Size = new System.Drawing.Size(75, 22);
            this.tbxStartRowIndex.TabIndex = 74;
            this.tbxStartRowIndex.Text = "2";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 236);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(339, 16);
            this.label14.TabIndex = 73;
            this.label14.Text = "Cấu hình vị trí dòng dữ liệu đầu tiên trên tập tin MS Excel:";
            // 
            // cmbManagerCostOld
            // 
            this.cmbManagerCostOld.FormattingEnabled = true;
            this.cmbManagerCostOld.Location = new System.Drawing.Point(482, 87);
            this.cmbManagerCostOld.Name = "cmbManagerCostOld";
            this.cmbManagerCostOld.Size = new System.Drawing.Size(75, 22);
            this.cmbManagerCostOld.TabIndex = 70;
            // 
            // cmbSumMoney
            // 
            this.cmbSumMoney.FormattingEnabled = true;
            this.cmbSumMoney.Location = new System.Drawing.Point(482, 120);
            this.cmbSumMoney.Name = "cmbSumMoney";
            this.cmbSumMoney.Size = new System.Drawing.Size(75, 22);
            this.cmbSumMoney.TabIndex = 70;
            // 
            // cmbDayPay
            // 
            this.cmbDayPay.FormattingEnabled = true;
            this.cmbDayPay.Location = new System.Drawing.Point(178, 204);
            this.cmbDayPay.Name = "cmbDayPay";
            this.cmbDayPay.Size = new System.Drawing.Size(75, 22);
            this.cmbDayPay.TabIndex = 68;
            // 
            // cmbPayWater
            // 
            this.cmbPayWater.FormattingEnabled = true;
            this.cmbPayWater.Location = new System.Drawing.Point(178, 176);
            this.cmbPayWater.Name = "cmbPayWater";
            this.cmbPayWater.Size = new System.Drawing.Size(75, 22);
            this.cmbPayWater.TabIndex = 67;
            // 
            // cmbPayManager
            // 
            this.cmbPayManager.FormattingEnabled = true;
            this.cmbPayManager.Location = new System.Drawing.Point(178, 148);
            this.cmbPayManager.Name = "cmbPayManager";
            this.cmbPayManager.Size = new System.Drawing.Size(75, 22);
            this.cmbPayManager.TabIndex = 66;
            // 
            // cmbNameHeadApartment
            // 
            this.cmbNameHeadApartment.FormattingEnabled = true;
            this.cmbNameHeadApartment.Location = new System.Drawing.Point(178, 120);
            this.cmbNameHeadApartment.Name = "cmbNameHeadApartment";
            this.cmbNameHeadApartment.Size = new System.Drawing.Size(75, 22);
            this.cmbNameHeadApartment.TabIndex = 65;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(382, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 16);
            this.label10.TabIndex = 60;
            this.label10.Text = "Cột Nợ phí cũ:";
            // 
            // cmbSubOrgId
            // 
            this.cmbSubOrgId.FormattingEnabled = true;
            this.cmbSubOrgId.Location = new System.Drawing.Point(178, 92);
            this.cmbSubOrgId.Name = "cmbSubOrgId";
            this.cmbSubOrgId.Size = new System.Drawing.Size(75, 22);
            this.cmbSubOrgId.TabIndex = 64;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(382, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 16);
            this.label9.TabIndex = 60;
            this.label9.Text = "Cột Tổng Tiền:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 16);
            this.label7.TabIndex = 59;
            this.label7.Text = "Cột Thời Gian Nợ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 58;
            this.label6.Text = "Cột Tiền Nước:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "Cột Tiền Quản Lý:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Cột Tên Chủ Hộ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "Cột Số Căn Hộ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 16);
            this.label2.TabIndex = 54;
            this.label2.Text = "Cấu hình vị trí các cột dữ liệu trên tập tin MS Excel:";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(376, 354);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 26);
            this.btnNext.TabIndex = 53;
            this.btnNext.Text = "Tiếp Tục";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(482, 354);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmConnectionConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(594, 455);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.Name = "FrmConnectionConfig";
            this.Text = "Tích Hợp - Cấu Hình Kết Nối";
            this.panel9.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtInputFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel9;
        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private CommonControls.Custom.NumberOnlyTextBox tbxStartRowIndex;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbSumMoney;
        private System.Windows.Forms.ComboBox cmbDayPay;
        private System.Windows.Forms.ComboBox cmbPayWater;
        private System.Windows.Forms.ComboBox cmbPayManager;
        private System.Windows.Forms.ComboBox cmbNameHeadApartment;
        private System.Windows.Forms.ComboBox cmbSubOrgId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbManagerCostOld;
        private System.Windows.Forms.Label label10;
    }
}