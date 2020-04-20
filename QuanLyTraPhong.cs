using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKhachSan.Model;
using System.Data.Entity.Migrations;

namespace QLKhachSan.GUI.Controls
{
    public partial class QuanLyTraPhong : Form
    {
        // QLKhachSanContext db = new QLKhachSanContext();
        public QuanLyTraPhong()
        {
            InitializeComponent();
            HienThiDanhSach();
        }

        QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities();

        public void HienThiDanhSach()
        {
             listViewP.Items.Clear();
            int stt = 1;
            var lstPhongThue = (from phong in db.PHONGs
                                join lp in db.LOAIPHONGs on phong.MaLoaiPhong equals lp.MaLoaiPhong
                               join suDungPhong in db.PHIEUTHUEPHONGs on phong.MaPhong equals suDungPhong.MaPhong
                               join khachHang in db.KHACHHANGs on suDungPhong.MaKH equals khachHang.MaKH
                               // where phong.TrangThai.Contains("Đã ở")
                                select new
                                {
                                    TENPHONG = phong.SoPhong,
                                    LOAIPHONG = lp.TenLoaiPhong,
                                    TENKH = khachHang.TenKH,
                                    SDT = khachHang.SDT,
                                    TGBATDAU = suDungPhong.NgayNhan,
                                    GIAPHONG = lp.GiaPhong
                                }).ToList();
            foreach (var phongThue in lstPhongThue)
            {
                string[] row =
                    {
                            stt.ToString(), phongThue.TENPHONG, phongThue.LOAIPHONG.ToString(), phongThue.TENKH,
                            phongThue.SDT, phongThue.TGBATDAU.ToString(), phongThue.GIAPHONG.ToString()
                        };
                ListViewItem item = new ListViewItem(row);
                stt++;
                listViewP.Items.Add(item);
            }
        }

      
       
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtFindByName_TextChanged(object sender, EventArgs e)
        {
            listViewP.Items.Clear();
            int stt = 1;
            var lstPhongThue = (from phong in db.PHONGs
                                join lp in db.LOAIPHONGs on phong.MaLoaiPhong equals lp.MaLoaiPhong
                                join suDungPhong in db.PHIEUTHUEPHONGs on phong.MaPhong equals suDungPhong.MaPhong
                                join khachHang in db.KHACHHANGs on suDungPhong.MaKH equals khachHang.MaKH
                                where phong.TrangThai.Contains("Đã ở") && khachHang.TenKH.Contains(txtFindByName.Text)
                                select new
                                {
                                    TENPHONG = phong.SoPhong,
                                    LOAIPHONG = lp.TenLoaiPhong,
                                    TENKH = khachHang.TenKH,
                                    SDT = khachHang.SDT,
                                    TGBATDAU = suDungPhong.NgayNhan,
                                    GIAPHONG = lp.GiaPhong
                                }).ToList();
           
            foreach (var phongThue in lstPhongThue)
            {
                string[] row =
                    {
                            stt.ToString(), phongThue.TENPHONG, phongThue.LOAIPHONG.ToString(), phongThue.TENKH,
                            phongThue.SDT, phongThue.TGBATDAU.ToString(), phongThue.GIAPHONG.ToString()
                        };
                ListViewItem item = new ListViewItem(row);
                stt++;
                listViewP.Items.Add(item);

            }
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            if (listViewP.SelectedIndices.Count > 0)
            {
                string tenPhong = listViewP.SelectedItems[0].SubItems[1].Text;
                string soDienThoai = listViewP.SelectedItems[0].SubItems[4].Text;
                var khachHang = (from kh in db.KHACHHANGs where kh.SDT.Equals(soDienThoai) select kh).FirstOrDefault();
                var phong = (from p in db.PHONGs where p.SoPhong.Equals(tenPhong) select p).FirstOrDefault();
                //var hoaDon = (from hd in db.HOADONs

                //          where hd.MaKH.Equals(khachHang.MaKH)  select hd).FirstOrDefault();
                var cthd = (from ct in db.CHITIETHDs
                           where ct.MaPhong.Equals(phong.MaPhong) 
                          // && ct.MaHD.Equals(hoaDon.MaHD)
                          select ct).FirstOrDefault();
                


                phong.TrangThai = "Trống";
                db.PHONGs.AddOrUpdate(phong);

                cthd.NgayTra = DateTime.Now;
                db.CHITIETHDs.AddOrUpdate(cthd);
               

                db.SaveChanges();
                HienThiDanhSach();
                
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn phòng để trả !");
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            string stt = listViewP.SelectedItems[0].SubItems[0].Text;
            string tenPhong = listViewP.SelectedItems[0].SubItems[1].Text;
            string tenLPhong = listViewP.SelectedItems[0].SubItems[2].Text;
            string soDienThoai = listViewP.SelectedItems[0].SubItems[4].Text;
            var phong = (from p in db.PHONGs where p.SoPhong.Equals(tenPhong) select p).FirstOrDefault();
            var loaiphong = (from lp in db.LOAIPHONGs where lp.TenLoaiPhong.Equals(tenLPhong) select lp).FirstOrDefault();
            var khachHang = (from kh in db.KHACHHANGs where kh.SDT.Equals(soDienThoai) select kh).FirstOrDefault();
            lbMaPhong.Text = phong.MaPhong.ToString();
            lbTenPhong.Text = phong.SoPhong.ToString();
            lbTrangThai.Text = phong.TrangThai.ToString();
            lbLoaiPhong.Text = loaiphong.TenLoaiPhong.ToString();
            lbGiaPhong.Text = loaiphong.GiaPhong.ToString();
            lbMaKh.Text = khachHang.MaKH.ToString();
            lbTenKh.Text = khachHang.TenKH;
            lbSdt.Text = soDienThoai;
            lbDiaChi.Text = khachHang.DiaChi;
            lbCmt.Text = khachHang.CMND;

        }
    }
    }