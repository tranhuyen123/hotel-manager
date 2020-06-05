namespace QLKhachSan.GUI.Controls
{
    partial class HoaDon
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvThongTinThanhToan = new System.Windows.Forms.DataGridView();
            this.clmStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMaDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLoaiPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNgaySD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlThongTinKhachHang = new System.Windows.Forms.Panel();
            this.txtTienTra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblTenKhach = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTinThanhToan)).BeginInit();
            this.pnlThongTinKhachHang.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 81);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thanh toán dịch vụ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnInHoaDon);
            this.panel2.Controls.Add(this.btnTimKiem);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pnlThongTinKhachHang);
            this.panel2.Controls.Add(this.txtSDT);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(1, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(843, 392);
            this.panel2.TabIndex = 1;
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.Location = new System.Drawing.Point(639, 96);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(75, 26);
            this.btnInHoaDon.TabIndex = 5;
            this.btnInHoaDon.Text = "In hóa đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = true;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click_1);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(494, 11);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 26);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTongTien);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.dgvThongTinThanhToan);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(3, 188);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(837, 199);
            this.panel3.TabIndex = 3;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(509, 18);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(58, 17);
            this.lblTongTien.TabIndex = 3;
            this.lblTongTien.Text = "1000 đ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(442, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tổng tiền : ";
            // 
            // dgvThongTinThanhToan
            // 
            this.dgvThongTinThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongTinThanhToan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmStt,
            this.clmMaDichVu,
            this.clmTenDichVu,
            this.Column3,
            this.Column4,
            this.clmMaPhong,
            this.clmLoaiPhong,
            this.clmNgaySD,
            this.clmThanhTien});
            this.dgvThongTinThanhToan.Location = new System.Drawing.Point(3, 49);
            this.dgvThongTinThanhToan.Name = "dgvThongTinThanhToan";
            this.dgvThongTinThanhToan.Size = new System.Drawing.Size(831, 143);
            this.dgvThongTinThanhToan.TabIndex = 1;
            // 
            // clmStt
            // 
            this.clmStt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmStt.HeaderText = "STT";
            this.clmStt.Name = "clmStt";
            this.clmStt.ReadOnly = true;
            this.clmStt.Width = 53;
            // 
            // clmMaDichVu
            // 
            this.clmMaDichVu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmMaDichVu.HeaderText = "Mã dịch vụ";
            this.clmMaDichVu.Name = "clmMaDichVu";
            this.clmMaDichVu.ReadOnly = true;
            // 
            // clmTenDichVu
            // 
            this.clmTenDichVu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmTenDichVu.HeaderText = "Tên dịch vụ";
            this.clmTenDichVu.Name = "clmTenDichVu";
            this.clmTenDichVu.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Số lượng DV";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Giá DV";
            this.Column4.Name = "Column4";
            // 
            // clmMaPhong
            // 
            this.clmMaPhong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmMaPhong.HeaderText = "Mã phòng";
            this.clmMaPhong.Name = "clmMaPhong";
            this.clmMaPhong.ReadOnly = true;
            // 
            // clmLoaiPhong
            // 
            this.clmLoaiPhong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmLoaiPhong.HeaderText = "Loại phòng";
            this.clmLoaiPhong.Name = "clmLoaiPhong";
            this.clmLoaiPhong.ReadOnly = true;
            // 
            // clmNgaySD
            // 
            this.clmNgaySD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmNgaySD.HeaderText = "Ngày sử dụng";
            this.clmNgaySD.Name = "clmNgaySD";
            this.clmNgaySD.ReadOnly = true;
            // 
            // clmThanhTien
            // 
            this.clmThanhTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmThanhTien.HeaderText = "Thành tiền";
            this.clmThanhTien.Name = "clmThanhTien";
            this.clmThanhTien.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(110, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(258, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thông tin dịch vụ thanh toán";
            // 
            // pnlThongTinKhachHang
            // 
            this.pnlThongTinKhachHang.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlThongTinKhachHang.Controls.Add(this.txtTienTra);
            this.pnlThongTinKhachHang.Controls.Add(this.label3);
            this.pnlThongTinKhachHang.Controls.Add(this.lblDiaChi);
            this.pnlThongTinKhachHang.Controls.Add(this.lblTenKhach);
            this.pnlThongTinKhachHang.Controls.Add(this.label7);
            this.pnlThongTinKhachHang.Controls.Add(this.label6);
            this.pnlThongTinKhachHang.Location = new System.Drawing.Point(88, 44);
            this.pnlThongTinKhachHang.Name = "pnlThongTinKhachHang";
            this.pnlThongTinKhachHang.Size = new System.Drawing.Size(510, 78);
            this.pnlThongTinKhachHang.TabIndex = 2;
            // 
            // txtTienTra
            // 
            this.txtTienTra.Location = new System.Drawing.Point(376, 12);
            this.txtTienTra.Name = "txtTienTra";
            this.txtTienTra.Size = new System.Drawing.Size(100, 20);
            this.txtTienTra.TabIndex = 5;
            this.txtTienTra.TextChanged += new System.EventHandler(this.txtTienTra_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tiền trả : ";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.Location = new System.Drawing.Point(138, 54);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(0, 20);
            this.lblDiaChi.TabIndex = 3;
            // 
            // lblTenKhach
            // 
            this.lblTenKhach.AutoSize = true;
            this.lblTenKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKhach.Location = new System.Drawing.Point(138, 10);
            this.lblTenKhach.Name = "lblTenKhach";
            this.lblTenKhach.Size = new System.Drawing.Size(0, 20);
            this.lblTenKhach.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Địa chỉ : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tên khách : ";
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(260, 11);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(228, 26);
            this.txtSDT.TabIndex = 1;
            this.txtSDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDT_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số điện thoại : ";
            // 
            // HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 510);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "HoaDon";
            this.Text = "Thanh Toán";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTinThanhToan)).EndInit();
            this.pnlThongTinKhachHang.ResumeLayout(false);
            this.pnlThongTinKhachHang.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlThongTinKhachHang;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblTenKhach;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvThongTinThanhToan;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnInHoaDon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTienTra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStt;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaDichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenDichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLoaiPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNgaySD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmThanhTien;
    }
}
