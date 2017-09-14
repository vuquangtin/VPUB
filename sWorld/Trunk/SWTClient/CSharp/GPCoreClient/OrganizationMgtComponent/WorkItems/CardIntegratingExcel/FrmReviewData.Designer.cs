﻿namespace SystemMgtComponent.WorkItems.CardIntegratingExcel
{
    partial class FrmReviewData
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
            this.line1 = new CommonControls.Custom.Line();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDataIntegration = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblChooseCheck = new System.Windows.Forms.Label();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnIntegration = new System.Windows.Forms.Button();
            this.dgvRecords = new CommonControls.Custom.CommonDataGridView();
            this.panel9.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // line1
            // 
            this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Line3DStyle = CommonControls.Custom.Line3DStyle.Inset;
            this.line1.Location = new System.Drawing.Point(0, 75);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(594, 2);
            this.line1.TabIndex = 63;
            this.line1.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.lblDataIntegration);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(594, 75);
            this.panel9.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 39);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(445, 14);
            this.label8.TabIndex = 1;
            this.label8.Text = "Phân tích dữ liệu từ tập tin MS Excel và đồng bộ với cơ sở dữ liệu của hệ thống.";
            // 
            // lblDataIntegration
            // 
            this.lblDataIntegration.AutoSize = true;
            this.lblDataIntegration.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataIntegration.Location = new System.Drawing.Point(12, 22);
            this.lblDataIntegration.Name = "lblDataIntegration";
            this.lblDataIntegration.Size = new System.Drawing.Size(111, 14);
            this.lblDataIntegration.TabIndex = 0;
            this.lblDataIntegration.Text = "Tích Hợp Dữ Liệu";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblChooseCheck);
            this.panel3.Controls.Add(this.cmbTables);
            this.panel3.Controls.Add(this.lblTotalRecords);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnIntegration);
            this.panel3.Controls.Add(this.dgvRecords);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 77);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel3.Size = new System.Drawing.Size(594, 378);
            this.panel3.TabIndex = 64;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // lblChooseCheck
            // 
            this.lblChooseCheck.AutoSize = true;
            this.lblChooseCheck.Location = new System.Drawing.Point(13, 11);
            this.lblChooseCheck.Name = "lblChooseCheck";
            this.lblChooseCheck.Size = new System.Drawing.Size(192, 16);
            this.lblChooseCheck.TabIndex = 17;
            this.lblChooseCheck.Text = "Chọn bảng dữ liệu cần kiểm tra:";
            // 
            // cmbTables
            // 
            this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(211, 8);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(200, 22);
            this.cmbTables.TabIndex = 16;
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalRecords.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalRecords.Location = new System.Drawing.Point(13, 339);
            this.lblTotalRecords.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(356, 26);
            this.lblTotalRecords.TabIndex = 15;
            this.lblTotalRecords.Text = "lblTotalRecords";
            this.lblTotalRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(481, 341);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Hủy Bỏ...";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnIntegration
            // 
            this.btnIntegration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIntegration.Location = new System.Drawing.Point(375, 341);
            this.btnIntegration.Name = "btnIntegration";
            this.btnIntegration.Size = new System.Drawing.Size(100, 26);
            this.btnIntegration.TabIndex = 13;
            this.btnIntegration.Text = "Tích Hợp...";
            this.btnIntegration.UseVisualStyleBackColor = true;
            this.btnIntegration.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // dgvRecords
            // 
            this.dgvRecords.AllowUserToAddRows = false;
            this.dgvRecords.AllowUserToDeleteRows = false;
            this.dgvRecords.AllowUserToOrderColumns = true;
            this.dgvRecords.AllowUserToResizeRows = false;
            this.dgvRecords.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecords.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRecords.ColumnHeadersHeight = 26;
            this.dgvRecords.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.dgvRecords.Location = new System.Drawing.Point(13, 43);
            this.dgvRecords.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.ReadOnly = true;
            this.dgvRecords.RowHeadersVisible = false;
            this.dgvRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecords.Size = new System.Drawing.Size(566, 280);
            this.dgvRecords.TabIndex = 11;
            // 
            // FrmReviewData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 455);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.panel9);
            this.Name = "FrmReviewData";
            this.Text = "Kiểm Tra Dữ Liệu Từ Tập Tin Excel";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControls.Custom.Line line1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDataIntegration;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnIntegration;
        private CommonControls.Custom.CommonDataGridView dgvRecords;
        private System.Windows.Forms.Label lblChooseCheck;
        private System.Windows.Forms.ComboBox cmbTables;

    }
}