namespace QLKhachSan.GUI.Controls
{
    partial class ucDichVu
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbSoLuong = new System.Windows.Forms.ComboBox();
            this.cbbPhong = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbDichVu = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTenThongKe = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(3, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(850, 281);
            this.panel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(376, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dịch Vụ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(37, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 231);
            this.panel1.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(604, 84);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(104, 54);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbSoLuong);
            this.groupBox1.Controls.Add(this.cbbPhong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbbDichVu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(29, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn dịch vụ";
            // 
            // cbbSoLuong
            // 
            this.cbbSoLuong.FormattingEnabled = true;
            this.cbbSoLuong.Location = new System.Drawing.Point(372, 119);
            this.cbbSoLuong.Name = "cbbSoLuong";
            this.cbbSoLuong.Size = new System.Drawing.Size(52, 21);
            this.cbbSoLuong.TabIndex = 17;
            // 
            // cbbPhong
            // 
            this.cbbPhong.FormattingEnabled = true;
            this.cbbPhong.Location = new System.Drawing.Point(111, 61);
            this.cbbPhong.Name = "cbbPhong";
            this.cbbPhong.Size = new System.Drawing.Size(184, 21);
            this.cbbPhong.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Số Lượng:";
            // 
            // cbbDichVu
            // 
            this.cbbDichVu.FormattingEnabled = true;
            this.cbbDichVu.Location = new System.Drawing.Point(111, 119);
            this.cbbDichVu.Name = "cbbDichVu";
            this.cbbDichVu.Size = new System.Drawing.Size(184, 21);
            this.cbbDichVu.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Phòng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Dịch vụ:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgvThongKe);
            this.panel2.Controls.Add(this.lblTenThongKe);
            this.panel2.Location = new System.Drawing.Point(3, 288);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(850, 227);
            this.panel2.TabIndex = 4;
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.phong,
            this.dichVu,
            this.soLuong,
            this.giaDV});
            this.dgvThongKe.Location = new System.Drawing.Point(37, 33);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.Size = new System.Drawing.Size(784, 154);
            this.dgvThongKe.TabIndex = 10;
            // 
            // STT
            // 
            this.STT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.STT.DataPropertyName = "STT";
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 50;
            // 
            // phong
            // 
            this.phong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.phong.DataPropertyName = "Phong";
            this.phong.HeaderText = "Phòng";
            this.phong.Name = "phong";
            this.phong.ReadOnly = true;
            // 
            // dichVu
            // 
            this.dichVu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dichVu.DataPropertyName = "DichVu";
            this.dichVu.HeaderText = "Dịch Vụ";
            this.dichVu.Name = "dichVu";
            // 
            // soLuong
            // 
            this.soLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.soLuong.DataPropertyName = "SoLuong";
            this.soLuong.HeaderText = "Số Lượng";
            this.soLuong.Name = "soLuong";
            this.soLuong.Width = 50;
            // 
            // giaDV
            // 
            this.giaDV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.giaDV.DataPropertyName = "GiaDV";
            this.giaDV.HeaderText = "Giá Dịch Vụ";
            this.giaDV.Name = "giaDV";
            // 
            // lblTenThongKe
            // 
            this.lblTenThongKe.AutoSize = true;
            this.lblTenThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenThongKe.ForeColor = System.Drawing.Color.Red;
            this.lblTenThongKe.Location = new System.Drawing.Point(377, 10);
            this.lblTenThongKe.Name = "lblTenThongKe";
            this.lblTenThongKe.Size = new System.Drawing.Size(113, 20);
            this.lblTenThongKe.TabIndex = 8;
            this.lblTenThongKe.Text = "Bảng thống kê";
            // 
            // ucDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 522);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "ucDichVu";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbDichVu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.Label lblTenThongKe;
        private System.Windows.Forms.ComboBox cbbSoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn phong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaDV;
        private System.Windows.Forms.ComboBox cbbPhong;
    }
}
