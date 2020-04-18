<<<<<<< HEAD
﻿using QLKhachSan.GUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKhachSan.Model;



namespace QLKhachSan.GUI
{
    public partial class QuanLyKhachSan : Form
    {
        public QuanLyKhachSan()
        {
            InitializeComponent();
        }

        public void quảnLýNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
                QuanLyNhanVien qlnd = new QuanLyNhanVien();
                qlnd.ShowDialog();
           
              

           
        }

        private void tênNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tênNhânViênToolStripMenuItem.Text = Cons.cons.loginNhanVien.HoTenNV;

        }
        QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities();
        public static int quyen;

        private void QuanLyKhachSan_Load(object sender, EventArgs e)
        {
           
            if (quyen == 2)
            {
                quảnLýNgườiDùngToolStripMenuItem.Visible = false;
                tênNhânViênToolStripMenuItem.Text = Cons.cons.loginNhanVien.HoTenNV;
            }
            else
            {
                tênNhânViênToolStripMenuItem.Text = Cons.cons.loginNhanVien.HoTenNV;
            }

        }

        private void quảnLýPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quanlyphong qlp = new Quanlyphong();
            qlp.ShowDialog();

        }

        private void quảnLýThiếtBịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyThietBi qltb = new QuanLyThietBi();
            qltb.ShowDialog();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            QuanLyKhachHang qlkh = new QuanLyKhachHang();
            qlkh.ShowDialog();

        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýThuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyThuePhong qltp = new QuanLyThuePhong();
            qltp.ShowDialog();
        }

        private void quảnLýDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyDichVu a = new QuanLyDichVu();
            a.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon b = new HoaDon();
            b.ShowDialog();
        }

        private void quảnLýThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyTraPhong c = new QuanLyTraPhong();
            c.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cons.cons.loginNhanVien = null; ;
            this.Close();
        }

        private void hướngDẫnCáchĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Huongdan hd = new Huongdan();
            hd.ShowDialog();
        }

        private void quảnLýSửDụngDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucDichVu a = new ucDichVu();
            a.ShowDialog();
        }

        private void hướngDẫnQuảnLýPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hướng_dẫn_quản_lý_phòng a = new Hướng_dẫn_quản_lý_phòng();
            a.ShowDialog();
        }

        private void hướngDẫnDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hướng_dẫn_dịch_vụ a = new Hướng_dẫn_dịch_vụ();
            a.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangKy a = new DangKy();
           
            a.ShowDialog();
           
          
           
        }
    }
}
=======
﻿using QLKhachSan.GUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKhachSan.Model;



namespace QLKhachSan.GUI
{
    public partial class QuanLyKhachSan : Form
    {
        public QuanLyKhachSan()
        {
            InitializeComponent();
        }

        public void quảnLýNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
                QuanLyNhanVien qlnd = new QuanLyNhanVien();
                qlnd.ShowDialog();
           
              

           
        }

        private void tênNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void QuanLyKhachSan_Load(object sender, EventArgs e)
        {
            tênNhânViênToolStripMenuItem.Text = Cons.cons.loginNhanVien.HoTenNV;
        }

        private void quảnLýPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quanlyphong qlp = new Quanlyphong();
            qlp.ShowDialog();

        }

        private void quảnLýThiếtBịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyThietBi qltb = new QuanLyThietBi();
            qltb.ShowDialog();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            QuanLyKhachHang qlkh = new QuanLyKhachHang();
            qlkh.ShowDialog();

        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýThuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyThuePhong qltp = new QuanLyThuePhong();
            qltp.ShowDialog();
        }

        private void quảnLýDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyDichVu a = new QuanLyDichVu();
            a.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon b = new HoaDon();
            b.ShowDialog();
        }

        private void quảnLýThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyTraPhong c = new QuanLyTraPhong();
            c.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cons.cons.loginNhanVien = null; ;
            this.Close();
        }

        private void hướngDẫnCáchĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Huongdan hd = new Huongdan();
            hd.ShowDialog();
        }

        private void quảnLýSửDụngDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucDichVu a = new ucDichVu();
            a.ShowDialog();
        }

        private void hướngDẫnQuảnLýPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hướng_dẫn_quản_lý_phòng a = new Hướng_dẫn_quản_lý_phòng();
            a.ShowDialog();
        }

        private void hướngDẫnDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hướng_dẫn_dịch_vụ a = new Hướng_dẫn_dịch_vụ();
            a.ShowDialog();
        }
    }
}
>>>>>>> 4c4a254da6d7397479b0b9d2ee8dcc949f6369b8
